using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _27_DoDinhTuan_21103100756_DHTI15A1CL.Models;

namespace _27_DoDinhTuan_21103100756_DHTI15A1CL.Controllers
{
    public class SinhViensController : Controller
    {
        private QLDIEMSVEntities db = new QLDIEMSVEntities();

        // GET: SinhViens
        public ActionResult Index()
        {
            return View(db.SinhViens.ToList());
        }

        // GET: SinhViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "masv,hoten,namsinh,gioitinh,email")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {

                var existingSinhVien = db.SinhViens.FirstOrDefault(sv => sv.masv == sinhVien.masv);
                if (existingSinhVien != null)
                {

                    ModelState.AddModelError("masv", "Mã sinh viên đã tồn tại.");
                    return View(sinhVien);
                }


                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sinhVien);
        }


        // GET: SinhViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "masv,hoten,namsinh,gioitinh,email")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SinhVien sinhVien = db.SinhViens.Find(id);
            db.SinhViens.Remove(sinhVien);
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
        public ActionResult Index1(string searchName)
        {
          
            var sinhViens = db.SinhViens.Include(s => s.Diems).AsQueryable();

            if (!String.IsNullOrEmpty(searchName))
            {
              
                sinhViens = sinhViens.Where(sv => sv.hoten.Contains(searchName));
            }

            return View("Index",sinhViens.ToList());
        }
        public ActionResult Diem()
        {
            var diemmin = db.Diems.Where(d => d.tenmh.Equals("Kỹ thuật lập trình")).Min(d => d.diem1);
            var dsmin = db.Diems.Where(d => d.tenmh.Equals("Kỹ thuật lập trình") && d.diem1 == diemmin).Select(d => d.SinhVien).ToList();
           

            return View(dsmin);

        }

    }
}
