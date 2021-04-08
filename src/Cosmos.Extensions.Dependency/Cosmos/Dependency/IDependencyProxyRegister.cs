using System;

namespace Cosmos.Dependency
{
    public interface IDependencyProxyRegister : IDisposable
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="descriptor"></param>
        void Register(DependencyProxyDescriptor descriptor);

        /// <summary>
        /// Try register
        /// </summary>
        /// <param name="descriptor"></param>
        void TryRegister(DependencyProxyDescriptor descriptor);

        /// <summary>
        /// Is registered
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IsRegistered(Type type);

        /// <summary>
        /// Is registered
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool IsRegistered<T>();

        /// <summary>
        /// Is registered
        /// </summary>
        /// <param name="type"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        bool IsRegistered(Type type, DependencyLifetimeType lifetimeType);

        /// <summary>
        /// Is registered
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        bool IsRegistered<T>(DependencyLifetimeType lifetimeType);
    }
}