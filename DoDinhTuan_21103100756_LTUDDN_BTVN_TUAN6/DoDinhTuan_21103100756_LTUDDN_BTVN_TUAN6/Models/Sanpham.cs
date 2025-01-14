using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoDinhTuan_21103100756_LTUDDN_BTVN_TUAN6.Models
{
    public class Sanpham
    {
        [Key]
        [StringLength(5)]
        [DisplayName("Mã sản phẩm")]
        public string Masp { get; set; }
        [StringLength(20)]
        [DisplayName("Tên sản phẩm")]
        public string Tensp { get; set; }
        public virtual ICollection<Banhang> Banhangs { get; set; }
    }
}