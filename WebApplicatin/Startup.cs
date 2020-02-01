using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApplicatin.Infrastructure;
using WebApplicatin.Infrastructure.Interfaces;
using WebApplicatin.Infrastructure.Implementations;
using WebApplicatin.DAL;

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
            services.AddSingleton<ISkiResortService, InMemorySkiResortService>();

            services.AddSingleton<IProductService, InMemoryProductService>();
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
