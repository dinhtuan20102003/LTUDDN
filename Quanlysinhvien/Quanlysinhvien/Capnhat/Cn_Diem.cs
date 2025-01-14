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
    public partial class Cn_Diem : Form
    {
        SqlConnection sqlcon;
        public Cn_Diem()
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
            sql = "select  *from Diem";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
        }

        public void loadSinhvien()
        {
            try
            {
                ketnoi();
                string sql = "SELECT masv FROM SinhVien";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);

                cmbmasv.DataSource = dt;
                cmbmasv.DisplayMember = "masv";
                cmbmasv.ValueMember = "masv";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu giáo viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadMonhoc()
        {
            try
            {
                ketnoi();
                string sql = "SELECT mamh FROM MonHoc";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);

                cmbmamh.DataSource = dt;
                cmbmamh.DisplayMember = "mamh";
                cmbmamh.ValueMember = "mamh";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu giáo viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Cn_Diem_Load(object sender, EventArgs e)
        {
            load();
            loadSinhvien();
            loadMonhoc();
            cmbmasv.SelectedIndex = -1;
            cmbmamh.SelectedIndex = -1;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtmaid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbmasv.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbmamh.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtdiem.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtmaid.Enabled = false;
            }
            catch { }
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txtmaid.Clear();
            cmbmasv.SelectedIndex = -1;
            cmbmamh.SelectedIndex = -1;
            txtdiem.Clear();
            txtmaid.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = cmbmasv.SelectedValue?.ToString();
                string maMH = cmbmamh.SelectedValue?.ToString();
                string diemText = txtdiem.Text.Trim();
                string idText = txtmaid.Text.Trim();


                if (string.IsNullOrWhiteSpace(idText))
                {
                    MessageBox.Show("Vui lòng nhập ID!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(idText, out int id) || id < 0)
                {
                    MessageBox.Show("ID phải là một số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(maSV))
                {
                    MessageBox.Show("Vui lòng chọn mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(maMH))
                {
                    MessageBox.Show("Vui lòng chọn mã môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(diemText))
                {
                    MessageBox.Show("Vui lòng nhập điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(diemText, out decimal diem) || diem < 0 || diem > 10)
                {
                    MessageBox.Show("Điểm phải là một số từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketnoi();
                string checkQuery = "SELECT COUNT(*) FROM Diem WHERE id = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@id", id);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("ID đã tồn tại! Vui lòng nhập một ID khác.", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string query = "INSERT INTO Diem (id, masv, mamh, diem) VALUES (@id, @masv, @mamh, @diem)";
                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@masv", maSV);
                    cmd.Parameters.AddWithValue("@mamh", maMH);
                    cmd.Parameters.AddWithValue("@diem", diem);

                    int kq = cmd.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm thành công điểm với ID: " + id, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                        btnnl_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm điểm. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = cmbmasv.SelectedValue?.ToString();
                string maMH = cmbmamh.SelectedValue?.ToString();
                string diemText = txtdiem.Text.Trim();
                string idText = txtmaid.Text.Trim();

                if (string.IsNullOrWhiteSpace(idText))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập ID cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(idText, out int id) || id < 0)
                {
                    MessageBox.Show("ID phải là một số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(maSV))
                {
                    MessageBox.Show("Vui lòng chọn mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(maMH))
                {
                    MessageBox.Show("Vui lòng chọn mã môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(diemText))
                {
                    MessageBox.Show("Vui lòng nhập điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(diemText, out decimal diem) || diem < 0 || diem > 10)
                {
                    MessageBox.Show("Điểm phải là một số từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketnoi();
                string checkQuery = "SELECT COUNT(*) FROM Diem WHERE id = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@id", id);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy điểm với ID: " + id, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string updateQuery = "UPDATE Diem SET masv = @masv, mamh = @mamh, diem = @diem WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(updateQuery, sqlcon))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@masv", maSV);
                    cmd.Parameters.AddWithValue("@mamh", maMH);
                    cmd.Parameters.AddWithValue("@diem", diem);

                    int kq = cmd.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công điểm với ID: " + id, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                        btnnl_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật điểm. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string idText = txtmaid.Text.Trim();


                if (string.IsNullOrWhiteSpace(idText))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập ID điểm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(idText, out int id) || id <= 0)
                {
                    MessageBox.Show("ID điểm phải là một số nguyên dương hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM Diem WHERE id = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@id", id);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy điểm với ID: " + id, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm với ID: " + id + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (tl == DialogResult.Yes)
                {
                    string sql = "DELETE FROM Diem WHERE id = @id";
                    using (SqlCommand sqlcom = new SqlCommand(sql, sqlcon))
                    {
                        sqlcom.Parameters.AddWithValue("@id", id);
                        int n = sqlcom.ExecuteNonQuery();

                        if (n > 0)
                        {
                            MessageBox.Show("Xóa thành công điểm với ID: " + id, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnnl_Click(sender, e);
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa điểm, vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Xóa điểm đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
