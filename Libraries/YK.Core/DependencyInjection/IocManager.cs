#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace YK.Core.DependencyInjection
{
    public class IocManager
    {
        #region Fields

        private  readonly IServiceProvider _serviceProvider;

        #endregion

        #region Ctors

        public IocManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region Utils

        private IServiceProvider GetServiceProvider()
        {
            var accessor = _serviceProvider.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            return context != null ? context.RequestServices : _serviceProvider;
        }

        #endregion

        #region Methods

        public object Resolve(Type type)
            => GetServiceProvider().GetRequiredService(type);

        public T Resolve<T>() where T : class
            => (T)GetServiceProvider().GetRequiredService(typeof(T));

        public IEnumerable<T> ResolveAll<T>()
            => (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));

        public object ResolveUnregistered(Type type)
        {
            Exception innerException = null;
            foreach (var constructor in type.GetConstructors())
            {
                try
                {
                    var parameters = constructor.GetParameters().Select(parameter =>
                    {
                        var service = Resolve(parameter.ParameterType);
                        if (service == null)
                            throw new Exception("Unknown dependency");
                        return service;
                    });

                    return Activator.CreateInstance(type, parameters.ToArray());
                }
                catch (Exception ex)
                {
                    innerException = ex;
                }
            }
            throw new Exception("No constructor was found that had all the dependencies satisfied.", innerException);
        }

        #endregion

        #region Props

        public IServiceProvider ServiceProvider => _serviceProvider;

        #endregion
    }
}