using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace CodeFirst_EF.Models
{
    public partial class ShopDataContext : DbContext
    {
        public ShopDataContext()
            : base("name=ShopDataContext")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Oders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
