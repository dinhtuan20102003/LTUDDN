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

namespace Quanlysinhvien.Quanly
{
    public partial class Cn_Chinhsach : Form
    {
        SqlConnection sqlcon;
        public Cn_Chinhsach()
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
        public void load()
        {
            ketnoi();
            string sql;
            sql = "select  *from ChinhSach";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
        }
        private void Cn_Chinhsach_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtmacs.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txttencs.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtcd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtmacs.Enabled = false;
            }
            catch { }
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txtmacs.Clear();
            txttencs.Clear();
            txtcd.Clear();
            txtmacs.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
                string maChinhsach = txtmacs.Text.Trim();
                string tenChinhsach = txttencs.Text.Trim();
                string cheDo = txtcd.Text.Trim();

                if (string.IsNullOrWhiteSpace(maChinhsach))
                {
                    MessageBox.Show("Bạn chưa nhập mã chính sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (maChinhsach.Contains(" "))
                {
                    MessageBox.Show("Mã chính sách không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tenChinhsach))
                {
                    MessageBox.Show("Bạn chưa nhập tên chính sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cheDo))
                {
                    MessageBox.Show("Bạn chưa nhập chế độ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string checkQuery = "SELECT COUNT(*) FROM ChinhSach WHERE macs = @macs";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@macs", maChinhsach);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã chính sách đã tồn tại! Vui lòng nhập mã chính sách khác.", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string query = "INSERT INTO ChinhSach (macs, tencs, chedo) VALUES (@macs, @tencs, @chedo)";
                using (SqlCommand sqlcom = new SqlCommand(query, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@macs", maChinhsach);
                    sqlcom.Parameters.AddWithValue("@tencs", tenChinhsach);
                    sqlcom.Parameters.AddWithValue("@chedo", cheDo);
                    sqlcom.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công chính sách với mã: " + maChinhsach, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtmacs.Clear();
                txttencs.Clear();
                txtcd.Clear();
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                string maChinhsach = txtmacs.Text.Trim();
                string tenChinhsach = txttencs.Text.Trim();
                string cheDo = txtcd.Text.Trim();

                if (string.IsNullOrWhiteSpace(maChinhsach))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã chính sách cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmacs.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(tenChinhsach))
                {
                    MessageBox.Show("Vui lòng nhập tên chính sách cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttencs.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cheDo))
                {
                    MessageBox.Show("Vui lòng nhập chế độ cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtcd.Focus();
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM ChinhSach WHERE macs = @macs";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@macs", maChinhsach);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy chính sách với mã: " + maChinhsach, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string updateQuery = "UPDATE ChinhSach SET tencs = @tencs, chedo = @chedo WHERE macs = @macs";
                using (SqlCommand sqlcom = new SqlCommand(updateQuery, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@macs", maChinhsach);
                    sqlcom.Parameters.AddWithValue("@tencs", tenChinhsach);
                    sqlcom.Parameters.AddWithValue("@chedo", cheDo);

                    int kq = sqlcom.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công chính sách: " + maChinhsach, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtmacs.Clear();
                        txttencs.Clear();
                        txtcd.Clear();
                        txtmacs.Enabled = true;
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin chính sách. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string maChinhsach = txtmacs.Text.Trim();

                if (string.IsNullOrWhiteSpace(maChinhsach))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã chính sách cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM ChinhSach WHERE macs = @macs";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@macs", maChinhsach);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy chính sách với mã: " + maChinhsach, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string checkStudentQuery = "SELECT COUNT(*) FROM SinhVien WHERE macs = @macs";
                using (SqlCommand checkStudentCmd = new SqlCommand(checkStudentQuery, sqlcon))
                {
                    checkStudentCmd.Parameters.AddWithValue("@macs", maChinhsach);
                    int studentCount = (int)checkStudentCmd.ExecuteScalar();

                    if (studentCount > 0)
                    {
                        MessageBox.Show($"Không thể xóa chính sách {maChinhsach} vì có sinh viên đang sử dụng.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa chính sách: " + maChinhsach + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (tl == DialogResult.Yes)
                {
                    string sql = "DELETE FROM ChinhSach WHERE macs = @macs";
                    using (SqlCommand sqlcom = new SqlCommand(sql, sqlcon))
                    {
                        sqlcom.Parameters.AddWithValue("@macs", maChinhsach);
                        int n = sqlcom.ExecuteNonQuery();

                        if (n > 0)
                        {
                            MessageBox.Show("Xóa thành công chính sách: " + maChinhsach, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtmacs.Clear();
                            txttencs.Clear();
                            txtcd.Clear();
                            txtmacs.Enabled = true;
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa chính sách, vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Xóa chính sách đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
