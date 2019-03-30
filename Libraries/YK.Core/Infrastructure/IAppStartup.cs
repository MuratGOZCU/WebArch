using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YK.Core.Infrastructure
{
    public interface IAppStartup
    {
        void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration);

        void Configure(IApplicationBuilder application);

        int Order { get; }
    }
}