using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace _27_LTUDDN_DoDinhTuan.Models
{
    public partial class QLSVDataContext : DbContext
    {
        public QLSVDataContext()
            : base("name=QLSVDataContext")
        {
        }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Diem> Diems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
