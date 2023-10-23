using Microsoft.AspNetCore.Mvc;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly Steak_ShopContext _context;

        public CheckOutController(Steak_ShopContext context)
        {
            _context = context;
        }

        public IActionResult Checkout()
        {
            return View();
        }

    }
}
