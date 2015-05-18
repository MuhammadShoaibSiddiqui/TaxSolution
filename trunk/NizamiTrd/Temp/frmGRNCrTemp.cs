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

using TaxSolution.StringFun01;
using TaxSolution.PrintDataSets;
using TaxSolution.PrintReport;
using TaxSolution.PrintViewer;

//using System.Text.RegularExpressions; // for Multiple Character Split

////"<<SPLITER>>"
//lAcTitle = Regex.Split(lRtnValue, "<<SPLITER>>");

//if (lAcTitle[0] == "ID not Found...")
//{
//  MessageBox.Show("GLID: Account ID not found, try another .....",lblFormTitle.Text.ToString());
//  e.Cancel = true;
//  return;
//}
//lblAcTitle.Text = lAcTitle[0];
//lblAcTitle.Tag = lAcTitle[1];

namespace TaxSolution.Temp
{
    enum GColGrn1
    {
        ItemID = 0,
        ItemName = 1,
        UOMName = 2,
        Qty = 3,
        Rate = 4,
        Value = 5,
        DiscPercent = 6,
        DiscValue = 7,
        AfterDisc = 8,
        STPercent = 9,
        STAmount = 10,
        FEDPercent = 11,
        FEDValue = 12,
        NetAmount = 13,
        UOMID = 14
        //// UnUsed
        //isMesh = 15,
        //Length = 16,
        //Bundle = 17,
        //MeshTotal = 18,
        //Width = 19,
        //isBundle = 20,
        //Amount = 21

         //ItemID = 0,                   //.ItemID].Valu
         //UOMID = 1,                   //.UOMID].Value
         //Qty = 2,         //.Qty].Value.T
         //Rate = 3,                   //.Rate].Value.
         //DiscPercent = 4,          //.DiscPercent]
         //DiscValue = 5,                   //.DiscValue].V
         //STPercent = 6,     //.STPercent].V
         //FEDPercent = 7     //.FEDPercent].

    }
    public partial class frmGRNCr : Form
    {
        //******* Grid Variable Setting -- Begin ******
        string fHDR = string.Empty;                       // Column Header
        string fColWidth = string.Empty;                  // Column Width (Input)
        string fColMinWidth = string.Empty;               // Column Minimum Width
        string fColMaxInputLen = string.Empty;            // Column Visible Length/Width 
        string fColReadOnly = string.Empty;               // Column ReadOnly 1 = ReadOnly, 0 = Read-Write  

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

        string fColFormat = string.Empty;                 // Column Format  
        string fFieldList = string.Empty;

        public frmGRNCr()
        {
            InitializeComponent(); 
            btn_Save.Enabled = false;
            btn_Delete.Enabled = false;

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
                //pnlCalander.BringToFront = true;
                mCalendarMain.SelectionStart = mCalendarMain.TodayDate;
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
            AtFormLoad();
        }

        private void AtFormLoad()
        {
            string lSQL = string.Empty;

            msk_VocDate.Text = now.Date.ToString();

            this.KeyPreview = true;
            SetMaxLen(); 
            SetToolTips();

            SettingGridVariable();
            LoadInitialControls();
            
            //btn_EnableDisable(false);
            sSMaster.Visible = false;
            msk_VocDate.Text = DateTime.Now.ToString();

            ButtonImageSetting();
            fFirstTableName = "cmn_Transport";
            fFirstKeyField = "Transport_ID";

            lSQL = "select * from " + fFirstTableName;
            lSQL += " order by Transport_Title";

            clsFillCombo.FillCombo(cboTransport, clsGVar.ConString1, fFirstTableName + "," + fFirstKeyField + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboTransport.SelectedValue);

            //UOM Combo Fill
            lSQL = "select * from " + "Gds_UOM";
            lSQL += " order by ordering";

            clsFillCombo.FillCombo(cbo_UOM, clsGVar.ConString1, "Gds_UOM" + "," + "GoodsUOM_ID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cbo_UOM.SelectedValue);

            //Godown Combo Fill
            lSQL = "select * from " + "cmn_Godown";
            lSQL += " order by ordering";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "cmn_Godown" + "," + "Godown_ID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);
            
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
            lFieldList = "ItemID";        // ItemID = 0,
            lFieldList += ",Name";        // ItemName = 1,
            lFieldList += ",UOMName";     // UOMID = 2,
            lFieldList += ",Qty";         // UOMName = 3,
            lFieldList += ",Rate";        // Qty = 4,
            lFieldList += ",Value";       // Rate = 5,
            lFieldList += ",DiscPercent"; // Value = 6,
            lFieldList += ",DiscAmount";  // DiscPercent = 7,
            lFieldList += ",AfterDisc";   // DiscValue = 8,
            lFieldList += ",STRate";      // AfterDisc = 9,
            lFieldList += ",STAmount";    // STPercent = 10,
            lFieldList += ",FSTRate";     // STAmount = 11,
            lFieldList += ",FSTAmount";   // FEDPercent = 12,
            lFieldList += ",NetAmount";   // FEDValue = 13,
            lFieldList += ",UOMID";       // NetAmount = 14

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

        private void EDButtons(bool pFlage)
        {
            if (pFlage)
            {
            }
            else
            {
            }
        }

        private void SetMaxLen()
        {
            txtManualDoc.MaxLength = 20;
            txtRemarks.MaxLength = 50;
            msk_AccountID.Mask = "#-#-##-##-####";
            msk_AccountID.HidePromptOnLeave = true;
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
            //btn_PinID.Image = Properties.Resources.tiny_pin;
            //btn_PinParentID.Image = Properties.Resources.tiny_pin;
            //btn_Refresh.Image = Properties.Resources.Refresh;
            //btn_SearchTree.Image = Properties.Resources.x_preview_16x16;
            //btn_Address.Image = Properties.Resources.ico_inbox;
            //btn_OpeningBalance.Image = Properties.Resources.ico_admin;
            //btn_NextID.Image = Properties.Resources.ico_arrow_r;
        }

        private void txtManualDoc_TextChanged(object sender, EventArgs e)
        {
            //string strManualDoc;
            //strManualDoc = e.ToString();
            //txtManualDoc.Text =  strManualDoc.ToUpper();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            CalcMeasure();
        }
        private void CalcMeasure()
        {
            //int fWidth;
            //int fLength;
            //float j;
            //fLength = int.Parse(txtLenDec.Text);
            //float m = 1245.5f;
            //j = m;
            if (chk_Mesh.Checked==true)
            {
                decimal fLength;
                decimal fWidth;
                fLength = clsDbManager.ConvDecimal(txtLenDec.Text);

                fLength = clsDbManager.ConvDecimal(txtLength.Text) + 
                    ((clsDbManager.ConvDecimal(txtLenDec.Text) * clsDbManager.ConvDecimal("0.0833")) ==0 ? 0:
                    (clsDbManager.ConvDecimal(txtLenDec.Text) * clsDbManager.ConvDecimal("0.0833")));
                fWidth = clsDbManager.ConvDecimal(txtWidth.Text) + 
                    ((clsDbManager.ConvDecimal(txtWidDec.Text) * clsDbManager.ConvDecimal("0.0833"))==0 ? 0:
                    (clsDbManager.ConvDecimal(txtWidDec.Text) * clsDbManager.ConvDecimal("0.0833")));
                lblTotalMeasure.Text = ((fLength * fWidth) * (clsDbManager.ConvInt(txtBundle.Text) == 0 ? 1 :
                    clsDbManager.ConvInt(txtBundle.Text))).ToString("0.0000");
                lblAmount.Text = (clsDbManager.ConvDecimal(lblTotalMeasure.Text) * clsDbManager.ConvDecimal(txtRate.Text)).ToString("0.00");

                //lblTotalMeasure.Text =String.Format("{0:0.0000}", ((fLength * fWidth) * (clsDbManager.ConvInt(txtBundle.Text) == 0 ? 1 : 
                //    clsDbManager.ConvInt(txtBundle.Text))).ToString());
                //lblAmount.Text = String.Format("{0:0.00}",(clsDbManager.ConvDecimal(lblTotalMeasure.Text) * clsDbManager.ConvDecimal(txtRate.Text)).ToString());
            }
            else if (chk_BundleCalc.Checked == true)
            {
                lblAmount.Text = (clsDbManager.ConvDecimal(txtBundle.Text) 
                    * clsDbManager.ConvDecimal(txtRate.Text)).ToString("0.00");
                //txtAmount.Text = (float.Parse(String.Format("{0:0.0}", txtBundle.Text)) * float.Parse(String.Format("{0:0.0}", txtRate.Text))).ToString();
                //(float.Parse(txtBundle.Text) * float.Parse(txtRate.Text)).ToString();
            }
            else
            {
                lblAmount.Text = (clsDbManager.ConvDecimal(txtQty.Text) 
                    * clsDbManager.ConvDecimal(txtRate.Text)).ToString("0.00");
                
                    //float.Parse(String.Format("{0:0,0.00}", txtQty.Text)) * float.Parse(String.Format("{0:0,0.00}", txtRate.Text)));
                //(float.Parse(txtQty.Text) * float.Parse(txtRate.Text)).ToString();
            }
            //fLength = float.Parse(txtLength.Text) + (float.Parse(txtLenDec.Text) * int32.Parse(8.33 / 100));

        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            CalcMeasure();
        }

        private void txtLenDec_TextChanged(object sender, EventArgs e)
        {
            CalcMeasure();
        }

        private void txtWidDec_TextChanged(object sender, EventArgs e)
        {
            CalcMeasure();
        }

        private void btnWeight_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Take Weight from Weight Machine Later");
        }

        private void chk_BundleCalc_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_BundleCalc.Checked == true)
            {
                chk_Mesh.Checked = false;
            }
            CalcMeasure();
        }

        private void chk_Mesh_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Mesh.Checked == true)
            {
                chk_BundleCalc.Checked = false;
            }
            CalcMeasure();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            CalcMeasure();
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            CalcMeasure();
        }

        private void txtBundle_TextChanged(object sender, EventArgs e)
        {
            CalcMeasure();
        }

        private void btnTab_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.tabControl1.TabPages["Transaction"];
        }

        private void btn_Exit_Click_2(object sender, EventArgs e)
        {
            fFormClosing = true;
            this.Close();
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
         //    frmLookUp sForm = new frmLookUp(
         //"ac_strid",
         //"ac_title,ac_atitle,Ordering",
         //"gl_ac",
         //"GL COA",
         //1,
         //"ID,Account Title,Account Alternate Title,Ordering",
         //"10,20,20,20",
         //"T,T,T,T",
         //true,
         //"",
         //"istran = 1"
         //);

            //select --, a.Ordering 
//from  
//where  a.istran = 1 and  upper(a.ac_title) like '%' 
//order by a.ac_title


             frmLookUp sForm = new frmLookUp(
                     "ac_strid",
                     "a.ac_title, a.ac_st, c.city_title",
                     "gl_ac a INNER JOIN geo_city c ON a.ac_city_id=c.city_id",
                     "GL COA",
                     1,
                     "ID,Account Title,LF #, City Title",
                     "10,20,8,12",
                     "T,T,T,T",
                     true,
                     "",
                     "a.istran = 1"
                     );
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
             }
         }

        private void PassData(object sender)
        {
            msk_AccountID.Text = ((MaskedTextBox)sender).Text;
        }
        //
        private void PassDataVocID(object sender)
        {
            lblDocID.Text = ((TextBox)sender).Text;
        }

        private void PassDataVocMasterGLID(object sender)
        {
            msk_AccountID.Text = ((MaskedTextBox)sender).Text;
        }

        private void msk_AccountID_Leave(object sender, EventArgs e)
        {
            if (msk_AccountID.Text.ToString().Trim('_', ' ', '-') == "")
            {
                //MessageBox.Show("GL Code is Empty! Unable to Process...", this.Text.ToString());
                //msk_AccountID.Focus();
            }

            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  
            tSQL = "Select top 1 ac_title, ac_id, ac_strid from gl_ac Where ";
            tSQL += " ac_strid = '" + msk_AccountID.Text + "';";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "gl_Ac");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblAccountName.Text = dRow.ItemArray.GetValue(0).ToString();
                    msk_AccountID.Tag=dRow.ItemArray.GetValue(1).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();
                }
                else
                {
                    //MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                    //msk_AccountID.Focus();
                }
            }
            catch
            {
                //MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                //msk_AccountID.Focus();
            }
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Item();
            }
        }
        public void LookUp_Item()
        {
            // Prepare a a list of fields. 

            string fStartName = "goodsitem";    // " + fStartName + " 
            string fTableCbo1 = "gds_UOM"; // " + fStartCbo1 + "
            string fTableCbo2 = "gds_Group";     // " + fStartCbo2 + "
            // new fields defined due to baming mkt_, geo_, gds_ etc
            string fStartCbo1 = "goodsuom"; // " + fStartCbo1 + "
            string fStartCbo2 = "Group";     // " + fStartCbo2 + "

            string fCbo1KeyField = "goodsuom_id"; // value of ID obtained from Cbo1, stored in goodsitem table
            string fCbo2KeyField = "Group_id";  // value of ID obtained from Cbo2, stored in goodsitem table   

            //tMainParam = "1007,Item ID," + "gds_item," + fStartName + "_id,int16,0";
            //tMainParam += "," + fTableCbo1 + "," + fStartCbo1 + "_id," + fTableCbo2 + "," + fStartCbo2 + "_id,Goods UOM Default Name,Item Group Name";
            //
            //tBeginParam = clsGVar.LocID.ToString();
            //tBeginParam += "," + clsGVar.GrpID.ToString();
            //tBeginParam += "," + clsGVar.CoID.ToString();
            //tBeginParam += "," + clsGVar.YrID.ToString();
            //
            // "INNER JOIN country p ON c.province_pid = p.country_id"
            //tFLBegin = "loc_id,grp_id,co_id,year_id";   //"group_id,company_id,year_id"; 
            //tFL = fStartName + "_title," + fStartName + "_st,ordering,goodsitem_packing_id,goodsitem_defuom_id,isdisabled";
            //tFL = fStartName + "_title," + fStartName + "_st,ordering," + fCbo1KeyField + "," + fCbo2KeyField + ",isdisabled";
            //tFLEnd = "isdefault,frm_id";
            ////
            //tFLenBegin = "0,0,0";
            //tFLen = "4,30,8,4";
            //tFLenEnd = "0,0";
            ////
            ////tFTBegin = "Group ID,Company ID,Year ID";
            //fFT = "ID,Item Title,Short Title,Ordering,UOM ID,Goup ID,Disabled";
            //fFTEnd = "Default";
            ////
            //fValBegin = "0,0,0,0";
            //fVal = "R,R,R,R,R";
            //fValEnd = "0";
            //
            fTitleWidth = "10,20,10,20,15,15,10";
            fTitleFormat = "N,T,T,T,T,T,T";

            fJoin = "LEFT OUTER JOIN " + fTableCbo1 + " u ON  kt." + fCbo1KeyField + " = u." + fStartCbo1 + "_id ";
            fJoin += "LEFT OUTER JOIN " + fTableCbo2 + " g ON  kt." + fCbo2KeyField + " = g." + fStartCbo2 + "_id";

            //tLookUpField = "kt.goodsitem_title, kt.goodsitem_st, kt.ordering, p.goodspacking_title, u.uom_title, kt.isdisabled";
            fLookUpField = "kt." + fStartName + "_title, kt." + fStartName + "_st, kt.ordering, u." + fStartCbo1 + "_title, g." + fStartCbo2 + "_title, kt.isdisabled";
            fLookUpTitle = "ID,Item Title,Short Title,Ordering,UOM Title,Group Title,Disabled";
            fLookUpTitleWidth = "10,20,10,6,15,15,8";

            string tKeyField = "kt." + "GoodsItem_ID";
            fTableName = " gds_item ";
            //string tKeyField = "kt." + fKeyField;
            //frmLookUp sForm = new frmLookUp(tKeyField, fLookUpField, fTableName, fFormTitle, 1, fLookUpTitle, fLookUpTitleWidth, fTitleFormat, false, fJoin);

            frmLookUp sForm = new frmLookUp(tKeyField, 
                fLookUpField, 
                fTableName, 
                fFormTitle, 
                1, 
                fLookUpTitle, 
                fLookUpTitleWidth, 
                fTitleFormat, 
                false, 
                fJoin);

            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataItem);
            sForm.ShowDialog();
            if (txtItemID.Text != null)
            {
                if (txtItemID.Text.ToString() == "" || txtItemID.Text.ToString() == string.Empty)
                {
                    return;
                }
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        // ----Event/Delegate--------------------------------
        private void PassDataItem(object sender)
        {
            txtItemID.Text = ((MaskedTextBox)sender).Text.ToString();
        }

        private void txtItemID_Leave(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;
            int int_UOMID = 0;

            // Fields 0,1,2,3 are Begin  

            //tSQL = "Select top 1 goodsitem_title, goodsitem_id, goodsitem_st, Group_id, goodsuom_id ";
            //tSQL += " from gds_item Where ";
            //tSQL = tSQL + " goodsitem_id = '" + txtItemID.Text.ToString() + "';";

            //tSQL = "Select top 1 i.goodsitem_title, i.goodsitem_id, i.goodsitem_st, ";
            //tSQL += " i.Group_id, gg.Group_title, gg.Group_st, ";
            //tSQL += " i.goodsuom_id, u.goodsuom_title, u.goodsuom_st";
            //tSQL += " from gds_item i INNER JOIN gds_Group gg ON i.Group_id=gg.Group_id";
            //tSQL += " INNER JOIN gds_uom u ON i.goodsuom_id=u.goodsuom_id";
            //tSQL += " Where i.goodsitem_id = '" + txtItemID.Text.ToString() + "'";

            //try
            //{
            //    ds = clsDbManager.GetData_Set(tSQL, "gds_item");
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        //fAlreadyExists = true;
            //        dRow = ds.Tables[0].Rows[0];
            //        // Starting title as 0
            //        //lblItemName.Text = dRow.ItemArray.GetValue(0).ToString();

            //        lblItemName.Text = dRow.ItemArray.GetValue(5).ToString() + dRow.ItemArray.GetValue(2).ToString();
            //        txtItemID.Tag = dRow.ItemArray.GetValue(1).ToString();
            //        int_UOMID = Convert.ToInt16(dRow.ItemArray.GetValue(6).ToString());
            //        cbo_UOM.SelectedIndex = ClassSetCombo.Set_ComboBox(cbo_UOM, int_UOMID);
            //        //tFirstID = Convert.ToInt16(dRow.ItemArray.GetValue(3).ToString());
            //        //cboFirstID.SelectedIndex = ClassSetCombo.Set_ComboBox(cboFirstID, tFirstID);

            //    }
            //}

            tSQL = "Select top 1 i.goodsitem_title, i.goodsitem_id, i.goodsitem_st, ";
            tSQL += " i.Group_id, gg.Group_title, gg.Group_st, ";
            tSQL += " i.goodsuom_id, u.goodsuom_title, u.goodsuom_st";
            tSQL += " from gds_item i INNER JOIN gds_Group gg ON i.Group_id=gg.Group_id";
            tSQL += " INNER JOIN gds_uom u ON i.goodsuom_id=u.goodsuom_id";
            tSQL += " Where i.goodsitem_id = '" + txtItemID.Text.ToString() + "';";
            tSQL += " SELECT isNull(SUM(ISNULL(Qty_In,0)) - Sum(ISNULL(Qty_Out,0)),0) AS ShopBalance ";
            tSQL += " FROM inv_trandtl WHERE doc_fiscal_id=1 AND ItemID='" + txtItemID.Text.ToString() + "'";
            tSQL += " AND GodownID=1;";
            tSQL += " SELECT isNull(SUM(ISNULL(Qty_In,0)) - Sum(ISNULL(Qty_Out,0)),0) AS GodownBalance ";
            tSQL += " FROM inv_trandtl WHERE doc_fiscal_id=1 AND ItemID='" + txtItemID.Text.ToString() + "'";
            //tSQL += " AND GodownID=" + cboGodown.SelectedValue.ToString();

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "gds_item");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    //lblItemName.Text = dRow.ItemArray.GetValue(0).ToString();

                    lblItemName.Text = dRow.ItemArray.GetValue(5).ToString() + dRow.ItemArray.GetValue(2).ToString();
                    txtItemID.Tag = dRow.ItemArray.GetValue(1).ToString();
                    int_UOMID = Convert.ToInt16(dRow.ItemArray.GetValue(6).ToString());
                    cbo_UOM.SelectedIndex = clsSetCombo.Set_ComboBox(cbo_UOM, int_UOMID);
                    //tFirstID = Convert.ToInt16(dRow.ItemArray.GetValue(3).ToString());
                    //cboFirstID.SelectedIndex = ClassSetCombo.Set_ComboBox(cboFirstID, tFirstID);
                    dRow = ds.Tables[1].Rows[0];
                    lblBalItem.Text = dRow.ItemArray.GetValue(0).ToString();

                    dRow = ds.Tables[2].Rows[0];
                    lblGodownBal.Text = dRow.ItemArray.GetValue(0).ToString();
                }
            }
            catch
            {
               // MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (btn_Add.Text.ToString() == "&Add")
            {
                if (!ValidationAdd_Btn())
                {
                    return;
                }
                grd.Rows.Add(txtItemID.Text.ToString(),
                    lblItemName.Text, 
                    cbo_UOM.Text,
                    txtQty.Text.ToString(),
                    txtRate.Text.ToString(),
                    Convert.ToInt16(txtRate.Text) * Convert.ToInt16(txtQty.Text),
                    txtDiscountPercentage.Text.ToString(),
                    txtDiscountValue.Text.ToString(),
                    (Convert.ToInt16(txtRate.Text) * Convert.ToInt16(txtQty.Text)) - (Convert.ToInt16(txtQty.Text) * Convert.ToInt16(txtDiscountValue.Text.ToString())),
                    txtSalesTaxPercentage.Text.ToString(),
                    ((Convert.ToInt16(txtRate.Text) * Convert.ToInt16(txtQty.Text)) - (Convert.ToInt16(txtQty.Text) * Convert.ToInt16(txtDiscountValue.Text.ToString()))) * (Convert.ToInt16(txtSalesTaxPercentage.Text.ToString()) / 100), 
                    txtFEDPercentage.Text.ToString(),
                    ((Convert.ToInt16(txtRate.Text) * Convert.ToInt16(txtQty.Text)) - (Convert.ToInt16(txtQty.Text) * Convert.ToInt16(txtDiscountValue.Text.ToString()))) * (Convert.ToInt16(txtFEDPercentage.Text.ToString()) / 100),
                    ((Convert.ToInt16(txtRate.Text) * Convert.ToInt16(txtQty.Text)) - (Convert.ToInt16(txtQty.Text) * Convert.ToInt16(txtDiscountValue.Text.ToString()))) + (((Convert.ToInt16(txtRate.Text) * Convert.ToInt16(txtQty.Text)) - (Convert.ToInt16(txtQty.Text) * Convert.ToInt16(txtDiscountValue.Text.ToString()))) * (Convert.ToInt16(txtSalesTaxPercentage.Text.ToString()) / 100)) + (((Convert.ToInt16(txtRate.Text) * Convert.ToInt16(txtQty.Text)) - (Convert.ToInt16(txtQty.Text) * Convert.ToInt16(txtDiscountValue.Text.ToString()))) * (Convert.ToInt16(txtFEDPercentage.Text.ToString()) / 100)),
                    cbo_UOM.SelectedValue.ToString()
                    );
                //lblAcID.Text,
                //ClearSub_Add_Btn();
            }
            else if (btn_Add.Text.ToString() == "&Update")
            {
                grd.Rows[fEditRow].Cells[(int)GColCsInv.ItemID].Value=txtItemID.Text;
                grd.Rows[fEditRow].Cells[(int)GColCsInv.ItemName].Value=lblItemName.Text;
                grd.Rows[fEditRow].Cells[(int)GColCsInv.UOMID].Value = cbo_UOM.SelectedValue.ToString();
                grd.Rows[fEditRow].Cells[(int)GColCsInv.UOMName].Value = cbo_UOM.Text;
                grd.Rows[fEditRow].Cells[(int)GColCsInv.GodownID].Value = cboGodown.SelectedValue.ToString();
                grd.Rows[fEditRow].Cells[(int)GColCsInv.GodownName].Value = cboGodown.Text;
                
                grd.Rows[fEditRow].Cells[(int)GColCsInv.Qty].Value=txtQty.Text.ToString();
                grd.Rows[fEditRow].Cells[(int)GColCsInv.Rate].Value=txtRate.Text.ToString();
                grd.Rows[fEditRow].Cells[(int)GColCsInv.Bundle].Value=txtBundle.Text.ToString();
                grd.Rows[fEditRow].Cells[(int)GColCsInv.MeshTotal].Value=lblTotalMeasure.Text.ToString();
                grd.Rows[fEditRow].Cells[(int)GColCsInv.Amount].Value=lblAmount.Text.ToString();

                grd.Rows[fEditRow].Cells[(int)GColCsInv.Length].Value=txtLength.Text.ToString();
                grd.Rows[fEditRow].Cells[(int)GColCsInv.LenDec].Value=txtLenDec.Text.ToString();
                grd.Rows[fEditRow].Cells[(int)GColCsInv.Width].Value=txtWidth.Text.ToString();
                grd.Rows[fEditRow].Cells[(int)GColCsInv.WidDec].Value=txtWidDec.Text.ToString();
                grd.Rows[fEditRow].Cells[(int)GColCsInv.isBundle].Value = (chk_BundleCalc.Checked == true ? 1 : 0);
                grd.Rows[fEditRow].Cells[(int)GColCsInv.isMesh].Value = (chk_Mesh.Checked == true ? 1 : 0);

                btn_Add.Text = "&Add";
                this.tabControl1.SelectedTab = this.tabControl1.TabPages["Transaction"];
                
            }
            ClearSub_Add_Btn();

            btn_EnableDisable(true);
            grd.Visible = false;
            SumVoc();
            grd.Visible = true;
            grd.Focus();

        }
        private void SumVoc()
        {
            bool bcheck;
            decimal fTotalQty = 0;
            decimal fTotalAmount = 0;
            decimal rtnVal = 0;
            decimal outValue = 0;
            //decimal outRate =0;
            string str_IsBundle = string.Empty;
            string str_IsMesh = string.Empty;

            for (int i = 0; i < grd.RowCount; i++)
            {
                // isBundle Check
            //    if (grdVoucher.Rows[i].Cells[(int)GColGrn.isBundle].Value == null)
            //    {
            //        str_IsBundle = clsDbManager.ConvBit("False");
            //    }
            //    else
            //    {
            //        str_IsBundle = clsDbManager.ConvBit(grdVoucher.Rows[i].Cells[(int)GColGrn.isBundle].Value.ToString());
            //    }

            //    // isMesh Check
            //    if (grdVoucher.Rows[i].Cells[(int)GColGrn.isMesh].Value == null)
            //    {
            //        str_IsMesh = clsDbManager.ConvBit("False");
            //    }
            //    else
            //    {
            //        str_IsMesh = clsDbManager.ConvBit(grdVoucher.Rows[i].Cells[(int)GColGrn.isMesh].Value.ToString());
            //    }

            //    if (str_IsBundle == "1")
            //    {
            //        grdVoucher.Rows[i].Cells[(int)GColGrn.Amount].Value =
            //            clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.Rate].Value.ToString())
            //            * clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.Bundle].Value.ToString());
            //    }

            //    if (str_IsMesh == "1")
            //    {
            //        grdVoucher.Rows[i].Cells[(int)GColGrn.Amount].Value =
            //            clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.Rate].Value.ToString())
            //            * clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.Bundle].Value.ToString())
            //            * (clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.Width].Value.ToString())
            //             + ((clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.WidDec].Value.ToString())) * clsDbManager.ConvDecimal("0.0833")))
            //            * (clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.Length].Value.ToString())
            //             + ((clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.LenDec].Value.ToString())) * clsDbManager.ConvDecimal("0.0833")))
            //            ;

                    
            //        //float fLength;
            //        //float fWidth;
            //        //fLength = float.Parse(txtLenDec.Text);

            //        //fLength = float.Parse(txtLength.Text) + ((float.Parse(txtLenDec.Text) * 0.0833f));
            //        //fWidth = float.Parse(txtWidth.Text) + ((float.Parse(txtWidDec.Text) * 0.0833f));
            //        //lblTotalMeasure.Text = ((fLength * fWidth) * int.Parse(txtBundle.Text)).ToString();
            //        //lblAmount.Text = (float.Parse(lblTotalMeasure.Text) * float.Parse(txtRate.Text)).ToString();

            //    }

            //    if (str_IsBundle == "0" && str_IsMesh == "0")
            //    {
            //        grdVoucher.Rows[i].Cells[(int)GColGrn.Amount].Value =
            //            clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.Rate].Value.ToString())
            //            * clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.Qty].Value.ToString());
            //            //* Convert.ToDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.Bundle].Value);
            //    }

            //    //if (grdVoucher.Rows[i].Cells[(int)GColGrn.isBundle].Value.GetType = checked)
            //    //{
            //    //    bcheck= decimal.TryParse(grdVoucher.Rows[i].Cells[(int)GColGrn.Rate].Value, out outValue);

            //    //    grdVoucher.Rows[i].Cells[(int)GColGrn.Amount].Value = 
            //    //        decimal.TryParse(grdVoucher.Rows[i].Cells[(int)GColGrn.Rate].Value, outValue) 
            //    //        * decimal.TryParse(grdVoucher.Rows[i].Cells[(int)GColGrn.Bundle].Value, outValue);
            //    //}

            //    if (grdVoucher.Rows[i].Cells[(int)GColGrn.Amount].Value != null)
            //    {
            //        bcheck = decimal.TryParse(grdVoucher.Rows[i].Cells[(int)GColGrn.Amount].Value.ToString(), out outValue);
            //        if (bcheck)
            //        {
            //            rtnVal += outValue;
            //            fTotalAmount += outValue;
            //            fTotalQty += clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColGrn.Qty].Value.ToString());
            //        }
            //    }
            //     //grdVoucher[2, i].Value = (i + 1).ToString();
            }

            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.Rows[i].Cells[(int)GColGrn1.NetAmount].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColGrn1.NetAmount].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fTotalAmount = fTotalAmount + outValue;
                    }
                }
            }

            lblTotalAmount.Text = String.Format("{0:0,0.00}", fTotalAmount);

            lblTotalAmount.Text = String.Format("{0:0,0.00}", fTotalAmount);
            lblTotalQty.Text = String.Format("{0:0,0.00}", fTotalQty);
        }

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
                if (grd.Rows.Count < 1)
                {
                    fTErr++;
                    //dGvError.Rows.Add(fTErr.ToString(), "Trans.", "", "No Transaction in the grid to save. " + "  " + lNow.ToString());
                    MessageBox.Show("No transaction in grid to Save", "Save: " + this.Text.ToString());
                    return false;
                }
                fLastRow = grd.Rows.Count - 1;
                if (!FormValidation())
                {
                    //textAlert.Text = "Form Validation Error: Not Saved." + "  " + lNow.ToString();
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
                fTNOT = GridTNOT(grd);
                if (!PrepareDocMaster())
                {
                    //textAlert.Text = "DocMaster: Modifying Doc/Voucher not available for updation.'  ...." + "  " + lNow.ToString();
                    //tabMDtl.SelectedTab = tabError;
                    return false;
                }
                //
                if (grd.Rows.Count > 0)
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
                    //textAlert.Text = "selected Box Empty... " + now.ToString("T");
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
                            //textAlert.Text = "Existing ID: " + txtManualDoc.Text + " Modified .... " + "  " + lNow.ToString();
                        }
                        else
                        {
                            //textAlert.Text = "New ID: " + txtManualDoc.Text + " Inserted .... " + "  " + lNow.ToString();
                        }
                        //EDButtons(true);
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
            string str_CreditPurcCode = string.Empty;

            try
            {
                string lDocDateStr = StrF01.D2Str(msk_VocDate);
                DateTime lDocDate = DateTime.Parse(lDocDateStr);
                str_CreditPurcCode = clsDbManager.GetConfigCode("cmn_Config", "CreditPurcID", "", "");

                if (lblDocID.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocWhere = " doc_vt_id=" + fDocTypeID.ToString();
                    fDocWhere += " and doc_fiscal_id=1 ";

                    //fDocAmt = decimal.Parse(lblTotalDr.Text.ToString());
                    //fDocID = clsDbManager.GetNextValDocID("gl_tran", "doc_id", NewDocWhere(), "");
                    fDocID = clsDbManager.GetNextValDocID("Inv_tran", "doc_id", fDocWhere, "");

                    lblDocID.Text = fDocID.ToString();
                    //
                    lSQL = "insert into gl_tran (";
                    lSQL += "  doc_vt_id";                                         // 1-
                    lSQL += ", doc_fiscal_id ";                                     // 2-
                    lSQL += ", doc_ID";                                            // 3-
                    lSQL += ", doc_StrID";                                         // 4-
                    lSQL += ", doc_date";                                          // 5-
                    lSQL += ", GLID";                                          // 6-
                    lSQL += ", doc_tnot";                                          // 6-
                    lSQL += ", doc_remarks";                                       // 7-
                    lSQL += ", doc_amt";                                           // 8-
                    lSQL += ", doc_status";                                        // 7-

                    lSQL += ", created_by";                                        // 8-
                    //lSQL += ", modified_by ";                                     // 9-
                    lSQL += ", created_date";                                      // 10-
                    //lSQL += ", modified_date  ";                                  // 11-
                    lSQL += " ) values (";
                    //
                    lSQL += fDocTypeID.ToString();                                 // JVR = 267, CRV=268
                    lSQL += ", " + fDocFiscal.ToString();                           // 3-
                    lSQL += ", " + fDocID.ToString() + "";                          // 4-
                    lSQL += ",'" + StrF01.EnEpos(txtManualDoc.Text) + "'";          // 5-
                    lSQL += ",'" + StrF01.D2Str(msk_VocDate) + "'";                 // 6-
                    lSQL += ", " + msk_AccountID.Tag;                             // 7- 
                    lSQL += ", " + fTNOT;                                           // 7- 
                    lSQL += ",'" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'"; // 8-
                    lSQL += ", " + fDocAmt.ToString();                              // 9-
                    lSQL += ", 1";                              // 13- Doc Status 

                    lSQL += ", " + clsGVar.AppUserID.ToString();                   // 10- Created by
                    //                                                             // 11- Modified by
                    lSQL += ",'" + StrF01.D2Str(DateTime.Now, true) + "'";         // 12- Created Date  
                    //                                                             // 13- Modified Date
                    lSQL += ")";

                    fManySQL.Add(lSQL);
                    // Invoice Entry
                    lSQL = "insert into Inv_tran (";
                    lSQL += "  doc_vt_id ";                                         // 1-
                    lSQL += ", doc_fiscal_id ";                                     // 2-
                    lSQL += ", doc_ID ";                                            // 3-
                    lSQL += ", doc_StrID ";                                         // 4-
                    lSQL += ", doc_date ";                                          // 5-
                    lSQL += ", GLID ";                                          // 6-
                    lSQL += ", ContractNo ";                                          // 6-
                    lSQL += ", doc_tnot ";                                          // 6-
                    lSQL += ", doc_remarks ";                                       // 7-
                    lSQL += ", doc_amt ";                                           // 8-

                    lSQL += ", doc_status ";                                        // 7-
                    lSQL += ", BiltyNo";                                        // 7-
                    lSQL += ", BiltyDate";                                        // 7-
                    lSQL += ", VehicleNo";                                        // 7-
                    lSQL += ", DriverName";                                        // 7-
                   // lSQL += ", TransportID";                                        // 7-
                    lSQL += ", isShowRpt";                                        // 7-
                    lSQL += ", isCalcRpt";                                        // 7-

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
                    lSQL += ", " + msk_AccountID.Tag;                             // 7- 
                    lSQL += ",'" + StrF01.EnEpos(txtContract.Text) + "'";                 // 6-
                    lSQL += ", " + fTNOT;                                           // 7- 
                    lSQL += ",'" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'"; // 8-
                    lSQL += ", " + fDocAmt.ToString();                              // 9-
                    lSQL += ", 1";                              // 13- Doc Status 

                    lSQL += ",'" + StrF01.EnEpos(txtBiltyNo.Text.ToString()) + "'"; // 8-
                    lSQL += ",'" + StrF01.EnEpos(txtBiltyDate.Text.ToString()) + "'"; // 8-
                    lSQL += ",'" + StrF01.EnEpos(txtVehicleNo.Text.ToString()) + "'"; // 8-
                    lSQL += ",'" + StrF01.EnEpos(txtDriverName.Text.ToString()) + "'"; // 8-
                   // lSQL += ", " + cboTransport.SelectedValue.ToString();                              // 9-
                    lSQL += ", " + (chk_ShowRpt.Checked == true ? 1 : 0);                              // 9-
                    lSQL += ", " + (chk_CalcRpt.Checked == true ? 1 : 0);                              // 9-

                    lSQL += ", " + clsGVar.AppUserID.ToString();                   // 10- Created by
                    //                                                             // 11- Modified by
                    lSQL += ",'" + StrF01.D2Str(DateTime.Now, true) + "'";         // 12- Created Date  
                    //                                                             // 13- Modified Date
                    lSQL += ")";

                    fManySQL.Add(lSQL);
                }
                else
                {
                    fDocWhere = " Doc_vt_id = " + fDocTypeID.ToString();
                    //fDocWhere += " AND doc_Fiscal_ID = " + fDocFiscal.ToString();
                    fDocWhere += " AND Doc_ID = " + String.Format("{0,0}", lblDocID.Text.ToString());
                    //if (clsDbManager.IDAlreadyExistWw("gl_tran", "doc_id", DocWhere("")))
                    if (clsDbManager.IDAlreadyExistWw("gl_tran", "doc_id", fDocWhere))
                    {
                        fDocAlreadyExists = true;
                        lSQL = "delete from gl_trandtl ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                        lSQL = "delete from Inv_trandtl ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //}
                        //else
                        //{
                        //dGvError.Rows.Add("M", "Master Doc", mtDocID.Text.ToString(), "Doc/Voucher " + mtDocID.Text.ToString() + " has been removed.");
                        //MessageBox.Show("Doc/Voucher ID " + lblDocID.Text.ToString() + " has been deleted or removed"
                        //   + "\n\r" + "The Voucher will be saved as new voucher, try again "
                        //   + "\n\r" + "Or press clear button to discard the voucher/Doc.", this.Text.ToString());
                        //lblDocID.Text = "";
                        //rtnValue = false;
                        //return rtnValue;

                        fDocID = Convert.ToInt64(lblDocID.Text.ToString());
                        lSQL = "update gl_tran set";
                        //
                        lSQL += "  doc_date = '" + StrF01.D2Str(msk_VocDate) + "'";                       // 9-
                        lSQL += ", doc_strid = '" + txtManualDoc.Text.ToString() + "'";                   // 9-

                        lSQL += ", GLID = " + msk_AccountID.Tag;                                         // 10-
                        //lSQL += ", ContractNo = '" + txtContract.Text.ToString() + "'";                   // 9-
                        lSQL += ", doc_tnot = " + fTNOT.ToString();                                       // 10-
                        lSQL += ", doc_remarks = '" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'";    // 12-
                        lSQL += ", doc_amt = " + fDocAmt.ToString();                                // 13-
                        lSQL += ", modified_by = " + clsGVar.AppUserID.ToString();                  // 16-
                        lSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";     // 18-
                        lSQL += " where ";
                        lSQL += fDocWhere;

                        fManySQL.Add(lSQL);

                        lSQL = "update Inv_tran set";
                        lSQL += "  doc_date = '" + StrF01.D2Str(msk_VocDate) + "'";                       // 9-
                        lSQL += ", doc_strid = '" + txtManualDoc.Text.ToString() + "'";                   // 9-

                        lSQL += ", GLID = " + msk_AccountID.Tag;                                         // 10-
                        lSQL += ", ContractNo = '" + txtContract.Text.ToString() + "'";                   // 9-
                        lSQL += ", doc_tnot = " + fTNOT.ToString();                                       // 10-
                        lSQL += ", doc_remarks = '" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'";    // 12-
                        lSQL += ", doc_amt = " + fDocAmt.ToString();                                // 13-

                        lSQL += ", BiltyNo = '" + StrF01.EnEpos(txtBiltyNo.Text.ToString()) + "'";
                        lSQL += ", BiltyDate = '" + StrF01.EnEpos(txtBiltyDate.Text.ToString()) + "'";
                        lSQL += ", VehicleNo = '" + StrF01.EnEpos(txtVehicleNo.Text.ToString()) + "'";
                        lSQL += ", DriverName = '" + StrF01.EnEpos(txtDriverName.Text.ToString()) + "'";
                        //lSQL += ", TransportID = " + cboTransport.SelectedValue.ToString();
                        lSQL += ", isShowRpt = " + (chk_ShowRpt.Checked == true ? 1 : 0);
                        lSQL += ", isCalcRpt = " + (chk_CalcRpt.Checked == true ? 1 : 0);

                        lSQL += ", modified_by = " + clsGVar.AppUserID.ToString();                  // 16-
                        lSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";     // 18-
                        lSQL += " where ";
                        lSQL += fDocWhere;
                        //
                        fManySQL.Add(lSQL);
                    }

                    else
                    {
                        fDocWhere = " doc_id = '" + lblDocID.Text.ToString() + "'";
                        if (clsDbManager.IDAlreadyExistWw("inv_tran", "doc_id", fDocWhere))
                        {

                            fDocAlreadyExists = true;
                            lSQL = "delete from inv_trandtl ";
                            lSQL += " where " + fDocWhere;

                            fManySQL.Add(lSQL);
                            //
                        }
                    }
                }

                if (grd.Rows.Count > 0)
                {
                    /* Commented by Usama Naveed
                    //Prepare_GL_Trans();
                    */

                    // 1st GL Transaction
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
                    //lSQL += " " + fDocTypeID.ToString();                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                    //lSQL += ", " + fDocFiscal.ToString();                      // 4- Document Fiscal
                    //lSQL += ", " + fDocID.ToString();                          // 2- Form 1- Voucher_id
                    ////
                    //lSQL += ", " + msk_AccountID.Tag; //grdVoucher.Rows[dGVRow].Cells[(int)GColGrn.acid].Value.ToString();            // 2- Serial Order replaced with SNo. 
                    ////                                                                                       // 5- Ac Title NA
                    //lSQL += ", '" + "Invoice Entry" + "'";      // 8- Narration 
                    //lSQL += ", " + clsDbManager.ConvDecimal(lblTotalAmount.Text);           // 9- Debit. 
                    //lSQL += ", " + 0;           // 10- Credit
                    //lSQL += ", " + 0;          // 11- Combo 1 
                    //lSQL += ", 0"; //is Checked
                    //lSQL += ")";

                    //fManySQL.Add(lSQL);
                }
                // 2nd GL Transaction
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
                lSQL += ", " + clsDbManager.ConvInt(str_CreditPurcCode); //msk_AccountID.Tag; //grdVoucher.Rows[dGVRow].Cells[(int)GColGrn.acid].Value.ToString();            // 2- Serial Order replaced with SNo. 
                //                                                                                       // 5- Ac Title NA
                lSQL += ", '" + StrF01.EnEpos(lblAccountName.Text) + "'";      // 8- Narration 
                lSQL += ", " + clsDbManager.ConvDecimal(lblTotalAmount.Text);           // 9- Debit. 
                lSQL += ", " + 0;           // 10- Credit

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
            try
            {
                for (int dGVRow = 0; dGVRow < grd.Rows.Count; dGVRow++)
                {
                    if (grd.Rows[dGVRow].Cells[(int)GColGrn1.ItemID].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if ((grd.Rows[dGVRow].Cells[(int)GColGrn1.ItemID].Value.ToString()).Trim(' ', '-') == "")
                        {
                            //lBlank = true;
                            if (dGVRow == fLastRow)
                            {
                                continue;
                            }
                        }
                    }

                    //ItemID = 0,
                    //ItemName = 1,
                    //UOMID = 2,
                    //UOMName = 3,
                    //GodownID = 4,
                    //GodownName = 5,
                    //Qty = 6,
                    //Rate = 7,
                    //Value = 8,
                    //DiscountPercentage = 9,
                    //DiscountValue = 10,
                    //AfterDiscount = 11,
                    //SalesTaxPercentage = 12,
                    //SalesTaxAmount = 13,
                    //FEDPercentage = 14,
                    //FEDValue = 15,
                    //NetAmount = 16,                                                                                                           

                    lSQL = "INSERT INTO Inv_trandtl ( doc_id ";
                    lSQL += ",doc_vt_id, ItemID, UOMID, Qty_In, Rate, DiscPercent, DiscAmount, STRate, FSTRate)";
                    lSQL += " VALUES (";
                    lSQL += "" + fDocID + "";
                    lSQL += "," + fDocTypeID;
                   // lSQL += ", '" + txtGateInward.Text.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGrn1.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGrn1.UOMID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGrn1.Qty].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGrn1.Rate].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGrn1.DiscPercent].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGrn1.DiscValue].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGrn1.STPercent].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGrn1.FEDPercent].Value.ToString() + "";
                    lSQL += ")";
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

        private bool Prepare_GL_Trans()
        { 
            bool rtnValue = true;
            string lSQL = "";
            DataSet ds = new DataSet();
            DataRow dRow;
            string strItemDes = string.Empty;
            string strUOM_ST = string.Empty;
            //Int64 lAcID = 0;
            try
            {
                //
                for (int dGVRow = 0; dGVRow < grd.Rows.Count; dGVRow++)
                {
                    //frmGroupRights.dictGrpForms.Add(Convert.ToInt32(dGVSelectedForms.Rows[dGVRow].Cells[0].Value.ToString()),
                    //    dGVSelectedForms.Rows[dGVRow].Cells[1].Value.ToString());
                    // Prepare Save Data to Db Table
                    //
                    if (grd.Rows[dGVRow].Cells[(int)GColGrn.ItemID].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if ((grd.Rows[dGVRow].Cells[(int)GColGrn.ItemID].Value.ToString()).Trim(' ', '-') == "")
                        {
                            //lBlank = true;
                            if (dGVRow == fLastRow)
                            {
                                continue;
                            }
                        }
                    }
                    strItemDes = "";
                    strUOM_ST = "";

                    lSQL = "SELECT gg.Group_st + i.goodsitem_st AS Item_ST ";
                    lSQL += " FROM gds_item i INNER JOIN gds_Group gg ON i.Group_id=gg.Group_id ";
                    lSQL += " WHERE i.goodsitem_id=" + grd.Rows[dGVRow].Cells[(int)GColGrn.ItemID].Value.ToString();
                    lSQL += "; SELECT goodsuom_st FROM gds_uom WHERE goodsuom_id=";
                    lSQL += grd.Rows[dGVRow].Cells[(int)GColGrn.UOMID].Value.ToString();

                    ds = clsDbManager.GetData_Set(lSQL, "Items");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dRow = ds.Tables[0].Rows[0];
                        strItemDes = dRow.ItemArray.GetValue(0).ToString();

                        dRow = ds.Tables[1].Rows[0];
                        strUOM_ST = dRow.ItemArray.GetValue(0).ToString();

                    }

                    if (grd.Rows[dGVRow].Cells[(int)GColGrn.isMesh].Value != null)
                    {
                        if (clsDbManager.ConvBit(grd.Rows[dGVRow].Cells[(int)GColGrn.isBundle].Value.ToString()) == "0"
                            && clsDbManager.ConvBit(grd.Rows[dGVRow].Cells[(int)GColGrn.isMesh].Value.ToString()) == "0")
                        {
                            strItemDes += " B=" + grd.Rows[dGVRow].Cells[(int)GColGrn.Bundle].Value.ToString()
                                + " Q=" + grd.Rows[dGVRow].Cells[(int)GColGrn.Qty].Value.ToString()
                                + " " + strUOM_ST
                                + " @" + grd.Rows[dGVRow].Cells[(int)GColGrn.Rate].Value.ToString();
                        }

                        if (clsDbManager.ConvBit(grd.Rows[dGVRow].Cells[(int)GColGrn.isBundle].Value.ToString()) == "1")
                        {
                            strItemDes += " Q=" + grd.Rows[dGVRow].Cells[(int)GColGrn.Bundle].Value.ToString()
                                + " " + strUOM_ST
                                + " @" + grd.Rows[dGVRow].Cells[(int)GColGrn.Rate].Value.ToString();
                        }

                        if (clsDbManager.ConvBit(grd.Rows[dGVRow].Cells[(int)GColGrn.isMesh].Value.ToString()) == "1")
                        {
                            strItemDes += " B=" + grd.Rows[dGVRow].Cells[(int)GColGrn.Bundle].Value.ToString()
                                + " x L=" + grd.Rows[dGVRow].Cells[(int)GColGrn.Length].Value.ToString()
                                + " x W=" + grd.Rows[dGVRow].Cells[(int)GColGrn.Width].Value.ToString()
                                + " Q=" + grd.Rows[dGVRow].Cells[(int)GColGrn.MeshTotal].Value.ToString()
                                + " " + strUOM_ST
                                + " @" + grd.Rows[dGVRow].Cells[(int)GColGrn.Rate].Value.ToString();
                        }

                    }
                    //lSQLValues += ConvBit("False");
                    //}
                    //else
                    //{
                    //lSQLValues += ConvBit(pdGv.Rows[i].Cells[j].Value.ToString());
                    //}
                    //grdVoucher.Rows[dGVRow].Cells[(int)GColGrn.isMesh].Value.ToString()

                    // 1st GL Transaction
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
                    lSQL += ", " + msk_AccountID.Tag; //grdVoucher.Rows[dGVRow].Cells[(int)GColGrn.acid].Value.ToString();            // 2- Serial Order replaced with SNo. 
                    //                                                                                       // 5- Ac Title NA
                    lSQL += ", '" + strItemDes + "'";      // 8- Narration 
                    lSQL += ", " + 0;           // 9- Debit. 
                    lSQL += ", " + clsDbManager.ConvDecimal(grd.Rows[dGVRow].Cells[(int)GColGrn.Amount].Value.ToString());           // 10- Credit
                    lSQL += ", " + 0;          // 11- Combo 1 
                    lSQL += ", 0"; //is Checked
                    lSQL += ")";

                    fManySQL.Add(lSQL);
                    //rtnValue = true;
                    
                }
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
            //decimal lDebit = 0;
            //decimal lCredit = 0;
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

                //lDebit = (lblTotalDr.Text == "" ? 0 : Convert.ToDecimal(lblTotalDr.Text));
                //lCredit = (lblTotalCr.Text == "" ? 0 : Convert.ToDecimal(lblTotalCr.Text));

                //lDebit = decimal.Parse((lblTotalDr.Text=="" ? 0: lblTotalDr.Text));
                //lCredit = decimal.Parse(lblTotalDr.Text);

                //if (lDebit != lCredit)
                //{
                //    if (!fSingleEntryAllowed)
                //    {
                //        // for for conventional books as in old Finac.
                //        fTErr++;
                //        ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Sum: Debit: " + lDebit.ToString() + " Credit: " + lCredit.ToString() + " Diff: " + (lDebit - lCredit).ToString() + "");
                //        //dGvError.Rows.Add(fTErr.ToString(), "Total Debit/Credit", "", ErrrMsg + "  " + lNow.ToString());
                //        return false;
                //    }
                //}
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
                    if (pdGv.Rows[dGVRow].Cells[(int)GColGrn.ItemID].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((pdGv.Rows[dGVRow].Cells[(int)GColGrn.ItemID].Value.ToString()).Trim(' ', '-') == "")
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
                //MessageBox.Show("Manual Voucher Number is Empty! Unable to Save");
                //return;
            }
            if (msk_AccountID.Text.Trim(' ', '_') == "")
            {
                //MessageBox.Show("Master GL Code is Empty! Unable to Save");
                //return;
            }
            else
            {
                //MessageBox.Show("has data");
                SaveData();
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

                    /*
                    int tcboTransportID = 0;
                    tcboTransportID = Convert.ToInt16(ds.Tables[0].Rows[0]["TransportID"].ToString());
                    cboTransport.SelectedIndex = clsSetCombo.Set_ComboBox(cboTransport, tcboTransportID);
                    */
                     
                    fEditMod = true;
                    


                    //tFirstID = Convert.ToInt16(dRow.ItemArray.GetValue(3).ToString());
                    //cboFirstID.SelectedIndex = ClassSetCombo.Set_ComboBox(cboFirstID, tFirstID);

                    //cboTransport.Text = (ds.Tables[0].Rows[0]["TransportID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["TransportID"].ToString());

                    //grdVoucher.DataSource = ds.Tables[1];
                    //grdVoucher.Visible = true;
                    //lblAccountName.Text = dRow.ItemArray.GetValue(0).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();

                    //if (grdVoucher.RowCount > 1)
                    //{
                    //    grdVoucher.Rows.Clear();
                    //    grdVoucher.Columns.Clear();
                    //}
                    //grdVoucher.Visible = false;
                    //grdVoucher.Rows.Clear();
                    //grdVoucher.Columns.Clear();

                    //grdVoucher.DataSource = ds.Tables[1];
                    //grdVoucher.Visible = true;

                    //grdVoucher.Rows.Clear();
                    //grdVoucher.Columns.Clear();
                    ////
                    //for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    //{
                    //    dRow = ds.Tables[1].Rows[i];
                    //    // **** Following Two Rows may get data one time *****
                    //    //         dGvDetail.DataSource = Zdtset.Tables[0];
                    //    //         dGvDetail.Visible = true;
                    //    // **** Following Two Rows may get data one time *****
                    //    //grdVoucher.Columns = 17;
                        
                    //    grdVoucher.Rows.Add(
                    //        (dRow.ItemArray.GetValue((int)GColGrn.ItemID) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGrn.ItemID).ToString()),                       // 0-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.ItemName) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGrn.ItemName).ToString()),                           // 1-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.UOMID) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGrn.UOMID).ToString()),                           // 1-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.UOMName) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGrn.UOMName).ToString()),                             // 3-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.GodownID) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGrn.GodownID).ToString()),                          // 4-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.GodownName) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColGrn.GodownName).ToString()),                          // 5-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.Qty) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGrn.Qty).ToString()),                            // 6-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.Rate) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGrn.Rate).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.Bundle) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGrn.Bundle).ToString()),                           // 10-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.MeshTotal) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGrn.MeshTotal).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.Amount) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGrn.Amount).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.isBundle) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGrn.isBundle).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.isMesh) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGrn.isMesh).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.Length) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGrn.Length).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.LenDec) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGrn.LenDec).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.Width) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGrn.Width).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColGrn.WidDec) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColGrn.WidDec).ToString())                            // 9-
                    //        );
                    //    //dGvDetail.Columns[1].ReadOnly = true;  // working
                    //}
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                        btn_EnableDisable(true);
                    }
                    LoadGridData();
                    SumVoc();
                    //txtManualDoc.Enabled = false;
                }
            }
            catch
            {
                //MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ClearThisForm();
        }
        //
        private void ClearThisForm()
        {
            // Transport Tab Clear  -- Begin
            txtBiltyNo.Text = string.Empty;
            txtBiltyDate.Text = string.Empty;
            txtVehicleNo.Text = string.Empty;
            txtDriverName.Text = string.Empty;
            cboTransport.SelectedValue = 7;
            // Transport Tab Clear  -- end

            lblDocID.Text = string.Empty;
            txtManualDoc.Text = string.Empty;
            txtManualDoc.Enabled = true;
            txtRemarks.Text = string.Empty;
            lblTotalQty.Text = string.Empty;
            lblTotalAmount.Text = string.Empty;
            //
            if (grd.Rows.Count > 0)
            {
                grd.Rows.Clear();
            }
            ResetFields();
            chk_Edit.Checked = false;
            txtManualDoc.Focus();
        }

        private void ClearSub_Add_Btn()
        {
            txtItemID.Text = string.Empty;
            lblItemName.Text = string.Empty;
            lblGodownBal.Text = string.Empty;
            lblBalItem.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtRate.Text = string.Empty;
            lblAmount.Text = string.Empty;
            chk_Mesh.Checked = false;
            chk_BundleCalc.Checked = false;
            txtBundle.Text = string.Empty;
            txtWidth.Text = string.Empty;
            txtWidDec.Text = string.Empty;
            txtLength.Text = string.Empty;
            txtLenDec.Text = string.Empty;
            lblTotalMeasure.Text = string.Empty;
            lblMeshBal.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            //lblInvoiceTotal.Text = string.Empty;

            txtItemID.Focus();

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

        private void txtManualDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
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

        //"ItemID";     
        //",Name";      
        //",UOMName";   
        //",Qty";       
        //",Rate";      
        //",Value";     
        //",DiscPercent"
        //",DiscAmount";
        //",AfterDisc"; 
        //",STRate";    
        //",STAmount";  
        //",FSTRate";   
        //",FSTAmount"; 
        //",NetAmount"; 
        //",UOMID";     
        
        

        private void LoadGridData()
        {
            string lSQL = "";
            lSQL += "  select i.ItemID AS ItemID, item.goodsitem_title AS Name, i.UOMID, ";
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


        // Prepare Document Where
        private string DocWhere(string pPrefix = "")
        {
          // pPrefix is including dot
          string fDocWhere = string.Empty;
          try
          {
            fDocWhere = " t.doc_vt_id=" + fDocTypeID.ToString();
            fDocWhere += " and t.doc_fiscal_id=1 and t.doc_status=1";
            fDocWhere += " and t.doc_id=" + lblDocID.Text.ToString();
            return fDocWhere;
          }
          catch (Exception ex)
          {
            throw;
          }
        }

        private void grdVoucher_KeyDown(object sender, KeyEventArgs e)
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

            //if (e.KeyCode == Keys.Insert)
            //{
            //    if (pnlVocTran.Visible == false)
            //    {
            //        pnlVocTran.Visible = true;
            //        btn_Add.Text = "&Add";

            //        msk_AccountID.Focus();
            //    }
            //}
            //if (e.KeyCode == Keys.Escape)
            //{
            //    if (pnlVocTran.Visible == true)
            //    {
            //        pnlVocTran.Visible = false;
            //        if (grdVoucher.Rows.Count > 2)
            //        {
            //            grdVoucher.Focus();
            //        }
            //        else
            //        {
            //            msk_VocDate.Focus();
            //        }
            //    }

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

                if (grd.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure, really want to Delete row ?", "Delete Row", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        grd.Rows.RemoveAt(grd.CurrentRow.Index);
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

                if (grd.Rows.Count > 0)
                {

                    if (fEditMod == true)
                    {
                        if (chk_Edit.Checked == false)
                        {
                            return;
                        }
                    }
                    //Current Row
                    fEditRow = grd.CurrentRow.Index;

                    txtItemID.Text = grd.Rows[fEditRow].Cells[(int)GColCsInv.ItemID].Value.ToString();
                    lblItemName.Text = grd.Rows[fEditRow].Cells[(int)GColCsInv.ItemName].Value.ToString();
                    cbo_UOM.SelectedIndex = clsSetCombo.Set_ComboBox(cbo_UOM, int.Parse(grd.Rows[fEditRow].Cells[(int)GColCsInv.UOMID].Value.ToString()));
                    cboGodown.SelectedIndex = clsSetCombo.Set_ComboBox(cboGodown, int.Parse(grd.Rows[fEditRow].Cells[(int)GColCsInv.GodownID].Value.ToString()));

                    txtQty.Text = grd.Rows[fEditRow].Cells[(int)GColCsInv.Qty].Value.ToString();
                    txtRate.Text = grd.Rows[fEditRow].Cells[(int)GColCsInv.Rate].Value.ToString();
                    txtBundle.Text = grd.Rows[fEditRow].Cells[(int)GColCsInv.Bundle].Value.ToString();
                    lblTotalMeasure.Text = grd.Rows[fEditRow].Cells[(int)GColCsInv.MeshTotal].Value.ToString();
                    lblAmount.Text = grd.Rows[fEditRow].Cells[(int)GColCsInv.Amount].Value.ToString();
                    txtLength.Text = grd.Rows[fEditRow].Cells[(int)GColCsInv.Length].Value.ToString();
                    txtLenDec.Text = grd.Rows[fEditRow].Cells[(int)GColCsInv.LenDec].Value.ToString();
                    txtWidth.Text = grd.Rows[fEditRow].Cells[(int)GColCsInv.Width].Value.ToString();
                    txtWidDec.Text = grd.Rows[fEditRow].Cells[(int)GColCsInv.WidDec].Value.ToString();

                    //ConvBit(pdGv.Rows[i].Cells[j].Value.ToString())
                    if (grd.Rows[fEditRow].Cells[(int)GColCsInv.isBundle].Value.ToString() == "True")
                    {
                        chk_BundleCalc.Checked = true;
                    }
                    if (grd.Rows[fEditRow].Cells[(int)GColCsInv.isMesh].Value.ToString() == "True")
                    {
                        chk_Mesh.Checked = true;
                    }

                    //chk_BundleCalc.Checked = clsDbManager.ConvBit(grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.isBundle].Value.ToString());
                    //chk_Mesh.Checked = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.isMesh].Value.ToString();

                    btn_Add.Text = "&Update";
                    this.tabControl1.SelectedTab = this.tabControl1.TabPages["InputTrans"];
                    //this.tabControl1.SelectedTab = this.tabControl1.TabPages["Transaction"];

                    txtItemID.Focus();

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
            grd.Focus();
        }

        private void frmGRNCr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (!fGridControl)
                //{
                //    e.Handled = true;
                //    SendKeys.Send("{TAB}");
                //}
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

            if (e.KeyCode == Keys.Insert)
            {
                if (fEditMod == true)
                {
                    if (chk_Edit.Checked == false)
                    {
                        return;
                    }
                }
                this.tabControl1.SelectedTab = this.tabControl1.TabPages["InputTrans"];
                txtItemID.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.tabControl1.SelectedTab = this.tabControl1.TabPages["Transaction"];
            }

        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            string plstField = "@Doc_ID,@Doc_VT_ID";
            string plstType = "8,8"; // {   "8 int, 8 DateTime, 18 Text" };
            string plstValue = lblDocID.Text.ToString() + "," + fDocTypeID.ToString();
            fRptTitle = this.Text;

            //DataSet ds = new DataSet();
            dsInvoice ds = new dsInvoice();
            //CrInvoice rpt1 = new CrInvoice();
            //CrInvoiceDes rpt1 = new CrInvoiceDes();
            CrInvoiceDesQty rpt1 = new CrInvoiceDesQty();

            frmPrintViewer rptView = new frmPrintViewer(
               fRptTitle,
               msk_VocDate.Text,
               msk_VocDate.Text,
               "sp_GRN",
               plstField,
               plstType,
               plstValue,
               ds,
               rpt1,
               "SP"
               );

            rptView.Show();
        }

        private bool ValidationAdd_Btn() 
        {
            bool lRtnValue = true;
            //DateTime lNow = DateTime.Now;
            //fDocAmt = 0;
            //
            ErrrMsg = "";
            try
            {
                if (txtItemID.Text.ToString().Trim(' ', '-') == "")
                {
                    ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Item ID Empty or Blank, Select Valid Item ID! Try Again");
                    fTErr++;
                    lRtnValue = false;
                    txtItemID.Focus();
                    throw new Exception();
                }

                if (Convert.ToDecimal(txtRate.Text.ToString()) == 0)
                {
                    ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Item Rate Empty or Blank, Put the Rate and Try Again");
                    fTErr++;
                    lRtnValue = false;
                    txtRate.Focus();
                }

                if (clsDbManager.ConvBit(chk_BundleCalc) == "0" && clsDbManager.ConvBit(chk_Mesh) == "0"
                    && Convert.ToDecimal(txtQty.Text.ToString())==0)
                {
                    ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Item Qty Empty or Blank, Put the Qty and Try Again");
                    fTErr++;
                    lRtnValue = false;
                    txtQty.Focus();
                }

                if (clsDbManager.ConvBit(chk_BundleCalc) == "1" &&  Convert.ToDecimal(txtBundle.Text.ToString()) == 0)
                {
                    ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Item Bundle Empty or Blank, Put the Bundle and Try Again");
                    fTErr++;
                    lRtnValue = false;
                    txtBundle.Focus();
                }

                if (clsDbManager.ConvBit(chk_Mesh) == "1" && Convert.ToDecimal(txtWidth.Text.ToString()) == 0
                    && Convert.ToDecimal(txtLength.Text.ToString()) == 0)
                {
                    ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Item Width or Length Empty or Blank, Put the Value and Try Again");
                    fTErr++;
                    lRtnValue = false;
                    txtWidth.Focus();
                }
                return lRtnValue;

            }
            catch (Exception ex)
            {
                fTErr++;
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Exception: Validation For Add Button -> " + ex.Message.ToString());
                MessageBox.Show(ErrrMsg, this.Text);
                //dGvError.Rows.Add(fTErr.ToString(), "Exception: FormValidation -> ", "", ErrrMsg + "  " + lNow.ToString());
                return false;
            }
            //return lRtnValue;        // to be removed
        }

        private void chk_BundleCalc_Leave(object sender, EventArgs e)
        {
            txtBundle.Focus();
        }

        private void txtWidDec_Leave(object sender, EventArgs e)
        {
            btn_Add.Focus();
        }

        private void txtManualDoc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LookUp_Voc();
        }

        private void txtItemID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LookUp_Item();
        }

        private void msk_AccountID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LookUpAc_Mask();
        }

        private void msk_VocDate_Leave(object sender, EventArgs e)
        {
            string lRtnValue = clsDbManager.VocCheckAndDisplayList(
            "Inv_tran",
            "doc_strid",
            fDocTypeID,
            StrF01.D2Str(msk_VocDate),
            txtManualDoc.Text);

            if (lRtnValue != "Not Found!")
            {
                MessageBox.Show("Voucher(s) : \n" + lRtnValue, this.Text.ToString());
            }
        }

        private void msk_AccountID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btn_PinID_Click(object sender, EventArgs e)
        {
            if (btn_PinID.Text == "&Pin")
            {
                btn_PinID.Text = "&Un Pin";
                btn_PinID.Image = Properties.Resources.tiny_pinned;
                cboGodown.Enabled = false;
            }
            else
            {
                btn_PinID.Text = "&Pin";
                btn_PinID.Image = Properties.Resources.tiny_pin;
                cboGodown.Enabled = true;
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (clsDbManager.ConvDecimal(txtQty.Text.ToString()) == 0)
            {
                //MessageBox.Show("Qty is Empty! Unable to Process", this.Text.ToString());
                //txtQty.Focus();
            }
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            if (clsDbManager.ConvDecimal(txtRate.Text.ToString()) == 0)
            {
                //MessageBox.Show("Rate is Empty! Unable to Process", this.Text.ToString());
                //txtRate.Focus();
            }
        }

        private void txtManualDoc_Leave(object sender, EventArgs e)
        {

        }

        private void txtManualDoc_Validating(object sender, CancelEventArgs e)
        {
            if (!fFormClosing)
            {
                if (txtManualDoc.Text == "")
                {
                  //  MessageBox.Show("Voucher # is Empty! Unable to Process", this.Text.ToString());
                   // txtManualDoc.Focus();
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        static bool HelperConvertNumberToText(int num, out string buf)
        {
            string[] strones = {
            "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
            "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
            "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen",
          };

            string[] strtens = {
              "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty",
              "Seventy", "Eighty", "Ninety", "Hundred"
          };

            string result = "";
            buf = "";
            int single, tens, hundreds;

            if (num > 1000)
                return false;

            hundreds = num / 100;
            num = num - hundreds * 100;
            if (num < 20)
            {
                tens = 0; // special case
                single = num;
            }
            else
            {
                tens = num / 10;
                num = num - tens * 10;
                single = num;
            }

            result = "";

            if (hundreds > 0)
            {
                result += strones[hundreds - 1];
                result += " Hundred ";
            }
            if (tens > 0)
            {
                result += strtens[tens - 1];
                result += " ";
            }
            if (single > 0)
            {
                result += strones[single - 1];
                result += " ";
            }

            buf = result;
            return true;
        }

        static bool ConvertNumberToText(int num, out string result)
        {
            string tempString = "";
            int thousands;
            int temp;
            result = "";
            if (num < 0 || num > 100000)
            {
                System.Console.WriteLine(num + " \tNot Supported");
                return false;
            }

            if (num == 0)
            {
                System.Console.WriteLine(num + " \tZero");
                return false;
            }

            if (num < 1000)
            {
                HelperConvertNumberToText(num, out tempString);
                result += tempString;
            }
            else
            {
                thousands = num / 1000;
                temp = num - thousands * 1000;
                HelperConvertNumberToText(thousands, out tempString);
                result += tempString;
                result += "Thousand ";
                HelperConvertNumberToText(temp, out tempString);
                result += tempString;
            }
            return true;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
           
        }

        private void lblTotalAmount_TextChanged(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(lblTotalAmount.Text);

            int num2 = Convert.ToInt16(num);
            
            string result = string.Empty;
            //num = arrNum[i];
            if (ConvertNumberToText(num2, out result) == true)
            {
                lblWordsAmount.Text = result;
                lblWordsAmount.Text += " Rupees Only";
            }
        }
    }
}
