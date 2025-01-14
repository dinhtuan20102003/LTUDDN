using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _27_LTUDDN_DoDinhTuan_21103100756.Models
{
    public class HoaDon
    {
        [Key, Column(Order = 0)]
        [DisplayName("Mã hóa đơn")]
        public int mahd { get; set; }
        [Key, Column(Order = 1)]
        [Required]
        [DisplayName("Mã sản phẩm")]
        public int masp { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Ngày bán")]
        [Required]
        public DateTime ngayban { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        [DisplayName("Số lượng bán")]
        public int soluongban { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}