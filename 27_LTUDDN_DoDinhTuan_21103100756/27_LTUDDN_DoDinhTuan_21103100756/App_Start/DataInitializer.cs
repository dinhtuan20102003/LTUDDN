using _27_LTUDDN_DoDinhTuan_21103100756.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _27_LTUDDN_DoDinhTuan_21103100756.App_Start
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<QLBanHangDataContext>
    {
        protected override void Seed(QLBanHangDataContext context)
        {
            context.SanPhams.Add(new SanPham { masp = 1, tensp = "Điện thoại Iphone 13", gia = 20000000, soluong = 10, loaisp = "Điện thoại" });
            context.SanPhams.Add(new SanPham { masp = 2, tensp = "Laptop Dell XPS", gia = 30000000, soluong = 5, loaisp = "Laptop" });
            context.SanPhams.Add(new SanPham { masp = 3, tensp = "Tai nghe AirPods", gia = 5000000, soluong = 20, loaisp = "Phụ kiện" });
            context.SaveChanges();
            context.HoaDons.Add(new HoaDon { mahd = 1, masp = 1, ngayban = new DateTime(2024, 07, 01), soluongban = 2 });
            context.HoaDons.Add(new HoaDon { mahd = 2, masp = 2, ngayban = new DateTime(2024, 06, 11), soluongban = 1 });
            context.HoaDons.Add(new HoaDon { mahd = 3, masp = 3, ngayban = new DateTime(2024, 08, 20), soluongban = 5 });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}