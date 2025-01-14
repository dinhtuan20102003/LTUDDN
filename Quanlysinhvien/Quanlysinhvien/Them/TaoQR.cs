using DevComponents.DotNetBar.Controls;
using Quanlysinhvien.Thongtin;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace Quanlysinhvien
{
    public partial class TaoQR : Form
    {
      

        public TaoQR()
        {
            InitializeComponent();
        }
        private SqlConnection sqlcon;
        private void ketnoi()
        {
            try
            {
                if (sqlcon == null || sqlcon.State == ConnectionState.Closed)
                {
                    string connectionString = "server=DinhTuan\\SQLEXPRESS;database=Quanlysinhvien;Integrated Security=True";
                    sqlcon = new SqlConnection(connectionString);
                    sqlcon.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadChinhsach()
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
                cmbmacs.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu chính sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadLop()
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
                cmbmalop.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu lớp: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GenerateStudentQRCode(string masv, string tensv, string gioitinh, string ngaysinh, string sodienthoai, string diachi, string macs, string malop)
        {
            try
            {
                string studentInfo = $"{masv}\n" +
                                     $"{tensv}\n" +
                                     $"{gioitinh}\n" +
                                     $"{ngaysinh}\n" +
                                     $"{sodienthoai}\n" +
                                     $"{diachi}\n" +
                                     $"{macs}\n" +
                                     $"{malop}";

                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(studentInfo);
                string base64String = Convert.ToBase64String(byteArray);

                BarcodeWriter barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,  
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Height = 270,   
                        Width = 270,   
                        PureBarcode = true  
                    }
                };

                var qrCodeImage = barcodeWriter.Write(base64String);
                pictureBoxQRCode.Image = qrCodeImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo mã QR: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Form2_Load(object sender, EventArgs e)
        {
            loadChinhsach();
            loadLop();
        }

        private void btnGenerateQRCode_Click(object sender, EventArgs e)
        {
            string masv = txtmasv.Text.Trim();
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

            string tensv = txttensv.Text.Trim();
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

            string gioitinh = "";
            if (rdonam.Checked)
                gioitinh = "Nam";
            else if (rdonu.Checked)
                gioitinh = "Nữ";
            else
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngaysinh = datens.Value;
            if (ngaysinh == DateTime.MinValue)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh của sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tuoi = DateTime.Now.Year - ngaysinh.Year;
            if (ngaysinh > DateTime.Now.AddYears(-tuoi)) tuoi--;

            if (tuoi < 17)
            {
                MessageBox.Show("Sinh viên phải từ 17 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sodienthoai = txtsdt.Text.Trim();
            if (string.IsNullOrWhiteSpace(sodienthoai))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(sodienthoai, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string diachi = txtdc.Text.Trim();
            if (string.IsNullOrWhiteSpace(diachi))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string macs = cmbmacs.SelectedValue?.ToString() ?? "Không có";

            if (cmbmacs.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã chính sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string malop = cmbmalop.SelectedValue?.ToString() ?? "Không có";
            if (cmbmalop.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerateStudentQRCode(masv, tensv, gioitinh, ngaysinh.ToString("dd/MM/yyyy"), sodienthoai, diachi, macs, malop);

        }

        public void GenerateStudentBarcode(string masv, string tensv, string gioitinh, string ngaysinh, string sodienthoai, string diachi, string macs, string malop)
        {
            try
            {
                string barcodeContent = $"{masv}|{tensv}|{gioitinh}|{ngaysinh}|{sodienthoai}|{diachi}|{macs}|{malop}";

      
                if (barcodeContent.Length > 80) 
                {
                    MessageBox.Show("Thông tin quá dài để tạo mã vạch. Hãy rút gọn thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               
                BarcodeWriter barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128, 
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Height = 100, 
                        Width = 300, 
                        PureBarcode = true 
                    }
                };

               
                var barcodeImage = barcodeWriter.Write(barcodeContent);
                pictureBoxQRCode.Image = barcodeImage; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo mã vạch: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            string masv = txtmasv.Text.Trim();
            string tensv = txttensv.Text.Trim();

         
            string gioitinh = rdonam.Checked ? "Nam" : (rdonu.Checked ? "Nữ" : "");
            string ngaysinh = datens.Value.ToString("dd/MM/yyyy");
            string sodienthoai = txtsdt.Text.Trim();
            string diachi = txtdc.Text.Trim();
            string macs = cmbmacs.SelectedValue?.ToString() ?? "Không có";
            string malop = cmbmalop.SelectedValue?.ToString() ?? "Không có";

            if (string.IsNullOrEmpty(masv))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên để tạo mã vạch.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerateStudentBarcode(masv, tensv, gioitinh, ngaysinh, sodienthoai, diachi, macs, malop);
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBoxQRCode.Image == null)
                {
                    MessageBox.Show("Không có mã QR nào để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG Image|*.png";
                    saveFileDialog.Title = "Lưu mã QR";
                    saveFileDialog.FileName = "QRCode.png";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        pictureBoxQRCode.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show("Lưu mã QR thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu mã QR: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
