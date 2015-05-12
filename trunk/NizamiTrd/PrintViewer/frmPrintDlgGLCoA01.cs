using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// 
using NizamiTrd.PrintViewer;
using NizamiTrd.StringFun01;
using NizamiTrd.Class;
using NizamiTrd.PrintDataSets;
using NizamiTrd.PrintReport;

namespace NizamiTrd
{
    public partial class frmPrintDlgGLCoA01 : Form
    {

        List<KeyValuePair<int, string>> fCboList;
        string fStrNine = "99999999999999999999";
        string fStrZero = "00000000000000000000";
        DateTime fFiscalDateStart = clsGetGvar.FiscalDateStart;
        DateTime fFiscalDateEnd = clsGetGvar.FiscalDateEnd;
        int fDefaultCboIndex = 0;
        string fTableNameStart = string.Empty;
        // Layout Options
        string fFormTitle = string.Empty;
        bool fInputCbo = false;
        bool fInputDate = true;
        bool fInputId = true;
        string fIdType = string.Empty;
        bool fInputSorting = true;
        bool fInputOptions = true;
        string fInputOptionList = "";
        bool fIsStoredProcedure = true;
        // Report Viewer Parameters
        string fRptTitle = "";
        string fListField = "";
        string fListSQLType = "";
        string fListValue = "";
        string fOptionalTitle1 = "";
        string fOptionalTitle2 = "";
        string fSelectedSp = "";
        //
        // if  pInputCbo = trie tjem stored procedured or table name is available depending upon combo value
        // Other wise IsStoredProcedure will provide name of stored procedure
        // In case pInputCbo = false and IsstoredProcedure is also "" then ?
        //
        public frmPrintDlgGLCoA01(
          String pFormTitle,
          bool pInputCbo,
          bool pInputDate,
          bool pInputId,
          string pIdType,
          bool pInputOptions,
          string pInputOptionList,
          bool pInputSorting,
          bool pIsStoredProcedure

            )
        {
            InitializeComponent();
            //
            fFormTitle = pFormTitle;
            fInputCbo = pInputCbo;
            fInputDate = pInputDate;
            fInputId = pInputId;
            fIdType = pIdType;
            fInputOptions = pInputOptions;
            fInputOptionList = pInputOptionList;
            fInputSorting = pInputSorting;
            fIsStoredProcedure = pIsStoredProcedure;

            //fCustomQry = pCustomQry;
            //
            lblFormTitle.Text = fFormTitle;
        }
        //private void AtFormLoad()
        //{
        //    List<KeyValuePair<int, string>> tCboList = new List<KeyValuePair<int, string>>();
        //    tCboList.Add(new KeyValuePair<int, string>(1009, "1- Business Category ID"));
        //    tCboList.Add(new KeyValuePair<int, string>(1009, "2- Position In Business ID"));
        //    tCboList.Add(new KeyValuePair<int, string>(1009, "3- Attitude ID"));
        //    tCboList.Add(new KeyValuePair<int, string>(1009, "4- Willing To Sell ID"));
        //    tCboList.Add(new KeyValuePair<int, string>(1009, "5- Visibility (Willing For) ID"));
        //    tCboList.Add(new KeyValuePair<int, string>(1009, "6- Deliverable Item ID"));
        //    tCboList.Add(new KeyValuePair<int, string>(1009, "7- Third Party Brand ID"));

        //    // Form Layout
        //    this.MaximizeBox = false;
        //    this.KeyPreview = true;
        //    this.FormBorderStyle = FormBorderStyle.FixedSingle;
        //    rBtnNumeric.Checked = true;
        //    // Note It is working properly it the list key is sorted. If rendom it will not work properly
        //    // For example key 15 was at the end then it was not able to find item with the "set index" click of button 
        //    //var listForCbo = new List<KeyValuePair<int, string>>();

        //    this.Text = clsGVar.CoTitle + "  [ " + clsGVar.YrTitle + " ]";
        //    // Clear the combobox
        //    cboSelectRpt.DataSource = null;
        //    cboSelectRpt.Items.Clear();

        //    // Bind the combobox
        //    cboSelectRpt.DataSource = new BindingSource(fCboList, null);
        //    cboSelectRpt.DisplayMember = "Value";
        //    cboSelectRpt.ValueMember = "Key";
        //    //fDefaultCboIndex = Convert.ToInt32(cboSelectRpt.SelectedValue);
        //    cboSelectRpt.SelectedIndex = 0;
        //    fDefaultCboIndex = Convert.ToInt32(cboSelectRpt.SelectedIndex);
        //    //mtextIdStart.HidePromptOnLeave = true;
        //    //mtextIdEnd.HidePromptOnLeave = true;
        //    //
        //    cboSetIndex();
        //    //
        //    mtextIdStart.Text = "1";
        //    mtextIdEnd.Text = fStrNine.Substring(0, (mtextIdEnd.Mask).Length);
        //}

        private void frmPrintDlgList_Load(object sender, EventArgs e)
        {
            //AtFormLoad();
            SetFormLayout();                                          // 01- Form Size, Position, Type
            SetControlMask();                                         // 02- Mask for Text Boxes, Max Length, Auto Save Settings
            //SetControlToolTips();                                     // 03- Add tool tips to the controls
            //SetContextMenuForm();                                     // 04- Set Context Menu Form
            //SetContextMenuGrid();                                     // 05- Set Context Menu Grid
            //LoadDataIntegration();                                    // 08- Load Integration Data like, Control Accounts, and Integration with other modules  (if any)
            LoadDataCbo();                                            // 06- Load Data For ComboBox (if any) 
            //SetGridLayout();                                          // 07- Set Grid Headers (if any)
            ////SetInitialData();                                       // 09- Load Initial Data necessary for the form if any (dependent table list)  (if any)
            ////HideControls();                                         // 10- Hide Controls kepts for future or discarded (but necessary for DML)  (if any)
            //SetCurrentDate();
            //tabInvoice.TabPages.Remove(tabError);                       // Tab for display error appeared during save/Delete process
            //clsMasterFormRequired CheckRequired = new clsMasterFormRequired();
            //string lValidationError = CheckRequired.RequiredControls(this.Controls, true);
            // This Shoould/Must be the Last Segment of the Code Block
            //fIsFormLoading = false;
            //
            // Set Start/End and Min/Max Date
            // the value of this constant is equivalent to 00:00:00.0000000, January 1, 0001.
            dtpStart.Value = fFiscalDateStart;
            dtpStart.MinDate = fFiscalDateStart;
            dtpStart.MaxDate = fFiscalDateEnd;

            dtpEnd.Value = fFiscalDateEnd;
            dtpEnd.MinDate = fFiscalDateStart;
            dtpEnd.MaxDate = fFiscalDateEnd;

            this.ActiveControl = cboSelectRpt;
        }
        //
        private void SetFormLayout()
        {
            // X = Horizontal, Y = Vertical
            lblFormTitle.Text = fFormTitle;
            this.KeyPreview = true;
            this.MinimumSize = new Size(416, 420);
            this.Top = clsGVar.frmTopGeneralIds;
            this.Left = clsGVar.frmLeftGeneralIds;
            this.StartPosition = FormStartPosition.CenterParent;                    // for Dialog Form only (Not working hardcoded is required at Property level
            clsGVar.SetFormColorGL(lblTopLine1, lblTopLine2, lblTopLine3);

            if (fIdType.ToUpper() == "GL")
            {
                gBId.Text = "GL Id";
            }
            else if (fIdType.ToUpper() == "INV_FIN")
            {
                gBId.Text = "Inventory Id";
            }
            if (!fInputDate)
            {
                gBDate.Visible = false;
                gBId.Location = new System.Drawing.Point(gBId.Location.X, gBId.Location.Y - gBDate.Size.Height);
                gBOptions.Location = new System.Drawing.Point(gBOptions.Location.X, gBOptions.Location.Y - gBDate.Size.Height);
                gBSortOrder.Location = new System.Drawing.Point(gBSortOrder.Location.X, gBSortOrder.Location.Y - gBDate.Size.Height);
            }
            //
            if (!fInputOptions)
            {
                gBOptions.Visible = false;
                gBSortOrder.Location = new System.Drawing.Point(gBSortOrder.Location.X, gBSortOrder.Location.Y - gBOptions.Size.Height);
            }
            if (!fInputSorting)
            {
                gBSortOrder.Visible = false;
            }

        }
        // 
        private void SetControlMask()
        {
            mtextIdStart.BorderStyle = BorderStyle.FixedSingle;
            mtextIdEnd.BorderStyle = BorderStyle.FixedSingle;
            //
            if (fIdType.ToUpper() == "GL")
            {
                mtextIdStart.Mask = clsGetGvar.MaskGlId;
                mtextIdEnd.Mask = clsGetGvar.MaskGlId;
            }
            else if (fIdType.ToUpper() == "INV_FIN")
            {
                mtextIdStart.Mask = clsGetGvar.MaskInventoryId;
                mtextIdEnd.Mask = clsGetGvar.MaskInventoryId;
            }
            mtextIdStart.HidePromptOnLeave = true;
            mtextIdEnd.HidePromptOnLeave = true;


        }
        private void LoadDataCbo()
        {
//<<<<<<< .mine
          List<KeyValuePair<int, string>> tCboList = new List<KeyValuePair<int, string>>();
          tCboList.Add(new KeyValuePair<int, string>(1, "Trial Balance"));
          tCboList.Add(new KeyValuePair<int, string>(2, "Trial Balance Optional"));
          tCboList.Add(new KeyValuePair<int, string>(3, "Account Ledger"));
          tCboList.Add(new KeyValuePair<int, string>(4, "Pending Bilty Report"));
          // Form Layout
          this.MaximizeBox = false;
          this.KeyPreview = true;
          this.FormBorderStyle = FormBorderStyle.FixedSingle;
          rBtnNumeric.Checked = true;
          // Note It is working properly it the list key is sorted. If rendom it will not work properly
          // For example key 15 was at the end then it was not able to find item with the "set index" click of button 
          //var listForCbo = new List<KeyValuePair<int, string>>();
//=======
            //List<KeyValuePair<int, string>> tCboList = new List<KeyValuePair<int, string>>();
            //tCboList.Add(new KeyValuePair<int, string>(1009, "Trial Balance"));
            //tCboList.Add(new KeyValuePair<int, string>(1010, "Trial Balance Optional"));
            //tCboList.Add(new KeyValuePair<int, string>(1011, "Account Ledger"));
            //// Form Layout
            //this.MaximizeBox = false;
            //this.KeyPreview = true;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //rBtnNumeric.Checked = true;
            //// Note It is working properly it the list key is sorted. If rendom it will not work properly
            // For example key 15 was at the end then it was not able to find item with the "set index" click of button 
            //var listForCbo = new List<KeyValuePair<int, string>>();
//>>>>>>> .r14

            this.Text = clsGVar.CoTitle + "  [ " + clsGVar.YrTitle + " ]";
            // Clear the combobox
            cboSelectRpt.DataSource = null;
            cboSelectRpt.Items.Clear();

            // Bind the combobox
            cboSelectRpt.DataSource = new BindingSource(tCboList, null);
            cboSelectRpt.DisplayMember = "Value";
            cboSelectRpt.ValueMember = "Key";
            //fDefaultCboIndex = Convert.ToInt32(cboSelectRpt.SelectedValue);
            cboSelectRpt.SelectedIndex = 0;
            fDefaultCboIndex = Convert.ToInt32(cboSelectRpt.SelectedIndex);
            //mtextIdStart.HidePromptOnLeave = true;
            //mtextIdEnd.HidePromptOnLeave = true;
            //
            cboSetIndex();
            //
            mtextIdStart.Text = fStrZero.Substring(0, (mtextIdStart.Mask).Length);
            mtextIdEnd.Text = fStrNine.Substring(0, (mtextIdEnd.Mask).Length);
            //

        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            // Validate Input Fields
            string tDateStart = StrF01.D2Str(dtpStart);
            string tDateEnd = StrF01.D2Str(dtpEnd);

            try
            {
                // Remove Quot from beginning and end
                if (Convert.ToDateTime(tDateStart.TrimEnd('\'').TrimStart('\'')) > Convert.ToDateTime(tDateEnd.TrimEnd('\'').TrimStart('\'')))
                {
                    MessageBox.Show("Start Date > End Date, please re-enter and try again...", lblFormTitle.Text.ToString());
                    return;
                }

                string lTableNameMast = string.Empty;
                string lTableNameDtl = string.Empty;
                string lMastFL = string.Empty;
                string lDtlFL = string.Empty;
                string lPidInDtl = string.Empty;
                //
                string lIDStart = string.Empty;
                string lIDEnd = string.Empty;
                string lOrder = string.Empty;
                string lIncludeZeroDtl = string.Empty;
                string lOptions = string.Empty;
                //

                string abc1 = (mtextIdStart.Text).ToString().Replace('-', '0');
                string abc2 = (mtextIdEnd.Text).ToString().Replace('-', '0');

                //label1.Text = cboSelectRpt.SelectedValue.ToString() + " Index = " + cboSelectRpt.SelectedIndex.ToString();
                if (Convert.ToInt64(abc1) > Convert.ToInt64(abc2))
                {
                    MessageBox.Show("Warning: 'Ending ID' Less then 'Starting ID'", "Print ID List");
                    mtextIdStart.Focus();
                    return;
                }
                //
                if (PrePareReportParameters())
                {
                    dsLedgerNew ds = new dsLedgerNew();

                    switch (cboSelectRpt.SelectedIndex)
                    {
                        case 0:
                            {
                                CrTrial rptName = new CrTrial();
                                frmPrintViewer rptLedger = new frmPrintViewer(
                                          fRptTitle,
                                          fOptionalTitle1,
                                          fOptionalTitle2,
                                          fSelectedSp,
                                          fListField,
                                          fListSQLType,
                                          fListValue,
                                          ds,
                                          rptName,
                                          "SP"
                                          );
                                rptLedger.Show();
                                break;
                            }
                        case 1:
                            {
                                CrTrialOp rptName = new CrTrialOp();
                                frmPrintViewer rptLedger = new frmPrintViewer(
                                      fRptTitle,
                                      fOptionalTitle1,
                                      fOptionalTitle2,
                                      fSelectedSp,
                                      fListField,
                                      fListSQLType,
                                      fListValue,
                                      ds,
                                      rptName,
                                      "SP"
                                      );
                                rptLedger.Show();

                                break;
                            }
                        case 2:
                            {
                                CrLedger rptName = new CrLedger();
                                frmPrintViewer rptLedger = new frmPrintViewer(
                                          fRptTitle,
                                          fOptionalTitle1,
                                          fOptionalTitle2,
                                          fSelectedSp,
                                          fListField,
                                          fListSQLType,
                                          fListValue,
                                          ds,
                                          rptName,
                                          "SP"
                                          );
                                rptLedger.Show();
                                break;
                            }
                        default:
                            break;
                    }
                    //frmPrintViewer rptLedger = new frmPrintViewer(
                    //  fRptTitle,
                    //  fOptionalTitle1,
                    //  fOptionalTitle2,
                    //  fSelectedSp,
                    //  fListField,
                    //  fListSQLType,
                    //  fListValue,
                    //  ds,
                    //  rptName,
                    //  "SP"
                    //  );

                    //rptLedger.Show();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception, View: " + ex.Message, lblFormTitle.Text.ToString());
            }
        }
        private bool PrePareReportParameters()
        {
            bool rtnValue = true;

            fRptTitle = "Trial Balance Optional";
            fListField = "";
            fListSQLType = "";
            fListValue = "";
            fOptionalTitle1 = dtpStart.Text.ToString(); ;
            fOptionalTitle2 = dtpEnd.Text.ToString();
            //

            try
            {
                if (fInputCbo)
                {
                    if (cboSelectRpt.Items.Count > 0)
                    {
                        fRptTitle = cboSelectRpt.Text.ToString();
                    }
                }

                fListField += "@pLoc_id";
                fListField += ",@pGrp_id";
                fListField += ",@pCo_id";
                fListField += ",@pYear_id";
                if (fInputDate)
                {
                    fListField += ",@pDateStart";
                    fListField += ",@pDateEnd";
                }
                if (fInputId)
                {
                    fListField += ",@pIdStart";
                    fListField += ",@pIdEnd";
                }
                if (fInputOptions)
                {
                    fListField += "";
                }
                //
                fListSQLType += "8";      // Int
                fListSQLType += ",8";
                fListSQLType += ",8";
                fListSQLType += ",8";
                if (fInputDate)
                {
                    fListSQLType += ",18";   // Text
                    fListSQLType += ",18";
                }
                if (fInputId)
                {
                    fListSQLType += ",18";   // Text
                    fListSQLType += ",18";
                }

                //
                fListValue += clsGVar.LocID.ToString();
                fListValue += "," + clsGVar.GrpID.ToString();
                fListValue += "," + clsGVar.CoID.ToString();
                fListValue += "," + clsGVar.YrID.ToString();
                if (fInputDate)
                {
                    fListValue += "," + StrF01.ToShortD2StrCrystal(dtpStart);
                    fListValue += "," + StrF01.ToShortD2StrCrystal(dtpEnd);        // StrF01.ToShortD2StrCrystal(
                }
                if (fInputId)
                {
                    fListValue += "," + "" + mtextIdStart.Text.ToString() + "";
                    fListValue += "," + "" + mtextIdEnd.Text.ToString() + "";
                }
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception, Preparing Report Parameters: " + ex.Message, lblFormTitle.Text.ToString());
                return false;
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearThisForm();
        }
        private void ClearThisForm()
        {
            mtextIdStart.Text = string.Empty;
            mtextIdEnd.Text = string.Empty;
            rBtnNumeric.Checked = true;
            chkIncludeZeroTranDetail.Checked = false;
            cboSelectRpt.SelectedIndex = 0; // fDefaultCboIndex;      // Important Note: this should also be implemented in SDI forms
            if (fInputDate)
            {
                if (btn_PinParentID.Text == "&Pin")
                {
                    dtpStart.Value = fFiscalDateStart;
                    dtpEnd.Value = fFiscalDateEnd;
                }
            }
        }
        private void cboSelectRpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSetIndex();
        }
        //---------------------------------------------------------------------------------------
        private void cboSetIndex()
        {
            fRptTitle = cboSelectRpt.Text.ToString();
            if (cboSelectRpt.SelectedIndex == -1)
            {
                cboSelectRpt.SelectedIndex = 0;
            }

            switch (cboSelectRpt.SelectedIndex)
            {
                case 0:
                    {
                        fSelectedSp = "sp_gl_Trial";

                        fInputId = true;
                        break;
                    }
                case 1:
                    {
                        fSelectedSp = "sp_gl_Trial_Op";
                        fInputId = false;
                        break;
                    }
                case 2:
                    {
                        fSelectedSp = "sp_gl_Ledger";
                        fInputId = true;
                        break;
                    }

                default:
                    break;
            }


        }
        //---------------------------------------------------------------------------------------
        private void lblIDEnd_Click(object sender, EventArgs e)
        {
            if (mtextIdStart.Text.ToString().Trim(' ', '-') != "" || mtextIdStart.Text != "" || mtextIdStart.Text != string.Empty)
            {
                mtextIdEnd.Text = mtextIdStart.Text;
            }
        }
        //
        private void mtextIDStart_DoubleClick(object sender, EventArgs e)
        {
            frmSDILookUp();
        }
        public void frmSDILookUp()
        {
            //string strString = string.Empty;
            //if (fMastFL != string.Empty && fDtlFL != string.Empty)
            //{
            //    // The following will be redesigned.
            //    fField = fDtlFL.Split(',');
            //    fKeyField = fField[0];
            //    LFL = fField[1] + "," + fField[2];
            //    //fFormTitle = "List " + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(fTableName.ToLower()) + " ID";
            //    //fFT = "ID," + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(fTableName.ToLower()) + " Title,Short";
            //}
            //else
            //{
            //    MessageBox.Show("Error: Insufficient parameters, Please inform Technical Team.","Lookup: Print ID List");
            //    return;
            //}
            //// The following code block is left blank if needed for custom requirments.
            //switch (cboSelectRpt.SelectedIndex)
            //{
            //    case 0:
            //        {
            //            break;
            //        }
            //    case 1:
            //        {
            //            break;
            //        }
            //    case 2:
            //        {
            //            break;
            //        }

            //    default:
            //        {
            //            //
            //            break;
            //        }
            //}

            ////                              [KeyField],[FieldList],[TableName],[FormTitle],[DefaultFindField],[FieldTitle],[TitleWidth],[TitleFormat],[OneTable],[Join],[TBType]
            //frmLookUp sForm = new frmLookUp(fKeyField, LFL, fTableNameMast, fFormTitle, 1, fFT, fTitleWidth, fTitleFormat, true);    // fJoin = optional
            //sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            //sForm.ShowDialog();
            //if (mtextIDStart.Text != null)
            //{
            //    if (mtextIDStart.Text.ToString() == "" || mtextIDStart.Text.ToString() == string.Empty)
            //    {
            //        return;
            //    }
            //    System.Windows.Forms.SendKeys.Send("{TAB}");
            //}
        }
        // ---- Start Event/Delegate--------------------------------
        private void PassData(object sender)
        {
            mtextIdStart.Text = ((MaskedTextBox)sender).Text;
        }

        private void frmPrintDlgListMastDtlOne_KeyDown(object sender, KeyEventArgs e)
        {
            // set KeyPreview = true
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.F2 && ActiveControl == mtextIdStart)
            {
                frmSDILookUp();
            }

        }

        private void chkIncludeZeroTranDetail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            dtpEnd.Value = dtpStart.Value;
        }

        private void btn_PinParentID_Click(object sender, EventArgs e)
        {
            if (btn_PinParentID.Text == "&Pin")
            {
                btn_PinParentID.Text = "&Un Pin";
                btn_PinParentID.Image = NizamiTrd.Properties.Resources.BaBa_tiny_pinned;
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
            }
            else
            {
                btn_PinParentID.Text = "&Pin";
                btn_PinParentID.Image = NizamiTrd.Properties.Resources.BaBa_tiny_pin;
                dtpStart.Enabled = true;
                dtpEnd.Enabled = true;
            }
        }

        private void mtextIdStart_DoubleClick_1(object sender, EventArgs e)
        {
            LookUpIdStart();
        }
        private void LookUpIdStart()
        {
            if (fInputId)
            {
                // Lookup Selection
                if (fIdType.ToUpper() == "GL")
                {
                    LookUpGLIdStart();
                } // if "GL"
                else if (fIdType.ToUpper() == "INV_FIN")
                {
                    //LookUpInvId();
                } // if "INV_FIN"
            } // if fInputId
        }
        //
        private void LookUpIdEnd()
        {
            if (fInputId)
            {
                // Lookup Selection
                if (fIdType.ToUpper() == "GL")
                {
                    LookUpGLIdEnd();
                } // if "GL"
                else if (fIdType.ToUpper() == "INV_FIN")
                {
                    //LookUpInvId();
                } // if "INV_FIN"
            } // if fInputId
        }
        //
        private void LookUpGLIdStart()
        {
            clsLookUpGLAc GLLookUp = new clsLookUpGLAc(mtextIdStart, lblFormTitle.Text.ToString());
            GLLookUp.FindGLTransactionalId();
        } // End LookUpGLID
        //
        private void LookUpGLIdEnd()
        {
            clsLookUpGLAc GLLookUp = new clsLookUpGLAc(mtextIdEnd, lblFormTitle.Text.ToString());
            GLLookUp.FindGLTransactionalId();
        } // End LookUpGLID
        //

        private void mtextIdStart_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F8)
                {
                    LookUpIdStart();
                } // end if
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception, GL Lookup Id : " + ex.Message, lblFormTitle.Text.ToString());
            }
        }

        private void mtextIdStart_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mtextIdEnd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F8)
                {
                    LookUpIdEnd();
                } // end if
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception, GL Lookup Id : " + ex.Message, lblFormTitle.Text.ToString());
            }

        }

        private void mtextIdEnd_DoubleClick(object sender, EventArgs e)
        {
            LookUpIdEnd();
        }

        private void lblFormTitle_DoubleClick(object sender, EventArgs e)
        {
            //dtpStart.MinDate = DateTime(00:00:00.0000000, January 1, 0001);  // DateTime.MinValue;
            dtpStart.MinDate = clsGetGvar.ResetMinDate;
            dtpStart.MaxDate = clsGetGvar.ResetMaxDate;
            dtpEnd.MinDate = clsGetGvar.ResetMinDate;
            dtpEnd.MaxDate = clsGetGvar.ResetMaxDate;
        }

        private void lblFormTitle_Click(object sender, EventArgs e)
        {

        }

        //private void cboSelectRpt_Click(object sender, EventArgs e)
        //{
        //    cboSetIndex();
        //}




    }
}
