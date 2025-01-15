using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDT.Models
{
    public class DatSach
    {
        [Key]
        [DisplayName("Mã sách")]
        [Required(ErrorMessage = "Bạn chưa nhập mã sách")]
        public int MaSach { get; set; }
        [DisplayName("Mã tác giả")]
        [Required(ErrorMessage = "Bạn chưa nhập mã tác giả")]
        public int MaTG { get; set; }
        [DisplayName("Tên sách")]
        [Required(ErrorMessage = "Bạn chưa tên sách")]
        public string TenSach { get; set; }
        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = "Bạn chưa nhập đơn giá")]
        [Range(1, int.MaxValue, ErrorMessage = "Giá phải là số lớn hơn 0")]
        public decimal Gia { get; set; }
        [DisplayName("Số lượng")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng")]
        public int SoLuong { get; set; }
        public decimal ThanhTien
        {
            get
            {
                return SoLuong * Gia;
            }
        }

    }
}