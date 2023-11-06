using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SteakShop.Models;
using System.Globalization;

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
            ViewData["TotalAmount"] = GetTotal();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CompletePaymentAsync() {

            string Username = HttpContext.Session.GetString("Username");
            var user = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
            var getCartItem = _context.Carts.Where(c => c.UserId == user.Id).ToList();
            DateTime currentTime = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            string timeString = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime datetime = DateTime.ParseExact(timeString, format, CultureInfo.InvariantCulture);
            Order order = new Order
            {
                Date = datetime,
                Address = user.Address,
                TotalAmount = GetTotal(),
                Uid = user.Id
            };
            
            Notification notification = new Notification
            {
                Content = $"A new order. Username: {Username}" +
                $", Time order: {timeString}" +
                $", Address: {user.Address}" +
                $", Total Amount: {GetTotal()}",
                Date = datetime,
                IsRead = 2
            };

            var notificationData = new
            {
                ID = order.Id,
                UserID = Username,
                AlertDate = DateTime.Now,
                OrderDate = timeString,
                Address = user.Address,
                TotalAmount = GetTotal()
            };
            var notificationMessage = JsonConvert.SerializeObject(notificationData);
            var hubContext = HttpContext.RequestServices.GetRequiredService<IHubContext<NotificationHub>>();
            await hubContext.Clients.All.SendAsync("ReceiveNotification", notificationMessage);

            _context.Add(notification);
            _context.Add(order);
            _context.SaveChanges();

            foreach (var item in getCartItem)
            {
                OrdersFood order_food = new OrdersFood
                {
                    Oid = order.Id,
                    Fid = item.FoodId,
                    Quantity = item.Quantity,
                };
                _context.Add(order_food);
            }

            foreach (var item in getCartItem)
            {
                _context.Carts.Remove(item);
            }

            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}
