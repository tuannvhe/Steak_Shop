using Microsoft.AspNetCore.Mvc;

namespace SteakShop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Admin/Index.cshtml");
        }
    }
}
