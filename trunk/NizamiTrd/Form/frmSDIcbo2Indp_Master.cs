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
//using TestFormApp;

namespace TaxSolution
{
  public partial class frmSDIcbo2Indp_Master : Form
  {
    LookUp lookUpForm = new LookUp();

    // Parameters Form Level
    string fZeroStr = "000000000000000000000000000000";
    string fLastID = string.Empty;
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
    //
    public frmSDIcbo2Indp_Master(string pMain, string pBeginParam, string pFLBegin, string pFL, string pFLEnd, string pFLenBegin, string pFLen, string pFLenEnd, string pFTBegin, string pFT, string pFTEnd, string pValRBegin, string pValR, string pValREnd, string pTitleWidth, string pTitleFormat, bool pOneTable, string pJoin, string pLookUpField, string pLookUpTitle, string pLookUpTitleWidth)
    {
      //string[] tReplaceable;
      // FormID, Title, Table, KeyField, KeyFieldType, 
      InitializeComponent();
      HookEvents();
      // Buttons
      btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
      // Form Main Parameters
      fLookUpField = pLookUpField;
      fLookUpTitle = pLookUpTitle;
      fLookUpTitleWidth = pLookUpTitleWidth; 
      if (pOneTable == false)
      {
        //fReplaceable = pReplaceable;
        //tReplaceable = fReplaceable.Split(',');
        //fReplaceField = tReplaceable[0];
        //fReplaceWithField = tReplaceable[1];
        //fReplaceTitle = tReplaceable[2];
        //fReplaceWithTitle = tReplaceable[3];
        fJoin = pJoin;
        fOneTable = false;
      }
      // Class level variables
      cMain = pMain;
      cFLBegin = pFLBegin;          // Field List Beginning
      cFL = pFL;                    // Field List Body
      cFLEnd = pFLEnd;              // Field List End
      cFLenBegin = pFLenBegin;      // Field Len Beginning
      cFLen = pFLen;                // Field Len Body
      cFLenEnd = pFLenEnd;          // Field Len End
      cFTBegin = pFTBegin;          // Field Title Beginning  
      cFT = pFT;                    // Field Title Body
      cFTEnd = pFTEnd;              // Field Title End
      cValRBegin = pValRBegin;      // Validation Rule Begining
      cValR = pValR;                // Validation Rule Body
      cValREnd = pValREnd;          // Validtion Rule End
      //
      fMain = pMain.Split(',');     // Main Parameters
      fFormID = fMain[0];           // Form ID
      fFormTitle = fMain[1];        // Form Title
      fTableName = fMain[2];        // Table Name
      fKeyField = fMain[3];         // Key Field Name
      fKeyFieldType = fMain[4];     // Key Field Type   (Int, Long, etc)
      // fMain[5] for Address Btn
      fFirstTableName = fMain[6];        // Parent Table Name
      fFirstKeyField = fMain[7];         // Parent Key Field
      fSecondTableName = fMain[8];  // Parent Parent Table Name
      fSecondKeyField = fMain[9];         // Parent Parent Key Field Name    

      fCbo1ToolTip = fMain[10];     // Tool Tip Combobox 1
      fCbo2ToolTip = fMain[11];     // Tool Tip Combobox 2

                                    // RecInfo: Creation Date, Created by, Modified Date, Modified By

      fBeginParam = pBeginParam.Split(',');     // Begin Parameters/CoData
      //pLocID = Convert.ToInt16(fBeginParam[0]);
      //pGrpID = Convert.ToInt16(fBeginParam[1]);
      //pCoID = Convert.ToInt16(fBeginParam[2]);
      //pYearID = Convert.ToInt16(fBeginParam[3]);

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
      this.contextMenuStripSDIcbo2_Master.Items.AddRange(new
      System.Windows.Forms.ToolStripItem[] { this.toolStripMenuItemSDI_Master1, this.toolStripMenuItemSDI_Master2 });

    }

    private void frmSDI_Master_Load(object sender, EventArgs e)
    {
        AtFormLoad();

    }
    private void AtFormLoad()
    {
        ButtonImageSetting();
        string lSQL = string.Empty; 
        // Form Layout
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        //  
        this.Text = clsGVar.CoTitle;
        mtextID.HidePromptOnLeave = true;
        mtextOrdering.HidePromptOnLeave = true;
        this.MaximizeBox = false;
        cboSecondID.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFirstID.DropDownStyle = ComboBoxStyle.DropDownList;
        if (fMain[5] == "1")
        {
            fAddressBtn = true;
            btn_Address.Visible = true;
        }

        // Tool Tips  
        toolTipCbo1.ToolTipTitle = fFormTitle;
        toolTipCbo1.IsBalloon = true;
        // Input Box :
        toolTipCbo1.SetToolTip(mtextID, ("Enter ID / Code Number Max. Length: " + mtextID.Mask.ToString()) + " Numeric Characters");
        toolTipCbo1.SetToolTip(textTitle, ("Required: Name or Title, Max. Length: " + textTitle.MaxLength.ToString() + " Alphanumeric Characters"));
        toolTipCbo1.SetToolTip(textST, ("Required: Short Title or Short Name, Max. Length: " + textST.MaxLength.ToString() + " Alphanumeric Characters"));
        toolTipCbo1.SetToolTip(mtextOrdering, ("Required: Ordering Or Sequence: Priority to appear in View/Combo Box, Max. Length: " + mtextOrdering.Mask.ToString().Length + " Numeric Characters"));


        toolTipCbo1.SetToolTip(cboFirstID, ("Required: '" + fCbo1ToolTip + "' as parent ID/Name, Select one from the list."));
        toolTipCbo1.SetToolTip(cboSecondID, ("Required: '" + fCbo2ToolTip + "' as parent ID/Name, Select one from the list."));

        toolTipCbo1.SetToolTip(chkIsDisabled, ("Default: Un-Checked (Active), When checked, ID is disabled (In-Active)"));
        // Buttons:
        toolTipCbo1.SetToolTip(btn_Save, "Alt+S, Save New record or Modify/Update an existing record");
        toolTipCbo1.SetToolTip(btn_Clear, "Alt+C, Clear all input control/items on this form");
        toolTipCbo1.SetToolTip(btn_Delete, "Alt+D, Delete currently selected record");
        toolTipCbo1.SetToolTip(btn_Exit, "Alt+X, Close this form and exit to the Main Form");

        //string tSQL = string.Empty;
        //tSQL = "SELECT count(" + fKeyField + ") as cRecTotal, max(" + fKeyField + ") as cLastid FROM " + fTableName;
        toolStripStatuslblTotalText.Text = clsDbManager.GetTotalRec(fTableName, fKeyField);
        //   
        lSQL = "select * from " + fFirstTableName;
        //lSQL += " where ";  //loc_id = " + pLocID.ToString() + " and grp_id = " + pGrpID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString();
        //lSQL += clsGVar.LGCY;
        lSQL += " order by ordering";

        clsFillCombo.FillCombo(cboFirstID, clsGVar.ConString1, fFirstTableName + "," + fFirstKeyField + "," + "False", lSQL);
        fcboDefaultValue = Convert.ToInt16(cboFirstID.SelectedValue);
        //                                                                                       
        lSQL = "select * from " + fSecondTableName;
        //lSQL += " where ";  //loc_id = " + pLocID.ToString() + " and grp_id = " + pGrpID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString();
        //lSQL += clsGVar.LGCY;
        lSQL += " order by ordering";

        clsFillCombo.FillCombo(cboSecondID, clsGVar.ConString1, fSecondTableName + "," + fSecondKeyField + "," + "False", lSQL);


        //fcboDefaultValue = Convert.ToInt16(cboParentID.SelectedValue);
        isLoading = "N";
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
        btn_Address.Image = Properties.Resources.ico_inbox;
        //btn_OpeningBalance.Image = Properties.Resources.ico_admin;
        //btn_NextID.Image = Properties.Resources.ico_arrow_r;
    }
    private void btn_Exit_Click(object sender, EventArgs e)
    {
      //if (cboParentID.SelectedIndex == -1)
      //{
      //  MessageBox.Show("Parent CBO is empty...");
      //  return;
      //}
      //else
      //{
      //  MessageBox.Show("Value of cbo = " + Convert.ToInt16(cboParentID.SelectedValue).ToString());
      //  return;
      //}
      this.Close();
    }

    private void btn_Clear_Click(object sender, EventArgs e)
    {
      ClearThisForm();
    }
    private void ClearThisForm()
    {
      //textID1.Text = string.Empty;
      mtextID.Text = string.Empty;
      textTitle.Text = string.Empty;
      textST.Text = string.Empty;
      mtextOrdering.Text = "1"; //string.Empty;
      chkIsDisabled.Checked = false;
      chkIsDefault.Checked = false;
      //
      btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
      btn_Address.Enabled = false;
      //
      cboSecondID.SelectedIndex = clsSetCombo.Set_ComboBox(cboSecondID, fcboDefaultValue);
      //
      mtextID.Enabled = true;
      mtextID.Focus();
    }

    private void btn_Save_Click(object sender, EventArgs e)
    {
        Cursor.Current = Cursors.WaitCursor;
        SaveData();
        Cursor.Current = Cursors.Default;
    }

    private void toolStripLabel1_Click(object sender, EventArgs e)
    {
      // Next ID
      if (mtextID.Enabled)
      {
        mtextID.Text = clsDbManager.GetNextValMastID(fTableName, fKeyField, "").ToString();
      }
      else
      {
        textAlert.Text = "Cannot display Next ID, use clear button.";
      }
    }

    private void mtextID_Validating(object sender, CancelEventArgs e)
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
          int tFirstID = 0;
          int tSecondID = 0;  
          //
          tSQL = "select top 1 " + fField[0] + " as title," + fField[1] + " as stitle";
          tSQL += ", " + fField[2];                                 // Ordering
          tSQL += ", " + fField[3] + " as first_id";                // First Combo
          tSQL += ", " + fField[4] + " as second_id";               // 2nd Combo
          tSQL += ", " + fField[5] + ", " + fField[6];             // Is disabled, Is Default
          tSQL += " from " + fTableName;
          tSQL += " where ";
          //tSQL += clsGVar.LGCY;
          //tSQL += " and ";  
          //tSQL += " loc_id = " + pLocID.ToString() + " and grp_id = " + pGrpID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString() + " and ";
          tSQL +=  fKeyField + " = " + mtextID.Text.ToString();

          //========================================================
          DataSet dtset = new DataSet();
          DataRow dRow;
          dtset = clsDbManager.GetData_Set(tSQL, fTableName);
          //int abc = dtset.Tables.Count; // gives the number of tables.
          int abc = dtset.Tables[0].Rows.Count;
          
          if (abc == 0)
          {
            fAlreadyExists = false;
          }
          else
          {
            dRow = dtset.Tables[0].Rows[0];
            fAlreadyExists = true;
            textTitle.Text = dRow.ItemArray.GetValue(0).ToString(); // dtset.Tables[0].Rows[0][0].ToString();
            textST.Text = dRow.ItemArray.GetValue(1).ToString(); // dtset.Tables[0].Rows[0][1].ToString();
            mtextOrdering.Text = dRow.ItemArray.GetValue(2).ToString(); 
            tFirstID = Convert.ToInt16(dRow.ItemArray.GetValue(3).ToString());
            cboFirstID.SelectedIndex = clsSetCombo.Set_ComboBox(cboFirstID, tFirstID);
            tSecondID = Convert.ToInt16(dRow.ItemArray.GetValue(4).ToString());
            cboSecondID.SelectedIndex = clsSetCombo.Set_ComboBox(cboSecondID, tSecondID);


            //t1 = Convert.ToInt16(dRow.ItemArray.GetValue(2));
            //t2 = Convert.ToInt16(dRow.ItemArray.GetValue(3));

            //abc = (Convert.ToInt16)dtset.Tables[0].Rows[0][1].ToString();
            
            //chkIsDisabled.Checked = t1 == 1 ? true : false;
            //chkIsDefault.Checked = t2 == 1 ? true : false;

            chkIsDisabled.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(5).ToString());
            chkIsDefault.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(6).ToString());
          }
          //========================================================= ].Columns["keyword"].
          //int tFirstID = 0;
          
          //---------------------- Start 2nd Face ----------------------
          tSQL = "select top 1 " + fFirstKeyField ;
          tSQL += " from " + fFirstTableName;
          tSQL += " where ";

          //tSQL += " loc_id = " + pLocID.ToString() + " and grp_id = " + pGrpID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString() + " and ";
          //tSQL += clsGVar.LGCY;
          //tSQL += " and ";
          tSQL += fFirstKeyField + " = " + tFirstID;

          dtset = clsDbManager.GetData_Set(tSQL, fFirstTableName);
          //int abc = dtset.Tables.Count; // gives the number of tables.
          abc = dtset.Tables[0].Rows.Count;

          if (abc == 0)
          {
            //fAlreadyExists = false; // this is for overall table
          }
          else
          {
            dRow = dtset.Tables[0].Rows[0];
            fAlreadyExists = true;
            tFirstID = Convert.ToInt16(dRow.ItemArray.GetValue(0).ToString());
            cboFirstID.SelectedIndex = clsSetCombo.Set_ComboBox(cboFirstID, tFirstID);
          }


          //------------------------ End 2nd Face -------------------

         // MessageBox.Show("Query: " + tSQL);
         //
          // Ternary operation
          //
          if (fAlreadyExists )
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

    private void toolStripMenuItemSDI_Master2_Click(object sender, EventArgs e)
    {
      // Last ID
      if (mtextID.Enabled)
      {
        if (fLastID != string.Empty)
        {
          mtextID.Text = fLastID;
        }
      }
      else
      {
        textAlert.Text = "Cannot display Last ID, use clear button.";
      }
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
            // 0 - 2 = Co Data (Group, Company, Year)
            case 3 :
              if (mtextID.Text.ToString() == "" || mtextID.Text.ToString() == string.Empty)
              {
                // ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank ";
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
                IsValid = false;
              }
              break;
            case 4 :
              if (textTitle.Text.ToString() == "" || textTitle.Text.ToString() == string.Empty)
              {
                //ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank ";
               ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
                
                IsValid = false;
              }
              break;
            case 5:
              if (textST.Text.ToString() == "" || textST.Text.ToString() == string.Empty)
              {
                //ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank "; 
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
                IsValid = false;
              }
              break;
             // 6 - 7 = Optional Data

          } // Switch Statement
        } // if statement
      } // for loop
      // Check Combo Boxes
      if (cboFirstID.SelectedIndex == -1)
      {
           ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Combo Box 1 is Empty .... ");
           IsValid = false;
      }
      if (cboSecondID.SelectedIndex == -1)
      {
           ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Combo Box 2 is Empty .... ");
           IsValid = false;
      }
      // Already Exists
      fAlreadyExists = clsDbManager.IDAlreadyExist(fTableName, fKeyField, mtextID.Text.ToString(), "");

      return IsValid;
    } // End of Class
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
        tSQL += " Where ";
        //tSQL += clsGVar.LGCY;
        //tSQL += " and ";

        //tSQL += " loc_id = " + pLocID.ToString() + " and grp_id = " + pGrpID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString() + " and ";
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

    private void frmSDIcbo2Indp_Master_KeyDown(object sender, KeyEventArgs e)
    {
      // set KeyPreview = true
      if (e.KeyCode == Keys.Enter) 
        { 
            e.Handled = true;
            System.Windows.Forms.SendKeys.Send("{TAB}"); 
        }
      else if (e.KeyCode == Keys.F1 && ActiveControl == mtextID)
      {
        // MessageBox.Show("F2 is pressed");
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

    private void frmSDIcbo2Indp_Master_FormClosing(object sender, FormClosingEventArgs e)
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
        MessageBox.Show(ErrrMsg);
        return false;
      }

      string tSQL = string.Empty;
      if (!fAlreadyExists)
      {
        // Insert/New
        tSQL = "insert into " + fTableName + " (";
        //tSQL += fField[0] + ", " + fField[1] + ", " + fField[2] + ", " + fField[3];
        tSQL += "  " + fKeyField;                                       // ID
        tSQL += ", " + fField[0];                                       // Title
        tSQL += ", " + fField[1];                                       // ST
        tSQL += ", " + fField[2];                                       // Ordering
        tSQL += ", " + fField[3];                                       // cbo 1
        tSQL += ", " + fField[4];                                       // cbo 2
        tSQL += ", " + fField[5];                                       // IsDisabled
        tSQL += ", " + fField[6];                                      // IsDefault
        tSQL += ", " + fField[7];                                      // frmID

        // Isdefault skiped
        tSQL += ", created_by, created_date ";
        tSQL += ") values ( ";
        //
        //
        //tSQL += clsGVar.LocID.ToString();
        //tSQL += ", " + clsGVar.GrpID.ToString();
        //tSQL += ", " + clsGVar.CoID.ToString();
        //tSQL += ", " + clsGVar.YrID.ToString();
        //
        // tSQL += pLocID.ToString() + ", " + pGrpID.ToString() + ", " + pCoID.ToString() + ", " + pYearID.ToString();
        tSQL += "  " + mtextID.Text.ToString();
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

        tSQL += ", " + cboFirstID.SelectedValue.ToString();
        tSQL += ", " + cboSecondID.SelectedValue.ToString();
        if (chkIsDisabled.Checked == true)
        {
          string abc1 = chkIsDisabled.Checked.ToString();
          tSQL += ", 1";
        }
        else
        {
          tSQL += ", 0";
        }

        tSQL += ", 0"; // is Default is 0 at insert level, unchanged at update level (it will be implemented through a seperate form.
        tSQL += ", " + fFormID.ToString();
        tSQL += ", " + clsGVar.AppUserID.ToString() + ", '" + StrF01.D2Str(DateTime.Now, true) + "'";
        tSQL += ")";
      }
      else
      {
        // Modify/Update
            tSQL = "update " + fTableName + " set ";
            //
            tSQL += " " + fField[0] + " = '" + StrF01.EnEpos(textTitle.Text.ToString()) + "'";
            tSQL += ", " + fField[1] + " = '" + StrF01.EnEpos(textST.Text.ToString()) + "'";
            if (mtextOrdering.Text.ToString() == null || mtextOrdering.Text.ToString().Trim() == "")
            {
                tSQL += ", " + fField[2] + " = 0";
            }
            else
            {
                tSQL += ", " + fField[2] + " = " + mtextOrdering.Text.ToString();
            }
            tSQL += ", " + fField[3] + " = " + cboFirstID.SelectedValue.ToString();
            tSQL += ", " + fField[4] + " = " + cboSecondID.SelectedValue.ToString();

            if (chkIsDisabled.Checked == true)
            {
            tSQL += ", " + fField[5] + " = 1";
            }
            else
            {
            tSQL += ", " + fField[5] + " = 0";
            }
            // IsDefault 10 skiped
            // frmID 11 skiped
            tSQL += ", modified_by = " + clsGVar.UserID.ToString();
            tSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";
            tSQL += " where ";
            //
            //tSQL += clsGVar.LGCY;
            //tSQL += " and ";
            //
            //tSQL += " loc_id = " + pLocID.ToString() + " and grp_id = " + pGrpID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString() + " and ";
            tSQL += fKeyField + " = " + mtextID.Text.ToString();
      }

      // MessageBox.Show(tSQL);
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
    // End Save
    public void frmSDILookUp()
    {
      // Prepare a a list of fields. 
      // fOneTable = false = More then One Tables.
      // fOneTable = true = One Table only.
      //string[] tFieldList;
      //string[] tTitleList;
      //string tStrFieldList = string.Empty;
      //string tStrTitleList = string.Empty;
      // kt stands for 'key table'  
      // p stands for parent table   
      string tKeyField = "kt." + fKeyField;
      //tFieldList = cFL.Split(',');
      //tTitleList = cFT.Split(',');
      //int i = 0;
      //if (!fOneTable)
      ////{
      //  for (i = 0; i < tFieldList.Length; i++)
      //  {
      //    if (tFieldList[i] == fReplaceField)
      //    {
      //      tFieldList[i] = "p." + fReplaceWithField;
      //      // as Title also include ID, therefore it has length of +1 
      //      tTitleList[i+1] = fReplaceWithTitle;
      //    }
      //    else
      //    {
      //      tFieldList[i] = "kt." + tFieldList[i];
      //    }
      //  }
      //}


      //                              [KeyField],[FieldList],[TableName],[FormTitle],[DefaultFindField],[FieldTitle],[TitleWidth],[TitleFormat],[OneTable],[join]
      // frmLookUp sForm = new frmLookUp(fKeyField, tStrFieldList, fTableName, fFormTitle, 1, cFT,        fTitleWidth, fTitleFormat, false  Join);
      frmLookUp sForm = new frmLookUp(tKeyField, fLookUpField, fTableName, fFormTitle, 1, fLookUpTitle, fLookUpTitleWidth, fTitleFormat, false, fJoin);
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
    // ----Event/Delegate--------------------------------
    private void PassData(object sender)
    {
      //textBoxForm4.Text = ((TextBox)sender).Text;
      //textBoxForm4.Text = ((MaskedTextBox)sender).Text;
      mtextID.Text = ((MaskedTextBox)sender).Text;
    }

    private void mtextID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {

    }

    private void btn_Address_Click(object sender, EventArgs e)
    {
      //frmAddress_Master Dlg_Address = new frmAddress_Master();
      //Dlg_Address.ShowDialog();
    }

    private void cboParentParentID_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (isLoading == "N")
      {
          //clsFillCombo.FillCombo(cboSecondID, clsGVar.gConString1, fParentTableName + "," + "" + "," + "False", "select * from " + fParentTableName +
      }
    }

    private void lblOrdering_Click(object sender, EventArgs e)
    {
      mtextOrdering.Text = mtextID.Text;
    }

    private void btn_Exit_KeyDown(object sender, KeyEventArgs e)
    {
        //if (e.KeyCode == Keys.F1)
        //{
        //    frmSDILookUp();
        //}
    }


  }

}
