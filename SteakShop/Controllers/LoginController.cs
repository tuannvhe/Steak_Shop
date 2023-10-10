using Microsoft.AspNetCore.Mvc;
using SteakShop.Models;
using System.Diagnostics;

namespace SteakShop.Controllers
{ 
	public class LoginController : Controller
	{
        private readonly Steak_ShopContext _context;
        private readonly IWebHostEnvironment _environment;

        public LoginController(Steak_ShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
		{
            User user1 = _context.Users.Where(u => u.Username == user.Username
                && u.Password == user.Password).FirstOrDefault();

            if (user1 == null)
                return View("~/Views/Login/Login.cshtml");
            else
            {
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetInt32("Role", user1.Role);
                return RedirectToAction("Food", "Home");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Username", "");
            HttpContext.Session.SetInt32("Role", 0);
            return RedirectToAction("Login", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
