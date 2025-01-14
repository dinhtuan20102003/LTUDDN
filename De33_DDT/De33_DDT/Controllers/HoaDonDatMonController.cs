using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using De33_DDT.Models;

namespace De33_DDT.Controllers
{
    public class HoaDonDatMonController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: HoaDonDatMon
        public ActionResult Index()
        {
            var hoaDonDatMons = db.HoaDonDatMons.Include(h => h.KhachHang).Include(h => h.MonAn);
            return View(hoaDonDatMons.ToList());
        }
        public ActionResult TimKiem(string timkiem, string timkiem1)
        {
            var hoaDonDatMons = db.HoaDonDatMons.Include(h => h.KhachHang).Include(h => h.MonAn);
            //var loaimon = db.HoaDonDatMons.Select(l => l.MonAn.LoaiMon).Distinct().ToList();
            //ViewBag.Loaimon = new SelectList(loaimon);
            ViewBag.Loaimon = new SelectList(db.MonAns.Select(l => l.LoaiMon).Distinct().ToList(), "LoaiMon");

            if (!string.IsNullOrWhiteSpace(timkiem))
            {
                timkiem = timkiem.Trim().ToLower();
                hoaDonDatMons = hoaDonDatMons.Where(h => h.KhachHang.HoTen.Trim().ToLower().Contains(timkiem));
            }
            if (!string.IsNullOrWhiteSpace(timkiem))
            {
                timkiem1 = timkiem1.Trim().ToLower();
                hoaDonDatMons = hoaDonDatMons.Where(h => h.MonAn.LoaiMon.Trim().ToLower().Contains(timkiem1));
            }
            return View(hoaDonDatMons.ToList());
        }

        public ActionResult Hoadoncosoluongmax()
        {
            var hoaDonDatMons = db.HoaDonDatMons.Include(h => h.KhachHang).Include(h => h.MonAn);
            var max = db.HoaDonDatMons.Max(h => h.SoLuong);
            var hoadonmax = db.HoaDonDatMons.Where(h => h.SoLuong == max);
            return View(hoadonmax.ToList());
        }

        public ActionResult Monancotongdoanhthumax()
        {
            var hoaDonDatMons = db.HoaDonDatMons.Include(h => h.KhachHang).Include(h => h.MonAn);
            var monan = db.HoaDonDatMons.GroupBy(h => new { h.MonAn.MaMon, h.MonAn.TenMon, h.MonAn.DonGia, h.MonAn.LoaiMon })
                  .Select(g => new Tongdoanhthu
                  {
                      MaMon = g.Key.MaMon,
                      TenMon = g.Key.TenMon,
                      LoaiMon = g.Key.LoaiMon,
                      DonGia = g.Key.DonGia,
                      DoanhThu = g.Sum(h => h.SoLuong * h.MonAn.DonGia)
                  });
            var max = monan.Max(d => d.DoanhThu);
            var hoadonmax = monan.Where(d => d.DoanhThu == max);
            return View(hoadonmax.ToList());
        }
        // GET: HoaDonDatMon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            if (hoaDonDatMon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonDatMon);
        }

        // GET: HoaDonDatMon/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen");
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon");
            return View();
        }

        // POST: HoaDonDatMon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaMon,MaKH,NgayDat,SoLuong")] HoaDonDatMon hoaDonDatMon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonDatMons.Add(hoaDonDatMon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDonDatMon.MaKH);
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDonDatMon.MaMon);
            return View(hoaDonDatMon);
        }

        // GET: HoaDonDatMon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            if (hoaDonDatMon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDonDatMon.MaKH);
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDonDatMon.MaMon);
            return View(hoaDonDatMon);
        }

        // POST: HoaDonDatMon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaMon,MaKH,NgayDat,SoLuong")] HoaDonDatMon hoaDonDatMon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonDatMon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDonDatMon.MaKH);
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDonDatMon.MaMon);
            return View(hoaDonDatMon);
        }

        // GET: HoaDonDatMon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            if (hoaDonDatMon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonDatMon);
        }

        // POST: HoaDonDatMon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            db.HoaDonDatMons.Remove(hoaDonDatMon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
