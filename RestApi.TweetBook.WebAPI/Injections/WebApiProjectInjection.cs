using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            #region services
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IIdentityService, IdentityService>();
            #endregion
            #region jwt
            var jwtSettings= new JwtSettings();
            configuration.Bind(nameof(JwtSettings),jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.SaveToken = true;
                    x.TokenValidationParameters= new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = 
                            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true
                    };
                });

            #endregion
            return services;
        }
    }
}
