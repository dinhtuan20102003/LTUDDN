using DoDinhTuan_21103100756_LTUDDN_BTVN_Tuan4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_LTUDDN_BTVN_Tuan4.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public static List<NhanVien> nhanviens = new List<NhanVien>
        {
            new NhanVien{ MaNV =1, HoTen = "Do Dinh Tuan",NgaySinh = new DateTime(2003,10,20), GioiTinh = true, DienThoai = "0987546216", HeSoLuong = 2, Luong= 500000, TenPhong ="CNTT" },
               new NhanVien{ MaNV =2, HoTen = "Do Dinh Hung",NgaySinh = new DateTime(2003,10,20), GioiTinh = true, DienThoai = "0987546216", HeSoLuong = 2, Luong= 600000, TenPhong ="ATTT" },
                  new NhanVien{ MaNV =3, HoTen = "Do Dinh Dung",NgaySinh = new DateTime(2003,10,20), GioiTinh = true, DienThoai = "0987546216", HeSoLuong = 2, Luong= 700000, TenPhong ="ABCD" },
                     new NhanVien{ MaNV =4, HoTen = "Do Thi Linh",NgaySinh = new DateTime(2003,10,20), GioiTinh = false, DienThoai = "0987546216", HeSoLuong = 2, Luong= 800000, TenPhong ="CNTT" },
                        new NhanVien{ MaNV =5, HoTen = "Do Dinh Khoi",NgaySinh = new DateTime(2003,10,20), GioiTinh = true, DienThoai = "0987546216", HeSoLuong = 2, Luong= 900000, TenPhong ="CNTT" }
        };
        public ActionResult Index()
        {
            return View(nhanviens);
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(int id)
        {
            var nhanvien = nhanviens.FirstOrDefault(nv => nv.MaNV == id);
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
        public ActionResult Create(NhanVien newNV)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newNV.MaNV = nhanviens.Max(nv => nv.MaNV) + 1;
                    nhanviens.Add(newNV);
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here
                return View(newNV);

            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            var nhanvien = nhanviens.FirstOrDefault(nv => nv.MaNV == id);
            if (nhanvien == null)
            {
                HttpNotFound();
            }
            return View(nhanvien);

        }

        // POST: NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NhanVien updateNV)
        {
            try
            {
                var nhanvien = nhanviens.FirstOrDefault(nv => nv.MaNV == id);
                if (nhanvien == null)
                {
                    HttpNotFound();
                }
                else if (ModelState.IsValid)
                {

                    nhanvien.HoTen = updateNV.HoTen;
                    nhanvien.NgaySinh = updateNV.NgaySinh;
                    nhanvien.GioiTinh = updateNV.GioiTinh;
                    nhanvien.DienThoai = updateNV.DienThoai;
                    nhanvien.HeSoLuong = updateNV.HeSoLuong;
                    nhanvien.Luong = updateNV.Luong;
                    nhanvien.TenPhong = updateNV.TenPhong;
                    return RedirectToAction("Index");
                }
                return View(updateNV);

            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            var nhanvien = nhanviens.FirstOrDefault(nv => nv.MaNV == id);
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
                var nhanvien = nhanviens.FirstOrDefault(nv => nv.MaNV == id);
                if (nhanvien != null)
                {
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
        public ActionResult Gioitinh()
        {
            var nhanvien = nhanviens.Where(nv =>nv.GioiTinh == false).ToList();
            return View("Index", nhanvien);
        }

        public ActionResult TongLuong(string tenPhong) {
            var tongLuong = nhanviens.Where(nv => nv.TenPhong == tenPhong).Sum(nv => nv.Luong);
            ViewBag.TongLuong = tongLuong;
            return View("Index", nhanviens);
        }
        public ActionResult TimKiemTheoPhong(string tenPhong)
        {
            var nhanvien = nhanviens.Where(nv => nv.TenPhong.ToLower() == tenPhong.ToLower()).ToList();
            return View("Index", nhanvien);
        }
    }
}
