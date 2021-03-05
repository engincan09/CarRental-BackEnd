
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using ReCapProjectCore.CrossCutingConcerns.Caching;
using ReCapProjectCore.CrossCutingConcerns.Caching.Microsoft;
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

            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
