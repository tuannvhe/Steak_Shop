using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class BlogCategory
    {
        public BlogCategory()
        {
            BlogsCategories = new HashSet<BlogsCategory>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<BlogsCategory> BlogsCategories { get; set; }
    }
}
