using System;

namespace Cosmos.Dependency
{
    /// <summary>
    /// Register proxy descriptor
    /// </summary>
    public class DependencyRegisterDescriptor
    {
        internal Type RegisterType { get; set; }

        /// <summary>
        /// Service type
        /// </summary>
        public Type ServiceType { get; set; }

        /// <summary>
        /// Implementation type
        /// </summary>
        public Type ImplementationType { get; set; }

        /// <summary>
        /// Implementation type self
        /// </summary>
        public Type ImplementationTypeSelf { get; set; }

        /// <summary>
        /// Instance of implementation
        /// </summary>
        public object InstanceOfImplementation { get; set; }

        /// <summary>
        /// Instance func for implementation
        /// </summary>
        public Func<object> InstanceFuncForImplementation { get; set; }

        /// <summary>
        /// Instance func for implementation
        /// </summary>
        public Func<IDefinedResolver, object> ResolveFuncForImplementation { get; set; }

        /// <summary>
        /// Proxy type
        /// </summary>
        public DependencyProxyType ProxyType { get; set; }

        /// <summary>
        /// Lifetime type
        /// </summary>
        public DependencyLifetimeType LifetimeType { get; set; }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForService<TService, TImplementation>(DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = typeof(TService),
                ServiceType = typeof(TService),
                ImplementationType = typeof(TImplementation),
                ProxyType = DependencyProxyType.TypeToType,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="instance"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForService<TService, TImplementation>(TImplementation instance, DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = typeof(TService),
                ServiceType = typeof(TService),
                InstanceOfImplementation = instance,
                ProxyType = DependencyProxyType.TypeToInstance,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="instance"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForService<TService>(object instance, DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = typeof(TService),
                ServiceType = typeof(TService),
                InstanceOfImplementation = instance,
                ProxyType = DependencyProxyType.TypeToInstance,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TImplementationSelf"></typeparam>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = typeof(TImplementationSelf),
                ImplementationTypeSelf = typeof(TImplementationSelf),
                ProxyType = DependencyProxyType.TypeSelf,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForType(Type serviceType, Type implementationType, DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = serviceType,
                ServiceType = serviceType,
                ImplementationType = implementationType,
                ProxyType = DependencyProxyType.TypeToType,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="implementationType"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForObject(object instance, Type implementationType, DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = implementationType,
                InstanceOfImplementation = instance,
                ProxyType = DependencyProxyType.InstanceSelf,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="instanceFunc"></param>
        /// <param name="implementationType"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForObjectDelegate(Func<object> instanceFunc, Type implementationType, DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = implementationType,
                InstanceFuncForImplementation = instanceFunc,
                ProxyType = DependencyProxyType.TypeToInstanceFunc,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="instanceFunc"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForServiceDelegate<TService, TImplementation>(Func<TImplementation> instanceFunc, DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = typeof(TService),
                ServiceType = typeof(TService),
                ImplementationType = typeof(TImplementation),
                InstanceFuncForImplementation = () => instanceFunc(),
                ProxyType = DependencyProxyType.TypeToInstanceFunc,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="instanceFunc"></param>
        /// <param name="lifetimeType"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForResolvedServiceDelegate<TService, TImplementation>(Func<IDefinedResolver, TImplementation> instanceFunc,
            DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = typeof(TService),
                ServiceType = typeof(TService),
                ImplementationType = typeof(TImplementation),
                ResolveFuncForImplementation = resolver => instanceFunc(resolver),
                ProxyType = DependencyProxyType.TypeToResolvedInstanceFunc,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="instanceFunc"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForServiceDelegate<TService>(Func<object> instanceFunc, DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = typeof(TService),
                ServiceType = typeof(TService),
                InstanceFuncForImplementation = instanceFunc,
                ProxyType = DependencyProxyType.TypeToInstanceFunc,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="instanceFunc"></param>
        /// <param name="lifetimeType"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForResolvedServiceDelegate<TService>(Func<IDefinedResolver, object> instanceFunc, DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = typeof(TService),
                ServiceType = typeof(TService),
                ResolveFuncForImplementation = instanceFunc,
                ProxyType = DependencyProxyType.TypeToResolvedInstanceFunc,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="instanceFunc"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForInstanceDelegate<TImplementation>(Func<TImplementation> instanceFunc, DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = typeof(TImplementation),
                ImplementationTypeSelf = typeof(TImplementation),
                InstanceFuncForImplementation = () => instanceFunc(),
                ProxyType = DependencyProxyType.InstanceSelfFunc,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="instanceFunc"></param>
        /// <param name="lifetimeType"></param>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForResolvedInstanceDelegate<TImplementation>(Func<IDefinedResolver, TImplementation> instanceFunc,
            DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = typeof(TImplementation),
                ImplementationTypeSelf = typeof(TImplementation),
                ResolveFuncForImplementation = resolver => instanceFunc(resolver),
                ProxyType = DependencyProxyType.ResolvedInstanceSelfFunc,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="instanceFunc"></param>
        /// <param name="implementationType"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForInstanceDelegate(Func<object> instanceFunc, Type implementationType, DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = implementationType,
                InstanceFuncForImplementation = instanceFunc,
                ProxyType = DependencyProxyType.InstanceSelfFunc,
                LifetimeType = lifetimeType
            };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="instanceFunc"></param>
        /// <param name="implementationType"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public static DependencyRegisterDescriptor CreateForResolvedObjectDelegate(Func<IDefinedResolver, object> instanceFunc, Type implementationType,
            DependencyLifetimeType lifetimeType)
        {
            return new DependencyRegisterDescriptor
            {
                RegisterType = implementationType,
                ResolveFuncForImplementation = instanceFunc,
                ProxyType = DependencyProxyType.ResolvedInstanceSelfFunc,
                LifetimeType = lifetimeType
            };
        }
    }
}