using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class OrdersFood
    {
        public int Id { get; set; }
        public int Oid { get; set; }
        public int Fid { get; set; }
        public int Quantity { get; set; }

        public virtual Food FidNavigation { get; set; } = null!;
        public virtual Order OidNavigation { get; set; } = null!;
    }
}
