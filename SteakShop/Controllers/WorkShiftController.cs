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
            var getWorkShift = _context.WorkShifts.Include(w => w.Chef).ToList();
            ViewData.Model = getWorkShift;
            return View();
        }

        // GET: WorkShiftController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkShiftController/Create
        public IActionResult Create()
        {
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkShiftController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkShiftController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkShiftController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
