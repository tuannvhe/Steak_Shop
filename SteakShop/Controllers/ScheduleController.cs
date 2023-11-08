using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly Steak_ShopContext _context;

        public ScheduleController(Steak_ShopContext context)
        {
            _context = context;
        }

        public IActionResult Schedule()
        {
            Notifications();
            var getInfo = _context.ScheduleMarketings.Include(m => m.IdMbNavigation).ToList();
            ViewData.Model = getInfo;

            return View();
        }
        public ActionResult Create()
        {
            Notifications();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,CashReceive,IdMb")] ScheduleMarketing sm)
        {
            Notifications();

            try
            {
                _context.Add(sm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Schedule));
            }
            catch (Exception)
            {
                return View(sm);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Notifications();

            if (id == null || _context.ScheduleMarketings == null)
            {
                return NotFound();
            }

            var sm = await _context.ScheduleMarketings.FindAsync(id);
            if (sm == null)
            {
                return NotFound();
            }
            return View(sm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,CashReceive,IdMb")] ScheduleMarketing sm)
        {
            Notifications();

            if (id != sm.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(sm);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MSExists(sm.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Schedule));
        }
        private bool MSExists(int id)
        {
            return _context.ScheduleMarketings.Any(f => f.Id == id);
        }
        public void Notifications()
        {
            var notifications = _context.Notifications
                .OrderByDescending(o => o.Id)
                .ToList();
            ViewData["Noti"] = notifications;
            ViewData["Count"] = notifications.Count;
        }
    }
}
