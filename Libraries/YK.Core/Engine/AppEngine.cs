#region Usings

using System;
using System.Linq;
using System.Net;
using YK.Core.Configuration;
using YK.Core.DependencyInjection;
using YK.Core.Infrastructure;
using YK.Core.Mapper;
using YK.Core.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace YK.Core.Engine
{
    public class AppEngine : IEngine
    {
        #region Props

        public IocManager IocManager { get; private set; }

        #endregion

        #region Utils     

        private void RegisterDependencies(AppConfig appConfig, IServiceCollection services, ITypeFinder typeFinder)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(this).As<IEngine>().SingleInstance();

            containerBuilder.RegisterType<IAssemblyProvider>().As<IAssemblyProvider>().SingleInstance();

            containerBuilder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            var dependencyRegistrars = typeFinder.FindClassesOfType<IDependencyRegistrar>();

            var instances = dependencyRegistrars
                .Select(dependencyRegistrar => (IDependencyRegistrar)Activator.CreateInstance(dependencyRegistrar))
                .OrderBy(dependencyRegistrar => dependencyRegistrar.Order);

            foreach (var dependencyRegistrar in instances)
                dependencyRegistrar.Register(containerBuilder, typeFinder, appConfig);

            containerBuilder.Populate(services);

            var serviceProvider = new AutofacServiceProvider(containerBuilder.Build());
            IocManager = new IocManager(serviceProvider);
        }

        private void RunStartupTasks(ITypeFinder typeFinder)
        {
            var startupTasks = typeFinder.FindClassesOfType<IStartupTask>();

            var instances = startupTasks
                .Select(startupTask => (IStartupTask)Activator.CreateInstance(startupTask))
                .OrderBy(startupTask => startupTask.Order);

            foreach (var task in instances)
                task.Execute();
        }

        private void AddAutoMapper(IServiceCollection services, ITypeFinder typeFinder)
        {
            var mapperConfigurations = typeFinder.FindClassesOfType<IMapperProfile>();

            var instances = mapperConfigurations
                .Select(mapperConfiguration => (IMapperProfile)Activator.CreateInstance(mapperConfiguration))
                .OrderBy(mapperConfiguration => mapperConfiguration.Order);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var instance in instances)
                    cfg.AddProfile(instance.GetType());
            });

            services.AddAutoMapper();

            AutoMapperConfiguration.Init(config);
        }

        #endregion

        #region Methods

        public void Initialize(IServiceCollection services)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var provider = services.BuildServiceProvider();
            var hostingEnvironment = provider.GetRequiredService<IHostingEnvironment>();
            CommonHelper.BaseDirectory = hostingEnvironment.ContentRootPath;
        }

        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            var typeFinder = new AppTypeFinder(new AppAssemblyProvider());
            var startupConfigurations = typeFinder.FindClassesOfType<IAppStartup>();

            var instances = startupConfigurations
                .Select(startup => (IAppStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);

            foreach (var instance in instances)
                instance.ConfigureServices(services, configuration);

            AddAutoMapper(services, typeFinder);

            var appConfig = services.BuildServiceProvider().GetService<AppConfig>();
            RegisterDependencies(appConfig, services, typeFinder);

            if (!appConfig.IgnoreStartupTasks)
                RunStartupTasks(typeFinder);
        }

        public void Configure(IApplicationBuilder application)
        {
            var typeFinder = IocManager.Resolve<ITypeFinder>();
            var appStartups = typeFinder.FindClassesOfType<IAppStartup>();

            var instances = appStartups
                .Select(startup => (IAppStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);

            foreach (var instance in instances)
                instance.Configure(application);
        }

        #endregion
    }
}