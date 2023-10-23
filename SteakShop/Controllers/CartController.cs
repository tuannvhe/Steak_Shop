using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;

namespace SteakShop.Controllers
{
    public class CartController : Controller
    {
        private readonly Steak_ShopContext _context;

        public CartController(Steak_ShopContext context)
        {
            _context = context;
        }
        public decimal GetTotal()
        {
			string Username = HttpContext.Session.GetString("Username");
			var user = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
			var cart = _context.Carts.Include(c => c.FoodId).Where(c => c.UserId == user.Id).ToList();
			decimal totalAmount = 0;
			foreach (var item in cart)
			{
				totalAmount += item.Quantity * item.Food.Price;
			}
            return totalAmount;
		}
        public IActionResult GetCart()
        {
            string Username = HttpContext.Session.GetString("Username");
            var user = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
			var cart = _context.Carts.Include(c => c.FoodId).Where(c => c.UserId == user.Id).ToList();

            ViewData["TotalAmount"] = GetTotal();
            ViewData["Cart"] = cart;
			return View("~Views/Cart/Cart.cshtml");
		}

        [HttpPost]
        public IActionResult AddToCart(int foodId,int quantity)
        {
            string Username = HttpContext.Session.GetString("Username");
            var user = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
            var food = _context.Foods.Where(f => f.Id == foodId).FirstOrDefault();

			var getCart = _context.Carts.Where(c => c.UserId == user.Id && c.FoodId == foodId).FirstOrDefault();

            if (getCart == null)
            {
                Cart cart = new Cart
                {
                    UserId = user.Id,
                    FoodId = foodId,
                    Quantity = quantity
                };

                _context.Add(cart);
                _context.SaveChanges();
            }
            else
            {
                getCart.Quantity += quantity;
                _context.Update(getCart);
				_context.SaveChanges();
			}

			ViewData["TotalAmount"] = GetTotal();
			return View("~Views/Cart/Cart.cshtml");
        }

        public IActionResult RemoveCartItem(int foodId) {
			string Username = HttpContext.Session.GetString("Username");
			var user = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
			var food = _context.Foods.Where(f => f.Id == foodId).FirstOrDefault();
			var getCartItem = _context.Carts.Where(c => c.UserId == user.Id && c.FoodId == foodId).FirstOrDefault();

            getCartItem.Quantity = getCartItem.Quantity - 1;
			_context.Update(getCartItem);
			_context.SaveChanges();

			ViewData["TotalAmount"] = GetTotal();
			return View("~Views/Cart/Cart.cshtml");
        }

        public IActionResult CreateOrder(int quantity)
        {
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
			_context.Remove(getCartItem);			
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
		}
    }
}
