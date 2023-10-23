using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class Food
    {
        public Food()
        {
            Carts = new HashSet<Cart>();
            OrdersFoods = new HashSet<OrdersFood>();
        }

        public int Id { get; set; }
        public string FoodName { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CId { get; set; }

        public virtual Category CIdNavigation { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrdersFood> OrdersFoods { get; set; }
    }
}
