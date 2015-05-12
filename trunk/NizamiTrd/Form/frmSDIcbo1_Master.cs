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
using TaxSolution.Class;

namespace TaxSolution 
{
  public partial class frmSDIcbo1_Master : Form
  {
    // Example Bank Branch ID
    LookUp lookUpForm = new LookUp();

    // Parameters Form Level
    List<string> fDependentTables = new List<string>();
    string fZeroStr = "000000000000000000000000000000";
    string fLastID = string.Empty;
    int fFormID = 0;
    Int64 fAddrUID = 0;
    string fHasAddr = string.Empty;
    string fFormTitle = string.Empty;
    string fTableName = string.Empty;
    string fKeyFieldName = string.Empty;
    string fKeyFieldType = string.Empty;
    string fParentTableName = string.Empty;
    string fParentKeyField = string.Empty;
    string fCbo1ToolTip = string.Empty;
    //
    string ErrrMsg = string.Empty;
    bool fAlreadyExists = false;
    string fTitleWidth = string.Empty;
    string fTitleFormat = string.Empty;
    bool fAddressBtn = false;
    string[] fMainParameter;
    string[] fBeginParam;
    string[] fField;
    string[] fInputMaxLen;
    string[] fFieldTitle;
    string[] fValidationRule;

    //int pLocID = 0;
    //int pGrpID = 0;
    //int pCoID = 0;
    //int pYearID = 0;
    // Parameter to Class level
    string cMain = string.Empty;
    string cFieldListBegin = string.Empty;
    string cFieldLList = string.Empty;
    string cFieldListEnd = string.Empty;
    string cFieldLengthBegin = string.Empty;
    string cFieldLength = string.Empty;
    string cFieldLengthEnd = string.Empty;
    string cFieldTitleBegin = string.Empty;
    string cFieldTitle = string.Empty;
    string cFieldTitleEnd = string.Empty;
    string cValidationRuleBegin = string.Empty;
    string cValidationRule = string.Empty;
    string cValidationRuleEnd = string.Empty;
    //
    //string cTitleWidth = string.Empty;
    //string cTitleFormat = string.Empty;
    //
    // Combo Box Default Value
    int fcboDefaultValue = 0;
    //
    bool fOneTable = true;
    string fReplaceAbleField = string.Empty;
    string fReplaceWithField = string.Empty;
    string fReplaceAbleTitle = string.Empty;
    string fReplaceWithTitle = string.Empty;
    string fJoin = string.Empty;
    string fReplaceAble = string.Empty;
    //
    // Main Parameter
    // Begining Fields LYGC
    // Begining Field List
    // Field List
    // Field List End Is Default, IsDisable etc
    // Field Len Gegining
    // Field Len
    // Field Len End
    // Field Title Genin
    // Field Title
    // Field Title End
    // Value Required Begining
    // Value Required
    // Value Required End
    // Title Width
    // Title Format
    // One Table Default = true
    // Join Default ""
    // Replaceable (for Lookup/View)
    public frmSDIcbo1_Master(
        string pMainParameter, 
        string pBeginParam, 
        string pFieldListBegin, 
        string pFieldList, 
        string pFieldLengthd, 
        string pFieldLengthBegin, 
        string pFieldLength, 
        string pFieldLengthEnd, 
        string pFieldTitleBegin, 
        string pFieldTitle, 
        string pFieldTitleEnd, 
        string pValidationRuleBegin, 
        string pValidationRule, 
        string pValidationRuleEnd, 
        string pTitleWidth, 
        string pTitleFormat, 
        List<string> pDependentTables,
        bool pOneTable = true, 
        string pJoin = "", 
        string pReplaceable = "")
    {

      string[] tReplaceAble;
      // FormID, Title, Table, KeyField, KeyFieldType, 
      InitializeComponent();
      HookEvents();
      // Buttons
      btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
      // Form Main Parameters
      if (pOneTable == false)
      {
        fReplaceAble = pReplaceable;
        tReplaceAble = fReplaceAble.Split(',');
        fReplaceAbleField = tReplaceAble[0];
        fReplaceWithField = tReplaceAble[1];
        fReplaceAbleTitle = tReplaceAble[2];
        fReplaceWithTitle = tReplaceAble[3];
        fJoin = pJoin;
        fOneTable = false;
      }
      // Class level variables
      cMain = pMainParameter;
      cFieldListBegin = pFieldListBegin;          // Field List Beginning
      cFieldLList = pFieldList;                    // Field List Body
      cFieldListEnd = pFieldLengthd;              // Field List End
      cFieldLengthBegin = pFieldLengthBegin;      // Field Len Beginning
      cFieldLength = pFieldLength;                // Field Len Body
      cFieldLengthEnd = pFieldLengthEnd;          // Field Len End
      cFieldTitleBegin = pFieldTitleBegin;          // Field Title Beginning  
      cFieldTitle = pFieldTitle;                    // Field Title Body
      cFieldTitleEnd = pFieldTitleEnd;              // Field Title End
      cValidationRuleBegin = pValidationRuleBegin;      // Validation Rule Begining
      cValidationRule = pValidationRule;                // Validation Rule Body
      cValidationRuleEnd = pValidationRuleEnd;          // Validtion Rule End
      //
      fMainParameter = pMainParameter.Split(',');     // Main Parameters
      //fFormID = fMainParameter[0];           // Form ID
      fFormID = Convert.ToInt32(fMainParameter[0]);      // Form ID
      fFormTitle = fMainParameter[1];        // Form Title
      fTableName = fMainParameter[2];        // Table Name
      fKeyFieldName = fMainParameter[3];         // Key Field Name
      fKeyFieldType = fMainParameter[4];     // Key Field Type   (Int, Long, etc)
      fHasAddr = fMainParameter[5];          // Has Address Button
      // fMainParameter[5] for Address Btn
      fParentTableName = fMainParameter[6];  // Parent Table Name for Combo
      fParentKeyField = fMainParameter[7];  // Parent Key Field Name for Combo  
      fCbo1ToolTip = fMainParameter[8];      // String for tooltip of the combobox
      //
      fBeginParam = pBeginParam.Split(',');     // Begin Parameters/CoData
      //pLocID = Convert.ToInt16(fBeginParam[0]);
      //pGrpID = Convert.ToInt16(fBeginParam[1]);
      //pCoID = Convert.ToInt16(fBeginParam[2]);
      //pYearID = Convert.ToInt16(fBeginParam[3]);
      // RecInfo: Creation Date, Created by, Modified Date, Modified By

      fTitleWidth = pTitleWidth;    // Title Width for lookup columns (15,50,30,20) etc
      fTitleFormat = pTitleFormat;  // Title Format for lookup columns (N = Numeric, T=Text etc)
      fDependentTables = pDependentTables;
      //
      this.Text = fFormTitle;
      lblFormTitle.Text = fFormTitle;
      // Length Text Boxes
      if (pFieldListBegin == string.Empty || pFieldListBegin == "")
      {
        // Field List Without Grp
        fField = (pFieldList + "," + pFieldLengthd).Split(',');
        // Field Titles
        fFieldTitle = (pFieldTitle + "," + pFieldTitleEnd).Split(',');
        // Validation: Required
        fValidationRule = (pValidationRule + "," + pValidationRuleEnd).Split(',');

      }
      else
      {
        // Field List With Grp,Co,Year
        fField = (pFieldListBegin + "," + pFieldList + "," + pFieldLengthd).Split(',');
        // Field Titles
        fFieldTitle = (pFieldTitleBegin + "," + pFieldTitle + "," + pFieldTitleEnd).Split(',');
        // Validation: Required
        fValidationRule = (pValidationRuleBegin + "," + pValidationRule + "," + pValidationRuleEnd).Split(',');

      }

      fInputMaxLen = pFieldLength.Split(',');
      mtextID.MaxLength = Convert.ToInt16(fInputMaxLen[0]);
      textTitle.MaxLength = Convert.ToInt16(fInputMaxLen[1]);
      textST.MaxLength = Convert.ToInt16(fInputMaxLen[2]);
      // Marked Edit
      //mtextID.Mask = fZeroStr.Substring(0, Convert.ToInt16(fMaxLen[0])); 
      mtextID.Mask = "0000";

      mtextOrdering.Mask = fZeroStr.Substring(0, Convert.ToInt16(fInputMaxLen[3]));
      // Context Menu Setup
      this.contextMenuStripSDIcbo1_Master.Items.AddRange(new
      System.Windows.Forms.ToolStripItem[] { this.toolStripMenuItemSDI_Master1, this.toolStripMenuItemSDI_Master2 });

    }

    private void frmSDI_Master_Load(object sender, EventArgs e)
    {
        AtFormLoad();

    }
    private void AtFormLoad()
    {
        KeyPreview = true;
        string lSQl = string.Empty;
        // Form Layout
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.Top = 0;
        //this.Left = clsGVar.frmLeft; 
        //  
        this.Text = clsGVar.CoTitle;
        mtextID.HidePromptOnLeave = true;
        mtextOrdering.HidePromptOnLeave = true;
        this.MaximizeBox = false;
        cboParentID.DropDownStyle = ComboBoxStyle.DropDownList;
        if (fMainParameter[5] == "1")
        {
            fAddressBtn = true;
            btn_Address.Visible = true;
        }

        //string tSQL = string.Empty;
        //tSQL = "SELECT count(" + fKeyField + ") as cRecTotal, max(" + fKeyField + ") as cLastid FROM " + fTableName;

        // Tool Tips  
        toolTipCbo1.ToolTipTitle = fFormTitle;
        toolTipCbo1.IsBalloon = true;
        // Input Box :
        toolTipCbo1.SetToolTip(mtextID, ("Enter ID / Code Number Max. Length: " + mtextID.Mask.ToString()) + " Numeric Characters");
        toolTipCbo1.SetToolTip(textTitle, ("Required: Name or Title, Max. Length: " + textTitle.MaxLength.ToString() + " Alphanumeric Characters"));
        toolTipCbo1.SetToolTip(textST, ("Required: Short Title or Short Name, Max. Length: " + textST.MaxLength.ToString() + " Alphanumeric Characters"));
        toolTipCbo1.SetToolTip(mtextOrdering, ("Required: Ordering Or Sequence: Priority to appear in View/Combo Box, Max. Length: " + mtextOrdering.Mask.ToString().Length + " Numeric Characters"));


        toolTipCbo1.SetToolTip(cboParentID, ("Required: '" + fCbo1ToolTip + "' as parent ID/Name, Select one from the list."));
        toolTipCbo1.SetToolTip(chkIsDisabled, ("Default: Un-Checked (Active), When checked, ID is disabled (In-Active)"));
        // Buttons:
        toolTipCbo1.SetToolTip(btn_Save, "Alt+S, Save New record or Modify/Update an existing record");
        toolTipCbo1.SetToolTip(btn_Clear, "Alt+C, Clear all input control/items on this form");
        toolTipCbo1.SetToolTip(btn_Delete, "Alt+D, Delete currently selected record");
        toolTipCbo1.SetToolTip(btn_Exit, "Alt+X, Close this form and exit to the Main Form");

        toolStripStatuslblTotalText.Text = clsDbManager.GetTotalRec(fTableName, fKeyFieldName);

        lSQl = "select " + fParentKeyField + ", " + fParentKeyField.Replace("_id","_title") + " from " + fParentTableName;
        //lSQl += " where "; 
        //lSQl += clsGVar.LGCY;
        lSQl += " order by ordering";
        clsFillCombo.FillComboWithQry(
            cboParentID, 
            fParentTableName + "," + fParentKeyField + ",False", lSQl);   
        fcboDefaultValue = Convert.ToInt16(cboParentID.SelectedValue);
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
      lblAddrID.Text = string.Empty;
      mtextOrdering.Text = string.Empty;
      chkIsDisabled.Checked = false;
      chkIsDefault.Checked = false;
      //
      btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
      btn_Address.Enabled = false;
      lblAddrID.Visible = false;
      //
      if (btn_Pin.Text != "&Un-Pin")
        cboParentID.SelectedIndex = clsSetCombo.Set_ComboBox(cboParentID, fcboDefaultValue);
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
        mtextID.Text = clsDbManager.GetNextValMastID(fTableName, fKeyFieldName, "").ToString();
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

          int t1 = 0;
          int t2 = 0;

          tSQL = "select top 1 " + fField[0] + " as title," + fField[1] + " as stitle," + fField[2] + ", " + fField[3] + " as parent_id," + fField[4] + ", " + fField[5];
          if (fHasAddr == "1")
          {
            tSQL += ", " + "addr_uid";
          }
          tSQL += " from " + fTableName;
          tSQL += " where ";
          //  
          //tSQL += clsGVar.LGCY;
          //tSQL += " and ";
          tSQL +=  fKeyFieldName + " = " + mtextID.Text.ToString();

          //========================================================
          DataSet dtset = new DataSet();
          DataRow dRow;
          dtset = clsDbManager.GetData_Set(tSQL, fTableName);
          //int abc = dtset.Tables.Count; // gives the number of tables.
          int nor = dtset.Tables[0].Rows.Count;
          
          if (nor == 0 || nor == null)
          {
            fAlreadyExists = false;
          }
          else
          {
            dRow = dtset.Tables[0].Rows[0];
            fAlreadyExists = true;
            textTitle.Text = dRow.ItemArray.GetValue(0).ToString(); // dtset.Tables[0].Rows[0][0].ToString();
            textST.Text = dRow.ItemArray.GetValue(1).ToString(); // dtset.Tables[0].Rows[0][1].ToString();
            mtextOrdering.Text = dRow.ItemArray.GetValue(2).ToString(); // 
            int tPid = 0;
            tPid = Convert.ToInt16(dRow.ItemArray.GetValue(3).ToString());
            cboParentID.SelectedIndex = clsSetCombo.Set_ComboBox(cboParentID, tPid);


            //t1 = Convert.ToInt16(dRow.ItemArray.GetValue(2));
            //t2 = Convert.ToInt16(dRow.ItemArray.GetValue(3));

            //abc = (Convert.ToInt16)dtset.Tables[0].Rows[0][1].ToString();
            
            chkIsDisabled.Checked = t1 == 1 ? true : false;
            //chkIsDefault.Checked = t2 == 1 ? true : false;

            chkIsDisabled.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(4).ToString());
            chkIsDefault.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(5).ToString());
            //
            if (fHasAddr == "1")
            {
              fAddrUID = dRow.ItemArray.GetValue(6) == DBNull.Value ? 0 : Convert.ToInt64(dRow.ItemArray.GetValue(6));
              lblAddrID.Visible = true;
              lblAddrID.Text = fAddrUID.ToString();
            }

          }
          //========================================================= ].Columns["keyword"].
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

    private void toolStripMenuItemSDI_Master1_Click(object sender, EventArgs e)
    {
      // Next ID
      if (mtextID.Enabled)
      {
        mtextID.Text = clsDbManager.GetNextValMastID(fTableName, fKeyFieldName, "").ToString();
        textTitle.Focus();
      }
      else
      {
        textAlert.Text = "Cannot display Next ID, use clear button.";
      }
    }
    private void toolStripMenuItemSDI_Master2_Click(object sender, EventArgs e)
    {
      // Last ID
      if (mtextID.Enabled)
      {
        mtextID.Text = fLastID;
        textTitle.Focus();
      }
      else
      {
        textAlert.Text = "Cannot display Last ID, use clear button.";
      }
    }    // Validity of Data
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
            // 0 - 2 = Co Data
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

          }
        }
      }
      // Already Exists
      fAlreadyExists = clsDbManager.IDAlreadyExist(fTableName, fKeyFieldName, mtextID.Text.ToString(), "");

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

    private void btn_Delete_Click( object sender, EventArgs e )
    {
      string lDependencyFound = "";
      try
      {
        if (fDependentTables != null)
        {
          lDependencyFound = clsCheckTableDependency.CheckTableDependency(fDependentTables, mtextID.Text.ToString(),"");
          if (lDependencyFound != "Dependency Not Found")
          {
            MessageBox.Show("Warnning:\nDelete not possible, following table(s) contain record(s)\n" + lDependencyFound, lblFormTitle.Text.ToString());
            return;
          }
          else
          {
            DeleteExistingID();
          }
        } // End if != null
        else
        {
          DeleteExistingID();
        } // End else != null
      }
      catch (Exception ex)
      {
        MessageBox.Show("Check Dependency to Deleting ID:\n Exception: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    //====
    private void DeleteExistingID()
    {
      try
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
          tSQL += fKeyFieldName + " = " + mtextID.Text.ToString();
          //
          if (clsDbManager.ExeOne(tSQL))
          {
            fLastID = mtextID.Text.ToString();

            textAlert.Text = "Existing ID: " + fLastID + " Deleted ....";
            MessageBox.Show("ID: " + mtextID.Text.ToString() + " : " + textTitle.Text.ToString() + "\r\nDeleted... ", fFormTitle);
            ClearThisForm();
            return;
          }
          else
          {
            textAlert.Text = "ID: " + mtextID.Text.ToString() + " Not Deleted: Try again....";
            return;
          }
        } // End Confirmation if
      }
      catch (Exception ex)
      {
        MessageBox.Show("Deleting ID:\n Exception: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    //====

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

    private void frmSDIcbo1_Master_KeyDown(object sender, KeyEventArgs e)
    {
      // set KeyPreview = true
      if (e.KeyCode == Keys.Enter) 
        { 
            e.Handled = true;
            System.Windows.Forms.SendKeys.Send("{TAB}"); 
        }
      else if (e.KeyCode == Keys.F2 && ActiveControl == mtextID)
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

    private void frmSDIcbo1_Master_FormClosing(object sender, FormClosingEventArgs e)
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

      string tSQL = string.Empty;
      try
      {
          #region Insert/Update

          if (!fAlreadyExists)
          {
                // Insert/New
                // fField = (pFieldList + "," + pFieldLengthd).Split(',');                        // Title Starts At 0: Without Grp,Co,Year (title, st, ordering, is disabled)
                // fField = (pFieldListBegin + "," + pFieldList + "," + pFieldLengthd).Split(',');     // Title Start at 3 : With Grp,Co,Year (f0, f1, f2 + title, st, ordering + Is Disabled)
                tSQL = "insert into " + fTableName + " (";
                //tSQL += fField[0] + ", " + fField[1] + ", " + fField[2]  ;            // Loc,Grp,Co
                //tSQL += " , " + fField[3];                                            // Year
                tSQL += "  " + fKeyFieldName;                                            // ID 
                tSQL += " , " + fField[0];                                            // title
                tSQL += " , " + fField[1];                                            // ST 
                tSQL += " , " + fField[2];                                            // Ordering 
                tSQL += " , " + fField[3];                                            // Pid
                tSQL += " , " + fField[4];                                            // IsDisabled bit
                tSQL += " , " + fField[5];                                            // IsDefault bit
                tSQL += " , " + fField[6];                                           // FrmID  
                tSQL += " , created_by, created_date ";                               // Created by Int, created_date
                tSQL += ") values ( ";
                //

                //tSQL += pLocID.ToString() + ", " + pGrpID.ToString() + ", " + pCoID.ToString() + ", " + pYearID.ToString() + ", ";
                tSQL += mtextID.Text.ToString();
                tSQL += ", " + StrF01.EnEpos(textTitle.Text.ToString().Trim());
                tSQL += ", " + StrF01.EnEpos(textST.Text.ToString().Trim());
                if (mtextOrdering.Text.ToString() == null || mtextOrdering.Text.ToString().Trim() == "")
                {
                    tSQL += ", 0";
                }
                else
                {
                    tSQL += ", " + mtextOrdering.Text.ToString();
                }
                tSQL += ", " + cboParentID.SelectedValue.ToString();
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
                tSQL += ", " + fField[3] + " = " + cboParentID.SelectedValue.ToString();

                if (chkIsDisabled.Checked == true)
                {
                    tSQL += ", " + fField[4] + " = 1";
                }
                else
                {
                    tSQL += ", " + fField[4] + " = 0";
                }
                // is IsDefault Skiped
                tSQL += ", " + fField[6] + " = " + fFormID;

                  // Frm ID is not required in Update.  

                tSQL += ", modified_by = " + clsGVar.AppUserID.ToString();
                tSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";
                tSQL += " where ";
                //tSQL += " loc_id = " + pLocID.ToString() + " and grp_id = " + pGrpID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString() + " and ";
                //tSQL += clsGVar.LGCY;
                //tSQL += " and ";
                tSQL += fKeyFieldName + " = " + mtextID.Text.ToString();
          }

          #endregion
      }
      catch (Exception e)
      {
          MessageBox.Show("Exception: Before Save: " + e.Message, lblFormTitle.Text.ToString());
          return false;
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
      string[] tFieldList;
      string[] tTitleList;
      string tStrFieldList = string.Empty;
      string tStrTitleList = string.Empty;
      string tKeyField = "kt." + fKeyFieldName;
      //string tTableName = fTableName + " c";
      //
      //tFieldList = (fKeyField + "," + cFL).Split(',');
      tFieldList = cFieldLList.Split(',');
      tTitleList = cFieldTitle.Split(',');
      int i = 0;
      if (!fOneTable)                                         // More then one tables
      {
        for (i = 0; i < tFieldList.Length; i++)
        {
          if (tFieldList[i] == fReplaceAbleField)
          {
            tFieldList[i] = "p." + fReplaceWithField;
            tTitleList[i + 1] = fReplaceWithTitle;            // as Title also include ID, therefore it has length of +1 
          }
          else
          {
            tFieldList[i] = "kt." + tFieldList[i];
          }
        }
      }
      tStrFieldList = String.Join(", ", tFieldList);
      tStrTitleList = String.Join(", ", tTitleList);

      //                              [KeyField],[FieldList],[TableName],[FormTitle],[DefaultFindField],[FieldTitle],[TitleWidth],[TitleFormat],[OneTable],[join]
      // frmLookUp sForm = new frmLookUp(fKeyField, tStrFieldList, fTableName, fFormTitle, 1, cFieldTitle, fTitleWidth, fTitleFormat, false);
      frmLookUp sForm = new frmLookUp(tKeyField, tStrFieldList, fTableName, fFormTitle, 1, tStrTitleList, fTitleWidth, fTitleFormat, false, fJoin);
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


    private void btn_Address_Click(object sender, EventArgs e)
    {
      try
      {
        //#region Address Form

        // 1- FormID
        // 2- ID    Convert.ToInt32(mtextID.Text) discarded
        // 3- Title
        //frmAddress_Master Dlg_Address = new frmAddress_Master(
        //    clsDbM.ConvInt(mtextID),
        //    fAddrUID,
        //    textTitle.Text.ToString(),
        //    0,
        //    "update " + fTableName + " set addr_uid = <<TOBEFillED>> where " + clsGVar.LGCY + " and " + fKeyField + " = " + mtextID.Text.ToString()
        //    );
        //Dlg_Address.ShowDialog();

        //
        // 1- FormID
        // 2- ID    Convert.ToInt32(mtextID.Text) discarded
        // 3- Title
        // 4- Addr UID
        frmAddress_Master Dlg_Address = new frmAddress_Master(
            fFormID,
            clsDbManager.ConvInt(mtextID),
            textTitle.Text.ToString(),
            fAddrUID,
            "update " + fTableName + " set addr_uid = <<TOBEFillED>> where " + fKeyFieldName + " = " + mtextID.Text.ToString()
             //+ clsGVar.LGCY + " and "
            );
        Dlg_Address.ShowDialog();
        //Update fAddrUID with fresh value
        fAddrUID = clsDbManager.GetIn64Value(fTableName, fKeyFieldName, "addr_uid", Convert.ToInt16(mtextID.Text));
        lblAddrID.Text = fAddrUID.ToString();

        //#endregion
      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception: " + ex.Message,lblFormTitle.Text.ToString());          
      }

    }

    private void btn_Pin_Click(object sender, EventArgs e)
    {
        if (btn_Pin.Text == "&Un-Pin")
        {
            btn_Pin.Text = "&Pin";
            btn_Pin.Image = Properties.Resources.tiny_pin;
        }
        else
        {
          btn_Pin.Text = "&Un-Pin";
          btn_Pin.Image = Properties.Resources.tiny_pinned;
        }
    }

    private void lblFormTitle_Click(object sender, EventArgs e)
    {
        lblFormTitle.Text = mtextID.Text;
    }

    private void lblID_Click(object sender, EventArgs e)
    {
        mtextID.Text = "99-11-22-3334";
    }

    private void mtextID_Click(object sender, EventArgs e)
    {
        // Important: not yet checked
        mtextID.SelectionStart = 0;
    }

    private void lblOrdering_Click(object sender, EventArgs e)
    {
      mtextOrdering.Text = mtextID.Text;
    }

    private void btn_Exit_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }

}
