using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Cart() {
            string Username = HttpContext.Session.GetString("Username");
            var getUser = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
            if (getUser == null)
            {
                return View();
            }
            else
            {
                ViewData["User"] = getUser;
                return View();
            }
            return View(); }  
        [HttpPost]
        public IActionResult Cart(int foodid,int quantity)
        {
            string Username = HttpContext.Session.GetString("Username");
            var getUser = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
            var currentTime = new DateTime(); 
            var currentDateTimeString = currentTime.ToString();
            var address = getUser?.Address;
            var getFood = _context.Foods.Where(f => f.Id == foodid).FirstOrDefault();
            var amount = getFood.Price;
            //tạo order mới
            var Order = new Order
            {
                Date = currentTime,
                Address = address,
                TotalAmount = amount,
                Uid = getUser?.Id
            };
            _context.Orders.Add(Order); 
            _context.SaveChanges();
            //lưu order đó vào cart
            var order = _context.Orders.Where(o => o.Id == Order.Id).FirstOrDefault();
            var Order_Foods = new OrdersFood
            {
                Oid = order.Id,
                Fid = foodid,
                Quantity = quantity
            };
            _context.OrdersFoods.Add(Order_Foods);
            _context.SaveChanges();
            return View();
        }
    }
}
