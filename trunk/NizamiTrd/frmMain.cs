using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using TaxSolution.PrintViewer;
using TaxSolution.StringFun01;

namespace TaxSolution
{
    public partial class frmMain : Form
    {
        private int childFormNumber = 0;

        public frmMain()
        {
            InitializeComponent();
            clsGVar.AppUserID = 1;
            clsGVar.AppUserTitle = "Shoaib";
            //groupMain.Focused() = false;
            //groupMain.SendToBack = true;
            //groupMain.Parent.SendToBack = true;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void generalVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJournalVoc frm = new frmJournalVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.MdiParent = this;
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void goodsReceiveNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmGRN frm = new frmGRN();
            frmGRNCr frm = new frmGRNCr();
            frm.MdiParent = this;
            //frm.BringToFront = true;
            frm.Show();

        }

        private void creditSaleTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoice frm = new frmInvoice();
            frm.MdiParent = this;
            //frm.BringToFront = true;
            frm.Show();

        }

        private void contractTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContractNew frm = new frmContractNew();
            frm.MdiParent = this;
            //frm.BringToFront = true;
            frm.Show();

        }

        private void itemGroupDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmGroupItem frm = new  frmGroupItem();
            //frm.MdiParent = this;
            ////frm.BringToFront = true;
            //frm.Show();

            frmGroupItem();
        }
        private void frmGroupItem()
        {
            string tMainParam = string.Empty;
            string tBeginParam = string.Empty;

            string tFLBegin = string.Empty;
            string tFL = string.Empty;
            string tFLEnd = string.Empty;

            //
            string tFLenBegin = string.Empty;
            string tFLen = string.Empty;
            string tFLenEnd = string.Empty;
            //
            string tFTBegin = string.Empty;
            string tFT = string.Empty;
            string tFTEnd = string.Empty;
            //
            string tValBegin = string.Empty;
            string tVal = string.Empty;
            string tValEnd = string.Empty;
            //
            string tTitleWidth = string.Empty;
            string tTitleFormat = string.Empty;
            // FormID, Title, Table, KeyField, KeyFieldType,
            tMainParam = "1006,Group ID,gds_Group,Group_id,int16,0";
            //
            //tBeginParam = clsGVar.LocID.ToString();
            //tBeginParam += "," + clsGVar.GrpID.ToString();
            //tBeginParam += "," + clsGVar.CoID.ToString();
            //tBeginParam += "," + clsGVar.YrID.ToString();
            //
            //tFLBegin = "loc_id,grp_id,co_id,year_id";   //"group_id,company_id,year_id"; 
            tFL = "Group_title,Group_st,ordering,isdisabled";
            tFLEnd = "isdefault,frm_id";
            //
            tFLenBegin = "0,0,0";
            tFLen = "4,40,20,4";
            tFLenEnd = "0,0";
            //
            //tFTBegin = "Group ID,Company ID,Year ID";
            tFT = "ID,Group Title,Short Title,Ordering,Is Disabled";
            tFTEnd = "Is Default";
            //
            tValBegin = "0,0,0,0";
            tVal = "R,R,R,R";
            tValEnd = "0";
            //
            tTitleWidth = "10,30,10,10,10";
            tTitleFormat = "N,T,T,T,T";
            //
            frmSDI_Master SDI_Group = new frmSDI_Master(tMainParam, tBeginParam, tFLBegin, tFL, tFLEnd, tFLenBegin, tFLen, tFLenEnd, tFTBegin, tFT, tFTEnd, tValBegin, tVal, tValEnd, tTitleWidth, tTitleFormat);
            SDI_Group.MdiParent = this;
            SDI_Group.Show();
        }
        private void itemCodeDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        //{
            //frmItemDes frm = new frmItemDes();
            //frm.MdiParent = this;
            //frm.Show();
        //}
        {
            frmItemID();
        }
        // Start Goods Item
        private void frmItemID()
        {
            string tMainParam = string.Empty;
            string tBeginParam = string.Empty;

            string tFLBegin = string.Empty;
            string tFL = string.Empty;
            string tFLEnd = string.Empty;

            //
            string tFLenBegin = string.Empty;
            string tFLen = string.Empty;
            string tFLenEnd = string.Empty;
            //
            string tFTBegin = string.Empty;
            string tFT = string.Empty;
            string tFTEnd = string.Empty;
            //
            string tValBegin = string.Empty;
            string tVal = string.Empty;
            string tValEnd = string.Empty;
            //
            string tTitleWidth = string.Empty;
            string tTitleFormat = string.Empty;
            string tJoin = string.Empty;
            string tLookUpField = string.Empty;
            string tLookUpTitle = string.Empty;
            string tLookUpTitleWidth = string.Empty;
            //  0- FormID, 
            //  1- Title, 
            //  2- Table, 
            //  3- KeyField, 
            //  4- KeyFieldType, 
            //  5- AddressFlage,
            //  6- KeyFieldType int16, int32 etc
            //  7-  Cbo-1 Parent Table (join table)
            //  8-  Cbo-1 Parent Table KeyField
            //  9-  Cbo-2 Parent Table (join table)
            //  10- Cbo-2 Parent Table KeyField
            //  11- Combo-1 Name for Tooltip  
            //  12- Combo-2 Name for Tooltip  

            //tMainParam = "1006,Item ID,goodsitem,goodsitem_id,int16,0";
            //tMainParam += ",goodspacking,goodspacking_id,uom,uom_id,Goods Item Packing Name,Goods UOM Default Name";
            string fStartName = "goodsitem";    // " + fStartName + " 
            string fTableCbo1 = "gds_UOM"; // " + fStartCbo1 + "
            string fTableCbo2 = "gds_Group";     // " + fStartCbo2 + "
            // new fields defined due to baming mkt_, geo_, gds_ etc
            string fStartCbo1 = "goodsuom"; // " + fStartCbo1 + "
            string fStartCbo2 = "Group";     // " + fStartCbo2 + "

            string fCbo1KeyField = "goodsuom_id"; // value of ID obtained from Cbo1, stored in goodsitem table
            string fCbo2KeyField = "Group_id";  // value of ID obtained from Cbo2, stored in goodsitem table   

            tMainParam = "1007,Item ID," + "gds_item," + fStartName + "_id,int16,0";
            tMainParam += "," + fTableCbo1 + "," + fStartCbo1 + "_id," + fTableCbo2 + "," + fStartCbo2 + "_id,Goods UOM Default Name,Item Group Name";
            //
            //tBeginParam = clsGVar.LocID.ToString();
            //tBeginParam += "," + clsGVar.GrpID.ToString();
            //tBeginParam += "," + clsGVar.CoID.ToString();
            //tBeginParam += "," + clsGVar.YrID.ToString();
            //
            // "INNER JOIN country p ON c.province_pid = p.country_id"
            //tFLBegin = "loc_id,grp_id,co_id,year_id";   //"group_id,company_id,year_id"; 
            //tFL = fStartName + "_title," + fStartName + "_st,ordering,goodsitem_packing_id,goodsitem_defuom_id,isdisabled";
            tFL = fStartName + "_title," + fStartName + "_st,ordering," + fCbo1KeyField + "," + fCbo2KeyField + ",isdisabled";
            tFLEnd = "isdefault,frm_id";
            //
            tFLenBegin = "0,0,0";
            tFLen = "4,50,35,4";
            tFLenEnd = "0,0";
            //
            //tFTBegin = "Group ID,Company ID,Year ID";
            tFT = "ID,Item Title,Short Title,Ordering,UOM ID,Goup ID,Disabled";
            tFTEnd = "Default";
            //
            tValBegin = "0,0,0,0";
            tVal = "R,R,R,R,R";
            tValEnd = "0";
            //
            tTitleWidth = "10,20,10,20,15,15,10";
            tTitleFormat = "N,T,T,T,T,T,T";

            //tJoin = "INNER JOIN packing p ON c.goodsitem_packing_id = p.packing_id";

            //tJoin =  "LEFT OUTER JOIN goodspacking p ON kt.loc_id = p.loc_id AND kt.grp_id = p.grp_id AND kt.co_id = p.co_id AND kt.year_id = p.year_id AND kt.goodsitem_packing_id = p.goodspacking_id ";
            //tJoin += "LEFT OUTER JOIN goodsuom u ON kt.loc_id = u.loc_id AND kt.grp_id = u.grp_id AND kt.co_id = u.co_id AND kt.year_id = u.year_id AND kt.goodsitem_defuom_id = u.uom_id";

            //tJoin = "LEFT OUTER JOIN " + fTableCbo1 + " p ON kt.grp_id = p.grp_id AND kt.co_id = p.co_id AND kt.year_id = p.year_id AND kt." + fCbo1KeyField + " = p." + fStartCbo1 + "_id ";
            //tJoin += "LEFT OUTER JOIN " + fTableCbo2 + " u ON kt.grp_id = u.grp_id AND kt.co_id = u.co_id AND kt.year_id = u.year_id AND kt." + fCbo2KeyField + " = u." + fStartCbo2 + "_id";

            tJoin = "LEFT OUTER JOIN " + fTableCbo1 + " u ON  kt." + fCbo1KeyField + " = u." + fStartCbo1 + "_id ";
            tJoin += "LEFT OUTER JOIN " + fTableCbo2 + " g ON  kt." + fCbo2KeyField + " = g." + fStartCbo2 + "_id";

            //tLookUpField = "kt.goodsitem_title, kt.goodsitem_st, kt.ordering, p.goodspacking_title, u.uom_title, kt.isdisabled";
            tLookUpField = "kt." + fStartName + "_title, kt." + fStartName + "_st, kt.ordering, u." + fStartCbo1 + "_title, g." + fStartCbo2 + "_title, kt.isdisabled";
            tLookUpTitle = "ID,Item Title,Short Title,Ordering,UOM Title,Group Title,Disabled";
            tLookUpTitleWidth = "10,20,10,6,15,15,8";
            // Concept of Replace
            //
            frmSDIcbo2Indp_Master SDIcbo2Ind_Item = new frmSDIcbo2Indp_Master(tMainParam, tBeginParam, tFLBegin, tFL, tFLEnd, tFLenBegin, tFLen, tFLenEnd, tFTBegin, tFT, tFTEnd, tValBegin, tVal, tValEnd, tTitleWidth, tTitleFormat, false, tJoin, tLookUpField, tLookUpTitle, tLookUpTitleWidth);
            SDIcbo2Ind_Item.MdiParent = this;
            SDIcbo2Ind_Item.Show();
        }

        private void stockItemWiseConversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemConv frm = new frmItemConv();
            frm.MdiParent = this;
            frm.Show();
        }

        private void issueToProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFtoF frm = new frmFtoF();
            frm.MdiParent = this;
            frm.Show();
        }

        private void contractLabourChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmContLabourChrg frm = new frmContLabourChrg();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void cashReceiptVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCRVoc frm = new frmCRVoc();
            frm.MdiParent = this;
            frm.Show();

        }

        private void cashPaymentVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCPVoc frm = new frmCPVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bankPaymentVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBPVoc frm = new frmBPVoc(); 
            frm.MdiParent = this;
            frm.Show();

        }

        private void bankReceiptVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBRVoc frm = new frmBRVoc();
            frm.MdiParent = this;
            frm.Show();

        }

        private void ledgerAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLedger frm = new frmLedger();
            frm.MdiParent = this;
            frm.Show();
        }

        private void accountCodeDefinationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1- FormID
            // 2- Form Title
            // 3- Table Name
            // 4- Key Field
            // 5- Parent ID Field
            // 6- keyfield String
            string tMainParam = clsGVar.cnstFormPrivileges_GLCOA.ToString() + ",GL COA,gl_ac,ac_id,ac_pid,ac_strid";
            frmGLCOA sGLCOA = new frmGLCOA(tMainParam);
            //frmGLAcID sGLCOA = new frmGLAcID(tMainParam);
            sGLCOA.MdiParent = this;
            sGLCOA.Show();

        }

        private void uOMDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUOMID();
        }
        private void frmUOMID()
        {
            string tMainParam = string.Empty;
            string tBeginParam = string.Empty;

            string tFLBegin = string.Empty;
            string tFL = string.Empty;
            string tFLEnd = string.Empty;

            //
            string tFLenBegin = string.Empty;
            string tFLen = string.Empty;
            string tFLenEnd = string.Empty;
            //
            string tFTBegin = string.Empty;
            string tFT = string.Empty;
            string tFTEnd = string.Empty;
            //
            string tValBegin = string.Empty;
            string tVal = string.Empty;
            string tValEnd = string.Empty;
            //
            string tTitleWidth = string.Empty;
            string tTitleFormat = string.Empty;
            // FormID, Title, Table, KeyField, KeyFieldType,
            tMainParam = "1005,UOM ID,gds_uom,goodsuom_id,int16,0";
            //
            //tBeginParam = clsGVar.LocID.ToString();
            //tBeginParam += "," + clsGVar.GrpID.ToString();
            //tBeginParam += "," + clsGVar.CoID.ToString();
            //tBeginParam += "," + clsGVar.YrID.ToString();
            //
            //tFLBegin = "loc_id,grp_id,co_id,year_id";   //"group_id,company_id,year_id"; 
            tFL = "goodsuom_title,goodsuom_st,ordering,isdisabled";
            tFLEnd = "isdefault,frm_id";
            //
            tFLenBegin = "0,0,0";
            tFLen = "4,20,6,4";
            tFLenEnd = "0,0";
            //
            //tFTBegin = "Group ID,Company ID,Year ID";
            tFT = "ID,UOM Title,Short Title,Ordering,Is Disabled";
            tFTEnd = "Is Default";
            //
            tValBegin = "0,0,0,0";
            tVal = "R,R,R,R";
            tValEnd = "0";
            //
            tTitleWidth = "10,30,10,10,10";
            tTitleFormat = "N,T,T,T,T";
            //
            frmSDI_Master SDI_UOM = new frmSDI_Master(tMainParam, tBeginParam, tFLBegin, tFL, tFLEnd, tFLenBegin, tFLen, tFLenEnd, tFTBegin, tFT, tFTEnd, tValBegin, tVal, tValEnd, tTitleWidth, tTitleFormat);
            SDI_UOM.MdiParent = this;
            SDI_UOM.Show();
        }

        private void godownDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGodown();
        }
        private void frmGodown()
        {
            string tMainParam = "1111,Godown ID,cmn_Godown,Godown_id,int16,0";
            string tFieldList = "Godown_title,Godown_st,Godown_ac_id,ordering,isdisabled,isdefault,created_by,modified_by,created_date,modified_date";
            string tFieldLength = "4,30,6,14,3";
            string tFieldTitle = "ID,Godown Title,Short,GL ID,Ordering";
            string tValidationRule = "R,R,R,R,R";
            string tTitleWidth = "4,30,6,14,3";
            string tFieldFormat = "N,T,T,T,T";

            frmGodown SDI_Godown = new frmGodown(
              tMainParam,
              tFieldList,
              tFieldLength,
              tFieldTitle,
              tValidationRule,
              tTitleWidth,
              tFieldFormat
              );
            SDI_Godown.MdiParent = this;
            SDI_Godown.Show();

            //string tMainParam = string.Empty;
            //string tBeginParam = string.Empty;

            //string tFLBegin = string.Empty;
            //string tFL = string.Empty;
            //string tFLEnd = string.Empty;

            ////
            //string tFLenBegin = string.Empty;
            //string tFLen = string.Empty;
            //string tFLenEnd = string.Empty;
            ////
            //string tFTBegin = string.Empty;
            //string tFT = string.Empty;
            //string tFTEnd = string.Empty;
            ////
            //string tValBegin = string.Empty;
            //string tVal = string.Empty;
            //string tValEnd = string.Empty;
            ////
            //string tTitleWidth = string.Empty;
            //string tTitleFormat = string.Empty;
            //// FormID, Title, Table, KeyField, KeyFieldType,
            //tMainParam = "1007,Godown ID,cmn_Godown,Godown_id,int16,0";
            ////
            ////tBeginParam = clsGVar.LocID.ToString();
            ////tBeginParam += "," + clsGVar.GrpID.ToString();
            ////tBeginParam += "," + clsGVar.CoID.ToString();
            ////tBeginParam += "," + clsGVar.YrID.ToString();
            ////
            ////tFLBegin = "loc_id,grp_id,co_id,year_id";   //"group_id,company_id,year_id"; 
            //tFL = "Godown_title,Godown_st,ordering,isdisabled";
            //tFLEnd = "isdefault,frm_id";
            ////
            //tFLenBegin = "0,0,0";
            //tFLen = "4,20,6,4";
            //tFLenEnd = "0,0";
            ////
            ////tFTBegin = "Group ID,Company ID,Year ID";
            //tFT = "ID,Godown Title,Short Title,Ordering,Is Disabled";
            //tFTEnd = "Is Default";
            ////
            //tValBegin = "0,0,0,0";
            //tVal = "R,R,R,R";
            //tValEnd = "0";
            ////
            //tTitleWidth = "10,30,10,10,10";
            //tTitleFormat = "N,T,T,T,T";
            ////
            //frmSDI_Master SDI_Godown = new frmSDI_Master(tMainParam, tBeginParam, tFLBegin, tFL, tFLEnd, tFLenBegin, tFLen, tFLenEnd, tFTBegin, tFT, tFTEnd, tValBegin, tVal, tValEnd, tTitleWidth, tTitleFormat);
            //SDI_Godown.MdiParent = this;
            //SDI_Godown.Show();
        }

        private void transportDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransport();
        }
        private void frmTransport()
        {
            string tMainParam = string.Empty;
            string tBeginParam = string.Empty;

            string tFLBegin = string.Empty;
            string tFL = string.Empty;
            string tFLEnd = string.Empty;

            //
            string tFLenBegin = string.Empty;
            string tFLen = string.Empty;
            string tFLenEnd = string.Empty;
            //
            string tFTBegin = string.Empty;
            string tFT = string.Empty;
            string tFTEnd = string.Empty;
            //
            string tValBegin = string.Empty;
            string tVal = string.Empty;
            string tValEnd = string.Empty;
            //
            string tTitleWidth = string.Empty;
            string tTitleFormat = string.Empty;
            // FormID, Title, Table, KeyField, KeyFieldType,
            tMainParam = "1007,Transport ID,cmn_Transport,Transport_id,int16,0";
            //
            //tBeginParam = clsGVar.LocID.ToString();
            //tBeginParam += "," + clsGVar.GrpID.ToString();
            //tBeginParam += "," + clsGVar.CoID.ToString();
            //tBeginParam += "," + clsGVar.YrID.ToString();
            //
            //tFLBegin = "loc_id,grp_id,co_id,year_id";   //"group_id,company_id,year_id"; 
            tFL = "Transport_title,Transport_st,ordering,isdisabled";
            tFLEnd = "isdefault,frm_id";
            //
            tFLenBegin = "0,0,0";
            tFLen = "4,20,6,4";
            tFLenEnd = "0,0";
            //
            //tFTBegin = "Group ID,Company ID,Year ID";
            tFT = "ID,Transport Title,Short Title,Ordering,Is Disabled";
            tFTEnd = "Is Default";
            //
            tValBegin = "0,0,0,0";
            tVal = "R,R,R,R";
            tValEnd = "0";
            //
            tTitleWidth = "10,30,10,10,10";
            tTitleFormat = "N,T,T,T,T";
            //
            frmSDI_Master SDI_Transport = new frmSDI_Master(tMainParam, tBeginParam, tFLBegin, tFL, tFLEnd, tFLenBegin, tFLen, tFLenEnd, tFTBegin, tFT, tFTEnd, tValBegin, tVal, tValEnd, tTitleWidth, tTitleFormat);
            SDI_Transport.MdiParent = this;
            SDI_Transport.Show();
        }

        private void cityDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCityID();
        }
        private void frmCityID()
        {
            string tMainParam = string.Empty;
            string tBeginParam = string.Empty;

            string tFLBegin = string.Empty;
            string tFL = string.Empty;
            string tFLEnd = string.Empty;

            //
            string tFLenBegin = string.Empty;
            string tFLen = string.Empty;
            string tFLenEnd = string.Empty;
            //
            string tFTBegin = string.Empty;
            string tFT = string.Empty;
            string tFTEnd = string.Empty;
            //
            string tValBegin = string.Empty;
            string tVal = string.Empty;
            string tValEnd = string.Empty;
            //
            string tTitleWidth = string.Empty;
            string tTitleFormat = string.Empty;
            string tJoin = string.Empty;
            string tReplaceable = string.Empty;
            // FormID, Title, Table, KeyField, Address, KeyFieldType,0,PTable, pfield, PPTable, PPkeyfield
            // FormID,
            // Title, 
            // Table, 
            // KeyField, 
            // Address, 0,1 
            // KeyFieldType,                Field Type Int16, Int32, Int64
            // PTable,                      Parent Table Name
            // pfield,                      Parent field Name
            // pfieldPid,                   Parent field Name Pid
            // PPTable,                     GP Table Name
            // PPkeyfield,                  GP Field Name

            tMainParam = "1006,City ID,geo_city,city_id,int16,0,geo_province,province_id,province_pid,geo_country,country_id";
            tBeginParam = clsGVar.LocID.ToString() + ",0,0,0";               //loc_id,grp_id,co_id,year_id

            // "INNER JOIN country p ON c.province_pid = p.country_id"
            tFLBegin = "loc_id,grp_id,co_id,year_id";   //"group_id,company_id,year_id"; 
            tFL = "city_title,city_st,ordering,city_pid,isdisabled";
            tFLEnd = "isdefault,frm_id";
            //
            tFLenBegin = "0,0,0";
            tFLen = "4,20,6,4";
            tFLenEnd = "0,0";
            //
            tFTBegin = "Group ID,Company ID,Year ID";
            tFT = "ID,City Title,Short Title,Ordering,Parent ID,Disabled";
            tFTEnd = "Default";
            //
            tValBegin = "0,0,0,0";
            tVal = "R,R,R,R,R";
            tValEnd = "0";
            //
            tTitleWidth = "10,20,10,10,10,10";
            tTitleFormat = "N,T,T,T,T,T";
            tJoin = "INNER JOIN geo_province p ON kt.city_pid = p.province_id";
            tReplaceable = "city_pid,province_title,Parent ID,Province Title";
            //
            // Replace city_pid with Parent ID
            // Replace privince_title with Province Title
            // This procedure is use for lookup purposes only
            // It has nothing to do with Validating or select, insert, update or delete queries.
            // 
            //   

            frmSDIcbo2_Master SDIcbo2_City = new frmSDIcbo2_Master(tMainParam, tBeginParam, tFLBegin, tFL, tFLEnd, tFLenBegin, tFLen, tFLenEnd, tFTBegin, tFT, tFTEnd, tValBegin, tVal, tValEnd, tTitleWidth, tTitleFormat, false, tJoin, tReplaceable);
            SDIcbo2_City.MdiParent = this;
            SDIcbo2_City.Show();
        }

        private void mCountryId()
        {
            string tMainParam = string.Empty;
            string tBeginParam = string.Empty;
            //
            string tFLBegin = string.Empty;
            string tFL = string.Empty;
            string tFLEnd = string.Empty;

            //
            string tFLenBegin = string.Empty;
            string tFLen = string.Empty;
            string tFLenEnd = string.Empty;
            //
            string tFTBegin = string.Empty;
            string tFT = string.Empty;
            string tFTEnd = string.Empty;
            //
            string tValBegin = string.Empty;
            string tVal = string.Empty;
            string tValEnd = string.Empty;
            //
            string tTitleWidth = string.Empty;
            string tTitleFormat = string.Empty;
            // FormID, Title, Table, KeyField, KeyFieldType, AddressFlage
            tMainParam = "903101,Country ID,geo_country,country_id,int16,0";
            tBeginParam = clsGVar.LocID.ToString() + ",0,0,0";               //loc_id,grp_id,co_id,year_id
            //
            //tFLBegin = "loc_id,grp_id,co_id,year_id";   //"group_id,company_id,year_id"; 
            tFL = "country_title,country_st,ordering,isdisabled";
            tFLEnd = "isdefault,frm_id";
            //
            tFLenBegin = "0,0,0";
            tFLen = "4,25,6,0";
            tFLenEnd = "0,0";
            //
            //tFTBegin = "Group ID,Company ID,Year ID";
            tFT = "ID,Country Title,Short Title,Ordering,Is Disabled";
            tFTEnd = "Is Default";
            //
            tValBegin = "0,0,0,0";
            tVal = "R,R,R,R";
            tValEnd = "0";
            //
            tTitleWidth = "10,20,10,10,10";
            tTitleFormat = "N,T,T,T,T";
            //
            frmSDI_Master SDI_Country = new frmSDI_Master(tMainParam, tBeginParam, tFLBegin, tFL, tFLEnd, tFLenBegin, tFLen, tFLenEnd, tFTBegin, tFT, tFTEnd, tValBegin, tVal, tValEnd, tTitleWidth, tTitleFormat);
            SDI_Country.MdiParent = this;
            SDI_Country.Show();
        } //  End Country

        // Start Province
        private void mProvinceId()
        {
            // FormID, Title, Table, KeyField, Address, ,0,PTable,Pkeyfield
            //  0- FormID, 
            //  1- Title, 
            //  2- Table, 
            //  3- KeyField, 
            //  4- KeyFieldType, 
            //  5- AddressFlage,
            //  6- KeyFieldType int16, int32 etc
            //  7- Parent Table
            //  8- Parent Table KeyField
            //  9- Combo Name for Tooltip  
            //  + clsStrF01.ToUcFirst(fStartName) + " ID," + fStartName + "," + fStartName + 
            string fStartName = "province";           // There is no need of geo or mkt it is covered bellow
            string fStartNameParent = "country";      // There is no need of geo or mkt it is covered bellow
            //tMainParam = "1006," + clsStrF01.ToUcFirst(fStartName) + " ID, geo_" + fStartName + "," + fStartName + "_id,int16,0";
            //tMainParam += ",geo_country,country_id,Country Name"; 
            string tMainParam = "903102," + StrF01.ToUcFirst(fStartName) + " ID, geo_" + fStartName + "," + fStartName + "_id,int16,0";
            tMainParam += ",geo_" + fStartNameParent + "," + fStartNameParent + "_id," + StrF01.ToUcFirst(fStartNameParent) + " Name";
            //
            string tBeginParam = string.Empty;
            //string tBeginParam = clsGVar.LGCYValues.ToString();     // Loc, Group, Co, Year Comma seperated list as string
            //
            // "INNER JOIN country p ON c.province_pid = p.country_id"
            string tFLBegin = string.Empty;
            //string tFLBegin = "loc_id,grp_id,co_id,year_id";   //"group_id,company_id,year_id"; 
            string tFL = fStartName + "_title," + fStartName + "_st,ordering," + fStartName + "_pid,isdisabled";
            string tFLEnd = "isdefault,frm_id";

            //
            string tFLenBegin = "0,0,0";
            string tFLen = "4,30,8,4";
            string tFLenEnd = "0,0";
            //
            string tFTBegin = string.Empty; // "Group ID,Company ID,Year ID";
            string tFT = "ID," + StrF01.ToUcFirst(fStartName) + " Title,Short Title,Ordering,Parent ID,Disabled";
            string tFTEnd = "Default";
            //
            string tValBegin = "0,0,0,0";
            string tVal = "R,R,R,R,R";
            string tValEnd = "0";
            //
            string tTitleWidth = "10,20,10,10,10,10";
            string tTitleFormat = "N,T,T,T,T,T";
            //tJoin = "INNER JOIN geo_country p ON kt.province_pid = p.country_id";
            //tReplaceable = "province_pid,country_title,Parent ID,Country Title";
            string tJoin = "INNER JOIN geo_" + fStartNameParent + " p ON kt." + fStartName + "_pid = p." + fStartNameParent + "_id";
            string tReplaceable = fStartName + "_pid," + fStartNameParent + "_title,Parent ID," + StrF01.ToUcFirst(fStartNameParent) + " Title";
            //
            List<string> tDependentTables = new List<string>();
            // 1-Title of Dependency (Form/Table Name)
            // 2-Table Name
            // 3-Field Name
            // 4-field Type (N=Numeric or S=string)
            // 
            //tDependentTables.Add("Address ID,cmn_address,addr_city_id,N");
            //tDependentTables.Add("Tehsil ID,geo_tehsil,tehsil_pid,N");
            //tDependentTables.Add("Town ID,geo_town,town_pid,N");
            //
            frmSDIcbo1_Master SDIcbo1_Province = new frmSDIcbo1_Master(tMainParam, tBeginParam, tFLBegin, tFL, tFLEnd, tFLenBegin, tFLen, tFLenEnd, tFTBegin, tFT, tFTEnd, tValBegin, tVal, tValEnd, tTitleWidth, tTitleFormat, tDependentTables, false, tJoin, tReplaceable);
            SDIcbo1_Province.MdiParent = this;
            SDIcbo1_Province.Show();
        } //  End Province
        // Region ID 

        private void mRegionId()
        {
            //  0- FormID, 
            //  1- Title, 
            //  2- Table, 
            //  3- KeyField, 
            //  4- KeyFieldType, 
            //  5- AddressFlage,
            string fStartName = "Region";
            string tMainParam = "903103," + StrF01.ToUcFirst(fStartName) + " ID," + "geo_" + fStartName + "," + fStartName + "_id,int16,0";
            string tBeginParam = clsGVar.LocID.ToString() + ",0,0,0";               //loc_id,grp_id,co_id,year_id      
            //
            string tFLBegin = string.Empty; // "loc_id,grp_id,co_id,year_id";   //"loc_id,group_id,company_id,year_id"; 
            string tFL = fStartName + "_title," + fStartName + "_st,ordering,isdisabled";
            string tFLEnd = "isdefault,frm_id";
            //
            string tFLenBegin = "0,0,0,0";
            string tFLen = "4,40,6,4,4";     // 0 = not applicable or unlimited (MaxLength)
            string tFLenEnd = "0,0";
            //
            string tFTBegin = string.Empty; // "Loc. ID,Group ID,Company ID,Year ID";
            string tFT = StrF01.ToUcFirst(fStartName) + " ID," + StrF01.ToUcFirst(fStartName) + " Title,Short Title,Ordering,Is Disabled";
            string tFTEnd = "Is Default";
            //
            string tValBegin = "0,0,0,0";         //
            string tVal = "R,R,R,R";                                         // R = Required,  0 = Not Required
            string tValEnd = "0";
            //
            string tTitleWidth = "10,20,10,10,10";   // Column width
            string tTitleFormat = "TI,T,T,T,T";      // TI = Text Integer
            //
            frmSDI_Master SDI_Region = new frmSDI_Master(tMainParam, tBeginParam, tFLBegin, tFL, tFLEnd, tFLenBegin, tFLen, tFLenEnd, tFTBegin, tFT, tFTEnd, tValBegin, tVal, tValEnd, tTitleWidth, tTitleFormat);
            SDI_Region.MdiParent = this;
            SDI_Region.Show();
        } // Region

        private void mTerritoryId()
        {
            string tMainParam = string.Empty;
            string tBeginParam = string.Empty;

            string tFLBegin = string.Empty;
            string tFL = string.Empty;
            string tFLEnd = string.Empty;

            //
            string tFLenBegin = string.Empty;
            string tFLen = string.Empty;
            string tFLenEnd = string.Empty;
            //
            string tFTBegin = string.Empty;
            string tFT = string.Empty;
            string tFTEnd = string.Empty;
            //
            string tValBegin = string.Empty;
            string tVal = string.Empty;
            string tValEnd = string.Empty;
            //
            string tTitleWidth = string.Empty;
            string tTitleFormat = string.Empty;
            string tJoin = string.Empty;
            string tReplaceable = string.Empty;
            // FormID, Title, Table, KeyField, Address, ,0,PTable,Pkeyfield
            //  0- FormID, 
            //  1- Title, 
            //  2- Table, 
            //  3- KeyField, 
            //  4- KeyFieldType, 
            //  5- AddressFlage,
            //  6- KeyFieldType int16, int32 etc
            //  7- Parent Table
            //  8- Parent Table KeyField
            //  9- Combo Name for Tooltip  
            //  + clsStrF01.ToUcFirst(fStartName) + " ID," + fStartName + "," + fStartName + 
            string fStartName = "territory";
            string fStartNameParent = "region";
            //tMainParam = "1006," + clsStrF01.ToUcFirst(fStartName) + " ID, geo_" + fStartName + "," + fStartName + "_id,int16,0";
            //tMainParam += ",geo_country,country_id,Country Name"; 
            tMainParam = "903104," + StrF01.ToUcFirst(fStartName) + " ID, geo_" + fStartName + "," + fStartName + "_id,int16,0";
            tMainParam += ",geo_" + fStartNameParent + "," + fStartNameParent + "_id," + StrF01.ToUcFirst(fStartNameParent) + " Name";
            tBeginParam = clsGVar.LocID.ToString() + ",0,0,0";               //loc_id,grp_id,co_id,year_id

            // "INNER JOIN country p ON c.province_pid = p.country_id"
            //tFLBegin = "loc_id,grp_id,co_id,year_id";   //"group_id,company_id,year_id"; 
            tFL = fStartName + "_title," + fStartName + "_st,ordering," + fStartName + "_pid,isdisabled";
            tFLEnd = "isdefault,frm_id";

            //
            tFLenBegin = "0,0,0";
            tFLen = "4,30,8,4";
            tFLenEnd = "0,0";
            //
            //tFTBegin = "Group ID,Company ID,Year ID";
            tFT = "ID," + StrF01.ToUcFirst(fStartName) + " Title,Short Title,Ordering,Parent ID,Disabled";
            tFTEnd = "Default";
            //
            tValBegin = "0,0,0,0";
            tVal = "R,R,R,R,R";
            tValEnd = "0";
            //
            tTitleWidth = "10,20,10,10,10,10";
            tTitleFormat = "N,T,T,T,T,T";
            //tJoin = "INNER JOIN geo_country p ON kt.province_pid = p.country_id";
            //tReplaceable = "province_pid,country_title,Parent ID,Country Title";
            tJoin = "INNER JOIN geo_" + fStartNameParent + " p ON kt." + fStartName + "_pid = p." + fStartNameParent + "_id";
            tReplaceable = fStartName + "_pid," + fStartNameParent + "_title,Parent ID," + StrF01.ToUcFirst(fStartNameParent) + " Title";
            //
            List<string> tDependentTables = new List<string>();
            // 1-Title of Dependency (Form/Table Name)
            // 2-Table Name
            // 3-Field Name
            // 4-field Type (N=Numeric or S=string)
            // 
            //tDependentTables.Add("Address ID,cmn_address,addr_city_id,N");
            //tDependentTables.Add("Tehsil ID,geo_tehsil,tehsil_pid,N");
            //tDependentTables.Add("Town ID,geo_town,town_pid,N");
            //
            frmSDIcbo1_Master SDIcbo1_Province = new frmSDIcbo1_Master(tMainParam, tBeginParam, tFLBegin, tFL, tFLEnd, tFLenBegin, tFLen, tFLenEnd, tFTBegin, tFT, tFTEnd, tValBegin, tVal, tValEnd, tTitleWidth, tTitleFormat, tDependentTables, false, tJoin, tReplaceable);
            SDIcbo1_Province.MdiParent = this;
            SDIcbo1_Province.Show();
        } //  End Territory

        private void itemTransationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemLedger frm = new frmItemLedger();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dailyVoucherEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDailyVoc frm = new frmDailyVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void itemOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemOp frm = new frmItemOp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void contractTransactionNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContractNew frm = new frmContractNew();
            frm.MdiParent = this;
            frm.Show();

        }

        private void factoryToFactoryImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueToProd frm = new frmIssueToProd();
            frm.MdiParent = this;
            frm.Show();
        }

        private void contractLabourChargesNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmContLabourChg frm = new frmContLabourChg();
            frmContLabChg frm = new frmContLabChg();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            frmGRNCs frm = new frmGRNCs();
            frm.MdiParent = this;
            //frm.BringToFront = true;
            frm.Show();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            frmCashInvoice frm = new frmCashInvoice();
            frm.MdiParent = this;
            //frm.BringToFront = true;
            frm.Show();
        }

        private void creditSaleTransactionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmInvoiceShop frm = new frmInvoiceShop();
            frm.MdiParent = this;
            //frm.BringToFront = true;
            frm.Show();
        }

        private void toolStripMenuItem21_Click_1(object sender, EventArgs e)
        {
            //frmGRN frm = new frmGRN();
            frmGRNCrShop frm = new frmGRNCrShop();
            frm.MdiParent = this;
            //frm.BringToFront = true;
            frm.Show();
        }

        private void factoryToShopShopToFactoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFtoS frm = new frmFtoS();
            frm.MdiParent = this;
            frm.Show();

        }

        private void itemLedgerShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemLedgerShop frm = new frmItemLedgerShop();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manufacturerClosingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin lgn = new frmLogin();
            lgn.Login = string.Empty;
            lgn.ShowDialog();

            if (lgn.Login != string.Empty)
            {
                frmMfgClose frm = new frmMfgClose();
                frm.MdiParent = this;
                frm.Show();
                lgn.Login = string.Empty;
            }
        }

        private void periodWiseGroupAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeriodGroup frm = new frmPeriodGroup();
            frm.MdiParent = this;
            frm.Show();
        }

        private void teritoryDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mTerritoryId();
        }

        private void provinceDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mProvinceId();
        }

        private void countryDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCountryId();
        }

        private void regionDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mRegionId();
        }

        private void salePointReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptSalePoint frm = new rptSalePoint();
            frm.MdiParent = this;
            frm.Show();
        }

        private void chartOfAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChartofAccount frm = new frmChartofAccount();
            frm.MdiParent=this;
            frm.Show();
        }

        private void customerAnalysisReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptItemLedgCust frm = new rptItemLedgCust();
            frm.MdiParent = this;
            frm.Show();
        }

         private void extraChargesVoucherJVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXJournalVoc frm = new frmXJournalVoc();
            frm.MdiParent = this;
            frm.Show();
        }

         private void millClosingToolStripMenuItem_Click(object sender, EventArgs e)
         {
            frmLogin lgn = new frmLogin();
            lgn.Login = string.Empty;
            lgn.ShowDialog();

            if (lgn.Login != string.Empty)
            {
                frmMillClose frm = new frmMillClose();
                frm.MdiParent = this;
                frm.Show();
                lgn.Login = string.Empty;
            }
         }

         private void trialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
         {
             //foreach (Form lActiveForm in this.MdiChildren)
             //{
             //    if (lActiveForm.GetType() == typeof(frmViewLedgerAc))
             //    {
             //        lActiveForm.Focus();
             //        return;
             //    }
             //}
             //string tFormTitle = "This is form Title";
             //bool tInputCbo = true;
             //bool tInputDate = true;
             //bool tInputId = true;
             //string tIdType = "GL";       // "INV_FIN", "INV_RM" etc
             //bool tInputOptions = true;
             //string tInputOptionList = string.Empty;
             //bool tInputSorting = false;
             //bool tIsStoredProcedure = true;
             ////
             //frmPrintDlgGLCoA01 ViewTrial01 = new frmPrintDlgGLCoA01(
             //  tFormTitle,
             //  tInputCbo,
             //  tInputDate,
             //  tInputId,
             //  tIdType,
             //  tInputOptions,
             //  tInputOptionList,
             //  tInputSorting,
             //  tIsStoredProcedure
             //  );
             //ViewTrial01.MdiParent = this;
             //ViewTrial01.Show();
             frmTrialBal frm = new frmTrialBal();
             frm.MdiParent = this;
             frm.Show();
         }

         private void agingReportToolStripMenuItem_Click(object sender, EventArgs e)
         {
             frmAging frm = new frmAging();
             frm.MdiParent = this;
             frm.Show();
         }

         private void expensesComparisonToolStripMenuItem_Click(object sender, EventArgs e)
         {
             frmExpenseComp frm = new frmExpenseComp();
             frm.MdiParent = this;
             frm.Show();
         }

         private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
         {
             frmBackupDataOLD frm = new frmBackupDataOLD();
             frm.MdiParent = this;
             frm.Show();
         }

         private void detailedPrintingToolStripMenuItem_Click(object sender, EventArgs e)
         {
             frmDetailsPrinting frm = new frmDetailsPrinting();
             frm.MdiParent = this;
             frm.Show();
         }

 
    }
}
