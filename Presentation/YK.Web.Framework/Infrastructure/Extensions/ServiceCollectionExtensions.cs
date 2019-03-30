using System;
using YK.Core.Configuration;
using YK.Core.Engine;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace YK.Web.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #region Utils

        private static void ConfigureStartupConfig<TConfig>(this IServiceCollection services,
            IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var config = new TConfig();

            configuration.Bind(config);

            services.AddSingleton(config);
        }

        private static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        #endregion

        public static IServiceProvider ConfigureServices(this IServiceCollection services,
            IConfigurationRoot configuration)
        {
            services.ConfigureStartupConfig<AppConfig>(configuration.GetSection("App"));
            services.AddHttpContextAccessor();

            var engine = EngineContext.Create();
            engine.Initialize(services);
            engine.ConfigureServices(services, configuration);

            return engine.IocManager.ServiceProvider;
        }

        public static void AddAntiForgery(this IServiceCollection services)
        {
            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = ".App.Antiforgery";
            });
        }

        public static void AddHttpSession(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.Cookie.Name = ".App.Session";
                options.Cookie.HttpOnly = true;
            });
        }

        public static void AddAppMvc(this IServiceCollection services)
        {
            //add basic MVC feature
            var mvcBuilder = services.AddMvc();

            //use session temp data provider
            mvcBuilder.AddSessionStateTempDataProvider();

            //MVC now serializes JSON with camel case names by default, use this code to avoid it
            mvcBuilder.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //add fluent validation
            mvcBuilder.AddFluentValidation(configuration => configuration.ValidatorFactoryType = typeof(AppValidatorFactory));
        }
    }
}
