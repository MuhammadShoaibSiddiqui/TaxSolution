using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaxSolution.Temp
{
    public partial class frmGRNCrNew : Form
    {
        //******* Grid Variable Setting -- Begin ******
        string fHDR = string.Empty;                       // Column Header
        string fColWidth = string.Empty;                  // Column Width (Input)
        string fColMinWidth = string.Empty;               // Column Minimum Width
        string fColMaxInputLen = string.Empty;            // Column Visible Length/Width 
        string fColFormat = string.Empty;                 // Column Format  
        string fColReadOnly = string.Empty;               // Column ReadOnly 1 = ReadOnly, 0 = Read-Write  
        string fFieldList = string.Empty;

        string fColType = string.Empty;
        string fFieldName = string.Empty;
        //******* Grid Variable Setting -- End ******

        LookUp lookUpForm = new LookUp();

        DateTime now = DateTime.Now;
        List<string> fManySQL = null;                      // List string for storing Multiple Queries
        //
        string fRptTitle = string.Empty;
        bool fFormClosing = false;
        bool ftTIsBalloon = true;
        bool fEditMod = false;
        int fEditRow = 0;
        bool fFrmLoading = true;                    // Form is Loading Controls (to accomodate Load event so that first time loading requirement is done)
        int fTErr = 0;                              // Total Errors while Saving or other operation.
        string ErrrMsg = string.Empty;              // To display error message if any.
        string fLastID = string.Empty;              // Last Voucher/Doc ID (Saved new or modified)
        //
        int fDocTypeID = clsGVar.GRNU;                         // Voucher/Doc Type ID
        int fDocFiscal = 1;                         // Accounting / Fiscal Period    
        //int fTNOA = 0;                              // Total Number of Attachments.    
        int fTNOT = 0;                              // Total Number of Grid Transactions.
        decimal fDocAmt = 0;                        // Document Amount Debit or Credit for DocMaster Field.
        string fDocWhere = string.Empty;            // Where string to build where clause for Voucher level
        int fLastRow = 0;                           // Last row number of the grid.
        Int64 fDocID = 1;
        bool fGridControl = false;                  // To overcome Grid's tabing
        bool fNewID = false;

        bool fSingleEntryAllowed = true;            // for the time being later set to false.
        bool fDocAlreadyExists = false;             // Check if Doc/voucher already exists (Edit Mode = True, New Mode = false)
        bool fIDConfirmed = false;                  // Account ID is valid and existance in Table is confirmed.
        bool fCellEditMode = false;                 // Cell Edit Mode

        // Parameters Form Level
        string fZeroStr = "000000000000000000000000000000";
        string fFormID = string.Empty;
        string fFormTitle = string.Empty;
        string fTableName = string.Empty;
        string fKeyField = string.Empty;
        string fKeyFieldType = string.Empty;
        string fFirstTableName = string.Empty;
        string fFirstKeyField = string.Empty;
        string fSecondTableName = string.Empty;
        string fSecondKeyField = string.Empty;
        string fCbo1ToolTip = string.Empty;
        string fCbo2ToolTip = string.Empty;

        //
        //string ErrrMsg = string.Empty;
        bool fAlreadyExists = false;
        string fTitleWidth = string.Empty;
        string fTitleFormat = string.Empty;
        bool fAddressBtn = false;
        string[] fMain;
        string[] fBeginParam;
        string[] fField;
        string[] fMaxLen;
        string[] fFieldTitle;
        string[] fValR;

        //int pLocID = 0;
        //int pGrpID = 0;
        //int pCoID = 0;
        //int pYearID = 0;
        // Parameter to Class level
        string cMain = string.Empty;
        string cFLBegin = string.Empty;
        string cFL = string.Empty;
        string cFLEnd = string.Empty;
        string cFLenBegin = string.Empty;
        string cFLen = string.Empty;
        string cFLenEnd = string.Empty;
        string cFTBegin = string.Empty;
        string cFT = string.Empty;
        string cFTEnd = string.Empty;
        string cValRBegin = string.Empty;
        string cValR = string.Empty;
        string cValREnd = string.Empty;
        //
        //string cTitleWidth = string.Empty;
        //string cTitleFormat = string.Empty;
        //
        // Combo Box Default Value
        int fcboDefaultValue = 0;
        //
        bool fOneTable = true;
        string fReplaceField = string.Empty;
        string fReplaceWithField = string.Empty;
        string fReplaceTitle = string.Empty;
        string fReplaceWithTitle = string.Empty;
        string fJoin = string.Empty;
        //
        string fLookUpField = string.Empty;
        string fLookUpTitle = string.Empty;
        string fLookUpTitleWidth = string.Empty;
        string isLoading = "Y";


        public frmGRNCrNew()
        {
            InitializeComponent();
        }

        private void txtManualDoc_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void txtManualDoc_KeyDown(object sender, KeyEventArgs e)
        {
            LookUp_Voc();
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
                    "t.doc_id",
                    "t.doc_strid, t.doc_date, ga.ac_title, t.doc_amt",
                    "inv_tran t INNER JOIN gl_ac ga ON t.GLID=ga.ac_id",
                    this.Text.ToString(),
                    1,
                    "Doc ID,Voucher ID,Date,Customer,Amount",
                    "5,6,8,18,10",
                    " T, T, T, T,N2",
                    true,
                    "",
                    "t.doc_vt_id = " + fDocTypeID.ToString() + " and t.doc_fiscal_id = 1 and t.doc_status = 1",
                    "TextBox"
                    );
            //"doc_id",
            //"doc_strid, doc_date, doc_remarks, doc_amt",
            //"Inv_Tran",
            //"GL Transaction",
            //1,
            //"Doc ID,Voucher ID,Date,Remarks,Amount",
            //"10,15,12,30,15",
            //" H, T, T, T,N2",
            //true,
            //"",
            //"doc_vt_id = " + fDocTypeID.ToString() + " and doc_fiscal_id = 1 and doc_status = 1",
            //"TextBox"
            //);
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
                    if (lblDocID.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                        //LoadSampleData();
                       // SumVoc();
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

        private void PassDataVocID(object sender)
        {
            lblDocID.Text = ((TextBox)sender).Text;
        }

        //Populate Recordset 
        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT it.doc_id, it.doc_strid, it.doc_date, it.doc_remarks, it.ContractNo, ";
            tSQL += " it.doc_amt, it.GLID, ga.ac_title, ga.ac_strid, ";
            tSQL += " it.BiltyNo, it.BiltyDate, it.VehicleNo, it.DriverName, it.TransportID, ";
            tSQL += " it.isShowRpt, it.isCalcRpt ";
            tSQL += " from inv_tran it INNER JOIN gl_ac ga ON it.GLID=ga.ac_id ";
            tSQL += " where  it.doc_vt_id=" + fDocTypeID.ToString() + " and it.doc_fiscal_id=1 and it.doc_status=1";
            tSQL += " and it.doc_id=" + lblDocID.Text.ToString() + ";";

            //tSQL += " select td.ItemID, i.goodsitem_title, td.UOMID, u.goodsuom_title, ";
            //tSQL += " td.GodownID, g.Godown_title, td.Qty_Out, td.Rate, td.Bundle,";
            //tSQL += " td.MeshTotal, td.isBundle, td.isMesh, td.Length, td.LenDec, ";
            //tSQL += " td.Width, td.WidDec ";            
            //tSQL += " FROM inv_tran t INNER JOIN inv_trandtl td ";
            //tSQL += " ON t.doc_vt_id=td.doc_vt_id AND t.doc_fiscal_id=td.doc_fiscal_id";
            //tSQL += " AND t.doc_id=td.doc_id ";
            //tSQL += " INNER JOIN gds_item i ON i.goodsitem_id=td.ItemID";
            //tSQL += " INNER JOIN gds_uom u ON td.UOMID=u.goodsuom_id";
            //tSQL += " INNER JOIN cmn_Godown g ON td.GodownID=g.Godown_id";

            //tSQL += " where t.doc_vt_id=" + fDocTypeID.ToString() + " and t.doc_fiscal_id=1 and t.doc_status=1";
            //tSQL += " and t.doc_id=" + lblDocID.Text.ToString();
            //tSQL += " ORDER BY td.SERIAL_No";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Inv_tran");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtManualDoc.Text = (ds.Tables[0].Rows[0]["doc_strid"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["doc_strid"].ToString());
                    msk_VocDate.Text = (ds.Tables[0].Rows[0]["doc_date"] == DBNull.Value ? DateTime.Now.ToString("T") : ds.Tables[0].Rows[0]["doc_date"].ToString());
                    txtRemarks.Text = (ds.Tables[0].Rows[0]["doc_remarks"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["doc_remarks"].ToString());
                    msk_AccountID.Text = (ds.Tables[0].Rows[0]["Ac_StrID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_StrID"].ToString());
                    lblAccountName.Text = (ds.Tables[0].Rows[0]["Ac_Title"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_Title"].ToString());
                    msk_AccountID.Tag = (ds.Tables[0].Rows[0]["GLID"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["GLID"].ToString());
                    txtContract.Text = (ds.Tables[0].Rows[0]["ContractNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ContractNo"].ToString());

                    txtBiltyNo.Text = (ds.Tables[0].Rows[0]["BiltyNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BiltyNo"].ToString());
                    txtBiltyDate.Text = (ds.Tables[0].Rows[0]["BiltyDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BiltyDate"].ToString());
                    txtVehicleNo.Text = (ds.Tables[0].Rows[0]["VehicleNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["VehicleNo"].ToString());
                    txtDriverName.Text = (ds.Tables[0].Rows[0]["DriverName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DriverName"].ToString());
                    // Show in Report
                    if (ds.Tables[0].Rows[0]["isShowRpt"] != DBNull.Value)
                    {
                        chk_ShowRpt.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["isShowRpt"]);
                    }
                    else
                    {
                        chk_ShowRpt.Checked = false;
                    }
                    // Calculate in Report
                    if (ds.Tables[0].Rows[0]["isCalcRpt"] != DBNull.Value)
                    {
                        chk_CalcRpt.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["isCalcRpt"]);
                    }
                    else
                    {
                        chk_CalcRpt.Checked = false;
                    }

                    
                    //fEditMod = true;



                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                       // btn_EnableDisable(true);
                    }
                    LoadGridData();
                    //txtManualDoc.Enabled = false;
                }
            }
            catch
            {
                //MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void frmGRNCrNew_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            string lSQL = string.Empty;

            SettingGridVariable();
            LoadInitialControls();

            this.KeyPreview = true;
        }

        private void SettingGridVariable()
        {
            string lHDR = "";                       // Column Header
            string lColWidth = "";                  // Column Width (Input)
            string lColMinWidth = "";               // Column Minimum Width
            string lColMaxInputLen = "";            // Column Visible Length/Width 
            string lColFormat = "";                 // Column Format  
            string lColReadOnly = "";               // Column ReadOnly 1 = ReadOnly, 0 = Read-Write  
            string lFieldList = "";
            string tColType = "";
            string tFieldName = "";

            //
            lFieldList = "ItemCode";               // Code    
            lFieldList += ",ItemName";         // ItemName
            lFieldList += ",UOMName";         // UnitName
            lFieldList += ",Qty";              // Qty
            lFieldList += ",Rate";             // Rate
            lFieldList += ",Value";            // Value
            lFieldList += ",DiscPercent";      // DiscPercent
            lFieldList += ",DiscAmount";       // DiscAmount
            lFieldList += ",AfterDisc";        // AfterDisc
            lFieldList += ",STRate";           // STRate
            lFieldList += ",STAmount";         // STAmount
            lFieldList += ",FSTRate";          // FSTRate
            lFieldList += ",FSTAmount";        // FSTAmount
            lFieldList += ",NetAmount";        // NetAmount
            lFieldList += ",UOMID";            // UOMID

            lHDR += "Item Code";              // Code    
            lHDR += ",Item Name";            // ItemName
            lHDR += ",UOM";            // UnitName
            lHDR += ",Qty";          // Qty
            lHDR += ",Rate";                 // Rate
            lHDR += ",Value";                // Value
            lHDR += ",Discount %";             // DiscPercent
            lHDR += ",Discount Value";               // DiscAmount
            lHDR += ",After Discount Value";                  // AfterDisc
            lHDR += ",Sales Tax %";               // STRate
            lHDR += ",Sales Tax Amount";              // STAmount
            lHDR += ",FED %";                // FSTRate
            lHDR += ",FED Amount";             // FSTAmount
            lHDR += ",Net Amount";             // NetAmount
            lHDR += ",UOMID";           // UOMID
            
            
            
            // Col Visible Width             
            lColWidth = "   5";                 // Code    
            lColWidth += ",12";                 // ItemName
            lColWidth += ",10";                 // UnitName
            lColWidth += ",7";                 // Qty
            lColWidth += ", 7";                 // Rate
            lColWidth += ", 7";                 // Value
            lColWidth += ", 7";                 // DiscPercent
            lColWidth += ", 7";                 // DiscAmount
            lColWidth += ", 5";                 // AfterDisc
            lColWidth += ", 5";                 // STRate
            lColWidth += ", 5";                 // STAmount
            lColWidth += ", 5";                 // FSTRate
            lColWidth += ", 5";                 // FSTAmount
            lColWidth += ", 5";                 // NetAmount
            lColWidth += ", 5";                 // UOMID
            
            // Column Input Length/Width
            lColMaxInputLen = "  0";                  // Code    
            lColMaxInputLen += ", 0";                 // ItemName
            lColMaxInputLen += ", 0";                 // UnitName
            lColMaxInputLen += ", 0";                 // Qty
            lColMaxInputLen += ", 0";                 // Rate
            lColMaxInputLen += ", 0";                 // Value
            lColMaxInputLen += ", 0";                 // DiscPercent
            lColMaxInputLen += ", 0";                 // DiscAmount
            lColMaxInputLen += ", 0";                 // AfterDisc
            lColMaxInputLen += ", 0";                 // STRate
            lColMaxInputLen += ", 0";                 // STAmount
            lColMaxInputLen += ", 0";                 // FSTRate
            lColMaxInputLen += ", 0";                 // FSTAmount
            lColMaxInputLen += ", 0";                 // NetAmount
            lColMaxInputLen += ", 0";                 // UOMID
            
            
            // Column Min Width
            lColMinWidth = "   0";                       // Code        
            lColMinWidth += ", 0";                       // ItemName    
            lColMinWidth += ", 0";                       // UnitName
            lColMinWidth += ", 0";                       // Qty
            lColMinWidth += ", 0";                       // Rate    
            lColMinWidth += ", 0";                       // Value    
            lColMinWidth += ", 0";                       // DiscPercent
            lColMinWidth += ", 0";                       // DiscAmount
            lColMinWidth += ", 0";                       // AfterDisc
            lColMinWidth += ", 0";                       // STRate  
            lColMinWidth += ", 0";                       // STAmount   
            lColMinWidth += ", 0";                       // FSTRate
            lColMinWidth += ", 0";                       // FSTAmount
            lColMinWidth += ", 0";                       // NetAmount
            lColMinWidth += ", 0";                       // UOMID
            
            
            // Column Format
            lColFormat = "   T";                        // Code         
            lColFormat += ", T";                        // ItemName    
            lColFormat += ", T";                        // UnitName
            lColFormat += ", T";                        // Qty
            lColFormat += ", T";                        // Rate    
            lColFormat += ", T";                        // Value    
            lColFormat += ", T";                        // DiscPercent
            lColFormat += ", T";                        // DiscAmount
            lColFormat += ", T";                        // AfterDisc
            lColFormat += ", T";                        // STRate  
            lColFormat += ", T";                        // STAmount   
            lColFormat += ", T";                        // FSTRate
            lColFormat += ", T";                        // FSTAmount
            lColFormat += " ,T";                        // NetAmount
            lColFormat += ", H";                        // UOMID
            
            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                       // Code       
            lColReadOnly += ",1";                       // ItemName   
            lColReadOnly += ",1";                       // UnitName
            lColReadOnly += ",0";                       // Qty
            lColReadOnly += ",0";                       // Rate   
            lColReadOnly += ",0";                       // Value   
            lColReadOnly += ",0";                       // DiscPercent
            lColReadOnly += ",0";                       // DiscAmount
            lColReadOnly += ",0";                       // AfterDisc
            lColReadOnly += ",0";                       // STRate 
            lColReadOnly += ",0";                       // STAmount  
            lColReadOnly += ",0";                       // FSTRate
            lColReadOnly += ",0";                       // FSTAmount
            lColReadOnly += ",0";                       // NetAmount
            lColReadOnly += ",1";                       // UOMID
            
            // For Saving Time
            tColType += "  N0";              // Code    
            tColType += ",SKP";              // ItemName
            tColType += ",SKP";              // UnitName
            tColType += ", N0";               // Qty
            tColType += ", N2";              // Rate
            tColType += ", N2";              // Value
            tColType += ", N2";              // DiscPercent
            tColType += ", N2";              // DiscAmount
            tColType += ", N2";              // AfterDisc
            tColType += ", N2";              // STRate
            tColType += ", N2";              // STAmount
            tColType += ", N2";              // FSTRate
            tColType += ", N2";              // FSTAmount
            tColType += ", N2";              // NetAmount
            tColType += ", N0";              // UOMID


            tFieldName += "ItemID";                 // Code    
            tFieldName += ",Name";            // ItemName  
            tFieldName += ",UOMName";            // UnitName
            tFieldName += ",Qty";         // Qty
            tFieldName += ",Rate";            // Rate    
            tFieldName += ",Value";           // Value    
            tFieldName += ",DiscPercent";            // DiscPercent
            tFieldName += ",DiscAmount";          // DiscAmount
            tFieldName += ",AfterDisc";                 // AfterDisc
            tFieldName += ",STRate";              // STRate
            tFieldName += ",STAmount";             // STAmount
            tFieldName += ",FSTRate";               // FSTRate
            tFieldName += ",FSTAmount";            // FSTAmount
            tFieldName += ",NetAmount";         // NetAmount
            tFieldName += ",UOMID";             // UOMID
            
            fHDR = lHDR;
            fColWidth = lColWidth;
            fColMaxInputLen = lColMaxInputLen;
            fColMinWidth = lColMinWidth;
            fColFormat = lColFormat;
            fColReadOnly = lColReadOnly;
            fFieldList = lFieldList;

            fColType = tColType;
            fFieldName = tFieldName;

        }
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
            grd.Rows.Clear();
            grd.Columns.Clear();

            List<string> lMask = null; //new List<string>;
            List<string> lCboFillType = null; //new List<string>;
            List<string> lCboTableKeyField = null; //new List<string>;
            List<string> lCboQry = null; //new List<string>;

            clsDbManager.SetGridHeaderCmb(
                grd,
                15,
                fHDR,
                fColWidth,
                fColMaxInputLen,
                fColMinWidth,
                fColFormat,
                fColReadOnly,
                "DATA",
                lMask,
                lCboFillType,
                lCboTableKeyField,
                lCboQry,
                false,
                2);

        }

        private void LoadGridData()
        {
            string lSQL = "";
            lSQL += "  select i.ItemID AS ItemCode, item.goodsitem_title AS ItemName, i.UOMID, ";
            lSQL += " u.goodsuom_title AS UOMName, i.Qty_In AS Qty, i.Rate,  (i.Qty_In * Rate) AS Value, ";
            lSQL += " i.DiscPercent,  ((i.DiscPercent/100)* Rate) AS DiscAmount, ";
            lSQL += " i.DiscAmount AS AfterDisc, i.STRate, ";
            lSQL += " ((i.STRate/100)*DiscAmount) AS STAmount,  i.FSTRate, ";
            lSQL += " ((i.FSTRate/100)*DiscAmount) AS FSTAmount, ";
            lSQL += " (i.DiscAmount + ((i.STRate/100)*DiscAmount) + ((i.FSTRate/100)*DiscAmount)) AS NetAmount ";
            lSQL += " from inv_tran it INNER JOIN inv_trandtl i ON i.doc_id = it.doc_id INNER JOIN gds_uom u ON i.UOMID = u.goodsuom_id ";
            lSQL += " INNER JOIN gds_item item ON i.ItemID = item.goodsitem_id ";
            lSQL += " WHERE it.doc_id = " + lblDocID.Text.ToString();

            clsDbManager.FillDataGrid(
                grd,
                lSQL,
                fFieldList,
                fColFormat);
        }


    }
}
