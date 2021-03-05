using Microsoft.Extensions.DependencyInjection;
using ReCapProjectCore.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectCore.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
