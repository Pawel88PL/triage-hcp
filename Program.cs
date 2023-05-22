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

            builder.Services.AddControllersWithViews();
            
            builder.Services.AddScoped<ITriageService, TriageService>();

            builder.Services.AddDbContext<DbTriageContext>(builder =>
            {
                builder.UseSqlServer("Data Source=mssql2.webio.pl,2401;Database=triageadmin_mydatabase;Uid=triageadmin_mydatabase;Password=&(MxH*TA/Q4]$Q-%NEk_;TrustServerCertificate=True");
            });

            // "Data Source=mssql2.webio.pl,2401;Database=triageadmin_mydatabase;Uid=triageadmin_mydatabase;Password=&(MxH*TA/Q4]$Q-%NEk_;TrustServerCertificate=True"
            // "Server=localhost\\SQLEXPRESS;Database=sor_hcp;Uid=sa;Password=Pawel1234!"


            builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<DbTriageContext>();

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