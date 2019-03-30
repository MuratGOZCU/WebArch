using YK.Core.Infrastructure;
using YK.Web.Framework.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YK.Web.Framework.Infrastructure.Startups
{
    public class AppCommonStartup : IAppStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddHttpSession();

            services.AddAntiForgery();
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseStaticFiles();

            application.UseSession();
        }

        public int Order => 100;
    }
}