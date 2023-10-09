using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class Blog
    {
        public Blog()
        {
            BlogImages = new HashSet<BlogImage>();
            BlogsCategories = new HashSet<BlogsCategory>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string BlogTitle { get; set; } = null!;
        public string BlogDetails { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Content { get; set; } = null!;
        public int Uid { get; set; }
        public int? Cid { get; set; }

        public virtual User UidNavigation { get; set; } = null!;
        public virtual ICollection<BlogImage> BlogImages { get; set; }
        public virtual ICollection<BlogsCategory> BlogsCategories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
