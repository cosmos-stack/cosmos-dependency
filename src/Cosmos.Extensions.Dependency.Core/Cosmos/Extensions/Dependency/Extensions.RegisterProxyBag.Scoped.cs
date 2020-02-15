using System;
using Cosmos.Extensions.Dependency.Core;

namespace Cosmos.Extensions.Dependency {
    /// <summary>
    /// Extensions for Register proxy bag
    /// </summary>
    public static partial class RegisterProxyBagExtensions {
        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddScoped<TService, TImplementation>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TImplementation>(DependencyLifetimeType.Scoped));
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
        public static DependencyProxyRegister AddScoped<TService, TImplementation>(this DependencyProxyRegister bag, TImplementation implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementation, DependencyLifetimeType.Scoped));
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
        public static DependencyProxyRegister AddScoped<TService, TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister
            AddScoped<TService, TResolver, TImplementation>(this DependencyProxyRegister bag, Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TResolver, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddScoped<TService>(this DependencyProxyRegister bag, TService implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService>(implementation, DependencyLifetimeType.Scoped));
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
        public static DependencyProxyRegister AddScoped<TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Scoped));
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
        public static DependencyProxyRegister AddScoped<TService>(this DependencyProxyRegister bag, Func<object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService>(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddScoped<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, TService> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TResolver>(resolver => implementationFunc(resolver), DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddScoped<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create<TService, TResolver>(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddScoped<TResolver, TImplementation>(this DependencyProxyRegister bag, Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddScoped<TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister AddScoped<TService>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create<TService>(DependencyLifetimeType.Scoped));
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
        public static DependencyProxyRegister AddScoped(this DependencyProxyRegister bag, Type serviceType, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create(serviceType, implementationType, DependencyLifetimeType.Scoped));
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
        public static DependencyProxyRegister AddScoped(this DependencyProxyRegister bag, object implementation, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.Register(DependencyRegisterDescriptor.Create(implementation, implementationType, DependencyLifetimeType.Scoped));
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
        public static DependencyProxyRegister AddScoped(this DependencyProxyRegister bag, Func<object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.Register(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService, TImplementation>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TImplementation>(DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService, TImplementation>(this DependencyProxyRegister bag, TImplementation implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementation, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService, TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister TryAddScoped<TService, TResolver, TImplementation>(this DependencyProxyRegister bag,
            Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TResolver, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService>(this DependencyProxyRegister bag, TService implementation) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService>(implementation, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TImplementation>(this DependencyProxyRegister bag, Func<TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService>(this DependencyProxyRegister bag, Func<object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService>(implementationFunc, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <typeparam name="TService"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService>(this DependencyProxyRegister bag) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService>(DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, TService> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TResolver>(resolver => implementationFunc(resolver), DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TResolver"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TService, TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create<TService, TResolver>(implementationFunc, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TResolver, TImplementation>(this DependencyProxyRegister bag, Func<TResolver, TImplementation> implementationFunc) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <typeparam name="TResolver"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped<TResolver>(this DependencyProxyRegister bag, Func<TResolver, object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
        }
        
        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DependencyProxyRegister TryAddScoped(this DependencyProxyRegister bag, Type serviceType, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create(serviceType, implementationType, DependencyLifetimeType.Scoped));
            return bag;
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementation"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped(this DependencyProxyRegister bag, object implementation, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementation, implementationType, DependencyLifetimeType.Scoped));
        }

        /// <summary>
        /// Try add Scoped
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="implementationFunc"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryAddScoped(this DependencyProxyRegister bag, Func<object> implementationFunc, Type implementationType) {
            if (bag is null) throw new ArgumentNullException(nameof(bag));
            if (implementationFunc is null) throw new ArgumentNullException(nameof(implementationFunc));
            bag.TryRegister(DependencyRegisterDescriptor.Create(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
        }
    }
}