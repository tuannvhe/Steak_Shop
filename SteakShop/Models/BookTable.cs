using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class BookTable
    {
        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
        public int EventId { get; set; }
        public int? Uid { get; set; }

        public virtual Event Event { get; set; } = null!;
        public virtual User? UidNavigation { get; set; }
    }
}
