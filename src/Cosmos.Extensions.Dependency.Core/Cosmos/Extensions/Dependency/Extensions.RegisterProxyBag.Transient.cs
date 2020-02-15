using System;
using Cosmos.Extensions.Dependency.Core;

namespace Cosmos.Extensions.Dependency {
    /// <summary>
    /// Extensions for Register proxy bag
    /// </summary>
    public static partial class RegisterProxyBagExtensions {
        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddTransient<TService, TImplementation>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TImplementation>(DependencyLifetimeType.Transient));
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
        public static DependencyProxyRegister AddTransient<TService, TImplementation>(this DependencyProxyRegister bag, TImplementation implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementation, DependencyLifetimeType.Transient));
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
        public static DependencyProxyRegister AddTransient<TService, TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddTransient<TService, TResolver, TImplementation>(this DependencyProxyRegister bag,
            Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TResolver, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddTransient<TService>(this DependencyProxyRegister bag, TService implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService>(implementation, DependencyLifetimeType.Transient));
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
        public static DependencyProxyRegister AddTransient<TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Transient));
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
        public static DependencyProxyRegister AddTransient<TService>(this DependencyProxyRegister bag, Func<object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService>(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddTransient<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, TService> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TResolver>(resolver => implementationFunc(resolver), DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddTransient<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TResolver>(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddTransient<TResolver, TImplementation>(this DependencyProxyRegister bag, Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddTransient<TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddTransient<TService>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService>(DependencyLifetimeType.Transient));
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
        public static DependencyProxyRegister AddTransient(this DependencyProxyRegister bag, Type serviceType, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create(serviceType, implementationType, DependencyLifetimeType.Transient));
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
        public static DependencyProxyRegister AddTransient(this DependencyProxyRegister bag, object implementation, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create(implementation, implementationType, DependencyLifetimeType.Transient));
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
        public static DependencyProxyRegister AddTransient(this DependencyProxyRegister bag, Func<object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService, TImplementation>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TImplementation>(DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService, TImplementation>(this DependencyProxyRegister bag, TImplementation implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementation, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService, TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister TryAddTransient<TService, TResolver, TImplementation>(this DependencyProxyRegister bag,
            Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TResolver, TImplementation>(implementationFunc, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService>(this DependencyProxyRegister bag, TService implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService>(implementation, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService>(this DependencyProxyRegister bag, Func<object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService>(implementationFunc, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, TService> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TResolver>(resolver => implementationFunc(resolver), DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TResolver>(implementationFunc, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TResolver, TImplementation>(this DependencyProxyRegister bag, Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient<TService>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService>(DependencyLifetimeType.Transient));
        }
        
        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister TryAddTransient(this DependencyProxyRegister bag, Type serviceType, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create(serviceType, implementationType, DependencyLifetimeType.Transient));
            return bag;
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient(this DependencyProxyRegister bag, object implementation, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementation, implementationType, DependencyLifetimeType.Transient));
        }

        /// <summary>
        /// Try add Transient
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddTransient(this DependencyProxyRegister bag, Func<object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Transient));
        }
    }
}