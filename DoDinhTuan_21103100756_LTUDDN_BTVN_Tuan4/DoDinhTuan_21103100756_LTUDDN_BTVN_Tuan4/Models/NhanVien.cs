using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoDinhTuan_21103100756_LTUDDN_BTVN_Tuan4.Models
{
    public class NhanVien
    {
        [Key]
        [DisplayName("Mã nhân viên")]
        public int MaNV { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage ="Tên phải có ít nhất hai kí tự")]
        [DisplayName("Họ tên")]
        public string HoTen { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [Required]
        [DisplayName("Giới tính")]
        public bool GioiTinh { get; set; }
        [Required]
        [DisplayName("Điện thoại")]
        public string DienThoai { get; set; }
        [Required]
        [DisplayName("Hệ số lương")]
        [Range(1, int.MaxValue)]
        public double HeSoLuong { get; set; }
        [Required]
        [DisplayName("Lương")]
        [Range(1, int.MaxValue)]
        public double Luong { get; set; }
        [Required]
        [DisplayName("Tên phòng")]
        public string  TenPhong { get; set; }
    }
}