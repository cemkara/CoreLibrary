using CoreLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace CoreLibrary.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        Context c = new Context();
       
        public IActionResult Index(int page=1)
        {
            var list = c.Books.Include(x => x.Publisher).Include(x => x.Writer).ToPagedList(page, 10);
            return View(list);
        }

        [HttpGet]
        public IActionResult BookAdd()
        {
            List<SelectListItem> writerSelectList = (from x in c.Writers.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.WriterId.ToString()
                                                     }).ToList();

            List<SelectListItem> publisherSelectList = (from x in c.Publishers.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.PublisherId.ToString()
                                                        }).ToList();
            ViewBag.writerSList = writerSelectList;
            ViewBag.publisherSList = publisherSelectList;

            return View();
        }
        [HttpPost]
        public IActionResult BookAdd(Book book)
        {
            Publisher selectPublisher = c.Publishers.Find(book.Publisher.PublisherId);
            Writer selectWriter = c.Writers.Find(book.Writer.WriterId);

            book.Publisher = selectPublisher;
            book.Writer = selectWriter;
            book.Status = true;
            c.Books.Add(book);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult BookRemove(int id)
        {
            Book book = c.Books.Find(id);
            book.Status = !book.Status;
            c.Update(book);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult BookUpdate(int Id)
        {
            Book book = c.Books.Where(x => x.Id == Id).Include(x => x.Publisher).Include(x => x.Writer).FirstOrDefault();

            List<SelectListItem> writerSelectList = (from x in c.Writers.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.WriterId.ToString()
                                                     }).ToList();

            List<SelectListItem> publisherSelectList = (from x in c.Publishers.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.PublisherId.ToString()
                                                        }).ToList();
            ViewBag.writerSList = writerSelectList;
            ViewBag.publisherSList = publisherSelectList;

            return View(book);
        }

        [HttpPost]
        public IActionResult BookUpdate(Book book)
        {
            Publisher selectPublisher = c.Publishers.Find(book.Publisher.PublisherId);
            Writer selectWriter = c.Writers.Find(book.Writer.WriterId);

            book.Publisher = selectPublisher;
            book.Writer = selectWriter;

            c.Books.Update(book);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BookDetail(int Id)
        {
            Book book = c.Books.Where(x => x.Id == Id).Include(x => x.Publisher).Include(x => x.Writer).FirstOrDefault();
            return View(book);
        }
    }
}
