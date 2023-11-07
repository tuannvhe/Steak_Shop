using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class MarketingBudget
    {
        public MarketingBudget()
        {
            ScheduleMarketings = new HashSet<ScheduleMarketing>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public decimal Budget { get; set; }

        public virtual ICollection<ScheduleMarketing> ScheduleMarketings { get; set; }
    }
}
