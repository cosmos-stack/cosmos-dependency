using System;
using CosmosStack.Dependency;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions for Dependency Injection
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Add Register Proxy
        /// </summary>
        /// <param name="services"></param>
        /// <param name="bag"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddRegisterProxyFrom(this IServiceCollection services, DependencyProxyRegister bag)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

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

        private static void TypeToTypeRegister(IServiceCollection services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime)
            {
                case ServiceLifetime.Scoped:
                    services.AddScoped(d.ServiceType, d.ImplementationType);
                    break;

                case ServiceLifetime.Singleton:
                    services.AddSingleton(d.ServiceType, d.ImplementationType);
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(d.ServiceType, d.ImplementationType);
                    break;

                default:
                    services.AddTransient(d.ServiceType, d.ImplementationType);
                    break;
            }
        }

        private static void TypeToInstanceRegister(IServiceCollection services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(d.ServiceType, d.InstanceOfImplementation);
                    break;

                default:
                    throw new InvalidOperationException("Invalid operation for scoped or Transient mode.");
            }
        }

        private static void TypeToInstanceFuncRegister(IServiceCollection services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime)
            {
                case ServiceLifetime.Scoped:
                    services.AddScoped(d.ServiceType, p => d.InstanceFuncForImplementation());
                    break;

                case ServiceLifetime.Singleton:
                    services.AddSingleton(d.ServiceType, p => d.InstanceFuncForImplementation());
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(d.ServiceType, p => d.InstanceFuncForImplementation());
                    break;

                default:
                    services.AddTransient(d.ServiceType, p => d.InstanceFuncForImplementation());
                    break;
            }
        }

        private static void TypeSelfRegister(IServiceCollection services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime)
            {
                case ServiceLifetime.Scoped:
                    services.AddScoped(d.ImplementationTypeSelf);
                    break;

                case ServiceLifetime.Singleton:
                    services.AddSingleton(d.ImplementationTypeSelf);
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(d.ImplementationTypeSelf);
                    break;

                default:
                    services.AddTransient(d.ImplementationTypeSelf);
                    break;
            }
        }

        private static void InstanceSelfRegister(IServiceCollection services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(d.InstanceOfImplementation);
                    break;

                default:
                    throw new InvalidOperationException("Invalid operation for scoped or Transient mode.");
            }
        }

        private static void InstanceSelfFuncRegister(IServiceCollection services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime)
            {
                case ServiceLifetime.Scoped:
                    services.AddScoped(p => d.InstanceFuncForImplementation());
                    break;

                case ServiceLifetime.Singleton:
                    services.AddSingleton(p => d.InstanceFuncForImplementation());
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(p => d.InstanceFuncForImplementation());
                    break;

                default:
                    services.AddTransient(p => d.InstanceFuncForImplementation());
                    break;
            }
        }

        private static void TypeToResolvedInstanceFuncRegister(IServiceCollection services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime)
            {
                case ServiceLifetime.Scoped:
                    services.AddScoped(d.ServiceType, p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;

                case ServiceLifetime.Singleton:
                    services.AddSingleton(d.ServiceType, p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(d.ServiceType, p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;

                default:
                    services.AddTransient(d.ServiceType, p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;
            }
        }

        private static void ResolvedInstanceSelfFuncRegister(IServiceCollection services, DependencyProxyDescriptor d)
        {
            var lifetime = d.LifetimeType.ToMsLifetime();
            switch (lifetime)
            {
                case ServiceLifetime.Scoped:
                    services.AddScoped(p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;

                case ServiceLifetime.Singleton:
                    services.AddSingleton(p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;

                default:
                    services.AddTransient(p => d.ResolveFuncForImplementation(p.ToAbstract()));
                    break;
            }
        }

        private static void WorkForCustomUnsafeDelegate(IServiceCollection services, DependencyProxyDescriptor d)
        {
            d.CustomUnsafeDelegate?.Invoke(services);
        }
    }
}