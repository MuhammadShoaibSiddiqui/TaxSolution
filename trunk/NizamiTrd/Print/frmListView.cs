using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using System.IO;                    // For File dialogbox, open/save/read

namespace TestFormApp
{
    // By BaBa (out of class)
    public delegate void BuildProgress(object sender, int progressPercent);
    // Without above the line was giving error: private event BuildProgress BuildProgress;

    public partial class frmListView : Form
    {
        // class level field
        private ListViewColumnSorter lvwColumnSorter;
        // By BaBa (within class at class level)
        private event BuildProgress BuildProgress;
        private event EventHandler BuildComplete;


        public frmListView()
        {
            InitializeComponent();
            // 
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set the view to show details.
            listViewOne.View = View.Details;
            // Allow the user to edit item text.
            listViewOne.LabelEdit = true;
            // Allow the user to rearrange columns.
            listViewOne.AllowColumnReorder = true;
            // Display check boxes.
            listViewOne.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listViewOne.FullRowSelect = true;
            // Display grid lines.
            listViewOne.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewOne.Sorting = SortOrder.Ascending;

            // Create three items and three sets of subitems for each item.
            ListViewItem item1 = new ListViewItem("item1", 0);
            // Place a check mark next to the item.
            item1.Checked = true;
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            item2.SubItems.Add("6");
            ListViewItem item3 = new ListViewItem("item3", 0);
            // Place a check mark next to the item.
            item3.Checked = true;
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");
            item3.SubItems.Add("9");

            // Create columns for the items and subitems.
            listViewOne.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
            listViewOne.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
            listViewOne.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            listViewOne.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

            //Add the items to the ListView.
            listViewOne.Items.AddRange(new ListViewItem[] { item1, item2, item3 });


        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            // create the subitems to add to the list
            string[] myItems = new string[] 
              {
                textBox1.Text,
                textBox2.Text,
                textBox3.Text
              };
            ListViewItem lvi = new ListViewItem(myItems);

            // insert all the items into the listview at the last available row
            listView1.Items.Add(lvi);
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "C# Corner Save File Dialog";
                sfd.InitialDirectory = @"D:\";
                sfd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                sfd.FilterIndex = 2;
                sfd.RestoreDirectory = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter m_streamWriter = new StreamWriter(fs);
                    m_streamWriter.Flush();

                    // Write to the file using StreamWriter class 
                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    for (int i = 0; i < this.listView1.Items.Count; i++)
                    {
                        for (int j = 0; j < this.listView1.Items[i].SubItems.Count; j++)
                        {
                            string tab = (j == 0) ? string.Empty : "\t";
                            m_streamWriter.Write(tab + listView1.Items[i].SubItems[j].Text);
                        }
                        m_streamWriter.WriteLine();
                    }

                    m_streamWriter.Flush();
                    m_streamWriter.Close();
                }
            }
            catch (Exception em)
            {
                MessageBox.Show("Error: " + em.Message.ToString());
            }

        }

        private void readbutton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "C# Corner Open File Dialog";
                fdlg.InitialDirectory = @"D:\";
                fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                fdlg.FilterIndex = 2;
                fdlg.RestoreDirectory = true;

                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(fdlg.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader m_streamReader = new StreamReader(fs);

                    // Write to the file using StreamWriter class 
                    m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    string strLine = m_streamReader.ReadLine();
                    int nStart = 0;
                    while (strLine != null)
                    {
                        int nPos1 = strLine.IndexOf("\t", nStart);
                        string str1 = strLine.Substring(0, nPos1);
                        nStart = nPos1 + 1;
                        int nPos2 = strLine.IndexOf("\t", nStart);
                        string str2 = strLine.Substring(nStart, nPos2 - nStart);
                        nStart = nPos2 + 1;
                        string str3 = strLine.Substring(nStart);
                        ListViewItem lvi = new ListViewItem(new string[] { str1, str2, str3 });
                        listView1.Items.Add(lvi);
                        nStart = 0; // reset
                        strLine = m_streamReader.ReadLine();
                    }

                    m_streamReader.Close();

                }

            }
            catch (Exception em)
            {
                MessageBox.Show("Error: " + em.Message.ToString());
            }
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            InitializeListView(); // must reinitialize listview because column info is also cleared
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }
        public void InitializeListView()
        {
            ColumnHeader header1 = this.listView1.Columns.Add("Name", 10 * Convert.ToInt32(listView1.Font.SizeInPoints), HorizontalAlignment.Center);
            ColumnHeader header2 = this.listView1.Columns.Add("E-mail", 20 * Convert.ToInt32(listView1.Font.SizeInPoints), HorizontalAlignment.Center);
            ColumnHeader header3 = this.listView1.Columns.Add("Phone", 20 * Convert.ToInt32(listView1.Font.SizeInPoints), HorizontalAlignment.Center);
        }

        private void frmListView_Load(object sender, EventArgs e)
        {
            //InitializeListView();     // header of 1st Option (Upper Buttons Set)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "This is a long text to Demonostrate the Functionality of Scrolling";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Goes to the end of list.
            listViewOne.EnsureVisible(listViewOne.Items.Count - 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.BuildProgress += BuildProgressHandler;
            this.BuildComplete += BuildCompleteHandler;
            progressBar1.Visible = true;
            this.lblProgress1.Text = "Build Progress";
            BuildProgress(this, this.progressBar1.Value + 10);

            string tQry = "Select * from treecoa order by acnostr";  // "SELECT [AcID] ,[AcNo] ,[AcParentID] ,[AcLevel] ,[AcLevelID] ,[AcNoStr] ,[AcTitle] FROM [GLAcMaster]  where [AcLocationID] = 1 and [AcGroupID] = 1 and [AcCompanyID] = 1"; 
            FillRecursiveTV.LoadNodesTable(treeview1, tQry,"","","" );
            //
            this.progressBar1.Value = 0;
            BuildComplete(this, null);

        }
        private void BuildProgressHandler(object sender, int progress)
        {
            // Show progress
            this.progressBar1.Value = progress;
        }

        private void BuildCompleteHandler(object sender, EventArgs e)
        {
            // Show completion
            this.lblProgress1.Text = "Rebuild All succeeded";
            this.progressBar1.Visible = false;
            this.lblProgress1.Visible = false;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            treeview1.Nodes[treeview1.Nodes.Count - 1].EnsureVisible();
            // dataGridView1.FirstDisplayedCell =  dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // After applying sort functionality the treeview has become extremly slow:

            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending;
            // Attach Subitems to the ListView
            listView1.Columns.Add("Id", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Ac Title", 300, HorizontalAlignment.Left);
            listView1.Columns.Add("Ac Abbr", 70, HorizontalAlignment.Left);
            //listView1.Columns.Add("Publi-Date", 100, HorizontalAlignment.Left);
            // -----------------------------------------------------------------
            DataTable dtable = clsGetTable.GetDataTable("select top 200 acnostr, actitle, acabbr from glacmaster where AcLocationID = 1 and  AcGroupID = 1 and AcCompanyID = 1");
            // Clear the ListView control
            listView1.Items.Clear();
            // Display items in the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DataRow drow = dtable.Rows[i];

                ////// Only row that have not been deleted
                ////if (drow.RowState != DataRowState.Deleted)
                ////{
                ////    // Define the list items
                ////    ListViewItem lvi = new ListViewItem(drow["acnostr"].ToString());
                ////    lvi.SubItems.Add(drow["actitle"].ToString());
                ////    lvi.SubItems.Add(drow["acabbr"].ToString());
                ////     // Add the list items to the ListView
                ////    listView1.Items.Add(lvi);
                ////} // end if
                ////// Define the list items
                // the above is commented to make it faster but no change.
                ListViewItem lvi = new ListViewItem(drow["acnostr"].ToString());
                //lvi.SubItems.Add(drow["acnostr"].ToString());
                lvi.SubItems.Add(drow["actitle"].ToString());
                lvi.SubItems.Add(drow["acabbr"].ToString());
                // Add the list items to the ListView
                listView1.Items.Add(lvi);

            } // end for


        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Sorting disabled after detecting it is very slow for 5000 records.
        //////    // Determine if clicked column is already the column that is being sorted.
        //////    if (e.Column == lvwColumnSorter.SortColumn)
        //////    {
        //////        // Reverse the current sort direction for this column.
        //////        if (lvwColumnSorter.Order == SortOrder.Ascending)
        //////        {
        //////            lvwColumnSorter.Order = SortOrder.Descending;
        //////        }
        //////        else
        //////        {
        //////            lvwColumnSorter.Order = SortOrder.Ascending;
        //////        }
        //////    }
        //////    else
        //////    {
        //////        // Set the column number that is to be sorted; default to ascending.
        //////        lvwColumnSorter.SortColumn = e.Column;
        //////        lvwColumnSorter.Order = SortOrder.Ascending;
        //////    }

        //////    // Perform the sort with these new sort options.
        //////    this.listView1.Sort();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int tCol = 3;
            string tSQL = "select top 200 acnostr, actitle, acabbr from glacmaster where AcLocationID = 1 and  AcGroupID = 1 and AcCompanyID = 1 order by acnostr";
            string tFL ="acnostr,actitle,acabbr";
            string tTL ="Ac ID,Account Title,Short Name";
            string tFLL = "10,30,10";
            listView1.OwnerDraw = true;
            TMP_FillListView.LoadListView(listView1, tCol, tSQL, tFL, tTL, tFLL, false);
        }
        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left;
            if (e.ColumnIndex == 1 && e.Item.Index > 11 && e.Item.Index < 20)
            {
                flags = TextFormatFlags.Right;
            }
            else
            {
                flags = TextFormatFlags.Left;
            }
            e.DrawText(flags); 

        }



        private void button9_Click(object sender, EventArgs e)
        {
            int tCol = 3;
            string tSQL = "select top 200 acnostr, actitle, acabbr from glacmaster where AcLocationID = 1 and  AcGroupID = 1 and AcCompanyID = 1 order by acnostr";
            string tFL = "acnostr,actitle,acabbr";
            string tTL = "Ac ID,Account Title,Short Name";
            string tFLL = "10,30,10";
            TMP_FillListView.LoadListView(listView1, tCol, tSQL, tFL, tTL, tFLL, true);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Checked = true;
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Checked = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                //if (listView1.Items[i].Checked)
                //{
                //    listView1.Items[i].Checked = false;
                //}
                //else
                //{
                //    listView1.Items[i].Checked = true;
                //}

                // OR
                listView1.Items[i].Checked = !listView1.Items[i].Checked;   // this is short cut as toggle
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem itm = listView1.SelectedItems[0];
                
                textBox1.Text = itm.SubItems[0].Text;
                textBox2.Text = itm.SubItems[1].Text;
                textBox3.Text = itm.SubItems[2].Text;
                // After populating the text boxes disable to ListView so that the pointer may not be dislocated (selection may to lost or shift to another element of LV)
                listView1.Enabled = false;
                
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            InitializeListView();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems[0].Text = textBox1.Text.ToString();
            listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text.ToString();
            listView1.SelectedItems[0].SubItems[2].Text = textBox3.Text.ToString();
            //
            listView1.Enabled = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            for (int groupIndex = 0; groupIndex < 3; ++groupIndex)
            {
                this.listView1.Groups.Add("GroupKey" + groupIndex, "Test" + groupIndex);

                for (int index = 0; index < 5; ++index)
                {
                    ListViewItem item = new ListViewItem("Test " + groupIndex + "/" + index,
                                                         this.listView1.Groups[groupIndex]);
                    this.listView1.Items.Insert(0, item);
                    this.listView1.Groups[groupIndex].Items.Insert(0, item);
                }
            } // end for

            for (int groupIndex = 2; groupIndex >= 0; --groupIndex)
            {
                for (int index = 0; index < 5; ++index)
                {
                    ListViewItem item = new ListViewItem("Test2 " + groupIndex + "/" + index,
                                                         this.listView1.Groups[groupIndex]);
                    this.listView1.Items.Insert(0, item);
                    this.listView1.Groups[groupIndex].Items.Insert(0, item);
                }
            } // end for
        // end method
        }

        private void button18_Click(object sender, EventArgs e)
        {


        } 






    }
}
