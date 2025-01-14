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
    public partial class Lop : Form
    {
        SqlConnection sqlcon;
        public Lop()
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
            sql = "select  *from Lop";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
        }
        private void Lop_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtml.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txttl.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtmakhoa.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
               
            }
            catch { }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
           In_lop f = new In_lop();
            f.Show();
        }

    }
}
