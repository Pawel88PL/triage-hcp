using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using triage_hcp.Models;
using triage_hcp.Services;
using triage_hcp.Services.Interfaces;

namespace triage_hcp
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var services = new ServiceCollection();

            builder.Services.AddControllersWithViews();
            
            builder.Services.AddScoped<ITriageService, TriageService>();


            builder.Services.AddDbContext<DbTriageContext>(builder =>
            {
                builder.UseSqlServer(configuration.GetConnectionString("MyDatabase"));
            });

            builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<DbTriageContext>();

            var serviceProvider = services.BuildServiceProvider();

            var context = serviceProvider.GetService<DbTriageContext>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}