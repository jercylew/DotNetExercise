using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAppDemo.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstAppDemo
{
    public class Startup
    {
        public Startup() //Default constructor
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("AppSettings.json");
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<FirstAppDemoDbContext>(option => option.Use);
        }

        private void ConfigRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller = Home}/{action = Index}/{id?}");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseWelcomePage(); Not available in .Core 2.1
            app.UseDeveloperExceptionPage();

            //Server static file, use default files
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseFileServer(); //Let the file server decide which one to use and take care of the order

            app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigRoute);


            //Last chance!!!
            app.Run(async (context) =>
            {
                //throw new Exception("Throw Exception");
                string strMsg = Configuration["message"];
                await context.Response.WriteAsync(strMsg);
            });
        }
    }
}
