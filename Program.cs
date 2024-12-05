using IWebMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 创建 WepApplication 类实例
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            // set database context
            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnStr")));

            // 返回 WebApplication 类实例
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

            // 启动 WebApplication
            app.Run();
        }
    }
}