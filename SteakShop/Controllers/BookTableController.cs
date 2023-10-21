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
			//ViewData.Model = events;
			return View(events);
        }

        [HttpPost]
		public IActionResult SubmitInfo(string name, string email, string phone, int numOfPeople, DateTime date, int selectedOption)
        {
            var events = _context.Events.Where(e => e.Id == selectedOption).FirstOrDefault();
            if (events == null)
            {

            }
            else
            {
                Order order = new Order
                {

                };
            }
			return RedirectToAction("BookTable", "BookTable");
        }
    }
}
