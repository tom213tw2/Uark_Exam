using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Uark_Exam
{
    internal class DefaultDependencyResolver : IDependencyResolver
    {
        private readonly ServiceProvider _serviceProvider;

        public DefaultDependencyResolver(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider as ServiceProvider;
        }

        public object GetService(Type serviceType)
        {
            return this._serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._serviceProvider.GetServices(serviceType);
        }

        public void Dispose()
        {
            this._serviceProvider?.Dispose();
        }
    }
}