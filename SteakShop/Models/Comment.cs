using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;
        public int? Bid { get; set; }

        public virtual Blog? BidNavigation { get; set; }
    }
}
