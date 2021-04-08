using System;
using Cosmos.Dependency;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions for Dependency Injection
    /// </summary>
    public static class FluentDependencyInjectionExtensions
    {
        /// <summary>
        /// Begin register
        /// </summary>
        /// <param name="services"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static DependencyProxyRegister<IServiceCollection> BeginTypedRegister<TService>(this TService services)
            where TService : IServiceCollection
        {
            return new MicrosoftProxyRegister(services);
        }

        /// <summary>
        /// Begin register
        /// </summary>
        /// <param name="services"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static DependencyProxyRegister BeginRegister<TService>(this TService services)
            where TService : IServiceCollection
        {
            return services.BeginTypedRegister();
        }

        /// <summary>
        /// End register
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public static IServiceCollection Finish(this DependencyProxyRegister<IServiceCollection> register)
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
        public static IServiceCollection Finish<TService>(this DependencyProxyRegister register)
            where TService : IServiceCollection
        {
            if (register is DependencyProxyRegister<IServiceCollection> typedRegister)
            {
                using (typedRegister)
                {
                    return typedRegister.RawServices;
                }
            }

            throw new ArgumentException("Cannot convert register to 'DependencyProxyRegister<IServiceCollection>'.");
        }
    }
}