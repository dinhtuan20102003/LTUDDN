using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication10000000000000.Models
{
    public class HangHoa
    {
        [Required]
        [Key]
        public int MaHH { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Ten { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime NgaySX { get; set; }
        [Required]
        public int DonGia { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [ScaffoldColumn(false)]
        public int ThanhTien
        {
            get
            {
                return DonGia * SoLuong;
            }
        }
        [Required]
        public string LoaiHang { get; set; }
    }
}