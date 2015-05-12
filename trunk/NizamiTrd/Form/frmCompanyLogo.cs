using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace TaxSolution
{
    public partial class frmCompanyLogo : Form
    {
        static string[] filename = { "" };
        string login = string.Empty;

        public frmCompanyLogo()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            lblCompanyName.Text = "Ranyal Industries (Pvt) Ltd";
            PopulateRecords();
        }

        private void button2_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnModify.Enabled = false;
            btnExit.Enabled = false;
            btnBrowse.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnModify.Enabled = true;
            btnCancel.Enabled = false;
            btnExit.Enabled = true;
            btnBrowse.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileChooser = new OpenFileDialog();
            //fileChooser.Filter = "image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            fileChooser.Filter = "image files All files (*.*)|*.*";
            fileChooser.InitialDirectory = "D:\\Pictures";
            fileChooser.Title = "Select Image";
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = fileChooser.FileName;
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(clsGVar.ConString1);

            if (pictureBox1.ImageLocation != null)
            {
                byte[] imgData;
                imgData = File.ReadAllBytes(pictureBox1.ImageLocation);

                //if(cboCourseSelection.SelectedValue.ToString() == "1")
                //{
                SqlCommand cmd = new SqlCommand("UPDATE Photos SET photo = @DATA WHERE ID = 28 ", con);
                cmd.Parameters.Add("@DATA", imgData);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnExit.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(clsGVar.ConString1);

            SqlCommand cmd = new SqlCommand("UPDATE RecruitCourse SET Picture = NULL WHERE ID = 28 ", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            pictureBox1.Image = null;
        }

        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin 



            tSQL += " select photo from Photos where id=28 ";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Photos");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    

                    // Sir Shoaib Code for File Streaming

                    //    if (pictureBox1.Image != null)
                    //    {
                    //        pictureBox1.Image.Dispose();
                    //    }
                    //    if (File.Exists("usama.bmp"))
                    //    {
                    //        File.Delete("usama.bmp");
                    //    }
                    //    //Initialize a file stream to write image data
                    //    FileStream fs = new FileStream("usama.bmp", FileMode.Create, FileAccess.Write, FileShare.Write);

                    //    if (ds.Tables[0].Rows[0]["Picture"] != DBNull.Value)
                    //    {
                    //        byte[] blob = (byte[])ds.Tables[0].Rows[0]["Picture"];

                    //        //Write data in image file using file stream
                    //        fs.Write(blob, 0, blob.Length);
                    //        fs.Close();
                    //        fs.Dispose();
                    //        //fs = null;

                    //        pictureBox1.Image = Image.FromFile("usama.bmp");
                    //        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //        pictureBox1.Refresh();

                    //    }
                    //    else
                    //    {
                    //        //pbPic.Image = Image.FromFile("Checkin.jpg");

                    //        pictureBox1.Image = imageList1.Images[0];
                    //        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //        pictureBox1.Refresh();
                    //    }
                    //    fs.Close();
                    //    fs.Dispose();
                    //    if (File.Exists("PunjabPoliceLogo.jpg"))
                    //    {
                    //        File.Delete("PunjabPoliceLogo.jpg");
                    //    }
                    //}

                    // Sir Shoaib Code for Memory Streaming

                    pictureBox1.Image = imageList1.Images[0];
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Refresh();


                    if (ds.Tables[0].Rows[0]["photo"] != DBNull.Value)
                    {
                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])ds.Tables[0].Rows[0]["photo"];
                        //  byteBLOBData = (Byte[])(ds.Tables["LadyRecruitCourse"].Rows[c - 1]["Picture"]);

                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        pictureBox1.Image = Image.FromStream(stmBLOBData);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Refresh();

                        byteBLOBData = null;
                        stmBLOBData.Close();
                        stmBLOBData.Dispose();
                        //lblMsg.Text = "File read from the database successfully.";
                    }
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Clear();
                }
            }


            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }
    }
}
    

