using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoDinhTuan_21103100756_LTUDDN_BTVN_TUAN6.Models
{
    public class Tong
    {
        [Key]
        public string Manv { get; set; }
        [DisplayName("Họ tên")]
        public  string Hoten { get; set; }
        [DisplayName("Tổng số lượng bán")]
        public int Tongsl { get; set; }
    }
}