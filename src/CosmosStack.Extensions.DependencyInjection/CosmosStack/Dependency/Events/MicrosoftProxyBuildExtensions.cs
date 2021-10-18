namespace CosmosStack.Dependency.Events
{
    public static class MicrosoftProxyBuildExtensions
    {
        /// <summary>
        /// Add IoC Event Service Support
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public static MicrosoftProxyRegister AddIocEventService(this MicrosoftProxyRegister register)
        {
            register.AddScoped<IEventPublisher, MicrosoftEventPublisher>();
            register.AddScoped<IAsyncEventPublisher, MicrosoftEventPublisher>();
            return register;
        }
        
        /// <summary>
        /// Add IoC Event Handle
        /// </summary>
        /// <param name="register"></param>
        /// <typeparam name="THandle"></typeparam>
        /// <typeparam name="TMessage"></typeparam>
        /// <returns></returns>
        public static MicrosoftProxyRegister AddIocEventHandle<THandle, TMessage>(this MicrosoftProxyRegister register) where THandle : class, IHandleEvent<TMessage>
        {
            register.AddScoped<IHandleEvent<TMessage>, THandle>();
            return register;
        }
    }
}