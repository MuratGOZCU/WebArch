using YK.Web.Framework.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace YK.Web.Api
{
    public class Startup
    {
        #region Properties

        public IConfigurationRoot Configuration { get; }

        #endregion

        #region Ctor

        public Startup(IHostingEnvironment environment)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        #endregion

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.ConfigureServices(Configuration);
        }

        public void Configure(IApplicationBuilder application)
        {
            application.Configure();
        }
    }
}