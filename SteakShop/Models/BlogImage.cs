using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class BlogImage
    {
        public int Id { get; set; }
        public string ImageSource { get; set; } = null!;
        public int Bid { get; set; }

        public virtual Blog BidNavigation { get; set; } = null!;
    }
}
