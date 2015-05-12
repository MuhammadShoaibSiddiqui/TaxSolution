using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace TaxSolution
{
    public partial class frmBackupDataOLD : Form
    {
        public frmBackupDataOLD()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backup_Database_Load(object sender, EventArgs e)
        {
            txtPath.Text = "\\" + "\\win2k8svr\\g$\\Backup\\NizamiBrothers" + DateTime.Now.ToString("dd-MM-yyyy_ddd_hh_mm") + ".bak";
            this.MaximizeBox = false;
        }

        private void frmBackupData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Start();
                SqlConnection con = new SqlConnection(clsGVar.ConString1);
                //string f = "\\";
                //string filePath = "\\win2k8svr\\g$\\Backup"; 
                string pSQL = "backup database NizamiBrothers to disk ='" + txtPath.Text.ToString() + "'";
                //cmd.ExecuteNonQuery();
                clsDbManager.ExeOne(pSQL);
                //MessageBox.Show("Bacukup Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(timer1.Interval);
            timer1.Interval = 250;
            this.toolStripStatusLabel1.Text = "Backup Completed !";
            //MessageBox.Show("Backup Successful");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileChooser = new FolderBrowserDialog();
          
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fileChooser.SelectedPath;
            }
        }
    }
}
