using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class AboutU
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Details { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
