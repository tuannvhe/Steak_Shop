using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;
using SteakShop.Models.DTO;

namespace SteakShop.Controllers
{
    public class CustomerController : Controller
    {
        private Steak_ShopContext _context;
        private readonly IWebHostEnvironment _environment;

        public CustomerController(Steak_ShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult ManageCustomer()
        {
            Notifications();
            var customerData = _context.Orders
                  .Include(o => o.UidNavigation)
                  .GroupBy(o => o.Uid)
                  .Select(group => new CustomerDTO
                  {
                      Username = group.First().UidNavigation.Username,
                      TotalOrders = group.Count(),
                      TotalAmount = group.Sum(o => o.TotalAmount)
                  })
                  .ToList();

            var bigCustomers = customerData.Where(data => data.TotalOrders > 10 && data.TotalAmount > 100).ToList();
            var mediumCustomers = customerData
                .Where(data => data.TotalOrders > 1 
                && data.TotalAmount > 50 
                && data.TotalAmount < 100)
                .ToList();

            return View(new CustomerDTO
            {
                BigCustomers = bigCustomers,
                MediumCustomers = mediumCustomers
            });
        }
        public ActionResult Information(string username)
        {
            Notifications();
            var getUser = _context.Users.Where(u => u.Username == username).FirstOrDefault();
            if (getUser == null) return NotFound();
            return View(getUser);
        }
        public void Notifications()
        {
            var notifications = _context.Notifications
                .OrderByDescending(o => o.Id)
                .ToList();
            ViewData["Noti"] = notifications;
            ViewData["Count"] = notifications.Count;
        }
    }
}
