using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlysinhvien
{
    public partial class Khoamay : Form
    {
        public Khoamay()
        {
            InitializeComponent();
        }

        private void Khoamay_Load(object sender, EventArgs e)
        {

        }
        SqlConnection sqlcon;
        public void ketnoi()
        {
            try
            {

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
        public string HashPassword(string password, int length = 16)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder result = new StringBuilder();
                foreach (byte b in bytes)
                {
                    result.Append(b.ToString("x2"));
                }
                return result.ToString().Substring(0, length).ToUpper();
            }
        }

        private void btnmokhoa_Click(object sender, EventArgs e)
        {
        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {
        this.Close();
        }

        private void bt_dn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dangnhap f = new Dangnhap();
            f.Show();
        }
    }
}
