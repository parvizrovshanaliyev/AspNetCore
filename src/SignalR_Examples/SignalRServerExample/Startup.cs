using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalRServerExample.Hubs;

namespace SignalRServerExample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //3. signal module elave edirik
            services.AddSignalR();

            // 5. requestleri qebul etmek ucun addCors politikasini elave etmeliyik
            services.AddCors(options => options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetIsOriginAllowed(origin => true);
            }));
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /* 5. requestleri qebul etmek ucun addCors politikasini elave etmeliyik
             *   app.UseRouting();-den once .UseCors() middleware cagrilmalidir
            */
            app.UseCors();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // 4. https://localhost:5001
                endpoints.MapHub<MyHub>("/myhub");
            });
        }
    }
}