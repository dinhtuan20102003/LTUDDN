using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace DoDinhTuan_21103100756_LTUDDN_BTVN_TUAN6.Models
{
    public partial class QLBH : DbContext
    {
        public QLBH()
            : base("name=QLBH")
        {

        }
        public DbSet<Nhanvien> Nhanviens { get; set; }
        public DbSet<Sanpham> Sanphams { get; set; }
        public DbSet<Banhang> Banhangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
