using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class Category
    {
        public Category()
        {
            Foods = new HashSet<Food>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Descriptions { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}
