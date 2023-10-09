using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class Order
    {
        public Order()
        {
            OrdersChefs = new HashSet<OrdersChef>();
            OrdersFoods = new HashSet<OrdersFood>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public int? Uid { get; set; }

        public virtual User? UidNavigation { get; set; }
        public virtual ICollection<OrdersChef> OrdersChefs { get; set; }
        public virtual ICollection<OrdersFood> OrdersFoods { get; set; }
    }
}
