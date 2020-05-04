using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RestApi.TweetBook.WebAPI.Options;

namespace RestApi.TweetBook.WebAPI.Injections
{
    public static class SwaggerInjection
    {
        public static IServiceCollection AddSwaggerDocumentation(
            this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "TweetBook API", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(
            this IApplicationBuilder app,
            IConfiguration configuration)
        {
            var swaggerOptions = new SwaggerOptions();

            configuration
                .GetSection(nameof(swaggerOptions))
                .Bind(swaggerOptions);

            app.UseSwagger(option =>
            {
                option.RouteTemplate = 
                    swaggerOptions.JsonRoute;
            });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(
                        swaggerOptions.UIEndpoint,
                        swaggerOptions.Description);
            });

            return app;
        }
    }
}
