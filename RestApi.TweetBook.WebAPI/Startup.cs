using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestApi.TweetBook.WebAPI.Injections;

namespace RestApi.TweetBook.WebAPI
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
            #region iinstaller version injection

            //services.InstallServicesInAssembly(Configuration);

            #endregion

            #region extension version injections

            // swagger
            services.AddSwaggerDocumentation();

            // infrastructure
            services.AddInfrastructureInjection(Configuration);

            // webApi
            services.AddWebApiProjectInjection(Configuration);

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region MyRegion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // swagger
            app.UseSwaggerDocumentation(Configuration);

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            #endregion
            
            
        }
    }
}
