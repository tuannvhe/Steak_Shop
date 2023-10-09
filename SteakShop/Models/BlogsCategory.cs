using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class BlogsCategory
    {
        public int Id { get; set; }
        public int Bid { get; set; }
        public int Cid { get; set; }

        public virtual Blog BidNavigation { get; set; } = null!;
        public virtual BlogCategory CidNavigation { get; set; } = null!;
    }
}
