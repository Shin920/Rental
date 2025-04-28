using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using Rental.DAC;
using Microsoft.Win32;


namespace Rental
{
    public partial class frmLogin : Form
    {

        public Cmp LoginCmpInfo { get; set; }


        string strConn = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Convert.ToBoolean(RegistryHelp.ReadRegKey("Software\\Gudi\\PersonalProject", "userSaveCheck", 0));

            txtCmpID.Text = RegistryHelp.ReadRegKey("Software\\Gudi\\PersonalProject", "userid", "").ToString();

        }


        private void button1_Click(object sender, EventArgs e) // 로그인 버튼
        {
            if (String.IsNullOrEmpty(txtCmpID.Text))
            {
                MessageBox.Show(this, Properties.Resources.MSG_LOGIN_IDNULL, "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                       
            try
            {
                CmpDAC cDac = new CmpDAC();

                LoginCmpInfo = cDac.GetCmpInfo(txtCmpID.Text);

                if (LoginCmpInfo != null && LoginCmpInfo.Password == txtCmpPW.Text) 
                {
                    if(checkBox1.Checked)
                    {
                        RegistryHelp.WriteRegKey("Software\\Gudi\\PersonalProject", "userSaveCheck", 1);
                        RegistryHelp.WriteRegKey("Software\\Gudi\\PersonalProject", "userid", txtCmpID.Text);

                    }
                    else
                    {
                        RegistryHelp.WriteRegKey("Software\\Gudi\\PersonalProject", "userSaveCheck", 0);
                        RegistryHelp.WriteRegKey("Software\\Gudi\\PersonalProject", "userid", "");
                    }

                    
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, Properties.Resources.MSG_LOGIN_NOTVAILD);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(this, err.Message, Properties.Resources.MSG_LOGIN_FAILD, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                      
       

        private void txtCmpPW_TextChanged(object sender, EventArgs e)
        {
            if (txtCmpPW.Text.Length != 0)
                txtCmpPW.PasswordChar = '*';
            else
                txtCmpPW.PasswordChar = '\0';
        }
    }
}
