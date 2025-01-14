using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlysinhvien.In
{
    public partial class In_gv : Form
    {
        public In_gv()
        {
            InitializeComponent();
        }

        private void In_gv_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlysinhvienDataSet.GiaoVien' table. You can move, or remove it, as needed.
            this.giaoVienTableAdapter.Fill(this.quanlysinhvienDataSet.GiaoVien);

            this.reportViewer1.RefreshReport();
        }
    }
}
