using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestFormApp.StringFun01;

using TestFormApp.PrintDataSets;
using TestFormApp.PrintReport;

namespace TestFormApp.TestForm
{
    enum grd_
    { 
        DateCol,
        VocNoCol,
        DescCol,
        DrCol,
        CrCol,
        BalCol,
        RefIDCol
    }
    public partial class frmLedger : Form
    {
        public frmLedger()
        {
            InitializeComponent();
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

        private void mCalendarMain_DateChanged(object sender, DateRangeEventArgs e)
        {
            msk_FromDate.Text = mCalendarMain.SelectionStart.ToString();
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            string mStr;
            mStr = "SELECT m.doc_date as [Dated], m.doc_ref as [Doc.Ref], ";
	        //mStr = mStr + " d.SERIAL_NO, d.SERIAL_ORDER, gl.ac_level, d.AC_ID, gl.ac_strid, gl.ac_title,";
        	mStr = mStr + " d.NARRATION as [Description], d.DEBIT as [Debit], d.CREDIT as [Credit], ";
            mStr = mStr + " 0 as [Balance], d.REF_ID as [Ref.ID]";
            mStr = mStr + " FROM gl_ac gl full outer join gl_trandtl d ON gl.ac_id=d.AC_ID";
	        mStr = mStr + " inner join gl_tran m ON d.loc_id=m.loc_id ";
	        mStr = mStr + " AND d.grp_id=m.grp_id AND d.co_id=m.co_id AND d.year_id=m.year_id";
	        mStr = mStr + " AND d.doc_fiscal_id=m.doc_fiscal_id AND d.doc_ID=m.doc_id ";
            mStr = mStr + " WHERE ";
	        mStr = mStr + " m.doc_date between '" +  StrF01.D2Str(msk_FromDate) 
                + "' AND '" + StrF01.D2Str(msk_ToDate) + "'";
            mStr = mStr + " and gl.ac_strid='" + msk_AccountID.Text + "';";
            mStr = mStr + " Select * from Cheq_DBF where CODE='1-3-02-02-0130' AND Status=518;";
            mStr = mStr + " Select * from Cheq_DBF where CODE='1-3-02-02-0130' and status=520;";

            //1-2-03-01-0002

            DataSet dsDataSet = new DataSet();

            dsDataSet = clsDbManager.GetData_Set(mStr, "gl_Ac");

            // **** Following Two Rows may get data one time *****
            grdDetail.Rows.Clear();
            grdDetail.Columns.Clear();

            grdDetail.DataSource = dsDataSet.Tables[0];
            grdDetail.Visible = true;
            //Post Dateed Cheque Show
            grdPostDtdChq.DataSource = dsDataSet.Tables[1];
            grdPostDtdChq.Visible = true;

            //Post Dateed Dishonoured Cheque Show
            grdDishChq.DataSource = dsDataSet.Tables[2];
            grdDishChq.Visible = true;

            dsDataSet.Dispose();

            //grdDetail.Columns
            //DataGridViewColumn colum =  DataGridView.Columns[(int)grd_.DrCol];
            //this.dataGridView1.Columns["CustomerName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment
            grdDetail.Columns[(int)grd_.DrCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdDetail.Columns[(int)grd_.CrCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdDetail.Columns[(int)grd_.BalCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdDetail.Columns[(int)grd_.DrCol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdDetail.Columns[(int)grd_.CrCol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdDetail.Columns[(int)grd_.BalCol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //grdDetail.Columns[(int)grd_.BalCol].HeaderCell.Style.Font.Bold = true;

            grdDetail.Columns[(int)grd_.DescCol].MinimumWidth = 70;
            grdDetail.Columns[(int)grd_.RefIDCol].MinimumWidth = 5;

            SumLedger();
            
            // **** Following Two Rows may get data one time *****
        }

        private void SumLedger()
        {
            decimal colDebit = 0;
            decimal colCredit = 0;
            //decimal colBalance = 0;

            for (int i = 0; i < grdDetail.Rows.Count-1; i++)
            {
                colDebit += decimal.Parse(grdDetail.Rows[i].Cells[(int)grd_.DrCol].Value.ToString());
                colCredit += decimal.Parse(grdDetail.Rows[i].Cells[(int)grd_.CrCol].Value.ToString());
                grdDetail.Rows[i].Cells[(int)grd_.BalCol].Value = colDebit - colCredit;
                //dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.debit].Value = string.Empty;     // Set Debit value to empty
            }
            lblTotalDebit.Text = colDebit.ToString();
            lblTotalCredit.Text = colCredit.ToString();
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
                    if (msk_AccountID.Text.Length>0)    // Selected large int so that it may not conflict with int16, int32 etc
                    {
                        string tSQL = string.Empty;

                        //int t1 = 0;
                        //int t2 = 0;

                        // Fields 0,1,2,3 are Begin  
                        tSQL = "Select ac_title, ac_id, ac_strid from gl_ac Where " + clsGVar.LGCY;
                        tSQL = tSQL + " AND ac_strid = '" + msk_AccountID.Text + "';";

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


        private void mskValidating(object sender, CancelEventArgs e)
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


        private void msk_AccountID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Print_Click(object sender, EventArgs e)
        {
            string fRptTitle = this.Text;
            string plstField = "@Loc_ID,@Grp_ID,@Co_ID,@Year_ID,@Doc_Type_ID,@Doc_Fiscal_ID,@FromDate,@ToDate,@AcCode";
            string plstType = "8,8,8,8,8,8,18,18,18"; // {   "8, 8, 8, 8, 8, 8" };
            string plstValue = "1,1,1,1,0,0," + StrF01.D2Str(this.msk_FromDate) + "," +
            StrF01.D2Str(this.msk_ToDate) + "," + this.msk_AccountID.Text;

            dsLedgerNew ds = new dsLedgerNew();
            CrLedger rpt1 = new CrLedger();

            frmViewerTrialB rptLedger = new frmViewerTrialB(
               fRptTitle,
               StrF01.D2Str(this.msk_FromDate),
               StrF01.D2Str(this.msk_ToDate),
               "sp_gl_Ledger",
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
}
