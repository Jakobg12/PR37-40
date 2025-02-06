using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop1.Data.DataBase;
using Shop1.Data.Interfaces;
using Shop1.Data.Mocks;
using Shop1.Data.Models;

namespace Shop1
{
    public class Startup
    {
        public static List<ItemsBasket> BasketItem = new List<ItemsBasket>();
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IItems, DBItems>();
            services.AddTransient<ICategorys, DBCategory>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
