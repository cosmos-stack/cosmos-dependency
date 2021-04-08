using System;
using Cosmos.Dependency;
// ReSharper disable UnusedTypeParameter

namespace AspectCore.DependencyInjection
{
    /// <summary>
    /// Extensions for NCC AspectCore
    /// </summary>
    public static class FluentAspectCoreInjectorExtensions
    {
        /// <summary>
        /// Begin register
        /// </summary>
        /// <param name="services"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static DependencyProxyRegister<IServiceContext> BeginTypedRegister<TService>(this TService services)
            where TService : IServiceContext
        {
            return new AspectCoreProxyRegister(services);
        }

        /// <summary>
        /// Begin register
        /// </summary>
        /// <param name="services"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static DependencyProxyRegister BeginRegister<TService>(this TService services)
            where TService : IServiceContext
        {
            return services.BeginTypedRegister();
        }

        /// <summary>
        /// End register
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public static IServiceContext Finish(this DependencyProxyRegister<IServiceContext> register)
        {
            using (register)
            {
                return register.RawServices;
            }
        }

        /// <summary>
        /// End register
        /// </summary>
        /// <param name="register"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IServiceContext Finish<TService>(this DependencyProxyRegister register)
            where TService : IServiceContext
        {
            if (register is DependencyProxyRegister<IServiceContext> typedRegister)
            {
                typedRegister.Finish();
            }

            throw new ArgumentException("Cannot convert register to 'DependencyProxyRegister<IServiceContext>'.");
        }
    }
}