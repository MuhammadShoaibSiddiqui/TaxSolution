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
using System.Data.SqlClient;
using TestFormApp.StringFun01;
using TestFormApp.GL.Cls;
using System.Text.RegularExpressions;
using TestFormApp.GL.Cmn;
using TestFormApp.Cmn;


// Definition
// Permissions are rules that regulate which users can use a resource such as a folder,file or printer.
// Rights are rules that regulate which user can perform tasks such as creating a user account,
// logging on to the local computer or shutting down a server.

// maskfull
// allowprompt as input
namespace TestFormApp.GL.COA
{
    public partial class frmGLCOA : Form
    {
        string _sCurrentTemp = string.Empty;
        bool fErr = false;
        string ErrrMsg = string.Empty;

        ContextMenu mnuContextMenu;
        MenuItem[] CmMenuItem;
        int fTotalAllMenuItems = 0;
        //
        string fZeroStr = "000000000000000000000000000000";
        int fTotalSubMenuItem = 0; //cancelled
        string[] fMenuName;
        // 
        string[] fMain;
        string[] fLevelInputArr;
        string[] fGLMaskArr;
        // 0 = required, 9 = digit or space
        string fGLMask = "0-0-00-00-0000";
        //string fGLMask = "99-99-9999";
        int fGLHeighiestLevel ;
        int fFormID = 0;
        string fTableName = string.Empty;
        string fKeyField = string.Empty;
        string fPidField = string.Empty;
        string fKeyFieldStr = string.Empty;
        string fParentAcType = string.Empty;
        string fAcType = string.Empty;
        string fParentAcID = string.Empty;
        string fAcID = string.Empty;
        string fParentPid = string.Empty;
        string fPid = string.Empty;
        string fParentGroupTran = string.Empty;
        string fParentNaturalSide = string.Empty;
        string fGroupTran = string.Empty;
        string fParentIsBudget = string.Empty;
        string fIsBudget = string.Empty;
        //
        int fLevels = 0;                        // Should be passed as parameter.
        bool fAlreadyExists = false;
        //
        //
        int fcboDefaultValue = 0;
        //
        //string SelNode = string.Empty;
        //
        // 1- Main Parameters FormID, Title
        // 2- Total Tree Nodes
        // 3- List of Tree Nodes
        // 4- Tree Node (List)
        // 5- Context Menu (List)
        // 6- Total Column (List)
        // 7- Column Title (List)
        // 8- Column Width (List)
        // 9- Column Format (List)
        //10- Color Scheme (List)
        //11- Query (List) to fill ListView
        //12- Field (List) to fill ListView
        //13- MemberOf Table List
        //14- MemberOf Field List
        //
        // Constructor:
        public frmGLCOA(
            string pMainParam 
            )
        { 
            InitializeComponent();
            //
            fMain = pMainParam.Split(',');
            fFormID = Convert.ToInt32(fMain[0]);
            lblFormTitle.Text = fMain[1];
            fTableName = fMain[2];
            fKeyField = fMain[3];
            fPidField = fMain[4];
            fKeyFieldStr = fMain[5];
            //AddContextMenu();
        }

        private void frmGLCOA_Load(object sender, EventArgs e)
        {
            AtFormLoad();
        }
        private void AtFormLoad()
        {
            // Note: pnlTreeView is Anchord: 3 Side Left, Right, Bottom: Top is not anchord.
            // Check Boxes are Anchored Bottom, Right

            KeyPreview = true;
            this.Text = clsGVar.CoTitle + "  [ " + clsGVar.YrTitle + " ]";

            //
            //this.MinimumSize = new Size(940, 625);
            this.MinimumSize = new Size(900, 600);

            //
            sCBase.Panel1MinSize = 294;
            sCBase.SplitterDistance =294;
            sCBase.SplitterWidth = 6;
            //
            tVCOA.BorderStyle = BorderStyle.None;
            tVCOA.Margin = new Padding(0);
            pnlTreeOptions.Width = tVCOA.Width;
            // Mask
            mtextParentID.Mask = fGLMask;
            mtextID.Mask = fGLMask;
            mtextOrdering.Mask = "0000000000";
            fGLHeighiestLevel = 5;
            fLevelInputArr = fGLMask.Split('-');
            if (fLevelInputArr.Length != fGLHeighiestLevel)
            {
                MessageBox.Show("Mask and Level conflict!",lblFormTitle.Text);
            }
            //
            mtextParentID.HidePromptOnLeave = true;
            mtextID.HidePromptOnLeave = true;
            mtextOrdering.HidePromptOnLeave = true;
            //
            textTitle.MaxLength = 50;
            textSt.MaxLength = 10;
            utextaTitle.MaxLength = 50;
            textSearchTree.MaxLength = 30;
            // 
            // TextBox Border
            //
            mtextID.BorderStyle = BorderStyle.FixedSingle;
            textTitle.BorderStyle = BorderStyle.FixedSingle;
            utextaTitle.BorderStyle = BorderStyle.FixedSingle;
            //textaTitle.Text = string.Empty;
            textSt.BorderStyle = BorderStyle.FixedSingle;
            mtextOrdering.BorderStyle = BorderStyle.FixedSingle;
            //
            cboAcType.DropDownStyle = ComboBoxStyle.DropDownList;
            string lSQl = "select * from " + "gl_actype";
            lSQl += " where ";
            lSQl += clsGVar.LGCY;
            lSQl += " order by ordering";
            clsFillCombo.FillCombo(
                cboAcType,
                clsGVar.ConString1,
                "gl_actype" + "," + "actype_id" + ",False", lSQl);
            fcboDefaultValue = Convert.ToInt16(cboAcType.SelectedValue);

            
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            string lQry = string.Empty;
            string lFList = "ac_id,ac_title,ac_strid";
            string lpID = "ac_pid";
            string lTreeKey = "ac_id";

            //bool lLoadTop = true;

            if (chkTopLevel.Checked)
            {
                lQry = "Select * from " + fTableName; 
                lQry += " where ";
                lQry += clsGVar.LGCY; 
                lQry += " and " + fPidField + " is NULL";
                lQry += " order by " + fKeyFieldStr; 
            }
            else
            {
                lQry = "Select * from " + fTableName;
                lQry += " where ";
                lQry += clsGVar.LGCY; 
                lQry += " order by " + fKeyFieldStr; 
            }
            //LoadTree(lQry, lLoadTop);
            // 1- Control
            // 2- Query
            // 3- Field List
            // 4- Parent ID
            // 5- TreeKey for Name property
            FillRecursiveTV.LoadNodesTable(
                tVCOA, 
                lQry,
                lFList,
                lpID,
                lTreeKey
                );
            if (chkExpandTree.Checked)
            {
              tVCOA.ExpandAll();
            }
            else
            {
              tVCOA.CollapseAll();
            }
        }

        private void chkExpandTree_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpandTree.Checked)
            {
                tVCOA.ExpandAll();
            }
            else
            {
                tVCOA.CollapseAll();
            }
        }

        private void chkShowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            tVCOA.BeginUpdate();
            if (chkShowCheckBox.Checked)
            {
                tVCOA.CheckBoxes = true;
            }
            else
            {
                tVCOA.CheckBoxes = false;
            }
            tVCOA.EndUpdate();
        }

        private void btn_SearchTree_Click(object sender, EventArgs e)
        {
            FindByText();
        }
        private void FindByText()
        {
            TreeNodeCollection nodes = tVCOA.Nodes;
            foreach (TreeNode n in nodes)
            {
                FindRecursive(n);
            }
        }


        private void FindRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                DateTime now = DateTime.Now;
                // if the text properties match, color the item
                if (tn.Text.ToUpper().Contains(textSearchTree.Text.ToUpper()))
                //if (tn.Text == textSearchTree.Text)
                {
                    tn.BackColor = Color.Yellow;
                    tVCOA.SelectedNode = tn; 
                    
                    tn.Expand();
                    toolStripStatuslblAlertText.Text = "'" + textSearchTree.Text + "'" + " Found. " + now.ToString("T");
                }
                FindRecursive(tn);
            }
        }

        private void btn_ParentClear_Click(object sender, EventArgs e)
        {
            ClearThisFormParent();
        }
        private void ClearThisFormParent()
        {
            if (btn_PinParentID.Text == "&Un Pin")
                return;

            mtextParentID.Text = string.Empty;
            lblParentTitle.Text = string.Empty;
            lblParentaTitle.Text = string.Empty;
            lblParentOrdering.Text = string.Empty;
            lblParentLevel.Text = string.Empty;
            lblParentAcType.Text = string.Empty;
            lblParentNaturalSide.Text = string.Empty;
        }

        private void lbtn_Clear_Click(object sender, EventArgs e)
        {
            ClearThisFormParent();
            ClearThisForm();
        }
        private void ClearThisForm()
        {
            mtextID.Text = string.Empty;
            textTitle.Text = string.Empty;
            utextaTitle.Text = string.Empty;
            //textaTitle.Text = string.Empty;
            textSt.Text = string.Empty;
            mtextOrdering.Text = string.Empty;
            //
            btn_Address.Visible = false;
            if (btn_PinID.Text == "&Un Pin")
                return;


            lblLevel.Text = string.Empty;
            //mtextLevel.Text = string.Empty;
            chkBudget.Checked = false;
            chkGroupTran.Enabled = true;
            chkGroupTran.Checked = true;
            // combo
            if (btn_PinParentID.Text != "&Un Pin")
                cboAcType.Enabled = true;
        }

        private void btn_PinParentID_Click(object sender, EventArgs e) 
        {
            if (btn_PinParentID.Text == "&Pin")
            {
                btn_PinParentID.Text = "&Un Pin";
                btn_PinParentID.Image = TestFormApp.Properties.Resources.BaBa_tiny_pinned;
                mtextParentID.Enabled = false;
            }
            else
            {
                btn_PinParentID.Text = "&Pin";
                btn_PinParentID.Image = TestFormApp.Properties.Resources.BaBa_tiny_pin;
                mtextParentID.Enabled = true;
            }
        }

        private void tVCOA_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void mtextParentID_Validating(object sender, CancelEventArgs e)
        {
            DateTime now = DateTime.Now;
            try
            {
                if (mtextParentID.Text.Trim(' ', '-') == "" )
                {
                    return;
                }
                else
                {
                    //
                    if (!mtextParentID.MaskFull)
                    {

                        int lSpaceLoc = 0;
                        lSpaceLoc = mtextParentID.Text.IndexOf(" ");
                        if (lSpaceLoc != -1)
                        {
                            MessageBox.Show("Account Parent ID: ID incomplete, Space at location " + lSpaceLoc.ToString(), lblFormTitle.Text);
                        }
                        else
                        {
                            MessageBox.Show("Account Parent ID: ID incomplete, Un-wanted character exists in ID.", lblFormTitle.Text);
                        }
                        e.Cancel = true;
                        return;
                    }

                    string tSQL = string.Empty;
                    tSQL = "select top 1 ";
                    //tSQL += "ac_id, ac_title  , ac_atitle  , ac_st  , ordering  , ac_level, ac_type,     istran, isbudget, ac_pid ";
                    tSQL += "m.ac_id, m.ac_title, m.ac_atitle, m.ac_st, m.ordering, m.ac_level, m.actype_id, m.istran, m.isbudget, m.ac_pid,  ";
                    tSQL += "t.actype_title, t.actype_side ";
                    tSQL += " from "; 
                    tSQL += "gl_ac m ";
                    tSQL += " INNER JOIN gl_actype t ON m.actype_id = t.actype_id";
                    tSQL += " where ";
                    tSQL += clsGVar.LGCYm;
                    tSQL += " and ";
                    tSQL += "m." + fKeyFieldStr + " = '" + mtextParentID.Text.ToString() + "'";
                    DataSet dtset = new DataSet();
                    DataRow dRow;
                    dtset = clsDbManager.GetData_Set(tSQL, fTableName);
                    int lNor = dtset.Tables[0].Rows.Count;
                    if (lNor == 0)
                    {
                        //fAlreadyExists = false;
                        // Note: when actype_id = 0  or null then following alert will appear
                        MessageBox.Show("Parent ID " + mtextParentID.Text.ToString() + "  not found",lblFormTitle.Text.ToString());
                        e.Cancel = true;
                    }
                    else
                    {
                        //fAlreadyExists = true;
                        dRow = dtset.Tables[0].Rows[0];
                        // Starting title as 0
                        fParentAcID = dRow.ItemArray.GetValue(0).ToString();
                        lblParentTitle.Text = dRow.ItemArray.GetValue(1).ToString(); 
                        lblParentaTitle.Text = dRow.ItemArray.GetValue(2).ToString(); 
                        lblParentOrdering.Text = dRow.ItemArray.GetValue(4).ToString(); 
                        lblParentLevel.Text = dRow.ItemArray.GetValue(5).ToString();
                        //lblParentAcType.Text = dRow.ItemArray.GetValue(6).ToString(); // work
                        fParentAcType = dRow.ItemArray.GetValue(6).ToString();
                        fParentGroupTran = dRow.ItemArray.GetValue(7).ToString();
                        fParentIsBudget = dRow.ItemArray.GetValue(8).ToString();

                        //
                        fParentPid = dRow.ItemArray.GetValue(9).ToString();
                        if (fParentGroupTran == "True")                  // Note: bit as string = true == "1")
                        {
                            lblParentGroupTran.Text = "Transactional";
                            toolStripStatuslblAlertText.Text = "Transactional ID is not allowed as parent ID, Select another with 'Group' Ac " + now.ToString("T"); 
                        }
                        else
                        {
                            lblParentGroupTran.Text = "Group";
                        }
                        lblParentAcType.Text = dRow.ItemArray.GetValue(10).ToString();
                        fParentNaturalSide = dRow.ItemArray.GetValue(11).ToString();

                        if (fParentNaturalSide == "True")
                        {
                            lblParentNaturalSide.Text = "Credit";
                        }
                        else
                        {
                            lblParentNaturalSide.Text = "Debit";
                        }
                        //
                        if (Convert.ToInt16(fParentAcType) > 0)
                        {
                            cboAcType.SelectedIndex = ClassSetCombo.Set_ComboBox(cboAcType, Convert.ToInt16(fParentAcType) );
                            //lblParentAcType.Text = cboAcType.Text.ToString();
                            cboAcType.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, lblFormTitle.Text.ToString());
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // To Clear Previously entered/accepted text, Widthout it mtext does not accept new text.
            mtextParentID.Clear();
            mtextParentID.Text = StrF01.getIDFromTreeText(tVCOA, '[', ']');
            mtextParentID.Focus();
        }

        private void frmGLCOA_KeyDown(object sender, KeyEventArgs e)
        {
            // set KeyPreview = true
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            } 
        }

        private void addToAccountIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mtextID.Text = StrF01.getIDFromTreeText(tVCOA, '[', ']');
            mtextID.Focus();
        }

        private void mtextID_Validating(object sender, CancelEventArgs e)
        {
            DateTime now = DateTime.Now;
            try
            {
                if (mtextID.Text.Trim(' ', '-') == "")
                {
                    return;
                }
                else
                {
                    if (mtextParentID.Text.Trim(' ', '-') != "")
                    {
                        if (fParentGroupTran == "True")
                        { 
                            MessageBox.Show ("Parent ID is a 'Transactional', it should be 'Group' Account ID",lblFormTitle.Text);
                            mtextParentID.Focus();
                            return;
                        }
                    }
                    //
                    if (!mtextID.MaskFull)
                    {
                        int lSpaceLoc = 0;
                        lSpaceLoc = mtextID.Text.IndexOf(" ");

                        if (lSpaceLoc != -1)
                        {
                            MessageBox.Show("Account ID: ID incomplete, Space at location " + lSpaceLoc.ToString(), lblFormTitle.Text);
                        }
                        else
                        {
                            MessageBox.Show("Account ID: ID incomplete, Un-wanted character exists in ID.", lblFormTitle.Text);
                        }
                        e.Cancel = true;
                        return;

                    }
                    // Following replaced with above.
                    //if (fGLMask.Length != (mtextID.Text.Trim()).Length)
                    //{
                    //    MessageBox.Show("Account ID: Mask n Length..... " + fGLMask.Length + "/" + (mtextID.Text.Trim()).Length, lblFormTitle.Text);
                    //}
                    //
                    // na fLevelInputArr = mtextID.Text.Split('-');
                    // Compair GL levels Defined with input masked textbox
                    if (fLevelInputArr.Length != fGLHeighiestLevel)
                    {
                        MessageBox.Show("Account ID: Mask Diff: Defined / Input : " + fGLHeighiestLevel.ToString() + "/" + fLevelInputArr.Length.ToString(), lblFormTitle.Text);
                    }

                    int lLevel = GetIDLevel(fGLMask, mtextID.Text.ToString());
                    if (lLevel == 99)
                    {
                        MessageBox.Show("Account ID: Error in parsing Account level, check mask or input TextBox "  , lblFormTitle.Text);
                        e.Cancel = true;
                        return;
                    }
                    //
                    lblLevel.Text = lLevel.ToString();
                    //
                    string tSQL = string.Empty;
                    tSQL = "select top 1 ";
                    tSQL += "ac_id, ac_title, ac_atitle, ac_st, ordering, ac_level, actype_id,istran, isbudget, ac_pid ";
                    tSQL += " from " + "gl_ac";
                    tSQL += " where ";
                    tSQL += clsGVar.LGCY;
                    tSQL += " and ";
                    tSQL += fKeyFieldStr + " = '" + mtextID.Text.ToString() + "'";
                    DataSet dtset = new DataSet();
                    DataRow dRow;
                    dtset = clsDbManager.GetData_Set(tSQL, fTableName);
                    int lroc = dtset.Tables[0].Rows.Count;
                    if (lroc == 0)
                    {
                        fAlreadyExists = false;
                        if (!CheckLevel(lLevel, mtextParentID, fParentGroupTran, mtextID))
                        {
                            e.Cancel = true;
                            return;
                        }
                        // lLevel = getlevel mtextid, fGLLevels as parameter
                        if (lLevel == fGLHeighiestLevel)
                        {
                            chkGroupTran.Checked = true;
                            //chkGroupTran.Enabled = false; ?
                        }
                        if (lLevel == 1)
                        {
                            cboAcType.Enabled = true;
                        }
                        else
                        {
                            cboAcType.Enabled = false;
                        }
                        //
                        btn_Address.Visible = false;
                    }
                    else
                    {
                        fAlreadyExists = true;
                        toolStripStatuslblAlertText.Text = "Modifying Account ID " + mtextID.Text.ToString() + "  " + now.ToString("T");
                        dRow = dtset.Tables[0].Rows[0];
                        // Starting title as 0
                        fAcID = dRow.ItemArray.GetValue(0).ToString();
                        textTitle.Text = dRow.ItemArray.GetValue(1).ToString(); 
                        utextaTitle.Text = dRow.ItemArray.GetValue(2).ToString(); 
                        textSt.Text = dRow.ItemArray.GetValue(3).ToString(); 
                        mtextOrdering.Text = dRow.ItemArray.GetValue(4).ToString();
                        lblLevel.Text = dRow.ItemArray.GetValue(5).ToString();
                        fAcType = dRow.ItemArray.GetValue(6).ToString();
                        fGroupTran = dRow.ItemArray.GetValue(7).ToString();
                        fIsBudget = dRow.ItemArray.GetValue(8).ToString();
                        fPid = dRow.ItemArray.GetValue(9).ToString();
                        //
                        cboAcType.SelectedIndex = ClassSetCombo.Set_ComboBox( cboAcType, Convert.ToInt16(fAcType) );
                        if (Convert.ToInt16(lblLevel.Text) == 1)
                        {
                            cboAcType.Enabled = true;
                        }
                        else
                        {
                            cboAcType.Enabled = false;
                        }
                        //
                        if (fGroupTran == "True")               // Note: bit as string = true == "1")
                        {
                            chkGroupTran.Checked = true;        // True = transactional
                            btn_Address.Visible = true;         // Address Button
                        }
                        else
                        {
                            chkGroupTran.Checked = false;       // False = Group
                        }
                        //
                        if (fIsBudget == "True")
                        {
                            chkBudget.Checked = true;
                        }
                        else
                        {
                            chkBudget.Checked = false;
                        }
                        //
                        
                          
                    } // End else part Alreadyexist = true
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, lblFormTitle.Text.ToString());
            }
        }

        public void frmGLAcLookUpParent()
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
                    "ac_title,ac_atitle,Ordering", 
                    "gl_ac", 
                    "GL COA", 
                    1, 
                    "ID,Account Title, Alternate Title,Ordering", 
                    "10,20,20,10", 
                    "T,T,T,T", 
                    true, 
                    fJoin
                    );
                sForm.lupassControl = new frmLookUp.LUPassControl(PassDataParent);
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

        }
        public void frmGLAcLookUp()
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
                    "ac_title,ac_atitle,Ordering",
                    "gl_ac",
                    "GL COA",
                    1,
                    "ID,Account Title, Alternate Title,Ordering",
                    "10,20,20,10",
                    "T,T,T,T",
                    true,
                    fJoin
                    );
                sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
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

        }

        // ----Event/Delegate--------------------------------
        private void PassDataParent(object sender)
        {
            // mtextID.Text = ((MaskedTextBox)sender).Text;
            mtextParentID.Text = ((MaskedTextBox)sender).Text;
        }
        private void PassData(object sender)
        {
            // mtextID.Text = ((MaskedTextBox)sender).Text;
            mtextID.Text = ((MaskedTextBox)sender).Text;
        }

        private void mtextParentID_DoubleClick(object sender, EventArgs e)
        {
            frmGLAcLookUpParent();
        }

        private void mtextID_DoubleClick(object sender, EventArgs e)
        {
            frmGLAcLookUp();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGLCOA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textTitle.Text.ToString().Trim().Length > 0 || lblParentaTitle.Text.ToString().Trim().Length > 0)
            {
                if (MessageBox.Show("Are You Sure To Exit the Form ?", "Closing: " + lblFormTitle.Text, MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btn_PinID_Click(object sender, EventArgs e)
        {
            if (btn_PinID.Text == "&Pin")
            {
                btn_PinID.Text = "&Un Pin";
                btn_PinID.Image = TestFormApp.Properties.Resources.BaBa_tiny_pinned;
                gbPin.Enabled = false;
            }
            else
            {
                btn_PinID.Text = "&Pin";
                btn_PinID.Image = TestFormApp.Properties.Resources.BaBa_tiny_pin;
                gbPin.Enabled = true;
            }
        }
        //
        private int GetIDLevel(string pMask, string pInput)
        {
            int rtnValue =99;
            // if mask is 999 then replace it with 0
            string[] lLevelInputArr;
            string[] lMaskArr; 
            //
            lLevelInputArr = pMask.Split('-');
            lMaskArr = pInput.Split('-');
            if (lLevelInputArr.Length != lMaskArr.Length)
                return rtnValue;

            rtnValue = lMaskArr.Length;
            for (int i = lMaskArr.Length -1 ; i > 0; i--)
            {
                if (fLevelInputArr[i] == lMaskArr[i])
                    rtnValue--; 
            }

            return rtnValue;
        }
        //
        private string GetIDTruncated(string pMask, string pInput)
        {
            string rtnValue = "";
            // if mask is 999 then replace it with 0
            string[] lLevelInputArr;
            string[] lMaskArr;
            //
            lLevelInputArr = pMask.Split('-');
            lMaskArr = pInput.Split('-');
            if (lLevelInputArr.Length != lMaskArr.Length)
                return rtnValue;

            //rtnValue = lMaskArr.Length;
            for (int i = lMaskArr.Length - 1; i > 0; i--)
            {
                if (fLevelInputArr[i] == lMaskArr[i])
                {
                    // Note +1 is to remove last - sign (Minus sign)
                    rtnValue = pInput.Substring(0, (pInput.Length - (fLevelInputArr[i].Length + 1) ));
                }
                //rtnValue--;
            }

            return rtnValue;
        }



        //private string GetIDLevelStr(string pInput, int pLevel)  
        //{
        //    string rtnValue = "";
        //    // if mask is 999 then replace it with 0
        //    string[] lLevelInputArr;
        //    //string[] lMaskArr;
        //    //
        //    lLevelInputArr = pInput.Split('-');
        //    //lMaskArr = pInput.Split('-');
        //    //if (lLevelInputArr.Length != lMaskArr.Length)
        //    //    return rtnValue;

        //    //rtnValue = lMaskArr.Length;
        //    for (int i = 0; i < pLevel; i++)
        //    {
        //        if (i == 0)
        //        {
        //            rtnValue += lLevelInputArr[i];
        //        }
        //        else
        //        {
        //            rtnValue += "-" + lLevelInputArr[i];
        //        }
        //    }

        //    return rtnValue;
        //}
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveData();
            Cursor.Current = Cursors.Default;
        }
        private bool SaveData()
        {
            DateTime now = DateTime.Now;

            //bool rtnValue = false;
            if (!FormValidation())
            {
                MessageBox.Show(ErrrMsg, "Validation Error :" + lblFormTitle.Text.ToString());
                toolStripStatuslblAlertText.Text = "Validation Error: Not Saved." + now.ToString("T");
                return false;
            }
            //int abc1 = Convert.ToInt32(fParentAcID);
            // start save process
            string tSQL = string.Empty;
            try
            {
                //#region Insert/Update

                if (!fAlreadyExists)
                {
                    if (Convert.ToInt16(lblLevel.Text.ToString()) != 1 && Convert.ToInt64(fParentAcID) == 0)
                    {
                        MessageBox.Show(ErrrMsg, "Insert: Parent ID not selected or Invalid, Select another !" + lblFormTitle.Text.ToString());
                        toolStripStatuslblAlertText.Text = "Validation Error: Not Saved." + now.ToString("T");

                        return false;
                    }

                    // Insert/New
                    //int lNewVal = 0;

                    string lStrNewVal = "";
                    lStrNewVal += "select max(" + fKeyField + ") as maxvalue from " + fTableName;
                    lStrNewVal += " where ";
                    lStrNewVal += " loc_id = " + clsGVar.LocID.ToString();
                    lStrNewVal += " and grp_id = " + clsGVar.GrpID.ToString();
                    lStrNewVal += " and co_id = " + clsGVar.CoID.ToString();
                    lStrNewVal += " and year_id = " + clsGVar.YrID.ToString();
                    lStrNewVal += " and frm_id = " + fFormID.ToString();

                    // Insert/New
                    tSQL = "insert into " + fTableName + " (";
                    tSQL += "loc_id, grp_id, co_id, year_id";                  // Loc,Grp,Co,Year
                    tSQL += " , ac_id" ;                                       // 5- ID 
                    tSQL += " , ac_title" ;                                    // 6- title
                    tSQL += " , ac_st" ;                                       // 7- ST 
                    tSQL += " , ordering" ;                                    // 8- Ordering 
                    tSQL += " , ac_pid" ;                                      // 9- Pid
                    tSQL += " , ac_level";                                     // 10- level
                    tSQL += " , ac_strid";                                     // 11- account id string 
                    tSQL += " , ac_strtruncated";                                     // 11- account id string 
                    tSQL += " , actype_id";                                    // 12- account type id 
                    tSQL += " , ac_atitle";                                    // 13- account title alternate 
                    tSQL += " , istran";                                       // 14- Group or Transaction 
                    tSQL += " , isbudget";                                     // 15- Is budget enabled 
                    tSQL += " , isdisabled" ;                                  // 16- IsDisabled bit
                    tSQL += " , isdefault" ;                                   // 17- IsDefault bit
                    tSQL += " , frm_id" ;                                      // 18- FrmID  
                    tSQL += " , created_by";                                   // 19- Created by
                    //tSQL += " , modified_by";                                // 20- Modified by
                    tSQL += " , created_date ";                                // 21- created_date
                    //tSQL += " , modified_date ";                             // 22- modified_date
                    tSQL += ") values ( ";
                    //
                    tSQL += clsGVar.LocID.ToString();                          // 1- 
                    tSQL += ", " + clsGVar.GrpID.ToString();                   // 2-
                    tSQL += ", " + clsGVar.CoID.ToString();                    // 3-
                    tSQL += ", " + clsGVar.YrID.ToString();                                                    // 4-
                    tSQL += ", " + clsDbManager.GetNextValMastID("", "", lStrNewVal);                                // 5- Next Heightest Value
                    tSQL += ", " + "'" + StrF01.EnEpos(textTitle.Text.ToString().Trim()) + "'";              // 6- Title
                    tSQL += ", " + "'" + StrF01.EnEpos(textSt.Text.ToString().Trim()) + "'";                 // 7- St
                    if (mtextOrdering.Text.ToString() == null || mtextOrdering.Text.ToString().Trim() == "")    // 8- Ordering
                    {
                        tSQL += ", 0";
                    }
                    else
                    {
                        tSQL += ", " + mtextOrdering.Text.ToString();
                    }
                    if (Convert.ToInt16(lblLevel.Text.ToString()) == 1)
                    {
                        tSQL += ", Null";                                                                       // 9- Pid  When level = 1 top level
                    }
                    else
                    {
                        tSQL += ", " + fParentAcID;                                                             // 9- Pid  When level > 1
                    }
                    tSQL += ", " + lblLevel.Text.ToString();                                                    // 10- Level
                    tSQL += ", " + "'" + StrF01.EnEpos(mtextID.Text.ToString()) + "'";                       // 11- Account id string
                    tSQL += ", " + "'" + GetIDTruncated(fGLMask,mtextID.Text.ToString()) + "'";                       // 11- Account id string
  
                    tSQL += ", " + cboAcType.SelectedValue.ToString();                                          // 12- account type id
                    tSQL += ", " + "N'" + StrF01.EnEpos(utextaTitle.Text.ToString()) + "'";                   // 13- Alternate Title
                    if (chkGroupTran.Checked == true)
                    {
                        tSQL += ", 1";                                                                          // 14- Group / Tran
                    }
                    else
                    {
                        tSQL += ", 0";
                    }
                    if (chkBudget.Checked == true)
                    {
                        tSQL += ", 1";                                                                          // 15- Budget enabled
                    }
                    else
                    {
                        tSQL += ", 0";
                    }
                    
                    
                    if (chkIsDisabled.Checked == true)
                    {
                        tSQL += ", 1";                                                                          // 16- IsDisabled bit
                    }
                    else
                    {
                        tSQL += ", 0";
                    }
                    // is Default is 0 at insert level, unchanged at update level (it will be implemented through a seperate form.
                    tSQL += ", 0";                                                                              // 17- IsDefault bit
                    tSQL += ", " + fFormID.ToString();                                                          // 18- Form ID
                    tSQL += ", " + clsGVar.AppUserID.ToString();                                               // 19- Created by
                                                                                                                // 20- Modified by
                    tSQL += ", '" +  StrF01.D2Str(DateTime.Now, true) + "'";                                              // 21- Created date
                                                                                                                // 22- Modified Date
                    tSQL += ")";
                }
                else
                {
                    //// Modify/Update
                    tSQL = "update " + fTableName + " set ";
                    tSQL += "  ac_title = '" + StrF01.EnEpos(textTitle.Text.ToString()) + "'";
                    tSQL += ", ac_st = '" + StrF01.EnEpos(textSt.Text.ToString()) + "'";

                    if (mtextOrdering.Text.ToString() == null || mtextOrdering.Text.ToString().Trim() == "")
                    {
                        tSQL += ", ordering = 0";
                    }
                    else
                    {
                        tSQL += ", ordering = " + mtextOrdering.Text.ToString();
                    }
                    if (Convert.ToInt16(lblLevel.Text.ToString()) == 1)
                    {
                        tSQL += ", ac_pid = Null";                                                                       // 9- Pid  When level = 1 top level
                    }
                    else
                    {
                        tSQL += ", ac_pid = " + fPid;                                                           // 9- pid and  fParentAcID in insert qry;
                    }

                    tSQL += ", ac_level = " + lblLevel.Text.ToString();
                    tSQL += ", ac_strid = " + "'" + StrF01.EnEpos(mtextID.Text.ToString()) + "'";
                    tSQL += ", ac_strtruncated = '" + GetIDTruncated(fGLMask,mtextID.Text.ToString()) + "'";

                    tSQL += ", actype_id = " + cboAcType.SelectedValue.ToString();
                    tSQL += ", ac_atitle = " + "N'" + StrF01.EnEpos(utextaTitle.Text.ToString()) + "'";
                    if (chkGroupTran.Checked == true)
                    {
                        tSQL += ", istran = 1";                                                                          // 14- Group / Tran
                    }
                    else
                    {
                        tSQL += ", istran =0";
                    }
                    if (chkBudget.Checked == true)
                    {
                        tSQL += ", isbudget = 1";                                                                          // 15- Budget enabled
                    }
                    else
                    {
                        tSQL += ", isbudget = 0";
                    }



                    if (chkIsDisabled.Checked == true)
                    {
                        tSQL += ", isdisabled = 1";
                    }
                    else
                    {
                        tSQL += ", isdisabled = 0";
                    }
                    // is IsDefault Skiped
                    // formedid = skiped
                    tSQL += ", modified_by = " + clsGVar.AppUserID.ToString();
                    // D2Str tSQL += ", modified_date = '" +  StrF01.D2Str(DateTime.Now, true) + "'";
                    tSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now) + "'";
                    tSQL += " where ";
                    tSQL += clsGVar.LGCY;
                    tSQL += " and ";
                    tSQL += fKeyField + " = " + fAcID.ToString();
                }

               //#endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: Before Save: " + e.Message, lblFormTitle.Text.ToString());
                return false;
            }
            // end save process
            // MessageBox.Show(tSQL);
            if (clsDbManager.ExeOne(tSQL))
            {
                //fLastID = mtextID.Text.ToString();
                if (fAlreadyExists)
                {
                    toolStripStatuslblAlertText.Text = "Existing ID: " + mtextID.Text.ToString() + " Modified ....";
                }
                else
                {
                    toolStripStatuslblAlertText.Text = "New ID: " + mtextID.Text.ToString() + " Inserted ....";
                }
                //MessageBox.Show("Rec Saved....");
                ClearThisForm();
                return true;
            }
            else
            {
                toolStripStatuslblAlertText.Text = "ID: " + mtextID.Text.ToString() + " Not Saved: Try again....";
                return false;
            }
        }
        private bool FormValidation()
        {
            ErrrMsg = string.Empty;
            bool rtnValue = true;

            if (mtextID.Text.ToString() == "" || mtextID.Text.ToString() == string.Empty)
            {
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, " Account ID is Empty or Blank... " );
                rtnValue = false;
            }

            if (textTitle.Text.ToString() == "" || textTitle.Text.ToString() == string.Empty)
            {
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Account Title" + "' is Empty or Blank... " + "");
                rtnValue = false;
            }
            if (utextaTitle.Text.ToString() == "" || utextaTitle.Text.ToString() == string.Empty)
            {
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Alternate Account Title" + "' is Empty or Blank... " + "");
                rtnValue = false;
            }

            if (textSt.Text.ToString() == "" || textSt.Text.ToString() == string.Empty)
            {
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Account Short Title" + "' is Empty or Blank... " + "");
                rtnValue = false;
            }
            if (mtextOrdering.Text.ToString() == "" || mtextOrdering.Text.ToString() == string.Empty)
            {
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Ordering" + "' is Empty or Blank... " + "");
                rtnValue = false;
            }

            return rtnValue;
        }
        private bool CheckLevel(int pLevel, MaskedTextBox pParentID, string pParentGroupTran, MaskedTextBox pID )
        {
            bool rtnValue = false;
            try
            {
                if (pLevel > 1)
                {
                    if (pParentID.Text.Trim(' ', '-') != "")
                    {
                        if (pParentGroupTran == "True")
                        {
                            MessageBox.Show("Parent Account ID is a 'Transactional' Account ID, it should be 'Group' Account ID", lblFormTitle.Text);
                            mtextParentID.Focus();
                            return rtnValue;
                        }

                        if (lblParentLevel.Text != string.Empty)
                        {
                            if (Convert.ToInt16(lblParentLevel.Text) >= pLevel)
                            {
                                MessageBox.Show("Parent Account ID Level must be lower then Account ID level or \n\r Account ID level must be higher then Parent Account ID level", lblFormTitle.Text);
                                return rtnValue;
                            }
                        } // End (fParentGroupTran == "True")
                    } // End (mtextParentID.Text.Trim(' ', '-') != "") 
                    else
                    {
                        MessageBox.Show("Parent ID not selected, please select one.", lblFormTitle.Text);
                        mtextParentID.Focus();
                        return rtnValue;
                    }
                }  // End if lLevel > 1

                return true;
            }
            catch (Exception)
            {
                return rtnValue;
            }


        }

        private void mtextID_Enter(object sender, EventArgs e)
        {
            chkGroupTran.Enabled = true;
            cboAcType.Enabled = true;
        }

        private void mtextParentID_Enter(object sender, EventArgs e)
        {
            cboAcType.Enabled = true;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_NextID_Click(object sender, EventArgs e)
        {
            if (mtextParentID.Text.Trim(' ', '-') == "")
            {
                MessageBox.Show("Parent Account ID is balank or empty. Select Parent ID and try again. ", lblFormTitle.Text.ToString());
                mtextParentID.Focus();
                return;
            }
            if (Convert.ToInt16(lblParentLevel.Text.ToString()) == fGLHeighiestLevel)
            {
                MessageBox.Show("Parent Account ID is a 'Transactional ID', select another, Group level ID.", lblFormTitle.Text.ToString());
                mtextParentID.Focus();
                return;
            }
            string lrtnValue = coa.GetNextMaskID(mtextParentID, Convert.ToInt16(lblParentLevel.Text.ToString()), "gl_ac,ac_strid,ac_level");
            if (lrtnValue.Length >= 3 )
            {
                if (lrtnValue.Substring(0, 3) == "Err")
                {
                    MessageBox.Show("Error parsing Account ID. " + lrtnValue.ToString(), lblFormTitle.Text.ToString());
                    mtextParentID.Focus();
                    return;
                }
                else
                {
                    mtextID.Text = lrtnValue;
                    mtextID.Focus();
                }
            }  // length >=3
            else
            {
                mtextID.Text = lrtnValue;
                mtextID.Focus();
            } // end else length >=3
        }

        private void btn_ShowCoding_Click(object sender, EventArgs e)
        {
            frmAcGrpRange sFormRange = new frmAcGrpRange();
            //sFormRange.MdiParent = this;
            //sFormRange.Show();
            sFormRange.Owner = this;
            sFormRange.Show();


        }

        private void lblOrdering_Click(object sender, EventArgs e)
        {
          mtextOrdering.Text = "100000";
        }

        private void btn_Address_Click(object sender, EventArgs e)
        {
          // 1- FormID
          // 2- ID    
          // 3- Title
          frmAddress_Master Dlg_Address = new frmAddress_Master(
              fFormID,
              Convert.ToInt64(fAcID),
              textTitle.Text.ToString()
              );
          //Dlg_Address.MdiParent = this.MdiParent; // working
          //Dlg_Address.Show();
          Dlg_Address.ShowDialog();

        }

        private void btn_OpeningBalance_Click(object sender, EventArgs e)
        {
            string abc = GetIDTruncated(fGLMask, mtextID.Text);
            MessageBox.Show("Truncated ID =  " + abc);

        }

        //private void textTitle_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    //if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.' || e.KeyChar == '-')
        //    //{
        //    //    TextBox t = (TextBox)sender;
        //    //    bool bHandled = false;
        //    //    _sCurrentTemp += e.KeyChar;
        //    //    if (_sCurrentTemp.Length > 0 && e.KeyChar == '-')
        //    //    {
        //    //        // '-' only allowed as first char 
        //    //        bHandled = true;
        //    //    }
        //    //    if (_sCurrentTemp.StartsWith(Convert.ToString('.')))
        //    //    {
        //    //        // add '0' in front of decimal point 
        //    //        t.Text = string.Empty;
        //    //        t.Text = '0' + _sCurrentTemp;
        //    //        _sCurrentTemp = t.Text;
        //    //        bHandled = true;
        //    //    }
        //    //    e.Handled = bHandled;
        //    //}

        //}

        //private void textTitle_Click(object sender, EventArgs e)
        //{
        //    textTitle.SelectionStart++;
        //    lblParentTitle.Text = textTitle.SelectionStart.ToString();
        //    int i = textTitle.GetLineFromCharIndex(textTitle.SelectionStart);
        //    lblParentOrdering.Text = i.ToString();
        //    int j = textTitle.SelectionStart - textTitle.GetFirstCharIndexFromLine(i);
        //    lblParentLevel.Text = j.ToString(); 
        //}

        //private void textTitle_KeyDown(object sender, KeyEventArgs e)
        //{
        //    // org if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Down))
        //    if ( e.KeyCode == Keys.Left )
        //    {
        //        textTitle.SelectionStart++;
        //        lblParentTitle.Text = textTitle.SelectionStart.ToString();
        //        int i = textTitle.GetLineFromCharIndex(textTitle.SelectionStart);
        //        lblParentOrdering.Text = i.ToString();
        //        int j = textTitle.SelectionStart - textTitle.GetFirstCharIndexFromLine(i);
        //        lblParentLevel.Text = j.ToString();
        //    }
        //    else if (e.KeyCode == Keys.Right)
        //    {
        //        textTitle.SelectionStart--;
        //        lblParentTitle.Text = textTitle.SelectionStart.ToString();
        //        int i = textTitle.GetLineFromCharIndex(textTitle.SelectionStart);
        //        lblParentOrdering.Text = i.ToString();
        //        int j = textTitle.SelectionStart - textTitle.GetFirstCharIndexFromLine(i);
        //        lblParentLevel.Text = j.ToString();
            
        //    }
        //}


        //


    }
}
