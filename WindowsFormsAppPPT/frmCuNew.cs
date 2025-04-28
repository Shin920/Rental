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

    public partial class frmCuNew : Form
    {

        public string EmpID { get { return txtEmpID.Text.ToString(); } }

        public string CmpID { get; set; }

        public string[] SelectedPrdID
        {
            get
            {
                string[] prdIDs = new string[lbCartPrd.Items.Count];
                for (int i = 0; i < lbCartPrd.Items.Count; i++)
                {
                    string[] arr = lbCartPrd.Items[i].ToString().Split('/');
                    prdIDs[i] = arr[0].Trim().ToString();
                }

                return prdIDs;
            }
        }
        public frmCuNew()
        {
            InitializeComponent();
        }

        private void frmCuNew_Load(object sender, EventArgs e)
        {
            cmbKinds.SelectedItem = "제품명";


            MySpread01..

            CommonUtil.SetInitGridView(dgvRentalable);

            CommonUtil.AddGridTextColumn(dgvRentalable, "제품번호", "prd_id", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvRentalable, "제품명", "prd_name", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvRentalable, "구분", "name", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvRentalable, "제조사", "built_cmp", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvRentalable, "제조일", "built_date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvRentalable, "렌트가격", "rent_price", DataGridViewContentAlignment.MiddleRight, colWidth: 130);

            dgvRentalable.Columns["rent_price"].DefaultCellStyle.Format = "N0";

            DataLoad();
        }

        private void DataLoad()
        {
            RentalDAC rent = new RentalDAC();
            dgvRentalable.DataSource = rent.GetAll().DefaultView;
            rent.Dispose();
        }

        private void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (txtPrdID.Text == "")
            {
                MessageBox.Show("제품을 선택하세요");
            }
            else
            {
                
                PrdDAC db = new PrdDAC();
                Prd prd = db.GetPrdInfo(txtPrdID.Text);

                db.Dispose();

                lbCartPrd.Items.Add($"{prd.PrdID} / {prd.PrdName} / {prd.Code} / {prd.BltCmp} / {prd.Price.Substring(0, prd.Price.Length - 5)}");
                
            }


        }
                

        private void btnDelPrd_Click(object sender, EventArgs e)
        {
            if (lbCartPrd.SelectedIndex >= 0)
            {
                int idx = lbCartPrd.SelectedIndex;

                lbCartPrd.Items.RemoveAt(idx);
            }
        }

        private void btnStartRT_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpID.Text == "" || txtPrdID.Text == "")
                {
                    MessageBox.Show("사번과 제품번호를 정확히 입력해주세요");
                    return;
                }
                else
                {
                    EmpDAC dac = new EmpDAC();
                    if (dac.isVaild(this.CmpID, txtEmpID.Text))
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show(Properties.Resources.MSG_NEW_RENTAL_OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("유효하지 않은 사번입니다.");
                        return;
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dgvRentalable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPrdID.Text = dgvRentalable[0, dgvRentalable.CurrentRow.Index].Value.ToString();
            imgDAC dac = new imgDAC();
            NewRenPB.ImageLocation = dac.GetFilePath(dgvRentalable[1, dgvRentalable.CurrentRow.Index].Value.ToString());
            dac.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchValue.Text == "")
            {
                DataLoad();
            }
            else
            {
                RentalDAC dac = new RentalDAC();
                dgvRentalable.DataSource = dac.GetRentalable(cmbKinds.Text, txtSearchValue.Text);
                dac.Dispose();
            }
        }

        private void btnEmpList_Click(object sender, EventArgs e)
        {
            SearchEmp frm = new SearchEmp();
            frm.CmpID = this.CmpID;
            if(frm.ShowDialog() == DialogResult.OK)
            {
                txtEmpID.Text = frm.EmpID.ToString();
            }
        }
    }
}
