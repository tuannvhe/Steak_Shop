using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SteakShop.Controllers
{ 
	public class UserController : Controller
	{
        private readonly Steak_ShopContext _context;
        private readonly IWebHostEnvironment _environment;

        public UserController(Steak_ShopContext context, IWebHostEnvironment environment)
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
                return View("~/Views/User/Login.cshtml");
            else
            {
                user1.NumberOfLogins += 1;
                _context.Update(user1);
                _context.SaveChanges();

                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetInt32("Role", user1.Role);
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Username", "");
            HttpContext.Session.SetInt32("Role", 0);
            return RedirectToAction("Login", "User");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Register([Bind("Id,Username,Password,Role,Name,Email,Phone,Address,NumberOfLogins")] User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            catch (Exception ex)
            {
                return BadRequest("Register failed. " + ex);
            }
           
        }
        
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MyAccount()
        {
            string Username = HttpContext.Session.GetString("Username") ?? "";
            var user = _context.Users.Where(u => u.Username == Username).FirstOrDefault();         
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Role,Name,Email,Phone,Address,NumberOfLogins")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
            try
            {
                string rePass = Request.Form["RePassword"];
                if (user.Password != null && rePass != null! && !user.Password.Equals(rePass))
                {
                    return View(user);
                }
                else
                {
                    var user1 = _context.Users.Find(id);
                    user.Password = user1.Password;
                    user.NumberOfLogins = user1.NumberOfLogins;

                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "Home");
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(f => f.Id == id);
        }
    }
}
