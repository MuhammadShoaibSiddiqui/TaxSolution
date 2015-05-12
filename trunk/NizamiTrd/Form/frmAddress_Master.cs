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
using TaxSolution;

//using TaxSolution;

namespace TaxSolution
{
  public partial class frmAddress_Master : Form
  {
    LookUp lookUpForm = new LookUp();
    
    // Fields
    enum GFld
    {
        loc = 0,
        grp = 1,
        co = 2,
        yr = 3,
        owner_id = 4,
        addr_sqid = 5,
        addr_type_id = 6,
	    addr_salute_id = 7 ,
	    addr_contactperson = 8,
	    addr_address1 = 9,
	    addr_address2 = 10,
	    addr_country_id = 11,
	    addr_province_id = 12,
	    addr_city_id = 13,
	    addr_zip = 14,
	    addr_phone = 15,
	    addr_ext = 16,
	    addr_mobile = 17,
	    addr_fax = 18,
	    addr_email = 19,
	    addr_web = 20,
	    addr_ref = 21,
	    addr_remarks = 22,
	    ordering = 23
    }
    //
    //List<string> fManySQL = new List<string>();
    string fOwnerSQL = string.Empty;
    
    //
    string fInsert = string.Empty;
    string fModify = string.Empty;
    Int64 fAddrUID = 0;
    Int64 fDocUID = 0;
    // Parameters Form Level
    string fLastID = string.Empty;
    //string fFormID = string.Empty;
    string fFormTitle = string.Empty;
    string fTableName = "cmn_address";
    string fKeyField = string.Empty;
    string fKeyFieldType = string.Empty;
    string ErrrMsg = string.Empty;
    bool fAlreadyExists = false;
    string[] fMain;
    string[] fField;
    string[] fMaxLen;
    string[] fFTArr;
    string[] fValRArr;
      //
    string fValR = string.Empty;
    string fFT = string.Empty;
    string fTitleWidth = string.Empty;
    string fTitleFormat = string.Empty;


    //int plocID = (int)EnCo.GrpID;
    //int pGrpID = (int)EnCo.GrpID;
    //int pCoID = (int)EnCo.GrpID; 
    //int pYearID = (int)EnCo.YearID;
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
    // Combo Box Default Value
    int fcboDefaultValueSalute = 0;
    int fcboDefaultValueCountry = 0;
    int fcboDefaultValueState = 0;
    //
    bool fOneTable = true;
    //
    string fAddrTypeTable = "cmn_address_type";
    string fKeyAddrTypeKeyField = "addr_type_id";   

    string fSaluteTable = "cmn_salute";
    string fSaluteKeyField = "salute_id";   
    //
    string fCountryTable = "geo_country";
    string fCountryKeyField = "country_id";

    string fProvinceTable = "geo_province";
    string fProvinceKeyField = "province_id";

    string fCityTable = "geo_city";
    string fCityKeyField = "city_id";

    bool isLoading = true;
    int fFormID = 0;
    Int64 fOwnerID = 0;
    int fSqID = 0;
    string fPTitle = string.Empty;
    // 1- FormID
    // 2- ID    
    // 3- Title
    public frmAddress_Master(
        int pFormID, 
        Int64 pID,
        string pTitle,
        Int64 pAddrUID,
        string pOwnerSQL

        )
    //Int64 pID, 

    {
      // FormID, Title, Table, KeyField, KeyFieldType, 
      InitializeComponent();
      HookEvents();
      // Title:

      fOwnerID = pID;        // Form ID
      fDocUID = pAddrUID;
      fPTitle = pTitle;
      fOwnerSQL = pOwnerSQL;

      // by baba fFormID = pFormID;
      //fUID = pID;

      lblID.Text = fOwnerID.ToString();
      lblTitle.Text = fPTitle;
      lblTAddrUID.Text = fDocUID.ToString();

      // Buttons
      //btn_Save.Enabled = false;
      btn_Delete.Enabled = false;

    }
    private void AtFormLoad()
    {
        // Form Layout
        // temp to be deleted later
        dGVAddress.Enabled = false;
        //
        //fKeyField = clsGVar.LGCY;
        //fKeyField += " and ";
        //fKeyField += " frm_id = " + fFormID + " and owner_id = " + fOwnerID; 
        fKeyField += " owner_id = " + fOwnerID; 
        this.Text = clsGVar.CoTitle;
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        //  
        this.Text = clsGVar.CoTitleSt;
        mtextID.HidePromptOnLeave = true;
        this.MaximizeBox = false;
        // MaxLength
        // Tab Address:
        textContactPerson.MaxLength = 50;
        textAddress1.MaxLength = 50;
        textAddress2.MaxLength = 50;
        textZip.MaxLength = 10;
        // Tab Contact:
        textPhone.MaxLength = 15;
        textExt.MaxLength = 15;
        textMobile.MaxLength = 15;
        textFax.MaxLength = 15;
        textEmail.MaxLength = 50;
        textWeb.MaxLength = 50;
        // Tab Status
        textAddressRef.MaxLength = 50;
        textAddressRemarks.MaxLength = 50;
        // ToolTip  
        fFormTitle = "Address";
        lblFormTitle.Text = fFormTitle;
        toolTipAddress.ToolTipTitle = fFormTitle;
        toolTipAddress.IsBalloon = true;
        // Address Tab
        tabAddress.ShowToolTips = true;

        //toolTipAddress.SetToolTip(tabAddress, "Tool tip");

        toolTipAddress.SetToolTip(tabPage1, "Address Info: Like, Country, Province, City, Street, Zip etc.");
        toolTipAddress.SetToolTip(cboSalutation, "Required: Select a 'Salutation' for Contact Person / Company etc, from the given list.");
        toolTipAddress.SetToolTip(cboAddrType, "Required: Select a 'Address Type' like 'Billing', 'Shiping' etc, from the given list.");

        toolTipAddress.SetToolTip(textContactPerson, "Contact Person: Required, Max Length: " + textContactPerson.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(textAddress1, "Address Line 1 (Street address): Optional, Max Length: " + textAddress1.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(textAddress2, "Address Line 2 (Street address): Optional, Max Length: " + textAddress2.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(cboCountry, "Required: Select a Country from the Given List ");
        toolTipAddress.SetToolTip(cboState, "Required: Select a State / Province from the given List (It dependes upon 'Country' Selection");
        toolTipAddress.SetToolTip(cboCity, "Required: Select a City from the given List (It dependes upon 'State/Province' Selection");
        toolTipAddress.SetToolTip(textZip, "Optional: Max Length: " + textZip.MaxLength.ToString() + " Alphanumeric Characters.");
        // Contact Tab
        toolTipAddress.SetToolTip(tabPage2, "Contact info: Like, Phone, Fax, Email etc.");
        toolTipAddress.SetToolTip(textZip, "Postal Code/Zip Code (Street address): Optional, Max Length: " + textZip.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(textPhone, "Phone Number (Including Country, Area Code): Optional, Max Length: " + textPhone.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(textExt, "Phone Extension (Multiple allowed seperated by comma): Optional, Max Length: " + textExt.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(textMobile, "Cell /Mobile Phone: Optional, Max Length: " + textMobile.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(textFax, "Fax Number (Including Country, Area Code): Optional, Max Length: " + textFax.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(textEmail, "Email Address: Optional, Max Length: " + textEmail.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(textWeb, "Web Address /URL (Multiple allowed seperated by comma): Optional, Max Length: " + textWeb.MaxLength.ToString() + " Alphanumeric Characters.");
        // Status Tab
        toolTipAddress.SetToolTip(tabPage3, "Current Status info: Default, Active, Disabled etc.");
        toolTipAddress.SetToolTip(textAddressRef, "A prominent Place/Person/Building, to help, to reach the address : Optional, Max Length: " + textAddressRef.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(textAddressRemarks, "A prominent Place/Person/Building, to help, to reach the address : Optional, Max Length: " + textAddressRemarks.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(textAddressRemarks, "Required: for sequence / priority of display/view in the list or report. Useful for multiple addresses " + mtextOrdering.MaxLength.ToString() + " Alphanumeric Characters.");
        toolTipAddress.SetToolTip(chkIsDefault, "When Checked, indicates default address (In case there are multiple addresses. Also see ordering");
        toolTipAddress.SetToolTip(chkIsDisabled, "When Checked, Indicates the record is disabled or In-Active. You can un-checked, to make it 'Active'");
        // Buttons:
        //toolTipAddress.SetToolTip(btn_Save, "Alt+S, Save One Or All record(s) in the Address Grid List");
        toolTipAddress.SetToolTip(btn_Save, "Alt+S, Save Data.");
        toolTipAddress.SetToolTip(btn_Save, "Alt+E, Save Data and close this form.");
        toolTipAddress.SetToolTip(btn_Clear, "Alt+C, Clear all input control/items on this form (All Tabs)");
        toolTipAddress.SetToolTip(btn_Delete, "Alt+D, Delete currently selected record in the 'Address Grid List'");
        toolTipAddress.SetToolTip(btn_New, "Alt+N, Get Ready Input Boxes for Add New Address");
        toolTipAddress.SetToolTip(btn_Modify, "Alt+M, Select record from 'Address Grid List' to Modify / Edit.");
        toolTipAddress.SetToolTip(btn_Exit, "Alt+X, Close this form and exit to the Main Form");
        //
        dGVAddress.ShowCellToolTips = false;
        toolTipAddress.SetToolTip(dGVAddress, "Address Grid List: to hold multiple addresses");

        // -----------------------------------------------------------------------------------
       // string fFT = string.Empty;
        //string fTitleWidth = string.Empty;
        //string fTitleFormat = string.Empty;
        //
            // fValR = Validation Required: N for Combo 
        ////

        //
        fFT = "SID,Salutation,Contact Person, Address Line-1,Address Line-2,";   //05
        fTitleWidth = "0,20,30,30,30,";
        fTitleFormat = "H,T,T,T,T,";
        fValR = "R,R,R,N,N";

        fFT += "CountryID,Country Title,";                                        //02
        fTitleWidth += "0,20,";
        fTitleFormat += "H,T,";
        fValR += "N,N";

        fFT += "ProvinceID,Province/State Title,";                                //02
        fTitleWidth += "0,20,";
        fTitleFormat += "H,T,";
        fValR += "N,N,N";

        fFT += "CityID,City Title,Postal Code,";                                  //03
        fTitleWidth += "0,20,15,";
        fTitleFormat += "H,T,T,";
        fValR += "N,N,N";

        fFT += "Phone,Ext,Cell/Mobile,Fax,Email Address,Web Address,";            //06
        fTitleWidth += "15,15,15,30,30,30,";
        fTitleFormat += "T,T,T,T,T,T,";
        fValR += "N,N,N,N,N,N";

        fFT += "Address Ref.,Address Remarks,Ordering";                           //03
        fTitleWidth += "30,30,10";
        fTitleFormat += "T,T,T";
        fValR += "N,N,R";
        // Temporarily suspended
        //classDS.SetGridHeader(dGVAddress, 
        //    20, 
        //    fFT, 
        //    fTitleWidth,
        //    "",
        //    fTitleFormat,
        //    "1",
        //    "LOOKUP",
        //    1);
        // Combo Box
        cboAddrType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboSalutation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCountry.DropDownStyle = ComboBoxStyle.DropDownList;
        cboState.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCity.DropDownStyle = ComboBoxStyle.DropDownList;
        // Address Type
        clsFillCombo.FillCombo(cboAddrType, clsGVar.ConString1, fAddrTypeTable + ",addr_type_id,False", "select * from " + fAddrTypeTable);
        // Salute
        clsFillCombo.FillCombo(cboSalutation, clsGVar.ConString1, fSaluteTable + ",salute_id,False", "select * from " + fSaluteTable);
        //fcboDefaultValueSalute = Convert.ToInt16(cboSalutation.SelectedValue);
        fcboDefaultValueSalute = cboSalutation.SelectedIndex;
        // Country
        clsFillCombo.FillCombo(cboCountry, clsGVar.ConString1, fCountryTable + ",country_id,False", "select * from " + fCountryTable);
        fcboDefaultValueCountry = Convert.ToInt16(cboCountry.SelectedValue);
        //fcboDefaultValueCountry = cboCountry.SelectedIndex;
        // State/Province
        clsFillCombo.FillCombo(cboState, clsGVar.ConString1, fProvinceTable + ",province_id,False", "select * from " + fProvinceTable + " where province_pid = " + Convert.ToInt16(fcboDefaultValueCountry).ToString());
        fcboDefaultValueState = Convert.ToInt16(cboState.SelectedValue);
        // City
        clsFillCombo.FillCombo(cboCity, clsGVar.ConString1, fCityTable + ",city_id,False", "select * from " + fCityTable + " where city_pid = " + Convert.ToInt16(fcboDefaultValueState).ToString());
        // org: isLoading = "N";
        isLoading = false;
        // Note when a combo is empty then its child combo should also be blank
        LoadFrmData();

    }

    private void LoadFrmData()
    {
        fAlreadyExists = false;
        //
        if (fDocUID > 0)    // Selected large int so that it may not conflict with int16, int32 etc
        {
            string tSQL = string.Empty;

            // top 1 will be omited when used multiple addresses
            // sqid will be taken from Table and put into grid.
            // When editing particualr address pick it from sqid.
            tSQL = "select top 1 * ";
            tSQL += " from cmn_address";
            tSQL += " where ";
            //tSQL += clsGVar.LGCY;
            //tSQL += " and ";
            //tSQL += " frm_id = " + fFormID.ToString();
            tSQL += " addr_uid = " + fDocUID.ToString();
            tSQL += " order by addr_sqid";

            //========================================================
            DataSet dtset = new DataSet();
            DataRow dRow;
            dtset = clsDbManager.GetData_Set(tSQL, "cmn_address");
            //int abc = dtset.Tables.Count; // gives the number of tables.
            int lRecFound = dtset.Tables[0].Rows.Count;

            if (lRecFound == 0)
            {
                fAlreadyExists = false;
            }
            else
            {
                fAlreadyExists = true;
                //isLoading = true;               // When true then no event fire
                //
                dRow = dtset.Tables[0].Rows[0];
                // Starting title as 0
                textContactPerson.Text = dRow.ItemArray.GetValue(0).ToString();
                textAddress1.Text = dRow.ItemArray.GetValue(1).ToString(); // dtset.Tables[0].Rows[0][1].ToString();
                textAddress2.Text = dRow.ItemArray.GetValue(2).ToString(); // dtset.Tables[0].Rows[0][1].ToString();

                //Object a = dRow.co    .Rows[0]["stud_Id"];
                //string abc1 = dRow.ItemArray.GetValue().ToString();
                //
                // Note: addr_sqid is part of primary key
                // used for multiple addresses.
                // before saving get max value
                //
                clsSetCombo.Set_ComboBox(cboAddrType, Convert.ToInt32(dRow["addr_type_id"]));
                clsSetCombo.Set_ComboBox(cboSalutation, Convert.ToInt32(dRow["addr_salute_id"]));
                textContactPerson.Text = dRow["addr_contactperson"].ToString(); 
                textAddress1.Text = dRow["addr_address1"].ToString();
                textAddress2.Text = dRow["addr_address2"].ToString();
                // Note: check city form for details of bellow
                clsSetCombo.Set_ComboBox(cboCountry, Convert.ToInt32(dRow["addr_country_id"]));
                clsSetCombo.Set_ComboBox(cboState, Convert.ToInt32(dRow["addr_province_id"]));
                clsSetCombo.Set_ComboBox(cboCity, Convert.ToInt32(dRow["addr_city_id"]));
                //
                textZip.Text = dRow["addr_zip"].ToString();
                // Tab Phone
                textPhone.Text = dRow["addr_phone"].ToString();
                textExt.Text = dRow["addr_ext"].ToString();
                textMobile.Text = dRow["addr_mobile"].ToString();
                textFax.Text = dRow["addr_fax"].ToString();
                textEmail.Text = dRow["addr_email"].ToString();
                textWeb.Text = dRow["addr_web"].ToString();
                // Tab Status
                textAddressRef.Text = dRow["addr_ref"].ToString();
                textAddressRemarks.Text = dRow["addr_remarks"].ToString();
                mtextOrdering.Text = dRow["ordering"].ToString();

                if (dRow["isdisabled"] != DBNull.Value)
                {
                    chkIsDisabled.Checked = Convert.ToBoolean(dRow["isdisabled"]);
                }
                else
                {
                    chkIsDisabled.Checked = false;
                }
                if (dRow["isdefault"] != DBNull.Value)
                {
                    chkIsDefault.Checked = Convert.ToBoolean(dRow["isdefault"]);
                }
                else
                {
                    chkIsDefault.Checked = false;
                }
                //
                if (dRow["addr_sqid"] != null)
                {
                    fSqID = Convert.ToInt16(dRow["addr_sqid"]);

                }
                else
                {
                    fSqID = 1;
                    // update the address table with sqid with 1
                }

            } // lRecFound

        }    // if > 0
    }

    private void frmAddress_Master_Load(object sender, EventArgs e)
    {
      isLoading = true;
        AtFormLoad();
    }

    private void btn_Exit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btn_Clear_Click(object sender, EventArgs e)
    {
        if (textContactPerson.Text.ToString().Trim().Length > 0)
        {
            if (MessageBox.Show("Are You Sure To Clear the Form ?", "Clearing Form", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
        }
        ClearThisForm();
    }
    private void ClearThisForm()
    {
      // Tab Address:
      textContactPerson.Text = string.Empty;
      textAddress1.Text = string.Empty;
      textAddress2.Text = string.Empty;
      cboSalutation.SelectedIndex = fcboDefaultValueSalute;
      cboCountry.SelectedIndex = fcboDefaultValueCountry; 
      //cboCity.SelectedIndex = 0;  
      textZip.Text = string.Empty;
      // Tab Contact:
      textPhone.Text = string.Empty;
      textExt.Text = string.Empty;
      textMobile.Text = string.Empty;
      textFax.Text = string.Empty;
      textEmail.Text = string.Empty;
      textWeb.Text = string.Empty;
      // Tab Status
      textAddressRef.Text = string.Empty;
      textAddressRemarks.Text = string.Empty;
      mtextOrdering.Text = string.Empty;
      chkIsDefault.Checked = false;
      chkIsDisabled.Checked = false;
      // Buttons
      //btn_Save.Enabled = false;
      btn_Delete.Enabled = false;
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
      // Pick from Db table
      // for the time being it is from last id + 1
      if (fLastID != string.Empty)
      {
        mtextID.Text = (Convert.ToInt32(fLastID) + 1).ToString();
      }
    }

    private void mtextID_Validating(object sender, CancelEventArgs e)
    {

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

      // check combo box
      if (cboAddrType.SelectedIndex == -1)
      {
          ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Combo Box Address Type is Empty .... ");
          IsValid = false;
      }
      if (cboSalutation.SelectedIndex == -1)
      {
          ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Combo Box Salutation is Empty .... ");
          IsValid = false;
      }

      if (cboCountry.SelectedIndex == -1)
      {
          ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Combo Box Country is Empty .... ");
          IsValid = false;
      }
      if (cboState.SelectedIndex == -1)
      {
          ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Combo Box Province/State is Empty .... ");
          IsValid = false;
      }
      if (cboCity.SelectedIndex == -1)
      {
          ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Combo Box City is Empty .... ");
          IsValid = false;
      }

      //for (int i = 0; i < fValRArr.Length; i++)
      //{
      //  if (fValRArr[i] == "R")
      //  {
      //    switch (i)
      //    { 
      //      // 0 - 2 = Co Data
      //      ////case 3 :
      //      ////  if (mtextID.Text.ToString() == "" || mtextID.Text.ToString() == string.Empty)
      //      ////  {
      //      ////    // ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank ";
      //      ////    ErrrMsg = clsStringFun01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
      //      ////    IsValid = false;
      //      ////  }
      //      ////  break;
      //      ////case 4 :
      //      ////  if (textTitle.Text.ToString() == "" || textTitle.Text.ToString() == string.Empty)
      //      ////  {
      //      ////    //ErrrMsg += "'" + fFieldTitle[i] + "' is Empty or Blank ";
      //      ////   ErrrMsg = clsStringFun01.BuildErrMsg(ErrrMsg, "'" + fFieldTitle[i] + "' is Empty or Blank... " + "");
                
      //      ////    IsValid = false;
      //      ////  }
      //      ////  break;
      //        case 5:
      //            if ( !(new Regex(@"^[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,}$")).IsMatch( textEmail.Text.ToString() ))
      //            {
      //                ErrrMsg = clsStrF01.BuildErrMsg(ErrrMsg, "'" + fFT[i] + "' is Empty or Blank... " + "");
      //                IsValid = false;
      //            }
      //            break;
      //      //// // 6 - 7 = Optional Data

      //    }
      //  }
      //}
      // Already Exists
      //fAlreadyExists = classDS.IDAlreadyExist(fTableName, fKeyField, mtextID.Text.ToString(), "");
      if (fDocUID > 0)
      {
        string ltQry = "";
        ltQry += "select top 1 Addr_uid from cmn_address";
        ltQry += " where ";
        //ltQry += " loc_id = " + clsGVar.LocID.ToString();
        //ltQry += " and grp_id = " + clsGVar.GrpID.ToString();
        //ltQry += " and co_id = " + clsGVar.CoID.ToString();
        //ltQry += " and year_id = " + clsGVar.YrID.ToString();
        //ltQry += " frm_id = " + fFormID.ToString();
        ltQry += " addr_uid = " + fDocUID.ToString();
        //ltQry += " and addr_sqid = " + fSqID.ToString();

        fAlreadyExists = clsDbManager.IDAlreadyExistCQ(fTableName, fKeyField, fOwnerID.ToString(), ltQry);
      }
      else
      {
        fAlreadyExists = false;
      }
      return IsValid;
    }

    private void btn_Delete_Click(object sender, EventArgs e)
    {
      // Confirmation Message
      if (MessageBox.Show("Are You Sure Really want to Delete ?", fFormTitle, MessageBoxButtons.OKCancel) == DialogResult.OK)
      {
        string tSQL = string.Empty;
        tSQL = "Delete from " + fTableName;
        tSQL += " Where ";
        //tSQL += clsGVar.LGCY;
        tSQL += " addr_uid = " + fAddrUID.ToString();
        //tSQL += " and owner_id = " + fFormID.ToString();

        // MessageBox.Show("ID: " + mtextID.Text.ToString() + " : " + ftextTitle.Text.ToString()  + "\r\nDeleted... ", fFormTitle);
      }

    }

    private void frmAddress_Master_KeyDown(object sender, KeyEventArgs e)
    {
      // set KeyPreview = true
      if (e.KeyCode == Keys.Enter) 
        { 
            e.Handled = true;
            System.Windows.Forms.SendKeys.Send("{TAB}"); 
        } 
    }
    // ------------------------------------
    private void EnableDisableSaveBtn()
    {
      // use of Delegate
      //btn_Save.Enabled = !string.IsNullOrEmpty(textTitle.Text) && !string.IsNullOrEmpty(mtextID.Text);
    }
    private void HookEvents()
    {
      //textTitle.TextChanged += delegate { EnableDisableSaveBtn(); };
    }

    private void mtextID_Enter(object sender, EventArgs e)
    {
      toolStripStatuslblStatusText.Text = "Ready";
    }

    private void toolStripStatuslblAlertTitle_Click(object sender, EventArgs e)
    {
      toolStripStatuslblAlertText.Text = string.Empty;
    }

    //private void mtextID_DoubleClick(object sender, EventArgs e)
    //{
    //  frmAddressLookUp();
    //}

    private void frmAddress_Master_FormClosing(object sender, FormClosingEventArgs e)
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
      if (!FormValidation())
      {
        MessageBox.Show(ErrrMsg, "Validation Error :");
        toolStripStatuslblAlertText.Text = "Validation Error: Not Saved.";
        return false;
      }
      string tSQL = string.Empty;
      Int64 fTmpDocUID = 0;

      try
      {
          #region Insert/Update

          if (!fAlreadyExists)
          {
              // Insert/New
              //int lNewVal = 0;
              
              string lStrNewVal = "";
              lStrNewVal += "select max(addr_uid) as maxvalue from cmn_address"; 

              tSQL = "";
              tSQL += "insert into cmn_address (";
              // 0
              //tSQL += "  loc_id";
              // 1
              //tSQL += ", grp_id";
              // 2
              //tSQL += ", co_id";
              // 3
              //tSQL += ", year_id";
              // 4
              //tSQL += "  frm_id";
              // 5
              tSQL += " addr_uid";
              // 6
              tSQL += ", addr_sqid";
              // 7
              tSQL += ", addr_type_id";
              // 8
              tSQL += ", addr_salute_id";
              // 9
              tSQL += ", addr_contactperson";
              // 10
              tSQL += ", addr_address1";
              // 11
              tSQL += ", addr_address2";
              // 12
              tSQL += ", addr_country_id";
              // 13
              tSQL += ", addr_province_id";
              // 14
              tSQL += ", addr_city_id";
              // 15
              tSQL += ", addr_zip";
              /// 16
              tSQL += ", addr_phone";
              // 17
              tSQL += ", addr_ext";
              // 18
              tSQL += ", addr_mobile";
              // 19
              tSQL += ", addr_fax";
              // 20
              tSQL += ", addr_email";
              // 21
              tSQL += ", addr_web";
              // 22
              tSQL += ", addr_ref";
              // 23
              tSQL += ", addr_remarks";
              // 24
              tSQL += ", ordering";
              // 25
              tSQL += ", isdisabled";
              // 26 isdefault     : skiped
              tSQL += ", isdefault";
              // 27 
              tSQL += ", created_by";
              // 28 
              tSQL += ", created_date";
              // 29 modified_by   : skiped
              // 30 modified_date : skiped
              tSQL += " ) values (";
              // 0
              //tSQL += clsGVar.LocID.ToString();
              // 1
              //tSQL += ", " + clsGVar.GrpID.ToString();
              // 2
              //tSQL += ", " + clsGVar.CoID.ToString();
              // 3
              //tSQL += ", " + clsGVar.YrID.ToString();
              // 4
              //tSQL += "  " + fFormID.ToString();
              // 5
              //tSQL += ", " + fOwnerID.ToString();
              // 6
              fDocUID = clsDbManager.GetNextValMastID("", "", lStrNewVal);
              tSQL += " " + fDocUID.ToString();        // using custom query                                    
              // 7
              tSQL += ",  " + "1";                                                  // to be changed  later for multi addresses
              //
              tSQL += ",  " + cboAddrType.SelectedValue.ToString();                 // Address Type ID
              // 8
              tSQL += ",  " + cboSalutation.SelectedValue.ToString();
              // 9
              tSQL += ",  '" + StrF01.EnEpos(textContactPerson.Text.ToString().Trim()) + "'";
              // 10
              tSQL += ",  '" + StrF01.EnEpos(textAddress1.Text.ToString().Trim()) + "'";
              // 11
              tSQL += ",  '" + StrF01.EnEpos(textAddress2.Text.ToString().Trim()) + "'";
              // 12
              tSQL += ",  " + cboCountry.SelectedValue.ToString(); ;
              // 13
              tSQL += ",  " + cboState.SelectedValue.ToString(); ;
              // 14
              tSQL += ",  " + cboCity.SelectedValue.ToString();
              // 15
              tSQL += ", '" + StrF01.EnEpos(textZip.Text.ToString().Trim()) + "'";
              // 16
              tSQL += ", '" + StrF01.EnEpos(textPhone.Text.ToString().Trim()) + "'";
              // 17
              tSQL += ", '" + StrF01.EnEpos(textExt.Text.ToString().Trim()) + "'";
              // 18
              tSQL += ", '" + StrF01.EnEpos(textMobile.Text.ToString().Trim()) + "'";
              // 19
              tSQL += ", '" + StrF01.EnEpos(textFax.Text.ToString().Trim()) + "'";
              // 20
              tSQL += ", '" + StrF01.EnEpos(textEmail.Text.ToString().Trim()) + "'";
              // 21
              tSQL += ", '" + StrF01.EnEpos(textWeb.Text.ToString().Trim()) + "'";
              // 22
              tSQL += ", '" + StrF01.EnEpos(textAddressRef.Text.ToString().Trim()) + "'";
              // 23
              tSQL += ", '" + StrF01.EnEpos(textAddressRemarks.Text.ToString().Trim()) + "'";
              // 24
              if (mtextOrdering.Text == string.Empty || mtextOrdering.Text == null)
              {
                  tSQL += ", 0 ";
              }
              else
              {
                  tSQL += ", " + Convert.ToInt32(mtextOrdering.Text.ToString());
              }
              // 25
              if (chkIsDisabled.Checked == true)
              {
                  tSQL += ", 1";
              }
              else
              {
                  tSQL += ",  0";
              }
              // 
              // 26 isdefault
              tSQL += ",  0";
              // 27
              tSQL += ", " + clsGVar.AppUserID.ToString();
              // 28
              tSQL += ", '" +  StrF01.D2Str(DateTime.Now, true) + "'";
              // 29 modified_by    : skiped
              // 30 modified_date  : skiped

              tSQL += " )";


          }
          else
          {
              // Modify/Update
              tSQL = "update cmn_address set ";
              // 0
              //tSQL += "coloc = " + clsGVar.gLocID.ToString();
              //// 1
              //tSQL += ", cogrp = " + clsGVar.gGrpID.ToString();
              //// 2
              //tSQL += ", coco = " + clsGVar.gCoID.ToString();
              //// 3
              //tSQL += ", coyr = " + clsGVar.gYrID.ToString();
              //// 4
              //tSQL += "frm_id = " + fFormID.ToString();
              //// 5
              //tSQL += ", owner_id = " + fOwnerID.ToString();
              //// 6
              //tSQL += ", addr_sqid = " + "1";                                           // to be changed  later for multi addresses
              // 7
              tSQL += " addr_type_id = " + cboAddrType.SelectedValue.ToString();      
                
              tSQL += ", addr_salute_id = " + cboSalutation.SelectedValue.ToString();
              // 9
              tSQL += ", addr_contactperson = '" + StrF01.EnEpos(textContactPerson.Text.ToString().Trim()) + "'";
              // 10
              tSQL += ", addr_address1 =  '" + StrF01.EnEpos(textAddress1.Text.ToString().Trim()) + "'";
              // 11
              tSQL += ", addr_address2 = '" + StrF01.EnEpos(textAddress2.Text.ToString().Trim()) + "'";
              // 12
              tSQL += ", addr_country_id = " + cboCountry.SelectedValue.ToString(); ;
              // 13
              tSQL += ", addr_province_id = " + cboState.SelectedValue.ToString(); ;
              // 14
              tSQL += ", addr_city_id = " + cboCity.SelectedValue.ToString();
              // 15
              tSQL += ", addr_zip = '" + StrF01.EnEpos(textZip.Text.ToString().Trim()) + "'";
              // 16
              tSQL += ", addr_phone = '" + StrF01.EnEpos(textPhone.Text.ToString().Trim()) + "'";
              // 17
              tSQL += ", addr_ext = '" + StrF01.EnEpos(textExt.Text.ToString().Trim()) + "'";
              // 18
              tSQL += ", addr_mobile = '" + StrF01.EnEpos(textMobile.Text.ToString().Trim()) + "'";
              // 19
              tSQL += ", addr_fax = '" + StrF01.EnEpos(textFax.Text.ToString().Trim()) + "'";
              // 20
              tSQL += ", addr_email = '" + StrF01.EnEpos(textEmail.Text.ToString().Trim()) + "'";
              // 21
              tSQL += ", addr_web = '" + StrF01.EnEpos(textWeb.Text.ToString().Trim()) + "'";
              // 22
              tSQL += ", addr_ref = '" + StrF01.EnEpos(textAddressRef.Text.ToString().Trim()) + "'";
              // 23
              tSQL += ", addr_remarks = '" + StrF01.EnEpos(textAddressRemarks.Text.ToString().Trim()) + "'";
              // 24
              if (mtextOrdering.Text == string.Empty || mtextOrdering.Text == null)
              {
                  tSQL += ", ordering = 0";
              }
              else
              {
                  tSQL += ", ordering = " + Convert.ToInt32(mtextOrdering.Text.ToString());

              }
              // 25
              if (chkIsDisabled.Checked == true)
              {
                  tSQL += ", isdisabled = 1";
              }
              else
              {
                  tSQL += ", isdisabled = 0";
              }
              // 26 isdefault     : skiped
              // 27 created_by    : skiped
              // 28 created_date  : skiped
              // 29
              tSQL += ", modified_by = " + clsGVar.AppUserID.ToString();
              // 30
              tSQL += ", modified_date = '" +  StrF01.D2Str(DateTime.Now, true) + "'";
              tSQL += " where ";
              //tSQL += " loc_id = " + clsGVar.LocID.ToString();
              //tSQL += " and grp_id = " + clsGVar.GrpID.ToString();
              //tSQL += " and co_id = " + clsGVar.CoID.ToString();
              //tSQL += " and year_id = " + clsGVar.YrID.ToString();
              //tSQL += " frm_id = " + fFormID.ToString();
              //tSQL += " and owner_id = " + fOwnerID.ToString();
              tSQL += " addr_uid = " + fDocUID.ToString();                                           // to be changed  later for multi addresses


              // WHERE

          }

          #endregion

      }
      catch (Exception e)
      {
          MessageBox.Show("Exception: Before Save: " + e.Message, lblFormTitle.Text.ToString());
          return false;
      }

      try
      {
          //#region Execute Query to save data
          List<string> fManySQL = new List<string>();
          //
          fManySQL.Add(tSQL);
          //fOwnerSQL = fOwnerSQL.Replace("<<TOBEFillED>>", fTmpDocUID.ToString());
          fOwnerSQL = fOwnerSQL.Replace("<<TOBEFillED>>", fDocUID.ToString() );
          fManySQL.Add(fOwnerSQL);
        
          //if (clsDbManager.ExeOne(tSQL))
          if (clsDbManager.ExeMany(fManySQL))
          {
              fLastID = mtextID.Text.ToString();
              if (fAlreadyExists)
              {
                  toolStripStatuslblAlertText.Text = "Existing ID: " + fLastID + " Modified ....";
              }
              else
              {
                  toolStripStatuslblAlertText.Text = "New ID: " + fLastID + " Inserted ....";
              }
              //MessageBox.Show("Rec Saved....");
              //ClearThisForm();
              return true;
          }
          else
          {
              toolStripStatuslblAlertText.Text = "ID: " + mtextID.Text.ToString() + " Not Saved: Try again....";
              return false;
          }

          //#endregion
      }
      catch (Exception e)
      {
          MessageBox.Show("Exception: Save: " + e.Message, lblFormTitle.Text.ToString());
          return false;
      }

    }
    // End Save
    public void frmAddressLookUp()
    {
      ////                              [FieldList],[KeyField],[TableName],[FormTitle],[DefaultFindField],[FieldTitle],[TitleWidth],[TitleFormat]
      //frmLookUp sForm = new frmLookUp(fKeyField, cFL, fTableName, fFormTitle, 1, cFT, fTitleWidth, fTitleFormat);
      ////sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
      //sForm.ShowDialog();
      //if (mtextID.Text != null)
      //{
      //  System.Windows.Forms.SendKeys.Send("{TAB}"); 
      //}
    }
    // ----Event/Delegate--------------------------------
    //private void PassData(object sender)
    //{
    //  //textBoxForm4.Text = ((TextBox)sender).Text;
    //  //textBoxForm4.Text = ((MaskedTextBox)sender).Text;
    //  mtextID.Text = ((MaskedTextBox)sender).Text;
    //}

    private void mtextID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {

    }

    private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (isLoading == false)
        {
            // (isLoading == false = The Form has been loaded)
            clsFillCombo.FillCombo(cboState, clsGVar.ConString1, fProvinceTable + ",province_id,False", "select * from " + fProvinceTable + " where province_pid = " + Convert.ToInt16(cboCountry.SelectedValue).ToString());
        }
    }
    private void cboState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (isLoading == false)
        // (isLoading == false = The Form has been loaded)
        {
            clsFillCombo.FillCombo(cboCity, clsGVar.ConString1, fCityTable + ",city_id,False", "select * from " + fCityTable + " where city_pid = " + Convert.ToInt16(cboState.SelectedValue).ToString());
        }
    }

    private void btn_SaveNExit_Click(object sender, EventArgs e)
    {
        Cursor.Current = Cursors.WaitCursor;
        if (SaveData())
        {
            Cursor.Current = Cursors.Default;
            this.Close();            
        }
        Cursor.Current = Cursors.Default;

    }

    public long fUID { get; set; }
  }

}
