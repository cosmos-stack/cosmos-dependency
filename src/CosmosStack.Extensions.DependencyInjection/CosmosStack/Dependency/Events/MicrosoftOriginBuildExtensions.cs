using Microsoft.Extensions.DependencyInjection;

namespace CosmosStack.Dependency.Events
{
    /// <summary>
    /// Microsoft Dependency Injection Original Building Extensions
    /// </summary>
    public static class MicrosoftOriginBuildExtensions
    {
        /// <summary>
        /// Add IoC Eventing Support
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddIocEventing(this IServiceCollection services)
        {
            services.AddScoped<IEventPublisher, MicrosoftEventPublisher>();
            services.AddScoped<IAsyncEventPublisher, MicrosoftEventPublisher>();
            return services;
        }

        /// <summary>
        /// Add IoC Eventing Message Support
        /// </summary>
        /// <param name="services"></param>
        /// <typeparam name="THandle"></typeparam>
        /// <typeparam name="TMessage"></typeparam>
        /// <returns></returns>
        public static IServiceCollection AddIocEventMessage<THandle, TMessage>(this IServiceCollection services) where THandle : class, IHandleEvent<TMessage>
        {
            services.AddScoped<IHandleEvent<TMessage>, THandle>();
            return services;
        }
    }
}