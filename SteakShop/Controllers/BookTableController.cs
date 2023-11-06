using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SteakShop.Models;
using System.Text;

namespace SteakShop.Controllers
{
    public class BookTableController : Controller
    {
        private readonly Steak_ShopContext _context;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IWebHostEnvironment _environment;
        List<string> notifications = new List<string>();
        public int SelectedEventId { get; set; }
        public int? UserID { get; private set; }

        public BookTableController(Steak_ShopContext context, IWebHostEnvironment environment, IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
            _context = context;
			_environment = environment;
        }
        public ActionResult BookTableAsync()
        {
			var events = _context.Events.ToList();
			ViewData.Model = events;
			string Username = HttpContext.Session.GetString("Username");
            var getUser = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
            
            if (getUser == null)
            {
                return View();
            }
            else
            {
                ViewData["User"] = getUser;             
                return View();
            }
        }
        [HttpPost]
		public async Task<IActionResult> SubmitInfoAsync(int selectedPeople, DateTime bookingDate, int selectedEvent)
        {
            var events = _context.Events.Where(e => e.Id == selectedEvent).FirstOrDefault();
			string Username = HttpContext.Session.GetString("Username");
			var getUser = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
            if(getUser == null)
            {
				var booking = new BookTable
				{
					NumberOfPeople = selectedPeople,
					Date = bookingDate,
					EventId = selectedEvent,
					Uid = 1
				};

                var getEvent = _context.Events.Find(selectedEvent);
                var notificationData = new
                {
                    ID = booking.Id,
                    AlertDate = DateTime.Now.ToString(),
                    NumberOfPeople = selectedPeople,
                    BookingDate = bookingDate.ToString("dd-MM-yyyy"),
                    EventID = getEvent.EventName,
                    UserID = "Guest"
                };

                var notificationMessage = JsonConvert.SerializeObject(notificationData);
                var hubContext = HttpContext.RequestServices.GetRequiredService<IHubContext<NotificationHub>>();
                await hubContext.Clients.All.SendAsync("ReceiveNotification", notificationMessage);
                _context.BookTables.Add(booking);
				_context.SaveChanges();
			}
            else
            {
				var booking = new BookTable
				{
					NumberOfPeople = selectedPeople,
					Date = bookingDate,
					EventId = selectedEvent,
					Uid = getUser.Id
				};
                var getEvent = _context.Events.Find(selectedEvent);
                var notificationData = new
                {
                    ID = booking.Id,
                    AlertDate = DateTime.Now.ToString(),
                    NumberOfPeople = selectedPeople,
                    BookingDate = bookingDate.ToString("dd-MM-yyyy"),
                    EventID = getEvent.EventName,
                    UserID = getUser.Username
                };

                var notificationMessage = JsonConvert.SerializeObject(notificationData);
                var hubContext = HttpContext.RequestServices.GetRequiredService<IHubContext<NotificationHub>>();
                await hubContext.Clients.All.SendAsync("ReceiveNotification", notificationMessage);
                _context.BookTables.Add(booking);
				_context.SaveChanges();
			}		            
			return RedirectToAction("Index", "Home");
        }
        public ActionResult ManageBookTable() {
            DateTime today = DateTime.Now.Date;
            var bookedTablesToday = _context.BookTables
                .Include(o => o.UidNavigation)
                .Include(o => o.Event)
                .Where(o => o.Date >= today && o.Date <= today.AddDays(1).AddTicks(-1)) // Lọc chỉ những bản ghi trong ngày hôm nay
                .ToList();

            ViewData.Model = bookedTablesToday;
            return View();
        }

        [HttpGet]
        public IActionResult GetBookedTablesByDate(DateTime? startDate, DateTime? endDate)
        {
            if (startDate > endDate)
            {
                var emptyList = new List<BookTable>();
                ViewData.Model = emptyList;
            }
            else if (startDate == null || endDate == null)
            {
                DateTime today = DateTime.Now.Date;
                var bookedTablesToday = _context.BookTables
                    .Include(o => o.UidNavigation)
                    .Include(o => o.Event)
                    .Where(o => o.Date >= today && o.Date <= today.AddDays(1).AddTicks(-1))
                    .ToList();

                ViewData.Model = bookedTablesToday;
            }
            else
            {
                var orders1 = _context.BookTables
               .Include(o => o.UidNavigation)
               .Include(o => o.Event)
               .Where(o => o.Date >= startDate.Value && o.Date <= endDate.Value)
               .ToList();
                ViewData.Model = orders1;
            }
            return View("~/Views/BookTable/ManageBookTable.cshtml");
        }
        public ActionResult Information(string username)
        {
            var getUser = _context.Users.Where(u => u.Username == username).FirstOrDefault();
            if (getUser == null) return NotFound();
            return View(getUser);
        }
    }
}
