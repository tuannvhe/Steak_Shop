using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class ContactU
    {
        public int Id { get; set; }
        public string Details { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string OpenTime { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
