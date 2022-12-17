using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using WebCarShop.Controllers;
using WebCarShop.Data.Interfaces;
using WebCarShop.Data.Models;
using WebCarShop.Data.Repositories;

namespace WebCarShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Додав я
            builder.Services.AddMvc();
            //builder.Services.AddDbContext<UsedCarContext>(options => options.UseSqlServer(_coinfString.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<IAllCars,CarsReposytory>();/*якщо не скалдеться з моєю бд*/

            var app = builder.Build();
            //Додав я
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            //app.Map("/time", (IAllCars timeService) => timeService.allC);
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Cars}/{action=ListCars}/{id?}");
            });

            app.Run();
        }
    }
}