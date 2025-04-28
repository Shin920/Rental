
namespace Rental
{
    partial class frmCuNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRentalable = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbCartPrd = new System.Windows.Forms.ListBox();
            this.btnAddPrd = new System.Windows.Forms.Button();
            this.btnDelPrd = new System.Windows.Forms.Button();
            this.btnStartRT = new System.Windows.Forms.Button();
            this.txtPrdID = new System.Windows.Forms.TextBox();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKinds = new System.Windows.Forms.ComboBox();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.NewRenPB = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEmpList = new System.Windows.Forms.Button();
            this.MySpread01 = new FarPoint.Win.Spread.FpSpread();
            this.MySpread01_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalable)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewRenPB)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MySpread01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MySpread01_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.MySpread01);
            this.groupBox1.Controls.Add(this.dgvRentalable);
            this.groupBox1.Location = new System.Drawing.Point(13, 59);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(650, 209);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "제품 목록";
            // 
            // dgvRentalable
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRentalable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRentalable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRentalable.Location = new System.Drawing.Point(3, 16);
            this.dgvRentalable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRentalable.Name = "dgvRentalable";
            this.dgvRentalable.RowHeadersWidth = 51;
            this.dgvRentalable.RowTemplate.Height = 27;
            this.dgvRentalable.Size = new System.Drawing.Size(644, 191);
            this.dgvRentalable.TabIndex = 0;
            this.dgvRentalable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRentalable_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lbCartPrd);
            this.groupBox2.Location = new System.Drawing.Point(10, 271);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(849, 201);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "선택 목록";
            // 
            // lbCartPrd
            // 
            this.lbCartPrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCartPrd.FormattingEnabled = true;
            this.lbCartPrd.ItemHeight = 12;
            this.lbCartPrd.Location = new System.Drawing.Point(3, 16);
            this.lbCartPrd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbCartPrd.Name = "lbCartPrd";
            this.lbCartPrd.Size = new System.Drawing.Size(843, 183);
            this.lbCartPrd.TabIndex = 1;
            // 
            // btnAddPrd
            // 
            this.btnAddPrd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddPrd.Location = new System.Drawing.Point(221, 494);
            this.btnAddPrd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddPrd.Name = "btnAddPrd";
            this.btnAddPrd.Size = new System.Drawing.Size(132, 26);
            this.btnAddPrd.TabIndex = 57;
            this.btnAddPrd.Text = "추가(&A)";
            this.btnAddPrd.UseVisualStyleBackColor = true;
            this.btnAddPrd.Click += new System.EventHandler(this.btnAddPrd_Click);
            // 
            // btnDelPrd
            // 
            this.btnDelPrd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelPrd.Location = new System.Drawing.Point(371, 494);
            this.btnDelPrd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelPrd.Name = "btnDelPrd";
            this.btnDelPrd.Size = new System.Drawing.Size(132, 26);
            this.btnDelPrd.TabIndex = 58;
            this.btnDelPrd.Text = "삭제(&D)";
            this.btnDelPrd.UseVisualStyleBackColor = true;
            this.btnDelPrd.Click += new System.EventHandler(this.btnDelPrd_Click);
            // 
            // btnStartRT
            // 
            this.btnStartRT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStartRT.Location = new System.Drawing.Point(349, 536);
            this.btnStartRT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartRT.Name = "btnStartRT";
            this.btnStartRT.Size = new System.Drawing.Size(167, 44);
            this.btnStartRT.TabIndex = 59;
            this.btnStartRT.Text = "결정(&E)";
            this.btnStartRT.UseVisualStyleBackColor = true;
            this.btnStartRT.Click += new System.EventHandler(this.btnStartRT_Click);
            // 
            // txtPrdID
            // 
            this.txtPrdID.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPrdID.Location = new System.Drawing.Point(85, 498);
            this.txtPrdID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrdID.Name = "txtPrdID";
            this.txtPrdID.Size = new System.Drawing.Size(112, 21);
            this.txtPrdID.TabIndex = 60;
            // 
            // txtEmpID
            // 
            this.txtEmpID.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEmpID.Location = new System.Drawing.Point(605, 496);
            this.txtEmpID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(116, 21);
            this.txtEmpID.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(519, 498);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 62;
            this.label1.Text = "사용자 사번";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(13, 501);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 63;
            this.label2.Text = "제품 번호";
            // 
            // cmbKinds
            // 
            this.cmbKinds.FormattingEnabled = true;
            this.cmbKinds.Items.AddRange(new object[] {
            "제품명",
            "구분",
            "제조사"});
            this.cmbKinds.Location = new System.Drawing.Point(303, 29);
            this.cmbKinds.Name = "cmbKinds";
            this.cmbKinds.Size = new System.Drawing.Size(90, 20);
            this.cmbKinds.TabIndex = 64;
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(403, 29);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(145, 21);
            this.txtSearchValue.TabIndex = 65;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(564, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 23);
            this.btnSearch.TabIndex = 66;
            this.btnSearch.Text = "조회(&S)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // NewRenPB
            // 
            this.NewRenPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewRenPB.Location = new System.Drawing.Point(3, 16);
            this.NewRenPB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewRenPB.Name = "NewRenPB";
            this.NewRenPB.Size = new System.Drawing.Size(182, 191);
            this.NewRenPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NewRenPB.TabIndex = 67;
            this.NewRenPB.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.NewRenPB);
            this.groupBox3.Location = new System.Drawing.Point(668, 59);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(188, 209);
            this.groupBox3.TabIndex = 68;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "이미지";
            // 
            // btnEmpList
            // 
            this.btnEmpList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEmpList.Location = new System.Drawing.Point(736, 493);
            this.btnEmpList.Name = "btnEmpList";
            this.btnEmpList.Size = new System.Drawing.Size(102, 24);
            this.btnEmpList.TabIndex = 69;
            this.btnEmpList.Text = "목록(&L)";
            this.btnEmpList.UseVisualStyleBackColor = true;
            this.btnEmpList.Click += new System.EventHandler(this.btnEmpList_Click);
            // 
            // MySpread01
            // 
            this.MySpread01.About = "4.0.2001.2005";
            this.MySpread01.AccessibleDescription = "";
            this.MySpread01.Location = new System.Drawing.Point(83, 33);
            this.MySpread01.Name = "MySpread01";
            this.MySpread01.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.MySpread01_Sheet1});
            this.MySpread01.Size = new System.Drawing.Size(530, 156);
            this.MySpread01.TabIndex = 70;
            // 
            // MySpread01_Sheet1
            // 
            this.MySpread01_Sheet1.Reset();
            this.MySpread01_Sheet1.SheetName = "Sheet1";
            // 
            // frmCuNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 591);
            this.Controls.Add(this.btnEmpList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.cmbKinds);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmpID);
            this.Controls.Add(this.txtPrdID);
            this.Controls.Add(this.btnStartRT);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDelPrd);
            this.Controls.Add(this.btnAddPrd);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCuNew";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCuNew";
            this.Load += new System.EventHandler(this.frmCuNew_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NewRenPB)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MySpread01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MySpread01_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRentalable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbCartPrd;
        private System.Windows.Forms.Button btnAddPrd;
        private System.Windows.Forms.Button btnDelPrd;
        private System.Windows.Forms.Button btnStartRT;
        private System.Windows.Forms.TextBox txtPrdID;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbKinds;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox NewRenPB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEmpList;
        private FarPoint.Win.Spread.FpSpread MySpread01;
        private FarPoint.Win.Spread.SheetView MySpread01_Sheet1;
    }
}