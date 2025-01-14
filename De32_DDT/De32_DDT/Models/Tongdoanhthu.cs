using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace De32_DDT.Models
{
    public class Tongdoanhthu
    {
     
        public int MaSach { get; set; }
    
        public string TenSach { get; set; }
     
        public string TheLoai { get; set; }
       
        public Nullable<decimal> DonGia { get; set; }
       
        public Nullable<int> SoLuongTon { get; set; }

        public Nullable<decimal> DoanhThu { get; set; }
    }
}