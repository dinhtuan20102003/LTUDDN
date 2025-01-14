using Quanlysinhvien.Thongtin;
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
    public partial class Cn_Monhoc : Form
    {
        SqlConnection sqlcon;
        public Cn_Monhoc()
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
            sql = "select  *from MonHoc";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
        }

        public void loadGiaovien()
        {
            try
            {
                ketnoi();
                string sql = "SELECT magv FROM GiaoVien";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);

                cmbmagv.DataSource = dt;
                cmbmagv.DisplayMember = "magv";
                cmbmagv.ValueMember = "magv";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu giáo viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Cn_Monhoc_Load(object sender, EventArgs e)
        {
            load();
            loadGiaovien();
            cmbmagv.SelectedIndex = -1;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtmamh.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txttenmh.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtst.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbmagv.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtmamh.Enabled = false;
            }
            catch { }
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txtmamh.Clear();
            txttenmh.Clear();
            txtst.Clear();
            cmbmagv.SelectedIndex = -1;

            txtmamh.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
                string mamh = txtmamh.Text.Trim();
                string tenmh = txttenmh.Text.Trim();
                string sotietText = txtst.Text.Trim();
                string magv = cmbmagv.SelectedValue?.ToString();

                if (string.IsNullOrWhiteSpace(mamh))
                {
                    MessageBox.Show("Bạn chưa nhập mã môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (mamh.Contains(" "))
                {
                    MessageBox.Show("Mã môn học không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tenmh))
                {
                    MessageBox.Show("Bạn chưa nhập tên môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(sotietText))
                {
                    MessageBox.Show("Bạn chưa nhập số tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!int.TryParse(sotietText, out int sotiet) || sotiet < 0)
                {
                    MessageBox.Show("Số tiết không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtst.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(magv))
                {
                    MessageBox.Show("Bạn chưa chọn mã giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string checkQuery = "SELECT COUNT(*) FROM MonHoc WHERE mamh = @mamh";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@mamh", mamh);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã môn học đã tồn tại! Vui lòng nhập mã môn học khác.", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string query = "INSERT INTO MonHoc (mamh, tenmh, sotiet, magv) VALUES (@mamh, @tenmh, @sotiet, @magv)";
                using (SqlCommand sqlcom = new SqlCommand(query, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@mamh", mamh);
                    sqlcom.Parameters.AddWithValue("@tenmh", tenmh);
                    sqlcom.Parameters.AddWithValue("@sotiet", sotiet);
                    sqlcom.Parameters.AddWithValue("@magv", magv);
                    sqlcom.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công môn học với mã: " + mamh, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtmamh.Clear();
                txttenmh.Clear();
                txtst.Clear();
                cmbmagv.SelectedIndex = -1;
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
                string mamh = txtmamh.Text.Trim();
                string tenmh = txttenmh.Text.Trim();
                string sotietText = txtst.Text.Trim();
                string magv = cmbmagv.SelectedValue?.ToString();

                if (string.IsNullOrWhiteSpace(mamh))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã môn học cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmamh.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(tenmh))
                {
                    MessageBox.Show("Vui lòng nhập tên môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttenmh.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(sotietText))
                {
                    MessageBox.Show("Bạn chưa nhập số tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!int.TryParse(sotietText, out int sotiet) || sotiet < 0)
                {
                    MessageBox.Show("Số tiết không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtst.Focus();
                    return;
                }


                if (string.IsNullOrWhiteSpace(magv))
                {
                    MessageBox.Show("Vui lòng chọn mã giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbmagv.Focus();
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM MonHoc WHERE mamh = @mamh";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@mamh", mamh);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy môn học với mã: " + mamh, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string updateQuery = "UPDATE MonHoc SET tenmh = @tenmh, sotiet = @sotiet, magv = @magv WHERE mamh = @mamh";
                using (SqlCommand sqlcom = new SqlCommand(updateQuery, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@mamh", mamh);
                    sqlcom.Parameters.AddWithValue("@tenmh", tenmh);
                    sqlcom.Parameters.AddWithValue("@sotiet", sotiet);
                    sqlcom.Parameters.AddWithValue("@magv", magv);

                    int kq = sqlcom.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công thông tin môn học với mã: " + mamh, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtmamh.Clear();
                        txttenmh.Clear();
                        txtst.Clear();
                        cmbmagv.SelectedIndex = -1;
                        txtmamh.Enabled = true;
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin môn học. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string mamh = txtmamh.Text.Trim();

                if (string.IsNullOrWhiteSpace(mamh))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã môn học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM MonHoc WHERE mamh = @mamh";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@mamh", mamh);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy môn học với mã: " + mamh, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string checkScoreQuery = "SELECT COUNT(*) FROM Diem WHERE mamh = @mamonhoc";
                using (SqlCommand checkScoreCmd = new SqlCommand(checkScoreQuery, sqlcon))
                {
                    checkScoreCmd.Parameters.AddWithValue("@mamonhoc", mamh);
                    int scoreCount = (int)checkScoreCmd.ExecuteScalar();

                    if (scoreCount > 0)
                    {
                        MessageBox.Show($"Không thể xóa môn học {mamh} vì đã có điểm được ghi nhận cho môn học này.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học với mã: " + mamh + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (tl == DialogResult.Yes)
                {
                    string sql = "DELETE FROM MonHoc WHERE mamh = @mamh";
                    using (SqlCommand sqlcom = new SqlCommand(sql, sqlcon))
                    {
                        sqlcom.Parameters.AddWithValue("@mamh", mamh);
                        int n = sqlcom.ExecuteNonQuery();

                        if (n > 0)
                        {
                            MessageBox.Show("Xóa thành công môn học với mã: " + mamh, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtmamh.Clear();
                            txttenmh.Clear();
                            txtst.Clear();
                            cmbmagv.SelectedIndex = -1;
                            txtmamh.Enabled = true;
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa môn học, vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Xóa môn học đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
