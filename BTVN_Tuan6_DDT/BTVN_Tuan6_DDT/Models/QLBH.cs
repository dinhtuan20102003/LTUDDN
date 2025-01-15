using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace BTVN_Tuan6_DDT.Models
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
