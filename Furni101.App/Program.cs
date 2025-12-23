using Furni101.App.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Furni101.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<FurniDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            //app.MapDefaultControllerRoute();


                app.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );

            app.MapDefaultControllerRoute();
            //app.MapGet("/", () => "Hello World!");
            app.Run();
        }
    }
}
