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
        public int SelectedEventId { get; set; }
        public int? UserID { get; private set; }

        public BookTableController(Steak_ShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
			_environment = environment;
        }
        public IActionResult BookTable()
        {
			var events = _context.Events.ToList();
			string Username = HttpContext.Session.GetString("Username");
			var getUser = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
			if (getUser == null)
			{
				return NotFound();
			}
			else
			{
                ViewData["User"] = getUser;
                ViewData.Model = events;
				return View();
			}			
        }
        [HttpPost]
		public IActionResult SubmitInfo(int selectedPeople, DateTime bookingDate, int selectedEvent)
        {
            var events = _context.Events.Where(e => e.Id == selectedEvent).FirstOrDefault();
            int userId = (int)HttpContext.Session.GetInt32("UserID");
                var booking = new BookTable
                {
                    NumberOfPeople = selectedPeople,
                    Date = bookingDate,
                    EventId = selectedEvent,
                    Uid = userId
                };
            _context.BookTables.Add(booking);
            _context.SaveChanges();
			return RedirectToAction("Index", "Home");
        }

    }
}
