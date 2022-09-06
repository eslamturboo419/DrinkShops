using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Interfaces;
using WebApplication1.Models.ImplementInterfaces;
using Microsoft.AspNetCore.Http;
using WebApplication1.Models.DB;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            services.AddMvc();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MyDbContext>();

 
            services.AddDbContextPool<MyDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyContextConnection"));
            });

            /// sessions
            services.AddDistributedMemoryCache();
            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(10); });

            //dependiencs 
            services.AddScoped<IDrinkRepostory, DrinkRepository>();
            services.AddScoped<ICategoryRepostory, CategoryRepostory>();
            services.AddScoped<IOrderRepostory, OrderRepository>();

            ///http accessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));



            services.Configure<IdentityOptions>(x =>
            {
                x.Password.RequiredLength = 4;  		 //   Defaults to 6.
                x.Password.RequiredUniqueChars = 0;		 //   Defaults to 1.
                x.Password.RequireNonAlphanumeric = false; //   Defaults to true.
                x.Password.RequireLowercase = false; 	//    Defaults to true.
                x.Password.RequireUppercase = false;     //     Defaults to true.
                x.Password.RequireDigit = false;        //    Defaults to true.

                // for the user
                x.User.RequireUniqueEmail = true;

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
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

            

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            /// every time run this application
            DbInitializer.Seed(app);
        }
    }
}
