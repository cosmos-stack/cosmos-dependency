using System;
using Cosmos.Extensions.Dependency.Core;

namespace Cosmos.Extensions.Dependency {
    /// <summary>
    /// Extensions for Register proxy bag
    /// </summary>
    public static partial class RegisterProxyBagExtensions {
        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddSingleton<TService, TImplementation>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TImplementation>(DependencyLifetimeType.Singleton));
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
        public static DependencyProxyRegister AddSingleton<TService, TImplementation>(this DependencyProxyRegister bag, TImplementation implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementation, DependencyLifetimeType.Singleton));
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
        public static DependencyProxyRegister AddSingleton<TService, TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddSingleton<TService, TResolver, TImplementation>(this DependencyProxyRegister bag,
            Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TResolver, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddSingleton<TService>(this DependencyProxyRegister bag, TService implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService>(implementation, DependencyLifetimeType.Singleton));
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
        public static DependencyProxyRegister AddSingleton<TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Singleton));
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
        public static DependencyProxyRegister AddSingleton<TService>(this DependencyProxyRegister bag, Func<object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService>(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddSingleton<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, TService> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TResolver>(resolver => implementationFunc(resolver), DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddSingleton<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TResolver>(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddSingleton<TResolver, TImplementation>(this DependencyProxyRegister bag, Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddSingleton<TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Add singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddSingleton<TService>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService>(DependencyLifetimeType.Singleton));
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
        public static DependencyProxyRegister AddSingleton(this DependencyProxyRegister bag, Type serviceType, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create(serviceType, implementationType, DependencyLifetimeType.Singleton));
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
        public static DependencyProxyRegister AddSingleton(this DependencyProxyRegister bag, object implementation, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create(implementation, implementationType, DependencyLifetimeType.Singleton));
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
        public static DependencyProxyRegister AddSingleton(this DependencyProxyRegister bag, Func<object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService, TImplementation>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TImplementation>(DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService, TImplementation>(this DependencyProxyRegister bag, TImplementation implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementation, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService, TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister TryAddSingleton<TService, TResolver, TImplementation>(this DependencyProxyRegister bag,
            Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TResolver, TImplementation>(implementationFunc, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService>(this DependencyProxyRegister bag, TService implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService>(implementation, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService>(this DependencyProxyRegister bag, Func<object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService>(implementationFunc, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, TService> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TResolver>(resolver => implementationFunc(resolver), DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TResolver>(implementationFunc, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TResolver, TImplementation>(this DependencyProxyRegister bag, Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton<TService>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService>(DependencyLifetimeType.Singleton));
        }
        
        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister TryAddSingleton(this DependencyProxyRegister bag, Type serviceType, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create(serviceType, implementationType, DependencyLifetimeType.Singleton));
            return bag;
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton(this DependencyProxyRegister bag, object implementation, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementation, implementationType, DependencyLifetimeType.Singleton));
        }

        /// <summary>
        /// Try add Singleton
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddSingleton(this DependencyProxyRegister bag, Func<object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Singleton));
        }
    }
}