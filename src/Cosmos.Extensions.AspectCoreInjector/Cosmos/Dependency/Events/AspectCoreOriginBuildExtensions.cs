using AspectCore.DependencyInjection;

namespace Cosmos.Dependency.Events
{
    public static class AspectCoreOriginBuildExtensions
    {
        public static IServiceContext AddIocEventing(this IServiceContext services)
        {
            services.AddType<IEventPublisher, AspectCoreEventPublisher>(Lifetime.Scoped);
            services.AddType<IAsyncEventPublisher, AspectCoreEventPublisher>(Lifetime.Scoped);
            return services;
        }

        public static IServiceContext AddIocEventMessage<THandle, TMessage>(this IServiceContext services) where THandle : class, IHandleEvent<TMessage>
        {
            services.AddType<IHandleEvent<TMessage>, THandle>(Lifetime.Scoped);
            return services;
        }
    }
}