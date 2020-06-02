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
        #region Add Scoped

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped<TService, TImplementation>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForService<TService, TImplementation>(DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped<TService, TImplementation>(this R bag, TImplementation implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped<TService, TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped<TService, TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped<TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped<TService>(this R bag, Func<object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped<TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped(this R bag, Func<IDefinedResolver, object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TImplementationSelf"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped<TImplementationSelf>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped(this R bag, Type serviceType, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForType(serviceType, implementationType, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped(this R bag, object implementation, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForObject(implementation, implementationType, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScoped(this R bag, Func<object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
            return bag;
        }

        #endregion

        #region Add Scoped Service

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScopedService<TService>(this R bag, TService implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForService<TService>(implementation, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScopedService<TService>(this R bag, Func<IDefinedResolver, TService> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddScopedService<TService>(this R bag, Func<IDefinedResolver, object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        #endregion

        #region Try Add Scoped

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService, TImplementation>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForService<TService, TImplementation>(DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService, TImplementation>(this R bag, TImplementation implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService, TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R TryAddScoped<TService, TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService>(this R bag, Func<object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TImplementationSelf"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TImplementationSelf>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped(this R bag, Func<IDefinedResolver, object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped(this R bag, Type serviceType, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForType(serviceType, implementationType, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped(this R bag, object implementation, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForObject(implementation, implementationType, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped(this R bag, Func<object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
        }

        #endregion

        #region Try Add Scoped Service

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScopedService<TService>(this R bag, TService implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForService<TService>(implementation, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScopedService<TService>(this R bag, Func<IDefinedResolver, TService> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScopedService<TService>(this R bag, Func<IDefinedResolver, object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Scoped));
        }

        #endregion
    }
}