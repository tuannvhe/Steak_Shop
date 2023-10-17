using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class ChefController : Controller
    {
        private readonly Steak_ShopContext _context;
        private readonly IWebHostEnvironment _environment;

        public ChefController(Steak_ShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
		public ActionResult Index()
		{
			return View();
		}


		public async Task<IActionResult> Chef()
        {
            var chef = _context.Chefs.Include(c => c.WorkShifts).ToList();
            ViewData.Model = chef;
            return View(chef);
        }

        [HttpPost]
        public async Task<IActionResult> GetWorkShiftById(int id)
        {
            List<WorkShift> workShift = _context.WorkShifts.Where(w => w.Id == id).ToList();
            return View(workShift);
        }
    }
}
