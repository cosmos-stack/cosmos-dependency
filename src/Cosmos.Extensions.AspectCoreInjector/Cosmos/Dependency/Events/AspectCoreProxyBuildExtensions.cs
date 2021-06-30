namespace Cosmos.Dependency.Events
{
    public static class AspectCoreProxyBuildExtensions
    {
        public static AspectCoreProxyRegister AddIocEventService(this AspectCoreProxyRegister register)
        {
            register.AddScoped<IEventPublisher, AspectCoreEventPublisher>();
            register.AddScoped<IAsyncEventPublisher, AspectCoreEventPublisher>();
            return register;
        }

        public static AspectCoreProxyRegister AddIocEventHandle<THandle, TMessage>(this AspectCoreProxyRegister register) where THandle : class, IHandleEvent<TMessage>
        {
            register.AddScoped<IHandleEvent<TMessage>, THandle>();
            return register;
        }
    }
}