using AspectCore.DependencyInjection;

namespace Cosmos.Dependency;

/// <summary>
/// Extensions for lifetime
/// </summary>
public static class LifetimeExtensions
{
    /// <summary>
    /// To NCC AspectCore lifetime
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static Lifetime ToAspectCoreLifetime(this DependencyLifetimeType type)
    {
        return type switch
        {
            DependencyLifetimeType.Scoped    => Lifetime.Scoped,
            DependencyLifetimeType.Singleton => Lifetime.Singleton,
            DependencyLifetimeType.Transient => Lifetime.Transient,
            _                                => Lifetime.Transient
        };
    }
}