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
using TaxSolution.Class;
using System.Text.RegularExpressions;
// using System.Threading;  // for testing of wait cursor

namespace TaxSolution
{ 
  public partial class frmAcGrpRange : Form
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
    //string[] fValR;
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
    public frmAcGrpRange()

    {

        //string pMain, 
        //string pBeginParam, 
        //string pFLBegin, 
        //string pFL, 
        //string pFLEnd, 
        //string pFLenBegin, 
        //string pFLen, 
        //string pFLenEnd, 
        //string pFTBegin, 
        //string pFT, 
        //string pFTEnd, 
        //string pValRBegin, 
        //string pValR, 
        //string pValREnd, 
        //string pTitleWidth, 
        //string pTitleFormat)

      // FormID, Title, Table, KeyField, KeyFieldType, 
      InitializeComponent();
      //HookEvents();
      // Buttons
      btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
      // Form Main Parameters
      // Class level variables
      //cMain = pMain;                            // Main Parameters
  
      //cFLBegin = pFLBegin;                      // Field List Beginning Loc,grp,co,year
      //cFL = pFL;                                // Field List Body
      //cFLEnd = pFLEnd;                          // Field List End
      //cFLenBegin = pFLenBegin;                  // Field Len Beginning
      //cFLen = pFLen;                            // Field Len Body
      //cFLenEnd = pFLenEnd;                      // Field Len End
      //cFTBegin = pFTBegin;                      // Field Title Beginning  
      //cFT = pFT;                                // Field Title Body
      //cFTEnd = pFTEnd;                          // Field Title End
      //cValRBegin = pValRBegin;                  // Validation Rule Begining
      //cValR = pValR;                            // Validation Rule Body
      //cValREnd = pValREnd;                      // Validtion Rule End
      ////
      //fMain = pMain.Split(',');                 // Main Parameters
      //fFormID = Convert.ToInt16(fMain[0]);      // Form ID
      //fFormTitle = fMain[1];                    // Form Title
      //fTableName = fMain[2];                    // Table Name
      //fKeyField = fMain[3];                     // Key Field Name
      //fKeyFieldType = fMain[4];                 // Key Field Type   (Int, Long, etc)

      //                                          // RecInfo: Creation Date, Created by, Modified Date, Modified By

      //fBeginParam = pBeginParam.Split(',');     // Begin Parameters/CoData
      //pLocID = Convert.ToInt16(fBeginParam[0]);
      //pGrpID = Convert.ToInt16(fBeginParam[1]);
      //pCoID = Convert.ToInt16(fBeginParam[2]);
      //pYearID = Convert.ToInt16(fBeginParam[3]);
      ////      
      //fTitleWidth = pTitleWidth;    // Title Width for lookup columns (15,50,30,20) etc
      //fTitleFormat = pTitleFormat;  // Title Format for lookup columns (N = Numeric, T=Text etc)
      
      //
      this.Text = fFormTitle;
      lblFormTitle.Text = fFormTitle;
      // Length Text Boxes
      //if (pFLBegin == string.Empty || pFLBegin == "")
      //{
      //  // Field List
      //  fField = (pFL + "," + pFLEnd).Split(',');
      //  // Field Titles
      //  fFieldTitle = (pFT + "," + pFTEnd).Split(',');
      //  // Validation: Required
      //  fValR = (pValR + "," + pValREnd).Split(',');

      //}
      //else
      //{
      //  // Field List
      //  fField = (pFLBegin + "," + pFL + "," + pFLEnd).Split(',');
      //  // Field Titles
      //  fFieldTitle = (pFTBegin + "," + pFT + "," + pFTEnd).Split(',');
      //  // Validation: Required
      //  fValR = (pValRBegin + "," + pValR + "," + pValREnd).Split(',');

      //}

      //fMaxLen = pFLen.Split(',');
      //mtextID.MaxLength = Convert.ToInt16(fMaxLen[0]);
      //textTitle.MaxLength = Convert.ToInt16(fMaxLen[1]);
      //textST.MaxLength = Convert.ToInt16(fMaxLen[2]);
      // Marked Edit
      //mtextID.Mask = fZeroStr.Substring(0, Convert.ToInt16(fMaxLen[0])); 
      //mtextOrdering.Mask = fZeroStr.Substring(0, Convert.ToInt16(fMaxLen[3]));

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
        this.Text = clsGVar.CoTitle + "  [ " + clsGVar.YrTitle + " ]";

        //mtextID.HidePromptOnLeave = true;
        //mtextOrdering.HidePromptOnLeave = true;
        //
        // ToolTip
        toolTipSDI.IsBalloon = true;
        toolTipSDI.ToolTipTitle = fFormTitle;
        //toolTipSDI.SetToolTip(mtextID, (toolTipSDI.GetToolTip(mtextID) + " " + mtextID.Mask.ToString()));
        //toolTipSDI.SetToolTip(textTitle, (toolTipSDI.GetToolTip(textTitle) + " " + fMaxLen[1] + " Characters"));
        //toolTipSDI.SetToolTip(textST, (toolTipSDI.GetToolTip(textST) + " " + fMaxLen[2] + " Characters"));
        //toolTipSDI.SetToolTip(mtextOrdering, (toolTipSDI.GetToolTip(mtextOrdering) + " " + fMaxLen[3] + " Characters"));
        //toolTipSDI.SetToolTip(mtextOrdering, ("Required: Ordering Or Sequence: Priority to appear in View/Combo Box, Max. Length: " + mtextOrdering.Mask.ToString().Length + " Numeric Characters"));

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
        toolStripStatuslblAlertText.Text = clsGVar.LGCY;
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
      //mtextID.Text = string.Empty;
      //textTitle.Text = string.Empty;
      //textST.Text = string.Empty;
      //mtextOrdering.Text = string.Empty;

      btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
      //btn_Address.Enabled = false;
      //mtextID.Enabled = true;
      //mtextID.Focus();
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
    }




    private void frmSDI_Master_KeyDown(object sender, KeyEventArgs e)
    {
      // set KeyPreview = true
      if (e.KeyCode == Keys.Enter) 
        { 
            e.Handled = true;
            System.Windows.Forms.SendKeys.Send("{TAB}"); 
        }
      //else if (e.KeyCode == Keys.F2 && ActiveControl == mtextID)
      //{
      //  frmSDILookUp();
      //}
    }
    // ------------------------------------



    private void frmSDI_Master_FormClosing(object sender, FormClosingEventArgs e)
    {
      //if (mtextID.Text != string.Empty && textTitle.ToString().Trim().Length >0)
      //{
      //  if (MessageBox.Show("Are You Sure To Exit the Form ?", "In Closing Title", MessageBoxButtons.OKCancel) != DialogResult.OK)
      //  {
      //    e.Cancel = true;
      //  }
      //}
    }
    // Start Save
    private bool SaveData()
    {
      // Check Validity of Data
      //if (!FormValidation())
      //{
      //  //MessageBox.Show(ErrrMsg, "Validation Error :");
      //  toolStripStatuslblAlertText.Text = "Validation Error: Not Saved.";
      //  return false;
      //}
      // Thread.Sleep(5000);   // Commented: just to check wait cursor // also commented above: using System.Threading;
      string tSQL = string.Empty;
      try
      {
          #region Insert/Update

          //if (!fAlreadyExists)
          //{
          //      // Insert/New
          //      // fField = (pFL + "," + pFLEnd).Split(',');                        // Title Starts At 0: Without Grp,Co,Year (title, st, ordering, is disabled)
          //      // fField = (pFLBegin + "," + pFL + "," + pFLEnd).Split(',');     // Title Start at 3 : With Grp,Co,Year (f0, f1, f2 + title, st, ordering + Is Disabled)
          //      tSQL = "insert into " + fTableName + " (";
          //      tSQL += fField[0] + ", " + fField[1] + ", " + fField[2];              // Loc,Grp,Co
          //      tSQL += " , " + fField[3];                                             // Year                
          //      tSQL += " , " + fKeyField;                                            // ID 
          //      tSQL += " , " + fField[4];                                            // title
          //      tSQL += " , " + fField[5];                                            // ST 
          //      tSQL += " , " + fField[6];                                            // Ordering 
          //      tSQL += " , " + fField[7];                                            // actype_nature
          //      tSQL += " , " + fField[8];                                            // actype_side
  

          //      tSQL += " , " + fField[9];                                            // IsDisabled bit
          //      tSQL += " , " + fField[10];                                            // IsDefault bit
          //      tSQL += " , " + fField[11];                                            // FrmID  
          //      tSQL += " , created_by, created_date ";                               // Created by Int, created_date
          //      tSQL += ") values ( ";
          //      //
          //      tSQL +=  clsGVar.gLocID.ToString();
          //      tSQL += ", " + clsGVar.gGrpID.ToString();
          //      tSQL += ", " + clsGVar.gCoID.ToString();
          //      tSQL += ", " + clsGVar.gYrID.ToString();
          //    //
          //    tSQL += ", " + mtextID.Text.ToString();
          //    tSQL += ", " + "'" + clsStrF01.EnEpos(textTitle.Text.ToString().Trim()) + "'";
          //    tSQL += ", " + "'" + clsStrF01.EnEpos(textST.Text.ToString().Trim()) + "'";
          //    if (mtextOrdering.Text.ToString() == null || mtextOrdering.Text.ToString().Trim() == "")
          //    {
          //        tSQL += ", 0";
          //    }
          //    else
          //    {
          //        tSQL += ", " + mtextOrdering.Text.ToString();
          //    }

          //    // actype_nature  0 = Balance Sheet, 1 = Revenue
          //    if (rBtn_Revenue.Checked == true)
          //    {
          //        tSQL += ", 1";
          //    }
          //    else
          //    {
          //        tSQL += ",  0";
          //    }
          //    // actype_side    1 = Credit=true, 0 = Debit=false
          //    if (rBtn_Credit.Checked == true)
          //    {
          //        tSQL += ",  1";
          //    }
          //    else
          //    {
          //        tSQL += ",  0";
          //    }

          //    if (chkIsDisabled.Checked == true)
          //    {
          //        tSQL += ", 1";
          //    }
          //    else
          //    {
          //        tSQL += ", 0";
          //    }
          //    // is Default is 0 at insert level, unchanged at update level (it will be implemented through a seperate form.
          //    tSQL += ", 0";        // is Default
          //    tSQL += ", " + fFormID.ToString();
          //    tSQL += ", " + clsGVar.gAppUserID.ToString() + ", '" +  StrF01.D2Str(DateTime.Now, true) + "'";
          //    tSQL += ")";
          //}
          //else
          //{
          //    // Modify/Update
          //    tSQL = "update " + fTableName + " set ";
          //        tSQL += "  " + fField[4] + " = '" + clsStrF01.EnEpos(textTitle.Text.ToString()) + "'";
          //        tSQL += ", " + fField[5] + " = '" + clsStrF01.EnEpos(textST.Text.ToString()) + "'";
          //        if (mtextOrdering.Text.ToString() == null || mtextOrdering.Text.ToString().Trim() == "")
          //        {
          //            tSQL += ", " + fField[6] + " = 0";
          //        }
          //        else
          //        {
          //            tSQL += ", " + fField[6] + " = " + mtextOrdering.Text.ToString();
          //        }


          //    //=====================================================
          //        // actype_nature  0 = Balance Sheet, 1 = Revenue
          //        if (rBtn_Revenue.Checked == true)
          //        {
          //            tSQL += ", " + fField[7] + " = 1"; ;
          //        }
          //        else
          //        {
          //            tSQL += ",  " + fField[7] + " = 0"; ;
          //        }
          //        // actype_side    1 = Credit=true, 0 = Debit=false
          //        if (rBtn_Credit.Checked == true)
          //        {
          //            tSQL += ",  " + fField[8] + " = 1"; 
          //        }
          //        else
          //        {
          //            tSQL += ",  " + fField[8] + " = 0"; 
          //        }

          //    //=====================================================
          //        //// actype_nature  
          //        //if (rBtn_Revenue.Checked == true)
          //        //{
          //        //    tSQL += ", " + fField[7] + " = 1";
          //        //}
          //        //else
          //        //{
          //        //    tSQL += ", " + fField[7] + " = 0";
          //        //}
          //        //// actype_side
          //        //if (rBtn_Credit.Checked == true)
          //        //{
          //        //    tSQL += ", " + fField[8] + " = 1";
          //        //}
          //        //else
          //        //{
          //        //    tSQL += ", " + fField[8] + " = 0";
          //        //}

          //        if (chkIsDisabled.Checked == true)
          //        {
          //            tSQL += ", " + fField[9] + " = 1";
          //        }
          //        else
          //        {
          //            tSQL += ", " + fField[9] + " = 0";
          //        }

          //        //tSQL += ", " + fField[8] + " = " + fFormID;
          //        tSQL += ", modified_by = " + clsGVar.gAppUserID.ToString();
          //        tSQL += ", modified_date = '" +  StrF01.D2Str(DateTime.Now, true) + "'";
          //        tSQL += " where ";
          //        tSQL += clsGVar.gLGCY;
          //        tSQL += " and ";

          //        //tSQL += " loc_id = " + clsGVar.gLocID.ToString();
          //        //tSQL += " and grp_id = " + clsGVar.gGrpID.ToString();
          //        //tSQL += " and co_id = " + clsGVar.gCoID.ToString();
          //        //tSQL += " and year_id = " + clsGVar.gYrID.ToString();
          //        //tSQL += " and ";
          //        tSQL += fKeyField + " = " + mtextID.Text.ToString();
          //}

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
              fLastID = ""; //mtextID.Text.ToString();
              if (fAlreadyExists)
              {
                  toolStripStatuslblAlertText.Text = "Existing ID: " + fLastID + " Modified ....";
              }
              else
              {
                  toolStripStatuslblAlertText.Text = "New ID: " + fLastID + " Inserted ....";
              }
              //MessageBox.Show("Rec Saved....");
              ClearThisForm();
              return true;
          }
          else
          {
              toolStripStatuslblAlertText.Text = "ID: " + "mtextID.Text.ToString()" + " Not Saved: Try again....";
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
        #region LookUp

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
            frmLookUp sForm = new frmLookUp(
                fKeyField, 
                "actype_title,actype_st,ordering", 
                fTableName, 
                "Ac Type",
                1, 
                "ID,Ac Type Title,Short,Ordering", 
                "10,20,10,10", 
                "T,T,T,T",
                true, 
                fJoin
                );

            //sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            //if (mtextID.Text != null)
            //{
            //    if (mtextID.Text.ToString() == "" || mtextID.Text.ToString() == string.Empty)
            //    {
            //        return;
            //    }
            //    System.Windows.Forms.SendKeys.Send("{TAB}");
            //}

        }
        catch (Exception e)
        {
            MessageBox.Show("Exception: Lookup " + e.Message, lblFormTitle.Text.ToString());
        }
        #endregion Lookup
    }
    // ----Event/Delegate--------------------------------




    public frmGLCOA Owner { get; set; }
  }

}
