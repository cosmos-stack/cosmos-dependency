using Autofac;

namespace Cosmos.Dependency;

/// <summary>
/// Extensions for Autofac container
/// </summary>
public static class ContainerExtensions
{
    /// <summary>
    /// To abstract
    /// </summary>
    /// <param name="container"></param>
    /// <returns></returns>
    public static IDefinedResolver ToAbstract(this IComponentContext container)
    {
        return new AutofacServiceResolver(container);
    }
}