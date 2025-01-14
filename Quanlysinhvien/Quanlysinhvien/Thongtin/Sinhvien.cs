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
    public partial class Sinhvien : Form
    {
        SqlConnection sqlcon;
        public Sinhvien()
        {
            InitializeComponent();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            In_sv f = new In_sv();
            f.Show();
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




        private void Sinhvien_Load(object sender, EventArgs e)
        {
            load();

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
                txtmacs.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtmalop.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
