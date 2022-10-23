using Cosmos.Dependency;

namespace Autofac;

/// <summary>
/// Extensions for Autofac
/// </summary>
public static class FluentRegisterTypesExtensions
{
    /// <summary>
    /// Begin register
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static DependencyProxyRegister<ContainerBuilder> BeginTypedRegister(this ContainerBuilder builder)
    {
        return new AutofacProxyRegister(builder);
    }

    /// <summary>
    /// Begin register
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static DependencyProxyRegister BeginRegister(this ContainerBuilder services)
    {
        return services.BeginTypedRegister();
    }

    /// <summary>
    /// End register
    /// </summary>
    /// <param name="register"></param>
    /// <returns></returns>
    public static ContainerBuilder Finish(this DependencyProxyRegister<ContainerBuilder> register)
    {
        using (register)
        {
            return register.RawServices;
        }
    }

    /// <summary>
    /// End register
    /// </summary>
    /// <param name="register"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static ContainerBuilder Finish(this DependencyProxyRegister register)
    {
        if (register is DependencyProxyRegister<ContainerBuilder> typedRegister)
        {
            using (typedRegister)
            {
                return typedRegister.RawServices;
            }
        }

        throw new ArgumentException("Cannot convert register to 'DependencyProxyRegister<ContainerBuilder>'.");
    }
}