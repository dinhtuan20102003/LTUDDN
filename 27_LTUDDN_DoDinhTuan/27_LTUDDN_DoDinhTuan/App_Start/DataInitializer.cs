using _27_LTUDDN_DoDinhTuan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _27_LTUDDN_DoDinhTuan.App_Start
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<QLSVDataContext>
    {
        protected override void Seed(QLSVDataContext context)
        {
            context.SinhViens.Add(new SinhVien { masv = 1, hoten = "Nguyễn Đặng Tân", namsinh = 2002, gioitinh = true, email = "dat@gmail.com" });
            context.SinhViens.Add(new SinhVien { masv = 2, hoten = "Nguyênax Anh Văn", namsinh = 2003, gioitinh = true, email = "van@gmail.com" });
            context.SinhViens.Add(new SinhVien { masv = 3, hoten = "Vũ Anh Tuấn", namsinh = 2001, gioitinh = true, email = "tuan@gmail.com" });
            context.SaveChanges();
            context.Diems.Add(new Diem { masv = 1, tenmh = "Cơ sở dữ liệu", diem = 9.0 });
            context.Diems.Add(new Diem { masv = 1, tenmh = "Kỹ thuật lập trình", diem = 9.4 });
            context.Diems.Add(new Diem { masv = 2, tenmh = "Cơ sở dữ liệu", diem = 6.0 });
            context.Diems.Add(new Diem { masv = 2, tenmh = "Kỹ thuật lập trình", diem = 6.4 });
            context.Diems.Add(new Diem { masv = 3, tenmh = "Cơ sở dữ liệu", diem = 8.0 });
            context.Diems.Add(new Diem { masv = 3, tenmh = "Kỹ thuật lập trình", diem = 8.4 });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}