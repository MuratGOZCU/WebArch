using YK.Core.Caching;
using YK.Core.Configuration;
using YK.Core.Data;
using YK.Core.DependencyInjection;
using YK.Core.Reflection;
using YK.Data;
using YK.Services.Localization;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace YK.Web.Framework.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, AppConfig config)
        {
            //cache manager
            builder.RegisterType<PerRequestCacheManager>().As<ICacheManager>().InstancePerLifetimeScope();

            //data context
            var optionsBuilder = new DbContextOptionsBuilder<EfDbContext>();
            optionsBuilder.UseSqlServer(config.DataConnectionString);
            builder.Register<IDbContext>(c => new EfDbContext(optionsBuilder.Options)).InstancePerLifetimeScope();

            //repositories
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //services
            builder.RegisterType<LanguageService>().As<ILanguageService>().InstancePerLifetimeScope();
        }

        public int Order => 0;
    }
}