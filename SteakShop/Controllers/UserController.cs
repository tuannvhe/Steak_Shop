using Microsoft.AspNetCore.Mvc;
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
		
		public IActionResult Register(string username, string password, string name, string email, string phone,string address)
        {
            try
            {
                if (!IsEmail(email))
                {
                    return View();
                }else if (!IsPhone(phone))
                {
                    return View();
                }
                else
                {
					User user = new User
					{
						Username = username,
						Password = password,
						Name = name,
						Email = email,
						Phone = phone,
						Address = address,
						Role = 2
					};
					_context.Users.Add(user);
					_context.SaveChanges();
					return RedirectToAction("Login", "Login");
				}
			}
            catch (Exception ex)
            {
                return View(ex.Message);
            }
           
        }
        private bool IsEmail(string email)
        {
			// Biểu thức chính quy kiểm tra định dạng email
			string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

			// Sử dụng Regex.IsMatch để kiểm tra email
			return Regex.IsMatch(email, pattern);
		}

		private bool IsPhone(string phone)
		{
			// Chia chuỗi thành mảng các số nguyên, sử dụng dấu phân cách (ví dụ: khoảng trắng) để tách
			string[] numbers = phone.Split(' ');

			if (numbers.Length != 10)
			{
				return false; // Nếu không có đúng 10 số, chuỗi không hợp lệ
			}

			foreach (string number in numbers)
			{
				if (!int.TryParse(number, out _))
				{
					return false; // Nếu không thể chuyển đổi thành số nguyên, chuỗi không hợp lệ
				}
			}

			return true; // Nếu tất cả 10 số đều là số nguyên, chuỗi hợp lệ
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
