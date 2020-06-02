using System;
using R = Cosmos.Dependency.DependencyProxyRegister;
using D = Cosmos.Dependency.DependencyRegisterDescriptor;

namespace Cosmos.Dependency
{
    /// <summary>
    /// Extensions for Register proxy bag
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
            bag.Register(D.CreateForService<TService, TImplementation>(DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForType(serviceType, implementationType, DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForObject(implementation, implementationType, DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForInstanceDelegate(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForService<TService>(implementation, DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Singleton));
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
            bag.Register(D.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForService<TService, TImplementation>(DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForType(serviceType, implementationType, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForObject(implementation, implementationType, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForService<TService>(implementation, DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Singleton));
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
            bag.TryRegister(D.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Singleton));
        }

        #endregion
    }
}