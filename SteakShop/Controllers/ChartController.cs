using Microsoft.AspNetCore.Mvc;

namespace SteakShop.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Chart()
        {
            return View();
        }
    }
}
