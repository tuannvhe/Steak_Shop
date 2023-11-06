using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

		public ActionResult Chef()
        {
            Notifications();
            var chef = _context.Chefs.Include(c => c.WorkShifts).ToList();
            ViewData.Model = chef;
            return View(chef);
        }
        public ActionResult GetListChefs()
        {
            Notifications();
            var chef = _context.Chefs.Include(c => c.WorkShifts).ToList();
            ViewData.Model = chef;
            return View("~/Views/Chef/ManageChef.cshtml");
        }

        public ActionResult Create(){
            Notifications();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Email,Salary,Certificate")] Chef chef)
        {
            Notifications();
            try
            {
                _context.Add(chef);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetListChefs));
            }
            catch (Exception)
            {
                return View(chef);
            }
        }

        public async Task<IActionResult> Edit(int ?id)
        {
            Notifications();
            if (id == null || _context.Chefs == null)
            {
                return NotFound();
            }

            var chef = await _context.Chefs.FindAsync(id);
            if (chef == null)
            {
                return NotFound();
            }
            return View(chef);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone,Salary,Certificate")] Chef chef)
        {
            Notifications();
            if (id != chef.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(chef);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChefExists(chef.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(GetListChefs));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            Notifications();
            if (id == null || _context.Chefs == null)
            {
                return NotFound();
            }

            var chef = await _context.Chefs
                .FirstOrDefaultAsync(c => c.Id == id);
            if (chef == null)
            {
                return NotFound();
            }
            return View(chef);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            Notifications();
            if (_context.Chefs == null)
            {
                return Problem("Entity set 'SteakShop.Context.Chef'  is null.");
            }
            var chef = await _context.Chefs.FindAsync(id);
            if (chef != null)
            {
                _context.Chefs.Remove(chef);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GetListChefs));
        }
        private bool ChefExists(int id)
        {
            return _context.Chefs.Any(f => f.Id == id);
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
