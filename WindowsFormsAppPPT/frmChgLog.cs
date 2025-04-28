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
    public partial class frmChgLog : Form
    {
        public string CmpID { get; set; }
        public frmChgLog()
        {
            InitializeComponent();
        }

        private void frmChgLog_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvChgLog);
            CommonUtil.AddGridTextColumn(dgvChgLog, "사번", "emp_no", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvChgLog, "이름", "emp_name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvChgLog, "제품번호", "prd_id", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvChgLog, "사용시작일", "start_date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvChgLog, "사용종료일", "end_date", colWidth: 100);

            DataLoad();
        }

        private void DataLoad()
       {
            EmpRentDAC dac = new EmpRentDAC();
            dgvChgLog.DataSource = dac.GetAll(CmpID);
            dac.Dispose();
                     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                DataLoad();
            }
            else
            {
                EmpRentDAC dac = new EmpRentDAC();
                dgvChgLog.DataSource = dac.GetSAll(CmpID, textBox1.Text);
                dac.Dispose();
            }
        }
    }
}
