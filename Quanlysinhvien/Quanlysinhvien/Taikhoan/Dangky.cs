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
    public partial class Dangky : Form
    {
        public Dangky()
        {
            InitializeComponent();
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
        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();

                string tendn = txttendn.Text.Trim();
                string tendd = txttendd.Text.Trim();
                string matkhau = txtmk.Text.Trim();
                string nlmk = txtnlmk.Text.Trim();

                string tendnPattern = @"^(?=.*[A-Za-z])(?![_\-.])(?!.*[_\-.]{2})[A-Za-z0-9._-]+(?<![_\-.])$";
                string matkhauPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{8,16}$";

                if (string.IsNullOrEmpty(tendn))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txttendn.Focus();
                    return;
                }

                if (tendn.Length < 6)
                {
                    MessageBox.Show("Tên tài khoản phải có độ dài tối thiểu là 6 ký tự!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttendn.Focus();
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(tendn, tendnPattern))
                {
                    MessageBox.Show("Tên tài khoản chỉ được phép chứa các ký tự (a-z, A-Z, 0-9), dấu gạch dưới, dấu gạch ngang và dấu chấm. Tên phải bắt đầu hoặc kết thúc bằng chữ cái hoặc chữ số, và có ít nhất một chữ cái.", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttendn.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(tendd))
                {
                    MessageBox.Show("Vui lòng nhập tên đầy đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttendd.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(matkhau))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtmk.Focus();
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(matkhau, matkhauPattern))
                {
                    MessageBox.Show("Mật khẩu phải dài từ 8 đến 16 ký tự, chứa ít nhất 1 ký tự viết hoa, 1 ký tự viết thường, 1 chữ số và 1 ký tự đặc biệt!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmk.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(nlmk))
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtnlmk.Focus();
                    return;
                }

                if (matkhau != nlmk)
                {
                    MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtnlmk.Focus();
                    return;
                }

                string str = "SELECT COUNT(*) FROM Login WHERE tendn = @tendn";
                using (SqlCommand cmd = new SqlCommand(str, sqlcon))
                {
                    cmd.Parameters.AddWithValue("@tendn", tendn);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());

                    if (i != 0)
                    {
                        MessageBox.Show("Tài khoản đã được đăng ký. Vui lòng sử dụng tên tài khoản khác!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txttendn.Focus();
                        txttendn.Clear();
                        txttendd.Clear();
                        txtmk.Clear();
                        txtnlmk.Clear();
                        return;
                    }
                }

                string s = "INSERT INTO Login (tendn, tendd, matkhau, chucvu, trangthai) " +
                           "VALUES (@tendn, @tendd, @matkhau, @chucvu, @trangthai)";
                using (SqlCommand com = new SqlCommand(s, sqlcon))
                {
                    string hashedPassword = HashPassword(matkhau);
                    com.Parameters.AddWithValue("@tendn", tendn);
                    com.Parameters.AddWithValue("@tendd", tendd);
                    com.Parameters.AddWithValue("@matkhau", hashedPassword);
                    com.Parameters.AddWithValue("@chucvu", "Người dùng");
                    com.Parameters.AddWithValue("@trangthai", 1);
                    com.ExecuteNonQuery();
                }

                if (MessageBox.Show("Đăng ký thành công. Bạn muốn đăng nhập không?", "Đăng ký", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Dangnhap f = new Dangnhap();
                    f.Show();
                }
                else
                {
                    Batdau batdau = new Batdau();
                    batdau.Show();
                }
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác không thực hiện được. Vui lòng kiểm tra lại!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            Batdau f = new Batdau();
            f.Show();
            this.Close();
        }

        private void chkanhien_CheckedChanged(object sender, EventArgs e)
        {
            if (chkanhien.Checked == true)
            {
                txtmk.UseSystemPasswordChar = false;
                txtnlmk.UseSystemPasswordChar = false;
            }
            else
            {
                txtmk.UseSystemPasswordChar = true;
                txtnlmk.UseSystemPasswordChar = true;
            }
        }

        private void Dangky_Load(object sender, EventArgs e)
        {

        }
    }
}
