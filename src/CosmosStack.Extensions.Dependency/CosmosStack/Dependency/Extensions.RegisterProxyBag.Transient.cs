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
            bag.Register(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForType(serviceType, implementationType, DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForObject(implementation, implementationType, DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForService<TService>(implementation, DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Transient));
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
            bag.Register(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForType(serviceType, implementationType, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForObject(implementation, implementationType, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForService<TService>(implementation, DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Transient));
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
            bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Transient));
        }

        #endregion
    }
}