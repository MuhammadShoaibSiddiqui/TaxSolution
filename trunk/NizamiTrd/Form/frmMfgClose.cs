﻿using System;
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
using TaxSolution.Class;

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

namespace TaxSolution
{
    enum GColMfg
    {
        ItemID=0, 
        ItemName=1,
        UOMID=2,
        UOMName=3,
        QtyIn=4,
        QtyOut=5,
        TotalOutput=6,
        WstPAge=7,
        WstLessQty=8,
        WstableQty=9,
        WstQty=10,
        WOLabQty=11,
        LabChgableQty=12,
        LabRate=13,
        LabChg=14,
        MeshTotal=15,
        MeshRate=16,
        Amount=17
    }

    enum GColWaste
    {
        ItemID = 0,
        ItemName = 1,
        UOMID = 2,
        UOMName = 3,
        GodownID = 4,
        GodownName = 5,
        Qty = 6,
        Rate = 7,
        Bundle = 8,
        MeshTotal = 9,
        Amount = 10,
        isBundle = 11,
        isMesh = 12,
        Length = 13,
        LenDec = 14,
        Width = 15,
        WidDec = 16
    }

    public partial class frmMfgClose : Form
    {
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
        Int64 fFromGLGodownID = 0;
        Int64 fToGLGodownID = 0;
        int fDocTypeID = clsGVar.MFC;                         // Voucher/Doc Type ID
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

        public frmMfgClose()
        {
            InitializeComponent(); 
            btn_Save.Enabled = false;
            btn_Delete.Enabled = false;
            
            //frmLogin lgn = new frmLogin();
            //lgn.MdiParent = this;
            //lgn.Login = string.Empty;
            //lgn.Show();
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
            //frmLogin lgn = new frmLogin();
            //if (lgn.Login == string.Empty)
            //{
            //    this.Close();
            //}

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
            LoadInitialControlsWaste();
            btn_EnableDisable(true);
            sSMaster.Visible = false;
            msk_VocDate.Text = DateTime.Now.ToString();

            ButtonImageSetting();
            fFirstTableName = "cmn_Transport";
            fFirstKeyField = "Transport_ID";

            lSQL = "select * from " + fFirstTableName;
            lSQL += " order by Transport_Title";

            //clsFillCombo.FillCombo(cboTransport, clsGVar.ConString1, fFirstTableName + "," + fFirstKeyField + "," + "False", lSQL);
            //fcboDefaultValue = Convert.ToInt16(cboTransport.SelectedValue);

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

            //Item Group Combo Fill
            lSQL = "select * from " + "gds_Group";
            lSQL += " order by Group_title, ordering";

            clsFillComboSQL.FillComboWithQry(cboItemGroup, "gds_Group" + "," + "Group_ID" + "," + "False", lSQL, true, clsGVar.ConString1);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

            //Transaction Type Combo Fill
            lSQL = "select * from " + "cmn_TransType";
            lSQL += " order by ordering";

            clsFillCombo.FillCombo(cboTransType, clsGVar.ConString1, "cmn_TransType" + "," + "TransType_ID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboTransType.SelectedValue);

            clsFillCombo.FillCombo(cboTransTypeW, clsGVar.ConString1, "cmn_TransType" + "," + "TransType_ID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboTransTypeW.SelectedValue);

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
            grdVoucher.Rows.Clear();
            grdVoucher.Columns.Clear();

            List<string> lMask = null; //new List<string>;
            List<string> lCboFillType = null; //new List<string>;
            List<string> lCboTableKeyField = null; //new List<string>;
            List<string> lCboQry = null; //new List<string>;

            clsDbManager.SetGridHeaderCmb(
                grdVoucher,
                18,
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
            grdVoucher.Columns[(int)GColMfg.Amount].MinimumWidth = 100;

        }

        private void LoadInitialControlsWaste()
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
            grdWaste.Rows.Clear();
            grdWaste.Columns.Clear();

            string lHDRw = "";
            lHDRw += "ItemID";                       // 0-   Hiden
            lHDRw += ",Item Name";                      // 1-   Hiden
            lHDRw += ",UOM ID";                          // 2-   
            lHDRw += ",UOM Name";                          // 3-   
            lHDRw += ",Godown ID";                          // 4-   
            lHDRw += ",Godown Name";                          // 5-   
            lHDRw += ",Qty";                          // 6-   
            lHDRw += ",Rate";                          // 7-   
            lHDRw += ",Bundle";                          // 8-   
            lHDRw += ",Mesh Total";                          // 9-   
            lHDRw += ",Amount";                          // 10-   
            //lHDRw += ",is \n\r Bundle";                          // 11-   \n\r
            //lHDRw += ",is \n\r Mesh";                          // 12-   
            lHDRw += ",is Bundle";                          // 11-   \n\r
            lHDRw += ",is Mesh";                          // 12-   
            lHDRw += ",Length";                          // 13-   
            lHDRw += ",Len.Dec";                          // 14-   
            lHDRw += ",Width";                          // 15-   
            lHDRw += ",Wid.Dec";                          // 16-   
            //lHDRw += ",''";

            clsDbManager.SetGridHeaderCmb(
                grdWaste,
                17,
                lHDRw,
                " 8,25, 3, 7, 2,15,12,12, 7, 7,15, 4, 4, 7, 7, 7,20",
                " 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0",
                " 8,25, 3, 7, 2,15,12,12, 7, 7,15, 4, 4, 7, 7, 7,20",
                " T, T, H, T, H, T,N2,N2, H, H,N2, H, H, H, H, H, H",
                " 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1",
                "DATA",
                null,
                null,
                null,
                null,
                false,
                2);
            grdWaste.Columns[(int)GColWaste.WidDec].MinimumWidth = 20;
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
            msk_AccountIDDr.Mask = "#-#-##-##-####";
            msk_AccountIDDr.HidePromptOnLeave = true;
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

        private void SettingGridVariable()
        {
            string lHDR = "";                       // Column Header
            string lColWidth = "";                  // Column Width (Input)
            string lColMinWidth = "";               // Column Minimum Width
            string lColMaxInputLen = "";            // Column Visible Length/Width 
            string lColFormat = "";                 // Column Format  
            string lColReadOnly = "";               // Column ReadOnly 1 = ReadOnly, 0 = Read-Write  
            string lFieldList ="";
            string tColType = "";
            string tFieldName = "";

            //
            lFieldList = "ItemID";                  // 0-   ItemID=0, 
            lFieldList += ",ItemName";              // 1-   ItemName=1,
            lFieldList += ",UOMID";                 // 2-   UOMID=2,
            lFieldList += ",goodsuom_st";           // 3-   UOMName=3,
            //lFieldList += ",OpBalance";             // 4-   OpBal=4,
            lFieldList += ",Qty_In";                // 5-   QtyIn=5,
            lFieldList += ",Qty_Out";               // 6-   QtyOut=6,
            lFieldList += ",Balance";               // 7-   TotalOutput=7,
            lFieldList += ",WastePAge";             // 8-   WstPAge=8,
            lFieldList += ",WasteLessQty";          // 9-   WstLessQty=9,
            lFieldList += ",WasteableQty";          // 10   WstableQty=10,
            lFieldList += ",WasteQty";              // 11   WstQty=11,
            lFieldList += ",WithoutLabQty";         // 12   WOLabQty=12,
            lFieldList += ",LabCharge";             // 13   LabChgQty=13,
            lFieldList += ",LabourRate";            // 14   LabRate=14,
            lFieldList += ",LabCharges";            // 15   LabChg=15,
            lFieldList += ",MeshTotal";             // 16   MeshTotal=16,
            lFieldList += ",MeshRate";              // 17   MeshRate=17,
            lFieldList += ",Amount";                // 18   Amount=18

            lHDR += "ItemID";                       // 0-   ItemID=0, 
            lHDR += ",Item Name";                   // 1-   ItemName=1,
            lHDR += ",UOM ID";                      // 2-   UOMID=2,
            lHDR += ",UOM Name";                    // 3-   UOMName=3,
            lHDR += ",Qty In";                      // 5-   QtyIn=5,
            lHDR += ",Qty Out";                     // 6-   QtyOut=6,
            lHDR += ",Total Output";                // 7-   TotalOutput=7,
            lHDR += ",Waste%";                      // 8-   WstPAge=8,
            lHDR += ",Waste Less Qty";              // 9-   WstLessQty=9,
            lHDR += ",Wasteable Qty";               // 10   WstableQty=10,
            lHDR += ",Waste Qty";                   // 11   WstQty=11,
            lHDR += ",Without Labour Qty";          // 12   WOLabQty=12,
            lHDR += ",Labour Chargeable Qty";       // 13   LabChgQty=13,
            lHDR += ",Labour Rate";                 // 14   LabRate=14,
            lHDR += ",Labour Charges";              // 15   LabChg=15,
            lHDR += ",Mesh Total";                  // 16   MeshTotal=16,
            lHDR += ",Mesh Rate";                   // 17   MeshRate=17,
            lHDR += ",Amount";                      // 18   Amount=18

            // Col Visible Width
            lColWidth = "   5";                        // 0-   ItemID=0, 
            lColWidth += ",12";                        // 1-   ItemName=1,
            lColWidth += ", 3";                        // 2-   UOMID=2,
            lColWidth += ", 7";                        // 3-   UOMName=3,
            //lColWidth += ", 7";                        // 4-   OpBal=4,
            lColWidth += ", 7";                        // 5-   QtyIn=5,
            lColWidth += ", 7";                        // 6-   QtyOut=6,
            lColWidth += ", 7";                        // 7-   TotalOutput=7,
            lColWidth += ", 7";                        // 8-  "WstPAge=8,
            lColWidth += ", 7";                        // 9-   WstLessQty=9,
            lColWidth += ", 7";                        // 10-  WstableQty=10,
            lColWidth += ", 7";                        // 11-  WstQty=11,
            lColWidth += ", 7";                        // 12-  WOLabQty=12,
            lColWidth += ", 7";                        // 13-  LabChgQty=13,
            lColWidth += ", 7";                        // 14-  LabRate=14,
            lColWidth += ", 7";                        // 15-  LabChg=15,
            lColWidth += ", 7";                        // 16-  MeshTotal=16,
            lColWidth += ", 7";                        // 17-  MeshRate=17,
            lColWidth += ",30";                        // 18-  Amount=18

            // Column Input Length/Width
            lColMaxInputLen = "  0";                    // 0-  ItemID=0, 
            lColMaxInputLen += ", 0";                    // 1-  ItemName=1,
            lColMaxInputLen += ", 0";                    // 2-  UOMID=2,
            lColMaxInputLen += ", 0";                    // 3-  UOMName=3,
            //lColMaxInputLen += ", 0";                    // 4-  OpBal=4,
            lColMaxInputLen += ", 0";                    // 5-  QtyIn=5,
            lColMaxInputLen += ", 0";                    // 6-  QtyOut=6,
            lColMaxInputLen += ", 0";                    // 7-  TotalOutput=7,
            lColMaxInputLen += ", 0";                    // 8-  WstPAge=8,
            lColMaxInputLen += ", 0";                    // 9-  WstLessQty=9,
            lColMaxInputLen += ", 0";                    // 10- WstableQty=10,
            lColMaxInputLen += ", 0";                    // 11- WstQty=11,
            lColMaxInputLen += ", 0";                    // 12- WOLabQty=12,
            lColMaxInputLen += ", 0";                    // 13- LabChgQty=13,
            lColMaxInputLen += ", 0";                    // 14- LabRate=14,
            lColMaxInputLen += ", 0";                    // 15- LabChg=15,
            lColMaxInputLen += ", 0";                    // 16- MeshTotal=16,
            lColMaxInputLen += ", 0";                    // 17- MeshRate=17,
            lColMaxInputLen += ", 0";                    // 18- Amount=18

            // Column Min Width
            lColMinWidth = "   0";                      // 0-   ItemID=0, 
            lColMinWidth += ", 0";                      // 1-   ItemName=1,
            lColMinWidth += ", 0";                      // 2-   UOMID=2,
            lColMinWidth += ", 0";                      // 3-   UOMName=3,
            //lColMinWidth += ", 0";                      // 4-   OpBal=4,
            lColMinWidth += ", 0";                      // 5-   QtyIn=5,
            lColMinWidth += ", 0";                      // 6-   QtyOut=6,
            lColMinWidth += ", 0";                      // 7-   TotalOutput=7,
            lColMinWidth += ", 0";                      // 8-  "WstPAge=8,
            lColMinWidth += ", 0";                      // 9-   WstLessQty=9,
            lColMinWidth += ", 0";                      // 10-  WstableQty=10,
            lColMinWidth += ", 0";                      // 11-  WstQty=11,
            lColMinWidth += ", 0";                      // 12-  WOLabQty=12,
            lColMinWidth += ", 0";                      // 13-  LabChgQty=13,
            lColMinWidth += ", 0";                      // 14-  LabRate=14,
            lColMinWidth += ", 0";                      // 15-  LabChg=15,
            lColMinWidth += ", 0";                      // 16-  MeshTotal=16,
            lColMinWidth += ", 0";                      // 17-  MeshRate=17,
            lColMinWidth += ",30";                      // 18-  Amount=18

            // Column Format
            lColFormat = "  T";                        // 0-    ItemID=0, 
            lColFormat += ", T";                        // 1-    ItemName=1,
            lColFormat += ", H";                        // 2-    UOMID=2,
            lColFormat += ", T";                        // 3-    UOMName=3,
            //lColFormat += ",N2";                        // 4--   OpBal=4,
            lColFormat += ",N2";                        // 5--   QtyIn=5,
            lColFormat += ",N2";                        // 6--   QtyOut=6,
            lColFormat += ",N2";                        // 7--   TotalOutput=7,
            lColFormat += ",N2";                        // 8--  "WstPAge=8,
            lColFormat += ",N2";                        // 9--   WstLessQty=9,
            lColFormat += ",N2";                        // 10-   WstableQty=10,
            lColFormat += ",N2";                        // 11-   WstQty=11,
            lColFormat += ",N2";                        // 12-   WOLabQty=12,
            lColFormat += ",N2";                        // 13-   LabChgQty=13,
            lColFormat += ",N2";                        // 14-   LabRate=14,
            lColFormat += ",N2";                        // 15-   LabChg=15,
            lColFormat += ",N2";                        // 16-   MeshTotal=16,
            lColFormat += ",N2";                        // 17-   MeshRate=17,
            lColFormat += ",N2";                        // 18-   Amount=18

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  1";                       // 0-    ItemID=0, 
            lColReadOnly += ",1";                       // 1-    ItemName=1,
            lColReadOnly += ",1";                       // 2-    UOMID=2,
            lColReadOnly += ",1";                       // 3-    UOMName=3,
            //lColReadOnly += ",1";                     // 4-    OpBal=4,
            lColReadOnly += ",1";                       // 5-    QtyIn=5,
            lColReadOnly += ",1";                       // 6-    QtyOut=6,
            lColReadOnly += ",1";                       // 7-    TotalOutput=7,
            lColReadOnly += ",0";                       // 8-  ""WstPAge=8,
            lColReadOnly += ",0";                       // 9-    WstLessQty=9,
            lColReadOnly += ",0";                       // 10-   WstableQty=10,
            lColReadOnly += ",0";                       // 11-   WstQty=11,
            lColReadOnly += ",0";                       // 12-   WOLabQty=12,
            lColReadOnly += ",1";                       // 13-   LabChgQty=13,
            lColReadOnly += ",0";                       // 14-   LabRate=14,
            lColReadOnly += ",0";                       // 15-   LabChg=15,
            lColReadOnly += ",0";                       // 16-   MeshTotal=16,
            lColReadOnly += ",0";                       // 17-   MeshRate=17,
            lColReadOnly += ",1";                       // 18-   Amount=18

            // For Saving Time
            tColType += "  N0";  //0        ItemID=0, 
            tColType += ", SKP";  //1        ItemName=1,
            tColType += ", N0";  //2        UOMID=2,
            tColType += ", SKP"; //3        UOMName=3,
            //tColType += ", N0";  //4        OpBal=4,
            tColType += ", N2"; //5        QtyIn=5,
            tColType += ", N2";  //6        QtyOut=6,
            tColType += ", N2";  //7        TotalOutput=7,
            tColType += ", N2";  //8        WstPAge=8,
            tColType += ", N2";  //9        WstLessQty=9,
            tColType += ", N2"; //10       WstableQty=10,
            tColType += ", N2";  //11       WstQty=11,
            tColType += ", N2";  //12       WOLabQty=12,
            tColType += ", N2";  //13       LabChgQty=13,
            tColType += ", N2";  //14       LabRate=14,
            tColType += ", N2";  //15       LabChg=15,
            tColType += ", N2";  //16       MeshTotal=16,
            tColType += ", N2";  //17        MeshRate=17,
            tColType += ", N2";  //18        Amount=18

            tFieldName += "ItemID";           //0      ItemID=0, 
            tFieldName += ",'' as Skp1";        //1       ItemName=1,
            tFieldName += ",UOMID";           //2      UOMID=2,
            tFieldName += ",'' as Skp1";     //3      UOMName=3,
            //tFieldName += ",OpBalance";       //4        OpBal=4,
            tFieldName += ",Qty_In";          //5     QtyIn=5,
            tFieldName += ",Qty_Out";         //6      QtyOut=6,
            tFieldName += ",Balance";         //7      TotalOutput=7,
            tFieldName += ",WastePAge";       //8      WstPAge=8,
            tFieldName += ",WasteLessQty";    //9      WstLessQty=9,
            tFieldName += ",WasteableQty";    //10    WstableQty=10,
            tFieldName += ",WasteQty";        //11     WstQty=11,
            tFieldName += ",WithoutLabQty";   //12     WOLabQty=12,
            tFieldName += ",LabCharge";       //13     LabChgQty=13,
            tFieldName += ",LabourRate";      //14     LabRate=14,
            tFieldName += ",LabCharges";      //15     LabChg=15,
            tFieldName += ",MeshTotal";       //16     MeshTotal=16,
            tFieldName += ",MeshRate";        //17      MeshRate=17,
            tFieldName += ",Amount";          //18      Amount=18


            fHDR = lHDR;
            fColWidth= lColWidth;
            fColMaxInputLen = lColMaxInputLen;
            fColMinWidth = lColMinWidth;
            fColFormat = lColFormat;
            fColReadOnly = lColReadOnly;
            fFieldList = lFieldList;

            fColType = tColType;
            fFieldName = tFieldName;
            
            //lMask = null;
            //lCboFillType = null;
            //lCboTableKeyField = null;
            //lCboQry = null;         
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
                 "a.istran = 1 and a.ac_id IN (SELECT Godown_ac_id FROM cmn_Godown)"
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
             msk_AccountIDDr.Text = string.Empty;
             sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
             sForm.ShowDialog();
             if (msk_AccountIDDr.Text != null)
             {
                 if (msk_AccountIDDr.Text != null)
                 {
                     if (msk_AccountIDDr.Text.ToString() == "" || msk_AccountIDDr.Text.ToString() == string.Empty)
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
            msk_AccountIDDr.Text = ((MaskedTextBox)sender).Text;
        }
        //
        private void PassDataVocID(object sender)
        {
            lblDocID.Text = ((TextBox)sender).Text;
        }

        private void PassDataContLabChgID(object sender)
        {
            txtLabourContract.Tag = ((TextBox)sender).Text;
            //txtLabourContract.Text = ((TextBox)sender).Text;
        }

        private void PassDataGLIDCr(object sender)
        {
            msk_AccountIDCr.Text = ((MaskedTextBox)sender).Text;
        }

        private void msk_AccountID_Leave(object sender, EventArgs e)
        {
            if (msk_AccountIDDr.Text.ToString().Trim('_', ' ', '-') == "")
            {
                MessageBox.Show("GL Code is Empty! Unable to Process...", this.Text.ToString());
                msk_AccountIDDr.Focus();
            }

            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  
            tSQL = "Select top 1 ac_title, ac_id, ac_strid from gl_ac Where ";
            tSQL += " ac_strid = '" + msk_AccountIDDr.Text + "';";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "gl_Ac");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblAccountNameDr.Text = dRow.ItemArray.GetValue(0).ToString();
                    msk_AccountIDDr.Tag=dRow.ItemArray.GetValue(1).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();
                }
                else
                {
                    MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                    msk_AccountIDDr.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                msk_AccountIDDr.Focus();
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
            tSQL += " AND GodownID=" + cboGodown.SelectedValue.ToString();

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

                    //cbo_UOM.SelectedIndex = ClassSetCombo.Set_ComboBox(cbo_UOM, int_UOMID);
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
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
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
                grdWaste.Rows.Add(txtItemID.Text.ToString(),
                    lblItemName.Text, 
                    cbo_UOM.SelectedValue.ToString(),
                    cbo_UOM.Text,
                    cboGodown.SelectedValue.ToString(),
                    cboGodown.Text,
                    txtQty.Text.ToString(),
                    txtRate.Text.ToString(),
                    (txtBundle.Text == "" ? "1" : txtBundle.Text).ToString(),
                    lblTotalMeasure.Text.ToString(),
                    lblAmount.Text.ToString(),
                    (chk_BundleCalc.Checked == true ? 1 : 0),
                    (chk_Mesh.Checked == true ? 1 : 0), 
                    txtLength.Text.ToString(),
                    txtLenDec.Text.ToString(),
                    txtWidth.Text.ToString(),
                    txtWidDec.Text.ToString()
                    );
                //lblAcID.Text,
                //ClearSub_Add_Btn();
            }
            else if (btn_Add.Text.ToString() == "&Update")
            {
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.ItemID].Value = txtItemID.Text;
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.ItemName].Value = lblItemName.Text;
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.UOMID].Value = cbo_UOM.SelectedValue.ToString();
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.UOMName].Value = cbo_UOM.Text;
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.GodownID].Value = cboGodown.SelectedValue.ToString();
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.GodownName].Value = cboGodown.Text;

                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Qty].Value = txtQty.Text.ToString();
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Rate].Value = txtRate.Text.ToString();
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Bundle].Value = txtBundle.Text.ToString();
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.MeshTotal].Value = lblTotalMeasure.Text.ToString();
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Amount].Value = lblAmount.Text.ToString();

                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Length].Value = txtLength.Text.ToString();
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.LenDec].Value = txtLenDec.Text.ToString();
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Width].Value = txtWidth.Text.ToString();
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.WidDec].Value = txtWidDec.Text.ToString();
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.isBundle].Value = (chk_BundleCalc.Checked == true ? 1 : 0);
                grdWaste.Rows[fEditRow].Cells[(int)GColWaste.isMesh].Value = (chk_Mesh.Checked == true ? 1 : 0);

                btn_Add.Text = "&Add";
                this.tabControl1.SelectedTab = this.tabControl1.TabPages["Transaction"];

            }
            ClearSub_Add_Btn();

            btn_EnableDisable(true);
            grdWaste.Visible = false;
            SumWaste();
            grdWaste.Visible = true;
            grdWaste.Focus();

        }

        private void SumVoc()
        {
            //bool bcheck;
            decimal fLabChges = 0;
            decimal fWasteQty =0;
            decimal fWasteableQty = 0;
            decimal fTotalAmount = 0;

            decimal fTotalQtyIn = 0;
            decimal fTotalQtyOut = 0;
            decimal fTotalBal = 0;

            for (int i = 0; i < grdVoucher.RowCount; i++)
            {
                grdVoucher.Rows[i].Cells[(int)GColMfg.WstableQty].Value =
                    clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.TotalOutput].Value.ToString())
                    - clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.WstLessQty].Value.ToString());

                grdVoucher.Rows[i].Cells[(int)GColMfg.WstQty].Value =
                    (clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.WstableQty].Value.ToString())
                    * clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.WstPAge].Value.ToString()))/100;

                grdVoucher.Rows[i].Cells[(int)GColMfg.LabChgableQty].Value =
                    clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.TotalOutput].Value.ToString())
                    - clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.WOLabQty].Value.ToString());

                grdVoucher.Rows[i].Cells[(int)GColMfg.LabChg].Value =
                    clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.LabRate].Value.ToString())
                    * clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.LabChgableQty].Value.ToString());

                grdVoucher.Rows[i].Cells[(int)GColMfg.Amount].Value =
                    clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.MeshRate].Value.ToString())
                    * clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.MeshTotal].Value.ToString());

                fWasteQty += clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.WstQty].Value.ToString());
                fWasteableQty += clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.WstableQty].Value.ToString());
                fLabChges += clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.LabChg].Value.ToString());
                fTotalAmount += clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.Amount].Value.ToString());

                fTotalQtyIn += clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.QtyIn].Value.ToString());
                fTotalQtyOut += clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.QtyOut].Value.ToString());
                fTotalBal += clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.TotalOutput].Value.ToString());
                if (clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.LabRate].Value.ToString()) == 0)
                {
                    //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
                    grdVoucher.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //grdVoucher.DefaultCellStyle.BackColor = Color.Red;
                }
                //* (clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.Width].Value.ToString())
                // + ((clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.WidDec].Value.ToString())) * clsDbManager.ConvDecimal("0.0833")))
                //* (clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.Length].Value.ToString())
                // + ((clsDbManager.ConvDecimal(grdVoucher.Rows[i].Cells[(int)GColMfg.LenDec].Value.ToString())) * clsDbManager.ConvDecimal("0.0833")))
                //;
            }

            lblTotalAmountMesh.Text = String.Format("{0:0,0.00}", fTotalAmount);
            lblTotalAmount.Text = String.Format("{0:0,0.00}", fLabChges);
            lblWasteQty.Text = String.Format("{0:0,0.00}", fWasteQty);
            lblWasteableQty.Text = String.Format("{0:0,0.00}", fWasteableQty);
            lblTotalQtyIn.Text = String.Format("{0:0,0.00}", fTotalQtyIn);
            lblTotalQtyOut.Text = String.Format("{0:0,0.00}", fTotalQtyOut);
            lblTotalBal.Text = String.Format("{0:0,0.00}", fTotalBal);

        }

        private void SumWaste()
        {
            bool bcheck;
            decimal fTotalQty = 0;
            decimal fTotalAmount = 0;
            decimal rtnVal = 0;
            decimal outValue = 0;
            //decimal outRate =0;
            string str_IsBundle = string.Empty;
            string str_IsMesh = string.Empty;

            for (int i = 0; i < grdWaste.RowCount; i++)
            {
                // isBundle Check
                if (grdWaste.Rows[i].Cells[(int)GColWaste.isBundle].Value == null)
                {
                    str_IsBundle = clsDbManager.ConvBit("False");
                }
                else
                {
                    str_IsBundle = clsDbManager.ConvBit(grdWaste.Rows[i].Cells[(int)GColWaste.isBundle].Value.ToString());
                }

                // isMesh Check
                if (grdWaste.Rows[i].Cells[(int)GColWaste.isMesh].Value == null)
                {
                    str_IsMesh = clsDbManager.ConvBit("False");
                }
                else
                {
                    str_IsMesh = clsDbManager.ConvBit(grdWaste.Rows[i].Cells[(int)GColWaste.isMesh].Value.ToString());
                }

                if (str_IsBundle == "1")
                {
                    grdWaste.Rows[i].Cells[(int)GColWaste.Amount].Value =
                        clsDbManager.ConvDecimal(grdWaste.Rows[i].Cells[(int)GColWaste.Rate].Value.ToString())
                        * clsDbManager.ConvDecimal(grdWaste.Rows[i].Cells[(int)GColWaste.Bundle].Value.ToString());
                }

                if (str_IsMesh == "1")
                {
                    grdWaste.Rows[i].Cells[(int)GColWaste.Amount].Value =
                        clsDbManager.ConvDecimal(grdWaste.Rows[i].Cells[(int)GColWaste.Rate].Value.ToString())
                        * clsDbManager.ConvDecimal(grdWaste.Rows[i].Cells[(int)GColWaste.Bundle].Value.ToString())
                        * (clsDbManager.ConvDecimal(grdWaste.Rows[i].Cells[(int)GColWaste.Width].Value.ToString())
                         + ((clsDbManager.ConvDecimal(grdWaste.Rows[i].Cells[(int)GColWaste.WidDec].Value.ToString())) * clsDbManager.ConvDecimal("0.0833")))
                        * (clsDbManager.ConvDecimal(grdWaste.Rows[i].Cells[(int)GColWaste.Length].Value.ToString())
                         + ((clsDbManager.ConvDecimal(grdWaste.Rows[i].Cells[(int)GColWaste.LenDec].Value.ToString())) * clsDbManager.ConvDecimal("0.0833")))
                        ;


                    //float fLength;
                    //float fWidth;
                    //fLength = float.Parse(txtLenDec.Text);

                    //fLength = float.Parse(txtLength.Text) + ((float.Parse(txtLenDec.Text) * 0.0833f));
                    //fWidth = float.Parse(txtWidth.Text) + ((float.Parse(txtWidDec.Text) * 0.0833f));
                    //lblTotalMeasure.Text = ((fLength * fWidth) * int.Parse(txtBundle.Text)).ToString();
                    //lblAmount.Text = (float.Parse(lblTotalMeasure.Text) * float.Parse(txtRate.Text)).ToString();

                }

                if (str_IsBundle == "0" && str_IsMesh == "0")
                {
                    grdWaste.Rows[i].Cells[(int)GColWaste.Amount].Value =
                        clsDbManager.ConvDecimal(grdWaste.Rows[i].Cells[(int)GColWaste.Rate].Value.ToString())
                        * clsDbManager.ConvDecimal(grdWaste.Rows[i].Cells[(int)GColWaste.Qty].Value.ToString());
                    //* Convert.ToDecimal(grdWaste.Rows[i].Cells[(int)GColInv.Bundle].Value);
                }

                //if (grdWaste.Rows[i].Cells[(int)GColInv.isBundle].Value.GetType = checked)
                //{
                //    bcheck= decimal.TryParse(grdWaste.Rows[i].Cells[(int)GColInv.Rate].Value, out outValue);

                //    grdWaste.Rows[i].Cells[(int)GColInv.Amount].Value = 
                //        decimal.TryParse(grdWaste.Rows[i].Cells[(int)GColInv.Rate].Value, outValue) 
                //        * decimal.TryParse(grdWaste.Rows[i].Cells[(int)GColInv.Bundle].Value, outValue);
                //}

                if (grdWaste.Rows[i].Cells[(int)GColWaste.Amount].Value != null)
                {
                    bcheck = decimal.TryParse(grdWaste.Rows[i].Cells[(int)GColWaste.Amount].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fTotalAmount += outValue;
                        fTotalQty += clsDbManager.ConvDecimal(grdWaste.Rows[i].Cells[(int)GColWaste.Qty].Value.ToString());
                    }
                }
                //grdWaste[2, i].Value = (i + 1).ToString();
            }

            lblTotalAmountWaste.Text = String.Format("{0:0,0.00}", fTotalAmount);
            lblTotalQtyWaste.Text = String.Format("{0:0,0.00}", fTotalQty);
        }

        private void GodownSetting(Int64 pGodown_ID = 0)
        {

            for (int i = 0; i < grdVoucher.RowCount; i++)
            {
                    //grdVoucher.Rows[i].Cells[(int)GColMfg.GodownID].Value = pGodown_ID;
            }
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
                fTNOT = GridTNOT(grdVoucher);
                if (!PrepareDocMaster())
                {
                    //textAlert.Text = "DocMaster: Modifying Doc/Voucher not available for updation.'  ...." + "  " + lNow.ToString();
                    //tabMDtl.SelectedTab = tabError;
                    return false;
                }
                //
                if (grdVoucher.Rows.Count > 0)
                {
                    // Prepare Detail Doc Query List

                    //GodownSetting(fToGLGodownID);
                    //if (!PrepareDocDetailIn())
                    //{
                    //    return false;
                    //}

                    //GodownSetting(fFromGLGodownID);
                    if (!PrepareDocDetail())
                    {
                        return false;
                    }

                    if (!PrepareDocGLDetail())
                    {
                        return false;
                    }

                    //if (!PrepareDocGLWasteDetail())
                    //{
                    //    return false;
                    //}

                    if (!PrepareDocWasteDetail())
                    {
                        return false;
                    }
                    //if (!PrepareDocWasteDetailIn())
                    //{
                    //    return false;
                    //}

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
            fDocAmt = clsDbManager.ConvDecimal(lblTotalAmountMesh.Text);
            //string str_CreditPurcCode = string.Empty;

            try
            {
                string lDocDateStr = StrF01.D2Str(msk_VocDate);
                DateTime lDocDate = DateTime.Parse(lDocDateStr);
                //str_CreditPurcCode = clsDbManager.GetConfigCode("cmn_Config", "CreditPurcID", "", "");

                fFromGLGodownID = clsDbManager.GetValDocID("cmn_Godown", "Godown_id", "Godown_Ac_ID=" + msk_AccountIDDr.Tag.ToString(), "");
                fToGLGodownID = clsDbManager.GetValDocID("cmn_Godown", "Godown_id", "Godown_Ac_ID=" + msk_AccountIDCr.Tag.ToString(), "");

                if (lblDocID.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocWhere = " doc_vt_id=" + fDocTypeID.ToString();
                    fDocWhere += " and doc_fiscal_id=1 ";

                    //fDocAmt = decimal.Parse(lblTotalDr.Text.ToString());
                    //fDocID = clsDbManager.GetNextValDocID("gl_tran", "doc_id", NewDocWhere(), "");
                    fDocID = clsDbManager.GetNextValDocID("Mfg_tran", "doc_id", fDocWhere, "");

                    lblDocID.Text = fDocID.ToString();
                    //
                    lSQL = "insert into gl_tran (";
                    lSQL += "  doc_vt_id";                                         // 1-
                    lSQL += ", doc_fiscal_id ";                                     // 2-
                    lSQL += ", doc_ID";                                            // 3-
                    lSQL += ", doc_StrID";                                         // 4-
                    lSQL += ", doc_date";                                          // 5-
                    lSQL += ", GLID";                                          // 6-
                    lSQL += ", GLID_Cr";                                          // 6-
                    lSQL += ", doc_tnot";                                          // 6-
                    lSQL += ", doc_remarks";                                       // 7-
                    lSQL += ", doc_amt";                                           // 8-
                    lSQL += ", doc_status";                                        // 7-

                    lSQL += ", created_by";                                        // 8-
                    //lSQL += ", modified_by ";                                    // 9-
                    lSQL += ", created_date";                                      // 10-
                    //lSQL += ", modified_date  ";                                 // 11-
                    lSQL += " ) values (";
                    //
                    lSQL += fDocTypeID.ToString();                                 // JVR = 267, CRV=268
                    lSQL += ", " + fDocFiscal.ToString();                           // 3-
                    lSQL += ", " + fDocID.ToString() + "";                          // 4-
                    lSQL += ",'" + StrF01.EnEpos(txtManualDoc.Text) + "'";          // 5-
                    lSQL += ",'" + StrF01.D2Str(msk_VocDate) + "'";                 // 6-
                    lSQL += ", " + msk_AccountIDDr.Tag;                             // 7- 
                    lSQL += ", " + msk_AccountIDCr.Tag;                             // 7- 
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
                    lSQL = "insert into Mfg_tran (";
                    lSQL += "  doc_vt_id ";                                         // 1-
                    lSQL += ", doc_fiscal_id ";                                     // 2-
                    lSQL += ", doc_ID ";                                            // 3-
                    lSQL += ", doc_StrID ";                                         // 4-
                    lSQL += ", doc_date ";                                          // 5-
                    lSQL += ", GLID ";                                          // 6-
                    lSQL += ", GLID_Cr ";                                          // 6-
                    lSQL += ", GLID_Dr_Waste ";                                          // 6-
                    lSQL += ", GLID_Cr_Waste";                                          // 6-

                    lSQL += ", ContractID ";                                          // 6-
                    lSQL += ", ContractNo ";                                          // 6-
                    lSQL += ", ContractStatType ";                                          // 6-
                    lSQL += ", ContractNoWaste ";                                          // 6-
                    lSQL += ", ContractStatTypeWaste ";                                         // 6-
                    lSQL += ", doc_tnot ";                                          // 6-
                    lSQL += ", doc_remarks ";                                       // 7-
                    lSQL += ", doc_amt ";                                           // 8-

                    lSQL += ", doc_status ";                                        // 7-
                    lSQL += ", GodownID";                                        // 7-
                    lSQL += ", FromDate";                                        // 7-
                    lSQL += ", ToDate";                                        // 7-
                    lSQL += ", ItemGroupID";                                        // 7-
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
                    lSQL += ", " + msk_AccountIDDr.Tag;                             // 7- 
                    lSQL += ", " + msk_AccountIDCr.Tag;                             // 7- 
                    lSQL += ", " + msk_WasteDr.Tag;                             // 7- 
                    lSQL += ", " + msk_WasteCr.Tag;                             // 7- 
                    lSQL += ", " + txtLabourContract.Tag;                             // 7- 

                    lSQL += ",'" + StrF01.EnEpos(txtLabourContract.Text) + "'";                 // 6-
                    lSQL += ", " + cboTransType.SelectedValue.ToString();                              // 9-
                    lSQL += ",'" + StrF01.EnEpos(txtWasteContract.Text) + "'";                 // 6-
                    lSQL += ", " + cboTransTypeW.SelectedValue.ToString();                              // 9-
                    lSQL += ", " + fTNOT;                                           // 7- 
                    lSQL += ",'" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'"; // 8-
                    lSQL += ", " + fDocAmt.ToString();                              // 9-
                    lSQL += ", 1";                              // 13- Doc Status 

                    lSQL += ", " + cboGodown.SelectedValue.ToString() + ""; // 8-
                    lSQL += ",'" + StrF01.D2Str(msk_FromDate) + "'"; // 8-
                    lSQL += ",'" + StrF01.D2Str(msk_ToDate) + "'"; // 8-
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString();                              // 9-
                    lSQL += ", " + (chk_ShowRpt.Checked == true ? 1 : 0);                              // 9-
                    lSQL += ", " + (chk_CalcRpt.Checked == true ? 1 : 0);                              // 9-

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
                    lSQL += ", GLID_Cr ";                                          // 6-
                    lSQL += ", ContractNo ";                                          // 6-
                    lSQL += ", doc_tnot ";                                          // 6-
                    lSQL += ", doc_remarks ";                                       // 7-
                    lSQL += ", doc_amt ";                                           // 8-

                    lSQL += ", doc_status ";                                        // 7-
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
                    lSQL += ", " + msk_WasteDr.Tag;                             // 7- 
                    lSQL += ", " + msk_WasteCr.Tag;                             // 7- 
                    lSQL += ",'" + StrF01.EnEpos(txtLabourContract.Text) + "'";                 // 6-
                    lSQL += ", " + fTNOT;                                           // 7- 
                    lSQL += ",'" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'"; // 8-
                    lSQL += ", " + fDocAmt.ToString();                              // 9-
                    lSQL += ", 1";                              // 13- Doc Status 

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
                    fDocWhere += " AND doc_Fiscal_ID = " + fDocFiscal.ToString();
                    fDocWhere += " AND Doc_ID = " + String.Format("{0,0}", lblDocID.Text.ToString());
                    //if (clsDbManager.IDAlreadyExistWw("gl_tran", "doc_id", DocWhere("")))
                    if (clsDbManager.IDAlreadyExistWw("Mfg_tran", "doc_id", fDocWhere))
                    {
                        fDocAlreadyExists = true;
                        lSQL = "delete from gl_trandtl ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                        lSQL = "delete from Mfg_trandtl ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);

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

                        lSQL += ", GLID = " + msk_AccountIDDr.Tag;                                         // 10-
                        lSQL += ", GLID_Cr = " + msk_AccountIDCr.Tag;                                         // 10-
                        //lSQL += ", ContractNo = '" + txtContract.Text.ToString() + "'";                   // 9-
                        lSQL += ", doc_tnot = " + fTNOT.ToString();                                       // 10-
                        lSQL += ", doc_remarks = '" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'";    // 12-
                        lSQL += ", doc_amt = " + fDocAmt.ToString();                                // 13-
                        lSQL += ", modified_by = " + clsGVar.AppUserID.ToString();                  // 16-
                        lSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";     // 18-
                        lSQL += " where ";
                        lSQL += fDocWhere;

                        fManySQL.Add(lSQL);

                        lSQL = "update Mfg_tran set";
                        lSQL += "  doc_date = '" + StrF01.D2Str(msk_VocDate) + "'";                       // 9-
                        lSQL += ", doc_strid = '" + txtManualDoc.Text.ToString() + "'";                   // 9-

                        lSQL += ", GLID = " + msk_AccountIDDr.Tag;                                         // 10-
                        lSQL += ", GLID_Cr = " + msk_AccountIDCr.Tag;                                         // 10-
                        lSQL += ", GLID_Dr_Waste = " + msk_WasteDr.Tag;                                         // 10-
                        lSQL += ", GLID_Cr_Waste = " + msk_WasteCr.Tag;                                         // 10-

                        lSQL += ", ContractID = " + txtLabourContract.Tag;                                         // 10-
                        lSQL += ", ContractNo = '" + txtLabourContract.Text.ToString() + "'";                   // 9-
                        lSQL += ", ContractNoWaste = '" + txtWasteContract.Text.ToString() + "'";                   // 9-
                        lSQL += ", ContractStatType = " + cboTransType.SelectedValue.ToString() + "";                   // 9-
                        lSQL += ", ContractStatTypeWaste = " + cboTransTypeW.SelectedValue.ToString() + "";                   // 9-
                        lSQL += ", doc_tnot = " + fTNOT.ToString();                                       // 10-
                        lSQL += ", doc_remarks = '" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'";    // 12-
                        lSQL += ", doc_amt = " + fDocAmt.ToString();                                // 13-

                        lSQL += ", GodownID = " + cboGodown.SelectedValue.ToString() + "";
                        lSQL += ", FromDate = '" + StrF01.D2Str(msk_FromDate) + "'";
                        lSQL += ", ToDate = '" + StrF01.D2Str(msk_ToDate)  + "'";
                        lSQL += ", ItemGroupID = " + cboItemGroup.SelectedValue.ToString();
                        lSQL += ", isShowRpt = " + (chk_ShowRpt.Checked == true ? 1 : 0);
                        lSQL += ", isCalcRpt = " + (chk_CalcRpt.Checked == true ? 1 : 0); 

                        lSQL += ", modified_by = " + clsGVar.AppUserID.ToString();                  // 16-
                        lSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";     // 18-
                        lSQL += " where ";
                        lSQL += fDocWhere;
                        //
                        fManySQL.Add(lSQL);
// Invoice Data Update
                        lSQL = "update Inv_tran set";
                        lSQL += "  doc_date = '" + StrF01.D2Str(msk_VocDate) + "'";                       // 9-
                        lSQL += ", doc_strid = '" + txtManualDoc.Text.ToString() + "'";                   // 9-

                        lSQL += ", GLID = " + msk_WasteDr.Tag;                                         // 10-
                        lSQL += ", ContractNo = '" + txtLabourContract.Text.ToString() + "'";                   // 9-
                        lSQL += ", doc_tnot = " + fTNOT.ToString();                                       // 10-
                        lSQL += ", doc_remarks = '" + StrF01.EnEpos(txtRemarks.Text.ToString()) + "'";    // 12-
                        lSQL += ", doc_amt = " + fDocAmt.ToString();                                // 13-

                        lSQL += ", isShowRpt = " + (chk_ShowRpt.Checked == true ? 1 : 0);
                        lSQL += ", isCalcRpt = " + (chk_CalcRpt.Checked == true ? 1 : 0);

                        lSQL += ", modified_by = " + clsGVar.AppUserID.ToString();                  // 16-
                        lSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";     // 18-
                        lSQL += " where ";
                        lSQL += fDocWhere;
                        //
                        fManySQL.Add(lSQL);
                    }
                }

                if (grdVoucher.Rows.Count > 0)
                {
                    //Prepare_GL_Trans();
                    //PrepareDocGLDetail();
                }

                // 2nd GL Transaction
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
                //lSQL += ", " + msk_AccountIDDr.Tag;
                ////lSQL += ", " + clsDbManager.ConvInt(str_CreditPurcCode); 
                ////                                                                                       // 5- Ac Title NA
                //lSQL += ", '" + StrF01.EnEpos(lblAccountNameDr.Text) + "'";      // 8- Narration 
                //lSQL += ", " + clsDbManager.ConvDecimal(lblTotalAmount.Text);           // 9- Debit. 
                //lSQL += ", " + 0;           // 10- Credit

                //lSQL += ", " + 0;          // 11- Combo 1 
                //lSQL += ", 0"; //is Checked
                //lSQL += ")";

                ////
                //fManySQL.Add(lSQL);

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

        private bool PrepareDocGLDetail()
        {
            bool rtnValue = true;
            string lSQL = "";
            //Int64 lAcID = 0;
            try
            {
                //
                for (int dGVRow = 0; dGVRow < grdVoucher.Rows.Count; dGVRow++)
                {
                    if (clsDbManager.ConvDecimal(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString()) != 0)
                    {
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
                        lSQL += " " + fDocTypeID.ToString();                                                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                        lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
                        lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
                        //
                        lSQL += ", " + msk_AccountIDDr.Tag;                     // 2- Serial Order replaced with SNo. 
                        //                                                                                       // 5- Ac Title NA
                        lSQL += ", '" + StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.ItemName].Value.ToString()) 
                             + " Qty: " + StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChgableQty].Value.ToString())
                            + "@" + String.Format("{0:0,0.00}", grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabRate].Value)
                            + "'";      // 8- Narration 
                        //+ "@" + String.Format("{0:0,0.00}", StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabRate].Value.ToString()))
                        //String.Format("{0:0,0.00}", fLabChges);
                        if (clsDbManager.ConvDecimal(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString()) > 0)
                        {
                            lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString();           // 9- Debit. 
                            lSQL += ", 0";          // 10- Credit
                        }
                        if (clsDbManager.ConvDecimal(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString()) < 0)
                        {
                            lSQL += ", 0";            // 9- Debit. 
                            lSQL += ", " + Math.Abs(clsDbManager.ConvDecimal(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString()));  //grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString();           // 10- Credit
                        }
                        lSQL += ", " + dGVRow.ToString();          // 11- Serial No
                        lSQL += ", 0"; //is Checked
                        lSQL += ")";
                        //
                        fManySQL.Add(lSQL);

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
                        lSQL += " " + fDocTypeID.ToString();                                                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                        lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
                        lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
                        //
                        lSQL += ", " + msk_AccountIDCr.Tag;                     // 2- Serial Order replaced with SNo. 
                        //                                                                                       // 5- Ac Title NA
                        lSQL += ", '" + StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.ItemName].Value.ToString())       // 8- Narration 
                            + " Qty: " + StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChgableQty].Value.ToString())
                            + "@" + String.Format("{0:0,0.00}", grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabRate].Value)
                            //+ "@" + String.Format("{0:0,0.00}", StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabRate].Value.ToString()))
                            + "'";      // 8- Narration 
                        //lSQL += ", 0";           // 9- Debit. 
                        //lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString();          // 10- Credit. 
                        if (clsDbManager.ConvDecimal(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString()) > 0)
                        {
                            lSQL += ", 0";          // 10- Credit
                            lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString();           // 9- Debit. 
                        }
                        if (clsDbManager.ConvDecimal(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString()) < 0)
                        {
                            lSQL += ", " + Math.Abs(clsDbManager.ConvDecimal(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString()));  //grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString();           // 10- Credit
                            lSQL += ", 0";            // 9- Debit. 
                        }
                        lSQL += ", " + dGVRow.ToString();          // 11- Serial No
                        lSQL += ", 0"; //is Checked
                        lSQL += ")";
                        //
                        fManySQL.Add(lSQL);
                    }
                }

                // Waste Grid GL Entry
                for (int dGVRow = 0; dGVRow < grdWaste.Rows.Count; dGVRow++)
                {
                    if (clsDbManager.ConvDecimal(grdWaste.Rows[dGVRow].Cells[(int)GColWaste.ItemID].Value.ToString()) > 0)
                    {
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
                        lSQL += " " + fDocTypeID.ToString();                                                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                        lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
                        lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
                        //
                        lSQL += ", " + msk_WasteDr.Tag;                     // 2- Serial Order replaced with SNo. 
                        //                                                                                       // 5- Ac Title NA
                        lSQL += ", '" + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColWaste.ItemName].Value.ToString())
                             + " Qty: " + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Qty].Value.ToString())
                            + "@" + String.Format("{0:0,0.00}", grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Rate].Value)
                            + "'";      // 8- Narration 
                        //+ "@" + String.Format("{0:0,0.00}", StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabRate].Value.ToString()))
                        //String.Format("{0:0,0.00}", fLabChges);
                        lSQL += ", " + grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Amount].Value.ToString();           // 9- Debit. 
                        lSQL += ", 0";          // 10- Debit. 
                        lSQL += ", " + dGVRow.ToString();          // 11- Serial No
                        lSQL += ", 0"; //is Checked
                        lSQL += ")";
                        //
                        fManySQL.Add(lSQL);

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
                        lSQL += " " + fDocTypeID.ToString();                                                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                        lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
                        lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
                        //
                        lSQL += ", " + msk_WasteCr.Tag;                     // 2- Serial Order replaced with SNo. 
                        //                                                                                       // 5- Ac Title NA
                        lSQL += ", '" + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColWaste.ItemName].Value.ToString())       // 8- Narration 
                            + " Qty: " + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Qty].Value.ToString())
                            + "@" + String.Format("{0:0,0.00}", grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Rate].Value)
                            //+ "@" + String.Format("{0:0,0.00}", StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabRate].Value.ToString()))
                            + "'";      // 8- Narration 
                        lSQL += ", 0";           // 9- Debit. 
                        lSQL += ", " + grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Amount].Value.ToString();          // 10- Debit. 
                        lSQL += ", " + dGVRow.ToString();          // 11- Serial No
                        lSQL += ", 0"; //is Checked
                        lSQL += ")";
                        //
                        fManySQL.Add(lSQL);
                    }
                }

                // Voucher Double Entry Input
                for (int dGVRow = 0; dGVRow < grdVoucher.Rows.Count; dGVRow++)
                {
                    // Mesh Transaction
                    if (clsDbManager.ConvDecimal(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Amount].Value.ToString()) > 0)
                    {
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
                        lSQL += " " + fDocTypeID.ToString();                                                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                        lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
                        lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
                        //
                        lSQL += ", " + msk_AccountIDDr.Tag;                     // 2- Serial Order replaced with SNo. 
                        //                                                                                       // 5- Ac Title NA
                        lSQL += ", 'Mesh: " + StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.ItemName].Value.ToString())       // 8- Narration 
                            +" Qty: " + StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.MeshTotal].Value.ToString())
                            + "@" + String.Format("{0:0,0.00}", grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.MeshRate].Value)
                            //+ "@" + String.Format("{0:0,0.00}", StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.MeshRate].Value.ToString()))
                            + "'";      // 8- Narration 

                        lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Amount].Value.ToString();           // 9- Debit. 
                        lSQL += ", 0";          // 10- Debit. 
                        lSQL += ", " + dGVRow.ToString();          // 11- Serial No
                        lSQL += ", 0"; //is Checked
                        lSQL += ")";
                        //
                        fManySQL.Add(lSQL);

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
                        lSQL += " " + fDocTypeID.ToString();                                                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                        lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
                        lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
                        //
                        lSQL += ", " + msk_AccountIDCr.Tag;                     // 2- Serial Order replaced with SNo. 
                        //                                                                                       // 5- Ac Title NA
                        lSQL += ", 'Mesh: " + StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.ItemName].Value.ToString())       // 8- Narration 
                            + " Qty: " + StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.MeshTotal].Value.ToString())
                            + "@" + String.Format("{0:0,0.00}", grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.MeshRate].Value)
                            //+ "@" + String.Format("{0:0,0.00}", StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.MeshRate].Value.ToString()))
                            + "'";      // 8- Narration 

                        lSQL += ", 0";           // 9- Debit. 
                        lSQL += ", " + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Amount].Value.ToString();          // 10- Debit. 
                        lSQL += ", " + dGVRow.ToString();          // 11- Serial No
                        lSQL += ", 0"; //is Checked
                        lSQL += ")";
                        //
                        fManySQL.Add(lSQL);
                    }

                } // End For loopo

                // Waste Voucher Double Entry Input
                //for (int dGVRow = 0; dGVRow < grdWaste.Rows.Count; dGVRow++)
                //{
                //    // Mesh Transaction
                //    if (clsDbManager.ConvDecimal(grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Amount].Value.ToString()) > 0)
                //    {
                //        lSQL = "insert into gl_trandtl ( ";
                //        // Middle Pottion
                //        lSQL += " doc_vt_id ";                                                               // Form 1- 
                //        lSQL += ", doc_fiscal_id ";                                                                // 4- Doc Fiscal 
                //        lSQL += ", doc_id ";                                                                    // Form 2- 
                //        lSQL += ", ac_id ";                                                                     // 3-
                //        lSQL += ", NARRATION ";                                                                 // 8-
                //        lSQL += ", DEBIT ";                                                                     // 9-    
                //        lSQL += ", CREDIT ";                                                                    // 10-
                //        //
                //        lSQL += ", SERIAL_ORDER ";                                                              // 1-
                //        lSQL += ", isChecked ";                                                                // 7-
                //        //
                //        // Bottom Portion
                //        //
                //        lSQL += ") values (";
                //        lSQL += " " + fDocTypeID.ToString();                                                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                //        lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
                //        lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
                //        //
                //        lSQL += ", " + msk_WasteDr.Tag;                     // 2- Serial Order replaced with SNo. 
                //        //                                                                                       // 5- Ac Title NA
                //        lSQL += ", 'Mesh: " + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColWaste.ItemName].Value.ToString())       // 8- Narration 
                //            + " Qty: " + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Qty].Value.ToString())
                //            + "@" + String.Format("{0:0,0.00}", grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Rate].Value)
                //            //+ "@" + String.Format("{0:0,0.00}", StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.MeshRate].Value.ToString()))
                //            + "'";      // 8- Narration 

                //        lSQL += ", " + grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Amount].Value.ToString();           // 9- Debit. 
                //        lSQL += ", 0";          // 10- Debit. 
                //        lSQL += ", " + dGVRow.ToString();          // 11- Serial No
                //        lSQL += ", 0"; //is Checked
                //        lSQL += ")";
                //        //
                //        fManySQL.Add(lSQL);

                //        lSQL = "insert into gl_trandtl ( ";
                //        // Middle Pottion
                //        lSQL += " doc_vt_id ";                                                               // Form 1- 
                //        lSQL += ", doc_fiscal_id ";                                                                // 4- Doc Fiscal 
                //        lSQL += ", doc_id ";                                                                    // Form 2- 
                //        lSQL += ", ac_id ";                                                                     // 3-
                //        lSQL += ", NARRATION ";                                                                 // 8-
                //        lSQL += ", DEBIT ";                                                                     // 9-    
                //        lSQL += ", CREDIT ";                                                                    // 10-
                //        //
                //        lSQL += ", SERIAL_ORDER ";                                                              // 1-
                //        lSQL += ", isChecked ";                                                                // 7-
                //        //
                //        // Bottom Portion
                //        //
                //        lSQL += ") values (";
                //        lSQL += " " + fDocTypeID.ToString();                                                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                //        lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
                //        lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
                //        //
                //        lSQL += ", " + msk_AccountIDCr.Tag;                     // 2- Serial Order replaced with SNo. 
                //        //                                                                                       // 5- Ac Title NA
                //        lSQL += ", 'Mesh: " + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColWaste.ItemName].Value.ToString())       // 8- Narration 
                //            + " Qty: " + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Qty].Value.ToString())
                //            + "@" + String.Format("{0:0,0.00}", grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Rate].Value)
                //            //+ "@" + String.Format("{0:0,0.00}", StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.MeshRate].Value.ToString()))
                //            + "'";      // 8- Narration 

                //        lSQL += ", 0";           // 9- Debit. 
                //        lSQL += ", " + grdWaste.Rows[dGVRow].Cells[(int)GColWaste.Amount].Value.ToString();          // 10- Debit. 
                //        lSQL += ", " + dGVRow.ToString();          // 11- Serial No
                //        lSQL += ", 0"; //is Checked
                //        lSQL += ")";
                //        //
                //        fManySQL.Add(lSQL);
                //    }

                //} // End For loopo

                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Detail Doc: " + ex.Message, this.Text.ToString());
                return false;
            }
        }

        //private bool PrepareDocGLWasteDetail()
        //{
        //    bool rtnValue = true;
        //    string lSQL = "";
        //    //Int64 lAcID = 0;
        //    try
        //    {
        //        //
        //        for (int dGVRow = 0; dGVRow < grdWaste.Rows.Count; dGVRow++)
        //        {
        //            if (clsDbManager.ConvDecimal(grdWaste.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString()) > 0)
        //            {
        //                lSQL = "insert into gl_trandtl ( ";
        //                // Middle Pottion
        //                lSQL += " doc_vt_id ";                                                               // Form 1- 
        //                lSQL += ", doc_fiscal_id ";                                                                // 4- Doc Fiscal 
        //                lSQL += ", doc_id ";                                                                    // Form 2- 
        //                lSQL += ", ac_id ";                                                                     // 3-
        //                lSQL += ", NARRATION ";                                                                 // 8-
        //                lSQL += ", DEBIT ";                                                                     // 9-    
        //                lSQL += ", CREDIT ";                                                                    // 10-
        //                //
        //                lSQL += ", SERIAL_ORDER ";                                                              // 1-
        //                lSQL += ", isChecked ";                                                                // 7-
        //                //
        //                // Bottom Portion
        //                //
        //                lSQL += ") values (";
        //                lSQL += " " + fDocTypeID.ToString();                                                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
        //                lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
        //                lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
        //                //
        //                lSQL += ", " + msk_WasteDr.Tag;                     // 2- Serial Order replaced with SNo. 
        //                //                                                                                       // 5- Ac Title NA
        //                lSQL += ", '" + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColMfg.ItemName].Value.ToString())
        //                     + " Qty: " + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColMfg.QtyOut].Value.ToString())
        //                    + "@" + String.Format("{0:0,0.00}", grdWaste.Rows[dGVRow].Cells[(int)GColMfg.LabRate].Value)
        //                    + "'";      // 8- Narration 
        //                //+ "@" + String.Format("{0:0,0.00}", StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabRate].Value.ToString()))
        //                //String.Format("{0:0,0.00}", fLabChges);
        //                lSQL += ", " + grdWaste.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString();           // 9- Debit. 
        //                lSQL += ", 0";          // 10- Debit. 
        //                lSQL += ", " + dGVRow.ToString();          // 11- Serial No
        //                lSQL += ", 0"; //is Checked
        //                lSQL += ")";
        //                //
        //                fManySQL.Add(lSQL);

        //                lSQL = "insert into gl_trandtl ( ";
        //                // Middle Pottion
        //                lSQL += " doc_vt_id ";                                                               // Form 1- 
        //                lSQL += ", doc_fiscal_id ";                                                                // 4- Doc Fiscal 
        //                lSQL += ", doc_id ";                                                                    // Form 2- 
        //                lSQL += ", ac_id ";                                                                     // 3-
        //                lSQL += ", NARRATION ";                                                                 // 8-
        //                lSQL += ", DEBIT ";                                                                     // 9-    
        //                lSQL += ", CREDIT ";                                                                    // 10-
        //                //
        //                lSQL += ", SERIAL_ORDER ";                                                              // 1-
        //                lSQL += ", isChecked ";                                                                // 7-
        //                //
        //                // Bottom Portion
        //                //
        //                lSQL += ") values (";
        //                lSQL += " " + fDocTypeID.ToString();                                                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
        //                lSQL += ", " + fDocFiscal.ToString();                                               // 4- Document Fiscal
        //                lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
        //                //
        //                lSQL += ", " + msk_WasteCr.Tag;                     // 2- Serial Order replaced with SNo. 
        //                //                                                                                       // 5- Ac Title NA
        //                lSQL += ", '" + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColMfg.ItemName].Value.ToString())       // 8- Narration 
        //                    + " Qty: " + StrF01.EnEpos(grdWaste.Rows[dGVRow].Cells[(int)GColMfg.QtyOut].Value.ToString())
        //                    + "@" + String.Format("{0:0,0.00}", grdWaste.Rows[dGVRow].Cells[(int)GColMfg.LabRate].Value)
        //                    //+ "@" + String.Format("{0:0,0.00}", StrF01.EnEpos(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.LabRate].Value.ToString()))
        //                    + "'";      // 8- Narration 
        //                lSQL += ", 0";           // 9- Debit. 
        //                lSQL += ", " + grdWaste.Rows[dGVRow].Cells[(int)GColMfg.LabChg].Value.ToString();          // 10- Debit. 
        //                lSQL += ", " + dGVRow.ToString();          // 11- Serial No
        //                lSQL += ", 0"; //is Checked
        //                lSQL += ")";
        //                //
        //                fManySQL.Add(lSQL);
        //            }
        //        }

        //        //} // End For loopo
        //        return rtnValue;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Save Detail Doc: " + ex.Message, this.Text.ToString());
        //        return false;
        //    }
        //}

        private bool PrepareDocDetail()
        {
            bool rtnValue = true;
            try
            {
                // Grid Voucher
                if (grdVoucher.Rows.Count > 0)
                {
                    // Prepare Detail Doc Query List
                    string tTableName = "Mfg_trandtl";
                    //string tFieldName = "";
                    //string tColType = "";
                    //

                    string tAddFieldName = "Doc_vt_id, Doc_fiscal_ID, Doc_ID";
                    string tAddValue = fDocTypeID.ToString() + ", " + fDocFiscal.ToString() + ", " + fDocID.ToString();

                    //string tDeleteQry = "delete from " + tTableName + " where "
                    //    + "Doc_vt_id=" + fDocTypeID.ToString()
                    //    + ", Doc_fiscal_ID=" + fDocFiscal.ToString()
                    //    + ", Doc_ID=" + fDocID.ToString();
                    //if (fNewID)
                    //{
                    //    tAddValue += mtextID.Text.ToString();
                    //    tDeleteQry += mtextID.Text.ToString();
                    //    tDeleteQry += " and " + clsGVar.LGCY;  // ?
                    //}
                    //else
                    //{
                    //    tAddValue += cboGLVoucherType.SelectedValue.ToString();
                    //    tDeleteQry += cboGLVoucherType.SelectedValue.ToString();
                    //    tDeleteQry += " and " + clsGVar.LGCY;
                    //}
                    //fManySQL.Add(tDeleteQry);
                    //
                    if (clsDbManager.PrepareGridSQL(grdVoucher, tTableName, fFieldName, fColType, fManySQL, tAddFieldName, tAddValue) != "OK")
                    {
                        return false;
                    }
                }
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Detail Doc: " + ex.Message, this.Text.ToString());
                return false;
            }
            
        }

        private bool PrepareDocDetailIn()
        {
            bool rtnValue = true;
            try
            {

                // Grid Voucher
                if (grdVoucher.Rows.Count > 0)
                {
                    // Prepare Detail Doc Query List
                    string tTableName = "Mfg_trandtl";
                    //string tFieldName = "";
                    //string tColType = "";
                    //
                    string tAddFieldName = "Doc_vt_id, Doc_fiscal_ID, Doc_ID";
                    string tAddValue = fDocTypeID.ToString() + ", " + fDocFiscal.ToString() + ", " + fDocID.ToString();

                    if (clsDbManager.PrepareGridSQL(grdVoucher, tTableName, fFieldList, fColFormat, fManySQL, tAddFieldName, tAddValue) != "OK")
                    {
                        return false;
                    }
                }
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Detail Doc: " + ex.Message, this.Text.ToString());
                return false;
            }
        }

        private bool PrepareDocWasteDetail()
        {
            bool rtnValue = true;
            try
            {

                // Grid Voucher
                if (grdWaste.Rows.Count > 0)
                {
                    // Prepare Detail Doc Query List
                    string tTableName = "Inv_trandtl";
                    string tFieldName = "";
                    string tColType = "";
                    //

                    tColType += "  N0"; //0 ItemID
                    tColType += ", TB"; //1 Item Name/Narration
                    tColType += ", N0"; //2 UOM
                    tColType += ", SKP"; //3 UOM Name
                    tColType += ", N0";  //4 Godown   
                    tColType += ", SKP"; //5 Godown Name
                    tColType += ", N2";  //6 Qty      
                    tColType += ", N2";  //7 Rate
                    tColType += ", N0";  //8    Bundle      
                    tColType += ", N2";  //9    MeshTotal
                    tColType += ", SKP";  //10  Amount        
                    tColType += ", CH";  //11   isBundle      
                    tColType += ", CH";  //12   isMesh      
                    tColType += ", N2";  //13   Length      
                    tColType += ", N2";  //14   LenDec      
                    tColType += ", N2";  //15   Width      
                    tColType += ", N2";  //16   WidDec       
                    //

                    tFieldName += "  ItemID";        //0  
                    tFieldName += ", Narration";     //1  
                    //
                    tFieldName += ", UOMID";         //2  
                    tFieldName += ", '' as skp2";    //3  
                    tFieldName += ", GodownID";      //4  
                    tFieldName += ", '' as skp3";    //5  
                    tFieldName += ", Qty_Out";       //6  
                    tFieldName += ", Rate";          //7  
                    tFieldName += ", Bundle";        //8  
                    tFieldName += ", MeshTotal";     //9  
                    tFieldName += ", '' as skp4";    //10  
                    tFieldName += ", isBundle";      //11 
                    tFieldName += ", isMesh";        //12 
                    tFieldName += ", Length";        //13 
                    tFieldName += ", LenDec";        //14 
                    tFieldName += ", Width";         //15 
                    tFieldName += ", WidDec";        //16 
                    // 
                    string tAddFieldName = "Doc_vt_id, Doc_fiscal_ID, Doc_ID";
                    string tAddValue = fDocTypeID.ToString() + ", " + fDocFiscal.ToString() + ", " + fDocID.ToString();

                    //
                    if (clsDbManager.PrepareGridSQL(grdWaste, tTableName, tFieldName, tColType, fManySQL, tAddFieldName, tAddValue) != "OK")
                    {
                        return false;
                    }
                }
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Detail Doc: " + ex.Message, this.Text.ToString());
                return false;
            }

        }

        private bool PrepareDocWasteDetailIn()
        {
            bool rtnValue = true;
            try
            {

                // Grid Voucher
                if (grdWaste.Rows.Count > 0)
                {
                    // Prepare Detail Doc Query List
                    string tTableName = "Inv_trandtl";
                    string tFieldName = "";
                    string tColType = "";
                    //

                    tColType += "  N0"; //0 ItemID
                    tColType += ", TB"; //1 Item Name/Narration
                    tColType += ", N0"; //2 UOM
                    tColType += ", SKP"; //3 UOM Name
                    tColType += ", N0";  //4 Godown   
                    tColType += ", SKP"; //5 Godown Name
                    tColType += ", N2";  //6 Qty      
                    tColType += ", N2";  //7 Rate
                    tColType += ", N0";  //8    Bundle      
                    tColType += ", N2";  //9    MeshTotal
                    tColType += ", SKP";  //10  Amount        
                    tColType += ", CH";  //11   isBundle      
                    tColType += ", CH";  //12   isMesh      
                    tColType += ", N2";  //13   Length      
                    tColType += ", N2";  //14   LenDec      
                    tColType += ", N2";  //15   Width      
                    tColType += ", N2";  //16   WidDec       
                    //

                    tFieldName += "  ItemID";        //0  
                    tFieldName += ", Narration";     //1  
                    //
                    tFieldName += ", UOMID";         //2  
                    tFieldName += ", '' as skp2";    //3  
                    tFieldName += ", GodownID";      //4  
                    tFieldName += ", '' as skp3";    //5  
                    tFieldName += ", Qty_Out";       //6  
                    tFieldName += ", Rate";          //7  
                    tFieldName += ", Bundle";        //8  
                    tFieldName += ", MeshTotal";     //9  
                    tFieldName += ", '' as skp4";    //10  
                    tFieldName += ", isBundle";      //11 
                    tFieldName += ", isMesh";        //12 
                    tFieldName += ", Length";        //13 
                    tFieldName += ", LenDec";        //14 
                    tFieldName += ", Width";         //15 
                    tFieldName += ", WidDec";        //16 
                    // 
                    string tAddFieldName = "Doc_vt_id, Doc_fiscal_ID, Doc_ID";
                    string tAddValue = fDocTypeID.ToString() + ", " + fDocFiscal.ToString() + ", " + fDocID.ToString();

                    //
                    if (clsDbManager.PrepareGridSQL(grdWaste, tTableName, tFieldName, tColType, fManySQL, tAddFieldName, tAddValue) != "OK")
                    {
                        return false;
                    }
                }
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Detail Doc: " + ex.Message, this.Text.ToString());
                return false;
            }

        }

        //private bool Prepare_GL_Trans()
        //{ 
        //    bool rtnValue = true;
        //    string lSQL = "";
        //    DataSet ds = new DataSet();
        //    DataRow dRow;
        //    string strItemDes = string.Empty;
        //    string strUOM_ST = string.Empty;
        //    //Int64 lAcID = 0;
        //    try
        //    {
        //        //
        //        for (int dGVRow = 0; dGVRow < grdVoucher.Rows.Count; dGVRow++)
        //        {
        //            //frmGroupRights.dictGrpForms.Add(Convert.ToInt32(dGVSelectedForms.Rows[dGVRow].Cells[0].Value.ToString()),
        //            //    dGVSelectedForms.Rows[dGVRow].Cells[1].Value.ToString());
        //            // Prepare Save Data to Db Table
        //            //
        //            if (grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.ItemID].Value == null)
        //            {
        //                if (dGVRow == fLastRow)
        //                {
        //                    continue;
        //                }
        //            }
        //            else
        //            {
        //                if ((grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.ItemID].Value.ToString()).Trim(' ', '-') == "")
        //                {
        //                    //lBlank = true;
        //                    if (dGVRow == fLastRow)
        //                    {
        //                        continue;
        //                    }
        //                }
        //            }
        //            strItemDes = "";
        //            strUOM_ST = "";

        //            lSQL = "SELECT gg.Group_st + i.goodsitem_st AS Item_ST ";
        //            lSQL += " FROM gds_item i INNER JOIN gds_Group gg ON i.Group_id=gg.Group_id ";
        //            lSQL += " WHERE i.goodsitem_id=" + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.ItemID].Value.ToString();
        //            lSQL += "; SELECT goodsuom_st FROM gds_uom WHERE goodsuom_id=";
        //            lSQL += grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.UOMID].Value.ToString();

        //            ds = clsDbManager.GetData_Set(lSQL, "Items");
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                dRow = ds.Tables[0].Rows[0];
        //                strItemDes = dRow.ItemArray.GetValue(0).ToString();

        //                dRow = ds.Tables[1].Rows[0];
        //                strUOM_ST = dRow.ItemArray.GetValue(0).ToString();

        //            }

        //            //if (grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.isMesh].Value != null)
        //            //{
        //            //    if (clsDbManager.ConvBit(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.isBundle].Value.ToString()) == "0"
        //            //        && clsDbManager.ConvBit(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.isMesh].Value.ToString()) == "0")
        //            //    {
        //            //        strItemDes += " B=" + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Bundle].Value.ToString()
        //            //            + " Q=" + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Qty].Value.ToString()
        //            //            + " " + strUOM_ST
        //            //            + " @" + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Rate].Value.ToString();
        //            //    }

        //            //    if (clsDbManager.ConvBit(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.isBundle].Value.ToString()) == "1")
        //            //    {
        //            //        strItemDes += " Q=" + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Bundle].Value.ToString()
        //            //            + " " + strUOM_ST
        //            //            + " @" + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Rate].Value.ToString();
        //            //    }

        //            //    if (clsDbManager.ConvBit(grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.isMesh].Value.ToString()) == "1")
        //            //    {
        //            //        strItemDes += " B=" + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Bundle].Value.ToString()
        //            //            + " x L=" + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Length].Value.ToString()
        //            //            + " x W=" + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Width].Value.ToString()
        //            //            + " Q=" + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.MeshTotal].Value.ToString()
        //            //            + " " + strUOM_ST
        //            //            + " @" + grdVoucher.Rows[dGVRow].Cells[(int)GColMfg.Rate].Value.ToString();
        //            //    }

        //            //}
        //            //lSQLValues += ConvBit("False");
        //            //}
        //            //else
        //            //{
        //            //lSQLValues += ConvBit(pdGv.Rows[i].Cells[j].Value.ToString());
        //            //}
        //            //grdVoucher.Rows[dGVRow].Cells[(int)GColIO.isMesh].Value.ToString()

        //            // 1st GL Transaction
        //            //lSQL = "insert into gl_trandtl ( ";
        //            //// Middle Pottion
        //            //lSQL += " doc_vt_id ";                                                               // Form 1- 
        //            //lSQL += ", doc_fiscal_id ";                                                                // 4- Doc Fiscal 
        //            //lSQL += ", doc_id ";                                                                    // Form 2- 
        //            //lSQL += ", ac_id ";                                                                     // 3-
        //            //lSQL += ", NARRATION ";                                                                 // 8-
        //            //lSQL += ", DEBIT ";                                                                     // 9-    
        //            //lSQL += ", CREDIT ";                                                                    // 10-
        //            ////
        //            //lSQL += ", SERIAL_ORDER ";                                                              // 1-
        //            //lSQL += ", isChecked ";                                                                // 7-
        //            ////
        //            //// Bottom Portion
        //            ////
        //            //lSQL += ") values (";
        //            //lSQL += " " + fDocTypeID.ToString();                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
        //            //lSQL += ", " + fDocFiscal.ToString();                      // 4- Document Fiscal
        //            //lSQL += ", " + fDocID.ToString();                          // 2- Form 1- Voucher_id
        //            ////
        //            //lSQL += ", " + msk_AccountIDCr.Tag; //grdVoucher.Rows[dGVRow].Cells[(int)GColIO.acid].Value.ToString();            // 2- Serial Order replaced with SNo. 
        //            ////                                                                                       // 5- Ac Title NA
        //            //lSQL += ", '" + strItemDes + "'";      // 8- Narration 
        //            //lSQL += ", " + 0;           // 9- Debit. 
        //            //lSQL += ", " + clsDbManager.ConvDecimal(grdVoucher.Rows[dGVRow].Cells[(int)GColFtF.Amount].Value.ToString());           // 10- Credit
        //            //lSQL += ", " + 0;          // 11- Combo 1 
        //            //lSQL += ", 0"; //is Checked
        //            //lSQL += ")";

        //            //fManySQL.Add(lSQL);
        //            //rtnValue = true;
                    
        //        }
        //        return rtnValue;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Save Detail Doc: " + ex.Message, this.Text.ToString());
        //        return false;
        //    }
        //}

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
                    if (pdGv.Rows[dGVRow].Cells[(int)GColMfg.ItemID].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((pdGv.Rows[dGVRow].Cells[(int)GColMfg.ItemID].Value.ToString()).Trim(' ', '-') == "")
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

            if (fEditMod == true)
            {
                if (chk_Edit.Checked == false)
                {
                    return;
                }
            }
            if (msk_AccountIDDr.Text.Trim(' ', '_') == "")
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
                    "t.doc_strid,t.doc_date,a.ac_title,t.doc_amt,t.doc_remarks",
                    "Mfg_tran t LEFT OUTER JOIN gl_ac a ON t.GLID_Cr=a.ac_id",
                    this.Text.ToString(),
                    1,
                    "Doc_ID,Voucher ID,Date,CreditAccount,Amount,Remarks",
                    "6,8,8,12,12,12",
                    " T, T, T, T,N2, T",
                    true,
                    "",
                    "t.doc_vt_id = " + fDocTypeID.ToString() + " and t.doc_fiscal_id = 1 and t.doc_status = 1",
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

            tSQL = "SELECT it.doc_id, it.doc_strid, it.doc_date, it.doc_remarks, ";
            tSQL += " it.ContractID, it.ContractNo, it.ContractStatType, ";
            tSQL += " it.ContractNoWaste, it.ContractStatTypeWaste, ";
            tSQL += " it.doc_amt, it.GLID, ga.ac_title, ga.ac_strid, ";
            tSQL += " it.GLID_Cr, gc.ac_title As Ac_TitleCr, gc.ac_strid As Ac_StrIDCr, ";
            tSQL += " it.GLID_Dr_Waste, wd.ac_title As Ac_TitleDrWaste, wd.ac_strid As Ac_StrIDDrWaste, ";
            tSQL += " it.GLID_Cr_Waste, wc.ac_title As Ac_TitleCrWaste, wc.ac_strid As Ac_StrIDCrWaste, ";

            tSQL += " it.GodownID, it.FromDate, it.ToDate, it.ItemGroupID, it.TransportID, ";
            tSQL += " it.isShowRpt, it.isCalcRpt ";
            tSQL += " from Mfg_tran it INNER JOIN gl_ac ga ON it.GLID=ga.ac_id ";
            tSQL += " INNER JOIN gl_ac gc ON it.GLID_Cr=gc.ac_id ";
            tSQL += " Left Outer JOIN gl_ac wd ON it.GLID_Dr_Waste= wd.ac_id ";
            tSQL += " Left Outer JOIN gl_ac wc ON it.GLID_Cr_Waste= wc.ac_id ";

            tSQL += " where  it.doc_vt_id=" + fDocTypeID.ToString() + " and it.doc_fiscal_id=1 and it.doc_status=1";
            tSQL += " and it.doc_id=" + lblDocID.Text.ToString() + ";";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Mfg_tran");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    fDocID = Convert.ToInt64(lblDocID.Text.ToString());

                    txtManualDoc.Text = (ds.Tables[0].Rows[0]["doc_strid"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["doc_strid"].ToString());
                    msk_VocDate.Text = (ds.Tables[0].Rows[0]["doc_date"] == DBNull.Value ? DateTime.Now.ToString("T") : ds.Tables[0].Rows[0]["doc_date"].ToString());
                    txtRemarks.Text = (ds.Tables[0].Rows[0]["doc_remarks"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["doc_remarks"].ToString());
                    msk_AccountIDDr.Text = (ds.Tables[0].Rows[0]["Ac_StrID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_StrID"].ToString());
                    lblAccountNameDr.Text = (ds.Tables[0].Rows[0]["Ac_Title"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_Title"].ToString());
                    msk_AccountIDDr.Tag = (ds.Tables[0].Rows[0]["GLID"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["GLID"].ToString());

                    msk_AccountIDCr.Text = (ds.Tables[0].Rows[0]["Ac_StrIDCr"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_StrIDCr"].ToString());
                    lblAccountNameCr.Text = (ds.Tables[0].Rows[0]["Ac_TitleCr"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_TitleCr"].ToString());
                    msk_AccountIDCr.Tag = (ds.Tables[0].Rows[0]["GLID_Cr"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["GLID_Cr"].ToString());

                    msk_WasteDr.Text = (ds.Tables[0].Rows[0]["Ac_StrIDDrWaste"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_StrIDDrWaste"].ToString());
                    lblWasteNameDr.Text = (ds.Tables[0].Rows[0]["Ac_TitleDrWaste"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_TitleDrWaste"].ToString());
                    msk_WasteDr.Tag = (ds.Tables[0].Rows[0]["GLID_Dr_Waste"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["GLID_Dr_Waste"].ToString());

                    msk_WasteCr.Text = (ds.Tables[0].Rows[0]["Ac_StrIDCrWaste"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_StrIDCrWaste"].ToString());
                    lblWasteNameCr.Text = (ds.Tables[0].Rows[0]["Ac_TitleCrWaste"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_TitleCrWaste"].ToString());
                    msk_WasteCr.Tag = (ds.Tables[0].Rows[0]["GLID_Cr_Waste"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["GLID_Cr_Waste"].ToString());

                    txtLabourContract.Tag = (ds.Tables[0].Rows[0]["ContractID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ContractID"].ToString());
                    txtLabourContract.Text = (ds.Tables[0].Rows[0]["ContractNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ContractNo"].ToString());
                    txtWasteContract.Text = (ds.Tables[0].Rows[0]["ContractNoWaste"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ContractNoWaste"].ToString());
                    cboTransType.SelectedIndex = clsSetCombo.Set_ComboBox(cboTransType, Convert.ToInt16(ds.Tables[0].Rows[0]["ContractStatType"].ToString()));
                    cboTransTypeW.SelectedIndex = clsSetCombo.Set_ComboBox(cboTransTypeW, Convert.ToInt16(ds.Tables[0].Rows[0]["ContractStatTypeWaste"].ToString()));
                    cboGodown.SelectedIndex = clsSetCombo.Set_ComboBox(cboGodown, Convert.ToInt16(ds.Tables[0].Rows[0]["GodownID"].ToString()));
                    cboItemGroup.SelectedIndex = clsSetCombo.Set_ComboBox(cboItemGroup, Convert.ToInt16(ds.Tables[0].Rows[0]["ItemGroupID"].ToString()));

                    msk_FromDate.Text = (ds.Tables[0].Rows[0]["Fromdate"] == DBNull.Value ? DateTime.Now.ToString("T") : ds.Tables[0].Rows[0]["Fromdate"].ToString());
                    msk_ToDate.Text = (ds.Tables[0].Rows[0]["Todate"] == DBNull.Value ? DateTime.Now.ToString("T") : ds.Tables[0].Rows[0]["Todate"].ToString());

                    //txtBiltyNo.Text = (ds.Tables[0].Rows[0]["BiltyNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BiltyNo"].ToString());
                    //txtBiltyDate.Text = (ds.Tables[0].Rows[0]["BiltyDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BiltyDate"].ToString());
                    //txtVehicleNo.Text = (ds.Tables[0].Rows[0]["VehicleNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["VehicleNo"].ToString());
                    //txtDriverName.Text = (ds.Tables[0].Rows[0]["DriverName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DriverName"].ToString());

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

                    //int tcboTransportID = 0;
                    //tcboTransportID = Convert.ToInt16(ds.Tables[0].Rows[0]["TransportID"].ToString());
                    ////cboTransport.SelectedIndex = clsSetCombo.Set_ComboBox(cboTransport, tcboTransportID);
                    fEditMod = true;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                        btn_EnableDisable(true);
                    }
                    LoadGridData();
                    LoadGridDataWaste();
                    //txtManualDoc.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
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
            msk_AccountIDDr.Text = string.Empty;
            lblAccountNameDr.Text = string.Empty;

            msk_AccountIDCr.Text = string.Empty;
            lblAccountNameCr.Text = string.Empty;

            msk_WasteDr.Text = string.Empty;
            lblWasteNameDr.Text = string.Empty;

            msk_WasteCr.Text = string.Empty;
            lblWasteNameCr.Text = string.Empty;

            txtLabourContract.Text = string.Empty;
            txtWasteContract.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            lblTotalAmount.Text = string.Empty;
            lblTotalAmountMesh.Text = string.Empty;
            lblWasteQty.Text = string.Empty;
            lblWasteableQty.Text = string.Empty;
            lblTotalQtyIn.Text = string.Empty;
            lblTotalQtyOut.Text = string.Empty;
            lblTotalBal.Text = string.Empty;
            lblTotalAmountWaste.Text = string.Empty;
            lblTotalQtyWaste.Text = string.Empty;
 
            //
            if (grdVoucher.Rows.Count > 0)
            {
                grdVoucher.Rows.Clear();
            }
            if (grdWaste.Rows.Count > 0)
            {
                grdWaste.Rows.Clear();
            }

            ResetFields();
            chk_Edit.Checked = false;
            chk_ShowRpt.Checked = false;
            chk_CalcRpt.Checked = false;

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
            //lblWasteQty.Text = string.Empty;
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

        private void LoadGridData() 
        {
            string lSQL = "";
            lSQL = "SELECT ";
            lSQL += "  td.ItemID";                               // 0-
            lSQL += ", i.goodsitem_title as ItemName";                                         // 1-
            lSQL += ", td.UOMID";                                              // 2-
            lSQL += ", u.goodsuom_st";                                              // 3-
            lSQL += ", td.Qty_In";                                            // 4-
            lSQL += ", td.Qty_Out";                                            // 5-
            lSQL += ", td.Balance";                                          // 7-
            lSQL += ", td.WastePAge";
            lSQL += ", td.WasteLessQty";
            lSQL += ", td.WasteableQty";
            lSQL += ", td.WasteQty";
            lSQL += ", td.WithoutLabQty";
            lSQL += ", td.LabCharge";
            lSQL += ", td.LabourRate";
            lSQL += ", td.LabCharges";
            lSQL += ", td.MeshTotal";
            lSQL += ", td.MeshRate";
            lSQL += ", td.Amount";

            lSQL += " FROM Mfg_tran t INNER JOIN Mfg_trandtl td  ON t.doc_vt_id=td.doc_vt_id ";
            lSQL += " AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id";
            lSQL += " INNER JOIN gds_item i ON i.goodsitem_id=td.ItemID ";
            lSQL += " INNER JOIN gds_uom u ON td.UOMID=u.goodsuom_id ";
            //lSQL += " INNER JOIN cmn_Godown g ON td.GodownID=g.Godown_id ";
            lSQL += " where ";
            lSQL += DocWhere("");
            lSQL += " ORDER BY td.SERIAL_No ";
          //
          clsDbManager.FillDataGrid(
              grdVoucher,
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
            fDocWhere += " and t.doc_fiscal_id=1 ";
            fDocWhere += " and t.doc_id=" + lblDocID.Text.ToString();
            //fDocWhere += " and isNull(td.Qty_In,0)>0 ";
            return fDocWhere;
          }
          catch (Exception ex)
          {
            throw;
          }
        }

        private void LoadGridDataWaste()
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
            lSQL += ", td.Qty_Out";                                               // 6-
            lSQL += ", td.Rate";                                          // 7-
            lSQL += ", td.Bundle";                                         // 8-
            lSQL += ", CASE WHEN td.isMesh=1 THEN td.Bundle* ((td.Width + (td.WidDec*0.0833)) * (td.Length + (td.LenDec*0.0833))) ELSE 0 END as MeshTotal";
            //td.Bundle* ((td.Width + (td.WidDec*0.0833)) * (td.Length + (td.LenDec*0.0833))) as MeshTotal";                                        // 9-
            //lSQL += ", isNull(td.Rate,0)*isNull(td.Qty_Out,0) as Amount";       // 10-
            lSQL += ", CASE WHEN td.isBundle=1 THEN isNull(td.Rate,0)*isNull(td.Bundle,0)";
            //lSQL += " WHEN td.isMesh=1 THEN isNull(td.Rate,0)*isNull(td.MeshTotal,0)";
            lSQL += " WHEN td.isMesh=1 THEN isNull(td.Rate,0)*td.Bundle* ((td.Width + (td.WidDec*0.0833)) * (td.Length + (td.LenDec*0.0833)))";
            lSQL += " ELSE isNull(td.Rate,0)*isNull(td.Qty_Out,0) END as Amount";

            lSQL += ", td.isBundle";                                            // 11-    
            lSQL += ", td.isMesh";                                               // 12-
            lSQL += ", td.Length";                                     // 13-
            lSQL += ", td.LenDec";           //14
            lSQL += ", td.Width";            //15
            lSQL += ", td.WidDec";           //16
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
            
            string tFieldList = "";
            tFieldList = "  ItemID";            //0
            tFieldList += ", goodsitem_title";   //1
            tFieldList += ", UOMID ";            //2
            tFieldList += ", goodsuom_title";    //3
            tFieldList += ", GodownID";          //4
            tFieldList += ", Godown_title";      //5
            tFieldList += ", Qty_Out";           //6
            tFieldList += ", Rate";              //7
            tFieldList += ", Bundle";            //8
            tFieldList += ", MeshTotal";         //9
            tFieldList += ", Amount";            //10
            tFieldList += ", isBundle";          //11
            tFieldList += ", isMesh";            //12
            tFieldList += ", Length";            //13
            tFieldList += ", LenDec";            //14
            tFieldList += ", Width";             //15
            tFieldList += ", WidDec";            //16
            //tFieldList += ", ''";              
            // 
            string tColFormat = "TB";
            //tColFormat += ",TB";                                                  // 0-  
            //tColFormat += ",SN";                                                    // 1-    
            tColFormat = "TB";                                                    // 0-    sn
            tColFormat += ",TB";                                                    // 1-    sn
            tColFormat += ",TB";                                                    // 2-
            tColFormat += ",TB";                                                    // 3-
            tColFormat += ",TB";                                                    // 4-
            tColFormat += ",TB";                                                    // 5-
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
            //tColFormat += ",TB";                                                    

            clsDbManager.FillDataGrid(
            grdWaste,
            lSQL,
            tFieldList,
            tColFormat);
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

                    txtItemID.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.ItemID].Value.ToString();
                    lblItemName.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.ItemName].Value.ToString();
                    cbo_UOM.SelectedIndex = clsSetCombo.Set_ComboBox(cbo_UOM, int.Parse(grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.UOMID].Value.ToString()));
                    cboGodown.SelectedIndex = clsSetCombo.Set_ComboBox(cboGodown, int.Parse(grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.GodownID].Value.ToString()));

                    txtQty.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.Qty].Value.ToString();
                    txtRate.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.Rate].Value.ToString();
                    txtBundle.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.Bundle].Value.ToString();
                    lblTotalMeasure.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.MeshTotal].Value.ToString();
                    lblAmount.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.Amount].Value.ToString();
                    txtLength.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.Length].Value.ToString();
                    txtLenDec.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.LenDec].Value.ToString();
                    txtWidth.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.Width].Value.ToString();
                    txtWidDec.Text = grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.WidDec].Value.ToString();

                    //ConvBit(pdGv.Rows[i].Cells[j].Value.ToString())
                    if (grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.isBundle].Value.ToString() == "True")
                    {
                        chk_BundleCalc.Checked = true;
                    }
                    if (grdVoucher.Rows[fEditRow].Cells[(int)GColCsInv.isMesh].Value.ToString() == "True")
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

        private void grdWaste_KeyDown(object sender, KeyEventArgs e)
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
                //if (!fGridControl)
                //{
                //    return;
                //}

                if (grdWaste.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure, really want to Delete row ?", "Delete Row", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        grdWaste.Rows.RemoveAt(grdWaste.CurrentRow.Index);
                        SumWaste();
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

                if (grdWaste.Rows.Count > 0)
                {
                    if (fEditMod == true)
                    {
                        if (chk_Edit.Checked == false)
                        {
                            return;
                        }
                    }
                    //Current Row
                    fEditRow = grdWaste.CurrentRow.Index;

                    txtItemID.Text = grdWaste.Rows[fEditRow].Cells[(int)GColWaste.ItemID].Value.ToString();
                    lblItemName.Text = grdWaste.Rows[fEditRow].Cells[(int)GColWaste.ItemName].Value.ToString();
                    cbo_UOM.SelectedIndex = clsSetCombo.Set_ComboBox(cbo_UOM, int.Parse(grdWaste.Rows[fEditRow].Cells[(int)GColWaste.UOMID].Value.ToString()));
                    cboGodown.SelectedIndex = clsSetCombo.Set_ComboBox(cboGodown, int.Parse(grdWaste.Rows[fEditRow].Cells[(int)GColWaste.GodownID].Value.ToString()));

                    txtQty.Text = grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Qty].Value.ToString();
                    txtRate.Text = grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Rate].Value.ToString();
                    txtBundle.Text = grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Bundle].Value.ToString();
                    lblTotalMeasure.Text = grdWaste.Rows[fEditRow].Cells[(int)GColWaste.MeshTotal].Value.ToString();
                    lblAmount.Text = grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Amount].Value.ToString();
                    txtLength.Text = grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Length].Value.ToString();
                    txtLenDec.Text = grdWaste.Rows[fEditRow].Cells[(int)GColWaste.LenDec].Value.ToString();
                    txtWidth.Text = grdWaste.Rows[fEditRow].Cells[(int)GColWaste.Width].Value.ToString();
                    txtWidDec.Text = grdWaste.Rows[fEditRow].Cells[(int)GColWaste.WidDec].Value.ToString();

                    //ConvBit(pdGv.Rows[i].Cells[j].Value.ToString())
                    //if (grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.isBundle].Value.ToString() == "True")
                    //{
                    //    chk_BundleCalc.Checked = true;
                    //}
                    //if (grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.isMesh].Value.ToString() == "True")
                    //{
                    //    chk_Mesh.Checked = true;
                    //}

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
            grdVoucher.Focus();
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
            if (optNormal.Checked == true)
            {
                string plstField = "@Doc_ID,@Doc_VT_ID";
                string plstType = "8,8"; // {   "8 int, 8 DateTime, 18 Text" };
                string plstValue = lblDocID.Text.ToString() + "," + fDocTypeID.ToString();
                fRptTitle = this.Text;

                //DataSet ds = new DataSet();
                dsMfgClosing ds = new dsMfgClosing();
                //CrInvoice rpt1 = new CrInvoice();
                //CrInvoiceDes rpt1 = new CrInvoiceDes();
                CrMfgClose rpt1 = new CrMfgClose();

                frmPrintViewer rptView = new frmPrintViewer(
                   fRptTitle,
                   msk_VocDate.Text,
                   msk_VocDate.Text,
                   "sp_MfgClosing",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptView.Show();
            }
            if (optMainSub.Checked == true)
            {
                string plstField = "@Doc_ID,@Doc_VT_ID";
                string plstType = "8,8"; // {   "8 int, 8 DateTime, 18 Text" };
                string plstValue = lblDocID.Text.ToString() + "," + fDocTypeID.ToString();
                fRptTitle = this.Text;

                //DataSet ds = new DataSet();
                dsMfgClosing ds = new dsMfgClosing();
                //CrInvoice rpt1 = new CrInvoice();
                //CrInvoiceDes rpt1 = new CrInvoiceDes();
                CrMfgCloseMain2 rpt1 = new CrMfgCloseMain2();

                frmPrintViewerSub4Rpt rptView = new frmPrintViewerSub4Rpt(
                   fRptTitle,
                   msk_VocDate.Text,
                   msk_VocDate.Text,
                   "sp_MfgClosingSub",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptView.Show();
            }

            if (optMainSubWOOpn.Checked == true)
            {
                string plstField = "@Doc_ID,@Doc_VT_ID";
                string plstType = "8,8"; // {   "8 int, 8 DateTime, 18 Text" };
                string plstValue = lblDocID.Text.ToString() + "," + fDocTypeID.ToString();
                fRptTitle = this.Text;

                //DataSet ds = new DataSet();
                dsMfgClosing ds = new dsMfgClosing();
                //CrInvoice rpt1 = new CrInvoice();
                //CrInvoiceDes rpt1 = new CrInvoiceDes();
                CrMfgCloseWOOpn rpt1 = new CrMfgCloseWOOpn();

                frmPrintViewerSub7Rpt rptView = new frmPrintViewerSub7Rpt(
                   fRptTitle,
                   msk_VocDate.Text,
                   msk_VocDate.Text,
                   "sp_MfgClosingSubWOOpn",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptView.Show();
            }
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

                //if (Convert.ToDecimal(txtRate.Text.ToString()) == 0)
                //{
                //    ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Item Rate Empty or Blank, Put the Rate and Try Again");
                //    fTErr++;
                //    lRtnValue = false;
                //    txtRate.Focus();
                //}

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

        // ************* New Lookup Auto Select ********** Begin
        //private void msk_AccountID_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    //frmGLAcLookUp();
        //    clsGLAcLookUp GLLookUp = new clsGLAcLookUp(msk_AccountIDDr, this.Text.ToString()); // Only two parameters are going, all other are optional

        //    GLLookUp.FindGLID();
        //}
        // ************* New Lookup Auto Select ********** End

        private void msk_VocDate_Leave(object sender, EventArgs e)
        {
            string lRtnValue = clsDbManager.VocCheckAndDisplayList(
            "Mfg_tran",
            "doc_strid",
            fDocTypeID,
            StrF01.D2Str(msk_VocDate),
            txtManualDoc.Text);

            if (lRtnValue != "Not Found!")
            {
                MessageBox.Show("Voucher(s) : \n" + lRtnValue, this.Text.ToString());
            }
        }

        private void msk_AccountIDCr_Leave(object sender, EventArgs e)
        {
            if (msk_AccountIDCr.Text.ToString().Trim('_', ' ', '-') == "")
            {
                MessageBox.Show("GL Code is Empty! Unable to Process...", this.Text.ToString());
                msk_AccountIDCr.Focus();
            }

            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  
            tSQL = "Select top 1 ac_title, ac_id, ac_strid from gl_ac Where ";
            tSQL += " ac_strid = '" + msk_AccountIDCr.Text + "';";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "gl_Ac");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblAccountNameCr.Text = dRow.ItemArray.GetValue(0).ToString();
                    msk_AccountIDCr.Tag = dRow.ItemArray.GetValue(1).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();
                }
                else
                {
                    MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                    msk_AccountIDCr.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                msk_AccountIDCr.Focus();
            }

        }

        private void msk_AccountIDCr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUpAc_MaskCr();
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
        private void LookUpAc_MaskCr()
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
                "a.istran = 1 and a.ac_id IN (SELECT Godown_ac_id FROM cmn_Godown)"
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
            msk_AccountIDCr.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataGLIDCr);
            sForm.ShowDialog();
            if (msk_AccountIDCr.Text != null)
            {
                if (msk_AccountIDCr.Text != null)
                {
                    if (msk_AccountIDCr.Text.ToString() == "" || msk_AccountIDCr.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    //msk_AccountID.Text = mMsk_AccountID.Text.ToString();
                    //grdVoucher[pCol, pRow].Value = tmtext.Text.ToString();
                    //System.Windows.Forms.SendKeys.Send("{TAB}");
                }
            }
        }

        private void msk_AccountIDCr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LookUpAc_MaskCr();
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
                MessageBox.Show("Qty is Empty! Unable to Process", this.Text.ToString());
                txtQty.Focus();
            }
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            if (clsDbManager.ConvDecimal(txtRate.Text.ToString()) == 0)
            {
                MessageBox.Show("Rate is Empty! Unable to Process", this.Text.ToString());
                txtRate.Focus();
            }
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

        private void btn_FillGrid_Click(object sender, EventArgs e)
        {
            string plstField=string.Empty;
            string plstType=string.Empty;
            string plstValue=string.Empty;

            plstField = "@pDoc_Fiscal_ID,@pFromDate,@pToDate,@pGodown,@pCT_ID";
            plstType = "8, 18, 18, 8, 8";
            plstValue = "1," + StrF01.D2Str(msk_FromDate) + "," + StrF01.D2Str(msk_ToDate) + ","
                   + cboGodown.SelectedValue.ToString() + "," + txtLabourContract.Tag.ToString();

            ExecuteSPData(plstField, plstType, plstValue);
        }

        private void ExecuteSPData(string flstField, string flstType, string flstValue)
        {
            SqlConnection Con = new SqlConnection(clsGVar.ConString1);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter;

            try
            {
                Con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Item_MfgClosing";

                string[] aryField = flstField.Split(',');
                string[] aryType = flstType.Split(',');
                string[] aryValue = flstValue.Split(',');

                for (int i = 0; i < aryField.Length; i++)
                {

                    switch (int.Parse(aryType[i]))
                    {
                        //sqlDBType.Int
                        case 8:
                            {
                                cmd.Parameters.Add(aryField[i], SqlDbType.Int).Value = int.Parse(aryValue[i]);
                                break;
                            }

                        //sqlDBType.DateTime
                        case 4:
                            {
                                cmd.Parameters.Add(aryField[i], SqlDbType.DateTime).Value = DateTime.Parse(aryValue[i]);
                                break;
                            }
                        //sqlDBType.Text
                        case 18:
                            {
                                cmd.Parameters.Add(aryField[i], SqlDbType.Text).Value = aryValue[i];
                                break;
                            }

                        default:
                            break;
                    }

                }

                cmd.Connection = Con;

                adapter = new SqlDataAdapter(cmd);
                DataSet fDs = new DataSet();
                //adapter.TableMappings.Add("Table", "Table");

                adapter.Fill(fDs);
                string lSQL = string.Empty;
                //
                clsDbManager.FillDataGrid(
                    grdVoucher,
                    lSQL,
                    fFieldList,
                    fColFormat,
                    fDs);

                SumVoc();
                //int cCount = fDs.Tables[0].Rows.Count;
                //if (cCount>0)
                //{
                //    MessageBox.Show(cCount.ToString());
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void grdVoucher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdVoucher_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ToString());
            SumVoc();
        }

        private void msk_AccountIDDr_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtLabourContract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_ContLabChg();
            }
        }

        private void LookUp_ContLabChg()
        {

            frmLookUp sForm = new frmLookUp(
                    "doc_id",
                    "doc_strid, doc_date, doc_remarks, doc_amt",
                    "ct_Tran",
                    this.Text.ToString(),
                    1,
                    "Doc_ID,Voucher ID,Date,Remarks,Amount",
                    "6,8,8,12,12",
                    " T, T, T, T,N2",
                    true,
                    "",
                    "doc_vt_id = " +  clsGVar.CLC.ToString() + " and doc_fiscal_id = 1",
                    "TextBox"
                    );
            //and doc_status = 1

            txtLabourContract.Tag = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataContLabChgID);
            sForm.ShowDialog();
            if (txtLabourContract.Tag != null)
            {
                if (txtLabourContract.Tag != null)
                {
                    if (txtLabourContract.Tag.ToString() == "" || txtLabourContract.Tag.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtLabourContract.Tag.ToString().Trim().Length > 0)
                    {
                        PopulateRecords_ContLabChg();
                        //LoadSampleData();
                        //SumVoc();
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
        private void PopulateRecords_ContLabChg()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT it.doc_id, it.doc_strid, it.doc_date, it.doc_remarks, it.ContractStatType, ";
            //tSQL += " it.ContractNoWaste, it.ContractStatTypeWaste, ";
            tSQL += " it.doc_amt, it.Doc_Status, it.GLID, ga.ac_title, ga.ac_strid, g.Godown_id, ";
            tSQL += " it.GLID_Cr, gc.ac_title As Ac_TitleCr, gc.ac_strid As Ac_StrIDCr ";
            //tSQL += " it.BiltyNo, it.BiltyDate, it.VehicleNo, it.DriverName, it.TransportID ";
            tSQL += " from ct_tran it INNER JOIN gl_ac ga ON it.GLID=ga.ac_id ";
            tSQL += " INNER JOIN gl_ac gc ON it.GLID_Cr=gc.ac_id ";
            tSQL += " LEFT OUTER JOIN cmn_Godown g ON it.GLID_Cr=g.Godown_ac_id ";
            tSQL += " where  it.doc_vt_id=" + clsGVar.CLC.ToString() + " and it.doc_fiscal_id=1";
            tSQL += " and it.doc_id=" + txtLabourContract.Tag.ToString() + ";";
            //and it.doc_status=1 it.ContractNo, 

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "ct_tran");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtLabourContract.Text = (ds.Tables[0].Rows[0]["doc_strid"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["doc_strid"].ToString());
                    //msk_VocDate.Text = (ds.Tables[0].Rows[0]["doc_date"] == DBNull.Value ? DateTime.Now.ToString("T") : ds.Tables[0].Rows[0]["doc_date"].ToString());
                    txtRemarks.Text = (ds.Tables[0].Rows[0]["doc_remarks"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["doc_remarks"].ToString());
                    msk_AccountIDDr.Text = (ds.Tables[0].Rows[0]["Ac_StrID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_StrID"].ToString());
                    lblAccountNameDr.Text = (ds.Tables[0].Rows[0]["Ac_Title"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_Title"].ToString());
                    msk_AccountIDDr.Tag = (ds.Tables[0].Rows[0]["GLID"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["GLID"].ToString());

                    msk_AccountIDCr.Text = (ds.Tables[0].Rows[0]["Ac_StrIDCr"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_StrIDCr"].ToString());
                    lblAccountNameCr.Text = (ds.Tables[0].Rows[0]["Ac_TitleCr"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ac_TitleCr"].ToString());
                    msk_AccountIDCr.Tag = (ds.Tables[0].Rows[0]["GLID_Cr"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["GLID_Cr"].ToString());

                    //txtLabourContract.Text = (ds.Tables[0].Rows[0]["ContractNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ContractNo"].ToString());
                    //txtWasteContract.Text = (ds.Tables[0].Rows[0]["ContractNoWaste"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ContractNoWaste"].ToString());
                    cboGodown.SelectedIndex = clsSetCombo.Set_ComboBox(cboGodown, Convert.ToInt16(ds.Tables[0].Rows[0]["Godown_ID"].ToString()));
                    cboTransType.SelectedIndex = clsSetCombo.Set_ComboBox(cboTransType, Convert.ToInt16(ds.Tables[0].Rows[0]["ContractStatType"].ToString()));
                    //cboTransTypeW.SelectedIndex = ClassSetCombo.Set_ComboBox(cboTransTypeW, Convert.ToInt16(ds.Tables[0].Rows[0]["ContractStatTypeWaste"].ToString()));

                    //txtBiltyNo.Text = (ds.Tables[0].Rows[0]["BiltyNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BiltyNo"].ToString());
                    //txtBiltyDate.Text = (ds.Tables[0].Rows[0]["BiltyDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BiltyDate"].ToString());
                    //txtVehicleNo.Text = (ds.Tables[0].Rows[0]["VehicleNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["VehicleNo"].ToString());
                    //txtDriverName.Text = (ds.Tables[0].Rows[0]["DriverName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DriverName"].ToString());

                    //int tcboTransportID = 0;
                    //tcboTransportID = Convert.ToInt16(ds.Tables[0].Rows[0]["TransportID"].ToString());
                    //cboTransport.SelectedIndex = ClassSetCombo.Set_ComboBox(cboTransport, tcboTransportID);

                    //if (ds.Tables[0].Rows[0]["Doc_Status"] != DBNull.Value)
                    //{
                    //    chkComplete.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Doc_Status"]);
                    //    //chkIsDisabled.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(3).ToString());
                    //}
                    //else
                    //{
                    //    chkComplete.Checked = false;
                    //}

                    //fEditMod = true;

                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    ds.Clear();
                    //    btn_EnableDisable(true);
                    //}
                    //LoadGridData();
                    //txtManualDoc.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void msk_WasteDr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //    //frmGLAcLookUp();
                    clsGLAcLookUp GLLookUp = new clsGLAcLookUp(msk_WasteDr, this.Text.ToString()); // Only two parameters are going, all other are optional

                    GLLookUp.FindGLID();
            }
        }

        private void msk_WasteCr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //    //frmGLAcLookUp();
                clsGLAcLookUp GLLookUp = new clsGLAcLookUp(msk_WasteCr, this.Text.ToString()); // Only two parameters are going, all other are optional
                GLLookUp.FindGLID();
            }
        }

        private void msk_WasteCr_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void msk_WasteDr_Leave(object sender, EventArgs e)
        {
            if (msk_WasteDr.Text.ToString().Trim('_', ' ', '-') == "")
            {
                MessageBox.Show("GL Code is Empty! Unable to Process...", this.Text.ToString());
                msk_WasteDr.Focus();
            }

            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  
            tSQL = "Select top 1 ac_title, ac_id, ac_strid from gl_ac Where ";
            tSQL += " ac_strid = '" + msk_WasteDr.Text + "';";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "gl_Ac");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblWasteNameDr.Text = dRow.ItemArray.GetValue(0).ToString();
                    msk_WasteDr.Tag = dRow.ItemArray.GetValue(1).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();
                }
                else
                {
                    MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                    msk_WasteDr.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                msk_WasteDr.Focus();
            }
        }

        private void msk_WasteCr_Leave(object sender, EventArgs e)
        {
            if (msk_WasteCr.Text.ToString().Trim('_', ' ', '-') == "")
            {
                MessageBox.Show("GL Code is Empty! Unable to Process...", this.Text.ToString());
                msk_WasteCr.Focus();
            }

            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  
            tSQL = "Select top 1 ac_title, ac_id, ac_strid from gl_ac Where ";
            tSQL += " ac_strid = '" + msk_WasteCr.Text + "';";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "gl_Ac");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblWasteNameCr.Text = dRow.ItemArray.GetValue(0).ToString();
                    msk_WasteCr.Tag = dRow.ItemArray.GetValue(1).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();
                }
                else
                {
                    MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                    msk_WasteCr.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                msk_WasteCr.Focus();
            }

        }

        private void txtItemID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        //private void grdWaste_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (!fGridControl)
        //        {
        //            e.Handled = true;
        //            SendKeys.Send("{TAB}");
        //        }
        //    }

        //    // DELETE
        //    if (e.KeyCode == Keys.Delete)
        //    {
        //        // MessageBox.Show("Delete key is pressed");
        //        //if (grdVoucher.Rows[lLastRow].Cells[(int)GCol.acid].Value == null &&grdWaste.Rows[lLastRow].Cells[(int)GCol.refid].Value == null)
        //        if (!fGridControl)
        //        {
        //            return;
        //        }

        //        if (grdVoucher.Rows.Count > 0)
        //        {
        //            if (MessageBox.Show("Are you sure, really want to Delete row ?", "Delete Row", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //            {
        //                grdWaste.Rows.RemoveAt(grdWaste.CurrentRow.Index);
        //                SumVoc();
        //                return;
        //            }
        //        }
        //    }

        //    // Edit
        //    if (e.KeyCode == Keys.Space)
        //    {

        //        // MessageBox.Show("Delete key is pressed");
        //        //if (grdWaste.Rows[lLastRow].Cells[(int)GCol.acid].Value == null && grdWaste.Rows[lLastRow].Cells[(int)GCol.refid].Value == null)
        //        if (!fGridControl)
        //        {
        //            return;
        //        }

        //        if (grdWaste.Rows.Count > 0)
        //        {
        //            if (fEditMod == true)
        //            {
        //                if (chk_Edit.Checked == false)
        //                {
        //                    return;
        //                }
        //            }
        //            //Current Row
        //            fEditRow = grdWaste.CurrentRow.Index;

        //            txtItemID.Text = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.ItemID].Value.ToString();
        //            lblItemName.Text = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.ItemName].Value.ToString();
        //            cbo_UOM.SelectedIndex = clsSetCombo.Set_ComboBox(cbo_UOM, int.Parse(grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.UOMID].Value.ToString()));
        //            cboGodown.SelectedIndex = clsSetCombo.Set_ComboBox(cboGodown, int.Parse(grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.GodownID].Value.ToString()));

        //            txtQty.Text = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.Qty].Value.ToString();
        //            txtRate.Text = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.Rate].Value.ToString();
        //            txtBundle.Text = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.Bundle].Value.ToString();
        //            lblTotalMeasure.Text = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.MeshTotal].Value.ToString();
        //            lblAmount.Text = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.Amount].Value.ToString();
        //            txtLength.Text = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.Length].Value.ToString();
        //            txtLenDec.Text = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.LenDec].Value.ToString();
        //            txtWidth.Text = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.Width].Value.ToString();
        //            txtWidDec.Text = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.WidDec].Value.ToString();

        //            //ConvBit(pdGv.Rows[i].Cells[j].Value.ToString())
        //            if (grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.isBundle].Value.ToString() == "True")
        //            {
        //                chk_BundleCalc.Checked = true;
        //            }
        //            if (grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.isMesh].Value.ToString() == "True")
        //            {
        //                chk_Mesh.Checked = true;
        //            }

        //            //chk_BundleCalc.Checked = clsDbManager.ConvBit(grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.isBundle].Value.ToString());
        //            //chk_Mesh.Checked = grdWaste.Rows[fEditRow].Cells[(int)GColCsInv.isMesh].Value.ToString();

        //            btn_Add.Text = "&Update";
        //            this.tabControl1.SelectedTab = this.tabControl1.TabPages["InputTrans"];
        //            //this.tabControl1.SelectedTab = this.tabControl1.TabPages["Transaction"];

        //            txtItemID.Focus();

        //        }
        //    }
        //    SumWaste();
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void lblDocID_Click(object sender, EventArgs e)
        {

        }

        private void grdWaste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_SaveNContinue_Click(object sender, EventArgs e)
        {

        }

        private void grdVoucher_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (fEditMod == true)
            {
                if (chk_Edit.Checked == false)
                {
                    //MessageBox.Show("Cell Beign Edit");
                    e.Cancel = true;
                    //grdVoucher.BeginEdit(false);
                    //grdVoucher.CancelRowEdit() = true;
                    //return false;
                }
            }
        }

        private void chk_Edit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void msk_VocDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

    }
}
