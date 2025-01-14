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
    public partial class In_lop : Form
    {
        public In_lop()
        {
            InitializeComponent();
        }

        private void In_lop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlysinhvienDataSet.Lop' table. You can move, or remove it, as needed.
            this.lopTableAdapter.Fill(this.quanlysinhvienDataSet.Lop);

            this.reportViewer1.RefreshReport();
        }
    }
}
