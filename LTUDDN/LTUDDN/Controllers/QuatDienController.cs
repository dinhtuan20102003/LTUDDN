using LTUDDN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTUDDN.Controllers
{
    public class QuatDienController : Controller
    {
        // GET: QuatDien
        public static List<QuatDien> quatdiens = new List<QuatDien>
        {
            new QuatDien{MaSp = 1, HangSanXuat = "Panasonic", NgayXuatXuong = new DateTime(2024,10,20), LuuLuongGio = 50, DonGia = 50000, SoLuong = 10 },
            new QuatDien{MaSp = 2, HangSanXuat = "Asia", NgayXuatXuong = new DateTime(2024,10,20), LuuLuongGio = 60, DonGia = 50000, SoLuong = 10}
        };
        public ActionResult Index()
        {
            foreach (var quatDien in quatdiens)
            {
                quatDien.TinhThanhTien();
            }

            return View(quatdiens);
        }

        // GET: QuatDien/Details/5
        public ActionResult Details(int id)
        {
            var quatdien = quatdiens.FirstOrDefault(qd => qd.MaSp == id);
            if (quatdien == null)
            {
                HttpNotFound();
            }

            return View(quatdien);
        }

        // GET: QuatDien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuatDien/Create
        [HttpPost]
        public ActionResult Create(QuatDien newQD)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    newQD.MaSp = quatdiens.Max(qd => qd.MaSp) + 1;
                    quatdiens.Add(newQD);
                    return RedirectToAction("Index");
                }
                return View(newQD);

            }
            catch
            {
                return View();
            }
        }

        // GET: QuatDien/Edit/5
        public ActionResult Edit(int id)
        {
            var quatdien = quatdiens.FirstOrDefault(qd => qd.MaSp == id);
            if (quatdien == null)
            {
                HttpNotFound();
            }

            return View(quatdien);
        }

        // POST: QuatDien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, QuatDien updateQD)
        {
            try
            {

                var quatdien = quatdiens.FirstOrDefault(qd => qd.MaSp == id);
                if (quatdien == null)
                {
                    HttpNotFound();
                }
                else if (ModelState.IsValid)
                {
                    quatdien.HangSanXuat = updateQD.HangSanXuat;
                    quatdien.NgayXuatXuong = updateQD.NgayXuatXuong;
                    quatdien.LuuLuongGio = updateQD.LuuLuongGio;
                    quatdien.DonGia = updateQD.DonGia;
                    quatdien.SoLuong = updateQD.SoLuong;
                    return RedirectToAction("Index");
                }
                return View(quatdien);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: QuatDien/Delete/5
        public ActionResult Delete(int id)
        {
            var quatdien = quatdiens.FirstOrDefault(qd => qd.MaSp == id);
            if (quatdien == null)
            {
                HttpNotFound();
            }

            return View(quatdien);
        }

        // POST: QuatDien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var quatdien = quatdiens.FirstOrDefault(qd => qd.MaSp == id);
                if (quatdien != null)
                {
                    quatdiens.Remove(quatdien);
                    return RedirectToAction("Index");
                }
               return View();

               
            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Filter(string HangSanXuat)
        {
           var quatdien1 = quatdiens.Where(qd => qd.HangSanXuat == HangSanXuat).OrderBy(qd =>qd.DonGia).ToList();
            var tbc = quatdien1.Average(qd => qd.ThanhTien);
            var tong = quatdien1.Sum(qd => qd.ThanhTien);
            ViewBag.tong = tong;
            ViewBag.tbc = tbc;
            return View("Index", quatdien1);
        }

        public ActionResult HienThiGia(double Gia)
        {
            // Lọc danh sách các mặt hàng có Đơn Giá nhỏ hơn giá nhập vào
            var quatdien = quatdiens.Where(qd => qd.DonGia < Gia).ToList();

            // Truyền danh sách đã lọc vào View để hiển thị
            return View("Index", quatdien);
        }
    }
}
