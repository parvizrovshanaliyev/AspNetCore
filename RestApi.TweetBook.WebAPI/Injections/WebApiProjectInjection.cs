using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestApi.TweetBook.WebAPI.Options;
using RestApi.TweetBook.WebAPI.Services;

namespace RestApi.TweetBook.WebAPI.Injections
{
    public static class WebApiProjectInjection
    {
        public static IServiceCollection AddWebApiProjectInjection(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers();
            services.AddScoped<IPostService, PostService>();
            #region jwt
            var jwtSettings= new JwtSettings();
            configuration.Bind(nameof(JwtSettings),jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = 
            });
            #endregion
            return services;
        }
    }
}
