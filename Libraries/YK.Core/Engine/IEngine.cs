using YK.Core.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YK.Core.Engine
{
    public interface IEngine
    {
        void Initialize(IServiceCollection services);

        void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration);

        void Configure(IApplicationBuilder application);

        IocManager IocManager { get; }
    }
}