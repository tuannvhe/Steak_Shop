using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly Steak_ShopContext _context;

        public CheckOutController(Steak_ShopContext context)
        {
            _context = context;
        }

        public decimal GetTotal()
        {
            string Username = HttpContext.Session.GetString("Username");
            var user = _context.Users.Where(u => u.Username == Username).FirstOrDefault();

            var cartItems = _context.Carts
                .Where(c => c.UserId == user.Id)
                .Include(c => c.Food)
                .ToList();

            decimal totalAmount = cartItems.Sum(item => item.Quantity * item.Food.Price);

            return totalAmount;
        }
        public IActionResult CheckOut()
        {
            string Username = HttpContext.Session.GetString("Username");
			var user = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
            var cartItems = _context.Carts
                .Where(c => c.UserId == user.Id)
                .Include(c => c.Food)
                .ToList();

            decimal totalPrice = cartItems.Sum(item => item.Quantity * item.Food.Price);
            ViewData["totalPrice"] = totalPrice;
            ViewData["userCart"] = cartItems;
            return View();
        }
        [HttpPost]
        public IActionResult CompletePayment() {

            string Username = HttpContext.Session.GetString("Username");
            var user = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
            var getCartItem = _context.Carts.Where(c => c.UserId == user.Id).ToList();
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = user.Address,
                TotalAmount = GetTotal(),
                Uid = user.Id
            };

            _context.Add(order);
            foreach (var item in getCartItem)
            {
                OrdersFood order_food = new OrdersFood
                {
                    Id = order.Id,
                    Fid = item.Id,
                    Quantity = item.Quantity,
                };
                _context.Add(order_food);
            }
            //_context.Remove(getCartItem);			

            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}
