using Autofac;

namespace Cosmos.Dependency.Events
{
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
        
        public static AutofacProxyRegister AddIocEventHandle<THandle, TMessage>(this AutofacProxyRegister register) where THandle : class, IHandleEvent<TMessage>
        {
            register.AddScoped<IHandleEvent<TMessage>, THandle>();
            return register;
        }
    }
}