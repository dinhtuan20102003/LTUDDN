using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _27_LTUDDN_DoDinhTuan_21103100756.Models;

namespace _27_LTUDDN_DoDinhTuan_21103100756.Controllers
{
    public class SanPhamController : Controller
    {
        private QLBanHangDataContext db = new QLBanHangDataContext();

        // GET: SanPham
        public ActionResult Index(decimal? min, decimal? max, string loaiSp)
        {
           
            //var categories = db.SanPhams.Select(s => s.loaisp).Distinct().ToList();
            //ViewBag.Categories = new SelectList(categories);

            //var sanpham = db.SanPhams.AsQueryable();

            //if (min.HasValue)
            //{
            //    sanpham = sanpham.Where(s => s.gia >= min.Value);
            //}

            //if (max.HasValue)
            //{
            //    sanpham = sanpham.Where(s => s.gia <= max.Value);
            //}

            //if (!string.IsNullOrEmpty(loaiSp))
            //{
            //    sanpham = sanpham.Where(s => s.loaisp.Contains(loaiSp));
            //}

            //return View(sanpham.ToList());

            var loaisp = db.SanPhams.Select(l => l.loaisp).Distinct().ToList();
            ViewBag.Loaisp = new SelectList(loaisp);

            var sanpham = db.SanPhams.AsQueryable();
            if (min.HasValue)
            {
                sanpham = sanpham.Where(d =>d.gia >= min.Value);
            }

            if (max.HasValue)
            {
                sanpham = sanpham.Where(d=>d.gia<= max.Value);
            }

            if (!string.IsNullOrWhiteSpace(loaiSp))
            {
                sanpham = sanpham.Where(d =>d.loaisp.Trim().ToLower().Contains(loaiSp.ToLower()));  
            }

            return View(sanpham.ToList());
        }
        public ActionResult SanPhamBanChayNhat()
        {
            var sanPhamBanChay = db.HoaDons.GroupBy(h => h.masp)
                .Select(g => new
                {
                    Masp = g.Key,
                    SoLuongBan = g.Sum(h => h.soluongban)
                })
                .OrderByDescending(s => s.SoLuongBan)
                .FirstOrDefault();
            var sanpham = db.SanPhams.Find(sanPhamBanChay.Masp);
          

            ViewBag.SoLuongBan = sanPhamBanChay.SoLuongBan;
            return View(sanpham);
        }

        // GET: SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "masp,tensp,gia,soluong,loaisp")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sanPham);
        }

        // GET: SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "masp,tensp,gia,soluong,loaisp")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }

        // GET: SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
