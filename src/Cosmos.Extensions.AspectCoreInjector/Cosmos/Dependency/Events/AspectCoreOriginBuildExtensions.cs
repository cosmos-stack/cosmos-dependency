using AspectCore.DependencyInjection;

namespace Cosmos.Dependency.Events;

/// <summary>
/// AspectCore Original building extensions
/// </summary>
public static class AspectCoreOriginBuildExtensions
{
    /// <summary>
    /// Add IoC Eventing Support
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceContext AddIocEventing(this IServiceContext services)
    {
        services.AddType<IEventPublisher, AspectCoreEventPublisher>(Lifetime.Scoped);
        services.AddType<IAsyncEventPublisher, AspectCoreEventPublisher>(Lifetime.Scoped);
        return services;
    }

    /// <summary>
    /// Add IoC Eventing Message Support
    /// </summary>
    /// <param name="services"></param>
    /// <typeparam name="THandle"></typeparam>
    /// <typeparam name="TMessage"></typeparam>
    /// <returns></returns>
    public static IServiceContext AddIocEventMessage<THandle, TMessage>(this IServiceContext services) where THandle : class, IHandleEvent<TMessage>
    {
        services.AddType<IHandleEvent<TMessage>, THandle>(Lifetime.Scoped);
        return services;
    }
}