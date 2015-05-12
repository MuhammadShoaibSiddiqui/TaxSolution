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
//using TLERP;

namespace TaxSolution
{
  public partial class frmSDIcbo2_Master : Form
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
    string fParentTableName = string.Empty;
    string fParentKeyField = string.Empty;
    string fParentParentTableName = string.Empty;
    string fParentParentKeyField = string.Empty;
    string fParentPidField = string.Empty;
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

    int pLocID = 0;
    int pGrpID = 0;
    int pCoID = 0;
    int pYearID = 0;
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
    string fReplaceable = string.Empty;
    string isLoading = "Y";
    //
    public frmSDIcbo2_Master(string pMain, string pBeginParam, string pFLBegin, string pFL, string pFLEnd, string pFLenBegin, string pFLen, string pFLenEnd, string pFTBegin, string pFT, string pFTEnd, string pValRBegin, string pValR, string pValREnd, string pTitleWidth, string pTitleFormat, bool pOneTable = true, string pJoin = "", string pReplaceable = "")
    {
      string[] tReplaceable;
      // FormID, Title, Table, KeyField, KeyFieldType, 
      InitializeComponent();
      HookEvents();
      // Buttons
      btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
      // Form Main Parameters
      if (pOneTable == false)
      {
        // Multiple Tables
        fReplaceable = pReplaceable;
        tReplaceable = fReplaceable.Split(',');
        fReplaceField = tReplaceable[0];
        fReplaceWithField = tReplaceable[1];
        fReplaceTitle = tReplaceable[2];
        fReplaceWithTitle = tReplaceable[3];
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
      fParentTableName = fMain[6];        // Parent Table Name
      fParentKeyField = fMain[7];         // Parent Key Field INCLUDE A
      fParentPidField = fMain[8];        // Parent Parent Pid Field Name   Not required actually not exists
      fParentParentTableName = fMain[9];  // Parent Parent Table Name
      fParentParentKeyField = fMain[10];   // Parent Parent Key Field Name
      

                                    // RecInfo: Creation Date, Created by, Modified Date, Modified By

      fBeginParam = pBeginParam.Split(',');     // Begin Parameters/CoData
      pLocID = Convert.ToInt16(fBeginParam[0]);
      pGrpID = Convert.ToInt16(fBeginParam[1]);
      pCoID = Convert.ToInt16(fBeginParam[2]);
      pYearID = Convert.ToInt16(fBeginParam[3]);


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
        string lSQL = string.Empty; 
        // Form Layout
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        //  
        this.Text = clsGVar.CoTitle;
        mtextID.HidePromptOnLeave = true;
        mtextOrdering.HidePromptOnLeave = true;
        this.MaximizeBox = false;
        cboParentID.DropDownStyle = ComboBoxStyle.DropDownList;
        cboParentParentID.DropDownStyle = ComboBoxStyle.DropDownList;
        if (fMain[5] == "1")
        {
            fAddressBtn = true;
            btn_Address.Visible = true;
        }

        // Tool Tips  
        toolTipCbo2.ToolTipTitle = fFormTitle;
        toolTipCbo2.IsBalloon = true;
        // Input Box :
        toolTipCbo2.SetToolTip(mtextID, ("Enter ID / Code Number Max. Length: " + mtextID.Mask.ToString()) + " Numeric Characters");
        toolTipCbo2.SetToolTip(textTitle, ("Required: Name or Title, Max. Length: " + textTitle.MaxLength.ToString() + " Alphanumeric Characters"));
        toolTipCbo2.SetToolTip(textST, ("Required: Short Title or Short Name, Max. Length: " + textST.MaxLength.ToString() + " Alphanumeric Characters"));
        toolTipCbo2.SetToolTip(mtextOrdering, ("Required: Ordering Or Sequence: Priority to appear in View/Combo Box, Max. Length: " + mtextOrdering.Mask.ToString().Length + " Numeric Characters"));

        toolTipCbo2.SetToolTip(cboParentParentID, ("Required: Grand Parent ID/Name, Select one from the list."));
        toolTipCbo2.SetToolTip(cboParentID, ("Required: Parent ID/Name, Select one from the list."));
        
        toolTipCbo2.SetToolTip(chkIsDisabled, ("Default: Un-Checked (Active), When checked, ID is disabled (In-Active)"));
        // ToolTip Buttons:
        toolTipCbo2.SetToolTip(btn_Save, "Alt+S, Save New record or Modify/Update an existing record");
        toolTipCbo2.SetToolTip(btn_Clear, "Alt+C, Clear all input control/items on this form");
        toolTipCbo2.SetToolTip(btn_Delete, "Alt+D, Delete currently selected record");
        toolTipCbo2.SetToolTip(btn_Exit, "Alt+X, Close this form and exit to the Main Form");


        //string tSQL = string.Empty;
        //tSQL = "SELECT count(" + fKeyField + ") as cRecTotal, max(" + fKeyField + ") as cLastid FROM " + fTableName;
        toolStripStatuslblTotalText.Text = clsDbManager.GetTotalRec(fTableName, fKeyField);

        lSQL = "select " + fParentParentKeyField + ", " + fParentParentKeyField.Replace("_id", "_title") + " from " + fParentParentTableName;

        //lSQL += " where "; //loc_id = " + pLocID.ToString() + " and grp_id = " + pGrpID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString();
        //lSQL += clsGVar.LGCY;
  
        lSQL += " order by ordering";

        clsFillComboNew.FillCombo(cboParentParentID, fParentParentTableName + "," + fParentParentKeyField + "," + "False", lSQL);
        fcboDefaultValue = Convert.ToInt16(cboParentParentID.SelectedValue);
        lSQL = "select " + fParentKeyField + ", " + fParentKeyField.Replace("_id", "_title") + " from " + fParentTableName;
        //lSQL += " Where ";
        //lSQL += clsGVar.LGCY;
        //lSQL += " and ";
        //lSQL += fParentKeyField + " = " + cboParentParentID.SelectedValue.ToString();
        // lSQL += " and loc_id = " + pLocID.ToString() + " and grp_id = " + pGrpID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString();
        //
        //                                                                                          it is "" as isdefault = false
        clsFillComboNew.FillCombo(cboParentID, fParentTableName + "," + "" + "," + "False", lSQL);


        //fcboDefaultValue = Convert.ToInt16(cboParentID.SelectedValue);
        isLoading = "N";
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
      //textST.Text = string.Empty;
      textST.Text = "ST";
      lblAddrID.Text = string.Empty;
      //mtextOrdering.Text = string.Empty;
      mtextOrdering.Text = "1";
      chkIsDisabled.Checked = false;
      chkIsDefault.Checked = false;
      //
      btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
      btn_Address.Enabled = false;
      lblAddrID.Enabled = false;
      //
      if (btn_Pin.Text != "&Un-Pin")
          if (cboParentID.Items.Count > 0)
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

          int t1 = 0;
          int t2 = 0;
          int tPid = 0;
          int tPPid = 0;
          string tPPidString = string.Empty;
          //
          tSQL = "select top 1 " + fField[4] + " as title," + fField[5] + " as stitle," + fField[6] + ", " + fField[7] + " as parent_id," + fField[8];
          tSQL += ", " + fField[9];
          tSQL += " from " + fTableName;
          tSQL += " where ";
  
          //tSQL += clsGVar.LGCY;
          //tSQL += " and ";
  
          // tSQL += " loc_id = " + pLocID.ToString() + " and grp_id = " + pYearID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString() + " and ";
          tSQL +=  fKeyField + " = " + mtextID.Text.ToString();

          //========================================================
          DataSet dtset = new DataSet();
          DataRow dRow;
          dtset = clsDbManager.GetData_Set(tSQL, fTableName);
          //int abc = dtset.Tables.Count; // gives the number of tables.
          int abc = dtset.Tables[0].Rows.Count;
          
          if (abc == 0 || abc == null)
          {
            textST.Text = "ST"; // dtset.Tables[0].Rows[0][1].ToString();
            mtextOrdering.Text = "1"; // 
            fAlreadyExists = false;
          }
          else
          {
            dRow = dtset.Tables[0].Rows[0];
            fAlreadyExists = true;
            textTitle.Text = dRow.ItemArray.GetValue(0).ToString(); // dtset.Tables[0].Rows[0][0].ToString();
            //textST.Text = dRow.ItemArray.GetValue(1).ToString(); // dtset.Tables[0].Rows[0][1].ToString();
            //mtextOrdering.Text = dRow.ItemArray.GetValue(2).ToString(); // 
            textST.Text = dRow.ItemArray.GetValue(1).ToString(); // dtset.Tables[0].Rows[0][1].ToString();
            mtextOrdering.Text = dRow.ItemArray.GetValue(2).ToString(); // 
            //   
            tPid = Convert.ToInt16(dRow.ItemArray.GetValue(3).ToString());
            tPPidString = clsDbManager.GetParentID(fParentTableName, fParentKeyField, fParentPidField, tPid);
            if (tPPidString != "Err")
            {
                tPPid = Convert.ToInt32(tPPidString);
                cboParentParentID.SelectedIndex = clsSetCombo.Set_ComboBox(cboParentParentID, tPPid);
            }
            else
            {
                MessageBox.Show("Error: Parent ID: '" + tPid.ToString() + "' not found.",lblFormTitle.Text.ToString());
                return;
            }
            //
            if (cboParentID.Items.Count > 0)
            {
                cboParentID.SelectedIndex = clsSetCombo.Set_ComboBox(cboParentID, tPid);
            }
            else
            {
                int fcboDefaultValue = Convert.ToInt16(cboParentParentID.SelectedValue);
                tSQL = "select * from " + fParentTableName;
                tSQL += " Where " + fParentKeyField + " = " + cboParentParentID.SelectedValue.ToString();
                //tSQL += clsGVar.LGCY;
  
                // tSQL += " and loc_id = " + pLocID.ToString() + " and grp_id = " + pGrpID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString();
                //
                //                                                                                          it is "" as isdefault = false
                clsFillComboNew.FillCombo(cboParentID, fParentTableName + "," + "" + "," + "False", tSQL);
                //
                cboParentID.SelectedIndex = clsSetCombo.Set_ComboBox(cboParentID, tPid);
            }

            
            //t1 = Convert.ToInt16(dRow.ItemArray.GetValue(2));
            //t2 = Convert.ToInt16(dRow.ItemArray.GetValue(3));

            //abc = (Convert.ToInt16)dtset.Tables[0].Rows[0][1].ToString();
            
            //chkIsDisabled.Checked = t1 == 1 ? true : false;
            //chkIsDefault.Checked = t2 == 1 ? true : false;

            chkIsDisabled.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(4).ToString());
            chkIsDefault.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(5).ToString());
          }
          //========================================================= ].Columns["keyword"].
          //int tPPid = 0;
          ////---------------------- Start 2nd Face ----------------------
          //tSQL = "select top 1 " + fParentTableName + "_id" ;
          //tSQL += " from " + fParentTableName;
          //tSQL += " where ";
          //tSQL += " loc_id = " + pLocID.ToString() + " and grp_id = " + pYearID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString() + " and ";
          //tSQL += fParentTableName + "_pid = " + tPid;


          //dtset = classDS.GetData_Set(tSQL, fParentTableName);
          ////int abc = dtset.Tables.Count; // gives the number of tables.
          //abc = dtset.Tables[0].Rows.Count;

          //if (abc == 0 || abc == null)
          //{
          //  //fAlreadyExists = false; // this is for overall table
          //}
          //else
          //{
          //  dRow = dtset.Tables[0].Rows[0];
          //  fAlreadyExists = true;
          //  tPPid = Convert.ToInt32(dRow.ItemArray.GetValue(0).ToString());
          //  cboParentParentID.SelectedIndex = ClassSetCombo.Set_ComboBox(cboParentParentID, tPPid);
          //}


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
    private void toolStripMenuItemSDI_Master1_Click(object sender, EventArgs e)
    {
      // Next ID
      if (mtextID.Enabled)
      {
        mtextID.Text = clsDbManager.GetNextValMastID(fTableName, fKeyField, "").ToString();
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
      if (cboParentParentID.SelectedIndex == -1)
      {
           ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Combo Box 1 is Empty .... ");
           IsValid = false;
      }
      if (cboParentID.SelectedIndex == -1)
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

    private void frmSDIcbo2_Master_KeyDown(object sender, KeyEventArgs e)
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

    private void frmSDIcbo2_Master_FormClosing(object sender, FormClosingEventArgs e)
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
      try
      {
          #region Insert/Update

          if (!fAlreadyExists)
          {
              // Insert/New
              // fField = (pFL + "," + pFLEnd).Split(',');                        // Title Starts At 0: Without Grp,Co,Year (title, st, ordering, is disabled)
              // fField = (pFLBegin + "," + pFL + "," + pFLEnd).Split(',');     // Title Start at 3 : With Grp,Co,Year (f0, f1, f2 + title, st, ordering + Is Disabled)
            tSQL = "insert into " + fTableName + " (";
            //tSQL += fField[0] + ", " + fField[1] + ", " + fField[2];              // lOC, Grp,Co
            //tSQL += " , " + fField[3];                                            // Year
            tSQL += "  " + fKeyField;                                                    // ID 
            tSQL += " , " + fField[4];                                            // title
            tSQL += " , " + fField[5];                                            // ST 
            tSQL += " , " + fField[6];                                            // Ordering 
            tSQL += " , " + fField[7];                                            // Pid
            tSQL += " , " + fField[8];                                            // IsDisabled bit
            tSQL += " , " + fField[9];                                            // IsDefault bit
            tSQL += " , " + fField[10];                                           // FrmID  
            tSQL += " , created_by, created_date ";                               // Created by Int, created_date
            tSQL += ") values ( ";
            //
            //tSQL += clsGVar.LocID.ToString();
            //tSQL += ", " + clsGVar.GrpID.ToString();
            //tSQL += ", " + clsGVar.CoID.ToString();
            //tSQL += ", " + clsGVar.YrID.ToString();
            //
            tSQL += " " + mtextID.Text.ToString();
            tSQL += ", '" + StrF01.EnEpos(textTitle.Text.ToString().Trim()) + "'";
            tSQL += ", '" + StrF01.EnEpos(textST.Text.ToString().Trim()) + "'";
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
            // 
            tSQL += ", 0";  // is Default is 0 at insert level, unchanged at update level (it will be implemented through a seperate form.
            tSQL += ", " + fFormID.ToString();
            tSQL += ", " + clsGVar.AppUserID.ToString() + ", '" + StrF01.D2Str(DateTime.Now, true) + "'";
            tSQL += ")";
          }
          else
          {
                // Modify/Update
                tSQL = "update " + fTableName + " set ";
                tSQL += "  " + fField[4] + " = '" + StrF01.EnEpos(textTitle.Text.ToString()) + "'";
                tSQL += ", " + fField[5] + " = '" + StrF01.EnEpos(textST.Text.ToString()) + "'";
                if (mtextOrdering.Text.ToString() == null || mtextOrdering.Text.ToString().Trim() == "")
                {
                    tSQL += ", " + fField[6] + " = 0";
                }
                else
                {
                    tSQL += ", " + fField[6] + " = " + mtextOrdering.Text.ToString();
                }
                tSQL += ", " + fField[7] + " = " + cboParentID.SelectedValue.ToString();

                if (chkIsDisabled.Checked == true)
                {
                    tSQL += ", " + fField[8] + " = 1";
                }
                else
                {
                    tSQL += ", " + fField[8] + " = 0";
                }
                // IsDefualt 9 skiped for Update

                tSQL += ", " + fField[10] + " = " + fFormID;

                // Frm ID is not required in Update.  

                tSQL += ", modified_by = " + clsGVar.AppUserID.ToString();
                tSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";
                tSQL += " where ";
                //
                //tSQL += clsGVar.LGCY;
                //tSQL += " and ";
  
                //tSQL += " loc_id = " + pLocID.ToString() + " and grp_id = " + pYearID.ToString() + " and co_id = " + pCoID.ToString() + " and year_id = " + pYearID.ToString() + " and ";
                tSQL += fKeyField + " = " + mtextID.Text.ToString();
          }

          #endregion

      }
      catch (Exception e)
      {
          MessageBox.Show("Exception: Before Save: " + e.Message, lblFormTitle.Text.ToString());
          return false;
      }

        
        
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
      // kt stands for 'key table'  
      // p stands for parent table   
      string tKeyField = "kt." + fKeyField;
      // The following procedure is very good for one field. But it will not work for the multiple tables as is 
      // in next: frmSDIcbo2Indp_Master.cs
      // We will have to adopt a different approach for frmSDIcbo2Indp_Master.cs 
      tFieldList = cFL.Split(',');
      tTitleList = cFT.Split(',');
      int i = 0;
      if (!fOneTable)
      {
        for (i = 0; i < tFieldList.Length; i++)
        {
          if (tFieldList[i] == fReplaceField)
          {
            tFieldList[i] = "p." + fReplaceWithField;
            // as Title also include ID, therefore it has length of +1 
            tTitleList[i+1] = fReplaceWithTitle;
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
      // frmLookUp sForm = new frmLookUp(fKeyField, tStrFieldList, fTableName, fFormTitle, 1, cFT, fTitleWidth, fTitleFormat, false);
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
        clsFillComboNew.FillCombo(cboParentID, fParentTableName + "," + "" + "," + "False", "select " + fParentKeyField + ", " + fParentKeyField.Replace("_id", "_title") + "  from " + fParentTableName +
    " Where " + fParentPidField + " = " + cboParentParentID.SelectedValue.ToString());
      }
    }

    private void btn_Pin_Click(object sender, EventArgs e)
    {
        if (btn_Pin.Text == "&Un-Pin")
        {
            btn_Pin.Text = "&Pin";
        }
        else
        {
            btn_Pin.Text = "&Un-Pin";
        }

    }

    private void lblOrdering_Click(object sender, EventArgs e)
    {
      mtextOrdering.Text = mtextID.Text;
    }

    private void btn_Exit_Click(object sender, EventArgs e)
    {

    }

    private void btn_Exit_Click_1(object sender, EventArgs e)
    {
      this.Close();
    }


  }

}
