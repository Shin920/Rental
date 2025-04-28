
namespace Rental
{
    partial class frmCuAS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbASCC = new System.Windows.Forms.ComboBox();
            this.txtdetail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNewASOk = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCmpName = new System.Windows.Forms.Label();
            this.lblPrdName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnASCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(50, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "접수 구분";
            // 
            // cmbASCC
            // 
            this.cmbASCC.FormattingEnabled = true;
            this.cmbASCC.Location = new System.Drawing.Point(139, 109);
            this.cmbASCC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbASCC.Name = "cmbASCC";
            this.cmbASCC.Size = new System.Drawing.Size(161, 23);
            this.cmbASCC.TabIndex = 1;
            // 
            // txtdetail
            // 
            this.txtdetail.Location = new System.Drawing.Point(50, 209);
            this.txtdetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdetail.Multiline = true;
            this.txtdetail.Name = "txtdetail";
            this.txtdetail.Size = new System.Drawing.Size(428, 468);
            this.txtdetail.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(56, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "상세내용";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(50, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "고객사명";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(50, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "제품번호";
            // 
            // btnNewASOk
            // 
            this.btnNewASOk.Location = new System.Drawing.Point(69, 698);
            this.btnNewASOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewASOk.Name = "btnNewASOk";
            this.btnNewASOk.Size = new System.Drawing.Size(168, 35);
            this.btnNewASOk.TabIndex = 9;
            this.btnNewASOk.Text = "신청완료";
            this.btnNewASOk.UseVisualStyleBackColor = true;
            this.btnNewASOk.Click += new System.EventHandler(this.btnNewASOk_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(318, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "접수날짜";
            // 
            // lblCmpName
            // 
            this.lblCmpName.AutoSize = true;
            this.lblCmpName.Location = new System.Drawing.Point(127, 30);
            this.lblCmpName.Name = "lblCmpName";
            this.lblCmpName.Size = new System.Drawing.Size(45, 15);
            this.lblCmpName.TabIndex = 11;
            this.lblCmpName.Text = "label5";
            // 
            // lblPrdName
            // 
            this.lblPrdName.AutoSize = true;
            this.lblPrdName.Location = new System.Drawing.Point(127, 66);
            this.lblPrdName.Name = "lblPrdName";
            this.lblPrdName.Size = new System.Drawing.Size(45, 15);
            this.lblPrdName.TabIndex = 12;
            this.lblPrdName.Text = "label6";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(395, 32);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 15);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "label7";
            // 
            // btnASCancel
            // 
            this.btnASCancel.Location = new System.Drawing.Point(272, 698);
            this.btnASCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnASCancel.Name = "btnASCancel";
            this.btnASCancel.Size = new System.Drawing.Size(168, 35);
            this.btnASCancel.TabIndex = 14;
            this.btnASCancel.Text = "닫기";
            this.btnASCancel.UseVisualStyleBackColor = true;
            this.btnASCancel.Click += new System.EventHandler(this.btnASCancel_Click);
            // 
            // frmCuAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 760);
            this.Controls.Add(this.btnASCancel);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblPrdName);
            this.Controls.Add(this.lblCmpName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnNewASOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdetail);
            this.Controls.Add(this.cmbASCC);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmCuAS";
            this.Text = "frmCuAS";
            this.Load += new System.EventHandler(this.frmCuAS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbASCC;
        private System.Windows.Forms.TextBox txtdetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNewASOk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCmpName;
        private System.Windows.Forms.Label lblPrdName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnASCancel;
    }
}