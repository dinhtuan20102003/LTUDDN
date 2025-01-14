using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _27_Đỗ_Đình_Tuấn_DHTI15A1CL.Models
{
    public class Xemay
    {
        private string bienso;
        private string tenxe;
        private string mau;
        private string hangsx;
        private int namsx;
        private string hinhanh;

        public string Bienso { get => bienso; set => bienso = value; }
        public string Tenxe { get => tenxe; set => tenxe = value; }
        public string Mau { get => mau; set => mau = value; }
        public string Hangsx { get => hangsx; set => hangsx = value; }
        public int Namsx { get => namsx; set => namsx = value; }
        public string Hinhanh { get => hinhanh; set => hinhanh = value; }

        public Xemay(string bienso, string tenxe, string mau, string hangsx, int namsx, string hinhanh)
        {
            this.Bienso = bienso;
            this.Tenxe = tenxe;
            this.Mau = mau;
            this.Hangsx = hangsx;
            this.Namsx = namsx;
            this.Hinhanh = hinhanh;
        }

        public Xemay()
        {
        }

    }
}