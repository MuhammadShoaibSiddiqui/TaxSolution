using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
//
using TaxSolution.StringFun01;
using TaxSolution.PrintDataSets;
using TaxSolution.PrintReport;
using TaxSolution.PrintViewer;

// *** Important Note ***  Voucher Type is now ALCP_Validation # 69 
// *** Important Note ***  Journal Voucher 267, CRV 268, CPV 269, BRV 270, BPV 271

namespace TaxSolution
{
    enum GColCP
    {
        Status = 0,
        tranid = 1,
        snum = 2,
        acid = 3,
        acstrid = 4,
        actitle = 5,
        Desc = 6,
        debit = 7,
        credit = 8,
        LastCol = 9
    }

    public partial class frmCPVoc : Form
    {
        DateTime now = DateTime.Now;
        List<string> fManySQL = null;                      // List string for storing Multiple Queries
        //
        string fRptTitle = string.Empty;
        bool fFormClosing = false;

        bool ftTIsBalloon = true;
        bool fEditMod = false;
        int fEditRow = 0;
        //bool fFrmLoading = true;                    // Form is Loading Controls (to accomodate Load event so that first time loading requirement is done)
        int fTErr = 0;                              // Total Errors while Saving or other operation.
        string ErrrMsg = string.Empty;              // To display error message if any.
        string fLastID = string.Empty;              // Last Voucher/Doc ID (Saved new or modified)
        //
        int fDocTypeID = clsGVar.CPV;                         // Voucher/Doc Type ID
        int fDocFiscal = 1;                         // Accounting / Fiscal Period    
        //int fTNOA = 0;                              // Total Number of Attachments.    
        int fTNOT = 0;                              // Total Number of Grid Transactions.
        decimal fDocAmt = 0;                        // Document Amount Debit or Credit for DocMaster Field.
        string fDocWhere = string.Empty;            // Where string to build where clause for Voucher level
        int fLastRow = 0;                           // Last row number of the grid.
        Int64 fDocID = 1;
        bool fGridControl = false;                  // To overcome Grid's tabing

        bool fSingleEntryAllowed = true;            // for the time being later set to false.
        bool fDocAlreadyExists = false;             // Check if Doc/voucher already exists (Edit Mode = True, New Mode = false)
        bool fIDConfirmed = false;                  // Account ID is valid and existance in Table is confirmed.
        bool fCellEditMode = false;                 // Cell Edit Mode

        public frmCPVoc()
        {
            InitializeComponent();
                        //frmMain.groupMain.
            //this.Parent.BringToFront = true;
            //this.BringToFront = true;

        }

         private void btn_FromDate_Click(object sender, EventArgs e)
        {
            if (pnlCalander.Visible)
            {
                pnlCalander.Visible = false;
                return;
            }
            else
            {
                //if (btnDetailTop.Text.ToString() == '\u25BC'.ToString())    // Down Arrow/at minimum width position
                //{
                //     btnDetailTop.PerformClick();
                //}
                //gBMonth.Visible = true;
                pnlCalander.Visible = true;
                msk_VocDate.Text = mCalendarMain.SelectionStart.ToString();

                mCalendarMain.Focus();
            }
        }

        private void btn_HideMonth_Click(object sender, EventArgs e)
        {
            pnlCalander.Visible = false;
        }

        private void mCalendarMain_DateChanged(object sender, DateRangeEventArgs e)
        {
            msk_VocDate.Text = mCalendarMain.SelectionStart.ToString();
        }

        private void frmJournalVoc_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            SetMaxLen();
            SetToolTips();
            LoadInitialControls();
            ButtonImageSetting();
            btn_PinID_Click(sender, e);
            //btn_EnableDisable(false);
            sSMaster.Visible = false;
            msk_VocDate.Text = DateTime.Now.ToString();

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Exit_Click_1(object sender, EventArgs e)
        {
            fFormClosing = true;
            this.Close();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ClearThisForm();
        }
        //
        private void ClearThisForm()
        { 
            lblDocID.Text = string.Empty;
            txtManualDoc.Text = string.Empty;
            txtManualDoc.Enabled = true;
            txtRemarks.Text = string.Empty;
            lblTotalCr.Text = string.Empty;
            lblTotalDr.Text = string.Empty;
            //
            if (grdVoucher.Rows.Count > 0)
            {
                grdVoucher.Rows.Clear();
            }
            ResetFields();
            chk_Edit.Checked = false;
            txtManualDoc.Focus();
        }
        private void ResetFields()
        {
            // Reset Form Level Variables/Fields
            fEditMod = false;
            fTNOT = 0;
            fDocAmt = 0;
            fDocWhere = string.Empty;
            fLastRow = 0;
        }
        //
        private void SetMaxLen()
        {
            txtManualDoc.MaxLength = 20;
            txtRemarks.MaxLength = 50;
            msk_VocMasterGLID.Mask = "#-#-##-##-####";
            msk_VocMasterGLID.HidePromptOnLeave = true;
            mCalendarMain.SelectionStart = mCalendarMain.TodayDate;
            msk_VocDate.Mask = "00/00/0000";
            msk_VocDate.ValidatingType = typeof(System.DateTime);
        }
        //
        private void SetToolTips()
        {
            if (ftTIsBalloon)
            {
                tTMDtl.IsBalloon = true;
            }
            else
            {
                tTMDtl.IsBalloon = false;
            }
            // ToolTip Main Buttons:
            tTMDtl.SetToolTip(btn_Save, "Alt + s, Save New record or Modify/Update an existing Voucher/Doc.");
            //tTMDtl.SetToolTip(btn_SaveNContinue, "Alt + e, Save data and continue work on current Voucher/Doc.");
            tTMDtl.SetToolTip(btn_Clear, "Alt + c, Clear all input control/items on this Voucher/Doc.");
            tTMDtl.SetToolTip(btn_Delete, "Alt + d, Delete currently selected Voucher/Doc.");
            tTMDtl.SetToolTip(btn_View, "Alt + v, View Voucher/Doc in report viewer.");
            tTMDtl.SetToolTip(btn_Exit, "Alt + x, Close this form and exit to the Main Form.");
            //
            tTMDtl.SetToolTip(btn_Month, "Alt + m, Show / Hide Month view for date input");
            tTMDtl.SetToolTip(txtRemarks, "Enter Manual Voucher, Max. length: " + txtManualDoc.MaxLength.ToString() + " Numeric digits");
            tTMDtl.SetToolTip(txtRemarks, "Enter Remarks, Max. length: " + txtRemarks.MaxLength.ToString() + " Numeric digits");
        }

        private void ButtonImageSetting()
        {
            btn_Exit.Image = Properties.Resources.FormExit;
            btn_Save.Image = Properties.Resources.saveHS;
            //btn_ParentClear.Image = Properties.Resources.BaBa_clear;
            btn_Clear.Image = Properties.Resources.BaBa_clear;
            btn_Delete.Image = Properties.Resources.ico_delete;
            btn_PinID.Image = Properties.Resources.tiny_pin;
            //btn_PinParentID.Image = Properties.Resources.tiny_pin;
            //btn_Refresh.Image = Properties.Resources.Refresh;
            //btn_SearchTree.Image = Properties.Resources.x_preview_16x16;
            //btn_Address.Image = Properties.Resources.ico_inbox;
            //btn_OpeningBalance.Image = Properties.Resources.ico_admin;
            //btn_NextID.Image = Properties.Resources.ico_arrow_r;
        }

        //-----------------------------------------------
        private void EDButtons(bool pFlage)
        {
            if (pFlage)
            {
            }
            else
            {
            }
        }
        //
        private void LoadInitialControls()
        {
            // 1 = dGV Grid Control
            // 2 = Column Total (Total number of Columns for cross verification with other parameters like width, format)
            // 3 = Column Header
            // 4 = Column Width to be displayed on Grid
            // 5 = Column MaxInputLen   // 0 = unlimited, 
            // 6 = Column Format        // T = Text, N = Numeric, H = Hiden
            // 7 = Column ReadOnly      // 1 = ReadOnly, 0 = Not ReadOnly
            // 8 = Grid Color Scheme    // Default = 1
            // RO 
 
            string lHDR = "";
            lHDR += "Status";                       // 0-   Hiden
            lHDR += ",TranID";                      // 1-   Hiden
            lHDR += ",SN";                          // 2-   

            lHDR += ",ID";                        // 3-
            lHDR += ",Code #";                        // 3-
            lHDR += ",Name";         // 4-
            lHDR += ",Description";               // 5-
            lHDR += ",Debit";                       // 9-
            lHDR += ",Credit";                      // 10-

            clsDbManager.SetGridHeaderCmb(
                grdVoucher,
                9,
                lHDR,
                " 2, 2, 3, 5,15,20,20,12,12",
                " 0, 0, 0, 0, 0, 0, 0, 0, 0",
                " 4, 4, 0, 4, 8, 0, 4, 0,20",
                " H, H, T, H, T, T, T,N2, H",
                " 1, 1, 1, 1, 1, 1, 1, 1, 1",
                "DATA",
                null,
                null,
                null,
                null,
                false,
                2);

        }
        private void frmJournalVoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!fGridControl)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                //e.Handled = true;
                //SendKeys.Send("{TAB}");
            }

            if (e.KeyCode == Keys.Insert)
            {
                if (pnlVocTran.Visible == false)
                {
                    if (fEditMod == true)
                    {
                        if (chk_Edit.Checked == false)
                        {
                            return;
                        }
                    }
                    pnlVocTran.Visible = true;
                    btn_Add.Text = "&Add";

                    msk_AccountID.Focus();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (pnlVocTran.Visible == true)
                {
                    pnlVocTran.Visible = false;
                    if (grdVoucher.Rows.Count>2)
                    {
                        grdVoucher.Focus();
                    }
                    else
                    {
                        msk_VocDate.Focus();
                    }
                }

            }
            // DELETE
            if (e.KeyCode == Keys.Delete)
            {
                // MessageBox.Show("Delete key is pressed");
                //if (grdVoucher.Rows[lLastRow].Cells[(int)GCol.acid].Value == null && grdVoucher.Rows[lLastRow].Cells[(int)GCol.refid].Value == null)
                if (!fGridControl)
                {
                    return;
                }

                if (grdVoucher.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure, really want to Delete row ?", "Delete Row", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        grdVoucher.Rows.RemoveAt(grdVoucher.CurrentRow.Index);
                        SumVoc();
                        return;
                    }
                }
            }

            // Edit
            if (e.KeyCode == Keys.Space)
            {

                // MessageBox.Show("Delete key is pressed");
                //if (grdVoucher.Rows[lLastRow].Cells[(int)GCol.acid].Value == null && grdVoucher.Rows[lLastRow].Cells[(int)GCol.refid].Value == null)
                if (!fGridControl)
                {
                    return;
                }

                if (grdVoucher.Rows.Count > 0)
                {
                    if (fEditMod == true)
                    {
                        if (chk_Edit.Checked == false)
                        {
                            return;
                        }
                    }

                    //Current Row
                    fEditRow = grdVoucher.CurrentRow.Index;

                    //lblAcID.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCP.acid].Value.ToString();
                    lblAccountName.Tag = grdVoucher.Rows[fEditRow].Cells[(int)GColCP.acid].Value.ToString();
                    msk_AccountID.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCP.acstrid].Value.ToString();
                    lblAccountName.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCP.actitle].Value.ToString();
                    txtNarration.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCP.Desc].Value.ToString();
                    txtDebit.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCP.debit].Value.ToString();
                    txtCredit.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCP.credit].Value.ToString();
                    btn_Add.Text = "&Update";

                    pnlVocTran.Visible = true;
                    msk_AccountID.Focus();

                }
            }

        }

        private void grdVoucher_Enter(object sender, EventArgs e)
        {
            fGridControl = true;
        }

        private void grdVoucher_Leave(object sender, EventArgs e)
        {
            fGridControl = false;
        }

        private void btn_FocusGrid_Click(object sender, EventArgs e)
        {
            grdVoucher.Focus();
        }

        private void frmJournalVoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (grdVoucher.Rows.Count > 1)
                {
                    if (MessageBox.Show("Are You Sure To Exit Form ?", this.Text.ToString(), MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Form Closing: " + ex.Message, this.Text.ToString());
            }
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            //sender.ToString().ToUpper();
            //txtRemarks.Text = txtRemarks.Text + sender.ToString().ToUpper();
        }

        private void msk_AccountID_Leave(object sender, EventArgs e)
        {
            if (msk_AccountID.Text.ToString().Trim('_', ' ', '-') == "")
            {
                MessageBox.Show("GL Code is Empty! Unable to Process...", this.Text.ToString());
                msk_AccountID.Focus();
            }

            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  
            tSQL = "Select top 1 ac_title, ac_id, ac_strid from gl_ac Where ";
            tSQL = tSQL + " ac_strid = '" + msk_AccountID.Text + "';";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "gl_Ac");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblAccountName.Text = dRow.ItemArray.GetValue(0).ToString();
                    lblAccountName.Tag = dRow.ItemArray.GetValue(1).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();
                    if (txtNarration.Text == "")
                    {
                        txtNarration.Text = "PAYMENT ";
                    }
                }
                else
                {
                    MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                    msk_AccountID.Focus();
                }

            }
            catch 
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                msk_AccountID.Focus();
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (msk_AccountID.Text.ToString().Trim(' ', '-') == "")
            {
                MessageBox.Show("Invalid GL Code...", this.Text.ToString());
                msk_AccountID.Focus();
                return;
            }

            if (txtNarration.Text == "")
            {
                MessageBox.Show("Transaction Description is Empty! Unable to Process...", this.Text.ToString());
                txtNarration.Focus();
                return;
            }

            if (lblAccountName.Tag == "0")
            {
                MessageBox.Show("Invalid GL ID...", this.Text.ToString());
                return;
            }

            if (txtDebit.Text == "0.00")
            {
                MessageBox.Show("Zero Amount Entry...", this.Text.ToString());
                txtDebit.Focus();
                return;
            }

            if (btn_Add.Text.ToString() == "&Add")
            {
                grdVoucher.Rows.Add(1, 1, 1,
                    lblAccountName.Tag,
                    msk_AccountID.Text,
                    lblAccountName.Text,
                    txtNarration.Text,
                    txtDebit.Text,
                    txtCredit.Text
                    );
                    //lblAcID.Text,
            }
            else if (btn_Add.Text.ToString() == "&Update")
            {
                //grdVoucher.Rows[fEditRow].Cells[(int)GColCP.acid].Value = lblAcID.Text;
                grdVoucher.Rows[fEditRow].Cells[(int)GColCP.acid].Value = lblAccountName.Tag;
                grdVoucher.Rows[fEditRow].Cells[(int)GColCP.acstrid].Value = msk_AccountID.Text;
                grdVoucher.Rows[fEditRow].Cells[(int)GColCP.actitle].Value = lblAccountName.Text;
                grdVoucher.Rows[fEditRow].Cells[(int)GColCP.Desc].Value = txtNarration.Text;
                grdVoucher.Rows[fEditRow].Cells[(int)GColCP.debit].Value = txtDebit.Text;
                grdVoucher.Rows[fEditRow].Cells[(int)GColCP.credit].Value = txtCredit.Text;
                btn_Add.Text = "&Add";
                pnlVocTran.Visible = false;
                grdVoucher.Focus();
                //msk_AccountID.Focus();
            }
            SumVoc();
            ClearSub();
            msk_AccountID.Focus();
        }
        //===============================================333333
        private void ClearSub()
        {
            lblAcID.Text = "";
            msk_AccountID.Text = "";
            lblAccountName.Text = "";
            lblAccountName.Tag = 0;
            txtNarration.Text = "PAYMENT ";
            txtDebit.Text = "0";
            txtCredit.Text = "0";
        }
        private void SumVoc()
        {
            bool bcheck;
            decimal fDebit = 0;
            decimal fCredit = 0;
            decimal rtnVal = 0;
            decimal outValue = 0;
 
            for (int i = 0; i < grdVoucher.RowCount; i++)
            {
                if (grdVoucher.Rows[i].Cells[(int)GColCP.debit].Value != null)
                {
                    bcheck = decimal.TryParse(grdVoucher.Rows[i].Cells[(int)GColCP.debit].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fDebit = fDebit + outValue;
                    }
                }
                if (grdVoucher.Rows[i].Cells[(int)GColCP.credit].Value != null)
                {
                    bcheck = decimal.TryParse(grdVoucher.Rows[i].Cells[(int)GColCP.credit].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fCredit = fCredit + outValue;
                    }
                    //fDebit = fDebit + float.Parse(grdVoucher.Rows[i].Cells[6].Value.ToString());
                    //fCredit = fCredit + float.Parse(grdVoucher.Rows[i].Cells[7].Value.ToString());
                    //grdVoucher.CurrentCell.Value = (i + 1).ToString();                     // Serial Number at first column
                } // if != null
                grdVoucher[2, i].Value = (i + 1).ToString();
            }

            lblTotalDr.Text = String.Format("{0:0,0.00}", fDebit);
            lblTotalCr.Text = String.Format("{0:0,0.00}", fCredit);
        }

         private void msk_AccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUpAc_Mask();
            }

            if (e.KeyCode == Keys.F2)
            {
                // 1- FormID
                // 2- Form Title
                // 3- Table Name
                // 4- Key Field
                // 5- Parent ID Field
                // 6- keyfield String
                string tMainParam = clsGVar.cnstFormPrivileges_GLCOA.ToString() + ",GL COA,gl_ac,ac_id,ac_pid,ac_strid";
                frmGLCOA sGLCOA = new frmGLCOA(tMainParam);
                //frmGLAcID sGLCOA = new frmGLAcID(tMainParam);
                //sGLCOA.MdiParent = sGLCOA;
                sGLCOA.Show();
            }
        }

        private void LookUpAc_Mask()
         {
             //string pSource,
             //int pRow,
             //int pCol

            // MessageBox.Show("Lookup Source: " + pSource);

             // 1- KeyField
             // 2- Field List
             // 3- Table Name
             // 4- Form Title
             // 5- Default Find Field (Int) 0,1,2,3 etc Default = 1 = title field
             // 6- Grid Title List
             // 7- Grid Title Width
             // 8- Grid Title format T = Text, N = Numeric etc
             // 9- Bool One Table = True, More Then One = False
             // 10 Join String Otherwise Empty String.
             // 11 Optional Where
             // 11 Return Control Type TextBox or MaskedTextBox Default mtextBox
             //
             frmLookUp sForm = new frmLookUp(
                 "ac_strid",
                 "a.ac_title, a.ac_st, c.city_title",
                 "gl_ac a INNER JOIN geo_city c ON a.ac_city_id=c.city_id",
                 this.Text,
                 1,
                 "ID,Account Title,LF #, City Title",
                 "10,20,8,12",
                 "T,T,T,T",
                 true,
                 "",
                 "a.istran = 1"
                 );

             //frmLookUp sForm = new frmLookUp(
             //        "ac_strid",
             //        "ac_title,ac_atitle,Ordering",
             //        "gl_ac",
             //        "GL COA",
             //        1,
             //        "ID,Account Title,Account Alternate Title,Ordering",
             //        "10,20,20,20",
             //        "T,T,T,T",
             //        true,
             //        "",
             //        "istran = 1"
             //        );
             mMsk_AccountID.Text = string.Empty;
             sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
             sForm.ShowDialog();
             if (mMsk_AccountID.Text != null)
             {
                 if (mMsk_AccountID.Text != null)
                 {
                     if (mMsk_AccountID.Text.ToString() == "" || mMsk_AccountID.Text.ToString() == string.Empty)
                     {
                         return;
                     }
                     msk_AccountID.Text = mMsk_AccountID.Text.ToString();
                     //grdVoucher[pCol, pRow].Value = tmtext.Text.ToString();
                     //System.Windows.Forms.SendKeys.Send("{TAB}");
                 }
  
                 //if (msk_AccountID.Text.ToString() == "" || msk_AccountID.Text.ToString() == string.Empty)
                 //{
                 //    return;
                 //}
                 //msk_AccountID.Text = sForm.lupassControl.ToString();
                 ////grdVoucher[pCol, pRow].Value = msk_AccountID.Text.ToString();
                 //System.Windows.Forms.SendKeys.Send("{TAB}");
             }
         }

        private void LookUpAc_Grid(
             string pSource,
             int pRow,
             int pCol
             )
        {
            // MessageBox.Show("Lookup Source: " + pSource);

            // 1- KeyField
            // 2- Field List
            // 3- Table Name
            // 4- Form Title
            // 5- Default Find Field (Int) 0,1,2,3 etc Default = 1 = title field
            // 6- Grid Title List
            // 7- Grid Title Width
            // 8- Grid Title format T = Text, N = Numeric etc
            // 9- Bool One Table = True, More Then One = False
            // 10 Join String Otherwise Empty String.
            // 11 Optional Where
            // 11 Return Control Type TextBox or MaskedTextBox Default mtextBox
            //
            frmLookUp sForm = new frmLookUp(
                "ac_strid",
                "a.ac_title, a.ac_st, c.city_title",
                "gl_ac a INNER JOIN geo_city c ON a.ac_city_id=c.city_id",
                this.Text,
                1,
                "ID,Account Title,LF #, City Title",
                "10,20,8,12",
                "T,T,T,T",
                true,
                "",
                "a.istran = 1"
                );
            //frmLookUp sForm = new frmLookUp(
            //        "ac_strid",
            //        "ac_title,ac_atitle,Ordering",
            //        "gl_ac",
            //        "GL COA",
            //        1,
            //        "ID,Account Title,Account Alternate Title,Ordering",
            //        "10,20,20,20",
            //        "T,T,T,T",
            //        true,
            //        "",
            //        "istran = 1"
            //        );
            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (msk_AccountID.Text != null)
            {
                if (msk_AccountID.Text.ToString() == "" || msk_AccountID.Text.ToString() == string.Empty)
                {
                    return;
                }
                grdVoucher[pCol, pRow].Value = msk_AccountID.Text.ToString();
                //System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void PassData(object sender)
        {
            msk_AccountID.Text = ((MaskedTextBox)sender).Text;
        }
        //
        private void PassDataVocID(object sender)
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            lblDocID.Text = ((TextBox)sender).Text; 
            //msk_VocCode.Text = ((MaskedTextBox)sender).Text;
        }

        private void PassDataVocMasterGLID(object sender) 
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            //lblDocID.Text = ((Label)sender).Text;
            msk_VocMasterGLID.Text = ((MaskedTextBox)sender).Text;
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //if (!tabMDtl.Contains(tabError))
        //        //{
        //        //    // Add New Tab
        //        //    tabMDtl.TabPages.Add(tabError);
        //        //    if (dGvError.RowCount > 0)
        //        //    {
        //        //        dGvError.Rows.Clear();
        //        //    }

        //        //}
        //        //
        //        //if (!GridFilled())
        //        //{
        //        //    MessageBox.Show("Grid Empty or not valid. Check Errror Tab.", "Save: " + lblFormTitle.Text.ToString());
        //        //    tabMDtl.SelectedTab = tabError;
        //        //    return;

        //        //}
        //        Cursor.Current = Cursors.WaitCursor;
        //        SaveData();
        //        Cursor.Current = Cursors.Default;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Exception Processing Save: " + ex.Message, "Save: " + this.Text.ToString());
        //    }
        //}

        private bool DocValid(bool pcheckDocID = true)
        {
            bool rtnValue = true;
            //if (mtBookID.Text.ToString().Trim(' ', '-') == "")
            //{
            //    MessageBox.Show("Voucher Type ID / Book ID empty or blank, select one and try again.", "Check Doc: " + lblFormTitle.Text.ToString());
            //    rtnValue = false;
            //}
            if (pcheckDocID)
            {
                if (txtManualDoc.Text.ToString().Trim(' ', '-') == "" || Convert.ToInt64(txtManualDoc.Text.ToString()) == 0)
                {
                    MessageBox.Show("Voucher ID / Doc ID empty or blank, select one and try again.", "Check Doc: " + this.Text.ToString());
                    rtnValue = false;
                }
            }

            return rtnValue;
        }

        private bool GridValid()
        {
            DateTime lNow = DateTime.Now;
            bool rtnValue = true;
            try
            {
                int lLastRow = grdVoucher.Rows.Count - 1;
                // Check the compulsary columns.
                if (grdVoucher.Rows.Count > 0)
                {
                    // Check GL Account ID
                    if (grdVoucher.Rows[lLastRow].Cells[(int)GColCP.acstrid].Value == null) // || 
                    {
                        rtnValue = false;
                    }
                    else
                    {
                        if ((grdVoucher.Rows[lLastRow].Cells[(int)GColCP.acstrid].Value.ToString()).Trim(' ', '-') == "")
                        {
                            rtnValue = false;
                        }
                    }
                    // Check Project/Reference ID
                    //if (grdVoucher.Rows[lLastRow].Cells[(int)GCol.refid].Value == null)
                    //{
                    //    rtnValue = false;
                    //}
                    //else
                    //{
                    //    if ((grdVoucher.Rows[lLastRow].Cells[(int)GCol.refid].Value.ToString()).Trim(' ', '-') == "")
                    //    {
                    //        rtnValue = false;
                    //    }
                    //}
                    // Optional: Check ComboBox 1
                    //if (grdVoucher.Rows[lLastRow].Cells[(int)GCol.CbmCol].Value == null) //|| 
                    //{
                    //    rtnValue = false;
                    //}
                    //else
                    //{
                    //    if ((grdVoucher.Rows[lLastRow].Cells[(int)GCol.refid].Value.ToString()).Trim() == "")
                    //    {
                    //        rtnValue = false;
                    //    }
                    //}
                    //// Optional: Check ComboBox 2
                    //if (grdVoucher.Rows[lLastRow].Cells[(int)GCol.CbmColCountry].Value == null)
                    //{
                    //    rtnValue = false;
                    //}
                    //else
                    //{
                    //    if ((grdVoucher.Rows[lLastRow].Cells[(int)GCol.CbmColCountry].Value.ToString()).Trim() == "")
                    //    {
                    //        rtnValue = false;
                    //    }
                    //}
                }
                textAlert.Text = "New row may not be inserted, Last row blank of empty.  " + lNow.ToString("T");
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Grid Validity: " + ex.Message, this.Text.ToString());
                return false;
            }
        }
        //
        private bool SaveData()
        {
            bool rtnValue = true;
            fTErr = 0;
            //List<string> lManySQL = new List<string>();
            if (fManySQL != null)
            {
                if (fManySQL.Count() > 0)
                {
                    fManySQL.Clear();
                }
            }
            string lSQL = string.Empty;
            DateTime lNow = DateTime.Now;
            try
            {
                //if (mtBookID.Text.ToString().Trim(' ', '-') == "")
                //{
                //    MessageBox.Show("Voucher Type ID / Book ID empty or blank, select one and try again.", "Save: " + lblFormTitle.Text.ToString());
                //    return false;
                //}
                if (txtManualDoc.Text != null)
                {
                    if (txtManualDoc.Text.ToString().Trim(' ', '-') != "")
                    {
                        //if (Convert.ToInt32(txtManualDoc.Text.ToString()) > 0)
                        //{
                        //    // if already exists       
                        //}
                    }
                }
                ErrrMsg = "";
                if (grdVoucher.Rows.Count < 1)
                {
                    fTErr++;
                    //dGvError.Rows.Add(fTErr.ToString(), "Trans.", "", "No Transaction in the grid to save. " + "  " + lNow.ToString());
                    MessageBox.Show("No transaction in grid to Save", "Save: " + this.Text.ToString());
                    return false;
                }
                fLastRow = grdVoucher.Rows.Count - 1;
                if (!FormValidation())
                {
                    textAlert.Text = "Form Validation Error: Not Saved." + "  " + lNow.ToString();
                    MessageBox.Show(ErrrMsg, "Save: " + this.Text.ToString());
                    return false;
                }
                // Grid Validation
                //if (!GridIDValidation("Ac ID", "MT", grdVoucher, dGvError, (int)GCol.acstrid, "gl_ac", "ac_strid", (int)GCol.debit, (int)GCol.credit, "STR"))
                //{
                //    textAlert.Text = "Grid: Validation Ac ID, Error. Check 'Error Tab'  ...." + "  " + lNow.ToString();
                //    //tabMDtl.SelectedTab = tabError;
                //    rtnValue = false;
                //}
                //if (!GridIDValidation("Ref/Prj ID", "MT", grdVoucher, dGvError, (int)GCol.refid, "geo_city", "city_id", (int)GCol.debit, (int)GCol.credit, "NUM"))
                //{
                //    textAlert.Text = "Grid: Validation Ref/Prj ID, Error. Check 'Error Tab'  ...." + "  " + lNow.ToString();
                //    //tabMDtl.SelectedTab = tabError;
                //    rtnValue = false;
                //}
                //if (!rtnValue)
                //{
                //    tabMDtl.SelectedTab = tabError;
                //    return rtnValue;
                //}
                // pending un comment when required
                //if (!GridCboValidation("Ref/Prj ID", "MT", grdVoucher, dGvError, (int)GCol.refid, "gl_ac", "ac_strid", (int)GCol.debit, (int)GCol.credit))
                //{
                //    tStextAlert.Text = "Grid: Validation Ref/Prj ID, Error. Check 'Error Tab'  ...." + lNow.ToString();
                //    tabMDtl.SelectedTab = tabError;
                //    return false;
                //}
                //

                fManySQL = new List<string>();

                // Prepare Master Doc Query List
                fTNOT = GridTNOT(grdVoucher);
                if (!PrepareDocMaster())
                {
                    textAlert.Text = "DocMaster: Modifying Doc/Voucher not available for updation.'  ...." + "  " + lNow.ToString();
                    //tabMDtl.SelectedTab = tabError;
                    return false;
                }
                //
                if (grdVoucher.Rows.Count > 0)
                {
                    // Prepare Detail Doc Query List
                    if (!PrepareDocDetail())
                    {
                        return false;
                    }
                }
                else
                {
                    DateTime now = DateTime.Now;
                    textAlert.Text = "selected Box Empty... " + now.ToString("T");
                    // pending return false;
                }
                // Execute Query
                if (fManySQL.Count > 0)
                {
                    if (!clsDbManager.ExeMany(fManySQL))
                    {
                        MessageBox.Show("Not Saved see log...", this.Text.ToString());
                        return false;
                    }
                    else
                    {
                        //fLastID = mtDocID.Text.ToString();
                        fLastID = txtManualDoc.Text.ToString();
                        if (fDocAlreadyExists)
                        {
                            textAlert.Text = "Existing ID: " + txtManualDoc.Text + " Modified .... " + "  " + lNow.ToString();
                        }
                        else
                        {
                            textAlert.Text = "New ID: " + txtManualDoc.Text + " Inserted .... " + "  " + lNow.ToString();
                        }
                        EDButtons(true);
                        ClearThisForm();
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Data Preparation list empty, Not Saved...", this.Text.ToString());
                    return false;
                } // End Execute Query
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Processing Save: " + ex.Message, "Save Data: " + this.Text.ToString());
                return false;
            }

        } // End Save
        private bool PrepareDocMaster()
        {
            bool rtnValue = true;
            string lSQL = string.Empty;
            fDocAmt = clsDbManager.ConvDecimal(lblTotalDr.Text);

            try
            {
                string lDocDateStr = StrF01.D2Str(msk_VocDate);
                DateTime lDocDate = DateTime.Parse(lDocDateStr);

                if (lblDocID.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    //fDocAmt = decimal.Parse(lblTotalDr.Text.ToString());
                    //fDocID = clsDbManager.GetNextValDocID("gl_tran", "doc_id", NewDocWhere(), "");
                    fDocWhere = " Doc_vt_id = " + fDocTypeID.ToString();
                    fDocWhere += " AND doc_Fiscal_ID = " + fDocFiscal.ToString();
                    fDocID = clsDbManager.GetNextValDocID("gl_tran", "doc_id", fDocWhere, "");
                    //
                    lSQL = "insert into gl_tran (";
                    lSQL += "  doc_vt_id ";                                         // 1-
                    lSQL += ", doc_fiscal_id ";                                     // 2-
                    lSQL += ", doc_ID ";                                            // 3-
                    lSQL += ", doc_StrID ";                                         // 4-
                    lSQL += ", doc_date ";                                          // 5-
                    lSQL += ", GLID ";                                          // 6-
                    lSQL += ", doc_tnot ";                                          // 6-
                    lSQL += ", doc_remarks ";                                       // 7-
                    lSQL += ", doc_amt ";                                           // 8-
                    lSQL += ", doc_status ";                                        // 7-
                    lSQL += ", created_by ";                                        // 8-
                    //lSQL += ", modified_by ";                                     // 9-
                    lSQL += ", created_date ";                                      // 10-
                    //lSQL += ", modified_date  ";                                  // 11-
                    lSQL += " ) values (";
                    //
                    lSQL += fDocTypeID.ToString();                                 // JVR = 267, CRV=268
                    lSQL += ", " + fDocFiscal.ToString();                           // 3-
                    lSQL += ", " + fDocID.ToString() + "";                          // 4-
                    lSQL += ",'" + StrF01.EnEpos(txtManualDoc.Text) + "'";          // 5-
                    lSQL += ",'" + StrF01.D2Str(msk_VocDate) + "'";                 // 6-
                    lSQL += ", " + lblVocCodeName.Tag;                             // 7- 
                    lSQL += ", " + fTNOT;                                           // 7- 
                    lSQL += ",'" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'"; // 8-
                    lSQL += ", " + fDocAmt.ToString();                              // 9-
                    lSQL += ", 1";                              // 13- Doc Status 

                    lSQL += ", " + clsGVar.AppUserID.ToString();                   // 10- Created by
                    //                                                             // 11- Modified by
                    lSQL += ",'" + StrF01.D2Str(DateTime.Now, true) + "'";         // 12- Created Date  
                    //                                                             // 13- Modified Date
                    lSQL += ")";
                 }
                else
                {
                    fDocWhere = " Doc_vt_id = " + fDocTypeID.ToString();
                    fDocWhere += " AND doc_Fiscal_ID = " + fDocFiscal.ToString();
                    fDocWhere += " AND Doc_ID = " + String.Format("{0,0}",lblDocID.Text.ToString());
                    //if (clsDbManager.IDAlreadyExistWw("gl_tran", "doc_id", DocWhere("")))
                    if (clsDbManager.IDAlreadyExistWw("gl_tran", "doc_id", fDocWhere)) 
                    {
                        fDocAlreadyExists = true;
                        lSQL = "delete from gl_trandtl ";
                        lSQL += " where " + fDocWhere;
    
                        fManySQL.Add(lSQL);
                        //
                    }
                    else
                    {
                        //dGvError.Rows.Add("M", "Master Doc", mtDocID.Text.ToString(), "Doc/Voucher " + mtDocID.Text.ToString() + " has been removed.");
                        MessageBox.Show("Doc/Voucher ID " + lblDocID.Text.ToString() + " has been deleted or removed"
                           + "\n\r" + "The Voucher will be saved as new voucher, try again "
                           + "\n\r" + "Or press clear button to discard the voucher/Doc.", this.Text.ToString());
                        lblDocID.Text = "";
                        rtnValue = false;
                        return rtnValue;
                    }
                    fDocID = Convert.ToInt64(lblDocID.Text.ToString());
                    lSQL = "update gl_tran set";
                    //
                    lSQL += "  doc_date = '" + StrF01.D2Str(msk_VocDate) + "'";                       // 9-
                    lSQL += ", doc_strid = '" + txtManualDoc.Text.ToString() + "'";                   // 9-

                    lSQL += ", GLID = " + lblVocCodeName.Tag;                                         // 10-
                    lSQL += ", doc_tnot = " + fTNOT.ToString();                                       // 10-
                    lSQL += ", doc_remarks = '" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'";    // 12-
                    lSQL += ", doc_amt = " + fDocAmt.ToString();                                // 13-
                    lSQL += ", modified_by = " + clsGVar.AppUserID.ToString();                  // 16-
                    lSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";     // 18-
                    lSQL += " where ";
                    lSQL += fDocWhere;
                    //
                }
                fManySQL.Add(lSQL);

                // Top Portion
                lSQL = "insert into gl_trandtl ( ";
                // Middle Pottion
                lSQL += " doc_vt_id ";                                                               // Form 1- 
                lSQL += ", doc_fiscal_id ";                                                                // 4- Doc Fiscal 
                lSQL += ", doc_id ";                                                                    // Form 2- 
                lSQL += ", ac_id ";                                                                     // 3-
                lSQL += ", NARRATION ";                                                                 // 8-
                lSQL += ", DEBIT ";                                                                     // 9-    
                lSQL += ", CREDIT ";                                                                    // 10-
                //
                lSQL += ", SERIAL_ORDER ";                                                              // 1-
                lSQL += ", isChecked ";                                                                // 7-
                //
                // Bottom Portion
                //
                lSQL += ") values (";
                lSQL += " " + fDocTypeID.ToString();                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                lSQL += ", " + fDocFiscal.ToString();                      // 4- Document Fiscal
                lSQL += ", " + fDocID.ToString();                          // 2- Form 1- Voucher_id
                //
                lSQL += ", " + lblVocCodeName.Tag; //grdVoucher.Rows[dGVRow].Cells[(int)GColCP.acid].Value.ToString();            // 2- Serial Order replaced with SNo. 
                //                                                                                       // 5- Ac Title NA
                lSQL += ", '" + "Cash Payment Voucher" + "'";      // 8- Narration 
                lSQL += ", " +  0;           // 9- Debit. 
                lSQL += ", " + float.Parse(lblTotalDr.Text);          // 10- Credit
                lSQL += ", " + 0;          // 11- Combo 1 
                lSQL += ", 0"; //is Checked
                lSQL += ")";

                //
                fManySQL.Add(lSQL);
                
                return rtnValue;
            }
            catch (Exception ex)
            {
                rtnValue = false;
                MessageBox.Show("Save Master Doc: " + ex.Message, this.Text.ToString());
                return false;
            }
        } // End PrepareDocMaster
        //
        private bool PrepareDocDetail()
        {
            bool rtnValue = true;
            string lSQL = "";
            //Int64 lAcID = 0;
            try
            {
                //
                for (int dGVRow = 0; dGVRow < grdVoucher.Rows.Count; dGVRow++)
                {
                    //frmGroupRights.dictGrpForms.Add(Convert.ToInt32(dGVSelectedForms.Rows[dGVRow].Cells[0].Value.ToString()),
                    //    dGVSelectedForms.Rows[dGVRow].Cells[1].Value.ToString());
                    // Prepare Save Data to Db Table
                    //
                    if (grdVoucher.Rows[dGVRow].Cells[(int)GColCP.acstrid].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if ((grdVoucher.Rows[dGVRow].Cells[(int)GColCP.acstrid].Value.ToString()).Trim(' ', '-') == "")
                        {
                            //lBlank = true;
                            if (dGVRow == fLastRow)
                            {
                                continue;
                            }
                        }
                    }
                    // string aaa1 = grdVoucher.Rows[dGVRow].Cells[(int)GCol.acstrid].Value.ToString();
                    // Getting ac_id with DocStrID 
                    //lAcID = coa.GetNumAcID(
                    //    "gl_ac",
                    //    "ac_strid",
                    //    "ac_id",
                    //    grdVoucher.Rows[dGVRow].Cells[(int)GCol.acstrid].Value.ToString(),
                    //    ""
                    //    );
                    // Top Portion
                    lSQL = "insert into gl_trandtl ( ";
                    // Middle Pottion
                    lSQL += " doc_vt_id ";                                                               // Form 1- 
                    lSQL += ", doc_fiscal_id ";                                                                // 4- Doc Fiscal 
                    lSQL += ", doc_id ";                                                                    // Form 2- 
                    lSQL += ", ac_id ";                                                                     // 3-
                    lSQL += ", NARRATION ";                                                                 // 8-
                    lSQL += ", DEBIT ";                                                                     // 9-    
                    lSQL += ", CREDIT ";                                                                    // 10-
                    //
                    lSQL += ", SERIAL_ORDER ";                                                              // 1-
                    lSQL += ", isChecked ";                                                                // 7-
                    //
                    // Bottom Portion
                    //
                    lSQL += ") values (";
                    lSQL += " " + fDocTypeID.ToString();                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                    lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
                    lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
                    //
                    lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColCP.acid].Value.ToString();            // 2- Serial Order replaced with SNo. 
                    //                                                                                       // 5- Ac Title NA
                    lSQL += ", '" + StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColCP.Desc].Value.ToString()) + "'";      // 8- Narration 
                    lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColCP.debit].Value.ToString();           // 9- Debit. 
                    lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColCP.credit].Value.ToString();          // 10- Debit. 
                    lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColCP.snum].Value.ToString();          // 11- Combo 1 
                    lSQL += ", 0"; //is Checked
                    lSQL += ")";

                    //
                    fManySQL.Add(lSQL);
                } // End For loopo
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Detail Doc: " + ex.Message, this.Text.ToString());
                return false;
            }

        }

        private bool FormValidation()
        {
            bool lRtnValue = true;
            DateTime lNow = DateTime.Now;
            decimal lDebit = 0;
            decimal lCredit = 0;
            fDocAmt = 0;
            //
            try
            {
                //string aaa1 = mtDocDate.Text.ToString().Trim(' ', '-');
                //string aaa2 = mtDocDate.Text.ToString().Trim(' ', '-');
                //string aaa3 = mtDocID.Text.ToString().Trim(' ', '-');
                //string aaa4 = textDocRef.Text.ToString().Trim(' ', '-'); 
                //
                //if (mtBookID.Text.ToString().Trim(' ', '-') == "")
                //{
                //    ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Voucher Type ID / Book ID empty or blank");
                //    fTErr++;
                //    dGvError.Rows.Add(fTErr.ToString(), "Voucher Type ID / Book ID empty or blank", "", "Form Validation: " + ErrrMsg + "  " + lNow.ToString());
                //    lRtnValue = false;
                //}
                if (txtManualDoc.Text.ToString().Trim(' ', '-') == "")
                {
                    ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Date empty or blank, select a valid date and try again");
                    fTErr++;
                    //dGvError.Rows.Add(fTErr.ToString(), "Date empty or blank", "", "Form Validation: " + ErrrMsg + "  " + lNow.ToString());
                    lRtnValue = false;
                }

                SumVoc();
                
                lDebit = (lblTotalDr.Text == "" ? 0 : Convert.ToDecimal(lblTotalDr.Text));
                lCredit = (lblTotalCr.Text == "" ? 0 : Convert.ToDecimal(lblTotalCr.Text));

                //lDebit = decimal.Parse((lblTotalDr.Text=="" ? 0: lblTotalDr.Text));
                //lCredit = decimal.Parse(lblTotalDr.Text);

                if (lDebit != lCredit)
                {
                    if (!fSingleEntryAllowed)
                    {
                        // for for conventional books as in old Finac.
                        fTErr++;
                        ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Sum: Debit: " + lDebit.ToString() + " Credit: " + lCredit.ToString() + " Diff: " + (lDebit - lCredit).ToString() + "");
                        //dGvError.Rows.Add(fTErr.ToString(), "Total Debit/Credit", "", ErrrMsg + "  " + lNow.ToString());
                        return false;
                    }
                }
                //fDocAmt = lDebit;
                return lRtnValue;

            }
            catch (Exception ex)
            {
                fTErr++;
                ErrrMsg  = StrF01.BuildErrMsg(ErrrMsg, "Exception: FormValidation -> " + ex.Message.ToString());
                //dGvError.Rows.Add(fTErr.ToString(), "Exception: FormValidation -> ", "", ErrrMsg + "  " + lNow.ToString());
                return false;
            }
            //return lRtnValue;        // to be removed
        }

        private int GridTNOT(DataGridView pdGv)
        {
            int rtnValue = 0;
            try
            {
                //
                for (int dGVRow = 0; dGVRow < pdGv.Rows.Count; dGVRow++)
                {
                    //frmGroupRights.dictGrpForms.Add(Convert.ToInt32(dGVSelectedForms.Rows[dGVRow].Cells[0].Value.ToString()),
                    //    dGVSelectedForms.Rows[dGVRow].Cells[1].Value.ToString());
                    // Prepare Save Data to Db Table
                    //
                    if (pdGv.Rows[dGVRow].Cells[(int)GColCP.acstrid].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((pdGv.Rows[dGVRow].Cells[(int)GColCP.acstrid].Value.ToString()).Trim(' ', '-') == "")
                        {
                            //lBlank = true;
                            if (dGVRow == fLastRow)
                            {
                                break;
                            }
                        }
                    }

                    rtnValue++;
                } // End For loopo
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Grid TNOT: " + ex.Message, this.Text.ToString());
                return rtnValue;
            }
        }

        private bool GridIDValidation(
        string pIDName,
        string pControType,
        DataGridView pdGVMDtl,
        DataGridView pdGvErr,
        int pCol,
        string pTableName,
        string pKeyField,
        int pDrCol,
        int pCrCol,
        string pIDType = "NUM"
        )

    {
            bool rtnValue = true;
            bool lBlank = false;
            // Check acid column.
            //if (pdGvErr.RowCount > 0)
            //{
            //    pdGvErr.Rows.Clear();
            //}
            for (int i = 0; i < pdGVMDtl.RowCount; i++)
            {
                // Check Debit, Credit Both > 0
                bool lDecimalcheck = false;
                decimal outValue = 0;
                decimal lDebit = 0;
                decimal lCredit = 0;
                //
                // Debit Value
                if (pdGVMDtl.Rows[i].Cells[pDrCol].Value != null)
                {
                    lDecimalcheck = decimal.TryParse(pdGVMDtl.Rows[i].Cells[pDrCol].Value.ToString(), out outValue);    // Debit Column
                    if (lDecimalcheck)
                    {
                        lDebit = outValue;
                    }
                }
                // Credit Value
                if (pdGVMDtl.Rows[i].Cells[pCrCol].Value != null)
                {
                    lDecimalcheck = decimal.TryParse(pdGVMDtl.Rows[i].Cells[pCrCol].Value.ToString(), out outValue);    // Credit Column
                    if (lDecimalcheck)
                    {
                        lCredit = outValue;
                    }
                }
                //
                if (lDebit > 0 && lCredit > 0)
                {
                    fTErr++;
                    //dGvError.Rows.Add(fTErr.ToString(), "Debit/Credit", "", "Grid Tran. " + (i + 1).ToString() + ", Both: Debiot: " + lDebit.ToString() + " and Credit: " + lCredit.ToString() + " Contain values, please select only one ...");
                    rtnValue = false;
                }


                //
                if (pdGVMDtl.Rows[i].Cells[pCol].Value == null)
                {
                    if (lDebit > 0 || lCredit > 0)
                    {
                        fTErr++;
                        lBlank = true;
                        //                 SNo               ID type  ID   Error Message
                        //dGvError.Rows.Add(fTErr.ToString(), pIDName, "", "Grid Tran. " + (i + 1).ToString() + ", ID Blank or null");      // as i starts with 0
                        rtnValue = false;
                    }

                    //if (i != (pdGVMDtl.RowCount - 1) )
                    //{
                    //    //                 SNo               ID type  ID   Error Message
                    //    dGvError.Rows.Add("Grid Tran. " + (i + 1).ToString(), pIDName, "", "ID Blank or null");      // as i starts with 0
                    //    rtnValue = false;
                    //}
                    if (pdGVMDtl.RowCount == 1)
                    {
                        fTErr++;
                        //
                        // 1- SNo
                        // 2- ID type  
                        // 3- Account ID
                        // 4- Error Message
                        //
                        //dGvError.Rows.Add(
                        //    fTErr.ToString(),
                        //    pIDName,
                        //    "",
                        //    "Grid Tran. " + (i + 1).ToString() + ", ID Blank or null, Only one Row in the grid"
                        //    );      // as i starts with 0
                        rtnValue = false;
                    }
                }
                else
                {
                    lBlank = false;
                    // Masked Edit
                    if (pControType == "MT")
                    {
                        if ((pdGVMDtl.Rows[i].Cells[pCol].Value.ToString()).Trim(' ', '-') == "")
                        {
                            if (lDebit > 0 || lCredit > 0)
                            {
                                lBlank = true;
                                //if (i != fLastRow)
                                //{
                                //if ((pdGVMDtl.Rows[i].Cells[pCol].Value.ToString()).Trim(' ', '-') == null)
                                //{
                                //    dGvError.Rows.Add("Grid Tran. " + (i + 1).ToString(), pIDName, "", "Masked: ID Blank/null");
                                //}
                                //else
                                //{
                                fTErr++;
                                //dGvError.Rows.Add(fTErr.ToString(), pIDName, " ", "Grid Tran. " + (i + 1).ToString() + ", Masked Text Box: ID Blank");
                                //}
                                rtnValue = false;
                                //} // if not lastrow
                            } // if Debit or Credit
                        } // if null or ""
                    }
                    else if (pControType == "TB")
                    {
                        if ((pdGVMDtl.Rows[i].Cells[pCol].Value.ToString()).Trim() == "") // has been addressed above || pdGVMDtl.Rows[i].Cells[pCol].Value == null)
                        {
                            lBlank = true;
                            if (lDebit > 0 || lCredit > 0)
                            {
                                fTErr++;
                                //dGvError.Rows.Add(fTErr.ToString(), pIDName, "", "Grid Tran. " + (i + 1).ToString() + ", Grid TextBox Column ID Blank");
                                rtnValue = false;
                            }

                            //if (i != fLastRow)
                            //{
                            //    if ((pdGVMDtl.Rows[i].Cells[pCol].Value.ToString()).Trim() == null)
                            //    {
                            //        dGvError.Rows.Add("Grid Tran. " + (i + 1).ToString(), pIDName, "", "ID Blank/null");
                            //    }
                            //    else
                            //    {
                            //        dGvError.Rows.Add("Grid Tran. " + (i + 1).ToString(), pIDName, "", "ID Blank");
                            //    }
                            //    rtnValue = false;
                            //} // if lastrow
                        } // if null or ""
                    }
                    else if (pControType == "CB")
                    {
                        // ComboBox
                        string aaaa = pdGVMDtl.Rows[i].Cells[pCol].Value.ToString().Trim();

                        if ((pdGVMDtl.Rows[i].Cells[pCol].Value.ToString()).Trim() == "")
                        {
                            lBlank = true;
                            if (lDebit > 0 || lCredit > 0)
                            {
                                fTErr++;
                                //dGvError.Rows.Add(fTErr.ToString(), pIDName, "", "Grid Tran. " + (i + 1).ToString() + ", Grid ComboBox Column ID Blank or not selected.");
                                rtnValue = false;
                            }
                        } // if  ""
                    }

                    // Check ID Exists
                    if (!lBlank)
                    {
                        if (pIDType == "NUM")
                        {
                            if (!clsDbManager.IDAlreadyExist(pTableName, pKeyField, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(), ""))
                            {
                                fTErr++;
                                //dGvError.Rows.Add(fTErr.ToString(), pIDName, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(), "Grid Tran. " + (i + 1).ToString() + ", Grid Text Box: ID not found in database");
                                rtnValue = false;
                            }
                        }
                        else if (pIDType == "STR")
                        {
                            if (!clsDbManager.IDAlreadyExistStrAc(pTableName, pKeyField, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(), ""))
                            {
                                fTErr++;
                                //dGvError.Rows.Add(fTErr.ToString(), pIDName, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(), "Grid Tran. " + (i + 1).ToString() + ", Grid Cell: Account ID not found in database");
                                rtnValue = false;
                            }
                        }
                        //else if (pIDType == "OTR")
                        //{
                        //    fTErr++;
                        //    dGvError.Rows.Add(fTErr.ToString(), pIDName, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(), "Grid Tran. " + (i + 1).ToString() + ", Grid Masked Text Box: Account ID Type Missing");
                        //    rtnValue = false;
                        //}
                        else
                        {
                            fTErr++;
                            //dGvError.Rows.Add(fTErr.ToString(), pIDName, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(), "Grid Tran. " + (i + 1).ToString() + ", Grid Masked Text Box: Account ID Type Missing");
                            rtnValue = false;
                        }
                    }
                    //// Check Debit, Credit Both > 0
                    //bool lDecimalcheck = false;
                    //decimal outValue = 0;
                    //decimal lDebit = 0;
                    //decimal lCredit = 0;
                    ////
                    //// Debit Value
                    //if (pdGVMDtl.Rows[i].Cells[pDrCol].Value != null)
                    //{
                    //    lDecimalcheck = decimal.TryParse(pdGVMDtl.Rows[i].Cells[pDrCol].Value.ToString(), out outValue);    // Debit Column
                    //    if (lDecimalcheck)
                    //    {
                    //        lDebit = outValue;
                    //    }
                    //}
                    //// Credit Value
                    //if (pdGVMDtl.Rows[i].Cells[pCrCol].Value != null)
                    //{
                    //    lDecimalcheck = decimal.TryParse(pdGVMDtl.Rows[i].Cells[pCrCol].Value.ToString(), out outValue);    // Credit Column
                    //    if (lDecimalcheck)
                    //    {
                    //        lCredit = outValue;
                    //    }
                    //}
                    ////
                    //if (lDebit > 0 && lCredit > 0)
                    //{
                    //    dGvError.Rows.Add("Tran. " + (i + 1).ToString(), "Debit/Credit", "", "Both: Debiot: " + lDebit.ToString() + " and Credit: " + lCredit.ToString() + " Contain values, please select only one ...");
                    //    rtnValue = false;
                    //}
                }
            }
            return rtnValue;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtManualDoc.Text))
            {
                MessageBox.Show("Manual Voucher Number is Empty! Unable to Save");
                return;
            }
            if (msk_VocMasterGLID.Text.Trim(' ', '_') == "")
            {
                MessageBox.Show("Master GL Code is Empty! Unable to Save");
                return;
            }
            else
            {
                //MessageBox.Show("has data");
                SaveData();
            }
        }

        private void txtManualDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void LookUp_Voc()
        {
                                
            //string pSource,
            //int pRow,
            //int pCol

            // MessageBox.Show("Lookup Source: " + pSource);

            // 1- KeyField
            // 2- Field List
            // 3- Table Name
            // 4- Form Title
            // 5- Default Find Field (Int) 0,1,2,3 etc Default = 1 = title field
            // 6- Grid Title List
            // 7- Grid Title Width
            // 8- Grid Title format T = Text, N = Numeric etc
            // 9- Bool One Table = True, More Then One = False
            // 10 Join String Otherwise Empty String.
            // 11 Optional Where
            // 11 Return Control Type TextBox or MaskedTextBox Default mtextBox
            //
            //select doc_id, doc_strid, doc_date, doc_remarks, doc_amt 
            //from gl_tran
            //where doc_vt_id=1 and doc_fiscal_id=1

            frmLookUp sForm = new frmLookUp(
                    "doc_id",
                    "doc_strid, doc_date, doc_remarks, doc_amt",
                    "gl_Tran",
                    this.Text.ToString(),
                    1,
                    "Doc_ID,Voucher ID,Date,Remarks,Amount",
                    "6,8,8,12,12",
                    " T, T, T, T,N2",
                    true,
                    "",
                    "doc_vt_id = " + fDocTypeID.ToString() + " and doc_fiscal_id = 1 and doc_status = 1",
                    "TextBox"
                    );
            lblDocID.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();
            if (lblDocID.Text != null)
            {
                if (lblDocID.Text != null)
                {
                    if (lblDocID.Text.ToString() == "" || lblDocID.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (lblDocID.Text.ToString().Trim().Length>0)
                    {
                        PopulateRecords();
                        SumVoc();
                    }

                    //lblDocID.Text = txtPassDataVocID.Text.ToString();
                    //grdVoucher[pCol, pRow].Value = tmtext.Text.ToString();
                    //System.Windows.Forms.SendKeys.Send("{TAB}");
                }

                //if (msk_AccountID.Text.ToString() == "" || msk_AccountID.Text.ToString() == string.Empty)
                //{
                //    return;
                //}
                //msk_AccountID.Text = sForm.lupassControl.ToString();
                ////grdVoucher[pCol, pRow].Value = msk_AccountID.Text.ToString();
                //System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        //Populate Recordset 
        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "select t.doc_id, t.doc_strid, t.doc_date, t.doc_remarks, t.doc_amt, ";
            tSQL += " t.GLID, ga.ac_strid, ga.ac_title ";
            tSQL += " from gl_Tran t LEFT OUTER JOIN gl_ac ga ON t.GLID=ga.ac_id ";
            tSQL += " where  t.doc_vt_id=" + fDocTypeID.ToString() + " and t.doc_fiscal_id=1 and t.doc_status=1";
            tSQL += " and t.doc_id=" + lblDocID.Text.ToString() + ";";

            tSQL += " select 1 as Status, d.Serial_No, d.Serial_Order, ";
            tSQL += " d.AC_ID, a.ac_strid, a.ac_title, d.NARRATION, d.DEBIT, d.CREDIT, t.Doc_Remarks";
            tSQL += " from gl_Tran t Left Outer join gl_trandtl d on t.doc_vt_id=d.doc_vt_id";
            tSQL += " and t.doc_fiscal_id=d.doc_fiscal_id ";
            tSQL += " and t.Doc_ID=d.Doc_ID";
            tSQL += " inner join gl_ac a on a.ac_id=d.AC_ID";
            tSQL += " where  t.doc_vt_id=" + fDocTypeID.ToString() + " and t.doc_fiscal_id=1 and t.doc_status=1";
            tSQL += " and t.doc_id=" + lblDocID.Text.ToString();
            tSQL += " and d.Debit>0";
            tSQL += " order by d.SERIAL_No";

            //tSQL = "Select top 1 ac_title, ac_id, ac_strid from gl_ac Where ";
            //tSQL = tSQL + " ac_strid = '" + msk_AccountID.Text + "';";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "gl_tran");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtManualDoc.Text = (ds.Tables[0].Rows[0]["doc_strid"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["doc_strid"].ToString() );
                    msk_VocDate.Text =  (ds.Tables[0].Rows[0]["doc_date"] == DBNull.Value ? DateTime.Now.ToString("T") :  ds.Tables[0].Rows[0]["doc_date"].ToString() ); 
                    txtRemarks.Text = (ds.Tables[0].Rows[0]["doc_remarks"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["doc_remarks"].ToString());
                    msk_VocMasterGLID.Text = (ds.Tables[0].Rows[0]["Ac_StrID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_StrID"].ToString() );
                    lblVocCodeName.Text = (ds.Tables[0].Rows[0]["Ac_Title"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_Title"].ToString() );
                    lblVocCodeName.Tag = (ds.Tables[0].Rows[0]["GLID"]== DBNull.Value ? "0" : ds.Tables[0].Rows[0]["GLID"].ToString() );
                    fEditMod = true;

                    //grdVoucher.DataSource = ds.Tables[1];
                    //grdVoucher.Visible = true;
                    //lblAccountName.Text = dRow.ItemArray.GetValue(0).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();

                    grdVoucher.Rows.Clear();
                    //
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        dRow = ds.Tables[1].Rows[i];
                        // **** Following Two Rows may get data one time *****
                        //         dGvDetail.DataSource = Zdtset.Tables[0];
                        //         dGvDetail.Visible = true;
                        // **** Following Two Rows may get data one time *****

                        grdVoucher.Rows.Add(
                            ( dRow.ItemArray.GetValue((int)GColCP.Status) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColCP.Status).ToString()),                       // 0-
                            ( dRow.ItemArray.GetValue((int)GColCP.tranid) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColCP.tranid).ToString()),                           // 1-
                            (dRow.ItemArray.GetValue((int)GColCP.snum)==DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColCP.snum).ToString() ),                           // 1-
                            (dRow.ItemArray.GetValue((int)GColCP.acid)==DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColCP.acid).ToString() ),                             // 3-
                            (dRow.ItemArray.GetValue((int)GColCP.acstrid)==DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColCP.acstrid).ToString() ),                          // 4-
                            (dRow.ItemArray.GetValue((int)GColCP.actitle)==DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColCP.actitle).ToString() ),                          // 5-
                            (dRow.ItemArray.GetValue((int)GColCP.Desc)==DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColCP.Desc).ToString() ),                            // 6-
                            (dRow.ItemArray.GetValue((int)GColCP.debit)==DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColCP.debit).ToString() ),                            // 9-
                            (dRow.ItemArray.GetValue((int)GColCP.credit)==DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColCP.credit).ToString() )                           // 10-
                            );
                        //dGvDetail.Columns[1].ReadOnly = true;  // working
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                        //btn_EnableDisable(true);
                    }
                    //txtManualDoc.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }

        }

        private void btn_SaveNContinue_Click(object sender, EventArgs e)
        {
            // TODO: Work is pending for Save & Continue
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            // Check if voucher box is empty
            
            //string plstField = "@Loc_ID,@Grp_ID,@Co_ID,@Year_ID,@Doc_Type_ID,@Doc_Fiscal_ID,@FromDate,@ToDate";
            //string plstType = "8,8,8,8,8,8,18,18"; // {   "8, 8, 8, 8, 8, 8" };
            //string plstValue = "1,1,1,1,0,0," + StrF01.D2Str(this.dtpFromDate.Value, false) + "," +
            //StrF01.D2Str(this.dtpToDate.Value, false);

            string plstField = "@Doc_ID,@Doc_VT_ID";
            string plstType = "8,8"; // {   "8 int, 8 DateTime, 18 Text" };
            string plstValue = lblDocID.Text.ToString() + "," + fDocTypeID.ToString();
            fRptTitle = this.Text;

            //DataSet ds = new DataSet();
            dsVoucher ds = new dsVoucher();
            CrJV rpt1 = new CrJV();

            frmPrintViewer rptTrial = new frmPrintViewer(
               fRptTitle,
               msk_VocDate.Text,
               msk_VocDate.Text, 
               "sp_Voucher",
               plstField,
               plstType,
               plstValue,
               ds,
               rpt1,
               "SP"
               );

            rptTrial.Show();

        }

        private void msk_VocMasterGLID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUpVocMasterGLID_Mask();
            }

        }
        private void LookUpVocMasterGLID_Mask()  
        {
            //string pSource,
            //int pRow,
            //int pCol

            // MessageBox.Show("Lookup Source: " + pSource);

            // 1- KeyField
            // 2- Field List
            // 3- Table Name
            // 4- Form Title
            // 5- Default Find Field (Int) 0,1,2,3 etc Default = 1 = title field
            // 6- Grid Title List
            // 7- Grid Title Width
            // 8- Grid Title format T = Text, N = Numeric etc
            // 9- Bool One Table = True, More Then One = False
            // 10 Join String Otherwise Empty String.
            // 11 Optional Where
            // 11 Return Control Type TextBox or MaskedTextBox Default mtextBox
            //
            frmLookUp sForm = new frmLookUp(
                "ac_strid",
                "a.ac_title, a.ac_st, c.city_title",
                "gl_ac a INNER JOIN geo_city c ON a.ac_city_id=c.city_id",
                this.Text,
                1,
                "ID,Account Title,LF #, City Title",
                "10,20,8,12",
                "T,T,T,T",
                true,
                "",
                "a.istran = 1"
                );

            //frmLookUp sForm = new frmLookUp(
            //        "ac_strid",
            //        "ac_title,ac_atitle,Ordering",
            //        "gl_ac",
            //        "GL COA",
            //        1,
            //        "ID,Account Title,Account Alternate Title,Ordering",
            //        "10,20,20,20",
            //        "T,T,T,T",
            //        true,
            //        "",
            //        "istran = 1"
            //        );
            msk_VocMasterGLID.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocMasterGLID);
            sForm.ShowDialog();
            if (msk_VocMasterGLID.Text != null)
            {
                if (msk_VocMasterGLID.Text != null)
                {
                    if (msk_VocMasterGLID.Text.ToString() == "" || msk_VocMasterGLID.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    msk_VocMasterGLID.Text = msk_VocMasterGLID.Text.ToString();
                    //grdVoucher[pCol, pRow].Value = tmtext.Text.ToString();
                    //System.Windows.Forms.SendKeys.Send("{TAB}");
                }

                //if (msk_AccountID.Text.ToString() == "" || msk_AccountID.Text.ToString() == string.Empty)
                //{
                //    return;
                //}
                //msk_AccountID.Text = sForm.lupassControl.ToString();
                ////grdVoucher[pCol, pRow].Value = msk_AccountID.Text.ToString();
                //System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void msk_VocMasterGLID_Leave(object sender, EventArgs e)
        {
            if (msk_VocMasterGLID.Text.ToString().Trim('_', ' ', '-') == "")
            {
                MessageBox.Show("GL Code is Empty! Unable to Process...", this.Text.ToString());
                msk_VocMasterGLID.Focus();
            }

            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  
            tSQL = "Select top 1 ac_title, ac_id, ac_strid from gl_ac Where ";
            tSQL = tSQL + " ac_strid = '" + msk_VocMasterGLID.Text + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "gl_Ac");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblVocCodeName.Text = dRow.ItemArray.GetValue(0).ToString();
                    lblVocCodeName.Tag = dRow.ItemArray.GetValue(1).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();
                }
                else
                {
                    MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                    msk_VocMasterGLID.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                msk_VocMasterGLID.Focus();
            }
        }

        private void msk_VocMasterGLID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtManualDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void msk_AccountID_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void msk_VocMasterGLID_Enter(object sender, EventArgs e)
        {
            clsGVar.SelectOnEnter(msk_VocMasterGLID);
        }

        private void txtManualDoc_Enter(object sender, EventArgs e)
        {
            clsGVar.SelectOnEnter(txtManualDoc);
        }

        private void btn_EnableDisable(bool pEnableDisable) 
        {
            btn_Save.Enabled=pEnableDisable;
            //btn_Clear.Enabled = pEnableDisable;
            btn_Delete.Enabled = pEnableDisable;
            //btn_SaveNContinue.Enabled = pEnableDisable;
            btn_View.Enabled = pEnableDisable;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            // Check if Voucher box is empty
        }

        private void msk_AccountID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void msk_VocMasterGLID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LookUpVocMasterGLID_Mask();
        }

        private void msk_AccountID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LookUpAc_Mask();
        }

        private void msk_VocDate_Leave(object sender, EventArgs e)
        {
            string lRtnValue = clsDbManager.VocCheckAndDisplayList(
                "gl_tran",
                "doc_strid",
                fDocTypeID,
                StrF01.D2Str(msk_VocDate),
                txtManualDoc.Text);

            if (lRtnValue != "Not Found!")
            {
                MessageBox.Show("Voucher(s) : \n" + lRtnValue, this.Text.ToString());
            }
        }

        private void btn_PinID_Click(object sender, EventArgs e)
        {
            if (btn_PinID.Text == "&Pin")
            {
                btn_PinID.Text = "&Un Pin";
                btn_PinID.Image = Properties.Resources.tiny_pinned;
                msk_VocMasterGLID.Enabled = false;
            }
            else
            {
                btn_PinID.Text = "&Pin";
                btn_PinID.Image = Properties.Resources.tiny_pin;
                msk_VocMasterGLID.Enabled = true;
            }
        }

        private void txtManualDoc_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void txtManualDoc_Leave(object sender, EventArgs e)
        {
            //if (txtManualDoc.Text == "")
            //{
            //    MessageBox.Show("Voucher # is Empty! Unable to Process", this.Text.ToString());
            //    txtManualDoc.Focus();
            //}

        }
        private void txtManualDoc_Validating(object sender, CancelEventArgs e)
        {
            if (!fFormClosing)
            {
                if (txtManualDoc.Text == "")
                {
                    MessageBox.Show("Voucher # is Empty! Unable to Process", this.Text.ToString());
                    txtManualDoc.Focus();
                }
            }
        }

        private void lblDocID_Click(object sender, EventArgs e)
        {

        }
    }
}
