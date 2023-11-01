using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;
using System.Diagnostics;

namespace SteakShop.Controllers
{
    public class HomeController : Controller
    {
        
        private Steak_ShopContext _context;
		private readonly IWebHostEnvironment _environment;
		
		public HomeController(Steak_ShopContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Food()
        {
            var context = _context.Foods.Include(f => f.CIdNavigation).ToList();
            ViewData.Model = context;
            return View("~/Views/Home/Food.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}