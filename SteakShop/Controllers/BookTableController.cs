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
            UserID = HttpContext.Session.GetInt32("UserID");
            var events = _context.Events.ToList();
			//ViewData.Model = events;
			return View(events);
        }

        [HttpPost]
		public IActionResult SubmitInfo(string name, string email, string phone, int selectedPeople, DateTime bookingDate, int selectedEvent)
        {
            var events = _context.Events.Where(e => e.Id == selectedEvent).FirstOrDefault();
                var booking = new BookTable
                {
                    NumberOfPeople = selectedPeople,
                    Date = bookingDate,
                    EventId = selectedEvent,
                    Uid = UserID
                };
            _context.BookTables.Add(booking);
            _context.SaveChanges();
			return RedirectToAction("BookTable", "BookTable");
        }

    }
}
