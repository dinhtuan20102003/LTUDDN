using Quanlysinhvien.Thongtin;
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

namespace Quanlysinhvien.Taikhoan
{
    public partial class Taikhoan1 : Form
    {
        public Taikhoan1()
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

        private void Taikhoan1_Load(object sender, EventArgs e)
        {
            ketnoi();
            string sql;
            sql = "select  *from Login";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            sqlda.Fill(ds);
            this.Dgv_taikhoan.DataSource = ds.Tables[0];
        }

        public void load()
        {
            string sql = "SELECT * FROM Login";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            sqlda.Fill(ds);
            Dgv_taikhoan.DataSource = ds.Tables[0];
            ds.Dispose();
        }

        private void Dgv_taikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txttendn.Text = Dgv_taikhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
                txttendd.Text = Dgv_taikhoan.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtmk.Text = Dgv_taikhoan.Rows[e.RowIndex].Cells[2].Value.ToString();
                string chucVu = Dgv_taikhoan.Rows[e.RowIndex].Cells[3].Value.ToString();
                switch (chucVu)
                {
                    case "Admin":
                        rdoadmin.Checked = true;
                        break;
                    case "Người dùng":
                        rdond.Checked = true;
                        break;
                    case "Trưởng khoa":
                        rdotk.Checked = true;
                        break;
                    case "Giáo viên":
                        rdogv.Checked = true;
                        break;
                    default:
                        break;
                }
                //string trangThai = Dgv_taikhoan.Rows[e.RowIndex].Cells[4].Value.ToString();
                //if (trangThai == "1")
                //{
                //    rdohd.Checked = true;
                //}
                //else if (trangThai == "0")
                //{
                //    rdokhd.Checked = true;
                //}
                bool trangThai = Convert.ToBoolean(Dgv_taikhoan.Rows[e.RowIndex].Cells[4].Value);
                if (trangThai)
                {
                    rdohd.Checked = true;
                }
                else
                {
                    rdokhd.Checked = true;
                }
                txttendn.Enabled = false;
            }
            catch
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

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txttendn.Clear();
            txttendd.Clear();
            txtmk.Clear();
            rdoadmin.Checked = false;
            rdohd.Checked = false;
            rdokhd.Checked = false;
            rdogv.Checked = false;
            rdotk.Checked = false;
            rdond.Checked = false;
           txttendn.Enabled =true;
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
                // Cắt ngắn chuỗi băm
                return result.ToString().Substring(0, length).ToUpper();
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
                string tendn = txttendn.Text.Trim();
                string tendd = txttendd.Text.Trim();
                string matkhau = txtmk.Text;
                string hashedPassword = HashPassword(matkhau);

                string chucvu = "";
                if (rdoadmin.Checked) chucvu = "Admin";
                else if (rdond.Checked) chucvu = "Người dùng";
                else if (rdotk.Checked) chucvu = "Trưởng khoa";
                else if (rdogv.Checked) chucvu = "Giáo viên";

                int trangthai = -1;
                if (rdohd.Checked) trangthai = 1;
                else if (rdokhd.Checked) trangthai = 0;

                string usernamePattern = @"^(?=.*[A-Za-z])(?![_\-.])(?!.*[_\-.]{2})[A-Za-z0-9._-]+(?<![_\-.])$";
                string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{8,16}$";
                int minLength = 6;

                if (tendn == "")
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //if (tendn.Length < minLength)
                //{
                //    MessageBox.Show("Tên tài khoản phải có độ dài tối thiểu là " + minLength + " ký tự!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txttendn.Focus();
                //    return;
                //}

                if (!System.Text.RegularExpressions.Regex.IsMatch(tendn, usernamePattern))
                {
                    MessageBox.Show("Tên tài khoản chỉ được phép chứa các ký tự (a-z, A-Z, 0-9), dấu gạch dưới, dấu gạch ngang và dấu chấm. Tên phải bắt đầu hoặc kết thúc bằng chữ cái hoặc chữ số, và có ít nhất một chữ cái.", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttendn.Focus();
                    return;
                }

                if (tendd == "")
                {
                    MessageBox.Show("Vui lòng nhập tên đầy đủ!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txttendd.Focus();
                    return;
                }

                if (matkhau.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //if (!System.Text.RegularExpressions.Regex.IsMatch(matkhau, passwordPattern))
                //{
                //    MessageBox.Show("Mật khẩu phải dài từ 8 đến 16 ký tự, chứa ít nhất 1 ký tự viết hoa, 1 ký tự viết thường, 1 chữ số và 1 ký tự đặc biệt!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtmk.Focus();
                //    return;
                //}

                if (chucvu == "")
                {
                    MessageBox.Show("Vui lòng chọn chức vụ!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (trangthai == -1)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái hoạt động!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string query = "INSERT INTO Login (tendn, tendd, matkhau, chucvu, trangthai) VALUES (@tendn, @tendd, @matkhau, @chucvu, @trangthai)";
                using (SqlCommand sqlcom = new SqlCommand(query, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@tendn", tendn);
                    sqlcom.Parameters.AddWithValue("@tendd", tendd);
                    sqlcom.Parameters.AddWithValue("@matkhau", hashedPassword);
                    sqlcom.Parameters.AddWithValue("@chucvu", chucvu);
                    sqlcom.Parameters.AddWithValue("@trangthai", trangthai);
                    sqlcom.ExecuteNonQuery();
                }

                MessageBox.Show($"Thêm thành công tài khoản {chucvu}: {tendn}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnnl_Click(sender, e);

                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu đã tồn tại! Bạn vui lòng nhập lại!" + ex, "Báo lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }



        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();

                string tendn = txttendn.Text.Trim();
                string tendd = txttendd.Text.Trim();
                string matkhau = txtmk.Text;
                string hashedPassword = HashPassword(matkhau);

                string chucvu = "";
                if (rdoadmin.Checked) chucvu = "Admin";
                else if (rdond.Checked) chucvu = "Người dùng";
                else if (rdotk.Checked) chucvu = "Trưởng khoa";
                else if (rdogv.Checked) chucvu = "Giáo viên";

                int trangthai = -1;
                if (rdohd.Checked) trangthai = 1;
                else if (rdokhd.Checked) trangthai = 0;

             
                string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{8,16}$";
                if (string.IsNullOrWhiteSpace(tendn))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập tên tài khoản cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tendd))
                {
                    MessageBox.Show("Vui lòng nhập tên đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttendd.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(matkhau))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmk.Focus();
                    return;
                }

                if (chucvu == "")
                {
                    MessageBox.Show("Vui lòng chọn chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (trangthai == -1)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string checkQuery = "SELECT COUNT(*) FROM Login WHERE tendn = @tendn";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@tendn", tendn);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show($"Không tìm thấy tài khoản {chucvu} với tên đăng nhập: " + tendn, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string updateQuery = "UPDATE Login SET tendd = @tendd, matkhau = @matkhau, chucvu = @chucvu, trangthai = @trangthai WHERE tendn = @tendn";
                using (SqlCommand sqlcom = new SqlCommand(updateQuery, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@tendn", tendn);
                    sqlcom.Parameters.AddWithValue("@tendd", tendd);
                    sqlcom.Parameters.AddWithValue("@matkhau", hashedPassword);
                    sqlcom.Parameters.AddWithValue("@chucvu", chucvu);
                    sqlcom.Parameters.AddWithValue("@trangthai", trangthai);

                    int rowsAffected = sqlcom.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Cập nhật thành công tài khoản {chucvu}: " + tendn, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnnl_Click(sender, e);
                        txttendn.Enabled = true;
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật tài khoản. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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
                string tendn = txttendn.Text.Trim();
                string chucvu = "";


                if (string.IsNullOrWhiteSpace(tendn))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập tên tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string checkQuery = "SELECT COUNT(*) FROM Login WHERE tendn = @tendn";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@tendn", tendn);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy tài khoản với tên đăng nhập: " + tendn, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (Dgv_taikhoan.CurrentRow != null)
                {
                    if (Dgv_taikhoan.CurrentRow.Cells.Count > 3)
                    {
                        chucvu = Dgv_taikhoan.CurrentRow.Cells[3].Value.ToString();
                    }

                    DialogResult confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản {chucvu}: " + tendn + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        string s = "DELETE FROM Login WHERE tendn = @tk";
                        using (SqlCommand sqlcom = new SqlCommand(s, sqlcon))
                        {
                            sqlcom.Parameters.AddWithValue("@tk", tendn);
                            int n = sqlcom.ExecuteNonQuery();

                            if (n > 0)
                            {
                                MessageBox.Show("Xóa thành công tài khoản " + chucvu + ": " + tendn, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnnl_Click(sender, e);
                                txttendn.Enabled = true;
                                load();
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
                else
                {
                    MessageBox.Show("Vui lòng chọn một tài khoản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
