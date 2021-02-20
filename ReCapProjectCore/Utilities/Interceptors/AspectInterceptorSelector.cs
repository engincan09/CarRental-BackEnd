﻿using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectCore.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);


            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
