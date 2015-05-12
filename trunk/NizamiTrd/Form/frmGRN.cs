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
    enum GColGRN_Old
    {
        ItemID = 0,
        ItemName = 1,
        UOMID = 2,
        GodownID = 3,
        ContractQty = 4,
        PrevGrnQty = 5,
        GrnQty = 6,
        ContRemQty = 7,
        Rate = 8,
        Amount = 9
    }

    public partial class frmGRN : Form 
    {
        DateTime now = DateTime.Now;
        List<string> fManySQL = null;                      // List string for storing Multiple Queries
        //
        string fRptTitle = string.Empty;
        //bool fFormClosing = false;

        bool ftTIsBalloon = true;
        bool fEditMod = false;
        int fEditRow = 0;
        //bool fFrmLoading = true;                    // Form is Loading Controls (to accomodate Load event so that first time loading requirement is done)
        int fTErr = 0;                              // Total Errors while Saving or other operation.
        string ErrrMsg = string.Empty;              // To display error message if any.
        string fLastID = string.Empty;              // Last Voucher/Doc ID (Saved new or modified)
        //
        //int fDocTypeID = 1;                         // Voucher/Doc Type ID
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

        public frmGRN()
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

        private void frmVoc_Load(object sender, EventArgs e)
        {

            this.KeyPreview = true;
            SetMaxLen();
            SetToolTips();
            LoadInitialControls();
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
            this.Close();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ClearThisForm();
        }
        //
        private void ClearThisForm()
        {
            //lblDocID.Text = string.Empty;
            //txtManualDoc.Tag = string.Empty;
            txtManualDoc.Tag = 0;
            txtManualDoc.Text = string.Empty;
            txtManualDoc.Enabled = true;
            txtRemarks.Text = string.Empty;
            //lblTotalCr.Text = string.Empty;
            //lblTotalDr.Text = string.Empty;
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
            string fFirstTableName = string.Empty;
            string fFirstKeyField = string.Empty;
            string lSQL = string.Empty;
            string lSQL_UOM = string.Empty;
            string lSQL_Gd = string.Empty;

            //fFirstTableName = "cmn_Transport";
            //fFirstKeyField = "Transport_ID";

            lSQL = "select * from " + fFirstTableName;
            lSQL += " order by Transport_Title";

            //clsFillCombo.FillCombo(cboTransport, clsGVar.ConString1, fFirstTableName + "," + fFirstKeyField + "," + "False", lSQL);
            //fcboDefaultValue = Convert.ToInt16(cboTransport.SelectedValue);

            //UOM Combo Fill
            lSQL_UOM = "select * from " + "Gds_UOM";
            lSQL_UOM += " order by ordering";

            clsFillCombo.FillCombo(cbo_UOM, clsGVar.ConString1, "Gds_UOM" + "," + "GoodsUOM_ID" + "," + "False", lSQL_UOM);
            //fcboDefaultValue = Convert.ToInt16(cbo_UOM.SelectedValue);

            //Godown Combo Fill
            lSQL_Gd = "select * from " + "cmn_Godown";
            lSQL_Gd += " order by ordering";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "cmn_Godown" + "," + "Godown_ID" + "," + "False", lSQL_Gd);
            //fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);

            // 1 = dGV Grid Control
            // 2 = Column Total (Total number of Columns for cross verification with other parameters like width, format)
            // 3 = Column Header
            // 4 = Column Width to be displayed on Grid
            // 5 = Column MaxInputLen   // 0 = unlimited, 
            // 6 = Column Format        // T = Text, N = Numeric, H = Hiden
            // 7 = Column ReadOnly      // 1 = ReadOnly, 0 = Not ReadOnly
            // 8 = Grid Color Scheme    // Default = 1
            // RO 
            // Grid: dGvOptional Fields
            //lSQl1 = "select ftype_id, ftype_title from " + "cmn_ftype";
            //lSQl1 += " where ";
            //lSQl1 += clsGVar.LGCY;
            //lSQl1 += " order by ordering";
            ////
            //if (CmbTableName.Count > 0)
            //{
            //    CmbTableName.Clear();
            //}

            //CmbTableName.Add("cmn_ftype,ftype_id,False");
            ////
            //if (CmbFillType.Count > 0)
            //{
            //    CmbFillType.Clear();
            //}
            //CmbFillType.Add("Q");
            ////
            //if (CmbQry.Count > 0)
            //{
            //    CmbQry.Clear();
            //}
            //CmbQry.Add(lSQl1);
            ////
            ////
            //if (MtMask.Count > 0)
            //{
            //    MtMask.Clear();
            //}
            //MtMask.Add("");
            //string lColHeading = "";
            //lColHeading += "Status";                       // 1-   
            //lColHeading += ",S#";                          // 2-   
            //lColHeading += ",Display Label";               // 3-
            //lColHeading += ",Type";                        // 4-
            //lColHeading += ",Empty Allowed";               // 5-
            //lColHeading += ",Max. Length";                 // 6-
            //lColHeading += ",Default Val.";                // 7-
            //lColHeading += ",Min. Val.";                   // 8-
            //lColHeading += ",Max. Val.";                   // 9-
            //lColHeading += ",ordering";                    // 10-
            //lColHeading += ",Is Disabled";                 // 11-
            //lColHeading += ",Remarks/Description";         // 12-
            ////                    "01,02,30,40,50,60,70,80,90,10,11,12"
            //string lColDspWidth = " 2, 3,15,12, 8, 8, 7, 7, 7, 7, 7,30";
            //string lColMinWidth = " 0, 0,15,12, 0, 8, 7, 7, 7, 7, 7,30";
            //string lColMaxInput = " 4,15,30, 0, 0, 2, 9, 9, 9, 2, 0,60";
            //string lColCtrlType = " H, T, T,CB,CH,N0,N0,N0,N0,N0,CH, T";
            //string lColReadOnly = " 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0";
            //clsDbM.SetGridHeaderCmb(
            //    dGvOptionalFields,
            //    12,
            //    lColHeading,
            //    lColDspWidth,
            //    lColMinWidth,
            //    lColMaxInput,
            //    lColCtrlType,
            //    lColReadOnly,
            //    "DATA",
            //    MtMask,
            //    CmbFillType,
            //    CmbTableName,
            //    CmbQry,
            //    false,
            //    2);
            //pnlTabOptionalFields.Enabled = false;

            List<string> CmbTableName = new List<string>
            {
                "goodsuom_title,goodsuom_id,False"
            };
            //
            List<string> CmbFillType = new List<string>
            {
                "Q"
            };
            //
            List<string> CmbQry = new List<string>
            {
                lSQL_UOM
            };
            //
            List<string> MtMask = new List<string>
            {
                ""
            };

            if (CmbTableName.Count > 0)
            {
                CmbTableName.Clear();
            }

            CmbTableName.Add("goodsuom_title,goodsuom_id,False");
            //
            if (CmbFillType.Count > 0)
            {
                CmbFillType.Clear();
            }
            CmbFillType.Add("Q");
            //
            if (CmbQry.Count > 0)
            {
                CmbQry.Clear();
            }
            CmbQry.Add(lSQL_UOM);
            //
            //
            if (MtMask.Count > 0)
            {
                MtMask.Clear();
            }
            MtMask.Add("");

            CmbTableName.Add("Godown_title,Godown_id,False");
            CmbFillType.Add("Q");
            CmbQry.Add(lSQL_Gd);
            MtMask.Add("");

            string lHDR = "";
            lHDR += "Item ID";                        // 0-   Hiden
            lHDR += ",Item Name";                     // 1-   Hiden
            lHDR += ",UOM";                           // 2-   
            lHDR += ",Godown";                        // 3-
            lHDR += ",Contract Qty";                  // 4-
            lHDR += ",Prev.Del.Qty";                  // 5-
            lHDR += ",GRN Qty";                       // 6-
            lHDR += ",Rem.Qty";                       // 7-
            lHDR += ",Rate";                          // 8-
            lHDR += ",Amount";                        // 9-

            string lColDspWidth = " 5,15,10,10,10,10,10,10,10,10";
            string lColMinWidth = " 0, 0, 0, 0, 0, 0, 0, 0, 0, 0";
            string lColMaxInput = " 5, 0, 0, 0, 8, 8, 8, 8, 0,20";
            string lColCtrlType = " T, T,CB,CB,N2,N2,N2,N2,N2,N2";
            string lColReadOnly = " 1, 1, 1, 1, 1, 1, 1, 1, 1, 1";

            clsDbManager.SetGridHeaderCmb(
                grdVoucher,
                10,
                lHDR,
                lColDspWidth,
                lColMinWidth,
                lColMaxInput,
                lColCtrlType,
                lColReadOnly,
                "DATA",
                MtMask,
                CmbFillType,
                CmbTableName,
                CmbQry, 
                false,
                2);

        }
        private void frmVoc_KeyDown(object sender, KeyEventArgs e)
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

                    txtItemID.Focus();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (pnlVocTran.Visible == true)
                {
                    pnlVocTran.Visible = false;
                    if (grdVoucher.Rows.Count > 2)
                    {
                        grdVoucher.Focus();
                    }
                    else
                    {
                        msk_VocDate.Focus();
                    }
                }

                //}
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

                        //lblAcID.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColGRN_Old.acid].Value.ToString();
                        //lblVocCodeName.Tag = grdVoucher.Rows[fEditRow].Cells[(int)GColGRN_Old.acid].Value.ToString();
                        //msk_VocMasterGLID.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColGRN_Old.acstrid].Value.ToString();
                        //lblVocCodeName.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColGRN_Old.actitle].Value.ToString();
                        //txtNarration.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColGRN_Old.Desc].Value.ToString();
                        //txtDebit.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColGRN_Old.debit].Value.ToString();
                        //txtCredit.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColGRN_Old.credit].Value.ToString();
                        //btn_Add.Text = "&Update";

                        //pnlVocTran.Visible = true;
                        //msk_VocMasterGLID.Focus();

                    }
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

        private void frmVoc_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            grdVoucher.Rows.Add(1,1,1,1,1);
            //grdVoucher.ReadOnly = false;
        }
        //===============================================333333

        private void SumVoc()
        {
            bool bcheck;
            decimal fQty = 0;
            decimal fAmount = 0;
            decimal rtnVal = 0;
            decimal outValue = 0;

            for (int i = 0; i < grdVoucher.RowCount; i++)
            {
                if (grdVoucher.Rows[i].Cells[(int)GColGRN_Old.Amount].Value != null)
                {
                    bcheck = decimal.TryParse(grdVoucher.Rows[i].Cells[(int)GColGRN_Old.Amount].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fAmount = fAmount + outValue;
                    }
                }
                if (grdVoucher.Rows[i].Cells[(int)GColGRN_Old.GrnQty].Value != null)
                {
                    bcheck = decimal.TryParse(grdVoucher.Rows[i].Cells[(int)GColGRN_Old.GrnQty].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fQty = fQty + outValue;
                    }
                    //fDebit = fDebit + float.Parse(grdVoucher.Rows[i].Cells[6].Value.ToString());
                    //fCredit = fCredit + float.Parse(grdVoucher.Rows[i].Cells[7].Value.ToString());
                    //grdVoucher.CurrentCell.Value = (i + 1).ToString();                     // Serial Number at first column
                } // if != null
                //grdVoucher[2, i].Value = (i + 1).ToString();
            }

            //lblTotalDr.Text = String.Format("{0:0,0.00}", fDebit);
            //lblTotalCr.Text = String.Format("{0:0,0.00}", fCredit);
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
            msk_VocMasterGLID.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
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
            if (msk_VocMasterGLID.Text != null)
            {
                if (msk_VocMasterGLID.Text.ToString() == "" || msk_VocMasterGLID.Text.ToString() == string.Empty)
                {
                    return;
                }
                grdVoucher[pCol, pRow].Value = msk_VocMasterGLID.Text.ToString();
                //System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void PassData(object sender)
        {
            msk_VocMasterGLID.Text = ((MaskedTextBox)sender).Text;
        }
        //
        private void PassDataVocID(object sender)
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            //msk_VocMasterGLID = ((TextBox)sender).Text;
            //lblDocID.Text = ((TextBox)sender).Text;
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
                    if (grdVoucher.Rows[lLastRow].Cells[(int)GColGRN_Old.ItemID].Value == null) // || 
                    {
                        rtnValue = false;
                    }
                    else
                    {
                        if ((grdVoucher.Rows[lLastRow].Cells[(int)GColGRN_Old.ItemName].Value.ToString()).Trim(' ', '-') == "")
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
            fDocAmt = clsDbManager.ConvDecimal(lblTotalAmount.Text);

            try
            {
                string lDocDateStr = StrF01.D2Str(msk_VocDate);
                DateTime lDocDate = DateTime.Parse(lDocDateStr);

                if (txtManualDoc.Tag.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    //fDocAmt = decimal.Parse(lblTotalDr.Text.ToString());
                    //fDocID = clsDbManager.GetNextValDocID("gl_tran", "doc_id", NewDocWhere(), "");
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
                    lSQL += clsGVar.GRN.ToString();                                 // JVR = 267, CRV=268
                    lSQL += ", " + fDocFiscal.ToString();                           // 3-
                    lSQL += ", " + txtManualDoc.Tag.ToString() + "";                          // 4-
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
                    fDocWhere = " Doc_vt_id = " + clsGVar.GRN.ToString();
                    fDocWhere += " AND doc_Fiscal_ID = " + fDocFiscal.ToString();
                    fDocWhere += " AND Doc_ID = " + String.Format("{0,0}", txtManualDoc.Tag.ToString());
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
                        MessageBox.Show("Doc/Voucher ID " + txtManualDoc.Tag.ToString() + " has been deleted or removed"
                           + "\n\r" + "The Voucher will be saved as new voucher, try again "
                           + "\n\r" + "Or press clear button to discard the voucher/Doc.", this.Text.ToString());
                        //lblDocID.Text = "";
                        rtnValue = false;
                        return rtnValue;
                    }
                    fDocID = Convert.ToInt64(txtManualDoc.Tag.ToString());
                    lSQL = "update gl_tran set";
                    //
                    lSQL += "  doc_date = '" + StrF01.D2Str(msk_VocDate) + "'";                       // 9-
                    lSQL += ", doc_strid = '" + txtManualDoc.Text.ToString() + "'";                   // 9-

                    lSQL += ", GLID = " + msk_VocMasterGLID.Tag;                                         // 10-
                    lSQL += ", doc_tnot = " + fTNOT.ToString();                                       // 10-
                    lSQL += ", doc_remarks = '" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'";    // 12-
                    lSQL += ", doc_amt = " + lblTotalAmount.Text.ToString();                                // 13-
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
                lSQL += " " + clsGVar.GRN.ToString();                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                lSQL += ", " + fDocFiscal.ToString();                      // 4- Document Fiscal
                lSQL += ", " + txtManualDoc.Tag.ToString();                          // 2- Form 1- Voucher_id
                //
                lSQL += ", " + lblVocCodeName.Tag; //grdVoucher.Rows[dGVRow].Cells[(int)GColGRN_Old.acid].Value.ToString();            // 2- Serial Order replaced with SNo. 
                //                                                                                       // 5- Ac Title NA
                lSQL += ", '" + "Cash Receipt Voucher" + "'";      // 8- Narration 
                lSQL += ", " + float.Parse(lblTotalAmount.Text);           // 9- Debit. 
                lSQL += ", " + 0;          // 10- Credit
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
                    if (grdVoucher.Rows[dGVRow].Cells[(int)GColGRN_Old.ItemID].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if ((grdVoucher.Rows[dGVRow].Cells[(int)GColGRN_Old.ItemID].Value.ToString()).Trim(' ', '-') == "")
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
                    //lSQL = "insert into gl_trandtl ( ";
                    //// Middle Pottion
                    //lSQL += " doc_vt_id ";                                                               // Form 1- 
                    //lSQL += ", doc_fiscal_id ";                                                                // 4- Doc Fiscal 
                    //lSQL += ", doc_id ";                                                                    // Form 2- 
                    //lSQL += ", ac_id ";                                                                     // 3-
                    //lSQL += ", NARRATION ";                                                                 // 8-
                    //lSQL += ", DEBIT ";                                                                     // 9-    
                    //lSQL += ", CREDIT ";                                                                    // 10-
                    ////
                    //lSQL += ", SERIAL_ORDER ";                                                              // 1-
                    //lSQL += ", isChecked ";                                                                // 7-
                    ////
                    //// Bottom Portion
                    ////
                    //lSQL += ") values (";
                    //lSQL += " " + clsGVar.GRN.ToString();                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                    //lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
                    //lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
                    ////
                    //lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColGRN_Old.acid].Value.ToString();            // 2- Serial Order replaced with SNo. 
                    ////                                                                                       // 5- Ac Title NA
                    //lSQL += ", '" + StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColGRN_Old.Desc].Value.ToString()) + "'";      // 8- Narration 
                    //lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColGRN_Old.debit].Value.ToString();           // 9- Debit. 
                    //lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColGRN_Old.credit].Value.ToString();          // 10- Debit. 
                    //lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColGRN_Old.snum].Value.ToString();          // 11- Combo 1 
                    //lSQL += ", 0"; //is Checked
                    //lSQL += ")";

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

                ////lDebit = (lblTotalDr.Text == "" ? 0 : Convert.ToDecimal(lblTotalDr.Text));
                ////lCredit = (lblTotalCr.Text == "" ? 0 : Convert.ToDecimal(lblTotalCr.Text));

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
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Exception: FormValidation -> " + ex.Message.ToString());
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
                    if (pdGv.Rows[dGVRow].Cells[(int)GColGRN_Old.ItemID].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((pdGv.Rows[dGVRow].Cells[(int)GColGRN_Old.ItemID].Value.ToString()).Trim(' ', '-') == "")
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
                    "Inv_Tran",
                    this.Text.ToString(),
                    1,
                    "Doc_ID,Voucher ID,Date,Remarks,Amount",
                    "6,8,8,12,12",
                    " T, T, T, T,N2",
                    true,
                    "",
                    "doc_vt_id = " + clsGVar.GRN.ToString() + " and doc_fiscal_id = 1 and doc_status = 1",
                    "TextBox"
                    );
            //lblDocID.Text = string.Empty;
            txtManualDoc.Tag = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();
            //if (lblDocID.Text != null)
            if (txtManualDoc.Tag != null)
            {
                //if (lblDocID.Text != null)
                if (txtManualDoc.Tag != null)
                {
                    //if (lblDocID.Text.ToString() == "" || lblDocID.Text.ToString() == string.Empty)
                    if (txtManualDoc.Tag.ToString() == "" || txtManualDoc.Tag.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtManualDoc.Tag.ToString().Trim().Length > 0)
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
            tSQL += " where  t.doc_vt_id=" + clsGVar.GRN.ToString() + " and t.doc_fiscal_id=1 and t.doc_status=1";
            tSQL += " and t.doc_id=" + txtManualDoc.Tag.ToString() + ";";

            tSQL += " select 1 as Status, d.Serial_No, d.Serial_Order, ";
            tSQL += " d.AC_ID, a.ac_strid, a.ac_title, d.NARRATION, d.DEBIT, d.CREDIT, t.Doc_Remarks";
            tSQL += " from gl_Tran t Left Outer join gl_trandtl d on t.doc_vt_id=d.doc_vt_id";
            tSQL += " and t.doc_fiscal_id=d.doc_fiscal_id ";
            tSQL += " and t.Doc_ID=d.Doc_ID";
            tSQL += " inner join gl_ac a on a.ac_id=d.AC_ID";
            tSQL += " where  t.doc_vt_id=" + clsGVar.GRN.ToString() + " and t.doc_fiscal_id=1 and t.doc_status=1";
            tSQL += " and t.doc_id=" + txtManualDoc.Tag.ToString();
            tSQL += " and d.Credit>0";
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
                    txtManualDoc.Text = (ds.Tables[0].Rows[0]["doc_strid"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["doc_strid"].ToString());
                    msk_VocDate.Text = (ds.Tables[0].Rows[0]["doc_date"] == DBNull.Value ? DateTime.Now.ToString("T") : ds.Tables[0].Rows[0]["doc_date"].ToString());
                    txtRemarks.Text = (ds.Tables[0].Rows[0]["doc_remarks"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["doc_remarks"].ToString());
                    msk_VocMasterGLID.Text = (ds.Tables[0].Rows[0]["Ac_StrID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_StrID"].ToString());
                    lblVocCodeName.Text = (ds.Tables[0].Rows[0]["Ac_Title"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_Title"].ToString());
                    lblVocCodeName.Tag = (ds.Tables[0].Rows[0]["GLID"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["GLID"].ToString());
                    fEditMod = true;

                    //grdVoucher.DataSource = ds.Tables[1];
                    //grdVoucher.Visible = true;
                    //lblAccountName.Text = dRow.ItemArray.GetValue(0).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();

                    grdVoucher.Rows.Clear();
                    //
                    //for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    //{
                    //    dRow = ds.Tables[1].Rows[i];
                    //    // **** Following Two Rows may get data one time *****
                    //    //         dGvDetail.DataSource = Zdtset.Tables[0];
                    //    //         dGvDetail.Visible = true;
                    //    // **** Following Two Rows may get data one time *****

                    //    grdVoucher.Rows.Add(
                    //        (dRow.ItemArray.GetValue((int)GColGRN_Old.Status) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGRN_Old.Status).ToString()),                       // 0-
                    //        (dRow.ItemArray.GetValue((int)GColGRN_Old.tranid) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGRN_Old.tranid).ToString()),                           // 1-
                    //        (dRow.ItemArray.GetValue((int)GColGRN_Old.snum) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGRN_Old.snum).ToString()),                           // 1-
                    //        (dRow.ItemArray.GetValue((int)GColGRN_Old.acid) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGRN_Old.acid).ToString()),                             // 3-
                    //        (dRow.ItemArray.GetValue((int)GColGRN_Old.acstrid) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGRN_Old.acstrid).ToString()),                          // 4-
                    //        (dRow.ItemArray.GetValue((int)GColGRN_Old.actitle) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGRN_Old.actitle).ToString()),                          // 5-
                    //        (dRow.ItemArray.GetValue((int)GColGRN_Old.Desc) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGRN_Old.Desc).ToString()),                            // 6-
                    //        (dRow.ItemArray.GetValue((int)GColGRN_Old.debit) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGRN_Old.debit).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColGRN_Old.credit) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGRN_Old.credit).ToString())                           // 10-
                    //        );
                    //    //dGvDetail.Columns[1].ReadOnly = true;  // working
                    //}
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                        //btn_EnableDisable(true);
                    }
                    LoadGridData();
                    //txtManualDoc.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }

        }
                private void LoadGridData() 
        {
          string lSQL = "";
          lSQL = "SELECT ";
          //lSQL += "  'False' as tstatus";                                           // 0a- Status for check box : now not required
          lSQL += "  td.ItemID";                               // 0-
          lSQL += ", i.goodsitem_title";                                         // 1-
          lSQL += ", td.UOMID";                                              // 2-
          lSQL += ", u.goodsuom_title";                                              // 3-
          lSQL += ", td.GodownID";                                            // 4-
          lSQL += ", g.Godown_title";                                            // 5-
          lSQL += ", td.Qty_In";                                               // 6-
          lSQL += ", td.Rate";                                          // 7-
          lSQL += ", td.Bundle";                                         // 8-
          lSQL += ", td.MeshTotal";                                        // 9-
          lSQL += ", isNull(td.Rate,0)*isNull(td.Qty_In,0) as Amount";       // 10-
          
          lSQL += ", td.isBundle";                                            // 11-    
          lSQL += ", td.isMesh";                                               // 12-
          lSQL += ", td.Length";                                     // 13-
          //
          lSQL += ", td.LenDec";           //14
          lSQL += ", td.Width";            //15
          lSQL += ", td.WidDec";           //16
          //lSQL += ", ''";           //16
          //
          lSQL += " FROM inv_tran t INNER JOIN inv_trandtl td  ON t.doc_vt_id=td.doc_vt_id ";
          lSQL += " AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id";
          lSQL += " INNER JOIN gds_item i ON i.goodsitem_id=td.ItemID ";
          lSQL += " INNER JOIN gds_uom u ON td.UOMID=u.goodsuom_id ";
          lSQL += " INNER JOIN cmn_Godown g ON td.GodownID=g.Godown_id ";
          lSQL += " where ";
          lSQL += DocWhere("");
          lSQL += " ORDER BY td.SERIAL_No ";
          //
          string tFieldList = "";                                                 // 0-
          tFieldList  = "  ItemID";                                         // 1-
          tFieldList += ", goodsitem_title";                                         // 1-
          tFieldList += ", UOMID ";                                                 // 2-
          tFieldList += ", goodsuom_title";                                               // 3- as it belong to master gl_ac
          tFieldList += ", GodownID";                                             // 4- as it belong to master gl_ac
          tFieldList += ", goodsuom_title";                                             // 5- as it belong to master gl_ac
          tFieldList += ", Qty_Out";                                               // 6-
          tFieldList += ", Rate";                                           // 7-
          tFieldList += ", Bundle";                                         // 8-
          tFieldList += ", MeshTotal";                                        // 9-
          tFieldList += ", Amount";                                        // 9-
          tFieldList += ", isBundle";                                                // 10-    
          tFieldList += ", isMesh";                                               // 11-
          tFieldList += ", Length";                                     // 12-
          tFieldList += ", LenDec";                                     // 12-
          tFieldList += ", Width";                                     // 12-
          tFieldList += ", WidDec";                                     // 12-
          //tFieldList += ", ''";                                     // 12-
          // 
          string tColFormat = "TB";
          //tColFormat += ",TB";                                                  // 0-  
          //tColFormat += ",SN";                                                    // 1-    
          tColFormat  =  "TB";                                                    // 1-    sn
          tColFormat += ",TB";                                                    // 1-    sn
          tColFormat += ",TB";                                                    // 2-
          tColFormat += ",TB";                                                    // 3-
          tColFormat += ",TB";                                                    // 4-
          tColFormat += ",N2";                                                    // 5-
          tColFormat += ",N2";                                                    // 6-    
          tColFormat += ",N2";                                                    // 7-
          tColFormat += ",N2";                                                    // 8-
          tColFormat += ",N2";                                                    // 9-
          tColFormat += ",N2";                                                    // 10-
          tColFormat += ",CH";                                                    // 11-
          tColFormat += ",CH";                                                    // 12-
          tColFormat += ",N2";                                                    // 13-
          tColFormat += ",N2";                                                    // 14-
          tColFormat += ",N2";                                                    // 15-
          tColFormat += ",N2";                                                    // 16-
          //tColFormat += ",TB";                                                    // 16-

          clsDbManager.FillDataGrid(
          grdVoucher,
          lSQL,
          tFieldList,
          tColFormat);

        }
        private string DocWhere(string pPrefix = "")
        {
          // pPrefix is including dot
          string fDocWhere = string.Empty;
          try
          {
            fDocWhere = " t.doc_vt_id=" + clsGVar.GRN.ToString();
            fDocWhere += " and t.doc_fiscal_id=1 and t.doc_status=1";
            fDocWhere += " and t.doc_id=" + txtManualDoc.Tag.ToString();
            return fDocWhere;
          }
          catch (Exception ex)
          {
            throw;
          }
        }
        private void txtManualDoc_Validating(object sender, CancelEventArgs e)
        {
            // TODO: Form Validation
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
            string plstValue = txtManualDoc.Tag.ToString() + "," + clsGVar.GRN.ToString();
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
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void msk_VocMasterGLID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtManualDoc_TextChanged(object sender, EventArgs e)
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
            btn_Save.Enabled = pEnableDisable;
            //btn_Clear.Enabled = pEnableDisable;
            btn_Delete.Enabled = pEnableDisable;
            //btn_SaveNContinue.Enabled = pEnableDisable;
            btn_View.Enabled = pEnableDisable;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            // Check if Voucher box is empty
        }

        private void txtItemID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cboGodown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtCredit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDebit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNarration_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblItemName_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void grdVoucher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sSMaster_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pnlVocTran_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbo_UOM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTotalAmount_Click(object sender, EventArgs e)
        {
        
        }

        private void lblTotalQty_Click(object sender, EventArgs e)
        {
        
        }

        private void btn_Save_Click_1(object sender, EventArgs e)
        {

        }
    }
}
