using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;
using System;
using System.Globalization;

namespace SteakShop.Controllers
{
    public class ChartController : Controller
    {
        private readonly Steak_ShopContext _context;
        public IActionResult Chart()
        {
            return View();
        }
        public ChartController(Steak_ShopContext context)
        {
            _context = context;
        }
        public class ChartViewModel
        {
            public int[] ChartData { get; set; }
            public string ChartTitle { get; set; }

            public string XAxisLabel { get; set; }

            public string YAxisLabel { get; set; }

            public List<string> LegendLabels { get; set; }
        }
        public struct Response
        {

            public int[] Data { get; set; }
            public int[] Data2 { get; set; }

        }
        [HttpPost]
        public IActionResult GetData(int id)
        {
            List<DateTime> dt = new List<DateTime>();
            List<decimal> totalAmount = new List<decimal>();
            List<string> formatDt = new List<string>();
            List<int> months = new List<int>();
            List<int> years = new List<int>();
            var today = DateTime.Now;
            var fromDate = today.AddDays(0);
            var fromMonth = today.AddMonths(0);
            var fromYear = today.AddYears(0);
            var response = new
            {
                Data1 = totalAmount,
                Data2 = formatDt.ToArray()
            };
            if (id == 1)
            {
                fromDate = today.AddDays(-1);
            }
            if (id == 2)
            {
                fromDate = today.AddDays(-4);
            }
            if (id == 3)
            {
                fromDate = today.AddDays(-7);
            }
            else if (id == 4)
            {
                fromDate = today.AddDays(-30);
            }
            else if (id == 5)
            {
                fromDate = today.AddDays(-90);
            }
            else if (id == 6)
            {
                fromDate = today.AddDays(-365);
            }
            else if (id == 7)
            {
                fromMonth = today.AddMonths(-1);

            }
            else if (id == 8)
            {
                fromMonth = today.AddMonths(-12);

            }
            else if (id == 9)
            {
                fromYear = today.AddYears(-1);
            }
            var datetime = _context.Orders.Where(o => o.Date >= fromDate && o.Date <= today).ToList();
            if (fromMonth.Month != today.Month)
            {
                datetime = _context.Orders.Where(o => o.Date >= fromMonth && o.Date <= today).ToList();
            }
            if (fromYear.Year != today.Year)
            {
                datetime = _context.Orders.Where(o => o.Date >= fromYear && o.Date <= today).ToList();
            }
            foreach (var order in datetime)
            {
                if (!dt.Contains(order.Date))
                {
                    dt.Add(order.Date);
                    totalAmount.Add(order.TotalAmount);
                }
                else
                {
                    totalAmount[totalAmount.Count - 1] += order.TotalAmount;
                }
                // Thêm ngày vào danh sách
            }
            formatDt = dt.Select(d => d.ToString("yyyy-MM-dd")).ToList();
            response = new
            {
                Data1 = totalAmount,
                Data2 = formatDt.ToArray()
            };
            return Json(response);
        }
    }
}
