using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TruyVanLinq_QLSach_LTUDDN.Models;

namespace TruyVanLinq_QLSach_LTUDDN.Controllers
{
    public class BookController : Controller
    {
        private BookDataContext db = new BookDataContext();

        // GET: Book
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            
            //books = books.OrderBy(b => b.Title);
            books = books.OrderByDescending(b => b.Title);
            
            var sumtttgAnh = db.Books.Where(b => b.Author.AuthorName.Contains("Anh")).Sum(b => b.Price);
            ViewBag.sumtttgAnh = sumtttgAnh;

            //var kt = books.Any(b => b.Price > 200000);
            //string thongbao = "";
            //if(kt == true)
            //{
            //    thongbao = "Có cuốn sách giá lớn hơn 200000";
            //}
            //else
            //{
            //    thongbao = "Không có cuốn sách giá lớn hơn 200000";
            //}
            //ViewBag.thongbao = thongbao;

            var kt = books.All(b => b.Price > 20000);
            string thongbao = "";
            if (kt == true)
            {
                thongbao = "Tất cả cuốn sách giá lớn hơn 20000";
            }
            else
            {
                thongbao = "Tồn tại cuốn sách giá <= 20000";
            }
            ViewBag.thongbao = thongbao;

            var count = db.Books.Count(b => b.Author.AuthorName.Contains("Anh"));
            ViewBag.count = count;

            return View(books.ToList());
        }

        public ActionResult SachGiaLon20()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            books = books.Where(b => b.Price > 20000 && b.Author.AuthorName.Contains("Anh"));
            return View(books.ToList());
        }

        public ActionResult SelectTitlePrice()
        {
            var books = db.Books.Select(b => new BookViewModel { Title = b.Title, Price = b.Price });
            return View(books);
        }

        public ActionResult DSMaxGia()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            var Maxgia = db.Books.Max(b => b.Price);
            books = books.Where(b => b.Price == Maxgia);
            return View(books.ToList());
        }

        public ActionResult HaiSachDatNhat()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            books = books.OrderByDescending(b => b.Price).Skip(1).Take(2);
            return View(books.ToList());
        }

        public ActionResult CheapBooks()
        {
            var books = db.Books.OrderBy(b => b.Price).ToList();
            var CheapBooks = books.TakeWhile(b => b.Price < 20000);
            return View(CheapBooks.ToList());
        }

        public ActionResult ExpensiveBooks()
        {
            var books = db.Books.OrderBy(b=>b.Price).ToList();
            var ExpensiveBooks = books.SkipWhile(b => b.Price < 20000);
            return View(ExpensiveBooks.ToList());
        }

        public ActionResult GroupBookByCategory()
        {
            var gbooks = db.Books
                .GroupBy(b=>b.Category.CategoryName)
                .Select(g => new BookByCategoryViewModel { CategoryName = g.Key, BookCount = g.Count(), PriceSum = g.Sum(b=>b.Price) });
            return View(gbooks.ToList());
        }

        public ActionResult TK(string search)
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim().ToLower();
                books = books.Where(b => b.Title.Trim().ToLower().Contains(search) || b.Description.Contains(search));
            }
            return View(books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Title,AuthorID,Price,Images,CategoryID,Description,Published,ViewCount")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Title,AuthorID,Price,Images,CategoryID,Description,Published,ViewCount")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
