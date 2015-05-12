using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaxSolution.PrintDataSets;
using TaxSolution.PrintReport;
using TaxSolution.PrintViewer6p;
using TaxSolution.StringFun01;

namespace TaxSolution
{
    public partial class frmAging : Form
    {
        public frmAging()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetAccountName()
        {
            //  MessageBox.Show("Control >>: " + ((Control)sender).GetType().Name.ToString());  for record and ref
            try
            {
                if (msk_AccountID.Text.ToString() == "" || msk_AccountID.Text.ToString() == string.Empty)
                {
                    return;
                }
                else
                {
                    if (msk_AccountID.Text.Length > 0)    // Selected large int so that it may not conflict with int16, int32 etc
                    {
                        string tSQL = string.Empty;

                        //int t1 = 0;
                        //int t2 = 0;

                        // Fields 0,1,2,3 are Begin  
                        tSQL = "Select ac_title, ac_id, ac_strid from gl_ac Where ";
                        tSQL += " ac_strid = '" + msk_AccountID.Text + "';";
                        //+clsGVar.LGCY;

                        tSQL += " SELECT Sum(isNull(td.DEBIT,0)- ISNULL(td.CREDIT,0))";
                        tSQL += " FROM gl_tran t INNER JOIN gl_trandtl td ON t.doc_vt_id=td.doc_vt_id";
                        tSQL += " AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id";
                        tSQL += " WHERE t.doc_fiscal_id=1";
                        tSQL += " AND td.AC_ID in (Select ac_id from gl_ac Where ac_strid = '" + msk_AccountID.Text + "')";
                        tSQL += " AND t.doc_date < '" + StrF01.D2Str(msk_FromDate) + "'";

                        //tSQL = "select top 1 " + fField[4] + " as title," + fField[5] + " as stitle," + fField[6] + ", " + fField[7] + ", " + fField[8];
                        //tSQL += " from " + fTableName;
                        //tSQL += " where ";
                        //tSQL += clsGVar.LGCY;
                        //tSQL += " and ";
                        //tSQL += fKeyField + " = " + mtextID.Text.ToString();
                        //fTableName
                        //========================================================
                        DataSet dtset = new DataSet();
                        DataRow dRow;
                        dtset = clsDbManager.GetData_Set(tSQL, "gl_ac");
                        //int abc = dtset.Tables.Count; // gives the number of tables.
                        int abc = dtset.Tables[0].Rows.Count;

                        if (abc == 0)
                        //if (abc == 0 || abc == null)
                        {
                            //fAlreadyExists = false;
                        }
                        else
                        {
                            //fAlreadyExists = true;
                            dRow = dtset.Tables[0].Rows[0];
                            // Starting title as 0
                            txtAcName.Text = dRow.ItemArray.GetValue(0).ToString();
                            msk_AccountID.Tag = dRow.ItemArray.GetValue(1).ToString();

                            dRow = dtset.Tables[1].Rows[0];
                            lblOpBal.Text = dRow.ItemArray.GetValue(0).ToString();

                            //textTitle.Text = dRow.ItemArray.GetValue(0).ToString(); // dtset.Tables[0].Rows[0][0].ToString();
                            //textST.Text = dRow.ItemArray.GetValue(1).ToString(); // dtset.Tables[0].Rows[0][1].ToString();
                            //mtextOrdering.Text = dRow.ItemArray.GetValue(2).ToString(); // dtset.Tables[0].Rows[0][1].ToString();

                            //t1 = Convert.ToInt16(dRow.ItemArray.GetValue(2));
                            //t2 = Convert.ToInt16(dRow.ItemArray.GetValue(3));

                            //abc = (Convert.ToInt16)dtset.Tables[0].Rows[0][1].ToString();

                            //chkIsDisabled.Checked = t1 == 1 ? true : false;
                            //chkIsDefault.Checked = t2 == 1 ? true : false;

                            //if (dRow.ItemArray.GetValue(3) != DBNull.Value)
                            //{
                            //    chkIsDisabled.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(3).ToString());
                            //}
                            //else
                            //{
                            //    chkIsDisabled.Checked = false;
                            //}
                            //if (dRow.ItemArray.GetValue(4) != DBNull.Value)
                            //{
                            //    chkIsDefault.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(4).ToString());
                            //}
                            //else
                            //{
                            //    chkIsDefault.Checked = false;
                            //}
                        }


                        //
                        //if (fAlreadyExists)
                        //{
                        //    btn_Save.Enabled = true;
                        //    btn_Delete.Enabled = true;
                        //    toolStripStatuslblStatusText.Text = "Modify";
                        //    if (fAddressBtn)
                        //    {
                        //        btn_Address.Enabled = true;
                        //    }
                        //}
                        //else
                        //{
                        //    btn_Save.Enabled = false;
                        //    btn_Delete.Enabled = false;
                        //    toolStripStatuslblStatusText.Text = "New";
                        //}
                        //mtextID.Enabled = false;
                        //}
                        //else
                        //{
                        //    btn_Save.Enabled = false;
                        //    btn_Delete.Enabled = false;
                        //    toolStripStatuslblStatusText.Text = "Err.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Test"); //lblFormTitle.Text.ToString());
            }
        }

        private void frmAging_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            msk_ToDate.Text = now.Date.ToString();
            msk_FromDate.Text = clsGVar.cnstFromDate.ToString();
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
                "a.istran = 0"
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
            msk_AccountID.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (msk_AccountID.Text != null)
            {
                if (msk_AccountID.Text != null)
                {
                    if (msk_AccountID.Text.ToString() == "" || msk_AccountID.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    //msk_AccountID.Text = mMsk_AccountID.Text.ToString();
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
        private void PassData(object sender)
        {
            msk_AccountID.Text = ((MaskedTextBox)sender).Text;
        }


        private void btn_Print_Click(object sender, EventArgs e)
        {

            if (optAging.Checked == true)
            {
                string fRptTitle = "Aging Report";
                string plstField = "@pDoc_Fiscal_ID,@pAc_ID,@pFromDate,@pToDate";
                string plstType = "8,8,18,18"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1," + this.msk_AccountID.Tag + "," + StrF01.D2Str(this.msk_FromDate) + "," +
                    StrF01.D2Str(this.msk_ToDate);

                dsAgingDue ds = new dsAgingDue();
                CrAgingDueRep2 rpt1 = new CrAgingDueRep2();
                //CrMonthlyComp rpt1 = new CrMonthlyComp();

                frmPrintViewer6p rptLedger = new frmPrintViewer6p(
                   fRptTitle,
                   this.msk_FromDate.Text,
                   this.msk_ToDate.Text,
                   this.msk_AccountID.Text,
                   this.txtAcName.Text,
                   string.Empty,
                   string.Empty,
                   "sp_Aging_Due_Rep",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );
                rptLedger.Show();
            }

            if (optAgingGLCode.Checked == true)
            {
                string fRptTitle = "Aging Report";
                string plstField = "@pDoc_Fiscal_ID,@pAc_ID,@pFromDate,@pToDate";
                string plstType = "8,8,18,18"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1," + this.msk_AccountID.Tag + "," + StrF01.D2Str(this.msk_FromDate) + "," +
                    StrF01.D2Str(this.msk_ToDate);

                dsAgingDue ds = new dsAgingDue();
                CrAgingDueRepGL rpt1 = new CrAgingDueRepGL();
                //CrMonthlyComp rpt1 = new CrMonthlyComp();

                frmPrintViewer6p rptLedger = new frmPrintViewer6p(
                   fRptTitle,
                   this.msk_FromDate.Text,
                   this.msk_ToDate.Text,
                   this.msk_AccountID.Text,
                   this.txtAcName.Text,
                   string.Empty,
                   string.Empty,
                   "sp_Aging_Due_Rep",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );
                rptLedger.Show();
            }
        }

        private void msk_AccountID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LookUpAc_Mask();
        }

        private void mCalendarMain_DateChanged(object sender, DateRangeEventArgs e)
        {
            msk_FromDate.Text = mCalendarMain.SelectionStart.ToString();
        }

        private void msk_AccountID_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (msk_AccountID.Text != "#-#-##-##-####")
                {
                    GetAccountName();
                }
            }
            catch (Exception)
            {

                throw;
            }
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
                mCalendarMain.SelectionStart = mCalendarMain.TodayDate;
                msk_FromDate.Text = mCalendarMain.SelectionStart.ToString();
                mCalendarMain.Focus();
            }

        }

        private void btn_ToDate_Click(object sender, EventArgs e)
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
                mCalendarMain.SelectionStart = mCalendarMain.TodayDate;
                msk_ToDate.Text = mCalendarMain.SelectionStart.ToString();
                mCalendarMain.Focus();
            }
        }

        private void btn_HideMonth_Click(object sender, EventArgs e)
        {
            pnlCalander.Visible = false;
        }

    }
}
