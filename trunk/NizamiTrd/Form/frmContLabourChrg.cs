using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NizamiTrd
{
    public partial class frmContLabourChrg : Form
    {
        public frmContLabourChrg()
        {
            InitializeComponent(); 
                        //frmMain.groupMain.
            //this.Parent.BringToFront = true;
            //this.BringToFront = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                //pnlCalander.BringToFront = true;
                mCalendarMain.SelectionStart = mCalendarMain.TodayDate;
                msk_FromDate.Text = mCalendarMain.SelectionStart.ToString();
                mCalendarMain.Focus();
            }
        }

        private void btn_HideMonth_Click(object sender, EventArgs e)
        {
            pnlCalander.Visible = false;
        }

        private void mCalendarMain_DateChanged(object sender, DateRangeEventArgs e)
        {
            msk_FromDate.Text = mCalendarMain.SelectionStart.ToString();
        }

        private void frmJournalVoc_Load(object sender, EventArgs e)
        {
            
        }

        private void txtManualDoc_TextChanged(object sender, EventArgs e)
        {
            //string strManualDoc;
            //strManualDoc = e.ToString();
            //txtManualDoc.Text =  strManualDoc.ToUpper();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
