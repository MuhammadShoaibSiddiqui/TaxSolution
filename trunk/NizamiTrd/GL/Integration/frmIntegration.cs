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

// Definition
// Permissions are rules that regulate which users can use a resource such as a folder,file or printer.
// Rights are rules that regulate which user can perform tasks such as creating a user account,
// logging on to the local computer or shutting down a server.

namespace TestFormApp.Utl
{
    enum GCol
    {
        currstatus = 0,
        tranid = 1,
        snum = 2,
        acid = 3,
        actitle = 4,
        refid = 5,
        reftitle = 6,
        doctran = 7,
        debit = 8,
        credit = 9,
        glref = 10
    }

    public partial class frmIntegration : Form
    {
        bool fErr = false;
        ContextMenu mnuContextMenu;
        MenuItem[] CmMenuItem;
        int fTotalAllMenuItems = 0;
        //
        int fTotalSubMenuItem = 0; //cancelled
        string[] fMenuName;
        int fTotalTreeNode = 0;
        string[] fpTreeNodeName;
        // 
        string[] fMain;
        int fFormID = 0;
        //
        List<string> fTreeNodeName;
        List<string> ftTreeNodeDocID;
        List<string> fContextMenu;
        List<int> fTotalCol;
        List<string> fListTitle;
        List<string> fListColWidth;
        List<string> fListColFormat;
        List<int> fColorSchem;
        //
        List<string> fListQry;
        List<string> fListFieldName;
        //
        //string fMemberofListTable = string.Empty;
        //string fMemberofListField = string.Empty;
        //string fNotMemberofListTable = string.Empty; 
        //string fNotMemberofListField = string.Empty;

        List<string> fMemberofListTable;
        List<string> fMemberofListField;
        List<string> fNotMemberofListTable;
        List<string> fNotMemberofListField;

        //
        string SelNode = string.Empty;
        string SelDocID = string.Empty;
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
        public frmIntegration(
            string pMainParam, 
            int pTotalTreeNode,
            string pListTreeNodeName,

            List<string> pTreeNodeName,
            List<string> ptTreeNodeDocID, 
            List<string> pContextMenu,
            List<int> pTotalCol,
            List<string> pListTitle,
            List<string> pListColWidth,
            List<string> pListColFormat,
            List<int> pColorSchem,
            
            List<string> pListQry,
            List<string> pListFieldName,                                                // Example

            List<string> pMemberofListTable,
            List<string> pMemberofListField,
            List<string> pNotMemberofListTable,
            List<string> pNotMemberofListField
            )
        { 
            InitializeComponent();
            //
            fMain = pMainParam.Split(',');
            fFormID = Convert.ToInt32(fMain[0]);
            lblFormTitle.Text = fMain[1];
            //
            fTotalTreeNode = pTotalTreeNode;
            fpTreeNodeName = pListTreeNodeName.Split(',');
            if (fTotalTreeNode != fpTreeNodeName.Length)
            {
                fErr = true;
            }
            // ----------------------
            fTreeNodeName = pTreeNodeName;
            ftTreeNodeDocID = ptTreeNodeDocID;
            fContextMenu = pContextMenu;
            fTotalCol = pTotalCol;
            fListTitle = pListTitle;
            fListColWidth = pListColWidth;
            fListColFormat = pListColFormat;
            fColorSchem = pColorSchem;
            //
            fListQry = pListQry;
            fListFieldName = pListFieldName;                                            // Example
            // for Memberof Parameters
            fMemberofListTable =pMemberofListTable;
            fMemberofListField = pMemberofListField;
            fNotMemberofListTable = pNotMemberofListTable;
            fNotMemberofListField = pNotMemberofListField; 
            // ======================
            BasicNodes();
            //lVManage.MultiSelect = false;
            AddTreeNode();
            //AddContextMenu();
        }


        // =================================================
        private void AddTreeNode()
        {
            DateTime now = DateTime.Now;
            TreeNode MainNode = new TreeNode("Main");
            tVManage.Nodes.Add(MainNode);
            for (int i = 0; i < fTotalTreeNode ; i++)
            {
                TreeNode GrpNode = new TreeNode(fpTreeNodeName[i].Trim(), i + 1, i + 1);   // 2 = image, 2 = selected image
                GrpNode.Tag = ftTreeNodeDocID[i].Trim();
                MainNode.Nodes.Add(GrpNode);

            }        
        }
        private void BasicNodes()
        {
            this.KeyPreview = true;
            //this.MaximizeBox = false;
            this.Text = clsGVar.CoTitleSt + "  [ " + clsGVar.YrTitle + " ]";
        }
        // =================================================
        private void AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tVManage.SelectedNode.Text != "Main")
            {
                SelNode = tVManage.SelectedNode.Index.ToString();
            }
            else
            {
                SelNode = "Main";
                //int n = 0;
                //foreach (MenuItem item in mnuContextMenu.MenuItems)
                //{
                //    mnuContextMenu.MenuItems[n].Visible = false;
                //    n++;
                //}
                return;
            }
            //
            string tSelNode = SelNode;
            if (tSelNode.Length < 2)
            {
                tSelNode = "0" + SelNode;
            }
            //cMUserManager.Items[0].Visible = true;        // for Manually created.
            //mnuContextMenu.MenuItems[0].Visible = false;    // for Dynamycally/Programatically created.
            //mnuContextMenu.MenuItems[1].Visible = false;

            //int i = 0;
            //foreach (MenuItem item in mnuContextMenu.MenuItems)
            //{
            //    string abc = item.Name.ToString().Substring(0, 7);
            //    if (item.Name.ToString().Substring(0, 7) == "cMenu" + tSelNode)
            //    {
            //        mnuContextMenu.MenuItems[i].Visible = true;
            //    }
            //    else
            //    {
            //        mnuContextMenu.MenuItems[i].Visible = false;
            //    }
            //    i++;
            //}
            //Fill_0();
            DateTime now = DateTime.Now;
            toolStripStatuslblAlertText.Text = "Selected Node: " + SelNode + "  " + now.ToString("T"); 
        }
        private void Fill_0()
        {
            int lSelValue = 0;
            if (SelNode == "Main")
            {
                return;
            }
            else
            {
                lSelValue = Convert.ToInt16(SelNode);
            }
            // 
            string tTreeNodeName = fTreeNodeName[lSelValue];
            int tTotalCol = fTotalCol[lSelValue];
            string tListTitle = fListTitle[lSelValue];
            string tListColWidth  = fListColWidth[lSelValue];
            string tListColFormat = fListColFormat[lSelValue];
            int tColorSchem = fColorSchem[lSelValue];
            //
            string tListQry = fListQry[lSelValue];
            string tListFieldName = fListFieldName[lSelValue];                      // Example
            //
            // 1- ListView Control (Fixed)
            // 2- Total Columns
            // 3- Column titles
            // 4- Column Width
            // 5- Column Format
            // 6- Color Scheme Default = 0
            //
            //--------------------------------------
            //classDS.SetLVHeader(
            //    lVManage,
            //    tTotalCol, 
            //    tListTitle,
            //    tListColWidth,
            //    tListColFormat,
            //    tColorSchem
            //    );
            //--------------------------------------


            // 1- ListView Control (Fixed)
            // 2- Total Columns
            // 3- Select Query
            // 4- Field List
            // 5- Column Width
            // 6- bool CheckBox Column
            // 7- connection string
            //
            //--------------------------------------
            //classDS.FillListView(
            //    lVManage,
            //    tTotalCol, 
            //    tListQry,
            //    tListFieldName,
            //    tListColWidth, 
            //    false, 
            //    clsGVar.gConString1
            //    );
            //--------------------------------------

        }
        // ------------------------------------------------
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            // We are only interested in right mouse clicks
            if (e.Button == MouseButtons.Right)
            {
                // Attempt to get the node the mouse clicked on
                TreeNode node = tVManage.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    // Select the tree item
                    //tVManage.SelectedNode = node;

                    if (tVManage.SelectedNode.Text != "Main")
                    {
                        SelNode = tVManage.SelectedNode.Index.ToString();
                        SelDocID = tVManage.SelectedNode.Tag.ToString();

                    }
                    else
                    {
                        SelNode = "Main";
                    }
                }
            }
        }
        //
        private void OnTreeMenuClick()
        { 
        }
        // ------------------------------------------------

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearchLV_Click(object sender, EventArgs e)
        {
            //DateTime now = DateTime.Now;
            //if (textSearchTV.Text == "" || textSearchTV.Text == string.Empty)
            //{
            //    toolStripStatuslblAlertText.Text = "Search Box: Empty/Blank... " + now.ToString("T");
            //    return;
            //}
            ////
            //if (lVManage.Items.Count <= 0)
            //{
            //    toolStripStatuslblAlertText.Text = "List View Empty, Nothing to find/Search... " + now.ToString("T");
            //    return;
            //}
            //int colCount = lVManage.Columns.Count;
            //int col = 0;
            //int lastItm = 0;
            //bool blnFind = false;
            //for (int i = col; i < colCount; i++)
            //{
            //    for (int lVRow = lastItm; lVRow < lVManage.Items.Count; lVRow++)
            //    {
            //        if (lVManage.Items[lVRow].SubItems[i].Text.IndexOf(textSearchTV.Text) > -1 | lVManage.Items[lVRow].SubItems[i].Text.ToUpper().IndexOf(textSearchTV.Text.ToUpper()) > -1)
            //        {
            //            lVManage.TopItem = lVManage.Items[lVRow];
            //            //
            //            lVManage.Focus();                                   // Sequence is important
            //            lVManage.Items[lVRow].Selected = true;
            //            //
            //            lastItm = lVRow + 1;
            //            blnFind = true;
            //            break;
            //        }
            //    } // for lVRow
            //    if (blnFind)
            //        break;
            //} // For i
        }

        // Add Context Menu
        //public void AddContextMenu()
        //{
        //    mnuContextMenu = new ContextMenu();
        //    this.ContextMenu = mnuContextMenu;                      // This Form's context menu
        //    //CmMenuItem = new MenuItem[fTotalMenutem];

        //    fTotalAllMenuItems = 0;
        //    for (int k = 0; k < fTotalTreeNode; k++)
        //    {
        //        string[] lMenuName;
        //        lMenuName = fContextMenu[k].Split(',');
        //        fTotalAllMenuItems += lMenuName.Length;
        //    }
        //    CmMenuItem = new MenuItem[fTotalAllMenuItems];                             // 1- [] instead of (), 2- No [] with CmMenuItem as earlier defined at top

        //    int lCount = 0;
        //    for (int j = 0; j < fTotalTreeNode; j++)                                // Number of Tree Nodes
        //    {
        //        // Prepare Menu Array from List
        //        string[] lMenuName;
        //        lMenuName = fContextMenu[j].Split(',');
        //        fTotalSubMenuItem = lMenuName.Length;
        //        //
        //        for (int i = 0; i < fTotalSubMenuItem; i++)
        //        {
        //            CmMenuItem[lCount] = new MenuItem();
        //            //CmMenuItem = new MenuItem[lCount];

        //            string tNo = j.ToString();
        //            if (tNo.Length < 2)
        //            {
        //                tNo = "0" + j.ToString();                                   // Category of Menu with respect to Tree Node
        //            }
        //            string tNoi = i.ToString();
        //            if (tNoi.Length < 2)
        //            {
        //                tNoi = "0" + i.ToString();                                   // Inner Sequence Numer With respect to Individual Set of Menu
        //            }
        //            CmMenuItem[lCount].Name = "cMenu" + tNo + "_" + tNoi;
        //            CmMenuItem[lCount].Text = lMenuName[i].Trim();
        //            //
        //            CmMenuItem[lCount].Click += new EventHandler(nMenuItem_Click);
        //            //
        //            mnuContextMenu.MenuItems.Add(CmMenuItem[lCount]);
        //            lCount++;                                                       // Context Menu should be in Contineouse Serial Order
        //            if (lCount >= fTotalAllMenuItems)
        //            {
        //                break;
        //            }
        //        } // Inner loop i
        //    } // Outer loop j
        //}
        //
        //private void nMenuItem_Click(object sender, EventArgs e)
        //{
        //    DateTime now = DateTime.Now;
        //    for (int i = 0; i < fTotalAllMenuItems ; i++)
        //    {
        //        if (sender.GetHashCode() == CmMenuItem[i].GetHashCode())
        //        {

        //            string abc = CmMenuItem[i].Name;
        //            toolStripStatuslblAlertText.Text = "formID " + fFormID.ToString() + " MenuName: " + abc + " Node: " + abc.Substring(5, 2) + " Menu " + abc.Substring(8,2) + " " + now.ToString("T");

        //            //MessageBox.Show("You have clicked menu Item: " + CmMenuItem[i].Name + " Node " + CmMenuItem[i].Name.Substring(5,2) + " Menu " + CmMenuItem[i].Name.Substring(8,2) , "Context Menu System");
        //            switch (fFormID)
        //            {
        //                case 1006:
        //                    {
        //                        //pTreeNodeName[i].Trim();
        //                        if (SelNode == "1")
        //                        {
        //                            //ListViewItem item = lVManage.SelectedItems[0];
        //                            //int tID = Convert.ToInt32(item.SubItems[0].Text.ToString().Trim());
        //                            //string tTitle = item.SubItems[1].Text.ToString().Trim();
        //                            //// 1- Selected ID
        //                            //// 2- Selected Title
        //                            //// 3- Memberof Table List for Query
        //                            //// 4- Memberof Field List for Query
        //                            //// 5- Not Memberof Table List for Query
        //                            //// 6- Not Memberof Field List for Query

        //                            //int lSelValue = 0;
        //                            //if (SelNode == "Main")
        //                            //{
        //                            //    return;
        //                            //}
        //                            //else
        //                            //{
        //                            //    lSelValue = Convert.ToInt16(SelNode);
        //                            //}
        //                            //string lMemberofListTable = fMemberofListTable[lSelValue]; 
        //                            //string lMemberofListField = fMemberofListField[lSelValue];
        //                            //string lNotMemberofListTable = fNotMemberofListTable[lSelValue];
        //                            //string lNotMemberofListField = fNotMemberofListField[lSelValue];
                                     
        //                            //frmAllocationMemberOf sUserManagerCreate = new frmAllocationMemberOf(
        //                            //    tID, 
        //                            //    tTitle, 
        //                            //    lMemberofListTable, 
        //                            //    lMemberofListField,
        //                            //    lNotMemberofListTable, 
        //                            //    lNotMemberofListField
        //                            //    );
        //                            //sUserManagerCreate.ShowDialog();
        //                        }
        //                        break;
        //                    }
        //                default:
        //                    break;
        //            }

        //        }
        //    }
        //}

        private void frmIntegration_Load(object sender, EventArgs e)
        {
            AtFormLoad();
        }
        private void AtFormLoad()
        {
            List<string> tCmbKeyfield = new List<string> 
            {
                "",
                ""
            };
            List<string> tCmbQry = new List<string>
            {
                "",
                ""
            };
            List<string> tCmbFillType = new List<string>
            {
                "",
                ""
            };
            //
            List<string> tMtMask = new List<string>
            {
                "",
                ""
            };
            //
            clsDbManager.SetGridHeaderCmb(
            dGV,
            6,
            "S#,Integration Title,Account Title,Ac ID,Side,Status",
            "5,20,20,10,10,10",
            "0, 0, 0, 0, 0, 0",
            "0, 0, 0, 0, 0, 0",
            "T, T, T, T,CB,CB",
            "1, 1, 1, 1, 1, 1",
            "DATA",
            tMtMask,
            tCmbFillType,
            tCmbKeyfield, 
            tCmbQry,
            false,
            2);

            dGV.AllowUserToAddRows = false;
            dGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tVManage.SelectedNode.Text != "Main")
            {
                SelNode = tVManage.SelectedNode.Index.ToString();
                SelDocID = tVManage.SelectedNode.Tag.ToString();
                PopulateGrid(SelDocID);
                    
            }
            else
            {
                SelNode = "Main";
            }

        }
        //
        private void PopulateGrid(string pSeldocID)
        {
            string lSQL = "select doc_title, doc_st, doc_transide, isdisabled";
            lSQL += "where ";
            lSQL += clsGVar.LGCY;
            lSQL += " and ";
            lSQL += "doc_id" + " = " + SelDocID;
            lSQL += " order by doc_id, doc_seqid";

        }


        //private void lVManage_Click(object sender, EventArgs e)
        //{
           
        //    DateTime now = DateTime.Now;
        //    if (lVManage.Items.Count <= 0)
        //    {
        //        toolStripStatuslblAlertText.Text = "Empty ListView: "  + now.ToString("T");
        //        return;
        //    }
        //    ListViewItem item = lVManage.SelectedItems[0];
        //    string labc = " ID: " + item.SubItems[0].Text.ToString().Trim() + " Name: " + item.SubItems[1].Text.ToString().Trim();

        //    toolStripStatuslblAlertText.Text = "formID " + fFormID.ToString() + " Node : " + SelNode + " " +  " [ " + labc + " ] " + now.ToString("T");
        //}
        //=======================================================
    }
}
