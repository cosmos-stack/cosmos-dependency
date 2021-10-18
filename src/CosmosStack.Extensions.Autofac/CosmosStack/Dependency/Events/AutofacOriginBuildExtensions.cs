using Autofac;
using Autofac.Features.Variance;

namespace CosmosStack.Dependency.Events
{
    /// <summary>
    /// Autofac Original Building Extensions
    /// </summary>
    public static class AutofacOriginBuildExtensions
    {
        /// <summary>
        /// Register IoC Eventing Support
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ContainerBuilder RegisterIocEventing(this ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterType<AutofacEventPublisher>().AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();
            return builder;
        }

        /// <summary>
        /// Register IoC Event Message Support
        /// </summary>
        /// <param name="builder"></param>
        /// <typeparam name="THandle"></typeparam>
        /// <typeparam name="TMessage"></typeparam>
        /// <returns></returns>
        public static ContainerBuilder RegisterIocEventMessage<THandle, TMessage>(this ContainerBuilder builder) where THandle : class, IHandleEvent<TMessage>
        {
            builder.RegisterType<THandle>().As<IHandleEvent<TMessage>>().InstancePerLifetimeScope();
            return builder;
        }
    }
}