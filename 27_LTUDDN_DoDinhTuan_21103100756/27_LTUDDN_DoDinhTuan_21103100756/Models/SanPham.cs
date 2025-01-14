using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _27_LTUDDN_DoDinhTuan_21103100756.Models
{
    public class SanPham
    {
        [Key,]
        [DisplayName("Mã sản phẩm")]
        public int masp { get; set; }
        [Required]
        [DisplayName("Tên sản phẩm")]
        [StringLength(50, MinimumLength = 5)]
        public string tensp { get; set; }
        [Required]
        [DisplayName("Giá")]
        [Range(1, int.MaxValue)]
        public decimal gia { get; set; }
        [Required]
        [DisplayName("Số lượng")]
     
        [Range(0, int.MaxValue)]
        public int soluong { get; set; }
        [Required]
        [DisplayName("Loại sản phẩm")]
        [StringLength(50)]
        public  string loaisp { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}