using Autofac;

namespace CosmosStack.Dependency.Events
{
    /// <summary>
    /// Add IoC Event Service Support
    /// </summary>
    public static class AutofacProxyBuildExtensions
    {
        public static AutofacProxyRegister AddIocEventService(AutofacProxyRegister register)
        {
            DependencyProxyDescriptor.CreateForCustomUnsafeDelegate<ContainerBuilder>(builder =>
            {
                builder.RegisterIocEventing();
                return builder;
            });

            return register;
        }
        
        /// <summary>
        /// Add IoC Event Handle Support
        /// </summary>
        /// <param name="register"></param>
        /// <typeparam name="THandle"></typeparam>
        /// <typeparam name="TMessage"></typeparam>
        /// <returns></returns>
        public static AutofacProxyRegister AddIocEventHandle<THandle, TMessage>(this AutofacProxyRegister register) where THandle : class, IHandleEvent<TMessage>
        {
            register.AddScoped<IHandleEvent<TMessage>, THandle>();
            return register;
        }
    }
}