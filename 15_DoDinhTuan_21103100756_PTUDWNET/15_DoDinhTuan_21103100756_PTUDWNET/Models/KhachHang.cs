using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _15_DoDinhTuan_21103100756_PTUDWNET.Models
{
    public class KhachHang
    {
        private string makh;
        private string tenkh;
        private string email;
        private string gioitinh;
        private int sotk;
        private string hinhanh;


        public KhachHang()
        {
        }

        public KhachHang(string makh, string tenkh, string email, string gioitinh, int sotk, string hinhanh)
        {
            this.Makh = makh;
            this.Tenkh = tenkh;
            this.Email = email;
            this.Gioitinh = gioitinh;
            this.Sotk = sotk;
            this.Hinhanh = hinhanh;
        }

        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Email { get => email; set => email = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public int Sotk { get => sotk; set => sotk = value; }
        public string Hinhanh { get => hinhanh; set => hinhanh = value; }
    }
}