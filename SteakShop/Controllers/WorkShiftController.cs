using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class WorkShiftController : Controller
    {
        private Steak_ShopContext _context;
        private readonly IWebHostEnvironment _environment;

        public WorkShiftController(Steak_ShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        // GET: WorkShiftController
        public ActionResult ManageWorkshift()
        {
            Notifications();
            var getWorkShift = _context.WorkShifts.Include(w => w.Chef).ToList();
            ViewData.Model = getWorkShift;
            return View();
        }

        // GET: WorkShiftController/Details/5
        public ActionResult Details(int id)
        {
            Notifications();
            return View();
        }

        // GET: WorkShiftController/Create
        public IActionResult Create()
        {
            Notifications();
            var getHoliday = new SelectList(_context.WorkShifts, "Holidays", "Holidays").Distinct();
            var getChef = new SelectList(_context.WorkShifts, "ChefId", "ChefId");
            ViewData["Holiday"] = getHoliday;
            ViewData["Chef"] = getChef;
            return View();
        }

        // POST: WorkShiftController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create([Bind("Id,WorkHours,Shifts,Holidays,ChefId")] WorkShift workShift)
        {
            Notifications();
            try
            {
                _context.Add(workShift);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageWorkshift));
            }
            catch
            {
                return View(workShift);
            }
        }

        // GET: WorkShiftController/Edit/5
        public async Task <IActionResult> Edit(int? id)
        {
            Notifications();
            if (id == null || _context.WorkShifts == null)
            {
                return NotFound();
            }

            var getHoliday = new SelectList(_context.WorkShifts, "Holidays", "Holidays").Distinct();
            var getChef = new SelectList(_context.WorkShifts, "ChefId", "ChefId");
            ViewData["Holiday"] = getHoliday;
            ViewData["Chef"] = getChef;

            var workShift = await _context.WorkShifts
                .Include(w => w.Chef)
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
            if (workShift == null)
            {
                return NotFound();
            }
            return View(workShift);
        }

        // POST: WorkShiftController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkHours,Shifts,Holidays,ChefId")] WorkShift workShift)
        {
            Notifications();
            if (id != workShift.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(workShift);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkShiftsExists(workShift.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(ManageWorkshift));
        }
            // GET: WorkShiftController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Notifications();
            if (id == null || _context.WorkShifts == null)
            {
                return NotFound();
            }

            var workShift = await _context.WorkShifts
                .FirstOrDefaultAsync(c => c.Id == id);
            if (workShift == null)
            {
                return NotFound();
            }
            return View(workShift);
        }

        // POST: WorkShiftController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(int id, IFormCollection collection)
        {
            Notifications();
            if (_context.WorkShifts == null)
            {
                return Problem("Entity set 'SteakShop.Context.WorkShifts'  is null.");
            }
            var workShift = await _context.WorkShifts
                .Include(w => w.Chef)
                .Where(w => w.Id == id).FirstOrDefaultAsync();
            if (workShift != null)
            {
                _context.WorkShifts.Remove(workShift);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageWorkshift));
        }
            private bool WorkShiftsExists(int id)
            {
                return _context.WorkShifts.Any(f => f.Id == id);
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
