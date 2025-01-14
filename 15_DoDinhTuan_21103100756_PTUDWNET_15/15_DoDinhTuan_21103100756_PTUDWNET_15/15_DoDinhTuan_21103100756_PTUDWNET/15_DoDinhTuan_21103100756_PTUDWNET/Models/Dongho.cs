using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _15_DoDinhTuan_21103100756_PTUDWNET.Models
{
    public class Dongho
    {
        private String masp;
        private String tensp;
        private String phanloai;
        private int soluong;
        private decimal dongia;
        private String hinhanh;

        public Dongho()
        {
        }

        public Dongho(string masp, string tensp, string phanloai, int soluong, decimal dongia, string hinhanh)
        {
            this.Masp = masp;
            this.Tensp = tensp;
            this.Phanloai = phanloai;
            this.Soluong = soluong;
            this.Dongia = dongia;
            this.Hinhanh = hinhanh;
        }

        public string Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Phanloai { get => phanloai; set => phanloai = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public decimal Dongia { get => dongia; set => dongia = value; }
        public string Hinhanh { get => hinhanh; set => hinhanh = value; }
    }
}