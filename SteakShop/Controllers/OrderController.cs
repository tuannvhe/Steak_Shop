using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class OrderController : Controller
    {
        private Steak_ShopContext _context;
        private readonly IWebHostEnvironment _environment;

        public OrderController(Steak_ShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult ManageOrders()
        {
            var orders = _context.Orders.Include(o => o.UidNavigation).ToList();
            ViewData.Model = orders;
            ViewData["TotalAmount"] = GetTotal(orders);
            return View();
        }
        public decimal GetTotal(List<Order> orders)
        {
            decimal totalAmount = orders.Sum(item => item.TotalAmount);

            return totalAmount;
        }
        [HttpGet]
        public IActionResult GetOrdersByDate(DateTime? startDate, DateTime? endDate)
        {
            if (startDate > endDate)
            {
                return NotFound();
            }
            else if (startDate == null || endDate == null )
            {                
                var orders = _context.Orders.Include(o => o.UidNavigation).ToList();
                ViewData.Model = orders;
                ViewData["TotalAmount"] = GetTotal(orders);
            }
            else
            {
                var orders1 = _context.Orders
               .Include(o => o.UidNavigation)
               .Where(o => o.Date >= startDate.Value && o.Date <= endDate.Value)
               .ToList();
                ViewData.Model = orders1;
                ViewData["TotalAmount"] = GetTotal(orders1);
            }    
            
            return View("~/Views/Order/ManageOrders.cshtml");
        }
    }
}
