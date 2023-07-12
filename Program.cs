using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
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

            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IDeleteService, DeleteService>();
            builder.Services.AddScoped<IDetailsService, DetailsService>();
            builder.Services.AddScoped<IDocumentService, DocumentService>();
            builder.Services.AddScoped<IListService, ListService>();
            builder.Services.AddScoped<IPeselService, PeselService>();
            builder.Services.AddScoped<ISearchPatientService, SearchPatientService>();
            builder.Services.AddScoped<ITriageService, TriageService>();

            builder.Services.AddDbContext<DbTriageContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("local"));
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