using System;
using System.Collections.Generic;

namespace SteakShop.Models
{
    public partial class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            BookTables = new HashSet<BookTable>();
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int? NumberOfLogins { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<BookTable> BookTables { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
