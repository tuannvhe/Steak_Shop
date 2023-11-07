using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class ScheduleMarketing
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? CashReceive { get; set; }
        public int IdMb { get; set; }

        public virtual MarketingBudget IdMbNavigation { get; set; } = null!;
    }
}
