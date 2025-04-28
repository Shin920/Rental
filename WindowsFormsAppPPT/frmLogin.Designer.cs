
namespace Rental
{
    partial class frmLogin
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtCmpPW = new WinReflectionSettings.PlaceholderTextBox();
            this.txtCmpID = new WinReflectionSettings.PlaceholderTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(83, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "렌탈 관리 시스템";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "계정 정보 문의   070-000-0000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "로그인(&L)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(238, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "닫기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(338, 148);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "아이디 저장";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtCmpPW
            // 
            this.txtCmpPW.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCmpPW.Location = new System.Drawing.Point(133, 139);
            this.txtCmpPW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCmpPW.Name = "txtCmpPW";
            this.txtCmpPW.PlaceholderText = "Password";
            this.txtCmpPW.PlaceholderTextColor = System.Drawing.SystemColors.WindowFrame;
            this.txtCmpPW.Size = new System.Drawing.Size(179, 26);
            this.txtCmpPW.TabIndex = 9;
            this.txtCmpPW.TextChanged += new System.EventHandler(this.txtCmpPW_TextChanged);
            // 
            // txtCmpID
            // 
            this.txtCmpID.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCmpID.Location = new System.Drawing.Point(133, 97);
            this.txtCmpID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCmpID.Name = "txtCmpID";
            this.txtCmpID.PlaceholderText = "Company ID";
            this.txtCmpID.PlaceholderTextColor = System.Drawing.SystemColors.WindowFrame;
            this.txtCmpID.Size = new System.Drawing.Size(179, 26);
            this.txtCmpID.TabIndex = 8;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(458, 297);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtCmpPW);
            this.Controls.Add(this.txtCmpID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private WinReflectionSettings.PlaceholderTextBox txtCmpID;
        private WinReflectionSettings.PlaceholderTextBox txtCmpPW;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

