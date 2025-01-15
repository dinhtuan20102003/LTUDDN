using Baitap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baitap.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public static List<NhanVien> nhanviens = new List<NhanVien>
        {
            new NhanVien{Manv = 1, HoTen = "Do Dinh Tuan", NgaySinh = new DateTime(2003,10,20), GioiTinh = true, DienThoai = "0987546216", HeSoLuong= 2.0, Luong = 300000, TenPhong = "CNTT" },
            new NhanVien{Manv = 2, HoTen = "Do Dinh Tuan", NgaySinh = new DateTime(1979,10,20), GioiTinh = true, DienThoai = "0987546216", HeSoLuong= 2.0, Luong = 400000, TenPhong = "CNTT" },
             new NhanVien{Manv = 3, HoTen = "Do Dinh Tuan", NgaySinh = new DateTime(1979,10,20), GioiTinh = true, DienThoai = "0987546216", HeSoLuong= 2.0, Luong = 200000, TenPhong = "CNTT" }
        };
        public ActionResult Index()
        {
            return View(nhanviens);
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(int id)
        {
            var nhanvien = nhanviens.FirstOrDefault(u => u.Manv == id);
            if (nhanvien == null)
            {
                HttpNotFound();
            }
            return View(nhanvien);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Create
        [HttpPost]
        public ActionResult Create(NhanVien newnv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newnv.Manv = nhanviens.Max(u => u.Manv) + 1;
                    nhanviens.Add(newnv);
                    return RedirectToAction("Index");
                }
                return View(newnv);
             
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            var nhanvien = nhanviens.FirstOrDefault(u=> u.Manv == id);
            if(nhanvien == null)
            {
                HttpNotFound();
            }
            return View(nhanvien);
        }

        // POST: NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,NhanVien undatenv)
        {
            try
            {
                // TODO: Add update logic here
                var nhanvien = nhanviens.FirstOrDefault(u => u.Manv == id);
                if (nhanvien == null)
                {
                    HttpNotFound();
                }
                else if (ModelState.IsValid){
                    nhanvien.HoTen = undatenv.HoTen;
                    nhanvien.NgaySinh = undatenv.NgaySinh;
                    nhanvien.HeSoLuong = undatenv.HeSoLuong;
                    nhanvien.Luong = undatenv.Luong;
                    nhanvien.TenPhong = undatenv.TenPhong;
                    return RedirectToAction("Index");
                }
                
                    
            return View(undatenv);
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            var nhanvien = nhanviens.FirstOrDefault(u =>u.Manv == id);
            if (nhanvien == null)
            {
                HttpNotFound();
            }
            return View(nhanvien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var nhanvien = nhanviens.FirstOrDefault(u => u.Manv == id);
              
                 if (nhanvien != null) { 
                    nhanviens.Remove(nhanvien);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
     
        public ActionResult TimKiemGioiTinhNu()
        {
            var nhanVienNu = nhanviens.Where(nv => nv.GioiTinh == false).ToList();
            return View("Index", nhanVienNu);
        }

     
        [HttpPost]
        public ActionResult TinhTongLuong(string tenPhong)
        {
            var tongLuong = nhanviens.Where(nv => nv.TenPhong == tenPhong).Sum(nv => nv.Luong);
            ViewBag.TongLuong = tongLuong;
            return View("Index", nhanviens);
        }

     
        [HttpPost]
        public ActionResult TimKiemTheoPhong(string tenPhong)
        {
            var nhanVienTheoPhong = nhanviens.Where(nv => nv.TenPhong.ToLower() == tenPhong.ToLower()).ToList();
            return View("Index", nhanVienTheoPhong);
        }
     
    }
}


