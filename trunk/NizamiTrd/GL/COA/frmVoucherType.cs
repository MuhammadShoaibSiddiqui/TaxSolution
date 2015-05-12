using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestFormApp.StringFun01;

namespace TestFormApp.GL.COA
{
    public partial class frmVoucherType : Form
    {
        List<string> fManySQL;

        public frmVoucherType()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmVoucherType_Load(object sender, EventArgs e)
        {
            mskVocType.Mask = ">LLL";
            mskVocType.AsciiOnly = true;

            string mStr;
            mStr = "select VouchertypeID,DocId from gl_VoucherResDoc where VoucherTypeID=2;";
            mStr = mStr + " select DescID, Name from alcp_validationdescription where ValidationId=52;";
            mStr = mStr + " select DescID, Name from alcp_validationdescription where ValidationId=26;";

            DataSet dsDataSet = new DataSet();

            dsDataSet = clsDbManager.GetData_Set(mStr, "gl_VoucherResDoc");

            //var col0 = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn grdCbo = new DataGridViewComboBoxColumn();
            grdCbo.Width = 150;
            grdCbo.DataSource = dsDataSet.Tables[0];
            grdCbo.DisplayMember = dsDataSet.Tables[0].Columns[1].ToString().Trim();
            grdCbo.ValueMember = dsDataSet.Tables[0].Columns[0].ToString();

            grdCbo.DropDownWidth = 10;
            grdCbo.DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
            grdCbo.FlatStyle = FlatStyle.Flat;
            grdCbo.HeaderText = "Validation ID";
            //grdRelatedDoc.Columns.Clear();
            grdRelatedDoc.ColumnCount = 0;
            grdRelatedDoc.Columns.Add(grdCbo);
            grdCbo.Dispose();

            // Next col0
            DataGridViewComboBoxColumn cboFieldType = new DataGridViewComboBoxColumn();
            cboFieldType.Width = 300;
            cboFieldType.DataSource = dsDataSet.Tables[1];
            cboFieldType.DisplayMember = dsDataSet.Tables[1].Columns[1].ToString().Trim();
            cboFieldType.ValueMember = dsDataSet.Tables[1].Columns[0].ToString();
            cboFieldType.HeaderText = "Field Type";
            grdFieldDef.ColumnCount = 1;
            grdFieldDef.Columns.Add(cboFieldType);
            //grdFieldDef.Rows.AddRange();
            //grdFieldDef.DisplayedRowCount(true);
            

            // Next cbo Control
            DataGridViewComboBoxColumn cboIncDr = new DataGridViewComboBoxColumn();
            cboIncDr.Width = 150;
            cboIncDr.DataSource = dsDataSet.Tables[2];
            cboIncDr.DisplayMember = dsDataSet.Tables[2].Columns[1].ToString().Trim();
            cboIncDr.ValueMember = dsDataSet.Tables[2].Columns[0].ToString();
            cboIncDr.HeaderText = "Control Code";
            grd_MustIncDr.ColumnCount = 0;
            grd_MustIncDr.Columns.Add(cboIncDr);

            DataGridViewComboBoxColumn cboIncCr = new DataGridViewComboBoxColumn();
            cboIncCr.Width = 150;
            cboIncCr.DataSource = dsDataSet.Tables[2];
            cboIncCr.DisplayMember = dsDataSet.Tables[2].Columns[1].ToString().Trim();
            cboIncCr.ValueMember = dsDataSet.Tables[2].Columns[0].ToString();
            cboIncCr.HeaderText = "Control Code";
            grd_MustIncCr.ColumnCount = 0;
            grd_MustIncCr.Columns.Add(cboIncCr);

            DataGridViewComboBoxColumn cboExcDr = new DataGridViewComboBoxColumn();
            cboExcDr.Width = 150;
            cboExcDr.DataSource = dsDataSet.Tables[2];
            cboExcDr.DisplayMember = dsDataSet.Tables[2].Columns[1].ToString().Trim();
            cboExcDr.ValueMember = dsDataSet.Tables[2].Columns[0].ToString();
            cboExcDr.HeaderText = "Control Code";
            grd_MustExcDr.ColumnCount = 0;
            grd_MustExcDr.Columns.Add(cboExcDr);  

            DataGridViewComboBoxColumn cboExcCr = new DataGridViewComboBoxColumn();
            cboExcCr.Width = 150;
            cboExcCr.DataSource = dsDataSet.Tables[2];
            cboExcCr.DisplayMember = dsDataSet.Tables[2].Columns[1].ToString().Trim();
            cboExcCr.ValueMember = dsDataSet.Tables[2].Columns[0].ToString();
            cboExcCr.HeaderText = "Control Code";
            grd_MustExcCr.ColumnCount = 0;
            grd_MustExcCr.Columns.Add(cboExcCr);  

            //private string[] list; 
 
              //list = new string[dsDataSet.Tables[0].Rows.Count]; 
 
          
            //grdRelatedDoc
            //cbo.DataSource = ds.Tables[0];
            //if (pSetDefault)
            //{
            //    cbo.DisplayMember = ds.Tables[0].Columns[1].ToString();
            //    cbo.ValueMember = ds.Tables[0].Columns[0].ToString();
            //    if (cbo.Items.Count > 0)
            //    {
            //        cbo.Selected = true;
            //    }
            //}

            // **** Following Two Rows may get data one time *****
            //grdRelatedDoc
            //grdDetail.Rows.Clear();
            //grdDetail.Columns.Clear();

            //grdDetail.DataSource = dsDataSet.Tables[0];
            //grdDetail.Visible = true;

            //****************DataGridView Combo Column ***********
    //           public void ComboList1() 
    //{ 
    //    DataGridViewComboBoxColumn combo1 = new DataGridViewComboBoxColumn(); 
    //    combo1.HeaderText = "Country"; 
    //    combo1.Items.Add("Antarctica"); 
    //    combo1.Items.Add("Belgium"); 
    //    combo1.Items.Add("Canada"); 
    //    combo1.Items.Add("Finland"); 
    //    combo1.Items.Add("Albania"); 
    //    combo1.Items.Add("India"); 
    //    combo1.Items.Add("Barbados"); 
    //    dataGridView1.Columns.Add(combo1); 
    //}  
    //public void ComboList2() 
    //{ 
    //    DataGridViewComboBoxColumn combo2 = new DataGridViewComboBoxColumn(); 
    //    combo2.HeaderText = "Types of Jobs"; 
    //    combo2.Items.Add("Accounting"); 
    //    combo2.Items.Add("HR"); 
    //    combo2.Items.Add("Finance"); 
    //    combo2.Items.Add("Transportation"); 
    //    combo2.Items.Add("Testing"); 
    //    dataGridView1.Columns.Add(combo2); 
    //} 
            //****************DataGridView Combo Column ***********

            //if (VoucherTypeID == "")
            //{
            //  MessageBox.Show("Combo Field List Empty. Connect and try again " + DGV1.Name.ToString(), "CB: Grid Header");
            //  return;
            //}
            //if (pCmbQry[fNoCbo] == "")
            //{
            //  MessageBox.Show("Combo Qry List Empty. Connect and try again " + DGV1.Name.ToString(), "CB: Grid Header");
            //  return;
            //}

            //clsFillCombo.FillComboCol(
            //    col0,
            //    fCmbTableKeyfield[fNoCbo],
            //    pCmbQry[fNoCbo]
            //    );
                //if (ds.Tables[0].Columns.Count == 2)
                //{
                //    cbo.DisplayMember = ds.Tables[0].Columns[1].ToString();
                //    cbo.ValueMember = ds.Tables[0].Columns[0].ToString();
                //}
   

            //fNoCbo++;
            //break;
            

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void mskVocType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= (Char)65 && e.KeyChar <= (Char)96)
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (SaveData() == true)
                {
                    MessageBox.Show("Successfully Save ", "Save: " + this.Text.ToString());
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Processing Save: " + ex.Message, "Save: " + this.Text.ToString());
            }
        }

        private bool SaveData()
        {
            //bool rtnValue = true;
            //fTErr = 0;
            List<string> lManySQL = new List<string>();
            string lSQL = string.Empty;
            DateTime lNow = DateTime.Now;
            try
            {
                // pending un comment when required
                //if (!GridCboValidation("Ref/Prj ID", "MT", dGvDetail, dGvError, (int)GCol.refid, "gl_ac", "ac_strid", (int)GCol.debit, (int)GCol.credit))
                //{
                //    tStextAlert.Text = "Grid: Validation Ref/Prj ID, Error. Check 'Error Tab'  ...." + lNow.ToString();
                //    tabMDtl.SelectedTab = tabError;
                //    return false;
                //}

                fManySQL = new List<string>();

                // Prepare Master Doc Query List
                //fTNOT = GridTNOT(dGvDetail);
                if (!PrepareDocMaster())
                {
                    MessageBox.Show("DocMaster: Modifying Doc/Voucher not available for updation.'  ...." + "  " + lNow.ToString()); 
                    //tabMDtl.SelectedTab = tabError;
                    return false;
                }
                //
                //if (grdFieldDef.Rows.Count > 0)
                if (grdSign.Rows.Count > 0)
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
                    MessageBox.Show("selected Box Empty... " + now.ToString("T")); 
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
                        //if (fDocAlreadyExists)
                        //{
                        //    textAlert.Text = "Existing ID: " + fDocID + " Modified .... " + "  " + lNow.ToString();
                        //}
                        //else
                        //{
                        //    textAlert.Text = "New ID: " + fDocID + " Inserted .... " + "  " + lNow.ToString();
                        //}
                        //EDButtons(true);
                        //ClearThisForm();
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
            string mStr = "";
            DataSet dsMax = new DataSet();

            bool rtnValue = true;
            string lSQL = string.Empty;
            try
            {
                //string lDocDateStr = StrF01.D2Str(mtDocDate);
                //DateTime lDocDate = DateTime.Parse(lDocDateStr);
                //(mtDocID.Text.ToString().Trim(' ', '-') == "")

                if (mskVocType.Text !="")
                {
                    //fDocAlreadyExists = false;
                    //fDocID = clsDbManager.GetNextValDocID("gl_tran", "doc_id", NewDocWhere(), "");
                    //
                    mStr ="select MAX(VoucherTypeID)+1 from gl_VoucherPrefMaster where OrgID=1";
                    //dsMax = clsDbManager.f (mStr);

                    lSQL = "INSERT INTO gl_VoucherPrefMaster2 (";
                    lSQL += " VoucherTypeID";
                    lSQL += " ,OrgID";
                    lSQL += " ,VoucherType";
                    lSQL += " ,TypeDesc";
                    lSQL += " ,IsInactive";
                    lSQL += " ,DefaultGLCode)";
                    lSQL += " VALUES (";

                    //
                    lSQL += 1;
                    lSQL += ", " + clsGVar.CoID;
                    lSQL += ", '" + mskVocType.Text.ToString() + "'";
                    lSQL += ", '" + txtVocDesc.Text.ToString() + "'";
                    if (chk_isInactive.Checked==true)
                    {
                        lSQL += ", 1";
                    }
                    else
                    {
                        lSQL += ", 0";
                    }

                    lSQL += ", '" + msk_AccountID.Text + "'";
                    lSQL += ")"; 

                    //***********************
     //               INSERT INTO gl_VoucherPrefMaster
     //      ([VoucherTypeID]
     //      ,[OrgID]
     //      ,[VoucherType]
     //      ,[TypeDesc]
     //      ,[IsInactive]
     //      ,[DefaultGLCode]
     //      ,[AutoFillVoucher]
     //      ,[ShowOpField]
     //      ,[FieldType]
     //      ,[FieldLabel]
     //      ,[CreatedOn]
     //      ,[CreatedBy]
     //      ,[ModifiedOn]
     //      ,[ModifiedBy]
     //      ,[FieldLabel1]
     //      ,[FieldType1]
     //      ,[FieldLabel2]
     //      ,[FieldType2]
     //      ,[FieldLabel3]
     //      ,[FieldType3]
     //      ,[FieldLabel4]
     //      ,[FieldType4]
     //      ,[FieldLabel5]
     //      ,[FieldType5]
     //      ,[FieldLabel6]
     //      ,[FieldType6]
     //      ,[FieldLabel7]
     //      ,[FieldType7]
     //      ,[FieldLabel8]
     //      ,[FieldType8]
     //      ,[FieldLabel9]
     //      ,[FieldType9]
     //      ,[FieldLabel10]
     //      ,[FieldType10]
     //      ,[Dr]
     //      ,[DrInclude]
     //      ,[DrExclude]
     //      ,[Cr]
     //      ,[CrInclude]
     //      ,[CrExclude]
     //      ,[PrintFooterAtBottom]
     //      ,[PrintEnteredBy]
     //      ,[PrintPrintedBy]
     //      ,[PrintEntryDate]
     //      ,[PrintBordersAndLines])
     //VALUES
     //      (<VoucherTypeID, int,>

                    //***********************
                }
                else
                {
                    // Update
                }
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
                for (int dGVRow =0; dGVRow < grdSign.Rows.Count; dGVRow++)
                {
                    //frmGroupRights.dictGrpForms.Add(Convert.ToInt32(dGVSelectedForms.Rows[dGVRow].Cells[0].Value.ToString()),
                    //    dGVSelectedForms.Rows[dGVRow].Cells[1].Value.ToString());
                    // Prepare Save Data to Db Table
                    //

                    // string aaa1 = dGvDetail.Rows[dGVRow].Cells[(int)GCol.acstrid].Value.ToString();
                    //lAcID = coa.GetNumAcID(
                    //    "gl_ac",
                    //    "ac_strid",
                    //    "ac_id",
                    //    grdFieldDef.Rows[dGVRow].Cells[(int)GCol.acstrid].Value.ToString(),
                    //    ""
                    //    );
                    // Top Portion
                    // Insert Key
                    DateTime CurrDate = DateTime.Now;

                    lSQL = "INSERT INTO gl_VoucherPrintPref (";
                    lSQL += "VoucherTypeID";
                    lSQL += ",TopPref";
                    lSQL += ",BottomPref";
                    lSQL += ",CreatedOn";
                    lSQL += ",CreatedBy";
                    lSQL += ",ModifiedOn";
                    lSQL += ",ModifiedBy";
                    lSQL += ",SortOrder)";

                    lSQL += " VALUES (";
                    lSQL += "1";
                    lSQL += ", '" + StrF01.EnEpos(grdSign.Rows[dGVRow].Cells[0].Value.ToString()) + "'";
                    lSQL += ", '" + StrF01.EnEpos(grdSign.Rows[dGVRow].Cells[1].Value.ToString()) + "'";
                    //lSQL += ", '" + StrF01.EnEpos(grdFieldDef.Rows[dGVRow].Cells[(int)2].Value.ToString()) + "'";
                    lSQL += ", '" + CurrDate  + "'";
                    lSQL += ", 1";
                    lSQL += ", '" + CurrDate  + "'";
                    lSQL += ", 1";
                    //lSQL += ", '" + CurrDate  + "'";
                    lSQL += ", " + dGVRow.ToString() + ")";


                    //lSQL += ", '" + StrF01.EnEpos(dGvDetail.Rows[dGVRow].Cells[(int)GCol.doctranRem].Value.ToString()) + "'";      // 8- Narration 
                    //lSQL += ", " + dGvDetail.Rows[dGVRow].Cells[(int)GCol.debit].Value.ToString();           // 9- Debit. 
                    //lSQL += ", " + dGvDetail.Rows[dGVRow].Cells[(int)GCol.credit].Value.ToString();          // 10- Debit. 
                    //lSQL += ", " + dGvDetail.Rows[dGVRow].Cells[(int)GCol.CbmCol].Value.ToString();          // 11- Combo 1 
                    //lSQL += ", " + dGvDetail.Rows[dGVRow].Cells[(int)GCol.CbmColCountry].Value.ToString();   // 12- Combo 2 


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

        private void mskVocType_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }   // End PrepareDocDetail



    }
}
