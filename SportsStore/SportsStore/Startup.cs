using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SportsStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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

            //enamables asp.net core mvc
            app.UseMvc(routes =>
            {

            });
        }
    }
}
