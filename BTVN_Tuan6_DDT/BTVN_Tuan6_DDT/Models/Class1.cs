using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTVN_Tuan6_DDT.Models
{
    public class Class1
    {
        [Key]
        public string Manv { get; set; }
        public string Hoten { get; set; }
        public int Tongsl { get; set; }
    }
}