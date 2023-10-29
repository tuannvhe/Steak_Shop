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
        public ActionResult GetListFood()
        {
            var getListFood = _context.Foods.ToList();
            ViewData.Model = getListFood;
            return View("~/Views/Food/ManageFood.cshtml");
        }

        // GET: ManageFoodController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageFoodController/Create
        public ActionResult Create()
        {
            ViewData["CateId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: ManageFoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FoodName,Price,Description,Image,CId")] Food food, IFormFile file)
        {
            string dir = Path.Combine(_environment.WebRootPath, "Images");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            string filePath = Path.Combine(dir, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            food.Image = "/Images/" + file.FileName;


            //if (ModelState.IsValid)
            try
            {
                _context.Foods.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["CateId"] = new SelectList(_context.Categories, "Id", "Id");
                return View(food);
            }
        }

        // GET: ManageFoodController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Foods == null)
            {
                return NotFound();
            }

            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            ViewData["CateId"] = new SelectList(_context.Foods, "CId", "CId", food.CId);
            return View(food);
        }

        // POST: ManageFoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FoodName,Price,Description,Image,CId")] Food food)
        {
            if (id != food.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(food);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(food.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //return RedirectToAction(nameof(GetListFood));
            ViewData["CateId"] = new SelectList(_context.Foods, "CId", "CId", food.CId);
            return View(food);
        }

        // GET: ManageFoodController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Foods == null)
            {
                return NotFound();
            }

            var food = await _context.Foods
                .FirstOrDefaultAsync(f => f.Id == id);
            if (food == null)
            {
                return NotFound();
            } 
            return View(food);
        }

        // POST: ManageFoodController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            if (_context.Foods == null)
            {
                return Problem("Entity set 'SteakShopContext.Food'  is null.");
            }
            var album = await _context.Foods.FindAsync(id);
            if (album != null)
            {
                _context.Foods.Remove(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GetListFood));
           
        }
        private bool FoodExists(int id)
        {
            return _context.Foods.Any(f => f.Id == id);
        }
    }
}
