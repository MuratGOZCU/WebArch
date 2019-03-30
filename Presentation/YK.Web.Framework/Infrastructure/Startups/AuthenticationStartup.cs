using YK.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YK.Web.Framework.Infrastructure.Startups
{
    public class AuthenticationStartup : IAppStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            ////add data protection
            //services.AddNopDataProtection();

            ////add authentication
            //services.AddNopAuthentication();
        }

        public void Configure(IApplicationBuilder application)
        {
            ////configure authentication
            //application.UseNopAuthentication();

            ////set request culture
            //application.UseCulture(); 
        }

        public int Order => 500;
    }
}
