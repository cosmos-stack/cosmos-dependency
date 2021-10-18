using System;
using R = CosmosStack.Dependency.DependencyProxyRegister;

namespace CosmosStack.Dependency
{
    /// <summary>
    /// Extensions for Register proxy bag <br />
    /// 注册包扩展
    /// </summary>
    public static partial class RegisterProxyBagExtensions
    {
        #region Add Singleton

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton<TService, TImplementation>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton<TService, TImplementation>(this R bag, TImplementation implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton<TService, TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(DependencyProxyDescriptor.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton<TService, TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton<TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(DependencyProxyDescriptor.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton<TService>(this R bag, Func<object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(DependencyProxyDescriptor.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton<TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(DependencyProxyDescriptor.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton(this R bag, Func<IDefinedResolver, object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(DependencyProxyDescriptor.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TImplementationSelf"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton<TImplementationSelf>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(DependencyProxyDescriptor.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton(this R bag, Type serviceType, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(DependencyProxyDescriptor.CreateForType(serviceType, implementationType, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton(this R bag, object implementation, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(DependencyProxyDescriptor.CreateForObject(implementation, implementationType, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingleton(this R bag, Func<object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(DependencyProxyDescriptor.CreateForInstanceDelegate(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
            return bag;
        }

        #endregion

        #region Add Singleton Service

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingletonService<TService>(this R bag, TService implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(DependencyProxyDescriptor.CreateForService<TService>(implementation, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingletonService<TService>(this R bag, Func<IDefinedResolver, TService> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddSingletonService<TService>(this R bag, Func<IDefinedResolver, object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        #endregion

        #region Try Add Singleton

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService, TImplementation>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService, TImplementation>(this R bag, TImplementation implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService, TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(DependencyProxyDescriptor.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService, TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(DependencyProxyDescriptor.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService>(this R bag, Func<object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(DependencyProxyDescriptor.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton(this R bag, Func<IDefinedResolver, object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TImplementationSelf"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TImplementationSelf>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(DependencyProxyDescriptor.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton(this R bag, Type serviceType, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(DependencyProxyDescriptor.CreateForType(serviceType, implementationType, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton(this R bag, object implementation, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(DependencyProxyDescriptor.CreateForObject(implementation, implementationType, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton(this R bag, Func<object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(DependencyProxyDescriptor.CreateForObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
        }

        #endregion

        #region Try Add Singleton Service

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingletonService<TService>(this R bag, TService implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(DependencyProxyDescriptor.CreateForService<TService>(implementation, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingletonService<TService>(this R bag, Func<IDefinedResolver, TService> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingletonService<TService>(this R bag, Func<IDefinedResolver, object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Singleton));
        }

        #endregion
    }
}