using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst_EF.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}