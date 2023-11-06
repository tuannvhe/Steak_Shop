using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SteakShop.Models;
using SteakShop.Models.DTO;

namespace SteakShop.Controllers
{
    public class AdminController : Controller
    {
        private Steak_ShopContext _context;
        private readonly IWebHostEnvironment _environment;

        public AdminController(Steak_ShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var notifications = _context.Notifications
                .OrderByDescending(o => o.Date)
                .ToList();
            ViewData["Noti"] = notifications;
            ViewData["Count"] = notifications.Count;
            return View();
        }  
    }
}
