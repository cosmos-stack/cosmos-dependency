using System;
using System.Collections.Generic;

namespace Autofac
{
    /// <summary>
    /// Autofac resolve extensions
    /// </summary>
    public static class AutofacResolveExtensions
    {
        private static Type _pinedEnumerableType = typeof(IEnumerable<>);

        /// <summary>
        /// Resolve many
        /// </summary>
        /// <param name="container"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static IEnumerable<object> ResolveMany(this IComponentContext container, Type serviceType)
        {
            var type = _pinedEnumerableType.MakeGenericType(serviceType);
            return container.Resolve(type) as IEnumerable<object>;
        }

        /// <summary>
        /// Resolve many
        /// </summary>
        /// <param name="container"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TService> ResolveMany<TService>(this IComponentContext container) where TService : class
        {
            return container.Resolve<IEnumerable<TService>>();
        }
    }
}