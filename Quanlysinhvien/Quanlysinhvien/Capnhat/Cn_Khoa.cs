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
    public partial class Cn_Khoa : Form
    {
        SqlConnection sqlcon;
        public Cn_Khoa()
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
            string sql = "select  *from Khoa";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
        }
        private void Cn_Khoa_Load(object sender, EventArgs e)
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
                txtmk.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txttk.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtmk.Enabled = false;
            }
            catch { }
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txtmk.Clear();
            txttk.Clear();
            txtmk.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
                string maKhoa = txtmk.Text.Trim();
                string tenKhoa = txttk.Text;

                if (string.IsNullOrWhiteSpace(txtmk.Text))
                {
                    MessageBox.Show("Bạn chưa nhập mã khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (maKhoa.Contains(" "))
                {
                    MessageBox.Show("Mã khoa không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txttk.Text))
                {
                    MessageBox.Show("Bạn chưa nhập tên khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string query = "INSERT INTO Khoa (makhoa, tenkhoa) VALUES (@makhoa, @tenkhoa)";
                using (SqlCommand sqlcom = new SqlCommand(query, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@makhoa", maKhoa);
                    sqlcom.Parameters.AddWithValue("@tenkhoa", tenKhoa);
                    sqlcom.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công khoa với mã: " + maKhoa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txttk.Clear();
                txtmk.Clear();

                load();
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
                string maKhoa = txtmk.Text.Trim();
                string tenKhoa = txttk.Text.Trim();

                if (string.IsNullOrWhiteSpace(maKhoa))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã khoa cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmk.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(tenKhoa))
                {
                    MessageBox.Show("Vui lòng nhập tên khoa cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttk.Focus();
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM Khoa WHERE makhoa = @makhoa";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@makhoa", maKhoa);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy khoa với mã: " + maKhoa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string updateQuery = "UPDATE Khoa SET tenkhoa = @tenkhoa WHERE makhoa = @makhoa";
                using (SqlCommand sqlcom = new SqlCommand(updateQuery, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@makhoa", maKhoa);
                    sqlcom.Parameters.AddWithValue("@tenkhoa", tenKhoa);
                    int kq = sqlcom.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công thông tin khoa với mã: " + maKhoa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txttk.Clear();
                        txtmk.Clear();
                        txtmk.Enabled = true;
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin khoa. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string maKhoa = txtmk.Text.Trim();

                if (string.IsNullOrWhiteSpace(maKhoa))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã khoa cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM Khoa WHERE makhoa = @makhoa";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@makhoa", maKhoa);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy khoa với mã: " + maKhoa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string checkClassQuery = "SELECT COUNT(*) FROM Lop WHERE makhoa = @makhoa";
                using (SqlCommand checkClassCmd = new SqlCommand(checkClassQuery, sqlcon))
                {
                    checkClassCmd.Parameters.AddWithValue("@makhoa", maKhoa);
                    int classCount = (int)checkClassCmd.ExecuteScalar();

                    if (classCount > 0)
                    {
                        MessageBox.Show($"Không thể xóa khoa {maKhoa} vì có lớp học thuộc khoa này.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }



                DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa khoa với mã: " + maKhoa + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (tl == DialogResult.Yes)
                {
                    string sql = "DELETE FROM Khoa WHERE makhoa = @makhoa";
                    using (SqlCommand sqlcom = new SqlCommand(sql, sqlcon))
                    {
                        sqlcom.Parameters.AddWithValue("@makhoa", maKhoa);
                        int n = sqlcom.ExecuteNonQuery();

                        if (n > 0)
                        {
                            MessageBox.Show("Xóa thành công khoa với mã: " + maKhoa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtmk.Clear();
                            txttk.Clear();
                            txtmk.Enabled = true;
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa khoa, vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Xóa khoa đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
