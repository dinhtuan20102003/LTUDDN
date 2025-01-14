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

namespace QLThuvien_DoDinhTuan
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon;
        public void ketnoi()
        {
            try
            {

                string ketnoi;
                ketnoi = "server=DinhTuan\\SQLEXPRESS;database=QLSV;Integrated Security=True";
                sqlcon = new SqlConnection(ketnoi);
                sqlcon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa kết nối được, Bạn kiểm tra lại tên server và tên cơ sở dữ liệu!", "Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(ex.Message);
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult tl;
            tl = MessageBox.Show("Bạn có muốn đóng chương trình không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tl == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txtmk.Clear();
            txttk.Clear();
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

        private void OK_Click(object sender, EventArgs e)
        {
            string username = txttk.Text.Trim();
            string password = txtmk.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                ketnoi();
                string query = "SELECT fullname, mode FROM Login WHERE username = @username AND password = @password";
                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string fullname = reader["fullname"].ToString();
                        int mode = Convert.ToInt32(reader["mode"]);

                        MessageBox.Show($"Chào mừng {fullname}!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        switch (mode)
                        {
                            case 0:
                                break;

                            case 1:
     
                                break;
                            case 2:
                               
                                break;

                            case 3:
                              
                                break;
                            default:
                                MessageBox.Show("Phân quyền không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}
