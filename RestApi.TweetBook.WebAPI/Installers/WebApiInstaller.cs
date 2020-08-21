using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RestApi.TweetBook.WebAPI.Installers
{
    public class WebApiInstaller :IInstaller
    {
        #region Implementation of IInstaller

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
        }

        #endregion
    }
}
