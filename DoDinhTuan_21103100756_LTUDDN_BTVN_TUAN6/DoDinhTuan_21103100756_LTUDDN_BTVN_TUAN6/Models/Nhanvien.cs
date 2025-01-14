using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoDinhTuan_21103100756_LTUDDN_BTVN_TUAN6.Models
{
    public class Nhanvien
    {
        [Key]
        [StringLength(4)]
        [DisplayName("Mã nhân viên")]
        public string Manv { get; set; }
        [StringLength(10)]
        [DisplayName("Tên quầy")]
        public string Tenquay { get; set; }
        [StringLength(30)]
        [DisplayName("Họ tên")]
        public string Hoten { get; set; }
        public virtual ICollection<Banhang> Banhangs { get; set; }
    }
}