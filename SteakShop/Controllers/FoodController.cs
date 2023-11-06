using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public ActionResult Food(int categoryId/*, int? page*/)
		{
            Notifications();
            List<SelectListItem> categories = new SelectList(_context.Categories, "Id", "CategoryName", categoryId).ToList();
			categories.Insert(0, new SelectListItem { Value = "0", Text = "All" });
			ViewData["CateIds"] = categories;
           /* if (page == null) page = 1;         
            int pageSize = 4; 
            int pageNumber = (page ?? 1);*/

            var foods = _context.Foods.Where(f => f.CId == (categoryId == 0 ? f.CId : categoryId))
                .ToList();
                /*.ToPagedList(pageNumber, pageSize);*/

            return View(foods.ToList());
		}
        public ActionResult GetListFood()
        {
            var getListFood = _context.Foods.ToList();
            ViewData.Model = getListFood;
            return View("~/Views/Food/ManageFood.cshtml");
        }

        // GET: FoodController/Details/5
        public ActionResult Details(int id)
        {
            Notifications();
            var getFood = _context.Foods.Find(id);
            return View(getFood);
        }

        // GET: FoodController/Create
        public ActionResult Create()
        {
            Notifications();
            ViewData["CateId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: FoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FoodName,Price,Description,Image,CId")] Food food, IFormFile file)
        {
            Notifications();
            /*string dir = Path.Combine(_environment.WebRootPath, "Images");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            string filePath = Path.Combine(dir, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            food.Image = "/Images/" + file.FileName;*/

            try
            {
                _context.Foods.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetListFood));
            }
            catch
            {
                ViewData["CateId"] = new SelectList(_context.Categories, "Id", "CategoryName");
                return View(food);
            }
        }

        // GET: FoodController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Notifications();
            if (id == null || _context.Foods == null)
            {
                return NotFound();
            }

            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            ViewData["CateId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            return View(food);
        }

        // POST: FoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FoodName,Price,Description,Image,CId")] Food food)
        {
            Notifications();
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
            var category = _context.Categories.Where(c => c.Id == food.CId).FirstOrDefault();
            ViewData["CateId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            return RedirectToAction(nameof(GetListFood));
        }

        // GET: FoodController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Notifications();
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

        // POST: FoodController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            Notifications();
            if (_context.Foods == null)
            {
                return Problem("Entity set 'SteakShop.Context.Food'  is null.");
            }
            var food = await _context.Foods.FindAsync(id);
            if (food != null)
            {
                _context.Foods.Remove(food);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GetListFood));
           
        }
        private bool FoodExists(int id)
        {
            return _context.Foods.Any(f => f.Id == id);
        }
        public void Notifications()
        {
            var notifications = _context.Notifications
                 .OrderByDescending(o => o.Date)
                 .ToList();
            ViewData["Noti"] = notifications;
            ViewData["Count"] = notifications.Count;
        }
    }
}
