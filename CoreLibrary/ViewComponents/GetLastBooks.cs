using CoreLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreLibrary.ViewComponents
{
    public class GetLastBooks:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var list = c.Books.Take(20).ToList();
            return View(list);
        }
    }
}
