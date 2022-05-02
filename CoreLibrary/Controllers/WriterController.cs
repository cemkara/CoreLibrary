using CoreLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace CoreLibrary.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            var list = c.Writers.ToPagedList(page, 10);
            return View(list);
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(Writer writer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            c.Writers.Add(writer);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult WriterRemove(int id)
        {
            Writer writer = c.Writers.Find(id);
            c.Remove(writer);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult WriterUpdate(int Id)
        {
            Writer writer = c.Writers.Find(Id);
            return View(writer);
        }

        [HttpPost]
        public IActionResult WriterUpdate(Writer writer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            c.Writers.Update(writer);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult WriterBooks(int id)
        {
            List<Book> books = c.Books.Where(x => x.WriterId == id).Include(x => x.Publisher).ToList();
            return View(books);
        }
    }
}
