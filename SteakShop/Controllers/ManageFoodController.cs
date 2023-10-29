using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class ManageFoodController : Controller
    {

        private readonly Steak_ShopContext _context;

        public ManageFoodController(Steak_ShopContext context)
        {
            _context = context;
        }
        // GET: ManageFoodController
        public ActionResult ManageFood()
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
            return View();
        }

        // POST: ManageFoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ManageFoodController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageFoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var getFood = _context.Foods.Find(id);
                
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageFoodController/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View();
        }

        // POST: ManageFoodController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var getFood = _context.Foods.Find(id);
                _context.Foods.Remove(getFood);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
