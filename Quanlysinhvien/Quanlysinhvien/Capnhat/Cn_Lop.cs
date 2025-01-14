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
    public partial class Cn_Lop : Form
    {
        SqlConnection sqlcon;
        public Cn_Lop()
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
            sql = "select  *from Lop";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
        }
        public void loadKhoa()
        {
            try
            {
                ketnoi();
                string sql = "SELECT makhoa FROM Khoa";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);

                cmbkhoa.DataSource = dt;
                cmbkhoa.DisplayMember = "makhoa";
                cmbkhoa.ValueMember = "makhoa";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cn_Lop_Load(object sender, EventArgs e)
        {
            load();
            loadKhoa();
            cmbkhoa.SelectedIndex = -1;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtml.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txttl.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbkhoa.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtml.Enabled = false;
            }
            catch { }
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txtml.Clear();
            txttl.Clear();
            cmbkhoa.SelectedIndex = -1;
            txtml.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
                string maLop = txtml.Text.Trim();
                string tenLop = txttl.Text.Trim();
                //string maKhoa = cmbkhoa.SelectedValue.ToString();
                string maKhoa = cmbkhoa.SelectedValue?.ToString();

                if (string.IsNullOrWhiteSpace(maLop))
                {
                    MessageBox.Show("Bạn chưa nhập mã lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (maLop.Contains(" "))
                {
                    MessageBox.Show("Mã lớp không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tenLop))
                {
                    MessageBox.Show("Bạn chưa nhập tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(maKhoa))
                {
                    MessageBox.Show("Bạn chưa chọn mã khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string checkQuery = "SELECT COUNT(*) FROM Lop WHERE malop = @malop";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@malop", maLop);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã lớp đã tồn tại! Vui lòng nhập mã lớp khác.", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string query = "INSERT INTO Lop (malop, tenlop, makhoa) VALUES (@malop, @tenlop, @makhoa)";
                using (SqlCommand sqlcom = new SqlCommand(query, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@malop", maLop);
                    sqlcom.Parameters.AddWithValue("@tenlop", tenLop);
                    sqlcom.Parameters.AddWithValue("@makhoa", maKhoa);
                    sqlcom.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công lớp với mã: " + maLop, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtml.Clear();
                txttl.Clear();
                cmbkhoa.SelectedIndex = -1;
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
                string maLop = txtml.Text.Trim();
                string tenLop = txttl.Text.Trim();
                string maKhoa = cmbkhoa.SelectedValue?.ToString();

                if (string.IsNullOrWhiteSpace(maLop))
                {
                    MessageBox.Show("Vui lòng choặn hoặc nhập mã lớp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtml.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(tenLop))
                {
                    MessageBox.Show("Vui lòng nhập tên lớp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttl.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(maKhoa))
                {
                    MessageBox.Show("Vui lòng chọn mã khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbkhoa.Focus();
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM Lop WHERE malop = @malop";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@malop", maLop);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy lớp với mã: " + maLop, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string updateQuery = "UPDATE Lop SET tenlop = @tenlop, makhoa = @makhoa WHERE malop = @malop";
                using (SqlCommand sqlcom = new SqlCommand(updateQuery, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@malop", maLop);
                    sqlcom.Parameters.AddWithValue("@tenlop", tenLop);
                    sqlcom.Parameters.AddWithValue("@makhoa", maKhoa);

                    int kq = sqlcom.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công thông tin lớp với mã: " + maLop, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtml.Clear();
                        txttl.Clear();
                        cmbkhoa.SelectedIndex = -1;
                        txtml.Enabled = true;
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin lớp. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string maLop = txtml.Text.Trim();

                if (string.IsNullOrWhiteSpace(maLop))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã lớp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM Lop WHERE malop = @malop";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@malop", maLop);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy lớp với mã: " + maLop, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string checkStudentQuery = "SELECT COUNT(*) FROM SinhVien WHERE malop = @malop";
                using (SqlCommand checkStudentCmd = new SqlCommand(checkStudentQuery, sqlcon))
                {
                    checkStudentCmd.Parameters.AddWithValue("@malop", maLop);
                    int studentCount = (int)checkStudentCmd.ExecuteScalar();

                    if (studentCount > 0)
                    {
                        MessageBox.Show($"Không thể xóa lớp {maLop} vì có sinh viên đang học thuộc lớp này.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp với mã: " + maLop + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (tl == DialogResult.Yes)
                {
                    string sql = "DELETE FROM Lop WHERE malop = @malop";
                    using (SqlCommand sqlcom = new SqlCommand(sql, sqlcon))
                    {
                        sqlcom.Parameters.AddWithValue("@malop", maLop);
                        int n = sqlcom.ExecuteNonQuery();

                        if (n > 0)
                        {
                            MessageBox.Show("Xóa thành công lớp với mã: " + maLop, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtml.Clear();
                            txttl.Clear();
                            cmbkhoa.SelectedIndex = -1;
                            txtml.Enabled = true;
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa lớp, vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Xóa lớp đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
