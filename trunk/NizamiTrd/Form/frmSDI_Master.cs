using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using TaxSolution.StringFun01;
//using TaxSolution.Cmn;
// using System.Threading;  // for testing of wait cursor

namespace TaxSolution
{
  public partial class frmSDI_Master : Form
  {
    LookUp lookUpForm = new LookUp();

    // Parameters Form Level
    string fZeroStr = "000000000000000000000000000000";
    string fLastID = string.Empty;
    int fFormID = 0;
    string fFormTitle = string.Empty;
    string fTableName = string.Empty;
    string fKeyField = string.Empty;
    string fKeyFieldType = string.Empty;
    string ErrrMsg = string.Empty;
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
    string fJoin = string.Empty;

    int pLocID = 0;
    //int pGrpID = 0;
    //int pCoID = 0;
    //int pYearID = 0;
    // Parameter to Class level
    // 30 Zeros
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
    public frmSDI_Master(
      string pMain, 
      string pBeginParam, 
      string pFLBegin, 
      string pFL, 
      string pFLEnd, 
      string pFLenBegin, 
      string pFLen, 
      string pFLenEnd, 
      string pFTBegin, 
      string pFT, 
      string pFTEnd, 
      string pValRBegin, 
      string pValR, 
      string pValREnd, 
      string pTitleWidth, 
      string pTitleFormat)
    {
      // FormID, Title, Table, KeyField, KeyFieldType, 
      InitializeComponent();
      HookEvents();
      // Buttons
      btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
      // Form Main Parameters
      // Class level variables
      cMain = pMain;                            // Main Parameters
  
      cFLBegin = pFLBegin;                      // Field List Beginning Loc,grp,co,year
      cFL = pFL;                                // Field List Body
      cFLEnd = pFLEnd;                          // Field List End
      cFLenBegin = pFLenBegin;                  // Field Len Beginning
      cFLen = pFLen;                            // Field Len Body
      cFLenEnd = pFLenEnd;                      // Field Len End
      cFTBegin = pFTBegin;                      // Field Title Beginning  
      cFT = pFT;                                // Field Title Body
      cFTEnd = pFTEnd;                          // Field Title End
      cValRBegin = pValRBegin;                  // Validation Rule Begining
      cValR = pValR;                            // Validation Rule Body
      cValREnd = pValREnd;                      // Validtion Rule End
      //
      fMain = pMain.Split(',');                 // Main Parameters
      fFormID = Convert.ToInt32(fMain[0]);      // Form ID
      fFormTitle = fMain[1];                    // Form Title
      fTableName = fMain[2];                    // Table Name
      fKeyField = fMain[3];                     // Key Field Name
      fKeyFieldType = fMain[4];                 // Key Field Type   (Int, Long, etc)
                                                // Address Button
                                                // RecInfo: Creation Date, Created by, Modified Date, Modified By

      fBeginParam = pBeginParam.Split(',');     // Begin Parameters/CoData
      //pLocID = Convert.ToInt16(fBeginParam[0]);
      //pGrpID = Convert.ToInt16(fBeginParam[1]);
      //pCoID = Convert.ToInt16(fBeginParam[2]);
      //pYearID = Convert.ToInt16(fBeginParam[3]);
      //      
      fTitleWidth = pTitleWidth;    // Title Width for lookup columns (15,50,30,20) etc
      fTitleFormat = pTitleFormat;  // Title Format for lookup columns (N = Numeric, T=Text etc)
      
      //
      this.Text = fFormTitle;
      lblFormTitle.Text = fFormTitle;
      // Length Text Boxes
      if (pFLBegin == string.Empty || pFLBegin == "")
      {
        // Field List
        fField = (pFL + "," + pFLEnd).Split(',');
        // Field Titles
        fFieldTitle = (pFT + "," + pFTEnd).Split(',');
        // Validation: Required
        fValR = (pValR + "," + pValREnd).Split(',');

      }
      else
      {
        // Field List
        fField = (pFLBegin + "," + pFL + "," + pFLEnd).Split(',');
        // Field Titles
        fFieldTitle = (pFTBegin + "," + pFT + "," + pFTEnd).Split(',');
        // Validation: Required
        fValR = (pValRBegin + "," + pValR + "," + pValREnd).Split(',');

      }

      fMaxLen = pFLen.Split(',');
      mtextID.MaxLength = Convert.ToInt16(fMaxLen[0]);
      textTitle.MaxLength = Convert.ToInt16(fMaxLen[1]);
      textST.MaxLength = Convert.ToInt16(fMaxLen[2]);
      // Marked Edit
      mtextID.Mask = fZeroStr.Substring(0, Convert.ToInt16(fMaxLen[0])); 
      mtextOrdering.Mask = fZeroStr.Substring(0, Convert.ToInt16(fMaxLen[3]));

      // Context Menu Setup
      this.contextMenuStripSDI_Master.Items.AddRange(new
      System.Windows.Forms.ToolStripItem[] { this.toolStripMenuItemSDI_Master1, this.toolStripMenuItemSDI_Master2 });

    }

    private void frmSDI_Master_Load(object sender, EventArgs e)
    {
        AtFormLoad();

    }

    #region AtFormLoad

    private void AtFormLoad()
    {
        ButtonImageSetting();
        // Form Layout
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        //
        this.Text = clsGVar.CoTitle + "  [ " + clsGVar.YrTitle + " ]";

        mtextID.HidePromptOnLeave = true;
        mtextOrdering.HidePromptOnLeave = true;
        if (fMain[5] == "1")
        {
            fAddressBtn = true;
            btn_Address.Visible = true;
        }
        // ToolTip
        toolTipSDI.IsBalloon = true;
        toolTipSDI.ToolTipTitle = fFormTitle;
        toolTipSDI.SetToolTip(mtextID, (toolTipSDI.GetToolTip(mtextID) + " " + mtextID.Mask.ToString()));
        toolTipSDI.SetToolTip(textTitle, (toolTipSDI.GetToolTip(textTitle) + " " + fMaxLen[1] + " Characters"));
        toolTipSDI.SetToolTip(textST, (toolTipSDI.GetToolTip(textST) + " " + fMaxLen[2] + " Characters"));
        //toolTipSDI.SetToolTip(mtextOrdering, (toolTipSDI.GetToolTip(mtextOrdering) + " " + fMaxLen[3] + " Characters"));
        toolTipSDI.SetToolTip(mtextOrdering, ("Required: Ordering Or Sequence: Priority to appear in View/Combo Box, Max. Length: " + mtextOrdering.Mask.ToString().Length + " Numeric Characters"));
        // (mtextOrdering.Mask.ToString()).Length();
        // Buttons
        toolTipSDI.SetToolTip(btn_Save, "Alt+S, Save New record or Modify/Update an existing record");
        toolTipSDI.SetToolTip(btn_Clear, "Alt+C, Clear all input control/items on this form");
        toolTipSDI.SetToolTip(btn_Delete, "Alt+D, Delete currently selected record");
        toolTipSDI.SetToolTip(btn_Exit, "Alt+X, Close this form and exit to the Main Form");
        toolTipSDI.SetToolTip(btn_Address, "Alt+A or Mouse Click to Open Address Input  Detailed Form");
        //string tSQL = string.Empty;
        //tSQL = "SELECT count(" + fKeyField + ") as cRecTotal, max(" + fKeyField + ") as cLastid FROM " + fTableName;
        toolStripStatuslblTotalText.Text = clsDbManager.GetTotalRec(fTableName, fKeyField);

        //
        //textAlert.Text = clsGVar.LGCY;
    }

    #endregion

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
        btn_Address.Image = Properties.Resources.ico_inbox;
        //btn_OpeningBalance.Image = Properties.Resources.ico_admin;
        //btn_NextID.Image = Properties.Resources.ico_arrow_r;
    }


    private void btn_Exit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btn_Clear_Click(object sender, EventArgs e)
    {
      ClearThisForm();
    }

    #region ClearThisform

    private void ClearThisForm()
    {
      //textID1.Text = string.Empty;
      mtextID.Text = string.Empty;
      textTitle.Text = string.Empty;
      textST.Text = string.Empty;
      mtextOrdering.Text = string.Empty;
      chkIsDisabled.Checked = false;
      chkIsDefault.Checked = false;

      btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
      btn_Address.Enabled = false;
      mtextID.Enabled = true;
      mtextID.Focus();
    }

    #endregion

    private void btn_Save_Click(object sender, EventArgs e)
    {
        Cursor.Current = Cursors.WaitCursor;
        SaveData();
        Cursor.Current = Cursors.Default;
    }

    private void toolStripLabel1_Click(object sender, EventArgs e)
    {
      // Pick from Db table
      // for the time being it is from last id + 1
      if (mtextID.Enabled)
      {
        if (fLastID != string.Empty)
        {
          mtextID.Text = (Convert.ToInt32(fLastID) + 1).ToString();
        }
      }
      else
      {
          textAlert.Text = "Cannot display Last ID, use clear button.";
      }
    }

    private void mtextID_Validating(object sender, CancelEventArgs e)
    {
      //  MessageBox.Show("Control >>: " + ((Control)sender).GetType().Name.ToString());  for record and ref
        try
        {
            if (mtextID.Text.ToString() == "" || mtextID.Text.ToString() == string.Empty)
            {
                return;
            }
            else
            {
                if (Convert.ToInt64(mtextID.Text) > 0)    // Selected large int so that it may not conflict with int16, int32 etc
                {
                    string tSQL = string.Empty;

                    //int t1 = 0;
                    //int t2 = 0;

                    // Fields 0,1,2,3 are Begin  
                    tSQL = "select top 1 " + fField[0] + " as title," + fField[1] + " as stitle," + fField[2] + ", " + fField[3] + ", " + fField[4];
                    tSQL += " from " + fTableName;
                    tSQL += " where ";
                    //tSQL += clsGVar.LGCY;
                    //tSQL += " and ";
                    tSQL += fKeyField + " = " + mtextID.Text.ToString();

                    //========================================================
                    DataSet dtset = new DataSet();
                    DataRow dRow;
                    dtset = clsDbManager.GetData_Set(tSQL, fTableName);
                    //int abc = dtset.Tables.Count; // gives the number of tables.
                    int abc = dtset.Tables[0].Rows.Count;

                    //if (abc == 0 || abc == null)
                    if (abc == 0)
                    {
                        fAlreadyExists = false;
                    }
                    else
                    {
                        fAlreadyExists = true;
                        dRow = dtset.Tables[0].Rows[0];
                        // Starting title as 0
                        textTitle.Text = dRow.ItemArray.GetValue(0).ToString(); // dtset.Tables[0].Rows[0][0].ToString();
                        textST.Text = dRow.ItemArray.GetValue(1).ToString(); // dtset.Tables[0].Rows[0][1].ToString();
                        mtextOrdering.Text = dRow.ItemArray.GetValue(2).ToString(); // dtset.Tables[0].Rows[0][1].ToString();

                        //t1 = Convert.ToInt16(dRow.ItemArray.GetValue(2));
                        //t2 = Convert.ToInt16(dRow.ItemArray.GetValue(3));

                        //abc = (Convert.ToInt16)dtset.Tables[0].Rows[0][1].ToString();

                        //chkIsDisabled.Checked = t1 == 1 ? true : false;
                        //chkIsDefault.Checked = t2 == 1 ? true : false;
                        if (dRow.ItemArray.GetValue(3) != DBNull.Value)
                        {
                            chkIsDisabled.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(3).ToString());
                        }
                        else
                        {
                            chkIsDisabled.Checked = false;
                        }
                        if (dRow.ItemArray.GetValue(4) != DBNull.Value)
                        {
                            chkIsDefault.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(4).ToString());
                        }
                        else
                        {
                            chkIsDefault.Checked = false;
                        }
                    }


                    //
                    if (fAlreadyExists)
                    {
                        btn_Save.Enabled = true;
                        btn_Delete.Enabled = true;
                        toolStripStatuslblStatusText.Text = "Modify";
                        if (fAddressBtn)
                        {
                            btn_Address.Enabled = true;
                        }
                    }
                    else
                    {
                        btn_Save.Enabled = false;
                        btn_Delete.Enabled = false;
                        toolStripStatuslblStatusText.Text = "New";
                    }
                    mtextID.Enabled = false;
                }
                else
                {
                    btn_Save.Enabled = false;
                    btn_Delete.Enabled = false;
                    toolStripStatuslblStatusText.Text = "Err.";
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Exception: " + ex.Message ,lblFormTitle.Text.ToString());
        }

    }

    private void toolStripMenuItemSDI_Master2_Click(object sender, EventArgs e)
    {
      if (mtextID.Enabled)
      {
        mtextID.Text = clsDbManager.GetNextValMastID(fTableName, fKeyField, "").ToString();
      }
      else
      {
        textAlert.Text = "Cannot display Next ID, use clear button.";
      }

      //if (fLastID != string.Empty)
      //{
      //  mtextID.Text = fLastID;
      //}
    }
    // Validity of Data
    private bool FormValidation()
    {
      bool IsValid = true;
      fAlreadyExists = false;
      ErrrMsg = string.Empty;
      for (int i = 0; i < fValR.Length; i++)
      {
        if (fValR[i] == "R")
        {
          switch (i)
          { 
            // 0 - 3 = Co Data
            case 4 :
              if (mtextID.Text.ToString() == "" || mtextID.Text.ToString() == string.Empty)
              {
                // ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank ";
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
                IsValid = false;
              }
              break;
            case 5 :
              if (textTitle.Text.ToString() == "" || textTitle.Text.ToString() == string.Empty)
              {
                //ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank ";
               ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
                
                IsValid = false;
              }
              break;
            case 6:
              if (textST.Text.ToString() == "" || textST.Text.ToString() == string.Empty)
              {
                //ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank "; 
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
                IsValid = false;
              }
              break;
             // 7 - 8 = Optional Data

          }
        }
      }
      // Already Exists
      fAlreadyExists = clsDbManager.IDAlreadyExist(fTableName, fKeyField, mtextID.Text.ToString(), "");

      return IsValid;
    }
    // 
    //private string BuildErrMsg(string fLastErrMsg, string fCurErrMsg)
    //{
    //    string tStr = string.Empty;
    //    if (fCurErrMsg.Length == 0 )
    //    {
    //      tStr = "Err Message Not Provided....";
    //      return tStr;
    //    }
    //    else
    //    {
    //        if (fLastErrMsg.Length > 0)
    //        {
    //          tStr = fLastErrMsg + "\r\n" + fCurErrMsg;
    //        }
    //          else
    //        {
    //          tStr = fCurErrMsg;
    //        }
    //    }
    //    return tStr;
    //}

    private void btn_Delete_Click(object sender, EventArgs e)
    {
        // Confirmation Message
        if (MessageBox.Show("Are You Sure Really want to Delete ?", fFormTitle, MessageBoxButtons.OKCancel) == DialogResult.OK)
        {
            string tSQL = string.Empty;
            tSQL = "Delete from " + fTableName;
            tSQL += " where ";
            tSQL += fKeyField + " = " + mtextID.ToString();
            //tSQL += clsGVar.LGCY;
            //tSQL += " and ";
            //if (cFLBegin != string.Empty)
            //{
            //  tSQL += " loc_id = " + pYearID.ToString() + " and grp_id = " + pYearID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString() + " and ";
            //}

            //try
            //{
            //    #region Execute Query to save data

            //    if (clsDbManager.ExeOne(tSQL))
            //    {
                    MessageBox.Show("ID: " + mtextID.Text.ToString() + " : " + textTitle.Text.ToString() + "\r\nDeleted... ", fFormTitle);

                    ClearThisForm();
            //        //return true;
            //    }
            //    else
            //    {
            //        textAlert.Text = "ID: " + mtextID.Text.ToString() + " Not Deleted: Try again....";
            //        //return false;
            //    }

            //    #endregion
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Exception: Save: " + e.Message, lblFormTitle.Text.ToString());
            //    //return false;
            //}
        }
    }


    private void button1_Click(object sender, EventArgs e)
    {
      // Toggle function
      // ok working: chkIsDisabled.Checked = ! chkIsDisabled.Checked;
      string tSQL = string.Empty;
      //tSQL = "ThreeState: " + chkIsDisabled.ThreeState.ToString() + "\n" +
      //           "Checked: " + chkIsDisabled.Checked.ToString() + "\n" +
      //           "CheckState: " + chkIsDisabled.CheckState.ToString();

      //chkIsDisabled.Checked = true; // chkIsDisabled.Checked;
      tSQL="This is test";
      lblFormTitle.Text = tSQL;

      //MessageBox.Show(tSQL);
    }

    private void frmSDI_Master_KeyDown(object sender, KeyEventArgs e)
    {
      // set KeyPreview = true
      if (e.KeyCode == Keys.Enter) 
        { 
            e.Handled = true;
            System.Windows.Forms.SendKeys.Send("{TAB}"); 
        }
      else if (e.KeyCode == Keys.F2 && ActiveControl == mtextID)
      {
        frmSDILookUp();
      }
    }
    // ------------------------------------
    private void EnableDisableSaveBtn()
    {
      // use of Delegate
      btn_Save.Enabled = !string.IsNullOrEmpty(textTitle.Text) && !string.IsNullOrEmpty(mtextID.Text);
    }
    private void HookEvents()
    {
      textTitle.TextChanged += delegate { EnableDisableSaveBtn(); };
    }

    private void mtextID_Enter(object sender, EventArgs e)
    {
      toolStripStatuslblStatusText.Text = "Ready";
    }

    private void toolStripStatuslblAlertTitle_Click(object sender, EventArgs e)
    {
      textAlert.Text = string.Empty;
    }

    private void mtextID_DoubleClick(object sender, EventArgs e)
    {
      frmSDILookUp();
    }

    private void frmSDI_Master_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (mtextID.Text != string.Empty && textTitle.ToString().Trim().Length >0)
      {
        if (MessageBox.Show("Are You Sure To Exit the Form ?", "In Closing Title", MessageBoxButtons.OKCancel) != DialogResult.OK)
        {
          e.Cancel = true;
        }
      }
    }
    // Start Save
    private bool SaveData()
    {
      // Check Validity of Data
      if (!FormValidation())
      {
        //MessageBox.Show(ErrrMsg, "Validation Error :");
        textAlert.Text = "Validation Error: Not Saved.";
        return false;
      }
      // Thread.Sleep(5000);   // Commented: just to check wait cursor // also commented above: using System.Threading;
      string tSQL = string.Empty;
      try
      {
          #region Insert/Update

          if (!fAlreadyExists)
          {
                // Insert/New
                // fField = (pFL + "," + pFLEnd).Split(',');                        // Title Starts At 0: Without Grp,Co,Year (title, st, ordering, is disabled)
                // fField = (pFLBegin + "," + pFL + "," + pFLEnd).Split(',');     // Title Start at 3 : With Grp,Co,Year (f0, f1, f2 + title, st, ordering + Is Disabled)
                tSQL = "insert into " + fTableName + " (";
                //tSQL += fField[0] + ", " + fField[1] + ", " + fField[2];              // Loc,Grp,Co
                //tSQL += " , " + fField[3];                                             // Year                
                tSQL += "   " + fKeyField;                                            // ID 
                tSQL += " , " + fField[0];                                            // title
                tSQL += " , " + fField[1];                                            // ST 
                tSQL += " , " + fField[2];                                            // Ordering 
                tSQL += " , " + fField[3];                                            // IsDisabled bit
                tSQL += " , " + fField[4];                                            // IsDefault bit
                tSQL += " , " + fField[5];                                            // FrmID  
                tSQL += " , created_by, created_date ";                               // Created by Int, created_date

                tSQL += ") values ( ";
                //
                //tSQL +=  clsGVar.LocID.ToString();
                //tSQL += ", " + clsGVar.GrpID.ToString();
                //tSQL += ", " + clsGVar.CoID.ToString();
                //tSQL += ", " + clsGVar.YrID.ToString();
              //
              tSQL += " " + mtextID.Text.ToString();
              tSQL += ", " + "'" + StrF01.EnEpos(textTitle.Text.ToString().Trim()) + "'";
              tSQL += ", " + "'" + StrF01.EnEpos(textST.Text.ToString().Trim()) + "'";
              if (mtextOrdering.Text.ToString() == null || mtextOrdering.Text.ToString().Trim() == "")
              {
                  tSQL += ", 0";
              }
              else
              {
                  tSQL += ", " + mtextOrdering.Text.ToString();
              }
              if (chkIsDisabled.Checked == true)
              {
                  tSQL += ", 1";
              }
              else
              {
                  tSQL += ", 0";
              }
              // is Default is 0 at insert level, unchanged at update level (it will be implemented through a seperate form.
              tSQL += ", 0";
              tSQL += ", " + fFormID.ToString();
              tSQL += ", " + clsGVar.AppUserID.ToString() + ", '" + StrF01.D2Str(DateTime.Now, true) + "'";
              tSQL += ")";
          }
          else
          {
              // Modify/Update
              tSQL = "update " + fTableName + " set ";
                  tSQL += "  " + fField[0] + " = '" + StrF01.EnEpos(textTitle.Text.ToString()) + "'";
                  tSQL += ", " + fField[1] + " = '" + StrF01.EnEpos(textST.Text.ToString()) + "'";
                  if (mtextOrdering.Text.ToString() == null || mtextOrdering.Text.ToString().Trim() == "")
                  {
                      tSQL += ", " + fField[2] + " = 0";
                  }
                  else
                  {
                      tSQL += ", " + fField[2] + " = " + mtextOrdering.Text.ToString();
                  }
                  if (chkIsDisabled.Checked == true)
                  {
                      tSQL += ", " + fField[3] + " = 1";
                  }
                  else
                  {
                      tSQL += ", " + fField[3] + " = 0";
                  }

                  //tSQL += ", " + fField[8] + " = " + fFormID;
                  tSQL += ", modified_by = " + clsGVar.AppUserID.ToString();
                  tSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";
                  tSQL += " where ";
                  //tSQL += clsGVar.LGCY;
                  //tSQL += " and ";

                  //tSQL += " loc_id = " + clsGVar.gLocID.ToString();
                  //tSQL += " and grp_id = " + clsGVar.gGrpID.ToString();
                  //tSQL += " and co_id = " + clsGVar.gCoID.ToString();
                  //tSQL += " and year_id = " + clsGVar.gYrID.ToString();
                  //tSQL += " and ";
                  tSQL += fKeyField + " = " + mtextID.Text.ToString();
          }

          #endregion

      }
      catch (Exception e)
      {
          MessageBox.Show("Exception: Before Save: " + e.Message,lblFormTitle.Text.ToString());
          return false;
      }

      try
      {
          #region Execute Query to save data

          if (clsDbManager.ExeOne(tSQL))
          {
              fLastID = mtextID.Text.ToString();
              if (fAlreadyExists)
              {
                  textAlert.Text = "Existing ID: " + fLastID + " Modified ....";
              }
              else
              {
                  textAlert.Text = "New ID: " + fLastID + " Inserted ....";
              }
              //MessageBox.Show("Rec Saved....");
              ClearThisForm();
              return true;
          }
          else
          {
              textAlert.Text = "ID: " + mtextID.Text.ToString() + " Not Saved: Try again....";
              return false;
          }

          #endregion
      }
      catch (Exception e)
      {
          MessageBox.Show("Exception: Save: " + e.Message, lblFormTitle.Text.ToString());
          return false;
      }

    }
    // End Save
    public void frmSDILookUp()
    {
        try
        {
            //                              [FieldList],[KeyField],[TableName],[FormTitle],[DefaultFindField],[FieldTitle],[TitleWidth],[TitleFormat],[OneTable],[Join],[TBType]
            frmLookUp sForm = new frmLookUp(fKeyField, cFL, fTableName, fFormTitle, 1, cFT, fTitleWidth, fTitleFormat, true, fJoin);
            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (mtextID.Text != null)
            {
                if (mtextID.Text.ToString() == "" || mtextID.Text.ToString() == string.Empty)
                {
                    return;
                }
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }

        }
        catch (Exception e)
        {
            MessageBox.Show("Exception: Lookup " + e.Message, lblFormTitle.Text.ToString());
        }

    }
    // ----Event/Delegate--------------------------------
    private void PassData(object sender)
    {
      mtextID.Text = ((MaskedTextBox)sender).Text;
    }

    // --------------------------------------------------------------------------------
    public void frmSDILookUp1()
    {
         //                              [FieldList],[KeyField],[TableName],[FormTitle],[DefaultFindField],[FieldTitle],[TitleWidth],[TitleFormat],[OneTable],[Join],[TBType]
         frmLookUp sForm = new frmLookUp(fKeyField, cFL, fTableName, fFormTitle, 1, cFT, fTitleWidth, fTitleFormat,true,"","TextBox");
         sForm.lupassControl = new frmLookUp.LUPassControl(PassData1);          // LookUp PassControl
         sForm.ShowDialog();
    }
     // 2nd Delegate for testing
    private void PassData1(object sender)
    {
         textTitle.Text = ((TextBox)sender).Text;
    }
    // ------------------------------------------------------------------------------
 
    private void btn_Address_Click(object sender, EventArgs e)
    {
        // 1- FormID
        // 2- ID    
        // 3- Title
        //frmAddress_Master Dlg_Address = new frmAddress_Master(
        //    fFormID, 
        //    textTitle.Text.ToString(),
        //    Convert.ToInt32(mtextID.Text), 
        //    "Select * from cmn_address;"
        //    );
        ////Dlg_Address.MdiParent = this.MdiParent; // working
        ////Dlg_Address.Show();
        //Dlg_Address.ShowDialog();
    }

    private void textTitle_DoubleClick(object sender, EventArgs e)
    {
         frmSDILookUp1();
    }

    private void lblOrdering_Click(object sender, EventArgs e)
    {
      mtextOrdering.Text = mtextID.Text;
    }

    private void mtextID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {

    }

    private void mtextID_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            frmSDILookUp();
        }
    }
  }

}
