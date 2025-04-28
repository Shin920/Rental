using Rental.DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental
{
    public partial class AddImage : Form
    {
        
        public AddImage(string pname)
        {
            InitializeComponent();

            
            textBox1.Text = pname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images Files(*.gif;*.jpg;*jpeg;*.png;*.bmp)|*.gif;*.jpg;*.jpeg;*.png;*bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dlg.FileName;
                pictureBox1.Image = Image.FromFile(dlg.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Tag = dlg.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sPath = ConfigurationManager.AppSettings["uploadPath"] + ProductName + "/";
                string localFile = pictureBox1.Tag.ToString();
                string sExt = localFile.Substring(localFile.LastIndexOf("."));
                //string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + sExt;
                string newFileName = textBox1.Text + sExt;
                string destFileName = sPath + newFileName;
                //디렉토리가 없다면 생성
                if (!Directory.Exists(sPath))
                {
                    Directory.CreateDirectory(sPath);
                }
                //파일복사 (다른이름저장)
                File.Copy(localFile, destFileName, true);

                //DB에 파일경로 저장
                imgDAC dac = new imgDAC();
                bool result = dac.AddProductImage(textBox1.Text, destFileName);
                if (result)
                {
                    MessageBox.Show("이미지 추가가 완료되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("이미지 저장에 실패하였습니다. 다시 시도하여 주십시오.");
                }

            }

            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
            //BLOB 실패
            //try
            //{
            //    byte[] imageData;

            //    using (FileStream fs = new FileStream(pictureBox1.Tag.ToString(), FileMode.Open, FileAccess.Read))
            //    {
            //        BinaryReader br = new BinaryReader(fs);
            //        imageData = br.ReadBytes((int)fs.Length);
            //        br.Close();
            //    }

            //    imgDAC dac = new imgDAC();
            //    bool result = dac.AddProductBLOBImage(textBox1.Text, imageData);
            //    if (result)
            //    {
            //        MessageBox.Show("이미지 추가가 완료되었습니다.");
            //        this.DialogResult = DialogResult.OK;
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("이미지 저장에 실패하였습니다. 다시 시도하여 주십시오.");
            //    }

            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}


        }
    }
}
