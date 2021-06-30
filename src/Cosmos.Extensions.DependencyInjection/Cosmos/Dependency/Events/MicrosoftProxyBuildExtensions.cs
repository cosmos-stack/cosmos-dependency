namespace Cosmos.Dependency.Events
{
    public static class MicrosoftProxyBuildExtensions
    {
        public static MicrosoftProxyRegister AddIocEventService(this MicrosoftProxyRegister register)
        {
            register.AddScoped<IEventPublisher, MicrosoftEventPublisher>();
            register.AddScoped<IAsyncEventPublisher, MicrosoftEventPublisher>();
            return register;
        }
        
        public static MicrosoftProxyRegister AddIocEventHandle<THandle, TMessage>(this MicrosoftProxyRegister register) where THandle : class, IHandleEvent<TMessage>
        {
            register.AddScoped<IHandleEvent<TMessage>, THandle>();
            return register;
        }
    }
}