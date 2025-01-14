using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoDinhTuan_21103100756_LTUDDN_BTVN_TUAN6.Models
{
    public class Banhang
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Key, Column(Order = 1)]
        [StringLength(4)]
        [DisplayName("Mã nhân viên")]
        public string Manv { get; set; }
        [Key, Column(Order = 2)]
        [StringLength(5)]
        [DisplayName("Mã sản phẩm")]
        public string Masp { get; set; }
        [DisplayName("Định mức")]
        public int Dinhmuc { get; set; }
        [DisplayName("Số lượng bán")]
        public int Slban { get; set; }
        public virtual Nhanvien Nhanvien { get; set; }
        public virtual Sanpham Sanpham { get; set; }
    }
}