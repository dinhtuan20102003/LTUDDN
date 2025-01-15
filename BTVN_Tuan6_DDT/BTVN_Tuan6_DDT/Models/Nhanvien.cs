using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTVN_Tuan6_DDT.Models
{
    public class Nhanvien
    {
        [Key]
        [StringLength(4)]
        public string Manv { get; set; }
        [StringLength(10)]
        public string Tenquay { get; set; }
        [StringLength(30)]
        public string Hoten { get; set; }
        public virtual ICollection<Banhang> Banhangs { get; set; }
    }
}