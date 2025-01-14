using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Quanlysinhvien
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
        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult tl;
            tl = MessageBox.Show("Bạn có muốn đóng chương trình không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tl == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        public string HashPassword(string password, int length = 16)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder result = new StringBuilder();
                foreach (byte b in bytes)
                {
                    result.Append(b.ToString("x2"));
                }
                return result.ToString().Substring(0, length).ToUpper();
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
        int sai = 3;
        //int tk = 0;
        //string kt = "";
        private void OK_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ketnoi();
            //    string tentk = txttk.Text;
            //    string mk = txtmk.Text;

            //    if (string.IsNullOrWhiteSpace(tentk))
            //    {
            //        MessageBox.Show("Bạn chưa nhập tên tài khoản!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }

            //    if (string.IsNullOrWhiteSpace(mk))
            //    {
            //        MessageBox.Show("Bạn chưa nhập mật khẩu!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }

            //    string taikhoan = "select count(*) from Admin where tk = @Username and mk = @Password";
            //    string hashedPassword = HashPassword(mk);
            //    SqlCommand cmd = new SqlCommand(taikhoan, sqlcon);
            //    cmd.Parameters.AddWithValue("@Username", tentk);
            //    cmd.Parameters.AddWithValue("@Password", hashedPassword);
            //    int i = Convert.ToInt32(cmd.ExecuteScalar());
            //    cmd.Dispose();

            //    string taikhoanu = "select count(*) from NguoiDung where tk = @Username and mk = @Password";
            //    SqlCommand cmd1 = new SqlCommand(taikhoanu, sqlcon);
            //    cmd1.Parameters.AddWithValue("@Username", tentk);
            //    cmd1.Parameters.AddWithValue("@Password", mk);
            //    int u = Convert.ToInt32(cmd1.ExecuteScalar());
            //    cmd1.Dispose();

            //    string taikhoangv = "select count(*) from Gv where tk = @Username and mk = @Password";
            //    SqlCommand cmd2 = new SqlCommand(taikhoangv, sqlcon);
            //    cmd2.Parameters.AddWithValue("@Username", tentk);
            //    cmd2.Parameters.AddWithValue("@Password", mk);
            //    int gv = Convert.ToInt32(cmd2.ExecuteScalar());
            //    cmd2.Dispose();

            //    string taikhoantkhoa = "select count(*) from Truongkhoa where tk = @Username and mk = @Password";
            //    SqlCommand cmd3 = new SqlCommand(taikhoantkhoa, sqlcon);
            //    cmd3.Parameters.AddWithValue("@Username", tentk);
            //    cmd3.Parameters.AddWithValue("@Password", mk);
            //    int tkhoa = Convert.ToInt32(cmd3.ExecuteScalar());
            //    cmd3.Dispose();

            //    if (sai > 0)
            //    {
            //        if (i != 0)
            //        {
            //            this.Close();
            //            MessageBox.Show("Bạn đã đăng nhập vào tài khoản Admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            tk = 0;
            //            Menu f = new Menu();
            //            f.UserName = "Chào mừng bạn đến với tài khoản Admin: " + tentk;
            //            f.Ts_Btn_capnhatdiem.Visible = false;
            //            f.Show();
            //        }
            //        else if (gv != 0)
            //        {
            //            this.Close();
            //            MessageBox.Show("Bạn đã đăng nhập vào tài khoản Giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            tk = 0;
            //            Menu f = new Menu();
            //            f.UserName = "Chào mừng bạn đến với tài khoản Giáo viên: " + tentk;
            //            f.Ts_Btn_dangnhap.Visible = false;
            //            f.Ts_Btn_admin.Visible = false;
            //            f.Ts_Btn_truongkhoa.Visible = false;
            //            f.Ts_Btn_giaovien.Visible = false;
            //            f.Ts_Btn_user.Visible = false;
            //            f.Ts_Btn_quanly.Visible = false;
            //            f.toolStripMenuItem1.Visible = false;
            //            f.Show();
            //        }
            //        else if (u != 0)
            //        {
            //            this.Close();
            //            MessageBox.Show("Bạn đã đăng nhập vào tài khoản User!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            tk = 0;
            //            Menu f = new Menu();
            //            f.UserName = "Chào mừng bạn đến với tài khoản User: " + tentk;
            //            f.Ts_Btn_dangnhap.Visible = false;
            //            f.Ts_Btn_admin.Visible = false;
            //            f.Ts_Btn_truongkhoa.Visible = false;
            //            f.Ts_Btn_giaovien.Visible = false;
            //            f.Ts_Btn_user.Visible = false;
            //            f.Ts_Btn_quanly.Visible = false;
            //            f.Ts_Btn_capnhatdiem.Visible = false;
            //            f.toolStripMenuItem1.Visible = false;
            //            f.Show();

            //        }
            //        else if (tkhoa != 0)
            //        {
            //            this.Close();
            //            MessageBox.Show("Bạn đã đăng nhập vào tài khoản Trưởng khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            tk = 0;
            //            Menu f = new Menu();
            //            f.UserName = "Chào mừng bạn đến với tài khoản Trưởng khoa: " + tentk;
            //            f.Ts_Btn_dangnhap.Visible = false;
            //            f.Ts_Btn_admin.Visible = false;
            //            f.Ts_Btn_truongkhoa.Visible = false;
            //            f.Ts_Btn_giaovien.Visible = false;
            //            f.Ts_Btn_user.Visible = false;
            //            f.Ts_Btn_capnhatdiem.Visible = false;
            //            f.toolStripMenuItem1.Visible = false;
            //            f.Show();

            //        }
            //        else
            //        {
            //            sai--;
            //            if (sai > 0)
            //            {
            //                MessageBox.Show("Tên tài khoản hoặc mật khẩu sai! Bạn còn " + sai + " lần đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                this.txttk.Clear();
            //                this.txtmk.Clear();
            //                this.txttk.Focus();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Bạn đã hết lượt truy cập. Mời bạn đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                this.Close();
            //                Batdau batdau = new Batdau();
            //                batdau.Show();
            //            }
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            try
            {
                ketnoi(); 
                string tendn = txttk.Text.Trim();
                string matkhau = txtmk.Text.Trim();

                if (string.IsNullOrWhiteSpace(tendn))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttk.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(matkhau))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmk.Focus();
                    return;
                }

                string hashedPassword = HashPassword(matkhau); 
                string query = "SELECT tendd, chucvu, trangthai FROM Login WHERE tendn = @tendn AND matkhau = @matkhau";

                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    cmd.Parameters.AddWithValue("@tendn", tendn);
                    cmd.Parameters.AddWithValue("@matkhau", hashedPassword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string tendd = reader["tendd"].ToString(); 
                            string chucvu = reader["chucvu"].ToString(); 
                            bool trangthai = Convert.ToBoolean(reader["trangthai"]); 

                            if (!trangthai)
                            {
                                MessageBox.Show("Tài khoản của bạn đang bị khóa. Vui lòng liên hệ quản trị viên!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txttk.Clear();
                                txtmk.Clear();
                                txttk.Focus();
                                return;
                            }

                            MessageBox.Show($"Bạn đã đăng nhập vào tài khoản {chucvu}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OpenMainMenu(tendd, chucvu);

                        }
                        else
                        {
                            sai--; 
                            if (sai > 0)
                            {
                                MessageBox.Show($"Tên đăng nhập hoặc mật khẩu không đúng! Bạn còn {sai} lần đăng nhập.", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txttk.Clear();
                                txtmk.Clear();
                                txttk.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Bạn đã hết lượt truy cập. Mời bạn đăng nhập lại!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Hide();
                                Batdau batdau = new Batdau();
                                batdau.Show();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenMainMenu(string tendd, string chucvu)
        {
            string greeting = $"Chào mừng bạn đến với tài khoản {chucvu}: {tendd}";
            this.Hide(); 
            Menu menu = new Menu();
            menu.UserName = greeting;

            switch (chucvu.ToLower())
            {
                case "admin":
                    menu.Ts_Btn_capnhatdiem.Visible = false;
                    menu.Ts_Btn_dangnhap.Visible = false;
                    break;
                case "giáo viên":
                    menu.Ts_Btn_tk.Visible = false;
                    menu.Ts_Btn_dangnhap.Visible = false;
                    //menu.Ts_Btn_admin.Visible = false;
                    //menu.Ts_Btn_truongkhoa.Visible = false;
                    //menu.Ts_Btn_giaovien.Visible = false;
                    //menu.Ts_Btn_user.Visible = false;
                    menu.Ts_Btn_quanly.Visible = false;
                    menu.toolStripMenuItem1.Visible = false;
                    break;
                case "người dùng":
                    menu.Ts_Btn_tk.Visible = false;
                    menu.Ts_Btn_dangnhap.Visible = false;
                    //menu.Ts_Btn_admin.Visible = false;
                    //menu.Ts_Btn_truongkhoa.Visible = false;
                    //menu.Ts_Btn_giaovien.Visible = false;
                    //menu.Ts_Btn_user.Visible = false;
                    menu.Ts_Btn_quanly.Visible = false;
                    menu.Ts_Btn_capnhatdiem.Visible = false;
                    menu.toolStripMenuItem1.Visible = false;
                    break;
                case "trưởng khoa":
                    menu.Ts_Btn_tk.Visible = false;
                    menu.Ts_Btn_dangnhap.Visible = false;
                    //menu.Ts_Btn_admin.Visible = false;
                    //menu.Ts_Btn_truongkhoa.Visible = false;
                    //menu.Ts_Btn_giaovien.Visible = false;
                    //menu.Ts_Btn_user.Visible = false;
                    menu.Ts_Btn_capnhatdiem.Visible = false;
                    menu.toolStripMenuItem1.Visible = false;
                    break;
                default:
                    MessageBox.Show("Vai trò không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            menu.Show(); 
        }







        private void Cancel_Click(object sender, EventArgs e)
        {
            Batdau f = new Batdau();
            f.Show();
            this.Close();
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


    }
}
