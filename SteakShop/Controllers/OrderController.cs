using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SteakShop.Models;
using static NuGet.Packaging.PackagingConstants;

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

        public ActionResult Details(int id)
        {
            var getDetails = _context.OrdersFoods
                .Include(o => o.FidNavigation)
                .Where(o => o.Oid == id)
                .ToList();
            var listOrders = _context.Orders.Where(o => o.Id == id).ToList();
            ViewData.Model = getDetails;
            ViewData["TotalAmount"] = GetTotal(listOrders);
            return View();
        }
        public IActionResult ManageOrders()
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDate = DateTime.Now;
            var orders = _context.Orders
                .Include(o => o.UidNavigation)
                .Where(o => o.Date >= startDate && o.Date <= endDate)
                .ToList();
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
                var emptyList = new List<Order>();
                ViewData.Model = emptyList;
                decimal totalAmount = 0;
                ViewData["TotalAmount"] = totalAmount;
            }
            else if (startDate == null || endDate == null )
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endDate = DateTime.Now;
                var orders = _context.Orders
                    .Include(o => o.UidNavigation)
                    .Where(o => o.Date >= startDate && o.Date <= endDate)
                    .ToList();
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
