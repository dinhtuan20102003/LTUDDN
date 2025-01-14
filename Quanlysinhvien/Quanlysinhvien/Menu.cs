using Quanlysinhvien.Quanly;
using Quanlysinhvien.Taikhoan;
using Quanlysinhvien.Thongtin;
using Quanlysinhvien.Timkiem;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Quanlysinhvien
{

    public partial class Menu : Form
    {


        public string UserName { get; set; }
        public Menu()
        {
           
        
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi");

            InitializeComponent();

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult tl = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (tl == DialogResult.Cancel)
            //{
            //    e.Cancel = true;
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Lbl_qlsv.Left <= panel1.Width)
                Lbl_qlsv.Left = Lbl_qlsv.Left + 10;
            else
                Lbl_qlsv.Left = -Lbl_qlsv.Width;

        }


        private void Lbl_qlsv_Click(object sender, EventArgs e)
        {
            String tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN\n";
            tt += "\n";
            tt += "Version: 17.10.1\n";
            tt += "\n";
            tt += "Học phần thực tập: \n\n";
            tt += "Lập trình hướng cơ sở dữ liệu \n";
            tt += "\n\n";
            tt += "Coppy right @ Năm 2024\n";
            tt += "Designer by: Đỗ Đình Tuấn - 21103100756 - DHTI15A1CL \n";
            tt += "Email: ddtuan.dhti15a13hn@sv.uneti.edu.vn \n\n";
            MessageBox.Show((tt), "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //label1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //string s = "Hôm nay là ngày " + DateTime.Now.ToString("dd/MM/yyyy");
            //s = s + " - Bây giờ là " + DateTime.Now.ToString("hh:mm:sstt ");
            //s = s + "\t" + UserName;
            //toolStripStatusLabel1.Text = s;
            string s = UserName;
            s += " | Hôm nay là ngày " + DateTime.Now.ToString("dd/MM/yyyy");
            s += " | Bây giờ là " + DateTime.Now.ToString("HH:mm:ss");
            toolStripStatusLabel1.Text = s;
            //toolStripStatusLabel1.ForeColor = Color.DodgerBlue;
            //this.Text = this.Text.Substring(1, this.Text.Length - 1) + this.Text.Substring(0, 1);
        }

        private void Ts_Btn_admin_Click(object sender, EventArgs e)
        {
            Admin f = new Admin();
            f.Show();
        }

        private void Ts_Btn_user_Click(object sender, EventArgs e)
        {
            User f = new User();
            f.Show();
        }

        private void Ts_Btn_dangxuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã đăng xuất thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Batdau f = new Batdau();
                f.Show();
                this.Hide();
            }
            else
            {
                this.Show();
            }


        }

        private void Ts_Btn_tt_sinhvien_Click(object sender, EventArgs e)
        {
            Sinhvien f = new Sinhvien();
            f.Show();
        }

        private void Ts_Btn_tt_giaovien_Click(object sender, EventArgs e)
        {
            Giaovien f = new Giaovien();
            f.Show();
        }

        private void Ts_Btn_tt_lop_Click(object sender, EventArgs e)
        {
            Lop f = new Lop();
            f.Show();
        }

        private void Ts_Btn_tt_khoa_Click(object sender, EventArgs e)
        {
            Khoa f = new Khoa();
            f.Show();
        }

        private void Ts_Btn_tt_monhoc_Click(object sender, EventArgs e)
        {
            Monhoc f = new Monhoc();
            f.Show();
        }

        private void Ts_Btn_tt_chinhsach_Click(object sender, EventArgs e)
        {
            Chinhsach f = new Chinhsach();
            f.Show();
        }

        private void Ts_Btn_tt_diem_Click(object sender, EventArgs e)
        {
            Diem f = new Diem();
            f.Show();

        }

        private void Ts_Btn_tk_sinhvien_Click(object sender, EventArgs e)
        {
            Tk_Sinhvien f = new Tk_Sinhvien();
            f.Show();
        }

        private void Ts_Btn_tk_giaovien_Click(object sender, EventArgs e)
        {
            Tk_Giaovien f = new Tk_Giaovien();
            f.Show();
        }

        private void Ts_Btn_tk_lop_Click(object sender, EventArgs e)
        {
            Tk_Lop f = new Tk_Lop();
            f.Show();
        }

        private void Ts_Btn_tk_khoa_Click(object sender, EventArgs e)
        {
            Tk_Khoa f = new Tk_Khoa();
            f.Show();
        }

        private void Ts_Btn_tk_monhoc_Click(object sender, EventArgs e)
        {
            Tk_Monhoc f = new Tk_Monhoc();
            f.Show();
        }

        private void Ts_Btn_tk_chinhsach_Click(object sender, EventArgs e)
        {
            Tk_Chinhsach f = new Tk_Chinhsach();
            f.Show();
        }

        private void Ts_Btn_ql_sinhvien_Click(object sender, EventArgs e)
        {
            Cn_Sinhvien f = new Cn_Sinhvien();
            f.Show();
        }

        private void Ts_Btn_ql_giaovien_Click(object sender, EventArgs e)
        {
            Cn_Giaovien f = new Cn_Giaovien();
            f.Show();
        }

        private void Ts_Btn_ql_lop_Click(object sender, EventArgs e)
        {
            Cn_Lop f = new Cn_Lop();
            f.Show();
        }

        private void Ts_Btn_ql_khoa_Click(object sender, EventArgs e)
        {
            Cn_Khoa f = new Cn_Khoa();
            f.Show();
        }

        private void Ts_Btn_ql_monhoc_Click(object sender, EventArgs e)
        {
            Cn_Monhoc f = new Cn_Monhoc();
            f.Show();
        }

        private void Ts_Btn_ql_chinhsach_Click(object sender, EventArgs e)
        {
            Cn_Chinhsach f = new Cn_Chinhsach();
            f.Show();
        }

        private void Ts_Btn_ql_diem_Click(object sender, EventArgs e)
        {
            Cn_Diem f = new Cn_Diem();
            f.Show();
        }

        private void Ts_Btn_ti_paint_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mspaint.exe");
        }

        private void Ts_Btn_ti_cmd_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd.exe");
        }

        private void Ts_Btn_ti_notepad_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void Ts_Btn_ti_maytinh_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void Ts_Btn_ti_word_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword.exe");
        }

        private void Ts_Btn_ht_thongtin_Click(object sender, EventArgs e)
        {
            string tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN\n";
            tt += "Version: 17.10.1\n\n";
            tt += "Học phần thực tập: \n\n";
            tt += "Lập trình hướng cơ sở dữ liệu \n";
            tt += "\n\n";
            tt += "Coppy right @ Năm 2024\n";
            tt += "Email: ddtuan.dhti15a13hn@sv.uneti.edu.vn \n";
            tt += "\n\n";
            MessageBox.Show((tt), "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Ts_Btn_ht_capnhat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang sử dụng phiên bản mới nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Ts_Btn_ht_lienhe_Click(object sender, EventArgs e)
        {
            string tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN\n";
            tt += "\n";
            tt += "Version: 17.10.1\n";
            tt += "\n";
            tt += "Học phần thực tập: \n\n";
            tt += "Lập trình hướng cơ sở dữ liệu \n";
            tt += "\n\n";
            tt += "Coppy right @ Năm 2024\n";
            tt += "Designer by: Nhóm 2 - DHTI15A1CL \n";
            tt += "Email: ddtuan.dhti15a13hn@sv.uneti.edu.vn \n\n";
            MessageBox.Show((tt), "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Ts_Btn_thoat_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã đăng xuất thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void Ts_Btn_khoa_Click(object sender, EventArgs e)
        {
        toolStrip1.Visible = false;
            Ts_Btn_tk.Visible = false;
            Ts_Btn_dangnhap.Visible = true;
            //Ts_Btn_admin.Visible = false;
            //Ts_Btn_user.Visible = false;
            Ts_Btn_dangxuat.Visible = false;
            Ts_Btn_khoa.Visible = false;
            Ts_Btn_thongtin.Visible = false;
            Ts_Btn_timkiem.Visible = false;
            Ts_Btn_quanly.Visible = false;
            Ts_Btn_hienthi.Visible = false;
            Ts_Btn_tienich.Visible = false;
            Ts_Btn_ht_capnhat.Visible = false;
            Ts_Btn_capnhatdiem.Visible = false;
            //Ts_Btn_giaovien.Visible = false;
            //Ts_Btn_truongkhoa.Visible = false;
            Ts_Btn_doimatkhau.Visible = false;
            toolStripMenuItem2.Visible = false;
            toolStripMenuItem1.Visible = false;
            statusStrip1.Visible = false;
            Khoamay f = new Khoamay();
            f.Show();
        }

        private void Ts_Btn_dangnhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dangnhap f = new Dangnhap();
            f.Show();
        }

        private void Ts_Btn_doimatkhau_Click(object sender, EventArgs e)
        {
            Doimatkhau f = new Doimatkhau();
            f.Show();
        }

        private void Ts_Btn_capnhatdiem_Click(object sender, EventArgs e)
        {
            Cn_Diemsv f = new Cn_Diemsv();
            f.Show();
        }

        private void Ts_Btn_truongkhoa_Click(object sender, EventArgs e)
        {
            Truongkhoa f = new Truongkhoa();
            f.Show();
        }

        private void Ts_Btn_giaovien_Click(object sender, EventArgs e)
        {
            Tk_Gv f = new Tk_Gv();
            f.Show();
        }

        private void Btn_ht_100_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.45;
        }

        private void Btn_ht_50_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.8;
           
        }

        private void Btn_ht_macdinh_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã đăng xuất thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void btntrogiup_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\User\source\repos\Quanlysinhvien\Quanlysinhvien\bin\Debug\Hotro.chm");
        }


        private void btnTA_Click(object sender, EventArgs e)
        {
          
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

            //this.Controls.Clear();
            //InitializeComponent();

        }

        private void Ts_Btn_tk_Click(object sender, EventArgs e)
        {
            Taikhoan1 f = new Taikhoan1();
            f.Show();
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            Khoa khoa = new Khoa();
            khoa.Show();
        }

        private void btnGiaovien_Click(object sender, EventArgs e)
        {
            Giaovien giaovien = new Giaovien();
            giaovien.Show();
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            Lop lop = new Lop();
            lop.Show();
        }

        private void btnSinhvien_Click(object sender, EventArgs e)
        {
            Sinhvien sinhvien = new Sinhvien();
            sinhvien.Show();
        }

        private void btnMonhoc_Click(object sender, EventArgs e)
        {
            Monhoc monhoc = new Monhoc();   
            monhoc.Show();
        }

        private void btnChinhsach_Click(object sender, EventArgs e)
        {
            Chinhsach chinhsach = new Chinhsach();
            chinhsach.Show();
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {

            Diem diem = new Diem();
            diem.Show();
        }

        private void Ts_Btn_hienthi_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tiếngViệtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
