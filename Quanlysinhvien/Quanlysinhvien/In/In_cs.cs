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
    public partial class In_cs : Form
    {
        public In_cs()
        {
            InitializeComponent();
        }

        private void In_cs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlysinhvienDataSet.ChinhSach' table. You can move, or remove it, as needed.
            this.chinhSachTableAdapter.Fill(this.quanlysinhvienDataSet.ChinhSach);

            this.reportViewer1.RefreshReport();
        }
    }
}
