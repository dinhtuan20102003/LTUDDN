using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlysanpham.Models
{
    public class Sanpham
    {
        private int masp;
        private string tensp;
        private string hangsx;
        private string mota;
        private double dongia;
        private string ngaydang;
        private string hinhanh;

        public Sanpham()
        {
        }

        public Sanpham(int masp, string tensp, string hangsx, string mota, double dongia, string ngaydang, string hinhanh)
        {
            this.Masp = masp;
            this.Tensp = tensp;
            this.Hangsx = hangsx;
            this.Mota = mota;
            this.Dongia = dongia;
            this.Ngaydang = ngaydang;
            this.Hinhanh = hinhanh;
        }

        public int Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Hangsx { get => hangsx; set => hangsx = value; }
        public string Mota { get => mota; set => mota = value; }
        public double Dongia { get => dongia; set => dongia = value; }
        public string Ngaydang { get => ngaydang; set => ngaydang = value; }
        public string Hinhanh { get => hinhanh; set => hinhanh = value; }
    }
}