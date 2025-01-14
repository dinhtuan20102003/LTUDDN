namespace Quanlysinhvien
{
    partial class Batdau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Batdau));
            this.label1 = new System.Windows.Forms.Label();
            this.bt_dn = new System.Windows.Forms.Button();
            this.bt_dk = new System.Windows.Forms.Button();
            this.bt_tt = new System.Windows.Forms.Button();
            this.bt_thoat = new System.Windows.Forms.Button();
            this.Lb_truong = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(245, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Sinh Viên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bt_dn
            // 
            this.bt_dn.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_dn.Location = new System.Drawing.Point(59, 201);
            this.bt_dn.Name = "bt_dn";
            this.bt_dn.Size = new System.Drawing.Size(144, 45);
            this.bt_dn.TabIndex = 2;
            this.bt_dn.Text = "Đăng nhập";
            this.bt_dn.UseVisualStyleBackColor = true;
            this.bt_dn.Click += new System.EventHandler(this.bt_dn_Click);
            // 
            // bt_dk
            // 
            this.bt_dk.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_dk.Location = new System.Drawing.Point(59, 266);
            this.bt_dk.Name = "bt_dk";
            this.bt_dk.Size = new System.Drawing.Size(144, 45);
            this.bt_dk.TabIndex = 3;
            this.bt_dk.Text = "Đăng ký";
            this.bt_dk.UseVisualStyleBackColor = true;
            this.bt_dk.Click += new System.EventHandler(this.bt_dk_Click);
            // 
            // bt_tt
            // 
            this.bt_tt.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_tt.Location = new System.Drawing.Point(783, 201);
            this.bt_tt.Name = "bt_tt";
            this.bt_tt.Size = new System.Drawing.Size(144, 45);
            this.bt_tt.TabIndex = 4;
            this.bt_tt.Text = "Thông tin";
            this.bt_tt.UseVisualStyleBackColor = true;
            this.bt_tt.Click += new System.EventHandler(this.bt_tt_Click);
            // 
            // bt_thoat
            // 
            this.bt_thoat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_thoat.Location = new System.Drawing.Point(783, 266);
            this.bt_thoat.Name = "bt_thoat";
            this.bt_thoat.Size = new System.Drawing.Size(144, 45);
            this.bt_thoat.TabIndex = 5;
            this.bt_thoat.Text = "Thoát";
            this.bt_thoat.UseVisualStyleBackColor = true;
            this.bt_thoat.Click += new System.EventHandler(this.bt_thoat_Click);
            // 
            // Lb_truong
            // 
            this.Lb_truong.AutoSize = true;
            this.Lb_truong.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_truong.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Lb_truong.Location = new System.Drawing.Point(28, 20);
            this.Lb_truong.Name = "Lb_truong";
            this.Lb_truong.Size = new System.Drawing.Size(514, 25);
            this.Lb_truong.TabIndex = 0;
            this.Lb_truong.Text = "Trường Đại Học Kinh Tế - Kỹ Thuật Công Nghiệp";
            this.Lb_truong.Click += new System.EventHandler(this.Lb_truong_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Lb_truong);
            this.panel1.Location = new System.Drawing.Point(215, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 64);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(59, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 63);
            this.panel2.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Quanlysinhvien.Properties.Resources.book;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Batdau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(986, 358);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bt_thoat);
            this.Controls.Add(this.bt_tt);
            this.Controls.Add(this.bt_dk);
            this.Controls.Add(this.bt_dn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Batdau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.batdau_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_dn;
        private System.Windows.Forms.Button bt_dk;
        private System.Windows.Forms.Button bt_tt;
        private System.Windows.Forms.Button bt_thoat;
        private System.Windows.Forms.Label Lb_truong;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}