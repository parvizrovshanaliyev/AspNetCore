using System;
using System.IO;
using System.Reflection;
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
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TweetBook API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Parviz",
                        Email = "parviz@pragmatech.az",
                        Url = new Uri("https://www.zedotech.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerOptions.UIEndpoint,
                    swaggerOptions.Description);
                c.RoutePrefix = string.Empty;
            });
            
            //app.UseSwagger(option =>
            //{
            //    option.RouteTemplate = 
            //        swaggerOptions.JsonRoute;
            //});
            //app.UseSwaggerUI(option =>
            //{
            //    option.SwaggerEndpoint(
            //            swaggerOptions.UIEndpoint,
            //            swaggerOptions.Description);
            //});

            return app;
        }
    }
}
