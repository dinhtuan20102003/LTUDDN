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
    public partial class Cn_Giaovien : Form
    {
        SqlConnection sqlcon;
        public Cn_Giaovien()
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
            sql = "select  *from GiaoVien";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
        }
        private void Cn_Giaovien_Load(object sender, EventArgs e)
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
                txtmagv.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txttengv.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string gioiTinh = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    rdonam.Checked = true;
                    rdonu.Checked = false;
                }
                else if (gioiTinh == "Nu" || gioiTinh == "Nữ")
                {
                    rdonam.Checked = false;
                    rdonu.Checked = true;
                }
                datens.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtsdt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtdc.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtmagv.Enabled = false;
            }
            catch { }
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txtmagv.Clear();
            txttengv.Clear();
            txtsdt.Clear();
            txtdc.Clear();
            rdonam.Checked = false;
            rdonu.Checked = false;
            datens.ResetText();
            txtmagv.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string magv = txtmagv.Text.Trim();
                string tengv = txttengv.Text.Trim();
                string gioitinh = rdonam.Checked ? "Nam" : (rdonu.Checked ? "Nữ" : "");
                string ngaysinh = datens.Value.ToString("yyyy-MM-dd");
                string sdt = txtsdt.Text.Trim();
                string diachi = txtdc.Text.Trim();

                if (string.IsNullOrWhiteSpace(magv))
                {
                    MessageBox.Show("Vui lòng nhập mã giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (magv.Contains(" "))
                {
                    MessageBox.Show("Mã giáo viên không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tengv))
                {
                    MessageBox.Show("Vui lòng nhập tên giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(tengv, @"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂÊÔàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹĐđ\s]+$"))
                {
                    MessageBox.Show("Tên giáo viên chỉ được phép chứa chữ cái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!rdonam.Checked && !rdonu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ;
                }

                if (datens.Value == null || datens.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Vui lòng nhập ngày sinh của giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime ngaySinh = datens.Value;
                int tuoi = DateTime.Now.Year - ngaySinh.Year;
                if (ngaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--;

                if (tuoi < 18)
                {
                    MessageBox.Show("Giáo viên phải từ 18 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(sdt))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^0\d{9}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(diachi))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM GiaoVien WHERE magv = @magv";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@magv", magv);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã giáo viên đã tồn tại! Vui lòng nhập mã khác.", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string insertQuery = "INSERT INTO GiaoVien (magv, tengv, gioitinh, ngaysinh, sdt, diachi) " +
                                     "VALUES (@magv, @tengv, @gioitinh, @ngaysinh, @sdt, @diachi)";
                using (SqlCommand sqlcom = new SqlCommand(insertQuery, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@magv", magv);
                    sqlcom.Parameters.AddWithValue("@tengv", tengv);
                    sqlcom.Parameters.AddWithValue("@gioitinh", gioitinh);
                    sqlcom.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                    sqlcom.Parameters.AddWithValue("@sdt", sdt);
                    sqlcom.Parameters.AddWithValue("@diachi", diachi);
                    sqlcom.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công giáo viên với mã " + magv, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtmagv.Clear();
                txttengv.Clear();
                txtsdt.Clear();
                txtdc.Clear();
                rdonam.Checked = false;
                rdonu.Checked = false;
                datens.ResetText();
                load();
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
                string magv = txtmagv.Text.Trim();
                string tengv = txttengv.Text.Trim();
                string gioitinh = rdonam.Checked ? "Nam" : (rdonu.Checked ? "Nữ" : "");
                string ngaysinh = datens.Value.ToString("yyyy-MM-dd");
                string sdt = txtsdt.Text.Trim();
                string diachi = txtdc.Text.Trim();

                if (string.IsNullOrWhiteSpace(magv))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã giáo viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (magv.Contains(" "))
                {
                    MessageBox.Show("Mã giáo viên không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tengv))
                {
                    MessageBox.Show("Vui lòng nhập tên giáo viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(tengv, @"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂÊÔàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹĐđ\s]+$"))
                {
                    MessageBox.Show("Tên giáo viên chỉ được phép chứa chữ cái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(gioitinh))
                {
                    MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (datens.Value == null || datens.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Vui lòng nhập ngày sinh của giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime ngaySinh = datens.Value;
                int tuoi = DateTime.Now.Year - ngaySinh.Year;
                if (ngaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--;

                if (tuoi < 18)
                {
                    MessageBox.Show("Giáo viên phải từ 18 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(sdt))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^0\d{9}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(diachi))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM GiaoVien WHERE magv = @magv";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@magv", magv);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy giáo viên với mã: " + magv, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string updateQuery = "UPDATE GiaoVien SET tengv = @tengv, gioitinh = @gioitinh, ngaysinh = @ngaysinh, sdt = @sdt, diachi = @diachi WHERE magv = @magv";
                using (SqlCommand sqlcom = new SqlCommand(updateQuery, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@magv", magv);
                    sqlcom.Parameters.AddWithValue("@tengv", tengv);
                    sqlcom.Parameters.AddWithValue("@gioitinh", gioitinh);
                    sqlcom.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                    sqlcom.Parameters.AddWithValue("@sdt", sdt);
                    sqlcom.Parameters.AddWithValue("@diachi", diachi);

                    int kq = sqlcom.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công thông tin giáo viên với mã: " + magv, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtmagv.Clear();
                        txttengv.Clear();
                        txtsdt.Clear();
                        txtdc.Clear();
                        rdonam.Checked = false;
                        rdonu.Checked = false;
                        datens.ResetText();
                        txtmagv.Enabled = true;
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin giáo viên, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string maGV = txtmagv.Text.Trim();

                if (string.IsNullOrWhiteSpace(maGV))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã giáo viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM GiaoVien WHERE magv = @magv";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@magv", maGV);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy giáo viên với mã: " + maGV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                string checkSubjectQuery = "SELECT COUNT(*) FROM MonHoc WHERE magv = @magiaovien";
                using (SqlCommand checkSubjectCmd = new SqlCommand(checkSubjectQuery, sqlcon))
                {
                    checkSubjectCmd.Parameters.AddWithValue("@magiaovien", maGV);
                    int subjectCount = (int)checkSubjectCmd.ExecuteScalar();

                    if (subjectCount > 0)
                    {
                        MessageBox.Show($"Không thể xóa giáo viên {maGV} vì có môn học đang được phân công cho giáo viên này.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }



                DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa giáo viên với mã: " + maGV + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (tl == DialogResult.Yes)
                {
                    string sql = "DELETE FROM GiaoVien WHERE magv = @magv";
                    using (SqlCommand sqlcom = new SqlCommand(sql, sqlcon))
                    {
                        sqlcom.Parameters.AddWithValue("@magv", maGV);
                        int n = sqlcom.ExecuteNonQuery();

                        if (n > 0)
                        {
                            MessageBox.Show("Xóa thành công giáo viên với mã: " + maGV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtmagv.Clear();
                            txttengv.Clear();
                            txtsdt.Clear();
                            txtdc.Clear();
                            rdonam.Checked = false;
                            rdonu.Checked = false;
                            datens.ResetText();
                            txtmagv.Enabled = true;
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa giáo viên, vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Xóa giáo viên đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
