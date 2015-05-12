using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaxSolution.PrintReport;
using TaxSolution.PrintViewer;
using TaxSolution.PrintDataSets;

namespace TaxSolution
{
    public partial class frmDetailsPrinting : Form
    {
        public frmDetailsPrinting()
        {
            InitializeComponent();
        }

        private void frmDetailsPrinting_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void frmDetailsPrinting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (optItemRateList.Checked == true)
            {
                string fRptTitle = "Item Rate List";
                string plstField = "@ID";
                string plstType = "8"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1";

                dsItems ds = new dsItems();
                CrItems rpt1 = new CrItems();

                frmPrintViewer rptLedger = new frmPrintViewer(
                   fRptTitle,
                   "",
                   "",
                   "sp_ListOfItems",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptLedger.Show();
            }

            else if (optListOfGodowns.Checked == true)
            {
                string fRptTitle = "List of Godowns";
                string plstField = "@ID";
                string plstType = "8"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1";

                dsGodowns ds = new dsGodowns();
                CrGodowns rpt1 = new CrGodowns();

                frmPrintViewer rptLedger = new frmPrintViewer(
                   fRptTitle,
                   "",
                   "",
                   "sp_ListOfGodowns",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptLedger.Show();
            }

            else if (optListOfUOM.Checked == true)
            {
                string fRptTitle = "List of UOM";
                string plstField = "@ID";
                string plstType = "8"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1";

                dsUOM ds = new dsUOM();
                CrUOM rpt1 = new CrUOM();

                frmPrintViewer rptLedger = new frmPrintViewer(
                   fRptTitle,
                   "",
                   "",
                   "sp_ListOfUOM",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptLedger.Show();
            }

            else if (optListOfTransports.Checked == true)
            {
                string fRptTitle = "List of Transports";
                string plstField = "@ID";
                string plstType = "8"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1";

                dsTransport ds = new dsTransport();
                CrTransport rpt1 = new CrTransport();

                frmPrintViewer rptLedger = new frmPrintViewer(
                   fRptTitle,
                   "",
                   "",
                   "sp_ListOfTransport",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptLedger.Show();
            }

            else if (optListOfCities.Checked == true)
            {
                string fRptTitle = "List of Cities";
                string plstField = "@ID";
                string plstType = "8"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1";

                dsCities ds = new dsCities();
                CrCities rpt1 = new CrCities();

                frmPrintViewer rptLedger = new frmPrintViewer(
                   fRptTitle,
                   "",
                   "",
                   "sp_ListOfCities",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptLedger.Show();
            }

            else if (optListOfItemCodes.Checked == true)
            {
                string fRptTitle = "List of Item Codes";
                string plstField = "@ID";
                string plstType = "8"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1";

                dsItemCodes ds = new dsItemCodes();
                CrListOfItemCodes rpt1 = new CrListOfItemCodes();

                frmPrintViewer rptLedger = new frmPrintViewer(
                   fRptTitle,
                   "",
                   "",
                   "sp_ListOfItemsCodes",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptLedger.Show();
            }

            else if (optListOfTerritories.Checked == true)
            {
                string fRptTitle = "List of Territories";
                string plstField = "@ID";
                string plstType = "8"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1";

                dsTerritories ds = new dsTerritories();
                CrListOfTerritories rpt1 = new CrListOfTerritories();

                frmPrintViewer rptLedger = new frmPrintViewer(
                   fRptTitle,
                   "",
                   "",
                   "sp_ListOfTerritories",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptLedger.Show();
            }

            else if (optListOfRegions.Checked == true)
            {
                string fRptTitle = "List of Regions";
                string plstField = "@ID";
                string plstType = "8"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1";

                dsRegions ds = new dsRegions();
                CrListOfRegions rpt1 = new CrListOfRegions();

                frmPrintViewer rptLedger = new frmPrintViewer(
                   fRptTitle,
                   "",
                   "",
                   "sp_ListOfRegions",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptLedger.Show();
            }

            else if (optListOfProvinces.Checked == true)
            {
                string fRptTitle = "List of Provinces";
                string plstField = "@ID";
                string plstType = "8"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1";

                dsProvinces ds = new dsProvinces();
                CrListOfProvinces rpt1 = new CrListOfProvinces();

                frmPrintViewer rptLedger = new frmPrintViewer(
                   fRptTitle,
                   "",
                   "",
                   "sp_ListOfProvinces",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptLedger.Show();
            }

            else if (optListOfCountries.Checked == true)
            {
                string fRptTitle = "List of Countries";
                string plstField = "@ID";
                string plstType = "8"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1";

                dsCountries ds = new dsCountries();
                CrListOfCountries rpt1 = new CrListOfCountries();

                frmPrintViewer rptLedger = new frmPrintViewer(
                   fRptTitle,
                   "",
                   "",
                   "sp_ListOfCountries",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptLedger.Show();
            }

            else if (optListOfItemGroups.Checked == true)
            {
                string fRptTitle = "List of Item Groups";
                string plstField = "@ID";
                string plstType = "8"; // {   "8, 8, 8, 8, 8, 8" };
                string plstValue = "1";

                dsItemGroups ds = new dsItemGroups();
                CrListOfItemGroups rpt1 = new CrListOfItemGroups();

                frmPrintViewer rptLedger = new frmPrintViewer(
                   fRptTitle,
                   "",
                   "",
                   "sp_ListOfItemGroups",
                   plstField,
                   plstType,
                   plstValue,
                   ds,
                   rpt1,
                   "SP"
                   );

                rptLedger.Show();
            }
        }
    }
}
