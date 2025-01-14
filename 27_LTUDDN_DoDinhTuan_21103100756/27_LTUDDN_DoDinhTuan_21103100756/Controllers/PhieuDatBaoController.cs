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
    public class PhieuDatBaoController : Controller
    {
        private QLKHDataContext db = new QLKHDataContext();

        // GET: PhieuDatBao
        public ActionResult Index()
        {
            var phieuDatBaos = db.PhieuDatBaos.Include(p => p.KhachHang);
            return View(phieuDatBaos.ToList());
        }
        public ActionResult Timkiem(string search)
        {
            var phieuDatBaos = db.PhieuDatBaos.Include(p => p.KhachHang);
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim().ToLower();
                phieuDatBaos = phieuDatBaos.Where(kh => kh.KhachHang.diachi.Trim().ToLower().Contains(search));
            }
            return View(phieuDatBaos.ToList());
        }
        public ActionResult Thanhtienthapnhat()
        {
         
            var phieuDatBaos = db.PhieuDatBaos.Include(p => p.KhachHang).ToList();

            var minThanhTien = phieuDatBaos.Min(p => p.thanhtien);
            var result = phieuDatBaos.Where(p => p.thanhtien == minThanhTien);
            return View(result.ToList());
        }

        public ActionResult Thanhtienthapnha1t()
        {
            var phieuDatBaos = db.PhieuDatBaos.Include(p => p.KhachHang);
            //var thanhtien = db.PhieuDatBaos.Min(kh => kh.thanhtien);
            //phieuDatBaos = phieuDatBaos.OrderBy(kh =>kh.thanhtien).Take(1);
            return View(phieuDatBaos.ToList());


        }

        // GET: PhieuDatBao/Details/5
        public ActionResult Details(string id, int? id1)
        {
            if (id == null|| id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatBao phieuDatBao = db.PhieuDatBaos.Find(id, id1);
            if (phieuDatBao == null)
            {
                return HttpNotFound();
            }
            return View(phieuDatBao);
        }

        // GET: PhieuDatBao/Create
        public ActionResult Create()
        {
            ViewBag.makh = new SelectList(db.KhachHangs, "makh", "tenkh");
            return View();
        }

        // POST: PhieuDatBao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tenbao,makh,ngaydat,soluong,dongia")] PhieuDatBao phieuDatBao)
        {
            if (ModelState.IsValid)
            {
                db.PhieuDatBaos.Add(phieuDatBao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.makh = new SelectList(db.KhachHangs, "makh", "tenkh", phieuDatBao.makh);
            return View(phieuDatBao);
        }

        // GET: PhieuDatBao/Edit/5
        public ActionResult Edit(string id, int? id1)
        {
            if (id == null|| id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatBao phieuDatBao = db.PhieuDatBaos.Find(id, id1);
            if (phieuDatBao == null)
            {
                return HttpNotFound();
            }
            ViewBag.makh = new SelectList(db.KhachHangs, "makh", "tenkh", phieuDatBao.makh);
            return View(phieuDatBao);
        }

        // POST: PhieuDatBao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tenbao,makh,ngaydat,soluong,dongia")] PhieuDatBao phieuDatBao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuDatBao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.makh = new SelectList(db.KhachHangs, "makh", "tenkh", phieuDatBao.makh);
            return View(phieuDatBao);
        }

        // GET: PhieuDatBao/Delete/5
        public ActionResult Delete(string id, int? id1)
        {
            if (id == null|| id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatBao phieuDatBao = db.PhieuDatBaos.Find(id, id1);
            if (phieuDatBao == null)
            {
                return HttpNotFound();
            }
            return View(phieuDatBao);
        }

        // POST: PhieuDatBao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, int? id1)
        {
            PhieuDatBao phieuDatBao = db.PhieuDatBaos.Find(id, id1);
            db.PhieuDatBaos.Remove(phieuDatBao);
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
