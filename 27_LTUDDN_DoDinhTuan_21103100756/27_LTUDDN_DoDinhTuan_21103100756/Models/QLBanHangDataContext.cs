using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace _27_LTUDDN_DoDinhTuan_21103100756.Models
{
    public partial class QLBanHangDataContext : DbContext
    {
        public QLBanHangDataContext()
            : base("name=QLBanHangDataContext")
        {
        }

        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<SanPham > SanPhams { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
