using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RestApi.TweetBook.WebAPI.Injections
{
    public static class WebApiProjectInjection
    {
        public static IServiceCollection AddWebApiProjectInjection(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers();

            return services;
        }
    }
}
