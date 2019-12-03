using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Data;
using DonutShop.Models;
using DonutShop.Models.Interfaces;
using DonutShop.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DonutShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public IHostEnvironment Environment { get; }
        public Startup(IHostEnvironment environment)
        {
            Environment = environment;
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            string userConnectionString = Environment.IsDevelopment()
                ? Configuration["ConnectionStrings:UserDefaultConnection"]
                : Configuration["ConnectionStrings:UserProductionConnection"];
            
            string inventoryConnectionString = Environment.IsDevelopment()
                ? Configuration["ConnectionStrings:InventoryDefaultConnection"]
                : Configuration["ConnectionStrings:InventoryProductionConnection"];

            services.AddDbContext<UserDbContext>(options =>
            options.UseSqlServer(userConnectionString));

            services.AddDbContext<InventoryDbContext>(options =>
            options.UseSqlServer(inventoryConnectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<UserDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IInventory<Donut>, DonutService>();
            services.AddScoped<ICart, CartService>();
            services.AddScoped<IEmailSender, EmailService>();
            services.AddScoped<IOrder, OrderService>();

            services.AddAuthorization(options =>
            options.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationRoles.Admin)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            RoleInitializer.SeedData(serviceProvider);
        }
    }
}
