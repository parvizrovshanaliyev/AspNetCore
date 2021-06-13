using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example1.Constraints;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Routing;

namespace Example1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // custom RouteConstraint
            services.Configure<RouteOptions>(option=>option.ConstraintMap.Add("custom",typeof(CustomConstraint)));
            //
            services.AddControllersWithViews()
                .AddFluentValidation(x =>
                    x.RegisterValidatorsFromAssemblyContaining<Startup>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                //custom route
                endpoints.MapControllerRoute("Default2", "mainPage", new { controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("Default3", "{controller=Personal}/{action=Index}");
                // route constraits
                endpoints.MapControllerRoute("Default4", "{controller=Personal}/{action=Index}/{id:int?}");
                endpoints
                    .MapControllerRoute("Default4", "{controller=Personal}/{action=Index}/{id:custom?}/{x:length(12)?}");
                // deafult
                endpoints.MapDefaultControllerRoute();

                // attribute routing
                endpoints.MapControllers();
            });
        }
    }
}
