using System;
using System.Collections.Generic;

namespace Cosmos.Dependency
{
    /// <summary>
    /// Interface for service resolver
    /// </summary>
    public interface IDefinedResolver
    {
        /// <summary>
        /// Resolve
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        object Resolve(Type serviceType);

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        TService Resolve<TService>() where TService : class;

        /// <summary>
        /// Required resolve
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        object RequiredResolve(Type serviceType);

        /// <summary>
        /// Required resolve
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        TService RequiredResolve<TService>() where TService : class;

        /// <summary>
        /// Resolve many
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        IEnumerable<object> ResolveMany(Type serviceType);

        /// <summary>
        /// Resolve many
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        IEnumerable<TService> ResolveMany<TService>() where TService : class;
    }
}