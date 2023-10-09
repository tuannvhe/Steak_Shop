using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class Chef
    {
        public Chef()
        {
            OrdersChefs = new HashSet<OrdersChef>();
            WorkShifts = new HashSet<WorkShift>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public decimal Salary { get; set; }
        public string Certificate { get; set; } = null!;

        public virtual ICollection<OrdersChef> OrdersChefs { get; set; }
        public virtual ICollection<WorkShift> WorkShifts { get; set; }
    }
}
