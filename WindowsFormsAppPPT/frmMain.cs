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
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.IO;

namespace Rental
{
    public partial class frmMain : Form
    {
        Cmp loginCmp;
        


        public frmMain()
        {
            InitializeComponent();

        }

        private void frmAdMain_Load(object sender, EventArgs e)
        {
            #region 컨트롤 초기값
            cmbSearchKinds.SelectedItem = "제품명";
            BcNum_1.SelectedItem = "02";
            cmbSearchCmp.SelectedItem = "고객사명";
            btnInsertCmp.Enabled = false;
            cmbSearchEmp.SelectedItem = "사번";
            EmNum_1.SelectedItem = "010";
            cmbEmpEmail.SelectedItem = "naver.com";
            cmbSearch.SelectedItem = "사번";

            #endregion

            #region 로그인판정
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loginCmp = frm.LoginCmpInfo;
                
                if (loginCmp.IsAdmin == "Y")
                {
                    this.tabControl1.TabPages.Remove(this.tabPage4);
                    this.tabControl1.TabPages.Remove(this.tabPage5);
                    this.tabControl1.TabPages.Remove(this.tabPage6);
                }
                else
                {
                    this.tabControl1.TabPages.Remove(this.tabPage1);
                    this.tabControl1.TabPages.Remove(this.tabPage2);
                    this.tabControl1.TabPages.Remove(this.tabPage3);
                    
                    label39.Text = $"{loginCmp.CmpName} 님 환영합니다";
                }
            }
            else
            {
                this.Close();
            }
            #endregion

            CommonUtil.ComboBoxBinding(cmbPrdCode, "Product"); // 구분 콤보박스에 값 할당


            CommonUtil.SetInitGridView(dgvPrd); 
            CommonUtil.AddGridTextColumn(dgvPrd, "제품번호", "prd_id", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvPrd, "제품명", "prd_name", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvPrd, "구분", "name", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvPrd, "가격", "price", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvPrd, "제조사", "built_cmp", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvPrd, "제조일", "built_date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvPrd, "제조사 연락처", "built_cmp_num", colWidth: 110);
            CommonUtil.AddGridTextColumn(dgvPrd, "보증기한 (M)", "grt_date", colWidth: 80);

            DataLoadPrd();

            CommonUtil.SetInitGridView(dgvCmp);
            CommonUtil.AddGridTextColumn(dgvCmp, "고객사코드", "cmp_id", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvCmp, "고객사명", "cmp_name", colWidth: 120);
            CommonUtil.AddGridTextColumn(dgvCmp, "비밀번호", "password", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvCmp, "총렌탈가격", "totPrice", DataGridViewContentAlignment.MiddleRight, colWidth: 100);
            dgvCmp.Columns["totPrice"].DefaultCellStyle.Format = "N0";

            
            //DataLoadCmp();

            CommonUtil.SetInitGridView(dgvEmp);
            CommonUtil.AddGridTextColumn(dgvEmp, "사번", "emp_no", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvEmp, "이름", "emp_name", colWidth: 120);
            CommonUtil.AddGridTextColumn(dgvEmp, "생년월일", "birth_date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvEmp, "전화번호", "phone", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvEmp, "이메일", "email", colWidth: 200);
            
            DataLoadEmp();
                        

            CommonUtil.SetInitGridView(dgvRentaling);

            CommonUtil.AddGridTextColumn(dgvRentaling, "제품번호", "prd_id", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvRentaling, "제품명", "prd_name", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvRentaling, "구분", "name", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvRentaling, "사용자", "emp_no", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvRentaling, "제조사", "built_cmp", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvRentaling, "제조일", "built_date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvRentaling, "렌탈시작일", "rent_startDate", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvRentaling, "렌탈금액", "rent_price", DataGridViewContentAlignment.MiddleRight, colWidth: 150);

            dgvRentaling.Columns["rent_price"].DefaultCellStyle.Format = "N0";

            DataLoadRTing();

            SumTotPrice();

            CommonUtil.CmpListBinding(cmbCmpName);
            CommonUtil.ComboBoxBinding(cmbStatus, "ASP");

            CommonUtil.SetInitGridView(dgvASMgmt);

            CommonUtil.AddGridTextColumn(dgvASMgmt, "번호", "as_no", colWidth: 60);
            CommonUtil.AddGridTextColumn(dgvASMgmt, "고객사명", "cmp_name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvASMgmt, "제품번호", "prd_id", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvASMgmt, "구분", "name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvASMgmt, "상태", "status", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvASMgmt, "접수날짜", "in_date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvASMgmt, "상세", "detail", colWidth: 150);
            CommonUtil.AddGridTextColumn(dgvASMgmt, "완료날짜", "out_date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvASMgmt, "보증기한(M)", "grt_date", colWidth: 80);

            //DataLoadASAD();

            CommonUtil.SetInitGridView(dgvASCU);

            CommonUtil.AddGridTextColumn(dgvASCU, "번호", "detail_no", colWidth: 60);
            CommonUtil.AddGridTextColumn(dgvASCU, "구분", "name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvASCU, "접수날짜", "in_date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvASCU, "상태", "status", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvASCU, "상세", "detail", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvASCU, "완료날짜", "out_date", colWidth: 100);

            DataLoadASCU();

        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            { 
                case 1: DataLoadCmp(); SumTotincome(); break;
                case 2: DataLoadASAD(); break;
                //case 4: DataLoadRTing(); break;
                //case 5: DataLoadASCU(); break;



                    //case 1:
                    //    if (!bTa0Visit)
                    //    {
                    //        DataLoadCmp();
                    //        bTa0Visit = true;
                    //    }
                    //    break;
                    //case 2:
                    //    if (!bTa0Visit)
                    //    {
                    //        DataLoadASAD();
                    //        bTa0Visit = true;
                    //    }
                    //    break;

            }

        }

        #region A1) 제품관리 탭
        private void DataLoadPrd()
        {
            PrdDAC prd = new PrdDAC();
            dgvPrd.DataSource = prd.GetAll().DefaultView;
            prd.Dispose();
        }

        private void btnInsertPrd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrdSNum.ReadOnly == true)
                {
                    MessageBox.Show("중복된 제품 번호입니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    CommonDAC cDac = new CommonDAC();
                    Prd myprd = new Prd();

                    myprd.PrdName = txtPrdName.Text;
                    myprd.BltDate = dtpBltDate.Value.ToString("yyyy-MM-dd");
                    myprd.Price = txtPrice.Text;
                    myprd.GrtDate = (int.Parse(cmbYear.Text)) * 12 + int.Parse(cmbMonth.Text);
                    myprd.BltCmpNum = BcNum_1.Text + "-" + BcNum_2.Text + "-" + BcNum_3.Text;
                    myprd.Code = cDac.GetCode(cmbPrdCode.Text.ToString());
                    myprd.PrdID = txtPrdSNum.Text;
                    myprd.BltCmp = txtBltCmp.Text;


                    PrdDAC prd = new PrdDAC();
                    prd.Insert(myprd);
                    prd.Dispose();

                    DataLoadPrd();
                }
            }
            catch
            {
                MessageBox.Show("모든 값을 입력해주세요");
            }
        }


        private void btnUpdatePrd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrdSNum.ReadOnly == false)
                {
                    MessageBox.Show("제품을 선택 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Prd myprd = new Prd();
                    CommonDAC cDac = new CommonDAC();


                    myprd.PrdID = txtPrdSNum.Text;
                    myprd.PrdName = txtPrdName.Text;
                    myprd.BltDate = dtpBltDate.Value.ToString("yyyy-MM-dd");
                    myprd.Price = txtPrice.Text;
                    myprd.GrtDate = (int.Parse(cmbYear.Text)) * 12 + int.Parse(cmbMonth.Text);
                    myprd.BltCmpNum = BcNum_1.Text + "-" + BcNum_2.Text + "-" + BcNum_3.Text;
                    myprd.Code = cDac.GetCode(cmbPrdCode.Text.ToString());

                    myprd.BltCmp = txtBltCmp.Text;
                    PrdDAC prd = new PrdDAC();
                    prd.Update(myprd);
                    prd.Dispose();

                    DataLoadPrd();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dgvPrd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPrdSNum.ReadOnly = true;
            CommonDAC cDac = new CommonDAC();
            int rldx = dgvPrd.CurrentRow.Index;


            txtPrdSNum.Text = dgvPrd[0, rldx].Value.ToString();
            txtPrdName.Text = dgvPrd[1, rldx].Value.ToString();
            cmbPrdCode.SelectedValue = cDac.GetCode(dgvPrd[2, rldx].Value.ToString());
            txtPrice.Text = dgvPrd[3, rldx].Value.ToString();
            txtBltCmp.Text = dgvPrd[4, rldx].Value.ToString();
            dtpBltDate.Value = (DateTime)dgvPrd[5, rldx].Value;
            string[] split = dgvPrd[6, rldx].Value.ToString().Split('-');
            if (split.Length > 2)
            {
                BcNum_1.SelectedItem = split[0];
                BcNum_2.Text = split[1];
                BcNum_3.Text = split[2];
            }
            cmbYear.SelectedItem = (Convert.ToInt32(dgvPrd[7, rldx].Value) / 12).ToString();
            cmbMonth.SelectedItem = (Convert.ToInt32(dgvPrd[7, rldx].Value) % 12).ToString();

            imgDAC dac = new imgDAC();
            OutputPB.ImageLocation = dac.GetFilePath(txtPrdName.Text);
            dac.Dispose();


        }

        private void btnSearchPrd_Click(object sender, EventArgs e)
        {
            #region 초기화부분
            txtPrdSNum.ReadOnly = false;
            txtPrdSNum.Text = txtPrdName.Text = txtPrice.Text = txtBltCmp.Text = BcNum_2.Text = BcNum_3.Text = "";
            CommonUtil.ComboBoxBinding(cmbPrdCode, "Product");
            dtpBltDate.Value = DateTime.Now;
            cmbYear.SelectedItem = cmbMonth.SelectedItem = BcNum_1.SelectedItem = null;

            #endregion
            if (txtSearchPrd.Text == "")
            {
                cmbSearchKinds.SelectedItem = "제품명";
                BcNum_1.SelectedItem = "02";
                DataLoadPrd();
            }
            else
            {
                PrdDAC prd = new PrdDAC();
                dgvPrd.DataSource = prd.GetSearchPrd(cmbSearchKinds.SelectedItem.ToString(), txtSearchPrd.Text.Trim()).DefaultView;
                prd.Dispose();
            }
        }

        private void btnDeletePrd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrdSNum.ReadOnly == false)
                {
                    MessageBox.Show("제품을 선택 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DialogResult result = MessageBox.Show("정말 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        PrdDAC pDac = new PrdDAC();
                        pDac.Delete(txtPrdSNum.Text);
                        pDac.Dispose();
                        MessageBox.Show("삭제 완료", "알림");

                        DataLoadPrd();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btnAddImg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrdName.Text))
            {
                MessageBox.Show("이미지를 추가할 제품을 선택하세요.");
                return;
            }

            AddImage frm = new AddImage(txtPrdName.Text);
            frm.ShowDialog();
        }

        private void btnDelImg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrdName.Text))
            {
                MessageBox.Show("이미지를 삭제할 제품을 선택하세요.");
                return;
            }

            imgDAC dac = new imgDAC();
            dac.DeleteProductImage(txtPrdName.Text);
            dac.Dispose();
            MessageBox.Show("삭제 완료");
        }
        #endregion

        #region A2) 고객사관리 탭
        private void DataLoadCmp()
        {
            CmpDAC cmp = new CmpDAC();
            dgvCmp.DataSource = cmp.GetAll().DefaultView;
            cmp.Dispose();
        }
        private void dgvCmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCmpID.ReadOnly = true;
            int rldx = dgvCmp.CurrentRow.Index;

            txtCmpID.Text = dgvCmp[0, rldx].Value.ToString();
            txtCmpName.Text = dgvCmp[1, rldx].Value.ToString();
            txtCmpPW.Text = dgvCmp[2, rldx].Value.ToString();
            
        }

        private void btnInsertCmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCmpName.Text.Length > 1 && txtCmpPW.Text.Length > 3)
                {
                    Cmp mycmp = new Cmp();
                    mycmp.CmpID = txtCmpID.Text;
                    mycmp.CmpName = txtCmpName.Text;
                    mycmp.Password = txtCmpPW.Text;

                    CmpDAC cmp = new CmpDAC();
                    cmp.Insert(mycmp);
                    cmp.Dispose();

                    DataLoadCmp();
                }
                else
                {
                    MessageBox.Show("입력값 오류입니다.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnUpdateCmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCmpID.ReadOnly == false)
                {
                    MessageBox.Show("고객사를 선택해주세요");
                }
                else
                {
                    Cmp mycmp = new Cmp();
                    mycmp.CmpID = txtCmpID.Text;
                    mycmp.CmpName = txtCmpName.Text;
                    mycmp.Password = txtCmpPW.Text;

                    CmpDAC cmp = new CmpDAC();
                    cmp.Update(mycmp);
                    cmp.Dispose();

                    DataLoadCmp();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnSearchCmp_Click(object sender, EventArgs e)
        {
            txtCmpID.ReadOnly = false;
            txtCmpID.Text = txtCmpName.Text = txtCmpPW.Text = "";
            btnInsertCmp.Enabled = false;


            if (txtSearchCmp.Text == "")
            {
                cmbSearchCmp.SelectedItem = "고객사명";
                DataLoadCmp();
            }

            else
            {
                CmpDAC cmp = new CmpDAC();
                dgvCmp.DataSource = cmp.GetSearchCmp(cmbSearchCmp.SelectedItem.ToString(), txtSearchCmp.Text.Trim()).DefaultView;
                cmp.Dispose();
            }
                   

        }

        private void btnDeleteCmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCmpID.ReadOnly == false)
                {
                    MessageBox.Show("고객사를 선택해주세요");
                }
                else
                {
                    DialogResult result = MessageBox.Show("정말 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        CmpDAC cDAC = new CmpDAC();
                        cDAC.Delete(txtCmpID.Text);
                        cDAC.Dispose();
                        MessageBox.Show("삭제 완료", "알림");

                        DataLoadCmp();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btnNotEqual_Click(object sender, EventArgs e)
        {
            CmpDAC cDAC = new CmpDAC();
            if (txtCmpID.Text != "")
            {
                if (cDAC.isExist(txtCmpID.Text))
                {
                    MessageBox.Show("존재하는 ID 입니다.");
                }
                else
                {
                    MessageBox.Show("사용가능");
                    btnInsertCmp.Enabled = true;
                    txtCmpID.ReadOnly = true;
                    
                }
            }
            else
            {
                MessageBox.Show("아이디를 입력 해주세요.");
            }
        }

        private void SumTotincome()
        {
            int sum = 0;
            for (int i = 0; i < dgvCmp.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvCmp.Rows[i].Cells[3].Value);
            }
            txtIncome.Text = String.Format("{0:#,0}", sum);
        }
        #endregion

        #region A3) AS관리 탭
        private void DataLoadASAD()
        {
            AsDAC dac = new AsDAC();
            dgvASMgmt.DataSource = dac.GetAllAtAD().DefaultView;
            dac.Dispose();

        }

        private void chkIng_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIng.Checked)
            {
                chkComplete.Checked = false;
            }
        }

        private void chkComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (chkComplete.Checked)
            {
                chkIng.Checked = false;
            }
        }

        private void btnSearchASAD_Click(object sender, EventArgs e)
        {
            string code;

            if (chkIng.Checked)
            {
                code = "notAsp06";
            }

            else
            {
                code = "Asp06";
            }
            AsDAC dac = new AsDAC();
            dgvASMgmt.DataSource = dac.GetSearchASAD(cmbCmpName.Text, code, ucDatePicker1.FromDate.ToString("yyyy-MM-dd"), ucDatePicker1.ToDate.ToString("yyyy-MM-dd")).DefaultView;
            dac.Dispose();
            
        }

        private void dgvASMgmt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblAsNo.Text = dgvASMgmt[0, dgvASMgmt.CurrentRow.Index].Value.ToString();
            AsDAC dac = new AsDAC();
            txtBltCmpNum.Text = dac.PrintNum(dgvASMgmt[2, dgvASMgmt.CurrentRow.Index].Value.ToString());
        }

        private void btnChangeSt_Click(object sender, EventArgs e)
        {
            CommonDAC cDAC = new CommonDAC();
            AsDAC aDAC = new AsDAC();

            aDAC.ChangeStatus(loginCmp.CmpID, lblAsNo.Text, cDAC.GetCode(cmbStatus.Text));

            DataLoadASAD();
        }

        private void btnExcelAsmg_Click(object sender, EventArgs e)
        {
            getExcelFile(dgvASMgmt);
        }

        private void btnChart_Click(object sender, EventArgs e)
        {

            FormChart frm = new FormChart();

            frm.Show();

        }

        #endregion

        #region C1) 직원관리 탭

        private void cmbEmpEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpEmail.Text == "직접입력")
            {
                txtVEmail.Visible = true;
                cmbEmpEmail.Location = new Point(360, 149);
                txtVEmail.Focus();
            }
            else
            {
                txtVEmail.Visible = false;
                cmbEmpEmail.Location = txtVEmail.Location;
            }
        }
        private void DataLoadEmp()
        {
            
                EmpDAC emp = new EmpDAC();
            if (loginCmp != null)
            {
                dgvEmp.DataSource = emp.GetAll(loginCmp.CmpID.ToString()).DefaultView;
                emp.Dispose();
            }
            
        }
        private void btnInsertEmp_Click(object sender, EventArgs e)
        {
            try
            {
                Emp myemp = new Emp();

                myemp.CmpID = loginCmp.CmpID;
                myemp.EmpNo = Convert.ToInt32(txtEmpNum.Text);
                myemp.EmpName = txtEmpName.Text;
                myemp.BirthDate = dtpBirthDate.Value.ToString("yyyy-MM-dd");
                myemp.Phone = EmNum_1.SelectedItem + "-" + EmNum_2.Text + "-" + EmNum_3.Text;
                if (cmbEmpEmail.Text == "직접입력")
                {
                    myemp.Email = txtEmpEmail.Text + "@" + txtVEmail.Text;
                }
                else
                {
                    myemp.Email = txtEmpEmail.Text + "@" + cmbEmpEmail.SelectedItem;
                }
                EmpDAC emp = new EmpDAC();
                emp.Insert(myemp);
                emp.Dispose();

                DataLoadEmp();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            Emp myemp = new Emp();

            myemp.CmpID = loginCmp.CmpID;
            myemp.EmpNo = Convert.ToInt32(txtEmpNum.Text);
            myemp.EmpName = txtEmpName.Text;
            myemp.BirthDate = dtpBirthDate.Value.ToString("yyyy-MM-dd");
            myemp.Phone = EmNum_1.Text + "-" + EmNum_2.Text + "-" + EmNum_3.Text;
            if (cmbEmpEmail.Text == "직접입력")
            {
                myemp.Email = txtEmpEmail.Text + "@" + txtVEmail.Text;
            }
            else
            {
                myemp.Email = txtEmpEmail.Text + "@" + cmbEmpEmail.SelectedItem;
            }

            EmpDAC emp = new EmpDAC();
            emp.Update(myemp);
            emp.Dispose();

            DataLoadEmp();

        }

        private void dgvEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmpNum.ReadOnly = true;
            int rldx = dgvEmp.CurrentRow.Index;

            txtEmpNum.Text = dgvEmp[0, rldx].Value.ToString();
            txtEmpName.Text = dgvEmp[1, rldx].Value.ToString();
            dtpBirthDate.Value = (DateTime)dgvEmp[2, rldx].Value;
            string[] split = dgvEmp[3, rldx].Value.ToString().Split('-');
            if (split.Length > 2)
            {
                EmNum_1.SelectedItem = split[0];
                EmNum_2.Text = split[1];
                EmNum_3.Text = split[2];
            }
            string[] split2 = dgvEmp[4, rldx].Value.ToString().Split('@');
            if (split2.Length > 1)
            {
                txtEmpEmail.Text = split2[0];
                cmbEmpEmail.SelectedItem = split2[1];
            }


        }

        private void btnSearchEmp_Click(object sender, EventArgs e)
        {
            txtEmpNum.ReadOnly = false;
            txtEmpNum.Text = txtEmpName.Text = EmNum_2.Text = EmNum_3.Text = txtEmpEmail.Text = "";
            dtpBirthDate.Value = DateTime.Now;

            if (txtSearchEmp.Text == "")
            {
                cmbSearchEmp.SelectedItem = "사번";
                EmNum_1.SelectedItem = "010";
                cmbEmpEmail.SelectedItem = "naver.com";
                DataLoadEmp();
            }
            else
            {
                EmpDAC emp = new EmpDAC();

                dgvEmp.DataSource = emp.GetSearchEmp(cmbSearchEmp.SelectedItem.ToString(), txtSearchEmp.Text.Trim(), loginCmp.CmpID.ToString());
                emp.Dispose();
            }

        }

        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("정말 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (DialogResult == DialogResult.Yes)
            {
                EmpDAC emp = new EmpDAC();
                emp.Delete(Convert.ToInt32(txtEmpNum.Text));
                emp.Dispose();
                MessageBox.Show("삭제 완료", "알림");

                DataLoadEmp();
            }
        }

        #endregion

        #region C2) 렌탈관리 탭 (AS접수버튼 포함)
        private void SumTotPrice()
        {
            int sum = 0;
            for (int i = 0; i < dgvRentaling.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvRentaling.Rows[i].Cells[7].Value);
            }
            txtTotPrice.Text =  String.Format("{0:#,0}", sum);
        }

        private void DataLoadRTing()
        {
            if (loginCmp != null)
            {
                RentalDAC rent = new RentalDAC();
                dgvRentaling.DataSource = rent.GetRentalAll(loginCmp.CmpID).DefaultView;
                rent.Dispose();
            }
        }

        private void btnNewRental_Click(object sender, EventArgs e)
        {
            frmCuNew frm = new frmCuNew();
            frm.CmpID = loginCmp.CmpID;

            if(frm.ShowDialog() == DialogResult.OK)
            {
                RentalDAC db = new RentalDAC();
                db.RentalPrd(this.loginCmp.CmpID, frm.EmpID, frm.SelectedPrdID);
                db.Dispose();
                DataLoadRTing();
                SumTotPrice();
            }
        }

        

        private void dgvRentaling_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rldx = dgvRentaling.CurrentRow.Index;


            label29.Text = dgvRentaling[0, rldx].Value.ToString();
            txtSelEmpID.Text = dgvRentaling[3, rldx].Value.ToString();

            imgDAC dac = new imgDAC();
            RentalingPB.ImageLocation = dac.GetFilePath(dgvRentaling[1, dgvRentaling.CurrentRow.Index].Value.ToString());
            dac.Dispose();

        }

        

        private void buttonQuitRT_Click(object sender, EventArgs e)
        {
            if (label29.Text == "")
            {
                MessageBox.Show("선택된 렌탈 건이 없습니다.");
            }
            else
            {
                DialogResult result = MessageBox.Show("정말 해지하시겠습니까?", "해지확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    RentalDAC db = new RentalDAC();
                    db.QuitRental(label29.Text);
                    DataLoadRTing();
                    SumTotPrice();
                }
            }
        }

        private void btnChgEmp_Click(object sender, EventArgs e)
        {
            if (label29.Text == "")
            {
                MessageBox.Show("선택된 렌탈 건이 없습니다.");
            }
            else
            {
                EmpDAC dac = new EmpDAC();
                if (dac.isVaild(loginCmp.CmpID, txtSelEmpID.Text))
                {
                    RentalDAC db = new RentalDAC();
                    db.ChangeEmp(loginCmp.CmpID, label29.Text, Convert.ToInt32(txtSelEmpID.Text));
                    DataLoadRTing();
                }
                else
                {
                    MessageBox.Show("유효하지 않은 사번입니다.");
                }
            }
        }

        private void btnNewAS_Click(object sender, EventArgs e)
        {
            if (label29.Text == "")
            {
                MessageBox.Show("선택된 렌탈 건이 없습니다.");
            }
            else
            {

                AsDAC dac = new AsDAC();
                if (dac.isProcessing(label29.Text))
                {
                    MessageBox.Show("이미 A/S 진행중인 제품입니다.");
                    return;
                }
                else
                {
                    frmCuAS frm = new frmCuAS(loginCmp, label29.Text);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("접수 되었습니다.");
                    }
                }
            }
        }

        private void txtTotPrice_TextChanged(object sender, EventArgs e)
        {
            if (loginCmp != null && loginCmp.CmpID != "Admin" )
            {
                RentalDAC rdac = new RentalDAC();
                rdac.UpdateTot(loginCmp.CmpID, Convert.ToInt32(txtTotPrice.Text.Replace(",","")));
                rdac.Dispose();
            }
        }

        private void btnSearchRTCu_Click(object sender, EventArgs e)
        {
            if (txtSearchValue.Text == "")
            {
                DataLoadRTing();
            }
            else
            {
                RentalDAC dac = new RentalDAC();
                dgvRentaling.DataSource = dac.SearchRental(loginCmp.CmpID, cmbSearch.Text, Convert.ToInt32(txtSearchValue.Text));
                dac.Dispose();
            }
        }

        private void btnExcelDl_Click(object sender, EventArgs e)
        {
            getExcelFile(dgvRentaling);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            frmChgLog frm = new frmChgLog();
            frm.CmpID = loginCmp.CmpID;
            frm.Show();
        }
        #endregion

        #region C3) AS현황 탭
        private void DataLoadASCU()
        {
            if (loginCmp != null)
            {
                AsDAC dac = new AsDAC();
                dgvASCU.DataSource = dac.GetAllAtCU(loginCmp.CmpID).DefaultView;
                dac.Dispose();
            }
        }

        private void chkIngCu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIngCu.Checked)
            {
                chkCompCu.Checked = false;
            }
        }

        private void chkCompCu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompCu.Checked)
            {
                chkIngCu.Checked = false;
            }
        }

        private void btnSearchASCU_Click(object sender, EventArgs e)
        {
            string code;

            if (chkIngCu.Checked)
            {
                code = "notAsp06";
            }

            else
            {
                code = "Asp06";
            }

            AsDAC dac = new AsDAC();
            dgvASCU.DataSource = dac.GetSearchASCU(loginCmp.CmpID, code, ucDatePicker2.FromDate.ToString("yyyy-MM-dd"), ucDatePicker2.ToDate.ToString("yyyy-MM-dd"));
            dac.Dispose();

        }

        #endregion


        #region 엑셀파일 저장 함수 = getExcelFile(dgv 이름)
        private void getExcelFile(DataGridView dgv)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel Files(*.xls)|*.xls";
            dlg.Title = "엑셀파일로 내보내기";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                //DataTable dt = (DataTable)dgv.DataSource; 오류로 개별함수 사용
                DataTable dt = GetDataGridViewAsDataTable(dgv);





                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    xlWorkSheet.Cells[1, c + 1] = dt.Columns[c].ColumnName;
                }

                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        xlWorkSheet.Cells[r + 2, c + 1] = dt.Rows[r][c].ToString();
                    }
                }

                xlWorkBook.SaveAs(dlg.FileName, Excel.XlFileFormat.xlWorkbookNormal);
                xlWorkBook.Close(true);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("엑셀 다운로드 완료");

            }


        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }



        public static DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView) //그리드뷰 소스를 DataTable로
        {
            try
            {
                if (_DataGridView.ColumnCount == 0)
                    return null;
                DataTable dtSource = new DataTable();
                // 컬럼 만듦
                foreach (DataGridViewColumn col in _DataGridView.Columns)
                {
                    if (col.ValueType == null)
                        dtSource.Columns.Add(col.Name, typeof(string));
                    else
                        dtSource.Columns.Add(col.Name, col.ValueType);
                    dtSource.Columns[col.Name].Caption = col.HeaderText;
                }
                // 열 데이터 삽입
                foreach (DataGridViewRow row in _DataGridView.Rows)
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                return dtSource;
            }
            catch
            {
                return null;
            }
        }





        #endregion

        
    }

}