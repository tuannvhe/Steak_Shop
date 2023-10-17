using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;

namespace SteakShop.Controllers
{
	public class FoodController : Controller
	{
		private Steak_ShopContext _context;
		private readonly IWebHostEnvironment _environment;

		public FoodController(Steak_ShopContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}

		public async Task<IActionResult> Food(int categoryId)
		{
			List<SelectListItem> categories = new SelectList(_context.Categories, "Id", "CategoryName", categoryId).ToList();
			categories.Insert(0, new SelectListItem { Value = "0", Text = "All" });
			ViewData["CateIds"] = categories;

			var foods = _context.Foods.Where(f => f.CId == (categoryId == 0 ? f.CId : categoryId));

			return View(await foods.ToListAsync());
		}
	}
}
