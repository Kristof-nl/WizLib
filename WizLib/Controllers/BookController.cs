using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizLib_Model.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WizLib.Controllers
{
    public class BookController : Controller
    {

        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> objList = _db.Books.Include(u => u.Publisher).ToList();

            //foreach(var obj in objList)
            //{
            //    //obj.Publisher = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == obj.Publisher_Id);

            //    //Explicit loading - more efficient
            //    _db.Entry(obj).Reference(u => u.Publisher).Load();
            //}
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM obj = new BookVM();
            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()

            });

            if (id == null)
            {
                return View(obj);
            }
            //Edit
            obj.Book = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        public IActionResult Details(int? id)
        {
            BookVM obj = new BookVM();
            if (id == null)
            {
                return View(obj);
            }
            //Edit
            obj.Book = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            obj.Book.BookDetail = _db.BookDetails.FirstOrDefault(u => u.BookDetail_Id == obj.Book.BookDetail_Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookVM obj)
        {


            if (obj.Book.BookDetail.BookDetail_Id == 0)
            {
                //This is create
                _db.BookDetails.Add(obj.Book.BookDetail);
                _db.SaveChanges();
            }
            else
            {
                //This is update
                _db.Books.Update(obj.Book);
                _db.SaveChanges();
            }
            var BookFromDb = _db.Books.FirstOrDefault(u => u.Book_Id == obj.Book.Book_Id);
            BookFromDb.BookDetail_Id = obj.Book.BookDetail.BookDetail_Id;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM obj)
        {
           
           
                if (obj.Book.Book_Id == 0)
                {
                    //This is create
                    _db.Books.Add(obj.Book);
                }
                else
                {
                    //This is update
                    _db.Books.Update(obj.Book);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
         
     
        }

        public IActionResult Delete(int Id)
        {
            var objFromDb = _db.Books.FirstOrDefault(u => u.Book_Id == Id);
            _db.Books.Remove(objFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
