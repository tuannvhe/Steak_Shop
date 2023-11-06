using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class CategoryController : Controller
    {
        private Steak_ShopContext _context;
        private readonly IWebHostEnvironment _environment;

        public CategoryController(Steak_ShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        // GET: CategoryController
        public ActionResult GetListCategories()
        {
            var getListCate = _context.Categories.ToList();
            ViewData.Model = getListCate;
            return View("~/Views/Category/ManageCategory.cshtml");
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName,Descriptions")] Category category)
        {
            try
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetListCategories));
            }
            catch (Exception)
            {
                return View(category);
            }
        }

        // GET: CategoryController/Edit/5
        public async Task <IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id, [Bind("Id,CategoryName,Descriptions")] Category category)
        {          
            if (id != category.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CateExists(category.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(GetListCategories));
        }

        // GET: CategoryController/Delete/5
        public async Task <IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(int id, IFormCollection collection)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'SteakShop.Context.Category'  is null.");
            }
            var cate = await _context.Categories.FindAsync(id);
            if (cate != null)
            {
                _context.Categories.Remove(cate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GetListCategories));
        }
        private bool CateExists(int id)
        {
            return _context.Categories.Any(f => f.Id == id);
        }
    }
}
