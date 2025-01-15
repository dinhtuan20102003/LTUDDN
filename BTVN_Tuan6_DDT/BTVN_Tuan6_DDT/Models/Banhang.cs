using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTVN_Tuan6_DDT.Models
{
    public class Banhang
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Key, Column(Order = 1)]
        public string Manv { get; set; }
        [Key, Column(Order = 2)]
        public string Masp { get; set; }
        public int Dinhmuc { get; set; }
        public int Slban { get; set; }
        public virtual Nhanvien Nhanvien { get; set; }
        public virtual Sanpham Sanpham { get; set; }
    }
}