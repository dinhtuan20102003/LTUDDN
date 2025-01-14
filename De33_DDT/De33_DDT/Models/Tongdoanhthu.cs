using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace De33_DDT.Models
{
    public class Tongdoanhthu
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public string LoaiMon { get; set; }
        public Nullable<decimal> DonGia { get; set; }

        public Nullable<decimal> DoanhThu { get; set; }
    }
}