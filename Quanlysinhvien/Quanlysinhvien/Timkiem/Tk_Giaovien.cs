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

namespace Quanlysinhvien.Timkiem
{
    public partial class Tk_Giaovien : Form
    {
       
        public Tk_Giaovien()
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
        private void Tk_Giaovien_Load(object sender, EventArgs e)
        {
            ketnoi();
            this.cmbtimtheo.Items.Add("Tên giáo viên");
            this.cmbtimtheo.Items.Add("Địa chỉ");
            string sql = "select *from giaovien";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            ketnoi();
            SqlCommand tim;
            bool kt = false;
            bool kt1 = false;
            int count;
            if (string.IsNullOrWhiteSpace(txttukhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbtimtheo.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tengv = "select count(*) from giaovien where tengv like '%' + @tukhoa + '%'";
            tim = new SqlCommand(tengv, sqlcon);
            tim.Parameters.AddWithValue("@tukhoa", txttukhoa.Text);
            count = (int)tim.ExecuteScalar();

            if (count != 0 && cmbtimtheo.SelectedItem.ToString() == "Tên giáo viên")
            {
                kt = true;
            }

            if (kt)
            {
                MessageBox.Show("Đã tìm thấy dữ liệu!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string kq = "select *from giaovien where tengv like '%' + @tukhoa + '%'";
                SqlDataAdapter dt = new SqlDataAdapter(kq, sqlcon);
                dt.SelectCommand.Parameters.AddWithValue("@tukhoa", txttukhoa.Text);

                DataSet ds1 = new DataSet();
                dt.Fill(ds1);
                dataGridView1.DataSource = ds1.Tables[0];
            }
            else
            {

                string diachi = "select count(*) from giaovien where diachi like '%' + @tukhoa + '%'";
                tim = new SqlCommand(diachi, sqlcon);
                tim.Parameters.AddWithValue("@tukhoa", txttukhoa.Text);
                count = (int)tim.ExecuteScalar();

                if (count != 0 && cmbtimtheo.SelectedItem.ToString() == "Địa chỉ")
                {
                    kt1 = true;
                }

                if (kt1)
                {
                    MessageBox.Show("Đã tìm thấy dữ liệu!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string kq = "select *from giaovien where diachi like '%' + @tukhoa + '%'";

                    SqlDataAdapter dt = new SqlDataAdapter(kq, sqlcon);
                    dt.SelectCommand.Parameters.AddWithValue("@tukhoa", txttukhoa.Text);

                    DataSet ds1 = new DataSet();
                    dt.Fill(ds1);
                    dataGridView1.DataSource = ds1.Tables[0];
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttukhoa.ResetText();
                    cmbtimtheo.SelectedIndex = -1;
                }
            }
        }

        private void btntailai_Click(object sender, EventArgs e)
        {
            txttukhoa.ResetText();
            cmbtimtheo.SelectedIndex = -1;
            Tk_Giaovien_Load(sender, e);
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
