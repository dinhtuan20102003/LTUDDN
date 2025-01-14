using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuvien_DoDinhTuan
{
    public partial class Form1 : Form
    {
        NhanVien nv = new NhanVien();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = nv.DSNV();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable bc = nv.BangCap();
            txtbc.DataSource = bc;
            txtbc.DisplayMember = "TenBangCap";
            txtbc.ValueMember = "MaBangCap";
            txtbc.SelectedIndex = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtht.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtns.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtdc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtdt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtbc.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string hoTen = txtht.Text;
            DateTime ngaySinh = DateTime.Parse(txtns.Text);
            string diaChi = txtdc.Text;
            string dienThoai = txtdt.Text;
            int maBangCap = int.Parse(txtbc.SelectedValue.ToString());

            bool result = nv.ThemNhanVien(hoTen, ngaySinh, diaChi, dienThoai, maBangCap);
            if (result)
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = nv.DSNV(); 
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int maNhanVien = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string hoTen = txtht.Text;
            DateTime ngaySinh = DateTime.Parse(txtns.Text);
            string diaChi = txtdc.Text;
            string dienThoai = txtdt.Text;
            int maBangCap = int.Parse(txtbc.SelectedValue.ToString());

            bool result = nv.SuaNhanVien(maNhanVien, hoTen, ngaySinh, diaChi, dienThoai, maBangCap);
            if (result)
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = nv.DSNV();  
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            int maNhanVien = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                bool result = nv.XoaNhanVien(maNhanVien);
                if (result)
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = nv.DSNV();  
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnnl_Click(object sender, EventArgs e)
        {
            txtht.Clear();
            txtns.ResetText();
            txtdc.Clear();
            txtdt.Clear();
            txtbc.SelectedIndex = -1;
        }
    }
}
