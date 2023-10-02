using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Uark_Exam.Interface;
using Uark_Exam.Service;

namespace Uark_Exam
{
    public class DependencyInjectionConfig
    {
        public static void Register()
        {
            var services = ConfigureServices();

            var provider = services.BuildServiceProvider();

            var resolver = new DefaultDependencyResolver(provider);
            ServiceScopeHttpModule.SetServiceProvider(provider);
            DependencyResolver.SetResolver(resolver);

            //config.DependencyResolver = resolver;
        }
        /// <summary>
        ///     使用 MS DI 註冊
        /// </summary>
        /// <returns></returns>
        private static ServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            //使用 Microsoft.Extensions.DependencyInjection 註冊
            services.AddControllersAsServices(typeof(DependencyInjectionConfig).Assembly
                .GetExportedTypes());
            
            services.AddServiceScope();
            
            return services;
        }
    }
}