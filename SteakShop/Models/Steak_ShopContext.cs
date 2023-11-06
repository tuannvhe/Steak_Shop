using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SteakShop.Models
{
    public partial class Steak_ShopContext : DbContext
    {
        public Steak_ShopContext()
        {
        }

        public Steak_ShopContext(DbContextOptions<Steak_ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AboutU> AboutUs { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<BlogCategory> BlogCategories { get; set; } = null!;
        public virtual DbSet<BlogImage> BlogImages { get; set; } = null!;
        public virtual DbSet<BlogsCategory> BlogsCategories { get; set; } = null!;
        public virtual DbSet<BookTable> BookTables { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Chef> Chefs { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<ContactU> ContactUs { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrdersChef> OrdersChefs { get; set; } = null!;
        public virtual DbSet<OrdersFood> OrdersFoods { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WorkShift> WorkShifts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Steak_Shop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AboutU>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BlogDetails).HasMaxLength(255);

                entity.Property(e => e.BlogTitle).HasMaxLength(255);

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_Users");
            });

            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName).HasMaxLength(255);
            });

            modelBuilder.Entity<BlogImage>(entity =>
            {
                entity.ToTable("Blog_Image");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bid).HasColumnName("BID");

                entity.HasOne(d => d.BidNavigation)
                    .WithMany(p => p.BlogImages)
                    .HasForeignKey(d => d.Bid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_Image_Blog");
            });

            modelBuilder.Entity<BlogsCategory>(entity =>
            {
                entity.ToTable("Blogs_Categories");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bid).HasColumnName("BID");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.HasOne(d => d.BidNavigation)
                    .WithMany(p => p.BlogsCategories)
                    .HasForeignKey(d => d.Bid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blogs_Categorys_Blog");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.BlogsCategories)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blogs_Categorys_BlogCategories");
            });

            modelBuilder.Entity<BookTable>(entity =>
            {
                entity.ToTable("BookTable");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.BookTables)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookTable_Events");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.BookTables)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("FK_BookTable_Users");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Foods");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Users");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName).HasMaxLength(255);
            });

            modelBuilder.Entity<Chef>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Certificate).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bid).HasColumnName("BID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.BidNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Bid)
                    .HasConstraintName("FK_Comment_Blog");
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.OpenTime).HasMaxLength(255);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EventName).HasMaxLength(255);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.FoodName).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Foods_Categories");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<OrdersChef>(entity =>
            {
                entity.ToTable("Orders_Chefs");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChefId).HasColumnName("ChefID");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.HasOne(d => d.Chef)
                    .WithMany(p => p.OrdersChefs)
                    .HasForeignKey(d => d.ChefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Chefs_Chefs");

                entity.HasOne(d => d.OidNavigation)
                    .WithMany(p => p.OrdersChefs)
                    .HasForeignKey(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Chefs_Orders");
            });

            modelBuilder.Entity<OrdersFood>(entity =>
            {
                entity.ToTable("Orders_Foods");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.HasOne(d => d.FidNavigation)
                    .WithMany(p => p.OrdersFoods)
                    .HasForeignKey(d => d.Fid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Foods_Foods");

                entity.HasOne(d => d.OidNavigation)
                    .WithMany(p => p.OrdersFoods)
                    .HasForeignKey(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Foods_Orders");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(30);

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            modelBuilder.Entity<WorkShift>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChefId).HasColumnName("ChefID");

                entity.Property(e => e.Holidays).HasMaxLength(50);

                entity.Property(e => e.Shifts).HasMaxLength(30);

                entity.HasOne(d => d.Chef)
                    .WithMany(p => p.WorkShifts)
                    .HasForeignKey(d => d.ChefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkShifts_Chefs");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
