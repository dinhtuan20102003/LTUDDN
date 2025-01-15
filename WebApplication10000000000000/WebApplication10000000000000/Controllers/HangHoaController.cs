using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10000000000000.Models;

namespace WebApplication10000000000000.Controllers
{
    public class HangHoaController : Controller
    {
        // GET: HangHoa
        public static List<HangHoa> hanghoas = new List<HangHoa>
        {
            new HangHoa {MaHH = 1, Ten = "Banh", NgaySX = new DateTime(2024, 10,20), DonGia = 100, SoLuong=10, LoaiHang ="BanhKeo"},
             new HangHoa {MaHH = 2, Ten = "But", NgaySX = new DateTime(2024, 11,20), DonGia = 200, SoLuong=15, LoaiHang ="BanhKeo"},
              new HangHoa {MaHH = 3, Ten = "Thuoc", NgaySX = new DateTime(2024, 12,20), DonGia = 300, SoLuong=20, LoaiHang ="VPP"}
        };
        public ActionResult Index()
        {
           
            return View(hanghoas);
        }

        // GET: HangHoa/Details/5
        public ActionResult Details(int id)
        {
            var hanghoa = hanghoas.FirstOrDefault(hh => hh.MaHH == id);
            if (hanghoa == null)
            {
                HttpNotFound();
            }
            return View(hanghoa);
        }

        // GET: HangHoa/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: HangHoa/Create
        [HttpPost]
        public ActionResult Create(HangHoa newhh)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newhh.MaHH = hanghoas.Max(hh => hh.MaHH) + 1;
                    hanghoas.Add(newhh);
                    return RedirectToAction("Index");
                }
                return View(newhh);

            }
            catch
            {
                return View();
            }
        }

        // GET: HangHoa/Edit/5
        public ActionResult Edit(int id)
        {

            var hanghoa = hanghoas.FirstOrDefault(hh => hh.MaHH == id);
            if (hanghoa == null)
            {
                HttpNotFound();
            }
            return View(hanghoa);
        }

        // POST: HangHoa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HangHoa updatehh)
        {
            try
            {
                var hanghoa = hanghoas.FirstOrDefault(hh => hh.MaHH == id);
                if (hanghoa == null)
                {
                    HttpNotFound();
                }
                else if (ModelState.IsValid)
                {
                    hanghoa.Ten = updatehh.Ten;
                    hanghoa.NgaySX = updatehh.NgaySX;
                    hanghoa.DonGia = updatehh.DonGia;
                    hanghoa.SoLuong = updatehh.SoLuong;
                    hanghoa.LoaiHang = updatehh.LoaiHang;
                    return RedirectToAction("Index");
                }

                return View(updatehh);
            }
            catch
            {
                return View();
            }
        }

        // GET: HangHoa/Delete/5
        public ActionResult Delete(int id)
        {
            var hanghoa = hanghoas.FirstOrDefault(hh => hh.MaHH == id);
            if (hanghoa == null)
            {
                HttpNotFound();
            }
            return View(hanghoa);

        }

        // POST: HangHoa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var hanghoa = hanghoas.FirstOrDefault(hh => hh.MaHH == id);
                if (hanghoa != null)
                {
                    hanghoas.Remove(hanghoa);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Gia(int gia, string loaiHang)
        {
            
            var timkiem = hanghoas.Where(hh => hh.DonGia < gia).ToList();
            var hanghoa = hanghoas.Where(hh => hh.LoaiHang == loaiHang).ToList();
            var tong = hanghoa.Sum(hh => hh.ThanhTien);
            ViewBag.Tong = tong;
            return View("Index", timkiem);
         

           
        }

    }
}
