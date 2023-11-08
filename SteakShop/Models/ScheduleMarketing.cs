using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SteakShop.Models
{
    public partial class ScheduleMarketing
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? CashReceive { get; set; }
        [Range(1, 5)]
        public int IdMb { get; set; }

        public virtual MarketingBudget IdMbNavigation { get; set; } = null!;
    }
}
