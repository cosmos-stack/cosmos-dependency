using System;
using Cosmos.Dependency;

namespace Autofac
{
    /// <summary>
    /// Extensions for Autofac
    /// </summary>
    public static class RegisterTypesExtensions
    {
        /// <summary>
        /// Register Proxy
        /// </summary>
        /// <param name="services"></param>
        /// <param name="bag"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ContainerBuilder RegisterProxyFrom(this ContainerBuilder services, DependencyProxyRegister bag)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (bag != null)
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
                    }
                }
            }

            return services;
        }

        private static void TypeToTypeRegister(ContainerBuilder services, DependencyRegisterDescriptor d)
        {
            var builder = services.RegisterType(d.ImplementationType).As(d.ServiceType);
            switch (d.LifetimeType)
            {
                case DependencyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case DependencyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case DependencyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void TypeToInstanceRegister(ContainerBuilder services, DependencyRegisterDescriptor d)
        {
            var builder = services.RegisterInstance(d.InstanceOfImplementation).As(d.ServiceType);
            switch (d.LifetimeType)
            {
                case DependencyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case DependencyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case DependencyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void TypeToInstanceFuncRegister(ContainerBuilder services, DependencyRegisterDescriptor d)
        {
            var builder = services.Register(c => d.InstanceFuncForImplementation()).As(d.ServiceType);

            switch (d.LifetimeType)
            {
                case DependencyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case DependencyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case DependencyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void TypeSelfRegister(ContainerBuilder services, DependencyRegisterDescriptor d)
        {
            var builder = services.RegisterType(d.ImplementationTypeSelf);
            switch (d.LifetimeType)
            {
                case DependencyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case DependencyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case DependencyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void InstanceSelfRegister(ContainerBuilder services, DependencyRegisterDescriptor d)
        {
            var builder = services.RegisterInstance(d.InstanceOfImplementation);
            switch (d.LifetimeType)
            {
                case DependencyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case DependencyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case DependencyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void InstanceSelfFuncRegister(ContainerBuilder services, DependencyRegisterDescriptor d)
        {
            var builder = services.RegisterInstance(d.InstanceFuncForImplementation());
            switch (d.LifetimeType)
            {
                case DependencyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case DependencyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case DependencyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void TypeToResolvedInstanceFuncRegister(ContainerBuilder services, DependencyRegisterDescriptor d)
        {
            var builder = services.Register(context => d.ResolveFuncForImplementation(context.ToAbstract())).As(d.ServiceType);
            switch (d.LifetimeType)
            {
                case DependencyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case DependencyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case DependencyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }

        private static void ResolvedInstanceSelfFuncRegister(ContainerBuilder services, DependencyRegisterDescriptor d)
        {
            var builder = services.Register(context => d.ResolveFuncForImplementation(context.ToAbstract()));
            switch (d.LifetimeType)
            {
                case DependencyLifetimeType.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;

                case DependencyLifetimeType.Singleton:
                    builder.SingleInstance();
                    break;

                case DependencyLifetimeType.Transient:
                    builder.InstancePerDependency();
                    break;

                default:
                    builder.InstancePerDependency();
                    break;
            }
        }
    }
}