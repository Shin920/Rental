using Rental.DAC;
using Rental.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental
{

    public partial class frmCuAS : Form
    {

        public Cmp AsCmp { get; set; }
        public string PrdName { get; set; }

        public frmCuAS(Cmp cp, string prdName)
        {


            this.AsCmp = cp;
            this.PrdName = prdName;
            InitializeComponent();

        }

        private void frmCuAS_Load(object sender, EventArgs e)
        {
            lblCmpName.Text = AsCmp.CmpName;
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblPrdName.Text = PrdName;

            CommonUtil.ComboBoxBinding(cmbASCC, "AS");


        }

        private void btnNewASOk_Click(object sender, EventArgs e)
        {

            CommonDAC cDAC = new CommonDAC();
            AS myas = new AS();
            myas.ProductID = PrdName;
            myas.Code = cDAC.GetCode(cmbASCC.Text.ToString());
            myas.Detail = txtdetail.Text;

            AsDAC asc = new AsDAC();
            asc.RegNewAs(myas);
            asc.Dispose();

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnASCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
