namespace SHOPTHUCUNG
{
    partial class EditCTNH
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCTNH));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_dongia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.NumericUpDown();
            this.cboMaNhap = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.bt_sua = new System.Windows.Forms.Button();
            this.bt_xoa = new System.Windows.Forms.Button();
            this.bt_them = new System.Windows.Forms.Button();
            this.bt_reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.number)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Số lượng";
            this.columnHeader11.Width = 87;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Mã sản phẩm";
            this.columnHeader10.Width = 71;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Mã Nhập";
            this.columnHeader9.Width = 84;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(101, 20);
            this.listView2.Margin = new System.Windows.Forms.Padding(2);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(353, 108);
            this.listView2.TabIndex = 63;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Đơn giá";
            this.columnHeader12.Width = 89;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.bt_sua);
            this.groupBox3.Controls.Add(this.bt_xoa);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label);
            this.groupBox3.Controls.Add(this.txtMaSP);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.bt_them);
            this.groupBox3.Controls.Add(this.txt_dongia);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.number);
            this.groupBox3.Controls.Add(this.cboMaNhap);
            this.groupBox3.Controls.Add(this.bt_reset);
            this.groupBox3.Location = new System.Drawing.Point(481, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(316, 113);
            this.groupBox3.TabIndex = 62;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi Tiết Nhập Hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Mã nhập:";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(8, 41);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(39, 13);
            this.label.TabIndex = 30;
            this.label.Text = "Mã SP";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Enabled = false;
            this.txtMaSP.Location = new System.Drawing.Point(74, 41);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(118, 20);
            this.txtMaSP.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 67);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Số Lượng:";
            // 
            // txt_dongia
            // 
            this.txt_dongia.Location = new System.Drawing.Point(74, 88);
            this.txt_dongia.Margin = new System.Windows.Forms.Padding(2);
            this.txt_dongia.Name = "txt_dongia";
            this.txt_dongia.Size = new System.Drawing.Size(119, 20);
            this.txt_dongia.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 92);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Đơn Giá:";
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(74, 65);
            this.number.Margin = new System.Windows.Forms.Padding(2);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(118, 20);
            this.number.TabIndex = 34;
            // 
            // cboMaNhap
            // 
            this.cboMaNhap.FormattingEnabled = true;
            this.cboMaNhap.Location = new System.Drawing.Point(74, 15);
            this.cboMaNhap.Margin = new System.Windows.Forms.Padding(2);
            this.cboMaNhap.Name = "cboMaNhap";
            this.cboMaNhap.Size = new System.Drawing.Size(119, 21);
            this.cboMaNhap.TabIndex = 31;
            this.cboMaNhap.SelectedIndexChanged += new System.EventHandler(this.cboMaNhap_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(90, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(698, 158);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sản Phẩm";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(11, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(674, 133);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã sản phẩm";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên sản phẩm";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hình ảnh";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số lượng";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Giá";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Trình trạng";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Mô tả";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Loại sản phẩm";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(719, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 45);
            this.button1.TabIndex = 64;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_sua
            // 
            this.bt_sua.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bt_sua.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_sua.BackgroundImage")));
            this.bt_sua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_sua.Location = new System.Drawing.Point(212, 56);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(48, 41);
            this.bt_sua.TabIndex = 61;
            this.bt_sua.UseVisualStyleBackColor = true;
            this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
            // 
            // bt_xoa
            // 
            this.bt_xoa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_xoa.BackgroundImage")));
            this.bt_xoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_xoa.FlatAppearance.BorderSize = 0;
            this.bt_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_xoa.Location = new System.Drawing.Point(255, 14);
            this.bt_xoa.Name = "bt_xoa";
            this.bt_xoa.Size = new System.Drawing.Size(48, 41);
            this.bt_xoa.TabIndex = 56;
            this.bt_xoa.UseVisualStyleBackColor = true;
            this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click);
            // 
            // bt_them
            // 
            this.bt_them.BackColor = System.Drawing.Color.Transparent;
            this.bt_them.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_them.BackgroundImage")));
            this.bt_them.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_them.FlatAppearance.BorderSize = 0;
            this.bt_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_them.Location = new System.Drawing.Point(212, 15);
            this.bt_them.Margin = new System.Windows.Forms.Padding(2);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(44, 39);
            this.bt_them.TabIndex = 47;
            this.bt_them.UseVisualStyleBackColor = false;
            this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
            // 
            // bt_reset
            // 
            this.bt_reset.BackColor = System.Drawing.Color.Transparent;
            this.bt_reset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_reset.BackgroundImage")));
            this.bt_reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_reset.FlatAppearance.BorderSize = 0;
            this.bt_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_reset.Location = new System.Drawing.Point(260, 58);
            this.bt_reset.Margin = new System.Windows.Forms.Padding(2);
            this.bt_reset.Name = "bt_reset";
            this.bt_reset.Size = new System.Drawing.Size(43, 37);
            this.bt_reset.TabIndex = 44;
            this.bt_reset.UseVisualStyleBackColor = false;
            this.bt_reset.Click += new System.EventHandler(this.bt_reset_Click);
            // 
            // EditCTNH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(879, 359);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "EditCTNH";
            this.Text = "EditCTNH";
            this.Load += new System.EventHandler(this.EditCTNH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.number)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_sua;
        private System.Windows.Forms.Button bt_xoa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bt_them;
        private System.Windows.Forms.TextBox txt_dongia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown number;
        private System.Windows.Forms.ComboBox cboMaNhap;
        private System.Windows.Forms.Button bt_reset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}