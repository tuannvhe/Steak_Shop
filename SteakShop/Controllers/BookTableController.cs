using Microsoft.AspNetCore.Mvc;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class BookTableController : Controller
    {
        private readonly Steak_ShopContext _context;

        public BookTableController(Steak_ShopContext context)
        {
            _context = context;
        }

        public IActionResult BookTable()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetInfo(BookTable model)
        {
            return View("~Views/Food/Food.cshtml");
        }
    }
}
