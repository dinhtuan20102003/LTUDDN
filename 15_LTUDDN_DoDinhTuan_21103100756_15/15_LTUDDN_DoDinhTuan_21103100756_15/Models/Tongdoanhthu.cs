using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _15_LTUDDN_DoDinhTuan_21103100756_15.Models
{
    public class Tongdoanhthu
    {
      
        public int MaBS { get; set; }
     
        public string TenBS { get; set; }
      
        public string ChuyenKhoa { get; set; }
      
        public Nullable<int> SoNamKinhNghiem { get; set; }
       
        public string DienThoai { get; set; }

        public Nullable<int> TongDoanhThu { get; set; }

    }
}