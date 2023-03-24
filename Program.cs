using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddScoped<ITriageService, TriageService>();

            builder.Services.AddDbContext<DbTriageContext>(builder =>
            {
                builder.UseSqlServer("Data Source=mssql4.webio.pl,2401;Database=triagetest_triage-hcp;Uid=triagetest_admin123;Password=Myszka1995@;TrustServerCertificate=True");
            });

            builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<DbTriageContext>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}