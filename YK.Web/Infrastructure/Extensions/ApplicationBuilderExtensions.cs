using YK.Core.Configuration;
using YK.Core.Engine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace YK.Web.Framework.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void Configure(this IApplicationBuilder application)
        {
            EngineContext.Current.Configure(application);
        }

        public static void UseAppMvc(this IApplicationBuilder application)
        {
            application.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            application.UseMvcWithDefaultRoute();
        }

        public static void UseAppExceptionHandler(this IApplicationBuilder application)
        {
            var appConfig = EngineContext.Current.IocManager.Resolve<AppConfig>();
            var hostingEnvironment = EngineContext.Current.IocManager.Resolve<IHostingEnvironment>();
            var useDetailedExceptionPage = appConfig.DisplayFullErrorStack || hostingEnvironment.IsDevelopment();
            if (useDetailedExceptionPage)
            {
                //get detailed exceptions for developing and testing purposes
                application.UseDeveloperExceptionPage();
            }
            else
            {
                //or use special exception handler
                application.UseExceptionHandler("/errorpage.htm");
            }   
            
            //log errors
        }
    }
}
