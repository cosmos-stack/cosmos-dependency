using Autofac;
using Autofac.Builder;
using Autofac.Features.Variance;

namespace Cosmos.Dependency.Events
{
    public static class AutofacOriginBuildExtensions
    {
        public static ContainerBuilder RegisterIocEventing(this ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterType<AutofacEventPublisher>().AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();
            return builder;
        }


        public static ContainerBuilder ContainerBuilder<THandle, TMessage>(this ContainerBuilder builder) where THandle : class, IHandleEvent<TMessage>
        {
            builder.RegisterType<THandle>().As<IHandleEvent<TMessage>>().InstancePerLifetimeScope();
            return builder;
        }
    }
}