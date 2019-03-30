using YK.Core.Configuration;
using YK.Core.Reflection;
using Autofac;

namespace YK.Core.DependencyInjection
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, AppConfig config);

        int Order { get; }
    }
}