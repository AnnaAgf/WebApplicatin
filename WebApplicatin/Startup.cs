using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplicatin.Infrastructure;
using WebApplicatin.Infrastructure.Interfaces;
using WebApplicatin.Infrastructure.Implementations;
using WebApplicatin.DAL;
using WebApplicatin.DomainNew.Entities;

namespace WebApplicatin
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //дл€ использовани€ DbContext -> appsettings
            services.AddDbContext<WebApplicatinContext>(options => options
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            //добавл€ем разрешение зависимости (интерфейс, экземпл€р класса)
            services.AddSingleton<IEmployeesService, InMemoryEmployeesService>();
            services.AddScoped<IProductService, SqlProductService>();
            services.AddSingleton<ISkiResortService, InMemorySkiResortService>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebApplicatinContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICartService, CookieCartService>();
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseWelcomePage("/welcome");
            //app.UseMiddleware<TokenMiddleware>("555555");
            //app.UseToken("555555");
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //await context.Response.WriteAsync("Hello World!");
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
