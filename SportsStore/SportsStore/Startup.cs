using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace SportsStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
            //tells Core that when a component such as a controller needs and implementation of the IProductRepository interface, it should receive an instance
            //of the FakeProductRepository class or EFProductRepository
            services.AddTransient<IProductRepository, EFProductRepository>();
            //extension method setups up shared object used in mvc
            services.AddMvc();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //ext meth displays details of exceptions, do comment out for deployment
            app.UseDeveloperExceptionPage();
            //adds boidly messages to HTTP responses
            app.UseStatusCodePages();
            //serve static content frmo wwwroot folder, such as CSS files
            app.UseStaticFiles();

            //enables asp.net core mvc;
            //sets up MVC middleware to handle HTTP requests, mappign URLS to controllers/action methods
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=List}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
