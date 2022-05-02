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
    public class PublisherController : Controller
    {
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            var list = c.Publishers.ToPagedList(page, 10);
            return View(list);
        }

        [HttpGet]
        public IActionResult PublisherAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PublisherAdd(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            c.Publishers.Add(publisher);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PublisherRemove(int id)
        {
            Publisher publisher = c.Publishers.Find(id);
            c.Publishers.Remove(publisher);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult PublisherUpdate(int Id)
        {
            Publisher publisher = c.Publishers.Find(Id);
            return View(publisher);
        }

        [HttpPost]
        public IActionResult PublisherUpdate(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            c.Publishers.Update(publisher);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PublisherBooks(int id)
        {
            List<Book> books = c.Books.Where(x => x.PublisherId == id).Include(x => x.Writer).ToList();
            return View(books);
        }
    }
}
