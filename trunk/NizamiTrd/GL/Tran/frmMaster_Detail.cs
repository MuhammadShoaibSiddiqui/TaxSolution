using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using System.Data.SqlClient;
//
using CSUST.Data;
using TestFormApp.StringFun01;
// for MaskedTextBox
using JThomas.Controls;
using MSMaskedEditBox;
// for datetimeformat
using System.Globalization;
using Cyotek.Windows.Forms;
using System.IO;
//using TestFormApp.StringFun01;
using TestFormApp.GL.Cls;
using TestFormApp.PrintDataSets;
using TestFormApp.PrintReport;
//using TestFormApp.UC;
// E:\DotNet_Dev_projects\TestFormApp\TestFormApp\TestFormApp\Icons\Images\New folder
// c# - UserControl in VS2010 - properties are not visible in designer ...



//
// Transaction Grid Events
//
// CellClick                    Info: Display cell info.
// CellDoubleClick              ID Lookup
// CellEndEdit                  Check debit, credit values in both cells
// CellFormatting               Format the cell according to numeric format Note: if (!frmLoading)
//                              At startup of form frmLoading = true, when loading is complete the last statement is frmLoading = false;
//                              if (!frmLoading) means loading = false (form has loaded)
// CellValueChanged             Account ID validation
// ColumnWidthChanged           Debit / Credit total allignment ( if (!frmLoading) )
// KeyDown                      Check, Insert, Delete, F8 keys pressed for initiating look and inserting / deleting rows.
// Scroll                       Debit / Credit total column allignment with the grid Debit/Credit columns
// EditingControlShowing        Account ID Numeric Control calls tb_KeyPress
    
namespace TestFormApp.GL.Tran
{
    enum GCol 
    {
        currstatus = 0
        ,tranid = 1,
        snum = 2,
        acid = 3,
        acstrid = 4,
        actitle = 5,
        refid = 6,
        reftitle = 7,
        doctranRem = 8,
        debit = 9,
        credit = 10,
        CbmCol = 11,
        CbmColCountry = 12,
        LastCol = 12

    }
    // to be inserted above glref = 10,

    public partial class frmMaster_Detail : Form
    {
        string fRptTitle = string.Empty;

        DateTime now = DateTime.Now;
        List<string> fManySQL;
        // S
        bool fLoadingImg = false;
        bool fSplitMouseDown = false;
        bool fNewImageLoaded = false;
        int fTErr = 0;                              // Total Errors while Saving.
        int fFormID = 7001;                         // Form ID
        int fCboVal = 0;                            // ComboBox Value for ComboColumn
        bool fSettingCbo = false;                   // ComboColumn setting Mode
        bool fFrmLoading = true;                    // Form is Loading Controls (to accomodate Load event so that first time loading requirement is done)
        bool fFrmEditLoading = false;               // Form is Loaded and Doc is loading data in grid for editing)
        bool fSingleEntryAllowed = false;            // for the time being later set to false.
        bool fGridControl = false;                  // Active Control is Grid (When Got Focus, off when Leave)
        string ErrrMsg = string.Empty;              // To display error message if any.
        bool fDocAlreadyExists = false;             // Check if Doc/voucher already exists (Edit Mode = True, New Mode = false)
        bool fIDConfirmed = false;                  // Account ID is valid and existance in Table is confirmed.
        bool fCellEditMode = false;                 // Cell Edit Mode
        string fLastID = string.Empty;              // Last Voucher/Doc ID (Saved new or modified)
        //
        // Voucher/Doc
        int fDocType = 0;
        int fDocFiscal = 0;
        int fTNOA = 0;                              // Total Number of Attachments.    
        int fTNOT = 0;                              // Total Number of Grid Transactions.
        decimal fDocAmt = 0;                        // Document Amount Debit or Credit for DocMaster Field.
        string fDocWhere = string.Empty;            // Where class for Voucher level
        int fLastRow = 0;                           // Last row number of the grid.
        Int64 fDocID = 0;
        // Look & Feel
        bool ftTIsBalloon = true;
        // DataGridView ComboBox Column
        DataGridViewComboBoxColumn dGVCmb = new DataGridViewComboBoxColumn(); 
        // Attach / Image
        string fImagePath = string.Empty;
        string fImageName = string.Empty;
        string fImageExt = string.Empty;
        string fImageSize = string.Empty;
        // Debug
        bool fDebug = false; 
        //PictureBox[] Shapes;
        //Label[] PicLbl;
        //Image imgThumb = null;
        
        
        //iBAttach.AutoScrol = true;
        //iBAttach.AutoSize = false;

        public frmMaster_Detail()
        {
            InitializeComponent();
            //fRptTitle = pTitle;
            //lblFormTitle.Text = fRptTitle;
        }

        private void frmMaster_Detail_Load(object sender, EventArgs e)
        {
            // atFormLoad
            // tmp
            //mtBookID.Text = "121";
            //mtDocID.Text = "34";
            mtFiscalID.Text = "0";
            // tmp
            this.KeyPreview = true;
            // (Width,Height)
            //this.MinimumSize = new System.Drawing.Size(900, 390);
            this.MinimumSize = new System.Drawing.Size(900, 470);
            this.Size = new System.Drawing.Size(900, 470);

            lblDebug.Visible = false;
            // Mask
            mtBookID.Mask = "0000";
            mtBookID.HidePromptOnLeave = true;
            mtBookID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mtDocID.Mask = "00000000";
            mtDocID.HidePromptOnLeave = true;
            mtDocID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mtDocDate.Mask = "00-00-0000";
            mtDocDate.ValidatingType = typeof(System.DateTime);
            mtDocDate.HidePromptOnLeave = true;
            mtDocDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mtFiscalID.Mask = "000";
            mtFiscalID.HidePromptOnLeave = true;
            mtFiscalID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // Attach
            mtImageOrdering.Mask = "000";
            mtImageOrdering.HidePromptOnLeave = true;
            mtImageOrdering.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //
            textDocRef.MaxLength = 15;
            textDocRemarks.MaxLength = 50;
            // Month Calendar
            pnlCalander.Visible = false;
            //gBMonth.Margin = new System.Windows.Forms.Padding(0);
            mCalendarMain.Margin = new System.Windows.Forms.Padding(0);
            pnlCalander.Margin = new System.Windows.Forms.Padding(0);
            //
            //splitContParent.Margin = new System.Windows.Forms.Padding(0);
            

            //splitContGrid.Margin = new System.Windows.Forms.Padding(0);
            // Pannel Back Color
            pnlDocTop.BackColor = gbDocType.BackColor;
            pnlAttachTop.BackColor = gbDocType.BackColor;
            pnlSigningTop.BackColor = gbDocType.BackColor;
            // Tab Back Color
            tabAttach.BackColor = gbDocType.BackColor;
            tabSigning.BackColor = gbDocType.BackColor;
            tabError.BackColor = gbDocType.BackColor;
            ImageInfoData(false);
            // Tab Attach
            lblHorAttach.BackColor = lblTopLine1.BackColor;
            toolStripAttach.BackColor = gbDocType.BackColor;
            toolStripAttach.Visible = true;

            tabMDtl.TabPages.Remove(tabError);                                  // Tab for display error appeared during save/Delete process
            // button2.Visible = false;

            // Split Container Parent                                       
            splitContParent.Panel1MinSize = 30;                                 //
            splitContParent.SplitterDistance = splitContParent.Panel1MinSize;   //
            // Hidden Buttons
            btn_ShowDetailTop.BackColor = gbDocType.BackColor;
            btn_ShowDetailTop.ForeColor = gbDocType.BackColor;
            btn_FocusGrid.BackColor = gbDocType.BackColor;
            btn_FocusGrid.ForeColor = gbDocType.BackColor;
            //
            //splitContParent.Panel2MinSize = 150; // 150;
            // Split Container Grid
            //splitContGrid.Panel1MinSize = 150;
            //splitContGrid.Panel2MinSize = 50;
            //splitContGrid.FixedPanel = FixedPanel.Panel2;
            //splitContGrid.SplitterDistance = 306; //233;
            //splitContGrid.Panel1.Height = 70;
            // Tab To Display Error
            clsDbManager.SetGridHeader(dGvError,
                4,
                "Tran.#,Reference,ID,Error Message",
                "5,10,12,50",
                "0,0,0,0",
                "T,T,T,T",
                "1,1,1,1",
                "DATA",
                2);
            dGvError.Columns[3].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            // Tab for Signing
            clsDbManager.SetGridHeaderCmb(dGvSigning,
                6,
                "S.#,Signee Title,User ID,Date Time,Status,Signature Remarks",
                "5,20,10,12,12,30",
                "0,0,0,0,0,0",
                "0,0,0,0,0,0",
                "T,T,T,T,T,T",
                "1,1,1,1,1,1",
                "DATA",
                null,
                null,
                null,
                null,
                false,
                2);
            // dGvDetail (Transaction Grid)
            // Color Scheme will be Read from table and will be passed as parameter to the Grid Header
            this.dGvDetail.RowsDefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dGvDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(230)))), ((int)(((byte)(189)))));
            //dGvDetail.AllowUserToResizeRows = false;
            //dGvDetail.RowHeadersVisible = false;                            // Headers at left hand side of the Grid
            //dGvDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //dGvDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // This will change the height of the row header (this is by default)
            //
            // 1 = dGV
            // 2 = Column Total (Total number of Columns for cross verification with other parameters like width, format)
            // 3 = Column Header
            // 4 = Column Width
            // 5 = Column MaxInputLen   // 0 = unlimited, "" for readonly grid
            // 6 = Column Format        // T = Text, N = Numeric, H = Hiden
            // 7 = Column ReadOnly      // 1 = ReadOnly, 0 = Not ReadOnly
            // 8 = Grid Color Scheme    // Default = 1
            // RO 
            string lSQl1 = "select city_id, city_title from " + "geo_city";
                                    lSQl1 += " where ";
                                    lSQl1 += clsGVar.LGCY;
                                    lSQl1 += " order by ordering";

            string lSQl2 = "select country_id, country_title from " + "geo_country";
                                    lSQl2 += " where ";
                                    lSQl2 += clsGVar.LGCY;
                                    lSQl2 += " order by ordering";


            List<string> CmbTableName = new List<string>
            {
                "geo_city,city_id,False",
                "geo_country,country_id,False"
            };
            List<string> CmbFillType = new List<string>
            {
                "Q",
                "Q"
            };
            //
            List<string> CmbQry = new List<string>
            {
                lSQl1,
                lSQl2
            };
            //
            List<string> MtMask = new List<string>
            {
                "00-00-0000",
                "000000"
            };
            //
 

            string lHDR = "";
            lHDR += "Status";                       // 0-   Hiden
            lHDR += ",TranID";                      // 1-   Hiden
            lHDR += ",SN";                          // 2-   
            lHDR += ",AcID";                        // 3-
            lHDR += ",Account";                     // 4-
            lHDR += ",Account Title";               // 5-
            lHDR += ",Reference";                   // 6-
            lHDR += ",Ref Title";                   // 7-
            lHDR += ",Transaction Narration";       // 8-
            lHDR += ",Debit";                       // 9-
            lHDR += ",Credit";                      // 10-
            lHDR += ",Dr/CR";                       // 11
            lHDR += ",Country";                     // 12
            clsDbManager.SetGridHeaderCmb(
                dGvDetail,
                13,
                lHDR,  
                " 2, 2, 4, 4,10,20,10,20,10,10,11,12,13",
                " 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0",
                " 4, 4, 0, 8, 0, 4, 0,20,50,10,10,10,13",
                " H, H, T, H,MT, T,MT, T, T,N2,N2,CB,CB",
                " 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0",
                "DATA",
                MtMask,
                CmbFillType,
                CmbTableName,
                CmbQry,
                false,
                2);
            // 
            //CmbTableName
            //dGvDetail.Columns[(int)GCol.debit].ValueType = typeof(decimal);
            // this.dataGridView1.Columns["itemTotalDataGridViewTextBoxColumn"].ValueType =   typeof(System.Decimal);
            //dGvDetail.AllowUserToAddRows = false;
            //dGvDetail.Columns[(int)GCol.CbmColCountry].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGvDetail.Columns[(int)GCol.CbmColCountry].MinimumWidth = 70;
            //dGvDetail.ShowCellToolTips = false;
            //
            dGvDetail.BorderStyle = BorderStyle.None;
            //lblRullerTopGrid.BackColor = dGvDetail.BackgroundColor;
            //lblRullerBottomGrid.BackColor = dGvDetail.BackgroundColor;
            // btnDetailTop // 255, 128, 128
            btnDetailTop.FlatStyle = FlatStyle.Flat;
            btnDetailTop.ForeColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            btnDetailTop.FlatAppearance.BorderColor = splitContParent.Panel1.BackColor;    // Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); // border color and fore color = same
            btnDetailTop.Anchor  = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnDetailTop.Font = new Font("Arial Unicode MS", 12, FontStyle.Regular);
            btnDetailTop.Text = '\u25BC'.ToString();
            // btnDetailBottom
            btnDetailBottom.FlatStyle = FlatStyle.Flat;
            btnDetailBottom.ForeColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            //btnDetailBottom.FlatAppearance.BorderColor = splitContGrid.Panel2.BackColor;    // Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); // border color and fore color = same
            btnDetailBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnDetailBottom.Font = new Font("Arial Unicode MS", 12, FontStyle.Regular);
            btnDetailBottom.Text = '\u25B2'.ToString();
            // =================
            //LoadSampleData();
            //fDocWhere = " d.doc_book_id = " + mtBookID.Text.ToString(); 
            //fDocWhere += " and d.doc_id = " + mtDocID.Text.ToString();
            //fDocWhere += " and d.doc_type_id = " + fDocType.ToString();
            //fDocWhere += " and d.doc_fiscal_id = " + fDocFiscal.ToString();

            fFrmLoading = false;
            AlligGridTotals();
            //InsertNewRowInGrid();
            sumDebitCredit();
            //
            // ToolTip Style:
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
            tTMDtl.SetToolTip(btn_SaveNContinue, "Alt + e, Save data and continue work on current Voucher/Doc.");
            tTMDtl.SetToolTip(btn_Clear, "Alt + c, Clear all input control/items on this Voucher/Doc.");
            tTMDtl.SetToolTip(btn_Delete, "Alt + d, Delete currently selected Voucher/Doc.");
            tTMDtl.SetToolTip(btn_View, "Alt + v, View Voucher/Doc in report viewer.");
            tTMDtl.SetToolTip(btn_Exit, "Alt + x, Close this form and exit to the Main Form.");
            // ToolTip Other Buttons:
            tTMDtl.SetToolTip(btn_Pin, "Alt + p, Pin the Voucher/Doc Top Header Data. (it will not cleared after the Voucher/Doc is saved)");
            tTMDtl.SetToolTip(btn_Month, "Alt + m, Show / Hide Month view for date input");
            tTMDtl.SetToolTip(btn_ScrollRight, "Alt+Shift + > , Scroll the input data grid towords right side");
            tTMDtl.SetToolTip(btn_ScrollLeft, "Alt + Shift + < , Scroll the input data grid towords left side");
            // ToolTip Input Controls:
            tTMDtl.SetToolTip(mtBookID, "Enter Voucher / Doc Type ID, max. length: " + mtBookID.Mask.ToString().Length + " Numeric digits");
            tTMDtl.SetToolTip(mtFiscalID, "Enter Fiscal / Accounting Period, max. length: " + mtFiscalID.Mask.ToString().Length + " Numeric digits");
            tTMDtl.SetToolTip(mtDocDate, "Date, max. length: " + mtDocDate.Mask.ToString().Length + " Numeric digits");
            tTMDtl.SetToolTip(mtDocID, "Voucher / Doc ID, max. length: " + mtDocID.Mask.ToString().Length + " Numeric digits");
            tTMDtl.SetToolTip(textDocRef, "Optional: Voucher / Doc Reference, max. length: " + textDocRef.MaxLength.ToString() + " Alphanumeric characters");
            tTMDtl.SetToolTip(textDocRemarks, "Optional: Voucher / Doc Remarks/Comments, max. length: " + textDocRemarks.MaxLength.ToString() + " Alphanumeric characters");
            // ToolTip Other Input/Display Controls
            tTMDtl.SetToolTip(lblBookTitle, "Book / Voucher / Doc Type Title");
            tTMDtl.SetToolTip(dGvDetail, "Data Input Grid: Press Rhight Mouse Click for Context Menu Options Or Press 'Insert' for New Row, 'Delete' to Remove row");
            tTMDtl.SetToolTip(lblTTentativeDocID, "Tentative Number for the new Voucher / Doc");
            //mtBookID.Focus(); // not working
            this.ActiveControl = mtBookID;
            // =================
        }
        private void LoadeData()
        {
        //currstatus = 0,
        //tranid = 1,
        //snum = 2,
        //acid = 3,
        //actitle = 4,
        //refid = 5,
        //reftitle = 6,
        //doctranRem = 7,
        //debit = 8,
        //credit = 9,
        //glref = 10,
        //CbmCol = 11
            fFrmEditLoading = true;
            //dGvDetail.Rows[0].Cells[(int)GCol.acid].Value = "18-01-0001";
            //
            // d = Dtl Table
            // ma = Master Account
            // mc = Master City
            //

            string lSQL = "";
            lSQL = "SELECT ";
            lSQL += "  d.SERIAL_NO";                                            // 0-
            lSQL += ", d.SERIAL_ORDER";                                         // 1-
            lSQL += ", 0 as sno ";                                              // 2-
            lSQL += ", ma.ac_id ";                                              // 3-
            lSQL += ", ma.ac_strid";                                            // 4-
            lSQL += ", ma.ac_title";                                            // 5-
            lSQL += ", d.REF_ID";                                               // 6-
            lSQL += ", mc.city_title";                                          // 7-
            lSQL += ", d.NARRATION";                                            // 8-
            lSQL += ", d.DEBIT";                                                // 9-    
            lSQL += ", d.CREDIT";                                               // 10-
            lSQL += ", d.city_id";                                              // 11-
            lSQL += ", d.country_id";                                           // 12-
            //
            lSQL += ", m.doc_id";
            lSQL += ", m.doc_book_id";
            lSQL += ", m.doc_type_id";
            lSQL += ", m.doc_fiscal_id";
            lSQL += ", m.doc_date";
            lSQL += ", m.doc_ref";
            lSQL += ", m.doc_tnot";
            lSQL += ", m.doc_tnoa";
            lSQL += ", m.doc_remarks";
            lSQL += ", m.doc_amt";
            lSQL += ", m.frm_id";
            //
            lSQL += " FROM gl_trandtl d RIGHT OUTER JOIN ";
            lSQL += " gl_tran m ON d.doc_book_id = m.doc_book_id ";
            lSQL += " AND d.doc_id = m.doc_ID ";
            lSQL += " AND d.doc_type_id = m.doc_type_id "; 
            lSQL += " AND d.doc_fiscal_id = m.doc_fiscal_id LEFT OUTER JOIN "; 
            lSQL += " geo_city mc  ON d.REF_ID = mc.city_id LEFT OUTER JOIN ";
            lSQL += " gl_ac ma ON d.AC_ID = ma.ac_id";
            lSQL += " where ";
            lSQL += clsGVar.LGCYd;
            lSQL += " and ";
            lSQL += DocWhere("d.");
            lSQL += " ORDER BY d.doc_id, d.serial_order ";

        //            currstatus = 0,
        //tranid = 1,
        //snum = 2,
        //acid = 3,
        //acstrid = 4,
        //actitle = 5,
        //refid = 6,
        //reftitle = 7,
        //doctranRem = 8,
        //debit = 9,
        //credit = 10,
        //CbmValHiden =11, 
        //CbmCol = 12,
        //CbmColCountry = 13,

            try
            {
                DataRow dRow;
                DataSet Zdtset = clsDbManager.GetData_Set(lSQL, "secgrpfrmperm");

                int lRecCount = Zdtset.Tables[0].Rows.Count;
                //int formid = 0;
                //string formtitle = "";
                if (lRecCount == 0)
                {
                    MessageBox.Show("Doc / Voucher not found, select another.", lblFormTitle.Text.ToString());
                    mtDocID.Focus();
                    return;
                }
                // DocMaster
                //dRow = Zdtset.Tables[0].Rows[0];doc_type_id
                fDocType = Convert.ToInt16(Zdtset.Tables[0].Rows[0]["doc_type_id"].ToString());
                //mtFiscalID.Text = Zdtset.Tables[0].Rows[0]["doc_fiscal_id"].ToString();
                fTNOA = Convert.ToInt16( Zdtset.Tables[0].Rows[0]["doc_tnoa"].ToString());
                textDocRemarks.Text = Zdtset.Tables[0].Rows[0]["doc_remarks"].ToString();
                mtDocDate.Text = Zdtset.Tables[0].Rows[0]["doc_date"].ToString();
                textDocRef.Text = Zdtset.Tables[0].Rows[0]["doc_ref"].ToString();
                //dRow.ItemArray.GetValue["doc_tnoa"].ToString();
                // Delete existing Row/Rows
                dGvDetail.Rows.Clear();
                //
                for (int i = 0; i < lRecCount; i++)
                {
                    dRow = Zdtset.Tables[0].Rows[i];
                    // **** Following Two Rows may get data one time *****
           //         dGvDetail.DataSource = Zdtset.Tables[0];
           //         dGvDetail.Visible = true;
                    // **** Following Two Rows may get data one time *****

                dGvDetail.Rows.Add(
                    dRow.ItemArray.GetValue((int)GCol.currstatus).ToString(),                       // 0-
                    dRow.ItemArray.GetValue((int)GCol.tranid).ToString(),                           // 1-
                    (i + 1).ToString(),                                                             // 2-
                    dRow.ItemArray.GetValue((int)GCol.acid).ToString(),                             // 3-
                    dRow.ItemArray.GetValue((int)GCol.acstrid).ToString(),                          // 4-
                    dRow.ItemArray.GetValue((int)GCol.actitle).ToString(),                          // 5-
                    dRow.ItemArray.GetValue((int)GCol.refid).ToString(),                            // 6-
                    dRow.ItemArray.GetValue((int)GCol.reftitle).ToString(),                         // 7-
                    dRow.ItemArray.GetValue((int)GCol.doctranRem).ToString(),                       // 8-
                    dRow.ItemArray.GetValue((int)GCol.debit).ToString(),                            // 9-
                    dRow.ItemArray.GetValue((int)GCol.credit).ToString(),                           // 10-
                    Convert.ToInt32(dRow.ItemArray.GetValue((int)GCol.CbmCol).ToString()),          // 11-
                    Convert.ToInt32(dRow.ItemArray.GetValue((int)GCol.CbmColCountry).ToString())    // 12-
                    );

                    //dGvDetail.Columns[1].ReadOnly = true;  // working

                }
                //
                fFrmEditLoading = false;
                sumDebitCredit();
                //fTNOA = 1;
                EDButtons(false);
                dGvDetail.Focus();

            }
            catch 
            {
                MessageBox.Show("Exception: Grid Loading...",lblFormTitle.Text.ToString());
            }
        }
        private void EDButtons(bool pFlage)
        {
            if (pFlage)
            {
                mtBookID.Enabled = true;
                mtDocID.Enabled = true;
                mtFiscalID.Enabled = true;
            }
            else
            {
                mtBookID.Enabled = false;
                mtDocID.Enabled = false;
                mtFiscalID.Enabled = false;
            }
        }
        private void btnDetailTop_Click(object sender, EventArgs e)
        {
            if (btnDetailTop.Text.ToString() == '\u25BC'.ToString())    // Down Arrow
            {
                // at Minimum Width
                splitContParent.SplitterDistance = 100;
                btnDetailTop.Font = new Font("Arial Unicode MS", 14, FontStyle.Regular);
                btnDetailTop.Text = '\u25B2'.ToString();
            }
            else
            {
                // at Maximum Width, Already expanded
               splitContParent.SplitterDistance = splitContParent.Panel1MinSize;
               btnDetailTop.Font = new Font("Arial Unicode MS", 14, FontStyle.Regular);
               btnDetailTop.Text = '\u25BC'.ToString();
            }

        }

        private void btnDetailBottom_Click(object sender, EventArgs e)
        {
            if (btnDetailTop.Text.ToString() == '\u25B2'.ToString())    // Top Button: Presently Up Arrow indicating Already Expanded, the action will now reduce distance
            {
                return;
            }
            //if (btnDetailBottom.Text.ToString() == '\u25B2'.ToString()) // Bottom Button: Up Arrow
            //{
            //  splitContGrid.SplitterDistance = 180;
            //    btnDetailBottom.Font = new Font("Arial Unicode MS", 14, FontStyle.Regular);
            //    btnDetailBottom.Text = '\u25BC'.ToString();
            //}
            //else
            //{
                //splitContGrid.SplitterDistance = 233; // splitContGrid.Panel1MinSize;
                //btnDetailBottom.Font = new Font("Arial Unicode MS", 14, FontStyle.Regular);
                //btnDetailBottom.Text = '\u25B2'.ToString();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dGvDetail.Rows.Clear();
            LoadeData();
            AlligGridTotals();
            
            //label2.Text = "SplitercontParent: " + splitContParent.SplitterDistance.ToString() +"\n\r";
            //label2.Text += "SplitterContGrid: " + splitContGrid.SplitterDistance.ToString() + "\n\r";
            //label2.Text += "Form Size: Width: " + this.Size.Width.ToString() + " Height: " + this.Size.Height.ToString();
        }
        private void AlligGridTotals()
        {
            //var cellRectangle = dGvDetail.GetCellDisplayRectangle(4, 1, true);
            //label2.Visible = true;
            //label2.Text = "Top Left " + cellRectangle.Left.ToString() + " Top: " + cellRectangle.Top.ToString() + " Bottom Right: " + cellRectangle.Right.ToString() + " Bottom: " + cellRectangle.Bottom.ToString();
            //lblTotalDebit.Left = cellRectangle.Left;
            //lblTotalDebit.Width = Convert.ToInt32(cellRectangle.Right.ToString()) - Convert.ToInt32(cellRectangle.Left.ToString());
            //label2.Visible = true;
            //
            if (dGvDetail.Rows.Count > 0)
            {
                // public Rectangle GetCellDisplayRectangle(int columnIndex, int rowIndex, bool cutOverflow )
                // ArgumentOutOfRangeException
                // columnIndex is less than -1 or greater than the number of columns in the control minus 1.
                // Or
                // rowIndex is less than -1 or greater than the number of rows in the control minus 1. 

                // Column
                if (dGvDetail.CurrentCell.ColumnIndex == -1)
                {
                    return;
                }
                // Row
                if (dGvDetail.CurrentCell.RowIndex == -1)
                {
                    return;
                }

                //var cellRectangle = dGvDetail.GetCellDisplayRectangle((int)GCol.debit, 1, true);  // raising above exception
                // instead of '1' used this: dGvDetail.CurrentCell.RowIndex the problem is solved.
                var cellRectangle = dGvDetail.GetCellDisplayRectangle((int)GCol.debit, dGvDetail.CurrentCell.RowIndex, true);
                lblTotalDebit.Left = cellRectangle.Left;
                lblTotalDebit.Width = Convert.ToInt32(cellRectangle.Right.ToString()) - Convert.ToInt32(cellRectangle.Left.ToString());
                //
                //label2.Text = "Top Left " + cellRectangle.Left.ToString() + " Top: " + cellRectangle.Top.ToString() + " Bottom Right: " + cellRectangle.Right.ToString() + " Bottom: " + cellRectangle.Bottom.ToString();
                //
                //var cellRectangle1 = dGvDetail.GetCellDisplayRectangle((int)GCol.credit, 1, true);
                var cellRectangle1 = dGvDetail.GetCellDisplayRectangle((int)GCol.credit, dGvDetail.CurrentCell.RowIndex, true);
                lblTotalCredit.Left = cellRectangle1.Left;
                lblTotalCredit.Width = Convert.ToInt32(cellRectangle1.Right.ToString()) - Convert.ToInt32(cellRectangle1.Left.ToString());
                //
                //label2.Text += " Two: Top Left " + cellRectangle1.Left.ToString() + " Top: " + cellRectangle1.Top.ToString() + " Bottom Right: " + cellRectangle1.Right.ToString() + " Bottom: " + cellRectangle1.Bottom.ToString();
            }
        }
        //
        private void btnPin_Click(object sender, EventArgs e)
        {
            if (btn_Pin.Text.ToString() == "Pi&n")
            {
                if (mtBookID.Text.ToString().Trim(' ', '-') == "")
                {
                    MessageBox.Show("Book ID empty or blank, select one and try again.", "Pin: " + lblFormTitle.Text.ToString());
                    mtBookID.Focus();
                    return;
                }
                if (mtDocDate.Text.ToString().Trim(' ', '-') == "")
                {
                    MessageBox.Show("Doc/Voucher Date empty or blank, select one and try again.", "Pin: " + lblFormTitle.Text.ToString());
                    mtDocDate.Focus();
                    return;
                }
                if (mtFiscalID.Text.ToString().Trim(' ', '-') == "")
                {
                    MessageBox.Show("Doc/Voucher Fiscal Period empty or blank, select one and try again.", "Pin: " + lblFormTitle.Text.ToString());
                    mtFiscalID.Focus();
                    return;
                }

                gbDocType.Enabled = false;
                btn_Pin.Text = "&Un-Pin";
                btn_Pin.Image = TestFormApp.Properties.Resources.BaBa_tiny_pinned;
             }
            else
            {
                gbDocType.Enabled = true;
                btn_Pin.Image = TestFormApp.Properties.Resources.BaBa_tiny_pin;
                btn_Pin.Text = "Pi&n";
            }
        }

        private decimal sumDecimal(DataGridView pdGV, int pCol, bool pCheckEmptyRow = false)
        {
            bool bcheck = false;
            decimal rtnVal = 0;
            decimal outValue = 0;
 
            if (pdGV.RowCount == 0)
            {
                return rtnVal;
            }
            else
            {
                for (int i = 0; i < pdGV.RowCount; i++)
                {
                    if (pdGV.Rows[i].Cells[pCol].Value != null)
                    {
                        bcheck = decimal.TryParse(pdGV.Rows[i].Cells[pCol].Value.ToString(), out outValue);
                        if (bcheck)
                        {
                            rtnVal += outValue;
                        }

                        // Check if compulsary columns are filled.
                        //if (!pCheckEmptyRow)
                        //{
                        //    bcheck = decimal.TryParse(pdGV.Rows[i].Cells[pCol].Value.ToString(), out outValue);
                        //    if (bcheck)
                        //    {
                        //        rtnVal += outValue;
                        //    }
                        //} // if pCheckEmptyRow
                        //else
                        //{
                        //    if ((pdGV.Rows[i].Cells[(int)GCol.acstrid].Value.ToString()).Trim(' ', '-') != "" && (pdGV.Rows[i].Cells[(int)GCol.refid].Value.ToString()).Trim(' ', '-') != "")
                        //    {
                        //        bcheck = decimal.TryParse(pdGV.Rows[i].Cells[pCol].Value.ToString(), out outValue);
                        //        if (bcheck)
                        //        {
                        //            rtnVal += outValue;
                        //        }
                        //    }
                        //} // else if pCheckEmptyRow
                    } // if != null
                } // for loop
            }

            return rtnVal;
        }

        private void sumDebitCredit()
        {
            lblTotalDebit.Text = (sumDecimal(dGvDetail, (int)GCol.debit)).ToString();
            lblTotalCredit.Text = (sumDecimal(dGvDetail, (int)GCol.credit)).ToString();
        }
        //private void dGvDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    string str = string.Empty;
        //    //// Important: the bellowing was disturbing decimal control therefore commented. BBG
        //    //if (!fFrmLoading)
        //    //{
        //    //    return;
        //    //}
        //    ////DataGridViewCellStyle _myStyle = new DataGridViewCellStyle();
        //    ////_myStyle.BackColor = Color.Pink;
        //    //decimal tvalue = 0;
        //    //if (e.Value != null)
        //    //{
        //    //    if (e.ColumnIndex == (int)GCol.debit || e.ColumnIndex == (int)GCol.credit)
        //    //    {
        //    //        // Not workable: It change on mouse over: also give exception when mouse over unknown row ?
        //    //        // MessageBox.Show("column: 2 = " + dataGridView1.CurrentCell.ColumnIndex.ToString());
        //    //        lblDebug.Text = "column: " + e.ColumnIndex.ToString() + " Row: " + e.RowIndex.ToString() + " Value: " + e.Value.ToString();
        //    //        //   Shifted the bellow portion at key Enter  
        //    //        bool bChecking = decimal.TryParse(e.Value.ToString(), out tvalue);
        //    //        if (bChecking)
        //    //        {
        //    //            e.Value = String.Format("{0:N2}", tvalue);
        //    //        }

        //    //        //if (e.ColumnIndex == 0)
        //    //        //{
        //    //        //    if (e.Value != null)
        //    //        //    {
        //    //        //        e.Value = e.Value.ToString().ToUpper();
        //    //        //        e.FormattingApplied = true;
        //    //        //    }
        //    //        //}
        //    //    }
        //    //} // End if !=null
        //    //// End of Method
        //}

        //private void dGvDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    // Note: cell formating event is fired before this event.
        //    // Control Decimal in the column
        //    int colIndex = this.dGvDetail.CurrentCell.ColumnIndex;
        //    if (colIndex == (int)GCol.acid || colIndex == (int)GCol.refid)        // GCol Enumerator
        //    {
        //        if (e.Control is TextBox)
        //        {
        //            TextBox tb = e.Control as TextBox;
        //            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);           // User defined event
        //        } // End if is Textbox
        //    } // End if            
        //    // End Mothod
        //}

// ==============================================================================================================
        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            // bool lCellEditMode = false; // Should be in 

            //if (dGvDetail.IsCurrentCellInEditMode)
            //{
            //    fCellEditMode = true;
            //}
            
            string str = string.Empty;
            string str1 = string.Empty;
            str = ((TextBox)sender).Text.ToString();
            str1 = ((TextBox)sender).Parent.Name.ToString();
            if (Char.IsControl(e.KeyChar) == false)                 // To check if a control character is present like \b, \t etc
            {
                if (!Char.IsDigit(e.KeyChar))
                {

                    if (fCellEditMode == true)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }// 
            else
            {
                // shift the following to the else part
                if (e.KeyChar != '\b') //allow the backspace key
                {
                    e.Handled = true;
                }

            } // if controle

        }
//================================================================================================================
        
        
        //void tb_KeyPressRes(object sender, KeyPressEventArgs e)
        //{
        //    bool lCellEditMode = false;

        //    if (dGvDetail.IsCurrentCellInEditMode)
        //    {
        //        lCellEditMode = true;
        //    }
        //    string str = string.Empty;
        //    str = ((TextBox)sender).Text.ToString();
        //    //string str = txtAge.Text;                             //  User Control
        //    int len = str.Length;                                   // The length is before the current input
        //    int index1 = 0;
        //    int index = 0;
        //    int dcml = 2;                                           // 2 indeicates the Deccimal Points Needed   (User Defined)
        //    if (str.Contains('.'))
        //    {
        //        index1 = str.IndexOf('.');                           // first location of "."    indexOf = 0 based
        //        index = len - index1;                                // 999.88 len = 6, index = 3 6 - 3  = 3 // when 3 "((Char.IsDigit(e.KeyChar)) && (index <= dcml))" fails
        //    }
        //    if (Char.IsControl(e.KeyChar) == false)                 // To check if a control character is present like \b, \t etc
        //    {
        //        if (((Char.IsDigit(e.KeyChar)) && (index <= dcml)) || ((e.KeyChar == '.') && (!(str.Contains('.')))))
        //        {   // part-1 digit and less then 2                     Part-2 = "." and not previously contain "."

        //            // ok
        //        }
        //        else
        //        {
        //            if ((e.KeyChar == '.') && (str.Contains('.')))
        //            {
        //                e.Handled = true;
        //                return;
        //            }
        //            if (index >= dcml)                           // The length is before the current input
        //            {
        //                e.Handled = true;
        //                return;
        //            }
        //            if (!Char.IsDigit(e.KeyChar))
        //            {
        //                e.Handled = true;
        //                return;
        //            }
        //            // shift the following to the else part
        //            //if (e.KeyChar != '\b') //allow the backspace key
        //            //{
        //            //    e.Handled = true;
        //            //}
        //        }
        //    }// if control
        //    else
        //    {
        //        // shift the following to the else part
        //        if (e.KeyChar != '\b') //allow the backspace key
        //        {
        //            e.Handled = true;
        //        }
            
        //    } // if controle
        //    //// only allow one decimal point 
        //    //if (e.KeyChar == '.'
        //    //    && (sender as TextBox).Text.IndexOf('.') > -1)
        //    //{
        //    //    e.Handled = true;
        //    //} 


        //    //string str = string.Empty;
        //    //str = ((TextBox)sender).Text.ToString();

        //    //=======================================================================================
        //        //bool lContainDot = false;
        //        //if ( ((TextBox)sender).Text.Contains(Convert.ToString((char)46)) && e.KeyChar == (char)46 )
        //        //{
        //        //    lContainDot = true;
        //        //}

        //        //// if (!(char.IsDigit(e.KeyChar)))      // Working but not accepting decimal point
        //        //if (!char.IsNumber(e.KeyChar))          // same as above Ref: http://www.daniweb.com/software-development/csharp/threads/226941/enter-only-number-in-datagridview
        //        //{
        //        //    if (e.KeyChar == '.' && lContainDot)
        //        //    {
        //        //        e.Handled = true;
        //        //        return;
        //        //    }
        //        //    if (e.KeyChar != '\b' ) //allow the backspace key
        //        //    {
        //        //        if (e.KeyChar != '.')      // if (richTextBox1.Text.Contains('.')) nl e.Handled = true; 

        //        //        e.Handled = true;
        //        //    }
        //        //}
        //    // End Method // c# datagridview conrol numeric only column
        //}

        private void dGvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // ID Lookup
            //
            if (dGvDetail.CurrentCell.ColumnIndex == (int)GCol.acstrid || dGvDetail.CurrentCell.ColumnIndex == (int)GCol.refid)
            {
                if (dGvDetail.CurrentCell.ColumnIndex == (int)GCol.acstrid)
                {
                    GridLookUpAc("Double Click: AcID", dGvDetail.CurrentCell.RowIndex, dGvDetail.CurrentCell.ColumnIndex);
                    textAlert.Text = "Account ID double Click " + now.ToString("T");
                }
                else
                {
                    // to be changed
                    GridLookUpCity("Double Click: RefID", dGvDetail.CurrentCell.RowIndex, dGvDetail.CurrentCell.ColumnIndex);
                    textAlert.Text = "RefID ID double Click " + now.ToString("T");
                }
            }
        }
        private void GridLookUpCity(string pSource, int pRow, int pCol)
        {
            // MessageBox.Show("Lookup Source: " + pSource);

            // 1- KeyField
            // 2- Field List
            // 3- Table Name
            // 4- Form Title
            // 5- Default Find Field (Int) 0,1,2,3 etc Default = 1 = title field
            // 6- Grid Title List
            // 7- Grid Title Width
            // 8- Grid Title format T = Text, N = Numeric, N2 = 2 Decimal & Numeric etc
            // 9- Bool One Table = True, More Then One = False
            // 10 Join String Otherwise Empty String.
            // 11 Optional Where
            // 11 Return Control Type TextBox or MaskedTextBox Default mtextBox
            //
            frmLookUp sForm = new frmLookUp(
                    "city_id",
                    "city_title,city_st,Ordering",
                    "geo_city",
                    "City ID",
                    1,
                    "ID,City Title,Short,Ordering",
                    "10,20,20,20",
                    "T,T,T,T",
                    true,
                    "",
                    ""
                    );
            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (tmtext.Text != null)
            {
                if (tmtext.Text.ToString() == "" || tmtext.Text.ToString() == string.Empty)
                {
                    return;
                }
                dGvDetail[pCol, pRow].Value = tmtext.Text.ToString();
                //System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        private void GridLookUpAc(
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
                    "ac_title,ac_atitle,Ordering",
                    "gl_ac",
                    "GL COA",
                    1,
                    "ID,Account Title,Account Alternate Title,Ordering",
                    "10,20,20,20",
                    "T,T,T,T",
                    true,
                    "",
                    "istran = 1"
                    );
            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (tmtext.Text != null)
            {
                if (tmtext.Text.ToString() == "" || tmtext.Text.ToString() == string.Empty)
                {
                    return;
                }
                dGvDetail[pCol, pRow].Value = tmtext.Text.ToString();
                //System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }



        private void mTextLookUp()
        {

            MessageBox.Show("Lookup Source: " + "Blank");

            frmLookUp sForm = new frmLookUp("driver_id", "driver_title,driver_st,isdisabled", "driver", "Test Form", 1, "drivertitle,driverst,isdisabled", "4,50,8", "T,T,T", true, "");
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDatamText);
            sForm.ShowDialog();
            if (tmtext.Text != null)
            {
                if (tmtext.Text.ToString() == "" || tmtext.Text.ToString() == string.Empty)
                {
                    return;
                }
                //dGvDetail[pCol, pRow].Value = tmtext.Text.ToString();
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        
        }
        private void PassData(object sender)
        {
            tmtext.Text = ((MaskedTextBox)sender).Text;
        }
        private void PassDatamText(object sender)
        {
            mtBookID.Text = ((MaskedTextBox)sender).Text;
        }

        private void dGvDetail_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Grid KeyDown");
            // Insert New Row
            int lLastRow = dGvDetail.Rows.Count - 1;
            //bool lEmptyRow = false;
            if (e.KeyCode == Keys.Space)
            {
                //MessageBox.Show("You have pressed a spacebar...");
                pnlEntry.Visible = true;
                
                return;
            }
            // INSERT
            if (e.KeyCode == Keys.Insert)
            {

                //if (dGvDetail.Rows.Count > 0)
                //{
                //    if (dGvDetail.Rows[lLastRow].Cells[(int)GCol.acstrid].Value == null || dGvDetail.Rows[lLastRow].Cells[(int)GCol.refid].Value == null) 
                //    {
                //        lEmptyRow = true;
                //    }
                //    if (dGvDetail.Rows[lLastRow].Cells[(int)GCol.CbmCol].Value == null || dGvDetail.Rows[lLastRow].Cells[(int)GCol.CbmColCountry].Value == null)
                //    {
                //        lEmptyRow = true;
                //    }
                //    if (!lEmptyRow)
                //    {
                //        InsertNewRowInGrid();
                //        //dGvDetail.Rows.Add((lLastRow + 2).ToString());
                //        //dGvDetail.CurrentCell = dGvDetail.Rows[lLastRow + 1].Cells[(int)GCol.acid];
                //        // dGvDetail.Rows[rowindex].Cells[columnindex].Selected = true;                 // still to be checked

                //        // dGvDetail.BeginEdit(true)                                                    // Optional

                //        return;
                //    }
                //}

                    //dGvDetail.Rows[dGvDetail.Rows.Count - 1].Selected = true; 
                    //dGvDetail.CurrentCell = dGvDetail.Rows[dGvDetail.Rows.Count - 1].Cells[1] 
                    //.ClearSelection();//If you want 
 
                    //int nRowIndex = dataGridView1.Rows.Count - 1; 
                    //int nColumnIndex = 3; 
 
                    //dataGridView1.Rows[nRowIndex].Selected = true; 
                    //dataGridView1.Rows[nRowIndex].Cells[nColumnIndex].Selected = true; 
 
                    ////In case if you want to scroll down as well. 
                    //dataGridView1.FirstDisplayedScrollingRowIndex = nRowIndex; 
                    //=========================================================================
                    //if (dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count) { dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Selected = true; }
                // last row
                //if (!DocValid(false))
                //{
                //    return;
                //}
                //if (dGvDetail.Rows.Count > 0)
                //{
                  if (GridOpr.GridRowInsertValid(dGvDetail, textAlert, ((int)GCol.acstrid).ToString() + "," + ((int)GCol.refid).ToString(), "MT,MT") )
                  {
                    InsertNewRowInGrid();
                  }
                  //return;
                //}
                //if (dGvDetail.Rows.Count > 0)
                //{
                //    if (GridValid())
                //    {
                //        InsertNewRowInGrid();
                //    }
                //    return;                    
                //}
            }
            // DELETE
            if (e.KeyCode == Keys.Delete)
            {
                // MessageBox.Show("Delete key is pressed");
                //if (dGvDetail.Rows[lLastRow].Cells[(int)GCol.acid].Value == null && dGvDetail.Rows[lLastRow].Cells[(int)GCol.refid].Value == null)
              if (dGvDetail.Rows.Count > 0)
              {
                if (dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.acstrid].Value == null && dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.refid].Value == null)
                {
                  //lEmptyRow = true;
                  //dGvDetail.Rows[lLastRow].Selected = true;
                  //dGvDetail.Rows.Remove();
                  //dGvDetail.Rows.RemoveAt(dGvDetail.SelectedRows[0].Index);
                  dGvDetail.Rows.RemoveAt(dGvDetail.CurrentRow.Index);
                  return;
                }
                else
                {
                  //lEmptyRow = false;
                  if (MessageBox.Show("Are you sure, really want to Delete row ?", "Delete Row", MessageBoxButtons.OKCancel) == DialogResult.OK)
                  {
                    dGvDetail.Rows.RemoveAt(dGvDetail.CurrentRow.Index);
                    return;
                  }
                }
              }

            }

            if (e.KeyCode == Keys.F8)
            {
                if (dGvDetail.CurrentCell.ColumnIndex == (int)GCol.acstrid )
                {
                    //MessageBox.Show("Grid: childSplitGrid = dGvDetail Crr row = " + dGvDetail.CurrentCell.RowIndex.ToString());
                    // dGvDetail.CurrentRow.Index.ToString() // is ok: now used: dGvDetail.CurrentCell.RowIndex.ToString()
                    tmtext.Text = string.Empty;
                    GridLookUpAc("F8 Key: ", (int)dGvDetail.CurrentCell.RowIndex, (int)dGvDetail.CurrentCell.ColumnIndex);
                }
                else if (dGvDetail.CurrentCell.ColumnIndex == (int)GCol.refid)
                {
                    tmtext.Text = string.Empty;
                    GridLookUpCity("F8 Key: ", (int)dGvDetail.CurrentCell.RowIndex, (int)dGvDetail.CurrentCell.ColumnIndex);
                }
            }
        }
        private void InsertNewRowInGrid()
        {

            int lLastRow = dGvDetail.Rows.Count - 1;        // When no transaction it is -1
            //dGvDetail.Rows.Add();                           // A blank row is added: Previously it was: dGvDetail.Rows.Add( "","",(lLastRow + 2).ToString() )
            //dGvDetail.CurrentCell = dGvDetail.Rows[lLastRow + 1].Cells[(int)GCol.snum];
            //dGvDetail.CurrentCell.Value = (lLastRow + 2).ToString();
            //dGvDetail.CurrentCell = dGvDetail.Rows[lLastRow + 1].Cells[(int)GCol.acid];
            // above is working
            //

            int n = dGvDetail.Rows.Add();
            dGvDetail.CurrentCell = dGvDetail.Rows[n].Cells[(int)GCol.snum];
            dGvDetail.CurrentCell.Value = (n+1).ToString();                     // Serial Number at first column
            dGvDetail.CurrentCell = dGvDetail.Rows[n].Cells[(int)GCol.acstrid];

        }
        private void mtBookID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                //tStextAlert.Text = " in Grid cell";
                //MessageBox.Show("mTextBox = dGvDetail Crr row = else part");
                // dGvDetail.CurrentRow.Index.ToString() // is ok: now used: dGvDetail.CurrentCell.RowIndex.ToString()
                tmtext.Text = string.Empty;
                mTextLookUp();
            }
        }
        /*
                    // Check Debit, Credit Both > 0
                    //pdGVMDtl.Rows[i].Cells[pCol].Value.ToString();
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
                        lDecimalcheck = decimal.TryParse(pdGVMDtl.Rows[i].Cells[pCrCol].Value.ToString(), out outValue);    // Debit Column
                        if (lDecimalcheck)
                        {
                            lCredit = outValue;
                        }
                    }
                    //
                    if (lDebit > 0 && lCredit > 0)
                    {
                        dGvError.Rows.Add("Grid Tran. " + (i + 1).ToString(), "Debit/Credit", "", "Both: Debiot: " + lDebit.ToString() + " and Credit: " + lCredit.ToString() + " Contain values, please select only one ...");
                        rtnValue = false;
                    }

        */
        private void dGvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool lDecimalcheck = false;
            decimal outValue = 0;
            //decimal lDebit = 0;
            //decimal lCredit = 0;

            if (e.ColumnIndex == (int)GCol.debit || e.ColumnIndex == (int)GCol.credit)
            {
                if (e.ColumnIndex == (int)GCol.debit)
                {
                    // First check if current input value is 0
                    if (dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.debit].Value != null)
                    {
                        lDecimalcheck = decimal.TryParse(dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.debit].Value.ToString(), out outValue);    // Debit Column if 0
                        if (lDecimalcheck)
                        {
                            if (outValue == 0)
                            {
                                sumDebitCredit();
                                return;
                            }
                            else
                            {
                                dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.credit].Value = string.Empty;     // Set Credit value to empty
                                sumDebitCredit();
                            }
                        }
                    }
                    //// Check Credit Value
                    //if (dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.credit].Value != null)
                    //{
                    //    lDecimalcheck = decimal.TryParse(dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.credit].Value.ToString(), out outValue);    // Credit Column
                    //    if (lDecimalcheck)
                    //    {
                    //        dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.credit].Value = string.Empty;     // Set Credit value to empty
                    //    }
                    //}

                }  // End If Input in Debit
                else
                   // Start if Input in Credit
                {
                    // First check if current input value is 0
                    if (dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.credit].Value != null)
                    {
                        lDecimalcheck = decimal.TryParse(dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.credit].Value.ToString(), out outValue);    // Credit Column if 0
                        if (lDecimalcheck)
                        {
                            if (outValue == 0)
                            {
                                sumDebitCredit();
                                return;
                            }
                            else
                            {
                                dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.debit].Value = string.Empty;     // Set Debit value to empty
                                sumDebitCredit();
                            }
                        }
                    }
                    //// Check Debit Value
                    //if (dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.debit].Value != null)
                    //{
                    //    lDecimalcheck = decimal.TryParse(dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.debit].Value.ToString(), out outValue);    // Debit Column
                    //    if (lDecimalcheck)
                    //    {
                    //        dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.debit].Value = string.Empty;     // Set Debit value to empty
                    //    }
                    //} 
                } // End if input in Debit
                //sumDebitCredit();
            }
            else if (e.ColumnIndex == (int)GCol.acstrid || e.ColumnIndex == (int)GCol.refid)
            {
                //if (e.ColumnIndex == (int)GCol.refid)
                //{
                //    if (fIDConfirmed)
                //    {
                //        MessageBox.Show("id is confirmed");
                //        dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "lTitle";  // when we change again cellValuechanged event is trigred
                //        dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Selected = true;
                //    }
                //}
            }
           
        }

        private void frmMaster_Detail_KeyDown(object sender, KeyEventArgs e)
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

        }

        private void dGvDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Account ID Validation
            if (!fFrmLoading)
            {
                if (e.ColumnIndex == (int)GCol.acstrid || e.ColumnIndex == (int)GCol.refid)
                {

                    if (e.ColumnIndex == (int)GCol.acstrid)
                    {
                        if (dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                        {
                            // dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "" 
                            if ((dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Trim(' ', '-') == "")
                            {
                                dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "Account ID is required ";
                                return;
                            }
                        }
                        else
                        {
                            dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "Null Value: Account ID is required ";
                            return;
                        }
                    }
                    else
                    {
                        // Ref ID
                        if (dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                        {
                            //if (dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "0")
                            if ((dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Trim(' ', '-') == "")
                            {
                                dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "Ref ID is required ";
                                return;
                            }
                        }
                        else
                        {
                            dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "Null Value: Reference ID is required ";
                            return;
                        }

                    }

                    if (e.ColumnIndex == (int)GCol.acstrid)
                    {
                        // Validate GL ID
                        fIDConfirmed = false;
                        string lTitle = "";
                        //lTitle = classDS.GetTitle("city", "city_id", "city_title", Convert.ToInt64(dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                        if (dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                        {
                            lTitle = clsDbManager.GetTitleAc(
                            "gl_ac",
                            "ac_strid",
                            "ac_title",
                            dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
                            );
                            if (lTitle == "ID not Found...")
                            {
                                if (!fFrmEditLoading)
                                {
                                    MessageBox.Show("Account ID not found.....", "Ac ID");
                                }
                                dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "Reference Title Not Found ";
                                //dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                                return;
                            }
                            fIDConfirmed = true;
                            dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = lTitle;  // when we change again cellValuechanged event is trigred
                        }
                        else
                        { 
                            // if id == null
                            dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "Reference Title Not Found/null";
                        }
                    }
                    else
                    {
                        // Validate Job ID
                        // string GetTitle(string pTable, string pKeyFieldID, string pKeyFieldTitle, int searchValue, string strCustom = "")
                        fIDConfirmed = false;
                        string lTitle = "";
                        lTitle = clsDbManager.GetTitle(
                            "geo_city", 
                            "city_id", 
                            "city_title", 
                            Convert.ToInt64( dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) 
                            );
                        //if (dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "999")
                        if (lTitle == "ID not Found...")
                        {
                            if (!fFrmEditLoading)
                            {
                                MessageBox.Show("Reference ID not found.....", "Ref ID");
                            }
                            dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "Reference Title Not Found ";
                            //dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                            return;
                        }
                        string abc = "Current Col: " + e.ColumnIndex.ToString() + " Row: " + e.RowIndex.ToString();
                        fIDConfirmed = true;
                        dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = lTitle;  // when we change again cellValuechanged event is trigred
                        //dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                        //dGvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Selected = true;
                        //dGvDetail.BeginEdit(true);
                    }
                } // END acid, refid
                else if ((e.ColumnIndex == (int)GCol.actitle || e.ColumnIndex == (int)GCol.reftitle))
                {
                    dGvDetail.ClearSelection();
                    if (e.ColumnIndex == (int)GCol.reftitle)
                    {
                        if (e.ColumnIndex == (int)GCol.reftitle && fIDConfirmed)
                        {
                            dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.reftitle + 1].Selected = true;
                            dGvDetail.CurrentCell = dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.reftitle + 1];
                        }
                        else
                        {
                            dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.refid].Selected = true;
                            dGvDetail.CurrentCell = dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.refid];
                        }
                    }
                    else
                    {
                        if (e.ColumnIndex == (int)GCol.actitle && fIDConfirmed)
                        {
                            dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.actitle + 1].Selected = true;
                            dGvDetail.CurrentCell = dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.actitle + 1];
                        }
                        else
                        {
                            dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.acstrid].Selected = true;
                            dGvDetail.CurrentCell = dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.acstrid];
                        }
                    }
                } // end ac title, ref title

            }
        }

        private void dGvDetail_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!fFrmLoading)
            {
                AlligGridTotals();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dGvDetail.Rows.Count > 1)
            {
                if (MessageBox.Show("Are You Sure To Clear the Form ?", lblFormTitle.Text.ToString(), MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                   return;
                }
            }
            EDButtons(true);
            ClearThisForm();
        }

        private void frmMaster_Detail_Resize(object sender, EventArgs e)
        {
            if (!fFrmLoading)
            {
                AlligGridTotals();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!tabMDtl.Contains(tabError))
                {
                    // Add New Tab
                    tabMDtl.TabPages.Add(tabError);
                    if (dGvError.RowCount > 0)
                    {
                        dGvError.Rows.Clear();
                    }

                }
                //
                if (!GridFilled())
                {
                    MessageBox.Show("Grid Empty or not valid. Check Errror Tab.", "Save: " + lblFormTitle.Text.ToString());
                    tabMDtl.SelectedTab = tabError;
                    return;

                }
                Cursor.Current = Cursors.WaitCursor;
                SaveData();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Processing Save: " + ex.Message, "Save: " + lblFormTitle.Text.ToString());
            }
        }
        private bool DocValid(bool pcheckDocID = true)
        {
            bool rtnValue = true;
            if (mtBookID.Text.ToString().Trim(' ', '-') == "")
            {
                MessageBox.Show("Voucher Type ID / Book ID empty or blank, select one and try again.", "Check Doc: " + lblFormTitle.Text.ToString());
                rtnValue =  false;
            }
            if (pcheckDocID)
            {
                if (mtDocID.Text.ToString().Trim(' ', '-') == "" || Convert.ToInt64(mtDocID.Text.ToString()) == 0)
                {
                    MessageBox.Show("Voucher ID / Doc ID empty or blank, select one and try again.", "Check Doc: " + lblFormTitle.Text.ToString());
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
                int lLastRow = dGvDetail.Rows.Count - 1;
                // Check the compulsary columns.
                if (dGvDetail.Rows.Count > 0)
                {
                    // Check GL Account ID
                    if (dGvDetail.Rows[lLastRow].Cells[(int)GCol.acstrid].Value == null) // || 
                    {
                        rtnValue = false;
                    }
                    else
                    {
                        if ((dGvDetail.Rows[lLastRow].Cells[(int)GCol.acstrid].Value.ToString()).Trim(' ', '-') == "")
                        {
                            rtnValue = false;
                        }
                    }
                    // Check Project/Reference ID
                    if (dGvDetail.Rows[lLastRow].Cells[(int)GCol.refid].Value == null)
                    {
                        rtnValue = false;
                    }
                    else
                    {
                        if ((dGvDetail.Rows[lLastRow].Cells[(int)GCol.refid].Value.ToString()).Trim(' ', '-') == "")
                        {
                            rtnValue = false;
                        }
                    }
                    // Optional: Check ComboBox 1
                    if (dGvDetail.Rows[lLastRow].Cells[(int)GCol.CbmCol].Value == null) //|| 
                    {
                        rtnValue = false;
                    }
                    else
                    {
                        if ((dGvDetail.Rows[lLastRow].Cells[(int)GCol.refid].Value.ToString()).Trim() == "")
                        {
                            rtnValue = false;
                        }
                    }
                    // Optional: Check ComboBox 2
                    if (dGvDetail.Rows[lLastRow].Cells[(int)GCol.CbmColCountry].Value == null)
                    {
                        rtnValue = false;
                    }
                    else
                    {
                        if ((dGvDetail.Rows[lLastRow].Cells[(int)GCol.CbmColCountry].Value.ToString()).Trim() == "")
                        {
                            rtnValue = false;
                        }
                    }
                }
                textAlert.Text = "New row may not be inserted, Last row blank of empty.  " + lNow.ToString("T"); 
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Grid Validity: " + ex.Message, lblFormTitle.Text.ToString());
                return false;
            }
        }
        //
        private bool SaveData()
        {
            bool rtnValue = true;
            fTErr = 0;
            List<string> lManySQL = new List<string>();
            string lSQL = string.Empty;
            DateTime lNow = DateTime.Now;
            try
            {
                if (mtBookID.Text.ToString().Trim(' ', '-') == "")
                {
                    MessageBox.Show("Voucher Type ID / Book ID empty or blank, select one and try again.", "Save: " + lblFormTitle.Text.ToString());
                    return false;
                }
                if (mtDocID.Text.ToString().Trim(' ', '-') != "")
                {
                    if (Convert.ToInt32(mtDocID.Text.ToString()) > 0)
                    {
                        // if already exists       
                    }
                }
                ErrrMsg = "";
                if (dGvDetail.Rows.Count < 1)
                {
                    fTErr++;
                    dGvError.Rows.Add(fTErr.ToString(), "Trans.", "", "No Transaction in the grid to save. " + "  " + lNow.ToString());
                    MessageBox.Show("No transaction in grid to Save", "Save: " + lblFormTitle.Text.ToString());
                    return false;
                }
                fLastRow = dGvDetail.Rows.Count - 1;
                if (!FormValidation())
                {
                    textAlert.Text = "Form Validation Error: Not Saved." + "  " + lNow.ToString();
                    MessageBox.Show(ErrrMsg, "Save: " + lblFormTitle.Text.ToString());
                    return false;
                }
                // Grid Validation
                if (!GridIDValidation("Ac ID", "MT", dGvDetail, dGvError, (int)GCol.acstrid, "gl_ac", "ac_strid", (int)GCol.debit, (int)GCol.credit, "STR"))
                {
                    textAlert.Text = "Grid: Validation Ac ID, Error. Check 'Error Tab'  ...." + "  " + lNow.ToString();
                    //tabMDtl.SelectedTab = tabError;
                    rtnValue = false;
                }
                if (!GridIDValidation("Ref/Prj ID", "MT", dGvDetail, dGvError, (int)GCol.refid, "geo_city", "city_id", (int)GCol.debit, (int)GCol.credit, "NUM"))
                {
                    textAlert.Text = "Grid: Validation Ref/Prj ID, Error. Check 'Error Tab'  ...." + "  " + lNow.ToString();
                    //tabMDtl.SelectedTab = tabError;
                    rtnValue = false;
                }
                if (!GridIDValidation("ComboBox City", "CB", dGvDetail, dGvError, (int)GCol.CbmCol, "geo_city", "city_id", (int)GCol.debit, (int)GCol.credit, "NUM"))
                {
                    textAlert.Text = "Grid: Validation ComboBox City, Error. Check 'Error Tab'  ...." + "  " + lNow.ToString();
                    //tabMDtl.SelectedTab = tabError;
                    rtnValue = false;
                }
                if (!GridIDValidation("ComboBox Country", "CB", dGvDetail, dGvError, (int)GCol.CbmColCountry, "geo_country", "country_id", (int)GCol.debit, (int)GCol.credit, "NUM"))
                {
                    textAlert.Text = "Grid: Validation ComboBox Country, Error. Check 'Error Tab'  ...." + "  " + lNow.ToString();
                    
                    rtnValue = false;
                }
                if (!rtnValue)
                {
                    tabMDtl.SelectedTab = tabError;
                    return rtnValue;
                }
                // pending un comment when required
                //if (!GridCboValidation("Ref/Prj ID", "MT", dGvDetail, dGvError, (int)GCol.refid, "gl_ac", "ac_strid", (int)GCol.debit, (int)GCol.credit))
                //{
                //    tStextAlert.Text = "Grid: Validation Ref/Prj ID, Error. Check 'Error Tab'  ...." + lNow.ToString();
                //    tabMDtl.SelectedTab = tabError;
                //    return false;
                //}
                //

                fManySQL = new List<string>();

                // Prepare Master Doc Query List
                fTNOT = GridTNOT(dGvDetail);
                if (!PrepareDocMaster())
                {
                    textAlert.Text = "DocMaster: Modifying Doc/Voucher not available for updation.'  ...." + "  " + lNow.ToString();
                    tabMDtl.SelectedTab = tabError;
                    return false;
                }
                //
                if (dGvDetail.Rows.Count > 0)
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
                        MessageBox.Show("Not Saved see log...", lblFormTitle.Text.ToString());
                        return false;
                    }
                    else
                    {
                        fLastID = mtDocID.Text.ToString();
                        if (fDocAlreadyExists)
                        {
                            textAlert.Text = "Existing ID: " + fDocID + " Modified .... " + "  " + lNow.ToString();
                        }
                        else
                        {
                            textAlert.Text = "New ID: " + fDocID + " Inserted .... " + "  " + lNow.ToString();
                        }
                        EDButtons(true);
                        ClearThisForm();
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Data Preparation list empty, Not Saved...", lblFormTitle.Text.ToString());
                    return false;
                } // End Execute Query
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Processing Save: " + ex.Message, "Save Data: " + lblFormTitle.Text.ToString());
                return false;
            }

        } // End Save
        private bool PrepareDocMaster()
        {
            bool rtnValue = true;
            string lSQL = string.Empty;
            try
            {
                string lDocDateStr = StrF01.D2Str(mtDocDate);
                DateTime lDocDate = DateTime.Parse(lDocDateStr);

                if (mtDocID.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("gl_tran", "doc_id", NewDocWhere(), "");
                    //
                    lSQL = "insert into gl_tran (";
                    lSQL += " loc_id ";                                             // 1-
                    lSQL += ", grp_id ";                                            // 2-
                    lSQL += ", co_id ";                                             // 3-
                    lSQL += ", year_id ";                                           // 4-
                    lSQL += ", doc_book_id ";                                       // 5-
                    lSQL += ", doc_ID ";                                            // 6-
                    lSQL += ", doc_type_id ";                                       // 7-
                    lSQL += ", doc_fiscal_id ";                                     // 8-
                    lSQL += ", doc_date ";                                          // 9-
                    lSQL += ", doc_ref ";                                           // 9a-
                    lSQL += ", doc_tnot ";                                          // 10-
                    lSQL += ", doc_tnoa ";                                          // 11-
                    lSQL += ", doc_remarks ";                                       // 12-
                    lSQL += ", doc_amt ";                                           // 13-
                    lSQL += ", frm_id ";                                            // 14-
                    lSQL += ", created_by ";                                        // 15-
                    //lSQL += ", modified_by ";                                     // 16-
                    lSQL += ", created_date ";                                      // 17-
                    //lSQL += ", modified_date  ";                                  // 18-
                    lSQL += " ) values (";
                    //

                    lSQL += clsGVar.LocID.ToString();                              // 1-
                    lSQL += ", " + clsGVar.GrpID.ToString();                       // 2-
                    lSQL += ", " + clsGVar.CoID.ToString();                        // 3-
                    lSQL += ", " + clsGVar.YrID.ToString();                        // 4-
                    lSQL += ", " + mtBookID.Text.ToString();                        // 5-
                    lSQL += ", " + fDocID;                                          // 6-
                    lSQL += ", " + fDocType.ToString();                             // 7-
                    lSQL += ", " + fDocFiscal.ToString();
                    //lSQL += ",'" + lDocDate.ToString() + "'" ;                     // 9-
                    lSQL += "," + StrF01.D2Str(mtDocDate) + "";                     // 9-
                    lSQL += ",'" + StrF01.EnEpos(textDocRef.Text.ToString()) + "'"; // 9a-
                    lSQL += ", " + fTNOT;                                           // 10- 
                    lSQL += ", " + clsDbManager.GetTotalRec("img_attach", "attach_id", clsGVar.ConString2).ToString();   // 11-
                    lSQL += ",'" + StrF01.EnEpos(textDocRemarks.Text.ToString()) + "'";                              // 12-
                    lSQL += ", " + fDocAmt.ToString();                              // 13-
                    lSQL += ", " + fFormID.ToString();                              // 14-
                    lSQL += ", " + clsGVar.AppUserID.ToString();                   // 15- Created by
                    //                                                              // 16- Modified by
                    lSQL += ",'" +  StrF01.D2Str(DateTime.Now, true) + "'";         // 17- Created Date  
                    //                                                              // 18- Modified Date
                    lSQL += ")";

                }
                else
                {
                    if (clsDbManager.IDAlreadyExistWw("gl_tran", "doc_id", DocWhere("")))
                    {
                        fDocAlreadyExists = true;
                        lSQL = "delete from gl_trandtl ";
                        lSQL += " where ";
                        lSQL += DocWhere();
                        fManySQL.Add(lSQL);
                        //
                    }
                    else
                    {
                        dGvError.Rows.Add("M", "Master Doc", mtDocID.Text.ToString(), "Doc/Voucher " + mtDocID.Text.ToString() + " has been removed.");      
                         MessageBox.Show("Doc/Voucher ID " + mtDocID.Text.ToString() + " has been deleted or removed"
                            + "\n\r" + "The Voucher will be saved as new voucher, try again "
                            + "\n\r" + "Or press clear button to discard the voucher/Doc.", lblFormTitle.Text.ToString());
                        mtDocID.Text = "";
                        rtnValue = false;
                        return rtnValue;
                    }
                    fDocID = Convert.ToInt64(mtDocID.Text.ToString());
                    lSQL = "update gl_tran set";
                    //lSQL += " loc_id = ";                                                     // 1-
                    //lSQL += ", grp_id = ";                                                    // 2-
                    //lSQL += ", co_id = ";                                                     // 3-
                    //lSQL += ", year_id = ";                                                   // 4-
                    //lSQL += ", doc_book_id ";                                                 // 5-
                    //lSQL += ", doc_ID ";                                                      // 6-
                    //lSQL += ", doc_type_id ";                                                    // 7-
                    //lSQL += ", doc_fiscal_id ";                                                  // 8-
                    //
                    lSQL += "  doc_date = '" + StrF01.D2Str(mtDocDate) + "'";                   // 9-

                    //lSQL += "  doc_date = '" + lDocDate + "'";                   // 9-

                    lSQL += ", doc_ref = '" + StrF01.EnEpos(textDocRef.Text.ToString()) + "'";  //9-a
                    lSQL += ", doc_tnot = " + fTNOT;                                            // 10-
                    lSQL += ", doc_tnoa = " + clsDbManager.GetTotalRec("img_attach", "attach_id", clsGVar.ConString2);  // 11-
                    lSQL += ", doc_remarks = '" + StrF01.EnEpos(textDocRemarks.Text.ToString()) + "'";              // 12-
                    lSQL += ", doc_amt = " + fDocAmt.ToString();                                // 13-
                    lSQL += ", frm_id = " + fFormID.ToString();                                 // 14-
                    //lSQL += ", created_by ";                                                  // 15-
                    lSQL += ", modified_by = " + clsGVar.AppUserID.ToString();                 // 16-
                    //lSQL += ", created_date ";                                                // 17-
                    lSQL += ", modified_date = '" +  StrF01.D2Str(DateTime.Now, true) + "'";    // 18-
                    lSQL += " where ";
                    lSQL += DocWhere();
                    //
                }
                fManySQL.Add(lSQL);
                return rtnValue;
            }
            catch (Exception ex)
            {
                rtnValue = false;
                MessageBox.Show("Save Master Doc: " + ex.Message,lblFormTitle.Text.ToString());
                return false;
            }   
        } // End PrepareDocMaster
        //
        private bool PrepareDocDetail()
        {
            bool rtnValue = true;
            string lSQL = "";
            Int64 lAcID = 0;
            try
            {
                //
                for (int dGVRow = 0; dGVRow < dGvDetail.Rows.Count; dGVRow++)
                {
                    //frmGroupRights.dictGrpForms.Add(Convert.ToInt32(dGVSelectedForms.Rows[dGVRow].Cells[0].Value.ToString()),
                    //    dGVSelectedForms.Rows[dGVRow].Cells[1].Value.ToString());
                    // Prepare Save Data to Db Table
                    //
                    if (dGvDetail.Rows[dGVRow].Cells[(int)GCol.acstrid].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if ((dGvDetail.Rows[dGVRow].Cells[(int)GCol.acstrid].Value.ToString()).Trim(' ', '-') == "" )
                        {
                            //lBlank = true;
                            if (dGVRow == fLastRow)
                            {
                                continue;
                            }
                        }
                    }
                    // string aaa1 = dGvDetail.Rows[dGVRow].Cells[(int)GCol.acstrid].Value.ToString();
                    lAcID = coa.GetNumAcID(                        
                        "gl_ac", 
                        "ac_strid", 
                        "ac_id", 
                        dGvDetail.Rows[dGVRow].Cells[(int)GCol.acstrid].Value.ToString(),
                        ""
                        );
                    // Top Portion
                    lSQL = "insert into gl_trandtl ( ";
                    lSQL += "loc_id";
                    lSQL += ", grp_id";
                    lSQL += ", co_id";
                    lSQL += ", year_id";
                    // 
                    // Middle Pottion
                    //
                    lSQL += ", doc_book_id ";                                                               // Form 1- 
                    lSQL += ", doc_id ";                                                                    // Form 2- 
                    lSQL += ", doc_type_id ";                                                                  // Form 3- Document Mode = JV, Cash, Bank etc 
                    lSQL += ", doc_fiscal_id ";                                                                // 4- Doc Fiscal 
                    //
                    lSQL += ", SERIAL_NO ";                                                                  // 0- 
                    lSQL += ", SERIAL_ORDER ";                                                              // 1-
                    //lSQL += ", 0 as sno ";                                                                // 2-   
                    lSQL += ", ac_id ";                                                                     // 3-
                    //lSQL += ", ac_strid ";                                                                // 4-
                    //lSQL += ", ac_title ";                                                                // 5-
                    lSQL += ", REF_ID ";                                                                    // 6-
                    //lSQL += ", city_title ";                                                                // 7-
                    lSQL += ", NARRATION ";                                                                 // 8-
                    lSQL += ", DEBIT ";                                                                     // 9-    
                    lSQL += ", CREDIT ";                                                                    // 10-
                    lSQL += ", city_id ";                                                                   // 11-
                    lSQL += ", country_id ";                                                                // 12-
                    //
                    // Bottom Portion
                    //
                    lSQL += ") values (";
                    lSQL += clsGVar.LocID.ToString();
                    lSQL += ", " + clsGVar.GrpID.ToString();
                    lSQL += ", " + clsGVar.CoID.ToString();
                    lSQL += ", " + clsGVar.YrID.ToString();
                    //
                    lSQL += ", " + mtBookID.Text.ToString();                                                 // 1- Form 2- book_id
                    lSQL += ", " + fDocID.ToString();                                                        // 2- Form 1- Voucher_id
                    lSQL += ", " + fDocType.ToString();                                                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                    lSQL += ", " + mtFiscalID.Text.ToString();                                               // 4- Document Fiscal
                    //
                    lSQL += ", " + "12345";                                                                  // 1- To be replaced with max value 
                    lSQL += ", " + dGvDetail.Rows[dGVRow].Cells[(int)GCol.snum].Value.ToString();            // 2- Serial Order replaced with SNo. 
                    lSQL += ", " + lAcID;                                                                    // 3- Account ID Numeric. 
                    //lSQL += ", " + dGvDetail.Rows[dGVRow].Cells[(int)GCol.acstrid].Value;                  // 4- NA. 
                    //                                                                                       // 5- Ac Title NA
                    lSQL += ", " + dGvDetail.Rows[dGVRow].Cells[(int)GCol.refid].Value.ToString();           // 6- Ref ID. 
                    //                                                                                       // 7- Ref Title NA
                    lSQL += ", '" + StrF01.EnEpos(dGvDetail.Rows[dGVRow].Cells[(int)GCol.doctranRem].Value.ToString()) + "'";      // 8- Narration 
                    lSQL += ", " + dGvDetail.Rows[dGVRow].Cells[(int)GCol.debit].Value.ToString();           // 9- Debit. 
                    lSQL += ", " + dGvDetail.Rows[dGVRow].Cells[(int)GCol.credit].Value.ToString();          // 10- Debit. 
                    lSQL += ", " + dGvDetail.Rows[dGVRow].Cells[(int)GCol.CbmCol].Value.ToString();          // 11- Combo 1 
                    lSQL += ", " + dGvDetail.Rows[dGVRow].Cells[(int)GCol.CbmColCountry].Value.ToString();   // 12- Combo 2 

                    lSQL += ")";
                    //
                    fManySQL.Add(lSQL);
                } // End For loopo
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Detail Doc: " + ex.Message, lblFormTitle.Text.ToString());
                return false;
            }

        }   // End PrepareDocDetail


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
                    if (pdGv.Rows[dGVRow].Cells[(int)GCol.acstrid].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((pdGv.Rows[dGVRow].Cells[(int)GCol.acstrid].Value.ToString()).Trim(' ', '-') == "" )
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
                MessageBox.Show("Save Grid TNOT: " + ex.Message, lblFormTitle.Text.ToString());
                return rtnValue;
            }   
        }

        //
        private bool GridFilled()
        {
            bool lRtnValue = true;
            DateTime lNow = DateTime.Now;
            //
            if (dGvDetail.Rows.Count > 1)
            {
                return lRtnValue;
            }
            else
            {
                if (dGvDetail.Rows.Count < 1)
                {
                    fTErr++;
                    dGvError.Rows.Add(fTErr.ToString(), "Trans.", "", "No Transaction in the grid to save. " + "  " + lNow.ToString());
                    //MessageBox.Show("No transaction in grid to Save", "Save: " + lblFormTitle.Text.ToString());
                    return false;
                }
                if (dGvDetail.Rows.Count == 1)
                {
                    if (dGvDetail.Rows[0].Cells[(int)GCol.acid].Value == null && dGvDetail.Rows[0].Cells[(int)GCol.refid].Value == null)
                    {
                        fTErr++;
                        dGvError.Rows.Add(fTErr.ToString(), "Grid Trans.", "", "New row. No data to save. " + "  " + lNow.ToString());
                        lRtnValue = false;
                    }
                    else
                    {
                        if (dGvDetail.Rows[0].Cells[(int)GCol.acid].Value == null)
                        {
                            fTErr++;
                            dGvError.Rows.Add(fTErr.ToString(), "Grid Trans.", "", "Empty Account ID in the grid. " + "  " + lNow.ToString());
                            //MessageBox.Show("No transaction in grid to Save", "Save: " + lblFormTitle.Text.ToString());
                            lRtnValue = false;
                        }
                        if (dGvDetail.Rows[0].Cells[(int)GCol.refid].Value == null)
                        {
                            fTErr++;
                            dGvError.Rows.Add(fTErr.ToString(), "Grid Trans.", "", "Reference ID/ Project ID in grid blank " + "  " + lNow.ToString());
                            //MessageBox.Show("No transaction in grid to Save", "Save: " + lblFormTitle.Text.ToString());
                            lRtnValue = false;
                        }
                        return lRtnValue;
                    }
                }

                //
                return lRtnValue;
            }
        }
        //
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
                if (mtBookID.Text.ToString().Trim(' ', '-') == "")
                {
                        ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Voucher Type ID / Book ID empty or blank");
                        fTErr++;
                        dGvError.Rows.Add(fTErr.ToString(), "Voucher Type ID / Book ID empty or blank", "", "Form Validation: " + ErrrMsg + "  " + lNow.ToString());
                        lRtnValue = false;
                }
                if (mtDocDate.Text.ToString().Trim(' ', '-') == "")
                {
                        ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Date empty or blank, select a valid date and try again");
                        fTErr++;
                        dGvError.Rows.Add(fTErr.ToString(), "Date empty or blank", "", "Form Validation: " + ErrrMsg + "  " + lNow.ToString());
                        lRtnValue = false;
                }

                lDebit = sumDecimal(dGvDetail, (int)GCol.debit,true);
                lCredit = sumDecimal(dGvDetail, (int)GCol.credit,true);
                if (lDebit != lCredit)
                {
                    if (!fSingleEntryAllowed)
                    {
                        // for for conventional books as in old Finac.
                        fTErr++;
                        ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Sum: Debit: " + lDebit.ToString() + " Credit: " + lCredit.ToString() + " Diff: " + (lDebit - lCredit).ToString() + "");
                        dGvError.Rows.Add(fTErr.ToString(), "Total Debit/Credit", "", ErrrMsg + "  " + lNow.ToString());
                        return false;
                    }
                }
                fDocAmt = lDebit;
                return lRtnValue;

            }
            catch (Exception ex)
            {
                fTErr++;
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Exception: FormValidation -> " + ex.Message.ToString() );
                dGvError.Rows.Add(fTErr.ToString(), "Exception: FormValidation -> ", "", ErrrMsg + "  " + lNow.ToString());
                return false;
            }
            //return lRtnValue;        // to be removed
        }
        //
        // 1- Validation Type (Name of ID to display in Error message)
        // 2- Grid to Validate
        // 3- Grid to Show Errors if any.
        // 4- Grid Column Number
        // 5- Table Name
        // 6- Key Field Name
        // 7- Debit Column No.
        // 8- Credit Column No.
        // 9- Column Type: NUM = number, MT = masked textbox, TB = TextBox, STR = String etc 
        //
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
                    dGvError.Rows.Add(fTErr.ToString(), "Debit/Credit", "", "Grid Tran. " + (i + 1).ToString()  + ", Both: Debiot: " + lDebit.ToString() + " and Credit: " + lCredit.ToString() + " Contain values, please select only one ...");
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
                        dGvError.Rows.Add(fTErr.ToString(), pIDName, "", "Grid Tran. " + (i + 1).ToString() + ", ID Blank or null");      // as i starts with 0
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
                        dGvError.Rows.Add(
                            fTErr.ToString(), 
                            pIDName, 
                            "",
                            "Grid Tran. " + (i + 1).ToString() + ", ID Blank or null, Only one Row in the grid"
                            );      // as i starts with 0
                        rtnValue = false;
                    }
                }
                else
                {
                    lBlank = false;
                    // Masked Edit
                    if (pControType == "MT")
                    {
                        if ((pdGVMDtl.Rows[i].Cells[pCol].Value.ToString()).Trim(' ', '-') == "" ) 
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
                                dGvError.Rows.Add(fTErr.ToString(), pIDName, " ", "Grid Tran. " + (i + 1).ToString() + ", Masked Text Box: ID Blank");
                                    //}
                                rtnValue = false;
                                //} // if not lastrow
                            } // if Debit or Credit
                        } // if null or ""
                    }
                    else if (pControType == "TB")
                    {
                        if ((pdGVMDtl.Rows[i].Cells[pCol].Value.ToString()).Trim() == "" ) // has been addressed above || pdGVMDtl.Rows[i].Cells[pCol].Value == null)
                        {
                            lBlank = true;
                            if (lDebit > 0 || lCredit > 0)
                            {
                                fTErr++;
                                dGvError.Rows.Add(fTErr.ToString(), pIDName, "", "Grid Tran. " + (i + 1).ToString() + ", Grid TextBox Column ID Blank");
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
                                dGvError.Rows.Add(fTErr.ToString(), pIDName, "", "Grid Tran. " + (i + 1).ToString() + ", Grid ComboBox Column ID Blank or not selected.");
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
                                dGvError.Rows.Add(fTErr.ToString(), pIDName, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(), "Grid Tran. " + (i + 1).ToString() + ", Grid Text Box: ID not found in database");
                                rtnValue = false;
                            }
                        }
                        else if (pIDType == "STR")
                        {
                            if (!clsDbManager.IDAlreadyExistStrAc(pTableName, pKeyField, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(), ""))
                            {
                                fTErr++;
                                dGvError.Rows.Add(fTErr.ToString(), pIDName, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(), "Grid Tran. "  + (i + 1).ToString() + ", Grid Cell: Account ID not found in database");
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
                            dGvError.Rows.Add(fTErr.ToString(), pIDName, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(), "Grid Tran. " +  (i + 1).ToString() + ", Grid Masked Text Box: Account ID Type Missing");
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

       
        //
        // 1- Validation Type (Name of ID to display in Error message)
        // 2- Grid to Validate
        // 3- Grid to Show Errors if any.
        // 4- Grid Column Number
        // 5- Table Name
        // 6- Key Field Name
        // 7- Debit Column No.
        // 8- Credit Column No.
        //
        private bool GridCboValidation( 
            string pIDType,
            string pControType,
            DataGridView pdGVMDtl,
            DataGridView pdGvErr,
            int pCol,
            string pTableName,
            string pKeyField,
            int pDrCol,
            int pCrCol
            )
        {
            bool rtnValue = true;
            bool lBlank = false;
            // Check acid column.
            if (pdGvErr.RowCount > 0)
            {
                pdGvErr.Rows.Clear();
            }
            for (int i = 0; i < pdGVMDtl.RowCount; i++)
            {
                if (pdGVMDtl.Rows[i].Cells[pCol].Value == null)
                {
                    if (i != (pdGVMDtl.RowCount - 1))
                    {
                        fTErr++;
                        //                 SNo               ID type  ID   Error Message
                        dGvError.Rows.Add(fTErr.ToString(), pIDType, "", "Grid Tran. " + (i + 1).ToString() + ", ID Blank or null");      // as i starts with 0
                        rtnValue = false;
                    }
                    if (pdGVMDtl.RowCount == 1)
                    {
                        fTErr++;
                        //                 SNo               ID type  ID   Error Message
                        dGvError.Rows.Add(fTErr.ToString(), pIDType, "", "Grid Tran. " + (i + 1).ToString() + ", ID Blank or null, Only one Row in the grid");      // as i starts with 0
                        rtnValue = false;
                    }
                }
                else
                {
                    lBlank = false;
                    if (pControType == "MT")
                    {
                        if ((pdGVMDtl.Rows[i].Cells[pCol].Value.ToString()).Trim(' ', '-') == "")
                        {
                            fTErr++;
                            dGvError.Rows.Add(fTErr.ToString(), pIDType, "", "Grid Tran. " + (i + 1).ToString() + ", Masked: ID Blank");
                            lBlank = true;
                            rtnValue = false;
                        }
                    }
                    else if (pControType == "TB")
                    {
                        if ((pdGVMDtl.Rows[i].Cells[pCol].Value.ToString()).Trim() == "")
                        {
                            fTErr++;
                            dGvError.Rows.Add(fTErr.ToString(), pIDType, "","Grid Tran. " + (i + 1).ToString() + ", ID Blank");
                            lBlank = true;
                            rtnValue = false;
                        }
                    }
                    // Check ID Exists
                    if (!lBlank)
                    {
                        if (!clsDbManager.IDAlreadyExist(pTableName, pKeyField, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(), ""))
                        {
                            fTErr++;
                            dGvError.Rows.Add(fTErr.ToString(), pIDType, pdGVMDtl.Rows[i].Cells[pCol].Value.ToString(),"Grid Tran. " + (i + 1).ToString() + ", ID not found in database");
                            rtnValue = false;
                        }
                    }
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
                        lDecimalcheck = decimal.TryParse(pdGVMDtl.Rows[i].Cells[pCrCol].Value.ToString(), out outValue);    // Debit Column
                        if (lDecimalcheck)
                        {
                            lCredit = outValue;
                        }
                    }
                    //
                    if (lDebit > 0 && lCredit > 0)
                    {
                        fTErr++;
                        dGvError.Rows.Add(fTErr.ToString(), "Debit/Credit", "", "Grid Tran. " + (i + 1).ToString() + ", Both: Debiot: " + lDebit.ToString() + " and Credit: " + lCredit.ToString() + " Contain values, please select only one ...");
                        rtnValue = false;
                    }
                }
            }
            return rtnValue;
        }

        //
        private void ClearThisForm()
        {
            if (btn_Pin.Text.ToString() == "Pi&n")
            {
                //mtBookID.Text = string.Empty;
                lblBookTitle.Text = string.Empty;
                lblBookSt.Text = string.Empty;
                mtDocDate.Text = DateTime.Now.ToString();
                textDocRef.Text = string.Empty;
                //
            }
            //
            mtDocID.Text = string.Empty;
            textDocRemarks.Text = string.Empty;
            lblTotalDebit.Text = string.Empty;
            lblTotalCredit.Text = string.Empty;
            if (dGvDetail.Rows.Count > 0)
            {
                dGvDetail.Rows.Clear();
                InsertNewRowInGrid();
            }
            mtDocID.Focus();
        }

        private void dGvDetail_Scroll(object sender, ScrollEventArgs e)
        {
            //AlligGridTotals();
        }

        private void dGvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblDebug.Text = "column: " + e.ColumnIndex.ToString() + " Row: " + e.RowIndex.ToString() + " Value: " ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblDebug.Visible = true;
            //lblDebug.Text = "Status: " + dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.currstatus].Value.ToString() + " Tran ID: " + dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.tranid].Value.ToString();
            lblDebug.Text = "SplitContParent P1 " + splitContParent.Panel1.Height.ToString() + "\n\r";
            lblDebug.Text = "SplitContParent P2 " + splitContParent.Panel2.Height.ToString() + "\n\r";
            lblDebug.Text += " Distance " + splitContParent.SplitterDistance.ToString() + "\n\r";
            //lblDebug.Text += " Distance " + splitContGrid.SplitterDistance.ToString() + "\n\r";
            //lblDebug.Text += " Panel 1 Height " + splitContGrid.Panel1.Height.ToString() + "\n\r";
            //lblDebug.Text += "Panel 2 Height " + splitContGrid.Panel2.Height.ToString() + "\n\r";
            lblDebug.Text += " Tab Height: " + tabMDtl.Height.ToString() + "\n\r";
            lblDebug.Text += " Form: Height " + this.Height.ToString() + "\n\r";
            lblDebug.Text += " Form: Width " + this.Width.ToString() + "\n\r";
        }

        private void tabError_Enter(object sender, EventArgs e)
        {
            //pnlDocTop.Parent = tabMDtl.TabPages[3];
            //DisplayDocData();
            lblErrBookID.Text = mtBookID.Text;
            lblErrDocDate.Text = mtDocDate.Text;
            lblErrDocRef.Text = textDocRef.Text;
            lblErrlBookTitle.Text = lblBookTitle.Text;
            lblErrDocID.Text = mtDocID.Text;
            lblErrFiscalID.Text = mtFiscalID.Text;
            lblErrFiscalTitle.Text = lblFiscalTitle.Text;
        }
        private void DisplayDocData()
        {
            lblErrBookID.Text = mtBookID.Text;
            lblErrDocDate.Text = mtDocDate.Text;
            lblErrDocRef.Text = textDocRef.Text;
            lblErrlBookTitle.Text = lblBookTitle.Text;
            lblErrDocID.Text = mtDocID.Text;
            lblErrFiscalID.Text = mtFiscalID.Text;
            lblErrFiscalTitle.Text = lblFiscalTitle.Text;
        }
        private void dGvDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Note: cell formating event is fired before this event.
            // Control Decimal in the column
            int colIndex = this.dGvDetail.CurrentCell.ColumnIndex;

            //if (colIndex == (int)GCol.CbmCol)        // GCol Enumerator
            //{
            //    ComboBox combo = e.Control as ComboBox;
            //    if (combo != null)
            //    {
            //        int aaa = combo.Items.Count;
            //        MessageBox.Show("EditingControlShowing: count A : " + aaa.ToString());
            //        // Remove an existing event-handler, if present, to avoid 
            //        // adding multiple handlers when the editing control is reused.
            //        combo.SelectedIndexChanged -= new EventHandler(ComboBoxCol_SelectedIndexChanged);

            //        // Add the event handler. 
            //        combo.SelectedIndexChanged += new EventHandler(ComboBoxCol_SelectedIndexChanged);
                
            //    }
            //    return;
            //} // End if  


            if (colIndex == (int)GCol.acstrid || colIndex == (int)GCol.refid)        // GCol Enumerator
            {
                if (e.Control is TextBox)
                {
                    fCellEditMode = true;
                    TextBox tb = e.Control as TextBox;
                    tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);         // User defined event
                } // End if is Textbox
            } // End if  
            else
            {
                fCellEditMode = false;
            }

            // End Mothod
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int lcboVal1 = 0;
            int lcboVal2 = 0;
            for (int i = 0; i < dGvDetail.Rows.Count; i++)
            {
                lcboVal1 = Convert.ToInt32(dGvDetail.Rows[i].Cells[(int)GCol.CbmCol].Value);
                lcboVal2 = Convert.ToInt32(dGvDetail.Rows[i].Cells[(int)GCol.CbmColCountry].Value);
                if (dGvDetail.Rows[i].Cells[(int)GCol.CbmColCountry].Value == null)
                {
                    MessageBox.Show("Country Combo: = null");
                }
                MessageBox.Show("ComboBox: Value: " + lcboVal1.ToString() + " Country :  " + lcboVal2.ToString());
            }

            //foreach (DataGridViewRow row in dGvDetail.Rows)
            //{
            //    DataGridViewComboBoxCell cell = row.Cells[(int)GCol.CbmCol] as DataGridViewComboBoxCell;
            //    MessageBox.Show("Cell Value: " + cell.Value.ToString() + " Display Member " + cell.DisplayMember.ToString());
                
            //} 



        }
        //private void dGvDetail_EditingControlShowingA(object sender, DataGridViewEditingControlShowingEventArgs e) 
        //{
        //    // Note: cell formating event is fired before this event.
        //    // Control Decimal in the column
        //    int colIndex = this.dGvDetail.CurrentCell.ColumnIndex;
        //    if (colIndex == (int)GCol.CbmCol )        // GCol Enumerator
        //    {
        //        ComboBox combo = e.Control as ComboBox;
        //        if (combo != null)
        //        {
        //            int aaa = combo.Items.Count;
        //            MessageBox.Show("count A : " + aaa.ToString());
        //            // Remove an existing event-handler, if present, to avoid 
        //            // adding multiple handlers when the editing control is reused.
        //            combo.SelectedIndexChanged -= new EventHandler(ComboBoxCol_SelectedIndexChanged);

        //            // Add the event handler. 
        //            combo.SelectedIndexChanged += new EventHandler(ComboBoxCol_SelectedIndexChanged);
        //        }
        //    } // End if  
        //}
        private void ComboBoxCol_SelectedIndexChanged(object sender, EventArgs e)
        {
             ComboBox cb = (ComboBox)sender;
             if(cb != null)
             {

                 MessageBox.Show("IN ComboBoxCol_SelectedIndexChanged: Count: " + cb.Items.Count.ToString());
                 //DataRowView view = cb.SelectedItem as DataRowView;
                 //string myName = view["UserName"].ToString();
                 //int myID = int.Parse(view["ID"].ToString)());
             }
        }

        private void dGvDetail_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (fSettingCbo) 
            {
                if (e.ColumnIndex == (int)GCol.CbmCol)
                //Rows[lLastRow].Cells[(int)GCol.acid].Value == null || dGvDetail.Rows[lLastRow].Cells[(int)GCol.refid].Value == null) 
                {

                    MessageBox.Show("in Enter Mode: Combo Column: Sender: " + sender.ToString() + " e:Column:  " + e.ColumnIndex.ToString());
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

            //if (dGvDetail.Rows.Count > 1 || btn_Pin.Text.ToString() != "Pi&n")
            //{
            //    if (MessageBox.Show("Are You Sure To Clear Exit Form ?", lblFormTitle.Text.ToString(), MessageBoxButtons.OKCancel) != DialogResult.OK)
            //    {
            //        return;
            //    }
            //}
            //MessageBox.Show("Date to Stirng " + StrF01.D2Str(mtDocDate) );
            //MessageBox.Show("Last Row: " + dGvDetail.Rows.Count.ToString());
            
            //int lCurrentCol = dGvDetail.CurrentCell.ColumnIndex;
            //int lSkip = 1;
            //if (dGvDetail.FirstDisplayedScrollingColumnIndex <= dGvDetail.Columns.Count - 1)
            //{
            //    for (int i = lCurrentCol; i < dGvDetail.Columns.Count - 1; i++)
            //    {
            //        if (dGvDetail.Columns[(dGvDetail.FirstDisplayedScrollingColumnIndex + lSkip)].Visible == true)
            //        {
            //            dGvDetail.FirstDisplayedScrollingColumnIndex = dGvDetail.FirstDisplayedScrollingColumnIndex + lSkip;
            //            return;
            //        }
            //        else
            //        {
            //            lSkip++;
            //        }
            //    }  // for
            //}  // if

        }

        private void btn_ScrollRight_Click(object sender, EventArgs e)
        {
            int lCurrentCol = dGvDetail.CurrentCell.ColumnIndex;
            int lSkip = 1;
            if (dGvDetail.FirstDisplayedScrollingColumnIndex <= dGvDetail.Columns.Count - 1)
            //if (dGvDetail.FirstDisplayedScrollingColumnIndex <= dGvDetail.Columns.Count) // no change
            {
                for (int i = lCurrentCol; i < dGvDetail.Columns.Count - 1; i++)
                //for (int i = lCurrentCol; i < dGvDetail.Columns.Count +1; i++) // no change
                {
                    if (dGvDetail.Columns[(dGvDetail.FirstDisplayedScrollingColumnIndex + lSkip)].Visible == true)
                    {
                        dGvDetail.FirstDisplayedScrollingColumnIndex = dGvDetail.FirstDisplayedScrollingColumnIndex + lSkip;
                        return;
                    }
                    else
                    {
                        lSkip++;
                    }
                }  // for
            }  // if

        }

        private void btn_ScrollLeft_Click(object sender, EventArgs e)
        {
            int lCurrentCol = 0;
            int lSkip = 1;
            if (dGvDetail.FirstDisplayedScrollingColumnIndex > 0)
            {
                lCurrentCol = dGvDetail.FirstDisplayedScrollingColumnIndex;
                for (int i = lCurrentCol; i > 0; i--)
                {
                    if (dGvDetail.Columns[(lCurrentCol - lSkip)].Visible == true)
                    {
                        dGvDetail.FirstDisplayedScrollingColumnIndex = lCurrentCol - lSkip;
                        return;
                    }
                    else
                    {
                        lSkip++;
                    }
                }  // for
            }  // if

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClearThisForm();
        }

        private void mtDocDate_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.ToString(); 

            if (mtDocDate.Text.Trim(' ', '-') == "")
            {
                return;
            }
            if (!e.IsValidInput)
            {
                MessageBox.Show( "Invalid Date! Enter a valid date using format " + sysFormat + "\n\r" + "or empty the box to exit.",lblFormTitle.Text.ToString());
                e.Cancel = true;
            }

        }

        private void btn_Month_Click(object sender, EventArgs e)
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
                mtDocDate.Text = mCalendarMain.SelectionStart.ToString();
                mCalendarMain.Focus();
            }
        }

        private void btn_HideMonth_Click(object sender, EventArgs e)
        {
            pnlCalander.Visible = false;
            textDocRef.Focus();
        }

        private void mCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            mtDocDate.Text = mCalendarMain.SelectionStart.ToString();
        }

        private void splitContParent_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            if (fSplitMouseDown)
            {
                splitContParent.SplitterDistance = e.SplitX;
                return;
            }
        }

        private void splitContParent_MouseDown(object sender, MouseEventArgs e)
        {
            fSplitMouseDown = true;
        }

        private void splitContParent_MouseUp(object sender, MouseEventArgs e)
        {
            fSplitMouseDown = false;
        }

        private void mtDocID_Validating(object sender, CancelEventArgs e)
        {
            if (mtDocID.Text.ToString().Trim(' ', '-') == "")
            {
                return;
            }
            if (mtBookID.Text.ToString().Trim(' ', '-') == "")
            {
                MessageBox.Show("Book ID empty or blank, select one and try again.",lblFormTitle.Text.ToString());
                mtDocID.Text = string.Empty;
                mtBookID.Focus();
                return;
            }
            //
            LoadeData();

        }

        private void tabSigning_Enter(object sender, EventArgs e)
        {
            //pnlDocTop.Parent = tabMDtl.TabPages[2];
            //DisplayDocData();
            lblSigningBookID.Text = mtBookID.Text;
            lblSigningDocDate.Text = mtDocDate.Text;
            lblSigningDocRef.Text = textDocRef.Text;
            lblSigningBookTitle.Text = lblBookTitle.Text;
            lblSigningDocID.Text = mtDocID.Text;
            lblSigningFiscalID.Text = mtFiscalID.Text;
            lblSigningFiscalTitle.Text = lblFiscalTitle.Text;
        }

        private void tabAttach_Enter(object sender, EventArgs e)
        {
            //pnlDocTop.Parent = tabMDtl.TabPages[1];
            //DisplayDocData();
            lblErrBookID.Text = mtBookID.Text;
            lblAttachDocDate.Text = mtDocDate.Text;
            lblAttachDocRef.Text = textDocRef.Text;
            lblAttachBookTitle.Text = lblBookTitle.Text;
            lblAttachDocID.Text = mtDocID.Text;
            lblAttachFiscalID.Text = mtFiscalID.Text;
            lblAttachFiscalTitle.Text = lblFiscalTitle.Text;

            dGvAttach.Columns[0].Width = 20;
            dGvAttach.Columns[1].Width = 100;
            if (fNewImageLoaded)
            {
                ImageInfoData(true);
            }
        }
        private void ImageInfoData(bool Visible)
        {
            if (Visible)
            {
                gbImageInfo.Visible = true;
                lblImageTitleLbl.Visible = true;
                lblImageStLbl.Visible = true;
                lblImageOrderingLbl.Visible = true;
                textImageTitle.Visible = true;
                textImageSt.Visible = true;
                mtImageOrdering.Visible = true;
            }
            else
            {
                gbImageInfo.Visible = false;
                lblImageTitleLbl.Visible = false;
                lblImageStLbl.Visible = false;
                lblImageOrderingLbl.Visible = false;
                textImageTitle.Visible = false;
                textImageSt.Visible = false;
                mtImageOrdering.Visible = false;
            }
        }
        private void ImageInfoDataClear()
        {
            textImageTitle.Text = string.Empty;
            textImageSt.Text = string.Empty;
            mtImageOrdering.Text = string.Empty;
        }
        //private void btn_LoadImage_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog oFileDialog1 = new OpenFileDialog();

        //    oFileDialog1.Title = "Open Image File";
        //    oFileDialog1.InitialDirectory = "D:\\temp";     // To be replaced with actual path get from Db with respect to user
        //    oFileDialog1.Filter = "All files (*.*)|*.*|Jpeg files (*.jpg)|*.jpg|PNG files (*.png)|*.png";
        //    oFileDialog1.FilterIndex = 2;
        //    oFileDialog1.RestoreDirectory = true;

        //    if (oFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        string imgPath = oFileDialog1.FileName;
        //        iBAttach.Image = Image.FromFile(imgPath);
        //    }

        //}

        private byte[] ImageToByteArrayIB(ImageBox pbImage)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pbImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private byte[] ImageToByteArray(System.Windows.Forms.PictureBox pbImage)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pbImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private Image byteArrayToImage(byte[] byteBLOBData)
        {
            MemoryStream ms = new MemoryStream(byteBLOBData);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void dGvAttach_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dGvAttach.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
            {
                MessageBox.Show("Invalid column: exiting.....");
                return;
            }
            if (fLoadingImg == true)
            {
                return;
            }
            iBAttach.Image = (Image)dGvAttach.Rows[e.RowIndex].Cells["ImageData"].Value;
            textImageTitle.Text = dGvAttach.Rows[e.RowIndex].Cells["ImageTitle"].Value.ToString();
            textImageSt.Text = dGvAttach.Rows[e.RowIndex].Cells["ImageST"].Value.ToString();
            mtImageOrdering.Text = dGvAttach.Rows[e.RowIndex].Cells["ImageOrdering"].Value.ToString();
            // For Binnary Data 

            //try
            //{

            //    //Get image data from gridview column.
            //   //byte[] imageData = (byte[])dataGridView1.Rows[e.RowIndex].Cells["ImageData"].Value;
            //    byte[] imageData = (byte[])dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            //    //Initialize image variable
            //    Image newImage;
            //    //Read image data into a memory stream
            //    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
            //    {
            //        ms.Write(imageData, 0, imageData.Length);

            //        //Set image variable value using memory stream.
            //        newImage = Image.FromStream(ms, true);
            //    }

            //    //set picture
            //    // pictureBox1.Image = newImage;
            //    imageBox.Image = newImage;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

        }

        private void toolStripBtn_Actual_Click(object sender, EventArgs e)
        {
            iBAttach.ActualSize();
        }

        private void toolStripBtn_ZoomIn_Click(object sender, EventArgs e)
        {
            iBAttach.ZoomIn();
        }

        private void toolStripBtn_ZoomOut_Click(object sender, EventArgs e)
        {
            iBAttach.ZoomOut();
        }

        private void toolStripBtn_Load_Click(object sender, EventArgs e)
        {
            if (!DocValid())
            {
                return;
            }
            OpenFileDialog oFileDialog1 = new OpenFileDialog();

            oFileDialog1.Title = "Open Image File";
            oFileDialog1.InitialDirectory = "D:\\temp";     // To be replaced with actual path get from Db with respect to user
            oFileDialog1.Filter = "All files (*.*)|*.*|Jpeg files (*.jpg)|*.jpg|PNG files (*.png)|*.png";
            oFileDialog1.FilterIndex = 2;
            oFileDialog1.RestoreDirectory = true;

            if (oFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imgPath = oFileDialog1.FileName;
                iBAttach.Image = Image.FromFile(imgPath);
                string lImageName = oFileDialog1.Title.ToString();   //"";

                FileInfo fI = new FileInfo(imgPath);
                fImagePath = fI.FullName.ToString();
                fImageName = fI.Name.ToString();
                fImageExt = fI.Extension.ToString();
                if ((fI.Length / 1024) <= 1024)
                {
                    fImageSize = (fI.Length / 1024).ToString() + "K";
                }
                else
                {
                    fImageSize = (fI.Length / 1024 /1024).ToString() + "M";
                }

                fNewImageLoaded = true;
                ImageInfoData(true);
            }

        }
        // Prepare Document Where
        private string DocWhere(string pPrefix = "")
        {
            // pPrefix is including dot
            try
            {
                fDocWhere = " " + pPrefix + "doc_book_id = " + mtBookID.Text.ToString();
                fDocWhere += " and " + pPrefix + "doc_id = " + mtDocID.Text.ToString();
                fDocWhere += " and " + pPrefix + "doc_type_id = " + fDocType.ToString();
                fDocWhere += " and " + pPrefix + "doc_fiscal_id = " + mtFiscalID.Text.ToString();
                return fDocWhere;
            }
            catch 
            {
                throw;
            }
        }
        // Prepare Document Where
        private string NewDocWhere(string pPrefix = "")
        {
            // pPrefix is including dot
            try
            {
                fDocWhere = " " + pPrefix + "doc_book_id = " + mtBookID.Text.ToString();
                fDocWhere += " and " + pPrefix + "doc_type_id = " + fDocType.ToString();
                fDocWhere += " and " + pPrefix + "doc_fiscal_id = " + mtFiscalID.Text.ToString();
                return fDocWhere;
            }
            catch 
            {
                throw;
            }
        }

        private void toolStripBtn_Save_Click(object sender, EventArgs e)
        {
            if (DocValid(true))
            {
                if (textImageTitle.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("Image Title empty or blank,","Image Save: " + lblFormTitle.Text.ToString());
                    textImageTitle.Focus();
                    return;
                }
                if (textImageSt.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("Image Short Name empty or blank,", "Image Save: " + lblFormTitle.Text.ToString());
                    textImageSt.Focus();
                    return;
                }
                if (mtImageOrdering.Text.ToString().Trim(' ', '-') == "")
                {
                    MessageBox.Show("Image Ordering is zero or empty or blank,", "Image Save: " + lblFormTitle.Text.ToString());
                    mtImageOrdering.Focus();
                    return;
                }
                SaveImage();
            }
        }
        //
        private void SaveImage()
        {
            Int64 lNextID = clsDbManager.GetNextValDocID("img_attach", "attach_id",clsGVar.LGCY, "");
            try
            {
                if (!fNewImageLoaded)
                {
                    MessageBox.Show("Old Image or image not loaded, re-load the image...", lblFormTitle.Text.ToString());
                    return;
                }
                SqlConnection conn = new SqlConnection(clsGVar.ConString1);
                SqlCommand cmd = new SqlCommand("InsertPhoto", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                // ------------------ Header Fields -----------------------------
                // 1- Add the Loc parameter and set the value
                cmd.Parameters.AddWithValue("@Ploc_id", 1);         // 1
                // 2- Add the Group parameter and set the value
                cmd.Parameters.AddWithValue("@Pgrp_id", 1);         // 2
                // 3- Add the Company parameter and set the value
                cmd.Parameters.AddWithValue("@Pco_id", 1);          // 3
                // 4- Add the year parameter and set the value
                cmd.Parameters.AddWithValue("@Pyear_id", 1);        // 4
                // 6- Add the Document/Voucher Type parameter and set the value (for GL Vouchers etc)
                cmd.Parameters.AddWithValue("@Pattach_doc_book_id", Convert.ToInt16(mtBookID.Text.ToString()));    // 5a
                cmd.Parameters.AddWithValue("@Pattach_doc_type_id", 0);    // 6
                // 7- Add the Document/Voucher ID/Number parameter and set the value (Actual ID of Document/Voucher as stored in its source)
                // 8- Add the Fiscal Period parameter and set the value (Default = 0 for GL only)
                cmd.Parameters.AddWithValue("@Pattach_doc_fiscal_id", Convert.ToInt16(mtFiscalID.Text.ToString()));      // 8

                cmd.Parameters.AddWithValue("@Pattach_doc_id", Convert.ToInt32(mtDocID.Text.ToString())); // owner id .. 7
                // ------------------ Data Fields -------------------------------
                // 1- Add the Sequence Order parameter and set the value
                cmd.Parameters.AddWithValue("@Pattach_id", lNextID);      // 9
                //cmd.Parameters.AddWithValue("@Pattach_so", 1);          // 10 NA
                // 2- Add the Title parameter and set the value
                cmd.Parameters.AddWithValue("@Pattach_title", StrF01.EnEpos(textImageTitle.Text.ToString()));   // 10
                // 3- Add the short title parameter and set the value
                cmd.Parameters.AddWithValue("@Pattach_st", StrF01.EnEpos(textImageSt.Text.ToString()));            // 11
                int t1 = mtImageOrdering.Text.ToString().Trim(' ', '-') == "" ? 0 : Convert.ToInt16(mtImageOrdering.Text.ToString());
                if (mtImageOrdering.Text.ToString().Trim(' ', '-') == "")
                {
                    t1 = 0;
                }
                cmd.Parameters.AddWithValue("@Pordering", t1);            // 12
                // 4- Add the File Name parameter and set the value physical name of the image file
                cmd.Parameters.AddWithValue("@Pattach_name", "Read From File");            // 13
                // 5- Add the File Extension parameter and set the value
                cmd.Parameters.AddWithValue("@Pattach_ext", "jjj");             // 14
                // 6- Add the File Length/Disk space used parameter and set the value
                cmd.Parameters.AddWithValue("@Pattach_length", 20000);          // 15
                // 5- Add the Form parameter and set the value
                cmd.Parameters.AddWithValue("@Pfrm_id", fFormID);      // 5

                // 7- Add the image Thumbnail parameter and set the value
                // CFTTB: cmd.Parameters.AddWithValue("@attach_thumbnail", photo.Thumbnail);
                // 8- Add the image parameter and set the value

                Image votingBackgroundImage = iBAttach.Image;
                Bitmap votingBackgroundBitmap = new Bitmap(votingBackgroundImage);
                Image votingImage = (Image)votingBackgroundBitmap;
                var maxheight = (votingImage.Height * 3) + 2;
                var maxwidth = votingImage.Width * 2;

                //if (maxheight == 227 && maxwidth == 720)
                //{

                //System.IO.MemoryStream defaultImageStream = new System.IO.MemoryStream();
                //Bitmap NewImage = new Bitmap(votingImage, new Size(720, 227));
                //Image b = (Image)NewImage;
                //b.Save(defaultImageStream, System.Drawing.Imaging.ImageFormat.Bmp);
                //byte[] defaultImageData = new byte[defaultImageStream.Length];
                //} 

                byte[] defaultImageData = ImageToByteArrayIB(iBAttach);

                cmd.Parameters.AddWithValue("@Pattach_img", defaultImageData);     // 16   
                cmd.Parameters.AddWithValue("@Pattach_img1", defaultImageData);     // 17   

                // Add the return value parameter
                //SqlParameter param = cmd.Parameters.Add("RETURN_VALUE", SqlDbType.Int);
                //param.Direction = ParameterDirection.ReturnValue;

                // Execute the insert
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Image Saved, Rows Effected: " + n.ToString() + " ID: " + mtDocID.Text.ToString(), lblFormTitle.Text.ToString());
                    fNewImageLoaded = false;
                    ImageInfoData(false);
                    ImageInfoDataClear();
                }
                else
                {
                    MessageBox.Show("Image not saved, check error log", lblFormTitle.Text.ToString());
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Save Image: " + ex.Message, "Image: " + lblFormTitle.Text.ToString());
            }
        }

        private void btn_ShowDetailTop_Click(object sender, EventArgs e)
        {
            btnDetailTop.PerformClick();
        }

        private void btn_FocusGrid_Click(object sender, EventArgs e)
        {
            dGvDetail.Focus();
        }

        private void dGvDetail_Leave(object sender, EventArgs e)
        {
            fGridControl = false;
        }

        private void dGvDetail_Enter(object sender, EventArgs e)
        {
            fGridControl = true;
        }

        private void frmMaster_Detail_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (dGvDetail.Rows.Count > 1 || btn_Pin.Text.ToString() != "Pi&n")
                {
                    if (MessageBox.Show("Are You Sure To Exit Form ?", lblFormTitle.Text.ToString(), MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Form Closing: " + ex.Message, lblFormTitle.Text.ToString());
            }
        }

        private void toolStripBtn_Retrieve_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DocValid())
                {
                    return;
                }
                //========================================================================================
                SqlConnection CN = new SqlConnection(clsGVar.ConString1);
                //Initialize SQL adapter.
                string lSQL = "";
                lSQL = "select ordering, attach_st, attach_img1, attach_title";
                lSQL += " from img_attach ";
                lSQL += " where ";
                lSQL += clsGVar.LGCY;
                lSQL += " and ";
                lSQL += DocWhere("attach_");
                lSQL += " ORDER BY attach_doc_id, ordering ";
                //
                SqlDataAdapter ADAP = new SqlDataAdapter(lSQL, CN);
                //Initialize Dataset.
                DataSet DS = new DataSet();
                //Fill dataset with ImagesStore table.
                ADAP.Fill(DS, "img_attach");
                int lRecCount = DS.Tables[0].Rows.Count;
                if (lRecCount == 0)
                {
                    MessageBox.Show("No image to retrieve.", lblFormTitle.Text.ToString());
                    return;
                }
                fLoadingImg = true;
                DataRow dRow;
                //                       byteArrayToImage((byte[])DS.Tables[0].Rows[1]["picture"])
                //
                dGvAttach.AllowUserToAddRows = false;
                dGvAttach.RowTemplate.Height = 70;

                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    dRow = DS.Tables[0].Rows[i];
                    dGvAttach.Rows.Add(
                        dRow.ItemArray.GetValue(0).ToString(),
                        dRow.ItemArray.GetValue(1).ToString(),
                        //dRow.ItemArray.GetValue(1)                         
                        //byteArrayToImage((byte[])DS.Tables[0].Rows[i]["imagedata"])
                        byteArrayToImage((byte[])DS.Tables[0].Rows[i]["attach_img1"]),
                        dRow.ItemArray.GetValue(3).ToString()

                    );
                }
                fLoadingImg = false;
                ImageInfoData(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Retrieve Images: " + ex.Message, "Image: " + lblFormTitle.Text.ToString());
            }
        }

        private void btn_Debug_Click(object sender, EventArgs e)
        {
            if (fDebug)
            {
                lblDebug.Visible = false;
                fDebug = false;
            }
            else
            {
                lblDebug.Visible = true;
                fDebug = true;
            }
            lblDebug.Text = "Height: " + this.Height.ToString() + " Width: " + this.Width.ToString();
        }

        private void btn_SaveNContinue_Click(object sender, EventArgs e)
        {
            try
            {
                if (!tabMDtl.Contains(tabError))
                {
                    // Add New Tab
                    tabMDtl.TabPages.Add(tabError);
                }
                //
                if (!GridFilled())
                {
                    MessageBox.Show("Grid Empty or not valid. Check Errror Tab.", "Save: " + lblFormTitle.Text.ToString());
                    tabMDtl.SelectedTab = tabError;
                    return;

                }
                Cursor.Current = Cursors.WaitCursor;
                if (SaveData())
                {
                    Cursor.Current = Cursors.Default;
                    mtDocID.Text = fDocID.ToString();
                    mtDocID.Focus();
                    dGvDetail.Focus();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Processing Save: " + ex.Message, "Save: " + lblFormTitle.Text.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            fTErr++;
            dGvError.Rows.Add(fTErr.ToString(), "Debit/Credit", "1234", "Grid Tran. " + ", Both: Debiot:  Contain values, please select only one ...");

        }

        private void tSMI_TotalofDebits_Click(object sender, EventArgs e)
        {
            bool bcheck = false;
            decimal outValue;
            decimal lAppositValue = 0;
            decimal lCalTotal = 0;
            try
            {
                if (dGvDetail.Rows.Count > 0)
                {
                    int lLastRow = dGvDetail.Rows.Count - 1;
                    // value of apposit row
                    if (dGvDetail.Rows[lLastRow].Cells[(int)GCol.debit].Value != null)
                    {
                        bcheck = decimal.TryParse(dGvDetail.Rows[lLastRow].Cells[(int)GCol.debit].Value.ToString(), out outValue);
                        if (bcheck)
                        {
                            lAppositValue = outValue;
                        }
                    }
                    // Calculate Total
                    lCalTotal = sumDecimal(dGvDetail, (int)GCol.debit) - lAppositValue;
                    if (lCalTotal < 0)
                    {
                        lCalTotal = lCalTotal * (-1);
                    }
                    // Apposit Value Set to 0 (if any)
                    dGvDetail.Rows[lLastRow].Cells[(int)GCol.debit].Value = "0";
                    // Total of Debits fill in credit column
                    dGvDetail.Rows[lLastRow].Cells[(int)GCol.credit].Value = lCalTotal.ToString();
                    sumDebitCredit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception SumofDebits: " + ex.Message, lblFormTitle.Text.ToString());
            }
        }

        private void tSMI_TotalofCredits_Click(object sender, EventArgs e)
        {
            bool bcheck = false;
            decimal outValue;
            decimal lAppositValue = 0;
            decimal lCalTotal = 0;
            try
            {
                if (dGvDetail.Rows.Count > 0)
                {
                    int lLastRow = dGvDetail.Rows.Count - 1;
                    // value of apposit row
                    if (dGvDetail.Rows[lLastRow].Cells[(int)GCol.credit].Value != null)
                    {
                        bcheck = decimal.TryParse(dGvDetail.Rows[lLastRow].Cells[(int)GCol.credit].Value.ToString(), out outValue);
                        if (bcheck)
                        {
                            lAppositValue = outValue;
                        }
                    }
                    // Calculate Total
                    lCalTotal = sumDecimal(dGvDetail, (int)GCol.credit) - lAppositValue;
                    if (lCalTotal < 0)
                    {
                        lCalTotal = lCalTotal * (-1);
                    }
                    // Apposit Value Set to 0 (if any)
                    dGvDetail.Rows[lLastRow].Cells[(int)GCol.credit].Value = "0";
                    // Total of Debits fill in credit column
                    dGvDetail.Rows[lLastRow].Cells[(int)GCol.debit].Value = lCalTotal.ToString();
                    sumDebitCredit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception SumofCredits: " + ex.Message, lblFormTitle.Text.ToString());
            }
        }

        private void tSMI_ShowDifference_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime lNow = DateTime.Now;
                textAlert.Text = "Debit - Credit : " + (sumDecimal(dGvDetail, (int)GCol.debit) - sumDecimal(dGvDetail, (int)GCol.credit)).ToString() + "  " + lNow.ToString();
            }
            catch (Exception ex )
            {
                MessageBox.Show("Exception Show Difference: " + ex.Message,lblFormTitle.Text.ToString());
            }
        }

        private void tSMI_InsertNewRow_Click(object sender, EventArgs e)
        {
            if (!DocValid(false))
                // false = not check docID in mtDocID
            {
                return;
            }
            //if (dGvDetail.Rows.Count > 0)
            //{
                if (GridValid())
                {
                    InsertNewRowInGrid();
                }
                return;
            //}
        }

        private void tSMI_DeleteRow_Click(object sender, EventArgs e)
        {
            if (dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.acstrid].Value == null && dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.refid].Value == null)
            {
                dGvDetail.Rows.RemoveAt(dGvDetail.CurrentRow.Index);
                sumDebitCredit();
                return;
            }
            else
            {
                // When row is not empty;
                string lTranNo = dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.tranid].Value.ToString();
                if (MessageBox.Show("Are you sure, really want to Delete row/Tran. No. " + lTranNo + " ?", "Delete Row", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dGvDetail.Rows.RemoveAt(dGvDetail.CurrentRow.Index);
                    sumDebitCredit();
                    return;
                }
            }
        }

        private void mtBookID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tSMI_MoveDebitCredit_Click(object sender, EventArgs e)
        {
            DateTime lNow = DateTime.Now;
            bool bcheck = false;
            decimal outValue;
            decimal lValueToMove = 0;
            try
            {
                if (dGvDetail.Rows.Count > 0)
                {
                    int lLastRow = dGvDetail.Rows.Count - 1;

                    if (dGvDetail.CurrentCell.ColumnIndex == -1 || dGvDetail.CurrentCell.RowIndex == -1)
                    {
                        tSlblAlert.Text = "Move Debit to Credit vs: Nothing to Move." + lNow.ToString("T");
                        return;
                    }
                    if (dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.debit].Value != null)
                    {
                        bcheck = decimal.TryParse(dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.debit].Value.ToString(), out outValue);
                        if (bcheck)
                        {
                            lValueToMove = outValue;
                        }
                        if (lValueToMove > 0)
                        {
                            dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.debit].Value = "0";
                            dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.credit].Value = lValueToMove.ToString();
                        }
                        else
                        {
                            if (dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.credit].Value != null)
                            {
                                bcheck = decimal.TryParse(dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.credit].Value.ToString(), out outValue);
                                if (bcheck)
                                {
                                    lValueToMove = outValue;
                                }
                                if (lValueToMove > 0)
                                {
                                    dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.credit].Value = "0";
                                    dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.debit].Value = lValueToMove.ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.credit].Value != null)
                        {
                            bcheck = decimal.TryParse(dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.credit].Value.ToString(), out outValue);
                            if (bcheck)
                            {
                                lValueToMove = outValue;
                            }
                            if (lValueToMove > 0)
                            {
                                dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.credit].Value = "0";
                                dGvDetail.Rows[dGvDetail.CurrentRow.Index].Cells[(int)GCol.debit].Value = lValueToMove.ToString();
                            }
                        }
                    }
                    sumDebitCredit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Move Debit To Credit vs: " + ex.Message, lblFormTitle.Text.ToString());
            }

        }

        private void tSMI_LookUpAcID_Click(object sender, EventArgs e)
        {
            DateTime lNow = DateTime.Now;
            if (dGvDetail.Rows.Count > 0)
            {
                if (dGvDetail.CurrentCell.ColumnIndex == -1 || dGvDetail.CurrentCell.RowIndex == -1)
                {
                    textAlert.Text = "Operation not possible Account ID: click inside Grid Cell, try again" + lNow.ToString("T");
                    return;
                }
                tmtext.Text = string.Empty;
                GridLookUpAc("F8 Key: ", (int)dGvDetail.CurrentCell.RowIndex, (int)GCol.acstrid);
            }
        }

        private void tSMI_LookUpPrjID_Click(object sender, EventArgs e)
        {
            DateTime lNow = DateTime.Now;
            if (dGvDetail.Rows.Count > 0)
            {
                if (dGvDetail.CurrentCell.ColumnIndex == -1 || dGvDetail.CurrentCell.RowIndex == -1)
                {
                    textAlert.Text = "Operation not possible, Prj/Job ID: click inside Grid Cell, try again" + lNow.ToString("T");
                    return;
                }
                tmtext.Text = string.Empty;
                GridLookUpCity("F8 Key: ", (int)dGvDetail.CurrentCell.RowIndex, (int)GCol.refid);
            }
        }

        private void splitContParent_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            string plstField = "@Loc_ID,@Grp_ID,@Co_ID,@Year_ID,@Doc_Type_ID,@Doc_Fiscal_ID,@Doc_ID";
            string plstType = "8,8,8,8,8,8,8"; // {   "8, 8, 8, 8, 8, 8" };
            string plstValue = "1,1,1,1,0,0,5";
                //+ StrF01.D2Str(this.dtpFromDate.Value, false) + "," +
               //StrF01.D2Str(this.dtpToDate.Value, false);

            dsGLDoc ds = new dsGLDoc();
            CrGLDoc rpt1 = new CrGLDoc();
            fRptTitle = lblFormTitle.Text;

            frmViewerTrialB rptTrial = new frmViewerTrialB(
               fRptTitle,
               StrF01.D2Str(now, false),
               StrF01.D2Str(now, false),
               "sp_glDoc",
               plstField,
               plstType,
               plstValue,
               ds,
               rpt1,
               "SP"
               ); 

               //StrF01.D2Str(this.dtpFromDate.Value, false),
               //StrF01.D2Str(this.dtpToDate.Value, false),

            rptTrial.Show();

        }

        private void dGvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mtDocID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            pnlEntry.Visible = false;
            btn_FocusGrid.PerformClick();
        }








        //private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        //{
        //    //mtDocDate.Text = monthCalendar1.SelectionStart.ToString();
        //}



        //private void dGvDetail_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (dGvDetail.CurrentCell.ColumnIndex == 0)
        //        //if (e.KeyCode == Keys.Enter)
        //        //{
        //        //    e.Handled = true;
        //        //    System.Windows.Forms.SendKeys.Send("{TAB}");
        //        //}
        //        //else if (e.KeyCode == Keys.F3 )
        //        if (e.KeyCode == Keys.F3 && ActiveControl == dGvDetail)
        //        {
        //            MessageBox.Show("In F2");
        //            //frmSDILookUp();
        //        }
        //    } // end if
        //}

        //////////private void frmMaster_Detail_KeyDown(object sender, KeyEventArgs e)
        //////////{
        //////////    // Covering F2 key
        //////////    string activeControl = string.Empty;
        //////////    string activeContainerName = this.ActiveControl.GetType().ToString();
        //////////    string childSplitGrid = string.Empty;                    
        //////////    string childSplitParent = string.Empty;
        //////////    //
        //////////    if ( activeContainerName == "System.Windows.Forms.SplitContainer" ) 
        //////////    {
        //////////        string abc22 = ActiveControl.Name.ToString();
        //////////        if (ActiveControl.Name.ToString() == "splitContParent")
        //////////        {

        //////////            //SplitContainer activeConatiner = this.splitContParent as SplitContainer;
        //////////            //activeControl = activeConatiner.ActiveControl.GetType().ToString(); 
        //////////            string childcontrol = splitContParent.ActiveControl.Name.ToString();
        //////////            if (childcontrol != "")
        //////////            {
        //////////                if (childcontrol == "splitContGrid")
        //////////                {
        //////////                    childSplitGrid = splitContGrid.ActiveControl.Name.ToString();
        //////////                    if (childSplitGrid != "" || childSplitGrid != string.Empty)
        //////////                    {
        //////////                        switch (childSplitGrid)
        //////////                        {
        //////////                            case "dGvDetail":
        //////////                                if (e.KeyCode == Keys.F2)
        //////////                                {
        //////////                                    if (dGvDetail.CurrentCell.ColumnIndex == (int)GCol.acid || dGvDetail.CurrentCell.ColumnIndex == (int)GCol.refid)
        //////////                                    {
        //////////                                        //tStextAlert.Text = " in Grid cell";
        //////////                                        MessageBox.Show("Grid: childSplitGrid = dGvDetail Crr row = " + dGvDetail.CurrentCell.RowIndex.ToString()  );
        //////////                                        // dGvDetail.CurrentRow.Index.ToString() // is ok: now used: dGvDetail.CurrentCell.RowIndex.ToString()
        //////////                                        tmtext.Text = string.Empty;
        //////////                                        GridLookUp("F2 Key: ", (int)dGvDetail.CurrentCell.RowIndex, (int)dGvDetail.CurrentCell.ColumnIndex);
        //////////                                        break;
        //////////                                    }
        //////////                                }
        //////////                                //Do Something here if RichtextBox 
        //////////                                //break;
        //////////                                if (e.KeyCode == Keys.Enter)
        //////////                                {
        //////////                                    if (dGvDetail.CurrentCell.ColumnIndex == (int)GCol.debit || dGvDetail.CurrentCell.ColumnIndex == (int)GCol.credit)
        //////////                                    {
        //////////                                        decimal tvalue = 0;
        //////////                                        bool bChecking = decimal.TryParse(dGvDetail.CurrentCell.Value.ToString(), out tvalue);
        //////////                                        if (bChecking)
        //////////                                        {
        //////////                                            dGvDetail.CurrentCell.Value = String.Format("{0:N2}", tvalue);
        //////////                                        }
        //////////                                        break;
        //////////                                    }
                                        
        //////////                                }
        //////////                                break;
        //////////                            case "System.Windows.Forms.RichTextBox":
        //////////                                MessageBox.Show("RichText ");
        //////////                                //Do Something here if RichtextBox 
        //////////                                break;
        //////////                            case "System.Windows.Forms.Grid":
        //////////                                MessageBox.Show("Grid: ");
        //////////                                //Do Something here if Grid 
        //////////                                break;
        //////////                            default:

        //////////                                break;
        //////////                        } // end switch "splitContGrid"
        //////////                    } // end if (childSplitGrid != "" || childSplitGrid != string.Empty)
        //////////                }  // end childcontrol == "splitContGrid" first part
        //////////                else if (childcontrol == "mtBookID")
        //////////                {
        //////////                    // ============================================================================
        //////////                    childSplitParent = splitContParent.ActiveControl.Name.ToString();
        //////////                    if (childSplitParent != "" || childSplitParent != string.Empty)
        //////////                    {
        //////////                        switch (childSplitParent)
        //////////                        {
        //////////                            case "mtBookID":
        //////////                                if (e.KeyCode == Keys.F2)
        //////////                                {
        //////////                                    //tStextAlert.Text = " in Grid cell";
        //////////                                    MessageBox.Show("mTextBox = dGvDetail Crr row = else part" );
        //////////                                    // dGvDetail.CurrentRow.Index.ToString() // is ok: now used: dGvDetail.CurrentCell.RowIndex.ToString()
        //////////                                    tmtext.Text = string.Empty;
        //////////                                    mTextLookUp();
        //////////                                }
        //////////                                //Do Something here if RichtextBox 
        //////////                                break;

        //////////                            case "System.Windows.Forms.RichTextBox":
        //////////                                MessageBox.Show("RichText ");
        //////////                                //Do Something here if RichtextBox 
        //////////                                break;
        //////////                            case "System.Windows.Forms.Grid":
        //////////                                MessageBox.Show("Grid: ");
        //////////                                //Do Something here if Grid 
        //////////                                break;
        //////////                            default:

        //////////                                break;
        //////////                        } // end switch "mtBookID"
        //////////                    } // end if (childSplitGrid != "" || childSplitGrid != string.Empty)

        //////////                    // ============================================================================
        //////////                } // end childcontrol == "splitContGrid" else part
        //////////            } // end if (childSplitParent != "" || childSplitParent != string.Empty)
        //////////        }
        //////////    }


        //////////    //string abc = ActiveControl.Name.ToString();
        //////////    //string abc1 = splitContParent.ActiveControl.Name.ToString();        // Very Important
        //////////    ////string abc2 = splitContGrid.ActiveControl.Name.ToString();
        //////////    //tStextAlert.Text = "Ready to jump";
        //////////    //if (e.KeyCode == Keys.F2 && splitContParent.ActiveControl.Name.ToString() == "mtBookID")
        //////////    //{
        //////////    //    tStextAlert.Text = " in textbox: mtBookID";
        //////////    //    //MessageBox.Show("MtEXTbOX bOOK id: In F3");
        //////////    //    //return;                
        //////////    //}
        //////////    ////else if (e.KeyCode == Keys.F2 && splitContParent.ActiveControl.Name.ToString() == "dGvDetail")
        //////////    //else if (e.KeyCode == Keys.F2 &&  splitContGrid.ActiveControl.Name.ToString() == "dGvDetail")
        //////////    //{
        //////////    //    if (dGvDetail.CurrentCell.ColumnIndex == 0)
        //////////    //    {
        //////////    //        tStextAlert.Text = " in Grid cell";
        //////////    //    }
        //////////    //        //MessageBox.Show("In F3");
        //////////    //    //frmSDILookUp();
        //////////    //}
        //////////    // Reference
        //////////    //if (e.Alt == true && e.KeyCode == Keys.C)
        //////////    //{
        //////////    //    Form2 f2 = new Form2();
        //////////    //    f2.Show();
        //////////    //} 

        //////////}

        //private void dGvDetail_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //if (e.KeyCode == Keys.Enter)
        //    //{
        //    //    if (dGvDetail.CurrentCell.ColumnIndex == (int)GCol.debit || dGvDetail.CurrentCell.ColumnIndex == (int)GCol.credit)
        //    //    {
        //    //        decimal tvalue = 0;
        //    //        bool bChecking = decimal.TryParse(dGvDetail.CurrentCell.Value.ToString(), out tvalue);
        //    //        if (bChecking)
        //    //        {
        //    //            dGvDetail.CurrentCell.Value = String.Format("{0:N2}", tvalue);
        //    //        }
        //    //    }

        //    //} // if key.Enter
        //// end method    
        //}

        //private void dGvDetail_Leave(object sender, EventArgs e)
        //{
        //    if (dGvDetail.CurrentCell.ColumnIndex == (int)GCol.debit || dGvDetail.CurrentCell.ColumnIndex == (int)GCol.credit)
        //    {
        //        decimal tvalue = 0;
        //        bool bChecking = decimal.TryParse(dGvDetail.CurrentCell.Value.ToString(), out tvalue);
        //        if (bChecking)
        //        {
        //            MessageBox.Show("Leave of grid");
        //            dGvDetail.CurrentCell.Value = String.Format("{0:N2}", tvalue);
        //        }
        //    }

        //}

     
    }
}


// Reference:
// http://www.c-sharpcorner.com/UploadFile/shivprasadk/learn-net-in-60-days-–-part-1-13-labs/
// http://www.youtube.com/playlist?list=PL0BB0AD0F12A24B6E&feature=plcp
// 21 videos 3:35:57 duration Learn .NET in 60 days series



