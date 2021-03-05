using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ReCapProjectCore.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectCore.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
        }
    }
}
