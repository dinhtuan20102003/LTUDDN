using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _27_LTUDDN_DoDinhTuan.Models
{
    public class SinhVien
    {
        [Key]
        [DisplayName("Mã sinh viên")]
        public int masv { get; set; }
        [DisplayName("Họ tên")]
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string hoten { get; set; }
        [DisplayName("Năm sinh")]
        [Required]
        [Range(2000, 2006)]
        public int namsinh { get; set; }
        [DisplayName("Giới tính")]
        [Required]
        public bool gioitinh { get; set; }
        [DisplayName("Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public virtual ICollection<Diem> Diems { get; set; }
    }
}