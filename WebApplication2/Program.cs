using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CSWebApp.Data;
namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string? str = builder.Configuration.GetConnectionString("CSWebAppContext");
            builder.Services.AddDbContext<CSWebAppContext>(options =>
                options.UseSqlServer(str ?? throw new InvalidOperationException("Connection string 'CSWebAppContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
