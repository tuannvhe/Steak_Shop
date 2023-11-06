using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Content { get; set; }
        public int? IsRead { get; set; }
    }
}
