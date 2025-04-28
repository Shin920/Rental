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
    public partial class SearchEmp : Form
    {
        public string CmpID { get; set; }
        public int EmpID { get; set; }
        public SearchEmp()
        {
            InitializeComponent();
        }

        private void SearchEmp_Load(object sender, EventArgs e)
        {

            CommonUtil.SetInitGridView(dgvSempList);

            CommonUtil.AddGridTextColumn(dgvSempList, "사번", "emp_no", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvSempList, "이름", "emp_name", colWidth: 80);
            
            DataLoadSemp();

        }

        private void DataLoadSemp()
        {
            if (CmpID != null)
            {
                EmpDAC dac = new EmpDAC();
                dgvSempList.DataSource = dac.GetSAll(CmpID).DefaultView;
                dac.Dispose();
            }
        }

        private void dgvSempList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSelectedNo.Text = dgvSempList[0, dgvSempList.CurrentRow.Index].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSName.Text == "")
            {
                DataLoadSemp();
            }
            else
            {
                EmpDAC dac = new EmpDAC();
                dgvSempList.DataSource = dac.GetSName(CmpID, txtSName.Text);
                dac.Dispose();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.EmpID = Convert.ToInt32(txtSelectedNo.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
