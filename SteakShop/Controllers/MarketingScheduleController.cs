using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class MarketingScheduleController : Controller
    {
        private readonly Steak_ShopContext _context;

        public MarketingScheduleController(Steak_ShopContext context)
        {
            _context = context;
        }

        public IActionResult ManageSchedule()
        {
            var getInfo = _context.ScheduleMarketings.Include(m => m.IdMbNavigation).ToList();
            ViewData.Model = getInfo;

            return View("~/Views/Schedule/ManageSchedule.cshtml");
        }
        public ActionResult GetListMSs()
        {
            var getInfo = _context.ScheduleMarketings.Include(m => m.IdMbNavigation).ToList();

            ViewData.Model = getInfo;
            return View("~/Views/Schedule/ManageSchedule.cshtml");
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartDate,EndDate,CashReceive,IdMb")] ScheduleMarketing sm )
        {
            try
            {
                _context.Add(sm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetListMSs));
            }
            catch (Exception)
            {
                return View(sm);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
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
        public async Task<IActionResult> Edit(int id, [Bind("StartDate,EndDate,CashReceive")] ScheduleMarketing sm)
        {
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
            return RedirectToAction(nameof(GetListMSs));
        }
        private bool MSExists(int id)
        {
            return _context.ScheduleMarketings.Any(f => f.Id == id);
        }
    }
}
