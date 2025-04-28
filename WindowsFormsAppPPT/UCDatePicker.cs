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
    public partial class UCDatePicker : UserControl
    {
        
        public DateTime FromDate
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }

        
        public DateTime ToDate
        {
            get { return dateTimePicker2.Value; }
            set { dateTimePicker2.Value = value; }
        }


        public UCDatePicker()
        {
            InitializeComponent();
        }

        private void UCDatePicker_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker2.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-6);
        }
    }
}
