using BTVN_Tuan6_DDT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BTVN_Tuan6_DDT.App_Start
{
    public class MyDB : DropCreateDatabaseIfModelChanges<QLBH>
    {
        protected override void Seed(QLBH context)
        {
            context.Nhanviens.Add(new Nhanvien { Manv = "NV01", Tenquay = "Quầy 2", Hoten = "Mai Lan"});
            context.Nhanviens.Add(new Nhanvien { Manv = "NV02", Tenquay = "Quầy 1", Hoten = "Hồng Nhung" });
            context.SaveChanges();
            context.Sanphams.Add(new Sanpham { Masp = "SP001", Tensp = "Áo thun" });
            context.Sanphams.Add(new Sanpham { Masp = "SP002", Tensp = "Áo khoác" });
            context.Sanphams.Add(new Sanpham { Masp = "SP003", Tensp = "Quần Jean" });
            context.SaveChanges();
            context.Banhangs.Add(new Banhang { Manv = "NV01", Masp = "SP001", Dinhmuc = 30, Slban = 25 });
            context.Banhangs.Add(new Banhang { Manv = "NV01", Masp = "SP002", Dinhmuc = 30, Slban = 35 });
            context.Banhangs.Add(new Banhang { Manv = "NV02", Masp = "SP002", Dinhmuc = 30, Slban = 34 });
            context.Banhangs.Add(new Banhang { Manv = "NV02", Masp = "SP003", Dinhmuc = 30, Slban = 36 });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}