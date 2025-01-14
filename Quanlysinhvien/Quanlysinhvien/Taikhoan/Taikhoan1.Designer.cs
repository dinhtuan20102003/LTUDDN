namespace Quanlysinhvien.Taikhoan
{
    partial class Taikhoan1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdogv = new System.Windows.Forms.RadioButton();
            this.rdotk = new System.Windows.Forms.RadioButton();
            this.rdond = new System.Windows.Forms.RadioButton();
            this.rdoadmin = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdokhd = new System.Windows.Forms.RadioButton();
            this.rdohd = new System.Windows.Forms.RadioButton();
            this.txttendd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkanhien = new System.Windows.Forms.CheckBox();
            this.btndong = new System.Windows.Forms.Button();
            this.btnnl = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.txtmk = new System.Windows.Forms.TextBox();
            this.txttendn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Dgv_taikhoan = new System.Windows.Forms.DataGridView();
            this.tendn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tendd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matkhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chucvu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_taikhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(38, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1327, 62);
            this.panel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(484, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Tài Khoản";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txttendd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkanhien);
            this.groupBox1.Controls.Add(this.btndong);
            this.groupBox1.Controls.Add(this.btnnl);
            this.groupBox1.Controls.Add(this.btnsua);
            this.groupBox1.Controls.Add(this.btnxoa);
            this.groupBox1.Controls.Add(this.btnthem);
            this.groupBox1.Controls.Add(this.txtmk);
            this.groupBox1.Controls.Add(this.txttendn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1330, 355);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdogv);
            this.groupBox2.Controls.Add(this.rdotk);
            this.groupBox2.Controls.Add(this.rdond);
            this.groupBox2.Controls.Add(this.rdoadmin);
            this.groupBox2.Location = new System.Drawing.Point(704, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 232);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức vụ ";
            // 
            // rdogv
            // 
            this.rdogv.AutoSize = true;
            this.rdogv.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdogv.Location = new System.Drawing.Point(29, 183);
            this.rdogv.Name = "rdogv";
            this.rdogv.Size = new System.Drawing.Size(125, 29);
            this.rdogv.TabIndex = 3;
            this.rdogv.TabStop = true;
            this.rdogv.Text = "Giáo viên";
            this.rdogv.UseVisualStyleBackColor = true;
            // 
            // rdotk
            // 
            this.rdotk.AutoSize = true;
            this.rdotk.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdotk.Location = new System.Drawing.Point(29, 136);
            this.rdotk.Name = "rdotk";
            this.rdotk.Size = new System.Drawing.Size(163, 29);
            this.rdotk.TabIndex = 2;
            this.rdotk.TabStop = true;
            this.rdotk.Text = "Trưởng khoa";
            this.rdotk.UseVisualStyleBackColor = true;
            // 
            // rdond
            // 
            this.rdond.AutoSize = true;
            this.rdond.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdond.Location = new System.Drawing.Point(29, 89);
            this.rdond.Name = "rdond";
            this.rdond.Size = new System.Drawing.Size(151, 29);
            this.rdond.TabIndex = 1;
            this.rdond.TabStop = true;
            this.rdond.Text = "Người dùng";
            this.rdond.UseVisualStyleBackColor = true;
            // 
            // rdoadmin
            // 
            this.rdoadmin.AutoSize = true;
            this.rdoadmin.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoadmin.Location = new System.Drawing.Point(29, 42);
            this.rdoadmin.Name = "rdoadmin";
            this.rdoadmin.Size = new System.Drawing.Size(99, 29);
            this.rdoadmin.TabIndex = 0;
            this.rdoadmin.TabStop = true;
            this.rdoadmin.Text = "Admin";
            this.rdoadmin.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdokhd);
            this.groupBox3.Controls.Add(this.rdohd);
            this.groupBox3.Location = new System.Drawing.Point(1014, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 232);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trạng thái hoạt động";
            // 
            // rdokhd
            // 
            this.rdokhd.AutoSize = true;
            this.rdokhd.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdokhd.Location = new System.Drawing.Point(29, 92);
            this.rdokhd.Name = "rdokhd";
            this.rdokhd.Size = new System.Drawing.Size(88, 29);
            this.rdokhd.TabIndex = 1;
            this.rdokhd.TabStop = true;
            this.rdokhd.Text = "Khóa";
            this.rdokhd.UseVisualStyleBackColor = true;
            // 
            // rdohd
            // 
            this.rdohd.AutoSize = true;
            this.rdohd.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdohd.Location = new System.Drawing.Point(29, 45);
            this.rdohd.Name = "rdohd";
            this.rdohd.Size = new System.Drawing.Size(132, 29);
            this.rdohd.TabIndex = 0;
            this.rdohd.TabStop = true;
            this.rdohd.Text = "Kích hoạt";
            this.rdohd.UseVisualStyleBackColor = true;
            // 
            // txttendd
            // 
            this.txttendd.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttendd.Location = new System.Drawing.Point(266, 120);
            this.txttendd.Name = "txttendd";
            this.txttendd.Size = new System.Drawing.Size(387, 34);
            this.txttendd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = " Tên đầy đủ";
            // 
            // chkanhien
            // 
            this.chkanhien.AutoSize = true;
            this.chkanhien.Location = new System.Drawing.Point(542, 231);
            this.chkanhien.Name = "chkanhien";
            this.chkanhien.Size = new System.Drawing.Size(111, 30);
            this.chkanhien.TabIndex = 10;
            this.chkanhien.Text = "Hiện/Ẩn";
            this.chkanhien.UseVisualStyleBackColor = true;
            this.chkanhien.CheckedChanged += new System.EventHandler(this.chkanhien_CheckedChanged);
            // 
            // btndong
            // 
            this.btndong.BackColor = System.Drawing.Color.White;
            this.btndong.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndong.Location = new System.Drawing.Point(891, 292);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(121, 41);
            this.btndong.TabIndex = 9;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = false;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnnl
            // 
            this.btnnl.BackColor = System.Drawing.Color.White;
            this.btnnl.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnl.Location = new System.Drawing.Point(751, 292);
            this.btnnl.Name = "btnnl";
            this.btnnl.Size = new System.Drawing.Size(121, 41);
            this.btnnl.TabIndex = 8;
            this.btnnl.Text = "Nhập lại";
            this.btnnl.UseVisualStyleBackColor = false;
            this.btnnl.Click += new System.EventHandler(this.btnnl_Click);
            // 
            // btnsua
            // 
            this.btnsua.BackColor = System.Drawing.Color.White;
            this.btnsua.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.Location = new System.Drawing.Point(461, 292);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(121, 41);
            this.btnsua.TabIndex = 6;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = false;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.Color.White;
            this.btnxoa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Location = new System.Drawing.Point(607, 292);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(121, 41);
            this.btnxoa.TabIndex = 7;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = false;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.White;
            this.btnthem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthem.Location = new System.Drawing.Point(319, 292);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(121, 41);
            this.btnthem.TabIndex = 5;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // txtmk
            // 
            this.txtmk.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmk.Location = new System.Drawing.Point(266, 184);
            this.txtmk.Name = "txtmk";
            this.txtmk.Size = new System.Drawing.Size(387, 34);
            this.txtmk.TabIndex = 2;
            this.txtmk.UseSystemPasswordChar = true;
            // 
            // txttendn
            // 
            this.txttendn.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttendn.Location = new System.Drawing.Point(266, 61);
            this.txttendn.Name = "txttendn";
            this.txttendn.Size = new System.Drawing.Size(387, 34);
            this.txttendn.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = " Tên đăng nhập";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Dgv_taikhoan);
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(35, 510);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1330, 312);
            this.panel2.TabIndex = 26;
            // 
            // Dgv_taikhoan
            // 
            this.Dgv_taikhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_taikhoan.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_taikhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_taikhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_taikhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tendn,
            this.tendd,
            this.matkhau,
            this.chucvu,
            this.trangthai});
            this.Dgv_taikhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_taikhoan.Location = new System.Drawing.Point(0, 0);
            this.Dgv_taikhoan.Name = "Dgv_taikhoan";
            this.Dgv_taikhoan.ReadOnly = true;
            this.Dgv_taikhoan.RowHeadersWidth = 51;
            this.Dgv_taikhoan.RowTemplate.Height = 24;
            this.Dgv_taikhoan.Size = new System.Drawing.Size(1330, 312);
            this.Dgv_taikhoan.TabIndex = 20;
            this.Dgv_taikhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_taikhoan_CellClick);
            // 
            // tendn
            // 
            this.tendn.DataPropertyName = "tendn";
            this.tendn.HeaderText = "Tên đăng nhập";
            this.tendn.MinimumWidth = 6;
            this.tendn.Name = "tendn";
            this.tendn.ReadOnly = true;
            // 
            // tendd
            // 
            this.tendd.DataPropertyName = "tendd";
            this.tendd.HeaderText = "Tên đầy đủ";
            this.tendd.MinimumWidth = 6;
            this.tendd.Name = "tendd";
            this.tendd.ReadOnly = true;
            // 
            // matkhau
            // 
            this.matkhau.DataPropertyName = "matkhau";
            this.matkhau.HeaderText = "Mật khẩu";
            this.matkhau.MinimumWidth = 6;
            this.matkhau.Name = "matkhau";
            this.matkhau.ReadOnly = true;
            // 
            // chucvu
            // 
            this.chucvu.DataPropertyName = "chucvu";
            this.chucvu.HeaderText = "Chức vụ";
            this.chucvu.MinimumWidth = 6;
            this.chucvu.Name = "chucvu";
            this.chucvu.ReadOnly = true;
            // 
            // trangthai
            // 
            this.trangthai.DataPropertyName = "trangthai";
            this.trangthai.HeaderText = "Trạng thái";
            this.trangthai.MinimumWidth = 6;
            this.trangthai.Name = "trangthai";
            this.trangthai.ReadOnly = true;
            this.trangthai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.trangthai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Taikhoan1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 846);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Taikhoan1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Taikhoan1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_taikhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkanhien;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnnl;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txtmk;
        private System.Windows.Forms.TextBox txttendn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView Dgv_taikhoan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdogv;
        private System.Windows.Forms.RadioButton rdotk;
        private System.Windows.Forms.RadioButton rdond;
        private System.Windows.Forms.RadioButton rdoadmin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txttendd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdokhd;
        private System.Windows.Forms.RadioButton rdohd;
        private System.Windows.Forms.DataGridViewTextBoxColumn tendn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tendd;
        private System.Windows.Forms.DataGridViewTextBoxColumn matkhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn chucvu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn trangthai;
    }
}