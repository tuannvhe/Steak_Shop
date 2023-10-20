using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class BookTableController : Controller
    {
        private readonly Steak_ShopContext _context;
		private readonly IWebHostEnvironment _environment;

		public BookTableController(Steak_ShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
			_environment = environment;
        }
        public IActionResult BookTable()
        {
			var events = _context.Events.ToList();
			ViewData.Model = events;
			return View();
        }

        [HttpPost]
		public IActionResult SubmitInfo(int eventId)
        {
            
			//return RedirectToAction("Food", "Food");
			return View("~Views/Food/Food.cshtml");
        }
    }
}
