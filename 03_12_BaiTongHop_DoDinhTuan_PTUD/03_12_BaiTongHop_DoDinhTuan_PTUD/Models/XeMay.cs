using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_12_BaiTongHop_DoDinhTuan_PTUD.Models
{
    public class XeMay
    {
        private string bienso;
        private string tenxe;
        private string mau;
        private string hangsx;
        private string ngaysx;
        private int namsx;
        private string hinhanh;

        public XeMay()
        {
        }

        public XeMay(string bienso, string tenxe, string mau, string hangsx, string ngaysx, int namsx, string hinhanh)
        {
            this.Bienso = bienso;
            this.Tenxe = tenxe;
            this.Mau = mau;
            this.Hangsx = hangsx;
            this.Ngaysx = ngaysx;
            this.Namsx = namsx;
            this.Hinhanh = hinhanh;
        }

        public string Bienso { get => bienso; set => bienso = value; }
        public string Tenxe { get => tenxe; set => tenxe = value; }
        public string Mau { get => mau; set => mau = value; }
        public string Hangsx { get => hangsx; set => hangsx = value; }
        public string Ngaysx { get => ngaysx; set => ngaysx = value; }
        public int Namsx { get => namsx; set => namsx = value; }
        public string Hinhanh { get => hinhanh; set => hinhanh = value; }
    }
}