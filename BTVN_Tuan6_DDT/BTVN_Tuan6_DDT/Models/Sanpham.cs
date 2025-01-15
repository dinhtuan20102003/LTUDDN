using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTVN_Tuan6_DDT.Models
{
    public class Sanpham
    {
        [Key]
        [StringLength(5)]
        public string Masp { get; set; }
        [StringLength(20)]
        public string Tensp { get; set; }
        public virtual ICollection<Banhang> Banhangs { get; set; }
    }
}