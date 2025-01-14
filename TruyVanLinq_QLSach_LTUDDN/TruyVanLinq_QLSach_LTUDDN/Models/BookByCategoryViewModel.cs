using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruyVanLinq_QLSach_LTUDDN.Models
{
    public class BookByCategoryViewModel
    {
        public string CategoryName { get; set; }
        public int BookCount { get; set; }
        public Nullable<decimal> PriceSum { get; set; }
    }
}