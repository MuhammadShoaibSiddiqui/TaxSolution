using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaxSolution.StringFun01;

using TaxSolution.PrintDataSets;
using TaxSolution.PrintReport;
using TaxSolution.PrintViewer;

namespace TaxSolution
{
    enum grdItmS
    {
        doc_date, 
        Doc_StrID, 
        NARRATION, 
        Godown, 
        Rate, 
        Qty_In,
        Qty_Out, 
        Balance, 
        UOM, 
        MeshTotal, 
        Bundle, 
        Length, 
        LenDec,
        Width, 
        WidDec, 
        SERIAL_NO
    }
    public partial class frmItemLedgerShop : Form
    {
        public frmItemLedgerShop()
        {
            InitializeComponent();

        }

        private void mCalendarMain_DateChanged(object sender, DateRangeEventArgs e)
        {
            msk_FromDate.Text = mCalendarMain.SelectionStart.ToString();
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            LoadGridData();
            SumLedger();
            
        }

        private void SumLedger()
        {
            decimal colQtyIn = 0;
            decimal colQtyOut = 0;
            decimal colBalance = 0;
            //if (clsDbManager.ConvDecimal(lblOpBal.Text) > 0)
            //{
            //    colBalance = clsDbManager.ConvDecimal(lblOpBal.Text);
            //}

            for (int i = 0; i < grdDetail.Rows.Count; i++)
            {
                colQtyIn += clsDbManager.ConvDecimal(grdDetail.Rows[i].Cells[(int)grdItmS.Qty_In].Value.ToString());
                colQtyOut += clsDbManager.ConvDecimal(grdDetail.Rows[i].Cells[(int)grdItmS.Qty_Out].Value.ToString());
                //colBalance += colQtyIn - colQtyOut;
                grdDetail.Rows[i].Cells[(int)grdItmS.Balance].Value = colQtyIn - colQtyOut; ;
                //grdDetail.Rows[i].Cells[(int)grdItm.Balance].Value = colBalance + colQtyIn - colQtyOut; ;
                //dGvDetail.Rows[e.RowIndex].Cells[(int)GCol.debit].Value = string.Empty;     // Set Debit value to empty
            }
            lblTotalDebit.Text = colQtyIn.ToString("0.00");
            lblTotalCredit.Text = colQtyOut.ToString("0.00");
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            string fRptTitle = this.Text;
            string plstField = string.Empty;
            string plstType = string.Empty;
            string plstValue = string.Empty;

            if (OptItemLedger.Checked == true)
            {
                plstField = "@pDoc_Fiscal_ID,@pItem_ID,@pFromDate,@pToDate,@pUOMID,@pGodown";
                plstType = "8,8,18,18,8,8"; // {   "8, 8, 8, 8, 8, 8" };
                plstValue = "1," + this.msk_ItemID.Tag + "," + StrF01.D2Str(this.msk_FromDate) + "," +
                    StrF01.D2Str(this.msk_ToDate) + "," + cbo_UOM.SelectedValue.ToString()
                     + ",1";
                //plstValue = "1," + this.msk_ItemID.Tag + "," + StrF01.D2Str(this.msk_FromDate) + "," +
                //    StrF01.D2Str(this.msk_ToDate) + "," + cbo_UOM.SelectedValue.ToString()
                //     + "," + cboGodown.SelectedValue.ToString();

                dsItemLedger ds = new dsItemLedger();

                CrItemLedger rpt1 = new CrItemLedger();

                frmPrintViewer rptLedger = new frmPrintViewer(
                    fRptTitle,
                    this.msk_FromDate.Text,
                    this.msk_ToDate.Text,
                    "sp_Item_Ledger",
                    plstField,
                    plstType,
                    plstValue,
                    ds,
                    rpt1,
                    "SP"
                    );
                rptLedger.Show();
            }

            if (OptItemLedgerShopItem.Checked == true)
            {
                plstField = "@pDoc_Fiscal_ID,@pItem_ID,@pFromDate,@pToDate,@pUOMID,@pGodown";
                plstType = "8,8,18,18,8,8"; // {   "8, 8, 8, 8, 8, 8" };
                plstValue = "1," + this.msk_ItemID.Tag + "," + StrF01.D2Str(this.msk_FromDate) + "," +
                    StrF01.D2Str(this.msk_ToDate) + "," + cbo_UOM.SelectedValue.ToString()
                     + "," + cboGodown.SelectedValue.ToString();
                //plstValue = "1," + this.msk_ItemID.Tag + "," + StrF01.D2Str(this.msk_FromDate) + "," +
                //    StrF01.D2Str(this.msk_ToDate) + "," + cbo_UOM.SelectedValue.ToString()
                //     + "," + cboGodown.SelectedValue.ToString();

                dsItemLedger ds = new dsItemLedger();

                CrItemLedgerShop rpt1 = new CrItemLedgerShop();

                frmPrintViewer rptLedger = new frmPrintViewer(
                    fRptTitle,
                    this.msk_FromDate.Text,
                    this.msk_ToDate.Text,
                    "sp_ItemUnitLedGodItem",
                    plstField,
                    plstType,
                    plstValue,
                    ds,
                    rpt1,
                    "SP"
                    );
                rptLedger.Show();
            }

            if (OptGeneralItemLedger.Checked == true)
            {
                plstField = "@pDoc_Fiscal_ID,@pItem_ID,@pFromDate,@pToDate,@pUOMID,@pGodown";
                plstType = "8,8,18,18,8,8"; // {   "8, 8, 8, 8, 8, 8" };
                plstValue = "1," + this.msk_ItemID.Tag + "," + StrF01.D2Str(this.msk_FromDate) + "," +
                    StrF01.D2Str(this.msk_ToDate) + "," + cbo_UOM.SelectedValue.ToString()
                     + "," + cboGodown.SelectedValue.ToString();
                //plstValue = "1," + this.msk_ItemID.Tag + "," + StrF01.D2Str(this.msk_FromDate) + "," +
                //    StrF01.D2Str(this.msk_ToDate) + "," + cbo_UOM.SelectedValue.ToString()
                //     + "," + cboGodown.SelectedValue.ToString();

                dsItemLedger ds = new dsItemLedger();

                CrItemLedgerShop rpt1 = new CrItemLedgerShop();

                frmPrintViewer rptLedger = new frmPrintViewer(
                    fRptTitle,
                    this.msk_FromDate.Text,
                    this.msk_ToDate.Text,
                    "sp_ItemUnitLedGodItem",
                    plstField,
                    plstType,
                    plstValue,
                    ds,
                    rpt1,
                    "SP"
                    );
                rptLedger.Show();
            }
            //if (OptStock.Checked == true)
            //{
            //    plstField = "@pDoc_Fiscal_ID,@pFromDate,@pToDate,@pGodown";
            //    plstType = "8,18,18,8"; // {   "8, 8, 8, 8, 8, 8" };
            //    plstValue = "1," +  StrF01.D2Str(this.msk_FromDate) + "," +
            //        StrF01.D2Str(this.msk_ToDate) + "," + cboGodown.SelectedValue.ToString();
            //    dsItemLedger ds = new dsItemLedger();
            //    CrItemStock rpt1 = new CrItemStock();
            //    frmPrintViewer rptLedger = new frmPrintViewer(
            //       fRptTitle,
            //       this.msk_FromDate.Text,
            //       this.msk_ToDate.Text,
            //       "sp_Item_Stock",
            //       plstField,
            //       plstType,
            //       plstValue,
            //       ds,
            //       rpt1,
            //       "SP"
            //       );
            //    rptLedger.Show();
            //}

            //if (OptStockDtl.Checked == true)
            //{
            //    plstField = "@pDoc_Fiscal_ID,@pFromDate,@pToDate,@pGodown";
            //    plstType = "8,18,18,8"; // {   "8, 8, 8, 8, 8, 8" };
            //    plstValue = "1," + StrF01.D2Str(this.msk_FromDate) + "," +
            //        StrF01.D2Str(this.msk_ToDate) + "," + cboGodown.SelectedValue.ToString();
            //    dsItemLedger ds = new dsItemLedger();
            //    CrItemStockDtl rpt1 = new CrItemStockDtl();
            //    frmPrintViewer rptLedger = new frmPrintViewer(
            //       fRptTitle,
            //       this.msk_FromDate.Text,
            //       this.msk_ToDate.Text,
            //       "sp_Item_StockDtl",
            //       plstField,
            //       plstType,
            //       plstValue,
            //       ds,
            //       rpt1,
            //       "SP"
            //       );
            //    rptLedger.Show();
            //}

            //if (OptItemLedgerShop.Checked == true)
            //{
            //    plstField = "@pDoc_Fiscal_ID,@pFromDate,@pToDate,@pGodown";
            //    plstType = "8,18,18,8"; // {   "8, 8, 8, 8, 8, 8" };
            //    plstValue = "1," + StrF01.D2Str(this.msk_FromDate) + "," +
            //        StrF01.D2Str(this.msk_ToDate) + "," + cboGodown.SelectedValue.ToString();
            //    dsItemLedger ds = new dsItemLedger();
            //    CrItemStokLedger rpt1 = new CrItemStokLedger();
            //    frmPrintViewer rptLedger = new frmPrintViewer(
            //       fRptTitle,
            //       this.msk_FromDate.Text,
            //       this.msk_ToDate.Text,
            //       "sp_ItemUnitLedGod",
            //       plstField,
            //       plstType,
            //       plstValue,
            //       ds,
            //       rpt1,
            //       "SP"
            //       );
            //    rptLedger.Show();
            //}

            //if (OptUnitLedger.Checked == true)
            //{
            //    plstField = "@pDoc_Fiscal_ID,@pFromDate,@pToDate,@pGodown";
            //    plstType = "8,18,18,8"; // {   "8, 8, 8, 8, 8, 8" };
            //    plstValue = "1," + StrF01.D2Str(this.msk_FromDate) + "," +
            //        StrF01.D2Str(this.msk_ToDate) + "," + cboGodown.SelectedValue.ToString();
            //    dsItemLedger ds = new dsItemLedger();
            //    CrItemStokLedger rpt1 = new CrItemStokLedger();
            //    frmPrintViewer rptLedger = new frmPrintViewer(
            //       fRptTitle,
            //       this.msk_FromDate.Text,
            //       this.msk_ToDate.Text,
            //       "sp_ItemUnitLedger",
            //       plstField,
            //       plstType,
            //       plstValue,
            //       ds,
            //       rpt1,
            //       "SP"
            //       );
            //    rptLedger.Show();
            //}

            //if (optVocPrint.Checked == true)
            //{
            //    plstField = "@pDoc_Fiscal_ID,@pFromDate,@pToDate";
            //    plstType = "8,18,18"; // {   "8, 8, 8, 8, 8, 8" };
            //    plstValue = "1," + StrF01.D2Str(this.msk_FromDate) + "," +
            //        StrF01.D2Str(this.msk_ToDate);
            //    dsVocDaily ds = new dsVocDaily();
            //    CrVocDaily rpt1 = new CrVocDaily();
            //    frmPrintViewer rptLedger = new frmPrintViewer(
            //       "Day Book",
            //       this.msk_FromDate.Text,
            //       this.msk_ToDate.Text,
            //       "sp_Voc_Daily",
            //       plstField,
            //       plstType,
            //       plstValue,
            //       ds,
            //       rpt1,
            //       "SP"
            //       );
            //    rptLedger.Show();
            //}

            //if (optSalePoint.Checked == true)
            //{
            //    plstField = "@pDoc_Fiscal_ID,@pFromDate,@pToDate";
            //    plstType = "8,18,18"; // {   "8, 8, 8, 8, 8, 8" };
            //    plstValue = "1," + StrF01.D2Str(this.msk_FromDate) + "," +
            //        StrF01.D2Str(this.msk_ToDate);
            //    dsVocDaily ds = new dsVocDaily();
            //    CrReceiptSub rpt1 = new CrReceiptSub();
            //    frmPrintViewer rptLedger = new frmPrintViewer(
            //       "Receipt",
            //       this.msk_FromDate.Text,
            //       this.msk_ToDate.Text,
            //       "sp_Receipt",
            //       plstField,
            //       plstType,
            //       plstValue,
            //       ds,
            //       rpt1,
            //       "SP"
            //       );
            //    rptLedger.Show();
            //}
            //if (optSalePoint.Checked == true)
            //{
            //    plstField = "@pDoc_Fiscal_ID,@pFromDate,@pToDate";
            //    plstType = "8,18,18"; // {   "8, 8, 8, 8, 8, 8" };
            //    plstValue = "1," + StrF01.D2Str(this.msk_FromDate) + "," +
            //        StrF01.D2Str(this.msk_ToDate);
            //    dsVocDaily ds = new dsVocDaily();
            //    CrPaymentSub rpt1 = new CrPaymentSub();
            //    frmPrintViewer rptLedger = new frmPrintViewer(
            //       "Receipt",
            //       this.msk_FromDate.Text,
            //       this.msk_ToDate.Text,
            //       "sp_Payment",
            //       plstField,
            //       plstType,
            //       plstValue,
            //       ds,
            //       rpt1,
            //       "SP"
            //       );
            //    rptLedger.Show();
            //}
        //    if (optSalePoint.Checked == true)
        //    {
        //        plstField = "@pDoc_Fiscal_ID,@pFromDate,@pToDate";
        //        plstType = "8,18,18"; // {   "8, 8, 8, 8, 8, 8" };
        //        plstValue = "1," + StrF01.D2Str(this.msk_FromDate) + "," +
        //            StrF01.D2Str(this.msk_ToDate);
        //        dsVocDaily ds = new dsVocDaily();
        //        CrSalePointMain rpt1 = new CrSalePointMain();

        //        frmPrintViewerSubRpt rptLedger = new frmPrintViewerSubRpt(
        //           "Daily Summary",
        //           this.msk_FromDate.Text,
        //           this.msk_ToDate.Text,
        //           "sp_SalePoint",
        //           plstField,
        //           plstType,
        //           plstValue,
        //           ds,
        //           rpt1,
        //           "SP"
        //           );
        //        rptLedger.Show();
        //    }
        }

        private void btn_FromDate_Click(object sender, EventArgs e)
        {
            if (pnlCalander.Visible)
            {
                pnlCalander.Visible = false;
                return;
            }
            else
            {
                //if (btnDetailTop.Text.ToString() == '\u25BC'.ToString())    // Down Arrow/at minimum width position
                //{
                //     btnDetailTop.PerformClick();
                //}
                //gBMonth.Visible = true;
                pnlCalander.Visible = true;
                mCalendarMain.SelectionStart = mCalendarMain.TodayDate;
                msk_FromDate.Text = mCalendarMain.SelectionStart.ToString();
                mCalendarMain.Focus();
            }

        }

        private void btn_ToDate_Click(object sender, EventArgs e)
        {
            if (pnlCalander.Visible)
            {
                pnlCalander.Visible = false;
                return;
            }
            else
            {
                //if (btnDetailTop.Text.ToString() == '\u25BC'.ToString())    // Down Arrow/at minimum width position
                //{
                //     btnDetailTop.PerformClick();
                //}
                //gBMonth.Visible = true;
                pnlCalander.Visible = true;
                mCalendarMain.SelectionStart = mCalendarMain.TodayDate;
                msk_ToDate.Text = mCalendarMain.SelectionStart.ToString();
                mCalendarMain.Focus();
            }
        }

        private void btn_HideMonth_Click(object sender, EventArgs e)
        {
            pnlCalander.Visible = false;

        }

        //private void msk_AccountID_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F1)
        //    {
        //        LookUpAc_Mask();
        //    }
        //}

        private void PassData(object sender)
        {
            msk_ItemID.Text = ((MaskedTextBox)sender).Text;
        }

        private void frmLedger_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            msk_ToDate.Text= now.Date.ToString();
            msk_FromDate.Text = clsGVar.cnstFromDate.ToString();
            LoadInitialControls();
        }

        private void LoadInitialControls()
        {
            // 1 = dGV Grid Control
            // 2 = Column Total (Total number of Columns for cross verification with other parameters like width, format)
            // 3 = Column Header
            // 4 = Column Width to be displayed on Grid
            // 5 = Column MaxInputLen   // 0 = unlimited, 
            // 6 = Column Format        // T = Text, N = Numeric, H = Hiden
            // 7 = Column ReadOnly      // 1 = ReadOnly, 0 = Not ReadOnly
            // 8 = Grid Color Scheme    // Default = 1
            // RO 
            //UOM Combo Fill
            int fcboDefaultValue = 0;
            string lSQL = string.Empty;

            //lSQL = "select * from " + "Gds_UOM";
            //lSQL += " order by ordering";

            lSQL = " SELECT * FROM (";
            lSQL += " SELECT 0 AS goodsuom_id, ' <<ALL>>' AS  goodsuom_title";
            lSQL += " UNION ";
            lSQL += " SELECT goodsuom_id, goodsuom_title FROM gds_uom)x ORDER BY x.Goodsuom_Title";

            clsFillCombo.FillCombo(cbo_UOM, clsGVar.ConString1, "Gds_UOM" + "," + "GoodsUOM_ID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cbo_UOM.SelectedValue);

            //Godown Combo Fill
            //lSQL = "select * from " + "cmn_Godown";
            //lSQL += " order by ordering";

            lSQL = " SELECT * FROM (";
            lSQL += " SELECT 0 AS Godown_ID, ' <<ALL>>' AS Godown_Title";
            lSQL += " UNION ";
            lSQL += " SELECT Godown_id, Godown_title FROM cmn_Godown)x ORDER BY x.Godown_Title";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "cmn_Godown" + "," + "Godown_ID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);

            grdDetail.Rows.Clear();
            grdDetail.Columns.Clear();

            string tFieldList = "";
            tFieldList = "  Doc_Date";            //0
            tFieldList += ", Doc_StrID";   //1
            tFieldList += ", Narration";            //2
            tFieldList += ", Godown";            //2
            tFieldList += ", Rate";            //2
            tFieldList += ", Qty_In";    //3
            tFieldList += ", Qty_Out";          //4
            tFieldList += ", Balance";      //5
            tFieldList += ", UOM";            //2
            tFieldList += ", QtyOther";            //2
            tFieldList += ", Bundle";            //2
            tFieldList += ", Length";            //2
            tFieldList += ", LenDec";            //2
            tFieldList += ", Width";            //2
            tFieldList += ", WidDec";            //2
            tFieldList += ", Serial_No";           //6

            string lHDR = "";
            lHDR += "Date";                       // 0-   Hiden
            lHDR += ",Voucher #";                      // 1-   Hiden
            lHDR += ",Narration";                          // 2-   
            lHDR += ",Godown";                          // 3-   
            lHDR += ",Rate";                          //4-   
            lHDR += ",Qty In";                          // 5-   
            lHDR += ",Qty Out";                          // 6-   
            lHDR += ",Balance";                          // 7-   
            lHDR += ",UOM";                          // 8-   
            lHDR += ",QtyOther";                          // 9-   
            lHDR += ",Bundle";                          // 10-   
            lHDR += ",Length";                          // 11-   
            lHDR += ",LenDec";                          // 12-   
            lHDR += ",Width";                          // 13-   
            lHDR += ",WidDec";                          // 14-   
            lHDR += ",Sr #";                          // 15-   

            string fColWidthAAAA = " 8,10,25, 6, 7, 7, 7, 7, 6, 7, 7, 7, 7, 7, 7, 4";
            string fColMinWidthA = " 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0";
            string fColMaxInpLen = " 8,10,25, 6,10,10, 7, 7, 6, 7, 7, 7, 7, 7, 7, 4";
            string fColFormatAAA = " T, T, T, T,N2,N2,N2,N2, T,N2,N2,N2,N2,N2,N2,N0";
            string fColReadOnlyA = " 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1";
            
            clsDbManager.SetGridHeaderCmb(
                grdDetail,
                16,
                lHDR,
                fColWidthAAAA,
                fColMinWidthA,
                fColMaxInpLen,
                fColFormatAAA,
                fColReadOnlyA,
                "DATA",
                null,
                null,
                null,
                null,
                false,
                2);
            //grdDetail.Columns[(int)GColInv.WidDec].MinimumWidth = 20;

        }
        private void frmLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (!fGridControl)
                //{
                //    e.Handled = true;
                //    SendKeys.Send("{TAB}");
                //}
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

        }

        private void LoadGridData()
        {
            if (msk_ItemID.Text=="" || msk_ItemID.Text==null)
            {
                return;
            }
            string lSQL = "";
            lSQL += "Select * from (";

            lSQL += " SELECT '" + StrF01.D2Str(msk_FromDate) + "' AS doc_date, 'OPN-1' AS Doc_StrID, ";
            lSQL += " 'Opening Balance' AS NARRATION, '" + cboGodown.Text + "' as Godown, 0 as Rate,";
            lSQL += " Case When Sum(ISNULL(td.Qty_In,0)-ISNULL(td.Qty_Out,0))>0 "
                 + " then Sum(ISNULL(td.Qty_In,0)-ISNULL(td.Qty_Out,0)) else 0 end as Qty_In,";
            lSQL += " Case When Sum(ISNULL(td.Qty_In,0)-ISNULL(td.Qty_Out,0))<0 "
                + " then Abs(Sum(ISNULL(td.Qty_In,0)-ISNULL(td.Qty_Out,0))) else 0 end as Qty_Out,";
            lSQL += " Sum(ISNULL(td.Qty_In,0)-ISNULL(td.Qty_Out,0)) as Balance, ";

            lSQL += "'" + cbo_UOM.Text + "' as UOM, 0 as QtyOther,";
            lSQL += " 0  as Bundle, 0 as Length, 0 as LenDec, 0 as Width, 0 as WidDec,  0 as Serial_No";

            lSQL += " FROM inv_tran t INNER JOIN inv_trandtl td ON t.doc_vt_id=td.doc_vt_id";
            lSQL += " AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id";
            //lSQL += " INNER JOIN gds_item gi ON gi.goodsitem_id=td.ItemID";
            //lSQL += " INNER JOIN gds_Group gg ON gg.Group_id=gi.Group_id";
            //lSQL += " INNER JOIN gds_uom u ON td.UOMID=u.goodsuom_id";
            //lSQL += " INNER JOIN cmn_Godown g ON td.GodownID=g.Godown_id";
            //lSQL += " INNER JOIN ALCP_ValidationDescription avd ON t.doc_vt_id=avd.DescID AND avd.ValidationId=69";

            lSQL += " WHERE t.doc_fiscal_id=1";
            lSQL += " AND td.ItemID=" + msk_ItemID.Tag.ToString();
            lSQL += " AND t.doc_date < '" + StrF01.D2Str(msk_FromDate) + "'";
            if (cboGodown.Text != " <<ALL>>")
            {
                lSQL += " AND td.GodownID=" + cboGodown.SelectedValue.ToString();
            }

            if (cbo_UOM.Text != " <<ALL>>")
            {
                lSQL += " AND td.UOMID=" + cbo_UOM.SelectedValue.ToString();
            }
            //lSQL += " ORDER BY t.doc_date, td.SERIAL_NO";

            lSQL += " UNION ";
            lSQL += " SELECT t.doc_date, avd.Name + '-' + t.doc_strid AS Doc_StrID, ";
            lSQL += " td.NARRATION, g.Godown_title as Godown, td.Rate,";
            lSQL += " td.Qty_In, td.Qty_Out, 0 AS Balance, u.goodsuom_st as UOM, td.MeshTotal as QtyOther,";
            lSQL += " td.Bundle, td.Length, td.LenDec, td.Width, td.WidDec, td.SERIAL_NO";
            lSQL += " FROM inv_tran t INNER JOIN inv_trandtl td ON t.doc_vt_id=td.doc_vt_id";
            lSQL += " AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id";
            lSQL += " INNER JOIN gds_item gi ON gi.goodsitem_id=td.ItemID";
            lSQL += " INNER JOIN gds_Group gg ON gg.Group_id=gi.Group_id";
            lSQL += " INNER JOIN gds_uom u ON td.UOMID=u.goodsuom_id";
            lSQL += " INNER JOIN cmn_Godown g ON td.GodownID=g.Godown_id";
            lSQL += " INNER JOIN ALCP_ValidationDescription avd ON t.doc_vt_id=avd.DescID AND avd.ValidationId=69";

            lSQL += " WHERE t.doc_fiscal_id=1";
            lSQL += " AND td.ItemID=" + msk_ItemID.Tag.ToString();
            lSQL += " AND t.doc_date BETWEEN '" + StrF01.D2Str(msk_FromDate);
            lSQL += "' AND '" + StrF01.D2Str(msk_ToDate) + "'";

            if (cboGodown.Text != " <<ALL>>")
            {
                lSQL += " AND td.GodownID=" + cboGodown.SelectedValue.ToString();
            }

            if (cbo_UOM.Text != " <<ALL>>")
            {
                lSQL += " AND td.UOMID=" + cbo_UOM.SelectedValue.ToString();
            }
            lSQL += ")x order by x.doc_date, x.Serial_No";
            //lSQL += " ORDER BY t.doc_date, td.SERIAL_NO";

            //
            string tFieldList = "";
            tFieldList = "  Doc_Date";            //0
            tFieldList += ", Doc_StrID";   //1
            tFieldList += ", Narration";            //2
            tFieldList += ", Godown";            //2
            tFieldList += ", Rate";            //2
            tFieldList += ", Qty_In";    //3
            tFieldList += ", Qty_Out";          //4
            tFieldList += ", Balance";      //5
            tFieldList += ", UOM";            //2
            tFieldList += ", QtyOther";            //2
            tFieldList += ", Bundle";            //2
            tFieldList += ", Length";            //2
            tFieldList += ", LenDec";            //2
            tFieldList += ", Width";            //2
            tFieldList += ", WidDec";            //2
            tFieldList += ", Serial_No";           //6

            //string tFieldList = "";
            //tFieldList =  "  Doc_Date";            //0
            //tFieldList += ", Doc_StrID";   //1
            //tFieldList += ", Narration";            //2
            //tFieldList += ", Qty_In";    //3
            //tFieldList += ", Qty_Out";          //4
            //tFieldList += ", Balance";      //5
            //tFieldList += ", Serial_No";           //6
            //tFieldList += ", ''";              
            // 
            string tColFormat = "";
            //tColFormat += ",TB";                                                  // 0-  
            //tColFormat += ",SN";                                                    // 1-    
            tColFormat = "TB";                                                    // 0-    sn
            tColFormat += ",TB";                                                    // 1-    sn
            tColFormat += ",TB";                                                    // 2-
            tColFormat += ",TB";                                                    // 3-
            tColFormat += ",N2";                                                    // 4-
            tColFormat += ",N2";                                                    // 5-
            tColFormat += ",N2";                                                    // 6-
            tColFormat += ",TB";                                                    // 7-
            tColFormat += ",TB";                                                    // 8-
            tColFormat += ",N2";                                                    // 9-
            tColFormat += ",N2";                                                    // 10-
            tColFormat += ",N2";                                                    // 11-
            tColFormat += ",N2";                                                    // 12-
            tColFormat += ",N2";                                                    // 13-
            tColFormat += ",N2";                                                    // 14-
            tColFormat += ",N0";                                                    // 15-    
            //tColFormat += ",TB";                                                    

            clsDbManager.FillDataGrid(
            grdDetail,
            lSQL,
            tFieldList,
            tColFormat);

        }
        // Prepare Document Where
        //private string DocWhere(string pPrefix = "")
        //{
        //    // pPrefix is including dot
        //    string fDocWhere = string.Empty;
        //    try
        //    {
        //        fDocWhere = " t.doc_vt_id=" + clsGVar.INV.ToString();
        //        fDocWhere += " and t.doc_fiscal_id=1 and t.doc_status=1";
        //        fDocWhere += " and t.doc_id=" + lblDocID.Text.ToString();
        //        return fDocWhere;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        public void LookUp_Item()
        {
            bool fAlreadyExists = false;
            string fTitleWidth = string.Empty;
            string fTitleFormat = string.Empty;
            string fJoin = string.Empty;
            bool fAddressBtn = false;
            string[] fMain;
            string[] fBeginParam;
            string[] fField;
            string[] fMaxLen;
            string[] fFieldTitle;
            string[] fValR;

            string fLookUpField = string.Empty;
            string fLookUpTitle = string.Empty;
            string fLookUpTitleWidth = string.Empty;
            string fFormTitle = this.Text;

            string fTableName = string.Empty;
            // Prepare a a list of fields. 

            string fStartName = "goodsitem";    // " + fStartName + " 
            string fTableCbo1 = "gds_UOM"; // " + fStartCbo1 + "
            string fTableCbo2 = "gds_Group";     // " + fStartCbo2 + "
            // new fields defined due to baming mkt_, geo_, gds_ etc
            string fStartCbo1 = "goodsuom"; // " + fStartCbo1 + "
            string fStartCbo2 = "Group";     // " + fStartCbo2 + "

            string fCbo1KeyField = "goodsuom_id"; // value of ID obtained from Cbo1, stored in goodsitem table
            string fCbo2KeyField = "Group_id";  // value of ID obtained from Cbo2, stored in goodsitem table   

            //tMainParam = "1007,Item ID," + "gds_item," + fStartName + "_id,int16,0";
            //tMainParam += "," + fTableCbo1 + "," + fStartCbo1 + "_id," + fTableCbo2 + "," + fStartCbo2 + "_id,Goods UOM Default Name,Item Group Name";
            //
            //tBeginParam = clsGVar.LocID.ToString();
            //tBeginParam += "," + clsGVar.GrpID.ToString();
            //tBeginParam += "," + clsGVar.CoID.ToString();
            //tBeginParam += "," + clsGVar.YrID.ToString();
            //
            // "INNER JOIN country p ON c.province_pid = p.country_id"
            //tFLBegin = "loc_id,grp_id,co_id,year_id";   //"group_id,company_id,year_id"; 
            //tFL = fStartName + "_title," + fStartName + "_st,ordering,goodsitem_packing_id,goodsitem_defuom_id,isdisabled";
            //tFL = fStartName + "_title," + fStartName + "_st,ordering," + fCbo1KeyField + "," + fCbo2KeyField + ",isdisabled";
            //tFLEnd = "isdefault,frm_id";
            ////
            //tFLenBegin = "0,0,0";
            //tFLen = "4,30,8,4";
            //tFLenEnd = "0,0";
            ////
            ////tFTBegin = "Group ID,Company ID,Year ID";
            //fFT = "ID,Item Title,Short Title,Ordering,UOM ID,Goup ID,Disabled";
            //fFTEnd = "Default";
            ////
            //fValBegin = "0,0,0,0";
            //fVal = "R,R,R,R,R";
            //fValEnd = "0";
            //
            fTitleWidth = "10,20,10,20,15,15,10";
            fTitleFormat = "N, T, T, T, T, T, T";


            fJoin = "LEFT OUTER JOIN " + fTableCbo1 + " u ON  kt." + fCbo1KeyField + " = u." + fStartCbo1 + "_id ";
            fJoin += "LEFT OUTER JOIN " + fTableCbo2 + " g ON  kt." + fCbo2KeyField + " = g." + fStartCbo2 + "_id";

            //tLookUpField = "kt.goodsitem_title, kt.goodsitem_st, kt.ordering, p.goodspacking_title, u.uom_title, kt.isdisabled";
            fLookUpField = "kt." + fStartName + "_title, kt." + fStartName + "_st, kt.ordering, u." + fStartCbo1 + "_title, g." + fStartCbo2 + "_title, kt.isdisabled";
            fLookUpTitle = "ID,Item Title,Short Title,Ordering,UOM Title,Group Title,Disabled";
            fLookUpTitleWidth = "10,20,10,6,15,15,8";

            string tKeyField = "kt." + "GoodsItem_ID";
            fTableName = " gds_item ";
            //string tKeyField = "kt." + fKeyField;
            //frmLookUp sForm = new frmLookUp(tKeyField, fLookUpField, fTableName, fFormTitle, 1, fLookUpTitle, fLookUpTitleWidth, fTitleFormat, false, fJoin);

            frmLookUp sForm = new frmLookUp(tKeyField,
                fLookUpField,
                fTableName,
                fFormTitle,
                1,
                fLookUpTitle,
                fLookUpTitleWidth,
                fTitleFormat,
                false,
                fJoin);

            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataItem);
            sForm.ShowDialog();
            if (msk_ItemID.Text != null)
            {
                if (msk_ItemID.Text.ToString() == "" || msk_ItemID.Text.ToString() == string.Empty)
                {
                    return;
                }
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        // ----Event/Delegate--------------------------------
        private void PassDataItem(object sender)
        {
            msk_ItemID.Text = ((MaskedTextBox)sender).Text.ToString();
        }

        private void msk_ItemID_Leave(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;
            int int_UOMID = 0;

            // Fields 0,1,2,3 are Begin 
            //tSQL = "Select top 1 goodsitem_title, goodsitem_id, goodsitem_st, Group_id, goodsuom_id ";
            //tSQL += " from gds_item Where ";
            //tSQL = tSQL + " goodsitem_id = '" + msk_ItemID.Text.ToString() + "';";

            tSQL = "Select top 1 i.goodsitem_title, i.goodsitem_id, i.goodsitem_st, ";
            tSQL += " i.Group_id, gg.Group_title, gg.Group_st, ";
            tSQL += " i.goodsuom_id, u.goodsuom_title, u.goodsuom_st";
            tSQL += " from gds_item i INNER JOIN gds_Group gg ON i.Group_id=gg.Group_id";
            tSQL += " INNER JOIN gds_uom u ON i.goodsuom_id=u.goodsuom_id";
            tSQL += " Where i.goodsitem_id = '" + msk_ItemID.Text.ToString() + "'";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "gds_item");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    //lblItemName.Text = dRow.ItemArray.GetValue(0).ToString();

                    lblItemName.Text = dRow.ItemArray.GetValue(5).ToString() + dRow.ItemArray.GetValue(2).ToString();
                    msk_ItemID.Tag = dRow.ItemArray.GetValue(1).ToString();
                    int_UOMID = Convert.ToInt16(dRow.ItemArray.GetValue(6).ToString());
                    cbo_UOM.SelectedIndex = clsSetCombo.Set_ComboBox(cbo_UOM, int_UOMID);
                    //tFirstID = Convert.ToInt16(dRow.ItemArray.GetValue(3).ToString());
                    //cboFirstID.SelectedIndex = ClassSetCombo.Set_ComboBox(cboFirstID, tFirstID);
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void msk_ItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Item();
            }
        }

        private void msk_ItemID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void msk_ItemID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LookUp_Item();
        }

        private void OptItemLedgerShopItem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void OptItemLedger_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void OptItemLedger_Click(object sender, EventArgs e)
        {
            cboGodown.Visible = false;
            lblGodown.Visible = false;
        }

        private void OptItemLedgerShopItem_Click(object sender, EventArgs e)
        {
            cboGodown.Visible = true;
            lblGodown.Visible = true;
        }

    }
}
