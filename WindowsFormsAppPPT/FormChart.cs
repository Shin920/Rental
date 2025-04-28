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
    public partial class FormChart : Form
    {
        public FormChart()
        {
            InitializeComponent();
        }

        private void FormChart_Load(object sender, EventArgs e)
        {
            AsDAC dac = new AsDAC();
            DataTable dt = dac.GetChartASKinds();
            dac.Dispose();
            dgvChart.DataSource = dt;
            chart1.DataSource = dt;
            chart1.Series["Series1"].XValueMember = "name";
            chart1.Series["Series1"].YValueMembers = "count";
            //chart1.Series["Series2"].XValueMember = "Reason";
            //chart1.Series["Series2"].YValueMembers = "Number of Deaths";
            //chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            //chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.DataBind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
