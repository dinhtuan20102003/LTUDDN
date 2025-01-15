using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst_EF.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Vui lòng nhập tên từ 2 đến 30 kí tự")]
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}