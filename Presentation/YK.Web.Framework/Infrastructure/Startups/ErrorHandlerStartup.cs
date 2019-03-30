using YK.Core.Infrastructure;
using YK.Web.Framework.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YK.Web.Framework.Infrastructure.Startups
{
    public class ErrorHandlerStartup : IAppStartup
    { 
        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseAppExceptionHandler();
        }

        public int Order => 0;
    }
}
