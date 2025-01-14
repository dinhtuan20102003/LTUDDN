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
using ZXing;
namespace Quanlysinhvien.Quanly
{
    public partial class Cn_Sinhvien : Form
    {
        SqlConnection sqlcon;
        public Cn_Sinhvien()
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
            sql = "select  *from SinhVien";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
        }

        public void loadChinhsach()
        {
            try
            {
                ketnoi();
                string sql = "SELECT macs FROM ChinhSach";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);

                cmbmacs.DataSource = dt;
                cmbmacs.DisplayMember = "macs";
                cmbmacs.ValueMember = "macs";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadLop()
        {
            try
            {
                ketnoi();
                string sql = "SELECT malop FROM Lop";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);

                cmbmalop.DataSource = dt;
                cmbmalop.DisplayMember = "malop";
                cmbmalop.ValueMember = "malop";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Cn_Sinhvien_Load(object sender, EventArgs e)
        {
            load();
            loadChinhsach();
            loadLop();
            cmbmacs.SelectedIndex = -1;
            cmbmalop.SelectedIndex = -1;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtmasv.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txttensv.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
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
                cmbmacs.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                cmbmalop.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtmasv.Enabled =false;
            }
            catch { }
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txtmasv.Clear();
            txttensv.Clear();
            txtsdt.Clear();
            txtdc.Clear();
            rdonam.Checked = false;
            rdonu.Checked = false;
            datens.ResetText();
            cmbmacs.SelectedIndex = -1;
            cmbmalop.SelectedIndex = -1;
            txtmasv.Enabled = true;
            pictureBox1.Image = null;


        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string masv = txtmasv.Text.Trim();
                string tensv = txttensv.Text.Trim();
                string gioitinh = rdonam.Checked ? "Nam" : (rdonu.Checked ? "Nữ" : "");
                string ngaysinh = datens.Value.ToString("yyyy-MM-dd");
                string sdt = txtsdt.Text.Trim();
                string diachi = txtdc.Text.Trim();
                string macs = cmbmacs.SelectedValue?.ToString();
                string malop = cmbmalop.SelectedValue?.ToString();

                if (string.IsNullOrWhiteSpace(masv))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (masv.Contains(" "))
                {
                    MessageBox.Show("Mã sinh viên không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tensv))
                {
                    MessageBox.Show("Vui lòng nhập tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(tensv, @"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂÊÔàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹĐđ\s]+$"))
                {
                    MessageBox.Show("Tên sinh viên chỉ được phép chứa chữ cái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!rdonam.Checked && !rdonu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (datens.Value == null || datens.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Vui lòng nhập ngày sinh của sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime ngaySinh = datens.Value;
                int tuoi = DateTime.Now.Year - ngaySinh.Year;
                if (ngaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--;

                if (tuoi < 17)
                {
                    MessageBox.Show("Sinh viên phải từ 17 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                if (cmbmacs.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn mã chính sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbmalop.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn mã lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM SinhVien WHERE masv = @masv";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@masv", masv);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã sinh viên đã tồn tại! Vui lòng nhập mã khác.", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string insertQuery = "INSERT INTO SinhVien (masv, tensv, gioitinh, ngaysinh, sdt, diachi, macs, malop) " +
                                     "VALUES (@masv, @tensv, @gioitinh, @ngaysinh, @sdt, @diachi, @macs, @malop)";
                using (SqlCommand sqlcom = new SqlCommand(insertQuery, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@masv", masv);
                    sqlcom.Parameters.AddWithValue("@tensv", tensv);
                    sqlcom.Parameters.AddWithValue("@gioitinh", gioitinh);
                    sqlcom.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                    sqlcom.Parameters.AddWithValue("@sdt", sdt);
                    sqlcom.Parameters.AddWithValue("@diachi", diachi);
                    sqlcom.Parameters.AddWithValue("@macs", macs);
                    sqlcom.Parameters.AddWithValue("@malop", malop);
                    sqlcom.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công sinh viên với mã " + masv, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnnl_Click(sender, e);
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
                string masv = txtmasv.Text.Trim();
                string tensv = txttensv.Text.Trim();
                string gioitinh = rdonam.Checked ? "Nam" : (rdonu.Checked ? "Nữ" : "");
                string ngaysinh = datens.Value.ToString("yyyy-MM-dd");
                string sdt = txtsdt.Text.Trim();
                string diachi = txtdc.Text.Trim();
                string macs = cmbmacs.SelectedValue?.ToString();
                string malop = cmbmalop.SelectedValue?.ToString();

                if (string.IsNullOrWhiteSpace(masv))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (masv.Contains(" "))
                {
                    MessageBox.Show("Mã sinh viên không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tensv))
                {
                    MessageBox.Show("Vui lòng nhập tên sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(tensv, @"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂÊÔàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹĐđ\s]+$"))
                {
                    MessageBox.Show("Tên sinh viên chỉ được phép chứa chữ cái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(gioitinh))
                {
                    MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (datens.Value == null || datens.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Vui lòng nhập ngày sinh của sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                if (cmbmacs.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn mã chính sách cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbmalop.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn mã lớp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM SinhVien WHERE masv = @masv";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@masv", masv);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sinh viên với mã: " + masv, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string updateQuery = "UPDATE SinhVien SET tensv = @tensv, gioitinh = @gioitinh, ngaysinh = @ngaysinh, sdt = @sdt, diachi = @diachi, macs = @macs, malop = @malop WHERE masv = @masv";
                using (SqlCommand sqlcom = new SqlCommand(updateQuery, sqlcon))
                {
                    sqlcom.Parameters.AddWithValue("@masv", masv);
                    sqlcom.Parameters.AddWithValue("@tensv", tensv);
                    sqlcom.Parameters.AddWithValue("@gioitinh", gioitinh);
                    sqlcom.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                    sqlcom.Parameters.AddWithValue("@sdt", sdt);
                    sqlcom.Parameters.AddWithValue("@diachi", diachi);
                    sqlcom.Parameters.AddWithValue("@macs", macs);
                    sqlcom.Parameters.AddWithValue("@malop", malop);

                    int kq = sqlcom.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công thông tin sinh viên với mã: " + masv, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtmasv.Clear();
                        txttensv.Clear();
                        txtsdt.Clear();
                        txtdc.Clear();
                        rdonam.Checked = false;
                        rdonu.Checked = false;
                        datens.ResetText();
                        cmbmacs.SelectedIndex = -1;
                        cmbmalop.SelectedIndex = -1;
                        txtmasv.Enabled = true;
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin sinh viên, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string maSV = txtmasv.Text.Trim();

                if (string.IsNullOrWhiteSpace(maSV))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketnoi();

                string checkQuery = "SELECT COUNT(*) FROM SinhVien WHERE masv = @masv";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@masv", maSV);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sinh viên với mã: " + maSV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                string checkScoreQuery = "SELECT COUNT(*) FROM Diem WHERE masv = @masv";
                using (SqlCommand checkScoreCmd = new SqlCommand(checkScoreQuery, sqlcon))
                {
                    checkScoreCmd.Parameters.AddWithValue("@masv", maSV);
                    int scoreCount = (int)checkScoreCmd.ExecuteScalar();

                    if (scoreCount > 0)
                    {
                        MessageBox.Show($"Không thể xóa sinh viên {maSV} vì đã có điểm được ghi nhận cho sinh viên này.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên với mã: " + maSV + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (tl == DialogResult.Yes)
                {
                    string sql = "DELETE FROM SinhVien WHERE masv = @masv";
                    using (SqlCommand sqlcom = new SqlCommand(sql, sqlcon))
                    {
                        sqlcom.Parameters.AddWithValue("@masv", maSV);
                        int n = sqlcom.ExecuteNonQuery();

                        if (n > 0)
                        {
                            MessageBox.Show("Xóa thành công sinh viên với mã: " + maSV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtmasv.Clear();
                            txttensv.Clear();
                            txtsdt.Clear();
                            txtdc.Clear();
                            rdonam.Checked = false;
                            rdonu.Checked = false;
                            datens.ResetText();
                            cmbmacs.SelectedIndex = -1;
                            cmbmalop.SelectedIndex = -1;
                            txtmasv.Enabled = true;
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa sinh viên, vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Xóa sinh viên đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnqr_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Chọn ảnh để quét mã QR";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(filePath);

                DecodeQRCode(filePath);
            }
        }
        private void DecodeQRCode(string filePath)
        {
            try
            {
                BarcodeReader reader = new BarcodeReader();
                Bitmap bitmap = new Bitmap(filePath);

                var result = reader.Decode(bitmap);
                if (result != null)
                {
                    string qrCodeData = result.ToString();
                    string decodedString = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(qrCodeData));
                    string[] studentInfo = decodedString.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                    if (studentInfo.Length >= 8)
                    {
                        txtmasv.Text = studentInfo[0].Replace("Mã sinh viên: ", "").Trim();
                        txttensv.Text = studentInfo[1].Replace("Tên sinh viên: ", "").Trim();

                        string gioitinh = studentInfo[2].Replace("Giới tính: ", "").Trim();
                        if (gioitinh == "Nam")
                        {
                            rdonam.Checked = true;
                        }
                        else if (gioitinh == "Nữ")
                        {
                            rdonu.Checked = true;
                        }

                        datens.Text = studentInfo[3].Replace("Ngày sinh: ", "").Trim();
                        txtsdt.Text = studentInfo[4].Replace("Số điện thoại: ", "").Trim();
                        txtdc.Text = studentInfo[5].Replace("Địa chỉ: ", "").Trim();

                        string macs = studentInfo[6].Replace("Mã chính sách: ", "").Trim();
                        string malop = studentInfo[7].Replace("Mã lớp: ", "").Trim();

                        foreach (DataRowView item in cmbmacs.Items)
                        {
                            if (item["macs"].ToString() == macs)
                            {
                                cmbmacs.SelectedItem = item;
                                break;
                            }
                        }

                        foreach (DataRowView item in cmbmalop.Items)
                        {
                            if (item["malop"].ToString() == malop)
                            {
                                cmbmalop.SelectedItem = item;
                                break;
                            }
                        }
                    }
                    pictureBox1.Image = bitmap;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã QR trong ảnh.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi quét mã QR: {ex.Message}");
            }
        }
    }
}

