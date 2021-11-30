using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;

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
            List<Book> objList = _db.Books.ToList();
            return View(objList);
        }

        //public IActionResult Upsert(int? id)
        //{
        //    Author obj = new Author();
        //    if (id == null)
        //    {
        //        return View(obj);
        //    }
        //    //Edit
        //    obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(obj);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert(Author obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (obj.Author_Id == 0)
        //        {
        //            //This is create
        //            _db.Authors.Add(obj);
        //        }
        //        else
        //        {
        //            //This is update
        //            _db.Authors.Update(obj);
        //        }
        //        _db.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(obj);
        //}

        //public IActionResult Delete(int Id)
        //{
        //    var objFromDb = _db.Authors.FirstOrDefault(u => u.Author_Id == Id);
        //    _db.Authors.Remove(objFromDb);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
