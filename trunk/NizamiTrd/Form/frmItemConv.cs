using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaxSolution
{
    public partial class frmItemConv : Form
    {
        public frmItemConv()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close()
        {
            throw new NotImplementedException();
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            CalcMeasure();
        }

        private void CalcMeasure()
        {
            //int fWidth;
            //int fLength;
            //float j;
            //fLength = int.Parse(txtLenDec.Text);
            //float m = 1245.5f;
            //j = m;
            if (chk_Mesh.Checked == true)
            {
                float fLength;
                float fWidth;
                fLength = float.Parse(txtLenDec.Text);

                fLength = float.Parse(txtLength.Text) + ((float.Parse(txtLenDec.Text) * 0.0833f));
                fWidth = float.Parse(txtWidth.Text) + ((float.Parse(txtWidDec.Text) * 0.0833f));
                lblTotalMeasure.Text = ((fLength * fWidth) * int.Parse(txtBundle.Text)).ToString();
                //txtAmount.Text = (float.Parse(txtTotalMeasure.Text) * float.Parse(txtRate.Text)).ToString();

            }
            else if (chk_BundleCalc.Checked == true)
            {
                //txtAmount.Text = (float.Parse(txtBundle.Text) * float.Parse(txtRate.Text)).ToString();
                //txtAmount.Text = (float.Parse(String.Format("{0:0.0}", txtBundle.Text)) * float.Parse(String.Format("{0:0.0}", txtRate.Text))).ToString();
                //(float.Parse(txtBundle.Text) * float.Parse(txtRate.Text)).ToString();
            }
            else
            {
                //txtAmount.Text = (float.Parse(txtQty.Text) * float.Parse(txtRate.Text)).ToString();
            }
            //fLength = float.Parse(txtLength.Text) + (float.Parse(txtLenDec.Text) * int32.Parse(8.33 / 100));
        }

        private void txtLenDec_TextChanged(object sender, EventArgs e)
        {
            CalcMeasure();
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            CalcMeasure();
        }

        private void txtWidDec_TextChanged(object sender, EventArgs e)
        {
            CalcMeasure();
        }

        private void chk_Mesh_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Mesh.Checked == true)
            {
                chk_BundleCalc.Checked = false;
            }
            CalcMeasure();

        }

        private void chk_BundleCalc_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_BundleCalc.Checked == true)
            {
                chk_Mesh.Checked = false;
            }
            CalcMeasure();

        }


    }
}
