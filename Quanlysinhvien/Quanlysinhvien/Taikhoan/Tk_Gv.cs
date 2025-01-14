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

namespace Quanlysinhvien.Taikhoan
{
    public partial class Tk_Gv : Form
    {
        SqlConnection sqlcon;
        public Tk_Gv()
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
        private void Tk_Gv_Load(object sender, EventArgs e)
        {
            ketnoi();
            string sql;
            sql = "select tk[Tên Tài Khoản],mk[Mật Khẩu] from Gv";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            sqlda.Fill(ds);
            this.Dgv_user.DataSource = ds.Tables[0];
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txttk.Enabled = true;
            txttk.Clear();
            txtmk.Clear();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
                string taiKhoan = txttk.Text.Trim();
                string matKhau = txtmk.Text;

                string usernamePattern = @"^(?=.*[A-Za-z])(?![_\-.])(?!.*[_\-.]{2})[A-Za-z0-9._-]+(?<![_\-.])$";
                string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{8,16}$";
                int minLength = 6;

                if (taiKhoan == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (taiKhoan.Length < minLength)
                {
                    MessageBox.Show("Tên tài khoản phải có độ dài tối thiểu là " + minLength + " ký tự!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttk.Focus();
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(taiKhoan, usernamePattern))
                {
                    MessageBox.Show("Tên tài khoản chỉ được phép chứa các ký tự (a-z, A-Z, 0-9), dấu gạch dưới, dấu gạch ngang và dấu chấm. Tên phải bắt đầu hoặc kết thúc bằng chữ cái hoặc chữ số, và có ít nhất một chữ cái.", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttk.Focus();
                    return;
                }

                if (matKhau.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(matKhau, passwordPattern))
                {
                    MessageBox.Show("Mật khẩu phải dài từ 8 đến 16 ký tự, chứa ít nhất 1 ký tự viết hoa, 1 ký tự viết thường, 1 chữ số và 1 ký tự đặc biệt!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmk.Focus();
                    return;
                }

                string query = "INSERT INTO Gv (tk, mk) VALUES (@tk, @mk)";
                using (SqlCommand sqlcom = new SqlCommand(query, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@tk", taiKhoan);
                    sqlcom.Parameters.AddWithValue("@mk", matKhau);
                    sqlcom.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công tài khoản: " + taiKhoan, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txttk.Clear();
                txtmk.Clear();

                string sql = "SELECT tk AS [Tên Tài Khoản], mk AS [Mật Khẩu] FROM Gv";
                DataSet ds = new DataSet();
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                sqlda.Fill(ds);
                Dgv_user.DataSource = ds.Tables[0];
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu đã tồn tại! Bạn vui lòng nhập lại!", "Báo lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();

                if (string.IsNullOrWhiteSpace(txttk.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttk.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtmk.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmk.Focus();
                    return;
                }

                string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{8,16}$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtmk.Text, passwordPattern))
                {
                    MessageBox.Show("Mật khẩu phải dài từ 8 đến 16 ký tự, chứa ít nhất 1 ký tự viết hoa, 1 ký tự viết thường, 1 chữ số và 1 ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmk.Focus();
                    return;
                }

                string query = "UPDATE Gv SET mk = @mk WHERE tk = @tk";
                using (SqlCommand sqlcom = new SqlCommand(query, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@mk", txtmk.Text);
                    sqlcom.Parameters.AddWithValue("@tk", txttk.Text);
                    int n = sqlcom.ExecuteNonQuery();

                    if (n > 0)
                    {
                        MessageBox.Show("Cập nhật thành công mật khẩu cho tài khoản: " + txttk.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txttk.Clear();
                        txtmk.Clear();
                        txttk.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                string sql = "SELECT tk AS [Tên Tài Khoản], mk AS [Mật Khẩu] FROM Gv";
                DataSet ds = new DataSet();
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                sqlda.Fill(ds);
                Dgv_user.DataSource = ds.Tables[0];
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
                string taiKhoan = txttk.Text;

              
                DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản: " + taiKhoan + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    string s = "DELETE FROM Gv WHERE tk = @tk";
                    using (SqlCommand sqlcom = new SqlCommand(s, sqlcon))
                    {
                        sqlcom.Parameters.AddWithValue("@tk", taiKhoan);
                        int n = sqlcom.ExecuteNonQuery();

                        if (n > 0)
                        {
                            MessageBox.Show("Xóa thành công tài khoản: " + taiKhoan, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txttk.Clear();
                            txtmk.Clear();
                            txttk.Enabled = true;

                           
                            string sql = "SELECT tk AS [Tên Tài Khoản], mk AS [Mật Khẩu] FROM Gv";
                            DataSet ds = new DataSet();
                            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                            sqlda.Fill(ds);
                            Dgv_user.DataSource = ds.Tables[0];
                            ds.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tài khoản cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Dgv_user_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txttk.Text = Dgv_user.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtmk.Text = Dgv_user.Rows[e.RowIndex].Cells[1].Value.ToString();
                txttk.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }

        private void chkanhien_CheckedChanged(object sender, EventArgs e)
        {

            if (chkanhien.Checked == true)
            {
                txtmk.UseSystemPasswordChar = false;
            }
            else
            {
                txtmk.UseSystemPasswordChar = true;
            }
        }
    }
}
