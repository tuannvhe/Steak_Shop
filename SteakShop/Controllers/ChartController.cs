using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class ChartController : Controller
    {
        private readonly Steak_ShopContext _context;
        public IActionResult Chart()
        {
            return View();
        }
        public IActionResult GetRevenue(DateTime date)
        {
            var today = DateTime.Now;
            var revenues = _context.Orders
                                    .Where(r => r.Date >= date && r.Date <= today)
                                    .Select(r => r.TotalAmount)
                                    .ToList();
            var totalRevenue = revenues.Sum();
            return Ok(totalRevenue);
        }
    }
}
