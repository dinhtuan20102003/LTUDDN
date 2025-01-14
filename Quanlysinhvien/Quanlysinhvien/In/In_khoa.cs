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
    public partial class In_khoa : Form
    {
        public In_khoa()
        {
            InitializeComponent();
        }

        private void In_khoa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlysinhvienDataSet.Khoa' table. You can move, or remove it, as needed.
            this.khoaTableAdapter.Fill(this.quanlysinhvienDataSet.Khoa);

            this.reportViewer1.RefreshReport();
        }
    }
}
