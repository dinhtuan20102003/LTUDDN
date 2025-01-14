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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace Quanlysinhvien
{
    public partial class CheckQR : Form
    {
        public CheckQR()
        {
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
            {
                cbCamera.Items.Add(device.Name);
                cbCamera.SelectedIndex = 0;
            }

            loadChinhsach();
            loadLop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
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
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Stop();
                pictureBox1.Image = null;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Stop();
                pictureBox1.Image = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
