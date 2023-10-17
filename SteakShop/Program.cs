using Microsoft.EntityFrameworkCore;
using SteakShop.Models;

namespace SteakShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<Steak_ShopContext>();

			//enable Session
			builder.Services.AddDistributedMemoryCache();
			
			builder.Services.AddHttpContextAccessor();
			builder.Services.AddSession(cfg => {
				cfg.Cookie.Name = "Steakshop";
				cfg.Cookie.IsEssential = true;
				cfg.IdleTimeout = new TimeSpan(0, 15, 0);
			});
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}