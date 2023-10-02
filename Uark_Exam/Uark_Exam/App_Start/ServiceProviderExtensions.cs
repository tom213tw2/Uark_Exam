using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Uark_Exam.Service;

namespace Uark_Exam
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllersAsServices(this IServiceCollection services,
            IEnumerable<Type> controllerTypes)
        {
            var filter = controllerTypes.Where(t => !t.IsAbstract
                                                    && !t.IsGenericTypeDefinition)
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t)
                            || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase));

            foreach (var type in filter)
            {
                services.AddTransient(type);
            }

            return services;
        }

        public static IServiceCollection AddServiceScope(this IServiceCollection services)
        {
            foreach (var item in typeof(FileService).Assembly.GetTypes().Where(s=>!s.IsAbstract &&s.Name.EndsWith("Service",StringComparison.OrdinalIgnoreCase)))
            {
                services.AddTransient(item.GetInterfaces().SingleOrDefault() ?? throw new InvalidOperationException(), item);
            }

            return services;
        }
    }
}