using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTUDDN.Models
{
    public class QuatDien
    {
        [Key]
        public int MaSp { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string HangSanXuat { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime NgayXuatXuong { get; set; }
        [Required]
        public int LuuLuongGio { get; set; }
        [Required]
        public double DonGia { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [ScaffoldColumn(false)]
        public double ThanhTien { get; set; }

        public void TinhThanhTien()
        {
            double tongTien = DonGia * SoLuong;
            double thue;
            if (HangSanXuat == "Panasonic" && LuuLuongGio > 40)
            {
                thue = 0.05 * tongTien;
            }
            else if (HangSanXuat == "Asia" && LuuLuongGio > 50)
            {
                thue = 0.07 * tongTien;
            }
            else
            {
                thue = 0.1 * tongTien;
            }
            ThanhTien = tongTien + thue;
        }

    }
}