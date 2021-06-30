using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Dependency.Events
{
    public static class MicrosoftOriginBuildExtensions
    {
        public static IServiceCollection AddIocEventing(this IServiceCollection services)
        {
            services.AddScoped<IEventPublisher, MicrosoftEventPublisher>();
            services.AddScoped<IAsyncEventPublisher, MicrosoftEventPublisher>();
            return services;
        }

        public static IServiceCollection AddIocEventMessage<THandle, TMessage>(this IServiceCollection services) where THandle : class, IHandleEvent<TMessage>
        {
            services.AddScoped<IHandleEvent<TMessage>, THandle>();
            return services;
        }
    }
}