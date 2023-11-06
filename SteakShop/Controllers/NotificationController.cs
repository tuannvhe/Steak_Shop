using Microsoft.AspNetCore.Mvc;
using SteakShop.Models;

namespace SteakShop.wwwroot
{
    public class NotificationController : Controller
    {
        private readonly Steak_ShopContext _context;

        public NotificationController(Steak_ShopContext context)
        {
            _context = context;
        }

        public IActionResult Notification()
        {
            var notifications = _context.Notifications.OrderByDescending(n => n.Id).ToList();
            ViewData["Noti"] = notifications;
            ViewData["Count"] = notifications.Count;
            return View(notifications);
        }       
    }
}
