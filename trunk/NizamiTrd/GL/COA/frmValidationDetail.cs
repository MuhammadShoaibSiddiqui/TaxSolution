using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using TestFormApp.Security.Cls;
using TestFormApp.StringFun01;


// Definition
// Permissions are rules that regulate which users can use a resource such as a folder,file or printer.
// Rights are rules that regulate which user can perform tasks such as creating a user account,
// logging on to the local computer or shutting down a server.

namespace TestFormApp.Security.UI
{
    public partial class frmValidationDetail : Form
    {
        bool fAlreadyExists = false;
        int fFormID = 1001;
        string ErrrMsg = string.Empty;
        int fTErr = 0;
        string fTableName = string.Empty;           // Master Table Name
        string fTableNameDtl = string.Empty;        // Detail Table Name
        string fKeyField = string.Empty;            // Master Table Key Field
        string fKeyFieldDtl = string.Empty;         // Detail Table Key Field
        string SQL2Exe = string.Empty;              // Query to Execute (to be Sent for commit)
        string fLastID = string.Empty;              // Last Document ID
        string fDataMode = "";                      // "" == Not selected, "I" = Insert, "U" = Update.
        //
        int fDocID = 0;
        public frmValidationDetail()
        {
            InitializeComponent();
            BasicNodes();
            lVValidDtl.MultiSelect = false;
        }
        // =================================================
        private void BasicNodes()
        {
            this.KeyPreview = true;
            //this.MaximizeBox = false;
            this.Text = clsGVar.CoTitleSt + "  [ " + clsGVar.YrTitle + " ]";
        }

        // ------------------------------------------------
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            // We are only interested in right mouse clicks
            //if (e.Button == MouseButtons.Right)
            //{
            //    // Attempt to get the node the mouse clicked on
            //    TreeNode node = tVManage.GetNodeAt(e.X, e.Y);
            //    if (node != null)
            //    {
            //        // Select the tree item
            //        tVManage.SelectedNode = node;

            //        // Check what type of node was clicked and edit
            //        // context menu
            //        if (node.Text.ToString() == "User")
            //        {
            //            cMUserManager.Items[0].Visible = true;
            //            cMUserManager.Items[1].Visible = false;
            //            ////tvmcontextMenuAlbum.Items[0].Visible = false;
            //            ////   ... frmCreateUser sUserManagerCreate = new frmCreateUser("Create&t","");
            //            //frmCreateUser sUserManagerCreate = new frmCreateUser("&Modify", "baba");
            //            ////sUserManagerCreate.MdiParent = this;
            //            //sUserManagerCreate.ShowDialog();
            //            //FillUser();
            //        }
            //        else if (node.Text.ToString() == "Group")
            //        {
            //            cMUserManager.Items[0].Visible = false;
            //            cMUserManager.Items[1].Visible = true;
            //        }
            //        else if (node.Text.ToString() == "Form")
            //        {
            //            cMUserManager.Items[0].Visible = false;
            //            cMUserManager.Items[1].Visible = false;
            //        }

            //    }
            //}
        }
        // ------------------------------------------------

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchLV_Click(object sender, EventArgs e)
        {
            ListViewItem foundItem = lVValidDtl.FindItemWithText(textSearchTV.Text, false, 0, true);
            if (foundItem != null)
            {
                lVValidDtl.TopItem = foundItem;
                lVValidDtl.Focus();
            }
            DateTime now = DateTime.Now;
            if (textSearchTV.Text == "" || textSearchTV.Text == string.Empty)
            {
                textAlert.Text = "Search Box: Empty/Blank... " + now.ToString("T");
                return;
            }
            //
            if (lVValidDtl.Items.Count <= 0)
            {
                //MessageBox.Show("Nothing to find....","Find List View");
                textAlert.Text = "List View Empty, Nothing to find/Search... " + now.ToString("T");
                return;
            }
            int colCount = lVValidDtl.Columns.Count;
            int col = 0;
            int lastItm = 0;
            bool blnFind = false;
            for (int i = col; i < colCount; i++)
            {
                for (int lVRow = lastItm; lVRow < lVValidDtl.Items.Count; lVRow++)
                {
                    if (lVValidDtl.Items[lVRow].SubItems[i].Text.IndexOf(textSearchTV.Text) > -1 | lVValidDtl.Items[lVRow].SubItems[i].Text.ToUpper().IndexOf(textSearchTV.Text.ToUpper()) > -1)
                    {
                        lVValidDtl.TopItem = lVValidDtl.Items[lVRow];
                        //
                        lVValidDtl.Focus();                                   // Sequence is important
                        lVValidDtl.Items[lVRow].Selected = true;
                        //
                        lastItm = lVRow + 1;
                        blnFind = true;
                        break;
                    }
                } // for lVRow
                if (blnFind)
                    break;
            } // For i
        }

        private void frmValidationDetail_Load(object sender, EventArgs e)
        {
            lblFormTitle.Text = "Validation Detail";
            textTitle.MaxLength = 50;
            textST.MaxLength = 15;
            textDesc.MaxLength = 50;
            //
            mtextID.Mask = "000";
            mtextID.HidePromptOnLeave = true;
            mtextID.ReadOnly = true;
            mtextOrdering.Mask = "000";
            mtextOrdering.HidePromptOnLeave = true;
            mtextValue.Mask = "000000.00";
            mtextValue.HidePromptOnLeave = true;
            //
            fTableName = "cnf_valid";
            fTableNameDtl = "cnf_validdtl";
            fKeyField = "valid_id";
            fKeyFieldDtl = "valid_dtl_id";
            //
            string lSQL = "SELECT valid_id,valid_title ";
            lSQL += " from cnf_valid";
            lSQL += " where ";
            lSQL += clsGVar.LGCY;
            lSQL += " order by ordering";
            //
            //lVValid.Clear();
            //ColumnHeader hdr = new ColumnHeader();
            //hdr.Text = "Validation Category";
            //hdr.Width = 100;
            //// Text Allignment
            //hdr.TextAlign = HorizontalAlignment.Center;
            //// Add the headers to the ListView control.
            //lVValid.Columns.Add(hdr);
            ////
            //lVValid.View = View.Details;
            //lVValid.HeaderStyle = ColumnHeaderStyle.None;
            //lVValid.Columns[lVValid.Columns.Count - 1].Width = -2;
            //classDS.FillListView(lVValid, 1, lSQL, "valid_title", "15",false, clsGVar.gConString1);
            //
            clsFillCombo.FillListBox(
                lBValid,
                clsGVar.ConString1,
                "cnf_valid,valid_id,False",
                lSQL
                );
            clsDbManager.SetLVHeader(lVValidDtl, 7, "ID,Valitation Title,Short,Description,Value,Ordering,isdisabled", "5,30,10,20,10,5,5", "N,T,T,T,N,T,T", 0);
            lVValidDtl.Columns[lVValidDtl.Columns.Count - 1].Width = -2;
            lBValid.Focus();
            if (lBValid.Items.Count > 0)
            {
                lBValid.SelectedIndex = 0;
            }
            LoadDetail();
        }
        //
        private void LoadDetail()
        {
            DateTime lNow = DateTime.Now;
            string lSQL = "";
            try
            {
                if (lBValid.Items.Count == 0)
                {
                    textAlert.Text = "No item in Validation Catetory List to select, try again  " + lNow.ToString("T");
                    return;
                }
                if (lBValid.SelectedIndex == -1)
                {
                    textAlert.Text = "Row not selected in Validation Catetory List, try again  " + lNow.ToString("T");
                    return;
                }
                lblValidCatID.Text = lBValid.SelectedValue.ToString();
                lblValidCatTitle.Text = lBValid.Text.ToString(); //      .SelectedItem.ToString();
                //
                lSQL = "SELECT ";
                lSQL += "  valid_dtl_id";
                lSQL += ", valid_dtl_title";
                lSQL += ", valid_dtl_st ";
                lSQL += ", valid_dtl_desc";
                lSQL += ", valid_dtl_value";
                lSQL += ", ordering";
                lSQL += ", isdisabled";
                lSQL += " from cnf_validdtl";
                lSQL += " where ";
                lSQL += " valid_id = " + lBValid.SelectedValue.ToString();
                lSQL += " and ";
                lSQL += clsGVar.LGCY;
                lSQL += " order by ordering";
                clsDbManager.FillListView(lVValidDtl, 7, lSQL, "valid_dtl_id,valid_dtl_title,valid_dtl_st,valid_dtl_desc,valid_dtl_value,ordering,isdisabled", "5,30,10,20,10,5,5", false, clsGVar.ConString1);
                

            }
            catch 
            {
                //MessageBox.Show("",lblFormTitle.Text.ToString() );
                textAlert.Text = "Exception: No item selected in Validation Category List, try again";
            }
        }
        //===========================================================
        //protected override void WndProc(ref Message message)
        //{
        //    const int WM_PAINT = 0xf;

        //    // if the control is in details view mode and columns
        //    // have been added, then intercept the WM_PAINT message
        //    // and reset the last column width to fill the list view
        //    switch (message.Msg)
        //    {
        //        case WM_PAINT:
        //            if (lVValid.View == View.Details && lVValid.Columns.Count > 0)
        //                lVValid.Columns[lVValid.Columns.Count - 1].Width = -2;
        //            break;
        //    }

        //    // pass messages on to the base control for processing
        //    base.WndProc(ref message);
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (lBValid.Items.Count > 0)
            {
                MessageBox.Show("Value : " + lBValid.SelectedValue.ToString() );
            }
        }

        private void lBValid_Click(object sender, EventArgs e)
        {
            LoadDetail();
            btn_Select.Enabled = true;
            tabValid.SelectedTab = tab_ListView;
        }

        private void lVValidDtl_DoubleClick(object sender, EventArgs e)
        {
            AddEdit();
        }
        private void AddEdit()
        {
            tabValid.SelectedTab = tab_AddEdit;
            ListViewItem item = lVValidDtl.SelectedItems[0];
            mtextID.Text = item.SubItems[0].Text.ToString().Trim();
            textTitle.Text = item.SubItems[1].Text.ToString().Trim();
            textST.Text = item.SubItems[2].Text.ToString().Trim();
            textDesc.Text = item.SubItems[3].Text.ToString().Trim();
            mtextValue.Text = item.SubItems[4].Text.ToString().Trim();
            mtextOrdering.Text = item.SubItems[5].Text.ToString().Trim();
            chkIsDisabled.Checked = Convert.ToBoolean(item.SubItems[6].Text.ToString());
            EDButtons(true);
            lBValid.Enabled = false;
            btn_Select.Enabled = false;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ClearThisForm();
            EDButtons(false);
            EDInput(false);
            lBValid.Enabled = true;
        }
        private void ClearThisForm()
        {
            mtextID.Text = string.Empty;
            textTitle.Text = string.Empty;
            textST.Text = string.Empty;
            textDesc.Text = string.Empty;
            mtextValue.Text = string.Empty;
            mtextOrdering.Text = string.Empty;
            chkIsDisabled.Checked = false;
        }
        private void EDInput(bool pFlage)
        {
            if (pFlage)
            {
                mtextID.Enabled = true;
                textTitle.Enabled = true;
                textST.Enabled = true;
                textDesc.Enabled = true;
                mtextValue.Enabled = true;
                mtextOrdering.Enabled = true;
                chkIsDisabled.Enabled = true;
            }
            else
            {
                mtextID.Enabled = false;
                textTitle.Enabled = false;
                textST.Enabled = false;
                textDesc.Enabled = false;
                mtextValue.Enabled = false;
                mtextOrdering.Enabled = false;
                chkIsDisabled.Enabled = false;
            }
        }
        //
        private void EDButtons(bool pFlage)
        {
            if (pFlage)
            {
                btn_Save.Enabled = true;
                btn_Delete.Enabled = true;
            }
            else
            {
                btn_Save.Enabled = false;
                btn_Delete.Enabled = false;
            }
        }
        //
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SaveData();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Processing Save: " + ex.Message, "Save: " + lblFormTitle.Text.ToString());
            }
        }
        private bool SaveData()
        { 
            //bool rtnValue = false;
            DateTime lNow = DateTime.Now;
            // Check Validity of Data
            if (!FormValidation())
            {
                //MessageBox.Show(ErrrMsg, "Validation Error :");
                textAlert.Text = "Validation Error: Not Saved.  " + lNow.ToString("T");
                return false;
            }
            if (!PrepareDocMaster())
            {
                textAlert.Text = "DocMaster: Save Date not ready for execution.'  ...." + "  " + lNow.ToString();
                return false;
            }
            //==============================================================================================
            
            if (clsDbManager.ExeOne(SQL2Exe))
            {
                fLastID = mtextID.Text.ToString();
                if (fAlreadyExists)
                {
                    textAlert.Text = "Existing ID: " + mtextID.Text.ToString() + " Modified ....  "  + lNow.ToString("T");
                }
                else
                {
                    textAlert.Text = "New ID: " + fDocID + " Inserted ....  " + lNow.ToString("T");
                }
                //MessageBox.Show("Rec Saved....");
                ClearThisForm();
                EDInput(false);
                lBValid.Enabled = true;
                return true;
            }
            else
            {
                textAlert.Text = "ID: " + mtextID.Text.ToString() + " Not Saved: Try again....  " + lNow.ToString("T");
                return false;
            }
            //===============================================================================================
        }
        private bool FormValidation()
        {
            bool rtnValue = true;
            fAlreadyExists = false;
            ErrrMsg = string.Empty;
            string custQry = string.Empty;
            try
            {
                if (textTitle.Text.ToString().Trim() == "")
                {
                    ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Title empty or blank, try again ");
                    fTErr++;
                    rtnValue = false;
                }
                if (textDesc.Text.ToString().Trim() == "")
                {
                    ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Description empty or blank, try again ");
                    fTErr++;
                    rtnValue = false;
                }
                // Already Exists
                if (mtextID.Text.ToString().Trim(' ', '-') != "")
                {
                    custQry = " valid_id = " + lblValidCatID.Text.ToString();
                    custQry += " and valid_dtl_id = " + mtextID.Text.ToString();
                    custQry += " and ";
                    custQry += clsGVar.LGCY;

                    fAlreadyExists = clsDbManager.IDAlreadyExistWw(fTableNameDtl, fKeyFieldDtl, custQry);
                }
                else
                {
                    fAlreadyExists = false;
                }
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Form Validation: " + ex.Message, lblFormTitle.Text.ToString());
                return false;
            }

        }
        // PrepareData to Save
        private bool PrepareDocMaster()
        {
            bool rtnValue = true;
            string lSQL = string.Empty;
            string custQRY = string.Empty;
            string lDocWhere = "";
            string chkValueDisabled = string.Empty; 
            //
            lDocWhere += " valid_id = " + lblValidCatID.Text.ToString();
            lDocWhere += " and ";
            lDocWhere += clsGVar.LGCY;
            custQRY = "select max(" + fKeyFieldDtl + ") as maxvalue";
            custQRY += " from " + fTableNameDtl;
            custQRY += " where ";
            custQRY += lDocWhere;
            try
            {
                //string lDocDateStr = StrF01.D2Str(mtDocDate);
                //DateTime lDocDate = DateTime.Parse(lDocDateStr);
                chkValueDisabled = chkIsDisabled.Checked == true ? "1" : "0";    
                if (mtextID.Text.ToString().Trim(' ', '-') == "" && fAlreadyExists == false)
                {

                    //lDocWhere += "";
                    fDocID = clsDbManager.GetNextValMastID(fTableNameDtl, "valid_detail_id",custQRY);
                    //
                    lSQL = "insert into " + fTableNameDtl + " (";
                    lSQL += " loc_id ";                                             // 1-
                    lSQL += ", grp_id ";                                            // 2-
                    lSQL += ", co_id ";                                             // 3-
                    lSQL += ", year_id ";                                           // 4-
                    
                    lSQL += ", valid_id";                                           // 5-
                    lSQL += ", valid_dtl_id";                                       // 6-
                    lSQL += ", valid_dtl_title";                                    // 7-
                    lSQL += ", valid_dtl_st";                                       // 8-
                    lSQL += ", valid_dtl_desc";                                     // 9-
                    lSQL += ", valid_dtl_value";                                    // 10-
                    lSQL += ", ordering";                                           // 11-
                    //
                    lSQL += ", isdisabled";                                         // 12-
                    lSQL += ", isdefault";                                          // 12a-
                    lSQL += ", frm_id";                                             // 12b-
                    lSQL += ", created_by ";                                        // 13-
                    //lSQL += ", modified_by ";                                     // 14-
                    lSQL += ", created_date ";                                      // 15-
                    //lSQL += ", modified_date  ";                                  // 16-
                    lSQL += " ) values (";
                    //

                    lSQL += clsGVar.LocID.ToString();                              // 1-
                    lSQL += ", " + clsGVar.GrpID.ToString();                       // 2-
                    lSQL += ", " + clsGVar.CoID.ToString();                        // 3-
                    lSQL += ", " + clsGVar.YrID.ToString();                        // 4-
                    lSQL += ", " + lblValidCatID.Text.ToString();                   // 5-
                    lSQL += ", " + fDocID;                                          // 6-
                    lSQL += ",'" +StrF01.EnEpos( textTitle.Text.ToString() )+ "'";  // 7-
                    lSQL += ",'" + StrF01.EnEpos(textST.Text.ToString()) + "'";     // 8-
                    lSQL += ",'" + StrF01.EnEpos(textDesc.Text.ToString()) + "'";   // 9-
                    lSQL += ", " + mtextValue.Text.ToString().Replace(" ", string.Empty);     // 10-
                    lSQL += ", " + mtextOrdering.Text.ToString();                   // 11-
                    // 
                    lSQL += ", " + chkValueDisabled;                                // 12-
                    lSQL += ",0";                                                   // 12a-Isdefault = false 
                    lSQL += ", " + fFormID;                                         // 12b
                    lSQL += ", " + clsGVar.AppUserID.ToString();                   // 13- Created by
                    //                                                              // 14- Modified by
                    lSQL += ",'" + StrF01.D2Str(DateTime.Now, true) + "'";          // 15- Created Date  
                    //                                                              // 16- Modified Date
                    lSQL += ")";

                }
                else
                {
                        //MessageBox.Show("Doc/Voucher ID " + mtextID.Text.ToString() + " has been deleted or removed"
                        //   + "\n\r" + "The Voucher will be saved as new voucher, try again "
                        //   + "\n\r" + "Or press clear button to discard the voucher/Doc.", lblFormTitle.Text.ToString());
                        //mtextID.Text = "";
                        //rtnValue = false;
                        //return rtnValue;

                    fDocID = Convert.ToInt16(mtextID.Text.ToString());
                    lSQL = "update " + fTableNameDtl + " set ";
                    //lSQL += " loc_id = ";                                                     // 1-
                    //lSQL += ", grp_id = ";                                                    // 2-
                    //lSQL += ", co_id = ";                                                     // 3-
                    //lSQL += ", year_id = ";                                                   // 4-
                    //lSQL += ", valid_id";                                                     // 5-
                    //lSQL += ", valid_dtl_id";                                                 // 6-
                    //
                    lSQL += "  valid_dtl_title = '" + StrF01.EnEpos(textTitle.Text.ToString()) + "'";               // 7-
                    lSQL += ", valid_dtl_st = '" + StrF01.EnEpos(textST.Text.ToString()) + "'";                     // 8-
                    lSQL += ", valid_dtl_desc = '" + StrF01.EnEpos(textDesc.Text.ToString()) + "'";                 // 9-
                    lSQL += ", valid_dtl_value = " + mtextValue.Text.ToString().Replace(" ",string.Empty) ;         // 10-
                    lSQL += ", ordering = " + mtextOrdering.Text.ToString();                                        // 11-
                    //
                    lSQL += ", isdisabled = " + chkValueDisabled;                               // 12-
                    //lSQL += ", created_by ";                                                  // 13-
                    lSQL += ", modified_by = " + clsGVar.AppUserID.ToString();                 // 14-
                    //lSQL += ", created_date ";                                                // 15-
                    lSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";     // 16-
                    lSQL += " where ";
                    lSQL += " valid_dtl_id = " + mtextID.Text.ToString();
                    lSQL += " and ";
                    lSQL += lDocWhere;
                    // xyz.Replace("  ", string.empty);
                }
                SQL2Exe = lSQL;
                return rtnValue;
            }
            catch (Exception ex)
            {
                rtnValue = false;
                MessageBox.Show("Exception: Save Validation: " + ex.Message, lblFormTitle.Text.ToString());
                return false;
            }
        }

        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            fDataMode = "I";
            ClearThisForm();
            EDInput(true);
            lBValid.Enabled = false;
            btn_Save.Enabled = true;
            textTitle.Focus();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmValidationDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (textTitle.Text.Trim().Length > 0)
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

        private void btn_FocuslV_Click(object sender, EventArgs e)
        {
            tabValid.SelectedTab = tab_ListView;
            lVValidDtl.Focus();
            if (lVValidDtl.Items.Count > 0)
            {
                lVValidDtl.Items[0].Selected = true;
            }

        }

        private void btn_FocuslB_Click(object sender, EventArgs e)
        {
            lBValid.Focus();
            if (lBValid.Items.Count > 0)
            {
                lBValid.SelectedIndex = 0;
            }
            tabValid.SelectedTab = tab_ListView;
            LoadDetail();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            DateTime lNow = DateTime.Now;
            if (lVValidDtl.SelectedItems.Count > 0)
            {
                AddEdit();
            }
            else
            {
                textAlert.Text = "Row not selected in the list, try again " + lNow.ToString("T");
            }
        }

        private void tabValid_Enter(object sender, EventArgs e)
        {
            //if (tabValid.SelectedIndex == 0)
            //{
            //    btn_Select.Enabled = true;
            //}
            //else
            //{
            //    btn_Select.Enabled = false;
            //}
        }

        private void tabValid_Leave(object sender, EventArgs e)
        {
                //btn_Select.Enabled = false;
        }

        private void tab_ListView_Leave(object sender, EventArgs e)
        {
            //btn_Select.Enabled = false;
        }

        private void tab_ListView_Enter(object sender, EventArgs e)
        {
            btn_Select.Enabled = true;
        }

        private void tS_AddEdit_Click(object sender, EventArgs e)
        {
            DateTime lNow = DateTime.Now;
            if (lVValidDtl.SelectedItems.Count > 0)
            {
                AddEdit();
            }
            else
            {
                textAlert.Text = "Row not selected in the list, try again " + lNow.ToString("T");
            }

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            // Check dependencie(s)

            // Confirmation Message
            if (MessageBox.Show("Are You Sure Really want to Delete ?", lblFormTitle.Text.ToString() + " ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string tSQL = string.Empty;
                tSQL = "Delete from " + fTableNameDtl;
                tSQL += " Where ";
                tSQL = " valid_id = " + lblValidCatID.Text.ToString();
                tSQL += " and valid_dtl_id = " + mtextID.Text.ToString();
                tSQL += " and ";
                tSQL += clsGVar.LGCY;

                MessageBox.Show("ID: " + mtextID.Text.ToString() + " : " + textTitle.Text.ToString() + "\r\nDeleted... ", lblTitle.Text.ToString());
            }

        }





    }
}
