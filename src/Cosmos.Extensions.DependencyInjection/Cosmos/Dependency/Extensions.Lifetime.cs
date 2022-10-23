using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Dependency;

/// <summary>
/// Lifetime extensions
/// </summary>
public static class LifetimeExtensions
{
    /// <summary>
    /// To Microsoft Lifetime
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static ServiceLifetime ToMsLifetime(this DependencyLifetimeType type)
    {
        return type switch
        {
            DependencyLifetimeType.Scoped    => ServiceLifetime.Scoped,
            DependencyLifetimeType.Singleton => ServiceLifetime.Singleton,
            DependencyLifetimeType.Transient => ServiceLifetime.Transient,
            _                                => ServiceLifetime.Transient
        };
    }
}