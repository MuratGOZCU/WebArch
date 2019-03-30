using YK.Core.Infrastructure;
using YK.Web.Framework.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YK.Web.Framework.Infrastructure.Startups
{
    public class AppMvcStartup : IAppStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddAppMvc();
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseAppMvc();
        }

        public int Order => 1000;
    }
}
