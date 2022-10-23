namespace Cosmos.Dependency;

/// <summary>
/// Extensions for service provider
/// </summary>
public static class ServiceProviderExtensions
{
    /// <summary>
    /// To abstract
    /// </summary>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static IDefinedResolver ToAbstract(this IServiceProvider provider)
    {
        return new MicrosoftServiceResolver(provider);
    }
}