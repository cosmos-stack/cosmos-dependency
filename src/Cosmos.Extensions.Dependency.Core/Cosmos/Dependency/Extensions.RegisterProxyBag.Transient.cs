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
        #region Add Transient

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient<TService, TImplementation>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForService<TService, TImplementation>(DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient<TService, TImplementation>(this R bag, TImplementation implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient<TService, TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient<TService, TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient<TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient<TService>(this R bag, Func<object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient<TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient(this R bag, Func<IDefinedResolver, object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TImplementationSelf"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient<TImplementationSelf>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient(this R bag, Type serviceType, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForType(serviceType, implementationType, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient(this R bag, object implementation, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForObject(implementation, implementationType, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransient(this R bag, Func<object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Transient));
            return bag;
        }

        #endregion

        #region Add Transient Service

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransientService<TService>(this R bag, TService implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.Register(D.CreateForService<TService>(implementation, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransientService<TService>(this R bag, Func<IDefinedResolver, TService> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static R AddTransientService<TService>(this R bag, Func<IDefinedResolver, object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.Register(D.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        #endregion

        #region Try Add Transient

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService, TImplementation>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForService<TService, TImplementation>(DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService, TImplementation>(this R bag, TImplementation implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService, TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService, TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TImplementation>(this R bag, Func<TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService>(this R bag, Func<object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient(this R bag, Func<IDefinedResolver, object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TImplementationSelf"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TImplementationSelf>(this R bag)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient(this R bag, Type serviceType, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForType(serviceType, implementationType, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient(this R bag, object implementation, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForObject(implementation, implementationType, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient(this R bag, Func<object> implementationFunc, Type implementationType)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Transient));
        }

        #endregion

        #region Try Add Transient Service

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransientService<TService>(this R bag, TService implementation)
        {
            bag.CheckNull(nameof(bag));
            bag.TryRegister(D.CreateForService<TService>(implementation, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransientService<TService>(this R bag, Func<IDefinedResolver, TService> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransientService<TService>(this R bag, Func<IDefinedResolver, object> implementationFunc)
        {
            bag.CheckNull(nameof(bag));
            implementationFunc.CheckNull(nameof(implementationFunc));
            bag.TryRegister(D.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Transient));
        }

        #endregion
    }
}