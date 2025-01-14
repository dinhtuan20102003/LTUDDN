using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlysinhvien
{
    public partial class Batdau : Form
    {
        public void ketnoi()
        {
            try
            {
                SqlConnection sqlcon;
                string ketnoi;
                ketnoi = "server=DinhTuan\\SQLEXPRESS;database=Quanlysinhvien;Integrated Security=True";
                sqlcon = new SqlConnection(ketnoi);
                sqlcon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa kết nối được, Bạn kiểm tra lại tên server và tên cơ sở dữ liệu!", "Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(ex.Message);
            }
        }
        public Batdau()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Lb_truong.Left <= panel1.Width)
                Lb_truong.Left = Lb_truong.Left + 10;
            else
                Lb_truong.Left = -Lb_truong.Width;
        }

        private void batdau_Load(object sender, EventArgs e)
        {

        }

        private void bt_tt_Click(object sender, EventArgs e)
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

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            DialogResult tl;
            tl = MessageBox.Show("Bạn có muốn đóng chương trình không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tl == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void bt_dn_Click(object sender, EventArgs e)
        {
            Dangnhap f = new Dangnhap();
            f.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            String tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN\n";
            tt += "\n";
            tt += "Version: 5.5\n";
            tt += "\n";
            tt += "Học phần thực tập: \n\n";
            tt += "Lập trình hướng cơ sở dữ liệu \n";
            tt += "\n\n";
            tt += "Coppy right @ Năm 2024\n";
            tt += "Designer by: Đỗ Đình Tuấn - 21103100756 - DHTI15A1CL \n";
            tt += "Email: nthieu.dhti15a13hn@sv.uneti.edu.vn \n\n";
            MessageBox.Show((tt), "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_dk_Click(object sender, EventArgs e)
        {

            Dangky f = new Dangky();
            f.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.White;
            int borderWidth = 1;
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panel1.Width - borderWidth, panel1.Height - borderWidth);
            }
        }

        private void Lb_truong_Click(object sender, EventArgs e)
        {

        }
    }
}
