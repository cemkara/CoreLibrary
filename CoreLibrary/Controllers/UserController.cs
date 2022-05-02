using CoreLibrary.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreLibrary.Controllers
{
    public class UserController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            Admin loginAdmin = c.Admins.Where(x => x.Username == admin.Username && x.Password == admin.Password).FirstOrDefault();

            if (loginAdmin != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.Username)
                };

                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "User");
        }
    }
}
