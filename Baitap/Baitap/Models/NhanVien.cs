using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baitap.Models
{
    public class NhanVien
    {
        [Key]
        public int Manv { get; set; }
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Tên phải có ít nhất 6 kí tự và dài nhất 30")]
        public string HoTen { get; set; }
        [DataType(DataType.Date)]
        public  DateTime  NgaySinh { get; set; }
       
        public  bool GioiTinh { get; set; }
        [RegularExpression(@"^(0[3|5|7|8|9])+([0-9]{8})\b")]
        public string   DienThoai { get; set; }
        [Range(1.0, 5.0, ErrorMessage = "Hệ số lương phải từ 1.0 đến 5.0")]
        public double HeSoLuong { get; set; }

        public double Luong { get; set; }

        public string TenPhong { get; set; }

    }
}