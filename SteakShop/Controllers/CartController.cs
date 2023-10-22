using Microsoft.AspNetCore.Mvc;

namespace SteakShop.Controllers
{
    public class CartController : Controller
    {
        [HttpPost]
        public IActionResult Cart()
        {
            return View();
        }
    }
}
