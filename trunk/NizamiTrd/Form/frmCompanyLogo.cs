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

namespace TaxSolution
{
    public partial class frmCompanyLogo : Form
    {
        string login = string.Empty;

        public frmCompanyLogo()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUsername.Text) | string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Please Provide User Name and Password");
            }

            SqlConnection conn = new SqlConnection(clsGVar.ConString1);
            conn.Open();

            string UserName = txtUsername.Text;
            string Password = txtPassword.Text;

            SqlCommand cmd = new SqlCommand("select * from Users WHERE UserName = '" + txtUsername.Text + "' and Password = '" + txtPassword.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            System.Data.SqlClient.SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                //DataSet ds = new DataSet();
                //DataRow dRow;
                //string tSQL = string.Empty;

                //tSQL = "select * from Users WHERE UserName = '" + txtUsername.Text + "' and Password = '" + txtPassword.Text + "'";

                SqlConnection con = new SqlConnection(clsGVar.ConString1);
                //try
                //{
                //    ds = clsDbManager.GetData_Set(tSQL, "RecruitCourse");

                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        dRow = ds.Tables[0].Rows[0];
                //        txtUsername.Text = (ds.Tables[0].Rows[0]["UserName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["UserName"].ToString());
                //    }


                if (this.txtUsername.Text == dr["UserName"].ToString() & this.txtPassword.Text == dr["Password"].ToString())
                {
                    //MessageBox.Show("*** Login Successful ***");

                    // tSQL += " ORDER BY CapNo ";

                    login = txtUsername.Text;
                    this.Close();
                }
                    //bool IsOpen = false;
                    //foreach (Form f in Application.OpenForms)
                    //{
                    //    if (f.Name == "frmMain")
                    //    {
                    //        IsOpen = true;
                    //        f.Focus();
                    //        MessageBox.Show("This User Is Already Logged In");
                    //        this.Hide();
                    //        break;
                    //    }
                    //}

                    //if (IsOpen == false)
                    //{
                        //if (txtUsername.Text == "Zaman")
                        //{
                        //    frmMain frm = new frmMain();
                        //    ToolStripMenuItem addUserToolStrip = frm.AddNewUserToolStrip;
                        //    addUserToolStrip.Enabled = true;
                        //    frm.Show();
                        //    this.Hide();
                        //}

                        //else
                        //{
                        //    frmMain frm = new frmMain();
                        //    frm.Show();
                        //    this.Hide();
                        //}
                    //}


                //catch
                    //{
                    //    MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                    //}
                    //}

                    else
                    {
                        MessageBox.Show("Invalid UserName or Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Access Denied!!");

                    }
                }
            
        
            else
            {
                MessageBox.Show("Invalid UserName or Password\n Access Denied !!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
       }


        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(this.txtUsername.Text) | string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    MessageBox.Show("Please Provide User Name and Password");
                }

                //SqlConnection conn = new SqlConnection();
                //conn.ConnectionString = "Data Source= (Local); Initial Catalog=PoliceTrainee; User ID=sa; Password=smc786";
                //conn.Open();

                SqlConnection conn = new SqlConnection(clsGVar.ConString1);
                conn.Open();

                string UserName = txtUsername.Text;
                string Password = txtPassword.Text;

                SqlCommand cmd = new SqlCommand("select * from Users WHERE UserName = '" + txtUsername.Text + "' and Password = '" + txtPassword.Text + "'", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                System.Data.SqlClient.SqlDataReader dr = null;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
                    //con.ConnectionString = "Data Source= (Local); Initial Catalog=PoliceTrainee; User ID=sa; Password=smc786";
                    //con.Open();

                    SqlConnection con = new SqlConnection(clsGVar.ConString1);

                    if (this.txtUsername.Text == dr["UserName"].ToString() & this.txtPassword.Text == dr["Password"].ToString())
                    {
                        login = txtUsername.Text;
                        this.Close();

                        //{
                        //    //MessageBox.Show("*** Login Successful ***");
                        //    bool IsOpen = false;
                        //    foreach (Form f in Application.OpenForms)
                        //    {
                        //        //if (f.Name == "frmMain")
                        //        //{
                        //        //    IsOpen = true;
                        //        //    f.Focus();
                        //        //    frmInsertBulkImages frm = new frmInsertBulkImages();
                        //        //    frm.ShowDialog();
                        //        //    this.Hide();
                        //        //    break;
                        //        //}
                        //    }

                        //    if (IsOpen == false)
                        //    {
                        //        //if (txtUsername.Text == "Zaman")
                        //        //{
                        //        //    frmMain frm = new frmMain();
                        //        //    ToolStripMenuItem addUserToolStrip = frm.AddNewUserToolStrip;
                        //        //    addUserToolStrip.Enabled = true;
                        //        //    frm.Show();
                        //        //    this.Hide();
                        //        //}

                        //        //else
                        //        //{
                        //        //    frmMain frm = new frmMain();
                        //        //    frm.Show();
                        //        //    this.Hide();
                        //        //}

                        //    }
                        //}
                    }

                    else
                    {
                        MessageBox.Show("Invalid UserName or Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Access Denied!!");

                    }
                }

                else
                {
                    MessageBox.Show("Invalid UserName or Password\n Access Denied !!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
    }
}
    

