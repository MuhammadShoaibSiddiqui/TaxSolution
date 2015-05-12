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
using System.Text.RegularExpressions;
//using TLERP.Cmn;
// using System.Threading;  // for testing of wait cursor

namespace TaxSolution
{
  public partial class frmGodown : Form
  {
    LookUp lookUpForm = new LookUp();

    // Parameters Form Level
    string fZeroStr = "000000000000000000000000000000";
    string fLastID = string.Empty;
    int fFormID = 0;
    Int64 fGLID = 0;
    string fFormTitle = string.Empty;
    string fTableName = string.Empty;
    string fKeyField = string.Empty;
    string fKeyFieldType = string.Empty;
    string ErrrMsg = string.Empty;
    bool fAlreadyExists = false;
    string fTitleWidth = string.Empty;
    string fTitleFormat = string.Empty;
    
    string[] fMain;
    string[] fBeginParam;
    string[] fField;  
    string[] fMaxLen;
    string[] fFieldTitle;
    string[] fValidationRule;
    string fJoin = string.Empty;

    // Parameter to Class level
    // 30 Zeros
    string fMainString = string.Empty;
    string fFieldListString = string.Empty;
    string fFieldLength = string.Empty;
    string fFieldTitleString = string.Empty;
    string fValidationRuleString = string.Empty;
    //
    //string cTitleWidth = string.Empty;
    //string cTitleFormat = string.Empty;
    //
    public frmGodown(
        string pMain, 
        string pFieldList, 
        string pFieldLength, 
        string pFieldTitle, 
        string pValidationRule,
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
      fMainString = pMain;                            // Main Parameters
      fMain = pMain.Split(',');                 // Main Parameters
      fFormID = Convert.ToInt16(fMain[0]);      // Form ID
      fFormTitle = fMain[1];                    // Form Title
      fTableName = fMain[2];                    // Table Name
      fKeyField = fMain[3];                     // Key Field Name
      fKeyFieldType = fMain[4];                 // Key Field Type   (Int, Long, etc)
      fTitleWidth = pTitleWidth;    // Title Width for lookup columns (15,50,30,20) etc
      fTitleFormat = pTitleFormat;  // Title Format for lookup columns (N = Numeric, T=Text etc)


      fFieldListString = fKeyField + "," + pFieldList;                                // Field List Body
      fFieldLength = pFieldLength;                            // Field Len Body
      fFieldTitleString = pFieldTitle;                        // Field Title Body
      fValidationRuleString = pValidationRule;                // Validation Rule Body
      //
 
                                                // RecInfo: Creation Date, Created by, Modified Date, Modified By

      //pLocID = Convert.ToInt16(fBeginParam[0]);
      //pGrpID = Convert.ToInt16(fBeginParam[1]);
      //pCoID = Convert.ToInt16(fBeginParam[2]);
      //pYearID = Convert.ToInt16(fBeginParam[3]);
      //      
      
      //
      this.Text = fFormTitle;
      lblFormTitle.Text = fFormTitle;
      // Length Text Boxes
        // Field List
      fField = (fFieldListString).Split(',');
        // Field Titles
        fFieldTitle = (pFieldTitle).Split(',');
        // Validation: Required
        fValidationRule = (pValidationRule).Split(',');

      fMaxLen = pFieldLength.Split(',');
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
        // Form Layout
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        //
        this.Top = 0;
        this.Left = 230;

        this.Text = clsGVar.CoTitle + "  [ " + clsGVar.YrTitle + " ]";
        // Load Mask
        //
        ButtonImageSetting();

        //
        mtextID.HidePromptOnLeave = true;
        mtextOrdering.HidePromptOnLeave = true;
        mtextGLID.Mask = "#-#-##-##-####";
        mtextGLID.HidePromptOnLeave = true;
        lblAcTitle.BorderStyle = BorderStyle.FixedSingle;
        //mtToID.Mask = ""; 
        //mtToID.HidePromptOnLeave = true;
        //
        // ToolTip
        toolTipSDI.IsBalloon = true;
        toolTipSDI.ToolTipTitle = fFormTitle;
        toolTipSDI.SetToolTip(mtextID, (toolTipSDI.GetToolTip(mtextID) + " " + mtextID.Mask.ToString()));
        toolTipSDI.SetToolTip(textTitle, (toolTipSDI.GetToolTip(textTitle) + " " + fMaxLen[1] + " Characters"));
        toolTipSDI.SetToolTip(textST, (toolTipSDI.GetToolTip(textST) + " " + fMaxLen[2] + " Characters"));
        //toolTipSDI.SetToolTip(mtextOrdering, (toolTipSDI.GetToolTip(mtextOrdering) + " " + fMaxLen[3] + " Characters"));
        toolTipSDI.SetToolTip(mtextOrdering, ("Required: Ordering Or Sequence: Priority to appear in View/Combo Box, Max. Length: " + mtextOrdering.Mask.ToString().Length + " Numeric Characters"));
        //toolTipSDI.SetToolTip(gBAcNature, "Account is Balance Sheet type or Revenue / Profit & Loss type");
        //toolTipSDI.SetToolTip(gBBalanceSide, "Natural Balance Side: Debit Side or Credit Side");

        // (mtextOrdering.Mask.ToString()).Length();
        // Buttons
        toolTipSDI.SetToolTip(btn_Save, "Alt+S, Save New record or Modify/Update an existing record");
        toolTipSDI.SetToolTip(btn_Clear, "Alt+C, Clear all input control/items on this form");
        toolTipSDI.SetToolTip(btn_Delete, "Alt+D, Delete currently selected record");
        toolTipSDI.SetToolTip(btn_Exit, "Alt+X, Close this form and exit to the Main Form");
        //string tSQL = string.Empty;
        //tSQL = "SELECT count(" + fKeyField + ") as cRecTotal, max(" + fKeyField + ") as cLastid FROM " + fTableName;
        toolStripStatuslblTotalText.Text = clsDbManager.GetTotalRec(fTableName, fKeyField);

        //
        textAlert.Text = clsGVar.LGCY;
        //ReadData();
    }

    #endregion

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
      mtextGLID.Text = string.Empty;
      lblAcTitle.Text = string.Empty;
      //mtToID.Text = string.Empty;

      //chkIsAddressApplicable.Checked = false;
      //chkIsDisabled.Checked = false;
      chkIsDefault.Checked = false;

      btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
      //btn_Address.Enabled = false;
      mtextID.Enabled = true;
      mtextID.Focus();
    }
    //private void ReadData()
    //{
    //    string lSQL = "";
    //    lSQL = "SELECT top 1 ";
    //    lSQL += " aclevel_mask";                                            // 0-
    //    lSQL += " FROM cnf_levelmst ";
    //    lSQL += " where ";
    //    lSQL += clsGVar.LGCY;

    //    try
    //    {
    //        //DataRow dRow;
    //        DataSet Zdtset = clsDbManager.GetData_Set(lSQL, "cnf_levelmst");

    //        int lRecCount = Zdtset.Tables[0].Rows.Count;
    //        int formid = 0;
    //        string formtitle = "";
    //        if (lRecCount == 0)
    //        {
    //            MessageBox.Show("Accunt Mask not found, Consult Administrator.", lblFormTitle.Text.ToString());
    //            return;
    //        }
    //        // DocMaster
    //        //dRow = Zdtset.Tables[0].Rows[0];doc_type_id
    //        mtFromID.Mask = Zdtset.Tables[0].Rows[0]["aclevel_mask"].ToString();
    //        mtToID.Mask = Zdtset.Tables[0].Rows[0]["aclevel_mask"].ToString(); 
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show("Exception: Account Mask Loading... " + ex.Message, lblFormTitle.Text.ToString());
    //    }
    //}

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
        //btn_Address.Image = Properties.Resources.ico_inbox;
        //btn_OpeningBalance.Image = Properties.Resources.ico_admin;
        //btn_NextID.Image = Properties.Resources.ico_arrow_r;
    }

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
      if (fLastID != string.Empty)
      {
        mtextID.Text = (Convert.ToInt32(fLastID) + 1).ToString();
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

                    // Fields 0,1,2,3 are Begin  
                    tSQL = "select top 1 "; 
                    tSQL += "godown_title,";                      // as 0
                    tSQL += "godown_st,";                         // as 1
                    tSQL += "ordering, ";                         // as 2  Ordering   
                    tSQL += "godown_ac_id, ";                     // as 3 from GL ID
                    tSQL += "isdisabled, ";                       // as 4 6 Is disabled
                    tSQL += "isdefault";                          // as 5 7 Is Default
                    tSQL += " from " + fTableName;
                    tSQL += " where ";
                    tSQL += fKeyField + " = " + mtextID.Text.ToString();
                    //========================================================
                    DataSet dtset = new DataSet();
                    DataRow dRow;
                    dtset = clsDbManager.GetData_Set(tSQL, fTableName);
                    //int abc = dtset.Tables.Count; // gives the number of tables.
                    int abc = dtset.Tables[0].Rows.Count;

                    if (abc == 0 || abc == null)
                    {
                        fAlreadyExists = false;
                    }
                    else
                    {
                        fAlreadyExists = true;
                        dRow = dtset.Tables[0].Rows[0];
                        // Starting title as 0
                        textTitle.Text = dRow.ItemArray.GetValue(0).ToString(); // title;
                        textST.Text = dRow.ItemArray.GetValue(1).ToString(); // st
                        mtextOrdering.Text = dRow.ItemArray.GetValue(2).ToString(); // ordering
                        // From ID
                        if (dRow.ItemArray.GetValue(3) != DBNull.Value)
                        {
                          string[] lGLTitle;
                          string lTitleID = "";
                            fGLID = Convert.ToInt64(dRow.ItemArray.GetValue(3).ToString());
                            // string pTable,
                            // string pStrIDFieldName,
                            // string pTitleFieldName,
                            // string pNumFieldName,
                            // Int64 pSearchValue,
                            // string pCustomQry = ""
                            // <<SPLITER>>
                            lTitleID =  clsDbManager.GetTitlnStrAcID(
                                    "gl_ac",
                                    "ac_strid",
                                    "ac_title",
                                    "ac_id",
                                    fGLID,
                                    ""
                                    );
                            if (lTitleID.Length > 0)
                            {
                              lGLTitle = Regex.Split(lTitleID, "<<SPLITER>>");
                              lblAcTitle.Text = lGLTitle[0];
                              mtextGLID.Text = lGLTitle[1];
                            }
                        }
                        // Check Box
                        if (dRow.ItemArray.GetValue(4) != DBNull.Value)
                        {
                            chkIsDisabled.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(4).ToString());
                        }
                        else
                        {
                            chkIsDisabled.Checked = false;
                        }

                        if (dRow.ItemArray.GetValue(5) != DBNull.Value)
                        {
                            chkIsDefault.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(5).ToString());
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
            MessageBox.Show("Exception, Form Validate: " + ex.Message ,lblFormTitle.Text.ToString());
        }

    }

    private void toolStripMenuItemSDI_Master2_Click(object sender, EventArgs e)
    {
      if (fLastID != string.Empty)
      {
        mtextID.Text = fLastID;
      }
    }
    // Validity of Data
    private bool FormValidation()
    {
      bool IsValid = true;
      fAlreadyExists = false;
      ErrrMsg = string.Empty;
      for (int i = 0; i < fValidationRule.Length; i++)
      {
        if (fValidationRule[i] == "R")
        {
          switch (i)
          { 
            // 0 - 3 = Co Data
            case 0 :
              if (mtextID.Text.ToString() == "" || mtextID.Text.ToString() == string.Empty)
              {
                // ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank ";
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
                IsValid = false;
              }
              break;
            case 1 :
              if (textTitle.Text.ToString() == "" || textTitle.Text.ToString() == string.Empty)
              {
                //ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank ";
               ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
                
                IsValid = false;
              }
              break;
            case 2:
              if (textST.Text.ToString() == "" || textST.Text.ToString() == string.Empty)
              {
                //ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank "; 
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
                IsValid = false;
              }
              break;
            case 3:
              if (mtextOrdering.Text.Trim(' ', '-') == "")
              {
                //ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank "; 
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
                IsValid = false;
              }
              break;

            case 4:  // Added by Baba New
              if (mtextGLID.Text.Trim(' ', '-') == "")
              {
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "' ID:/ " + fFieldTitle[i] + "' is Empty or Blank... " + "");
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
        //tSQL += clsGVar.LGCY;
        //tSQL += " and ";
        //if (cFLBegin != string.Empty)
        //{
        //  tSQL += " loc_id = " + pYearID.ToString() + " and grp_id = " + pYearID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString() + " and ";
        //}
  
        tSQL += fKeyField + " = " + mtextID.ToString();
        MessageBox.Show("ID: " + mtextID.Text.ToString() + " : " + textTitle.Text.ToString()  + "\r\nDeleted... ", fFormTitle);
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
         

          if (!fAlreadyExists)
          {
                // Insert/New
                tSQL = "insert into " + fTableName + " (";
                tSQL += "   " + fKeyField;                                            // 1- ID 
                tSQL += " , " + fField[1];                                            // 2- title
                tSQL += " , " + fField[2];                                            // 3- ST 
                tSQL += " , " + fField[3];                                            // 4- from ID
                tSQL += " , " + fField[4];                                            // 5- Ordering 
                tSQL += " , " + fField[5];                                            // 8- IsDisabled bit
                tSQL += " , " + fField[6];                                            // 9- IsDefault bit
                //tSQL += " , " + fField[12];                                            // 10 FrmID  
                tSQL += " , created_by, created_date, frm_ID ";                               // Created by Int, created_date
                tSQL += ") values ( ";
                //
              //
              tSQL += "  " + mtextID.Text.ToString();                                 // 1-
              tSQL += ", '" + StrF01.EnEpos(textTitle.Text.ToString().Trim()) + "'";         // 2-
              tSQL += ", '" + StrF01.EnEpos(textST.Text.ToString().Trim()) + "'";            // 3-
              tSQL += ",  " + fGLID; // mtextGLID.Text.ToString() + "'";                         // 5-
              tSQL += ", " + clsDbManager.ConvInt(mtextOrdering);                     // 4-
             
              
              tSQL += ", " + clsDbManager.ConvBit(chkIsDisabled);                     // 7-
              // is Default is 0 at insert level, unchanged at update level (it will be implemented through a seperate form.
              tSQL += ", 0";        // is Default
              //tSQL += ", " + fFormID.ToString();
              tSQL += ", " + clsGVar.AppUserID.ToString() + ", '" +  StrF01.D2Str(DateTime.Now, true) + "'";
              tSQL += ", 1007";
              tSQL += ")";
          }
          else
          {
              // Modify/Update
              tSQL = "update " + fTableName + " set ";
                  tSQL += "  " + fField[1] + " = '" + StrF01.EnEpos(textTitle.Text.ToString()) + "'";
                  tSQL += ", " + fField[2] + " = '" + StrF01.EnEpos(textST.Text.ToString()) + "'";
                  tSQL += ", " + fField[3] + " =  " + fGLID; //mtFromID.Text.ToString();
                  tSQL += ", " + fField[4] + " = " + clsDbManager.ConvInt(mtextOrdering);
                  tSQL += ", " + fField[5] + " = " + clsDbManager.ConvBit(chkIsDisabled);
                  tSQL += ", modified_by = " + clsGVar.AppUserID.ToString();
                  tSQL += ", modified_date = '" +  StrF01.D2Str(DateTime.Now, true) + "'";
                  tSQL += " where ";
                  //tSQL += clsGVar.LGCY;
                  //tSQL += " and ";

                  tSQL += fKeyField + " = " + mtextID.Text.ToString();
          }

         

      }
      catch (Exception e)
      {
          MessageBox.Show("Exception: Before Save: " + e.Message,lblFormTitle.Text.ToString());
          return false;
      }

      try
      {
        

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
            // 1- [FieldList],
            // 2- [KeyField],
            // 3- [TableName],
            // 4- [FormTitle],
            // 5- [DefaultFindField],
            // 6- [FieldTitle],
            // 7- [TitleWidth],
            // 8- [TitleFormat],
            // 9- [OneTable],
            // 10-[Join],
            // 11-[TBType]
          string lJoin = "INNER JOIN gl_ac p ON kt.godown_ac_id = p.ac_id";
            frmLookUp sForm = new frmLookUp(
                "kt." + fKeyField,
                "kt.Godown_title,kt.Godown_st,kt.ordering,p.ac_strid,p.ac_title", 
                fTableName, 
                "Godown ID",
                1, 
                "ID,Godown Title,Short,Ordering,GL Ac ID, GL Ac Title", 
                "10,20,10,10,15,20", 
                "T,T,T,T,T,T",
                false, 
                lJoin
                );

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
            MessageBox.Show("Exception: Lookup Godown ID " + e.Message, lblFormTitle.Text.ToString());
        }
    }
    // ----Event/Delegate--------------------------------
    private void PassData(object sender)
    {
      mtextID.Text = ((MaskedTextBox)sender).Text;
    }
    private void PassDataGL( object sender )
    {
      mtextGLID.Text = (( MaskedTextBox )sender).Text;
    }
    // --------------------------------------------------------------------------------
    private void PassData1(object sender)
    {
         textTitle.Text = ((TextBox)sender).Text;
    }
    // ------------------------------------------------------------------------------
    public void frmGLLookUp()
    {
        string fJoin = "";
        try
        {
            // 0- 
            // 1- [FieldList],
            // 2- [KeyField],
            // 3- [TableName],
            // 4- [FormTitle],[DefaultFindField],[FieldTitle],[TitleWidth],[TitleFormat],[OneTable],[Join],[TBType]
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
            //    "ac_strid",
            //    "ac_title,ac_atitle,Ordering",
            //    "gl_ac",
            //    "Godown ID",
            //    1,
            //    "ID,Account Title, Alternate Title,Ordering",
            //    "10,20,20,10",
            //    "T,T,T,T",
            //    true,
            //    fJoin
            //    );
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataGL);
            sForm.ShowDialog();
            //if (mtext.Text != null)
            //{
            //  if (mtext.Text.ToString() == "" || mtext.Text.ToString() == string.Empty)
            //  {
            //    return;
            //  }
            //  System.Windows.Forms.SendKeys.Send("{TAB}");
            //}

        }
        catch (Exception e)
        {
            MessageBox.Show("Exception: Lookup GL ID " + e.Message, lblFormTitle.Text.ToString());
        }
    }


    private void mtextID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {

    }

    private void mtFromID_Validating( object sender, CancelEventArgs e )
    {
      if (mtextGLID.Text.Trim(' ', '-') == "")
      {
        return;
      }
      //string pTable,
      //string pKeyFieldID,
      //string pKeyFieldTitle,
      //string pSearchValue,
      //string pCustomQry = ""

            //  public static string GetTitlenNumAcID(
            //string pTable,
            //string pKeyFieldID,
            //string pKeyFieldTitle,
            //string pSearchValue,
            //string pNumIDField,
            //string pCustomQry = ""

      string lRtnValue = clsDbManager.GetTitlenNumAcID(
        "gl_ac",
        "ac_strid",
        "ac_title",
        mtextGLID.Text.ToString(),
        "ac_id"
        );
        //
        string[] lAcTitle = Regex.Split(lRtnValue, "<<SPLITER>>");
        lblAcTitle.Text = "";

        if (lAcTitle[0] == "ID not Found...")
        {
          MessageBox.Show("GLID: Account ID not found, try another .....", lblFormTitle.Text.ToString());
          e.Cancel = true;
          return;
        }
        lblAcTitle.Text = lAcTitle[0];
        lblAcTitle.Tag = lAcTitle[1];
        fGLID = Convert.ToInt32(lAcTitle[1]); 
    }

    private void mtFromID_DoubleClick( object sender, EventArgs e )
    {
      frmGLLookUp();
    }

    private void mtextID_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            frmSDILookUp();
        }
    }

    private void mtextGLID_KeyDown(object sender, KeyEventArgs e)
    {
        frmGLLookUp();
    }

  }

}
