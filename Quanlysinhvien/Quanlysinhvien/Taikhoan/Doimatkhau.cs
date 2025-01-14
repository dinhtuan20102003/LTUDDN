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
    public partial class Doimatkhau : Form
    {
        SqlConnection sqlcon;
        public Doimatkhau()
        {
            InitializeComponent();
        }

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
        private void Doimatkhau_Load(object sender, EventArgs e)
        {
            txttk.Focus();
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
        private void btndoi_Click(object sender, EventArgs e)
        {
            //ketnoi();
            //string d = txtmkmoi.Text;
            //string b = txtnhaplai.Text;
            //string tentk = txttk.Text;
            //string mk = txtmkcu.Text;
            //if (string.IsNullOrWhiteSpace(tentk))
            //{
            //    MessageBox.Show("Vui lòng nhập tên tài khoản!", "Nhập liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    txttk.Focus();
            //    return;
            //}
            //if (string.IsNullOrWhiteSpace(mk))
            //{
            //    MessageBox.Show("Vui lòng nhập tên mật khẩu!", "Nhập liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    txtmkcu.Focus();
            //    return;
            //}

            //if (d != b)
            //{
            //    MessageBox.Show("Mật khẩu nhập lại không khớp! Vui lòng nhập lại!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //    txtnhaplai.Focus();
            //    txtnhaplai.Clear();
            //    return;
            //}
            //string taikhoan = "select count(*) from Admin where tk = @Username and mk = @Password";
            //SqlCommand cmd = new SqlCommand(taikhoan, sqlcon);
            //cmd.Parameters.AddWithValue("@Username", tentk);
            //cmd.Parameters.AddWithValue("@Password", mk);
            //int i = Convert.ToInt32(cmd.ExecuteScalar());
            //cmd.Dispose();

            //string taikhoanu = "select count(*) from NguoiDung where tk = @Username and mk = @Password";
            //SqlCommand cmd1 = new SqlCommand(taikhoanu, sqlcon);
            //cmd1.Parameters.AddWithValue("@Username", tentk);
            //cmd1.Parameters.AddWithValue("@Password", mk);
            //int u = Convert.ToInt32(cmd1.ExecuteScalar());
            //cmd1.Dispose();

            //string taikhoangv = "select count(*) from Gv where tk = @Username and mk = @Password";
            //SqlCommand cmd2 = new SqlCommand(taikhoangv, sqlcon);
            //cmd2.Parameters.AddWithValue("@Username", tentk);
            //cmd2.Parameters.AddWithValue("@Password", mk);
            //int gv = Convert.ToInt32(cmd2.ExecuteScalar());
            //cmd2.Dispose();

            //string taikhoantkhoa = "select count(*) from Truongkhoa where tk = @Username and mk = @Password";
            //SqlCommand cmd3 = new SqlCommand(taikhoantkhoa, sqlcon);
            //cmd3.Parameters.AddWithValue("@Username", tentk);
            //cmd3.Parameters.AddWithValue("@Password", mk);
            //int tkhoa = Convert.ToInt32(cmd3.ExecuteScalar());
            //cmd3.Dispose();

            //if (i != 0)
            //{
            //    try
            //    {
            //        if (d == b)
            //        {
            //            string sql = "update Admin set mk = '" + txtmkmoi.Text + "' where tk = '" + txttk.Text + "'";
            //            SqlCommand s = new SqlCommand(sql, sqlcon);
            //            s.ExecuteNonQuery();
            //            MessageBox.Show("Bạn đã thay đổi mật khẩu thành công tài khoản Admin!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Mật khẩu nhập lại không khớp!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Thao tác không thực hiện được. Vui lòng kiểm tra lại!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    }
            //}
            //else if (gv != 0)
            //{
            //    try
            //    {
            //        if (d == b)
            //        {
            //            string sql = "update GiaoVien set mk = '" + txtmkmoi.Text + "' where tk = '" + txttk.Text + "'";
            //            SqlCommand s = new SqlCommand(sql, sqlcon);
            //            s.ExecuteNonQuery();
            //            MessageBox.Show("Bạn đã thay đổi mật khẩu thành công tài khoản Giáo viên!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Mật khẩu nhập lại không khớp!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Thao tác không thực hiện được. Vui lòng kiểm tra lại!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    }
            //}
            //else if (u != 0)
            //{
            //    try
            //    {
            //        if (d == b)
            //        {
            //            string sql = "update User set mk = '" + txtmkmoi.Text + "' where tk = '" + txttk.Text + "'";
            //            SqlCommand s = new SqlCommand(sql, sqlcon);
            //            s.ExecuteNonQuery();
            //            MessageBox.Show("Bạn đã thay đổi mật khẩu thành công tài khoản User!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Mật khẩu nhập lại không khớp!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Thao tác không thực hiện được. Vui lòng kiểm tra lại!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    }
            //}
            //else if (tkhoa != 0)
            //{
            //    try
            //    {
            //        if (d == b)
            //        {
            //            string sql = "update TruongKhoa set mk = '" + txtmkmoi.Text + "' where tk = '" + txttk.Text + "'";
            //            SqlCommand s = new SqlCommand(sql, sqlcon);
            //            s.ExecuteNonQuery();
            //            MessageBox.Show("Bạn đã thay đổi mật khẩu thành công tài khoản Trưởng khoa!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Mật khẩu nhập lại không khớp!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Thao tác không thực hiện được. Vui lòng kiểm tra lại!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng! Bạn vui lòng kiểm tra lại!", "Đổi mật khẩu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    txttk.Focus();
            //    txtmkmoi.Clear();
            //    txttk.Clear();
            //    txtmkcu.Clear();
            //    txtnhaplai.Clear();
            //}
            string tendn = txttk.Text.Trim();
            string mkcu = txtmkcu.Text.Trim();
            string mkmoi = txtmkmoi.Text.Trim();
            string nhaplai = txtnhaplai.Text.Trim();

            if (string.IsNullOrWhiteSpace(tendn))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttk.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(mkcu))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmkcu.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(mkmoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmkcu.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(nhaplai))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu mới!", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmkcu.Focus();
                return;
            }

            if (mkmoi != nhaplai)
            {
                MessageBox.Show("Mật khẩu mới không khớp với mật khẩu nhập lại!", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnhaplai.Focus();
                txtnhaplai.Clear();
                return;
            }
            ketnoi();
            try
            {
                string query = "SELECT chucvu FROM Login WHERE tendn = @tendn AND matkhau = @matkhau";
                string chucvu = null;

                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    cmd.Parameters.AddWithValue("@tendn", tendn);
                    cmd.Parameters.AddWithValue("@matkhau", HashPassword(mkcu)); 
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Tên tài khoản hoặc mật khẩu cũ không đúng. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txttk.Focus();
                        return;
                    }

                    chucvu = result.ToString(); 
                }

                string updateQuery = "UPDATE Login SET matkhau = @matkhau WHERE tendn = @tendn";
                using (SqlCommand updateCmd = new SqlCommand(updateQuery, sqlcon))
                {
                    updateCmd.Parameters.AddWithValue("@tendn", tendn);
                    updateCmd.Parameters.AddWithValue("@matkhau", HashPassword(mkmoi)); 
                    updateCmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Bạn đã được thay đổi thành công mật khẩu cho tài khoản {chucvu}: {tendn}",
                          "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txttk.Clear();
                txtmkcu.Clear();
                txtmkmoi.Clear();
                txtnhaplai.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkanhien_CheckedChanged(object sender, EventArgs e)
        {

            if (chkanhien.Checked == true)
            {
             
                txtmkmoi.UseSystemPasswordChar = false;
                txtnhaplai.UseSystemPasswordChar = false;
            }
            else
            {
              
                txtmkmoi.UseSystemPasswordChar = true;
                txtnhaplai.UseSystemPasswordChar = true;
            }
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txttk.Focus();
            txtmkmoi.Clear();
            txttk.Clear();
            txtmkcu.Clear();
            txtnhaplai.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                txtmkcu.UseSystemPasswordChar = false;
               
            }
            else
            {
                txtmkcu.UseSystemPasswordChar = true;
               
            }
        }
    }
}

