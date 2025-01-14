using Quanlysinhvien.In;
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

namespace Quanlysinhvien.Thongtin
{
    public partial class Giaovien : Form
    {
        SqlConnection sqlcon;
        public Giaovien()
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
        private void btnin_Click(object sender, EventArgs e)
        {
            In_gv f = new In_gv();
            f.Show();
        }

        private void Giaovien_Load(object sender, EventArgs e)
        {
            load();
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
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi chọn dòng dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
