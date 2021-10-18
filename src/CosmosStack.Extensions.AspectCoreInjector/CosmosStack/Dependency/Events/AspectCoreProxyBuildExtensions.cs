namespace CosmosStack.Dependency.Events
{
    /// <summary>
    /// AspectCore Proxy Building Extensions
    /// </summary>
    public static class AspectCoreProxyBuildExtensions
    {
        /// <summary>
        /// Add IoC Event Service Support
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public static AspectCoreProxyRegister AddIocEventService(this AspectCoreProxyRegister register)
        {
            register.AddScoped<IEventPublisher, AspectCoreEventPublisher>();
            register.AddScoped<IAsyncEventPublisher, AspectCoreEventPublisher>();
            return register;
        }

        /// <summary>
        /// Add IoC Event Handle
        /// </summary>
        /// <param name="register"></param>
        /// <typeparam name="THandle"></typeparam>
        /// <typeparam name="TMessage"></typeparam>
        /// <returns></returns>
        public static AspectCoreProxyRegister AddIocEventHandle<THandle, TMessage>(this AspectCoreProxyRegister register) where THandle : class, IHandleEvent<TMessage>
        {
            register.AddScoped<IHandleEvent<TMessage>, THandle>();
            return register;
        }
    }
}