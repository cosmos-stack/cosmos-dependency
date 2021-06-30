using System;
using Cosmos;
using Cosmos.Dependency;

namespace AspectCore.DependencyInjection
{
    /// <summary>
    /// Extensions for NCC AspectCore
    /// </summary>
    public static class AspectCoreInjectorExtensions
    {
        /// <summary>
        /// Register Proxy
        /// </summary>
        /// <param name="services"></param>
        /// <param name="bag"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceContext RegisterProxyFrom(this IServiceContext services, DependencyProxyRegister bag)
        {
            services.CheckNull(nameof(services));

            if (bag is not null)
            {
                var descriptors = bag.ExportDescriptors();

                foreach (var descriptor in descriptors)
                {
                    switch (descriptor.ProxyType)
                    {
                        case DependencyProxyType.TypeToType:
                            TypeToTypeRegister(services, descriptor);
                            break;

                        case DependencyProxyType.TypeToInstance:
                            TypeToInstanceRegister(services, descriptor);
                            break;

                        case DependencyProxyType.TypeToInstanceFunc:
                            TypeToInstanceFuncRegister(services, descriptor);
                            break;

                        case DependencyProxyType.TypeSelf:
                            TypeSelfRegister(services, descriptor);
                            break;

                        case DependencyProxyType.InstanceSelf:
                            InstanceSelfRegister(services, descriptor);
                            break;

                        case DependencyProxyType.InstanceSelfFunc:
                            InstanceSelfFuncRegister(services, descriptor);
                            break;

                        case DependencyProxyType.TypeToResolvedInstanceFunc:
                            TypeToResolvedInstanceFuncRegister(services, descriptor);
                            break;

                        case DependencyProxyType.ResolvedInstanceSelfFunc:
                            ResolvedInstanceSelfFuncRegister(services, descriptor);
                            break;

                        case DependencyProxyType.CustomUnsafeDelegate:
                            WorkForCustomUnsafeDelegate(services, descriptor);
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            return services;
        }

        private static void TypeToTypeRegister(IServiceContext services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            services.AddType(d.ServiceType, d.ImplementationType, lifetime);
        }

        private static void TypeToInstanceRegister(IServiceContext services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            switch (lifetime)
            {
                case Lifetime.Singleton:
                    services.AddInstance(d.ServiceType, d.InstanceOfImplementation);
                    break;

                default:
                    throw new InvalidOperationException("Invalid operation for scoped or Transient mode.");
            }
        }

        private static void TypeToInstanceFuncRegister(IServiceContext services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            services.AddDelegate(d.ServiceType, r => d.InstanceFuncForImplementation(), lifetime);
        }

        private static void TypeSelfRegister(IServiceContext services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            services.AddType(d.ImplementationTypeSelf, lifetime);
        }

        private static void InstanceSelfRegister(IServiceContext services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            switch (lifetime)
            {
                case Lifetime.Singleton:
                    services.AddInstance(d.InstanceOfImplementation);
                    break;

                default:
                    throw new InvalidOperationException("Invalid operation for scoped or Transient mode.");
            }
        }

        private static void InstanceSelfFuncRegister(IServiceContext services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            switch (lifetime)
            {
                case Lifetime.Scoped:
                    services.AddDelegate(r => d.InstanceFuncForImplementation(), Lifetime.Scoped);
                    break;

                case Lifetime.Singleton:
                    services.AddDelegate(r => d.InstanceFuncForImplementation(), Lifetime.Singleton);
                    break;

                case Lifetime.Transient:
                    services.AddDelegate(r => d.InstanceFuncForImplementation());
                    break;

                default:
                    services.AddDelegate(r => d.InstanceFuncForImplementation());
                    break;
            }
        }

        private static void TypeToResolvedInstanceFuncRegister(IServiceContext services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            switch (lifetime)
            {
                case Lifetime.Scoped:
                    services.AddDelegate(d.ServiceType, p => d.ResolveFuncForImplementation(p.ToAbstract()), Lifetime.Scoped);
                    break;

                case Lifetime.Singleton:
                    services.AddDelegate(d.ServiceType, p => d.ResolveFuncForImplementation(p.ToAbstract()), Lifetime.Singleton);
                    break;

                case Lifetime.Transient:
                    services.AddDelegate(d.ServiceType, p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;

                default:
                    services.AddDelegate(d.ServiceType, p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;
            }
        }

        private static void ResolvedInstanceSelfFuncRegister(IServiceContext services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToAspectCoreLifetime();
            switch (lifetime)
            {
                case Lifetime.Scoped:
                    services.AddDelegate(p => d.ResolveFuncForImplementation(p.ToAbstract()), Lifetime.Scoped);
                    break;
                case Lifetime.Singleton:
                    services.AddDelegate(p => d.ResolveFuncForImplementation(p.ToAbstract()), Lifetime.Singleton);
                    break;
                case Lifetime.Transient:
                    services.AddDelegate(p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;

                default:
                    services.AddDelegate(p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;
            }
        }

        private static void WorkForCustomUnsafeDelegate(IServiceContext services, DependencyProxyDescriptor d)
        {
            d.CustomUnsafeDelegate?.Invoke(services);
        }
    }
}