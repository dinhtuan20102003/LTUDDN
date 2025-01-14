using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using De32_DDT.Models;

namespace De32_DDT.Controllers
{
    public class HoaDonBanController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: HoaDonBan
        public ActionResult Index()
        {
            var hoaDonBans = db.HoaDonBans.Include(h => h.KhachHang).Include(h => h.Sach);
            return View(hoaDonBans.ToList());
        }

        public ActionResult TimKiem(string timkiem)
        {
            var hoaDonBans = db.HoaDonBans.Include(h => h.KhachHang).Include(h => h.Sach);
            if (!string.IsNullOrWhiteSpace(timkiem))
            {
                timkiem = timkiem.Trim().ToLower();
                hoaDonBans = hoaDonBans.Where(d => d.KhachHang.HoTen.Trim().ToLower().Contains(timkiem));
            }
            return View(hoaDonBans.ToList());
        }

        public ActionResult Sachcotongdoanhthumax()
        {
            var hoaDonBans = db.HoaDonBans.Include(h => h.KhachHang).Include(h => h.Sach);
            var hoadon = db.HoaDonBans
                .GroupBy(b => new { b.Sach.MaSach, b.Sach.TenSach, b.Sach.TheLoai, b.Sach.DonGia, b.Sach.SoLuongTon })
                .Select(g => new Tongdoanhthu
                {
                    MaSach = g.Key.MaSach,
                    TenSach = g.Key.TenSach,
                    TheLoai = g.Key.TheLoai,
                    DonGia = g.Key.DonGia,
                    SoLuongTon = g.Key.SoLuongTon,
                    DoanhThu = g.Sum(h => h.SoLuong * h.Sach.DonGia)
                });
            var max = hoadon.Max(b => b.DoanhThu);
            var dsmax = hoadon.Where(b => b.DoanhThu == max).ToList();
            return View(dsmax.ToList());
        }

        public ActionResult Hoadoncosoluongmax()
        {
            var hoaDonBans = db.HoaDonBans.Include(h => h.KhachHang).Include(h => h.Sach);
            var max = db.HoaDonBans.Max(h => h.SoLuong);
            var hoadon = db.HoaDonBans.Where(h => h.SoLuong == max).ToList();
            return View(hoadon.ToList());
        }



        // GET: HoaDonBan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonBan hoaDonBan = db.HoaDonBans.Find(id);
            if (hoaDonBan == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonBan);
        }

        // GET: HoaDonBan/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen");
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach");
            return View();
        }

        // POST: HoaDonBan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaSach,MaKH,NgayBan,SoLuong")] HoaDonBan hoaDonBan)
        {
            var check = db.HoaDonBans.FirstOrDefault(h => h.MaHD == hoaDonBan.MaHD);
            if(check != null)
            {
                ModelState.AddModelError("MaHD", "Mã hóa đơn đã tông tại");
            }
            if (ModelState.IsValid)
            {
                db.HoaDonBans.Add(hoaDonBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDonBan.MaKH);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", hoaDonBan.MaSach);
            return View(hoaDonBan);
        }

        // GET: HoaDonBan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonBan hoaDonBan = db.HoaDonBans.Find(id);
            if (hoaDonBan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDonBan.MaKH);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", hoaDonBan.MaSach);
            return View(hoaDonBan);
        }

        // POST: HoaDonBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaSach,MaKH,NgayBan,SoLuong")] HoaDonBan hoaDonBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDonBan.MaKH);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", hoaDonBan.MaSach);
            return View(hoaDonBan);
        }

        // GET: HoaDonBan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonBan hoaDonBan = db.HoaDonBans.Find(id);
            if (hoaDonBan == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonBan);
        }

        // POST: HoaDonBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDonBan hoaDonBan = db.HoaDonBans.Find(id);
            db.HoaDonBans.Remove(hoaDonBan);
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
