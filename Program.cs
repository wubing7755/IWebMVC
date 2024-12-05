using IWebMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ���� WepApplication ��ʵ��
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            // set database context
            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnStr")));

            // ���� WebApplication ��ʵ��
            var app = builder.Build();

            // create database
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                dbContext.Database.EnsureCreated();
                dbContext.InitializeSeedData();
            };

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllers();

            // ���� WebApplication
            app.Run();
        }
    }
}