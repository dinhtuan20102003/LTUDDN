using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _27_LTUDDN_DoDinhTuan.Models
{
    public class Diem
    {
        [Required]
        [Key, Column(Order = 1)]
        [DisplayName("Mã sinh viên")]
        public int masv { get; set; }
        [Required]
        [Key, Column(Order = 0)]
        [DisplayName("Tên môn học")]
        public string tenmh { get; set; }
        [Required]
        [Range(0,10)]
        [DisplayName("Điểm")]
        public double diem { get; set; }
        public virtual SinhVien SinhVien { get; set; }
    }
}