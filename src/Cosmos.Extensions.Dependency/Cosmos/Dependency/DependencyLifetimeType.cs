namespace Cosmos.Dependency;

/// <summary>
/// Lifetime type for register proxy <br />
/// 生命周期
/// </summary>
public enum DependencyLifetimeType
{
    /// <summary>
    /// Scoped
    /// </summary>
    Scoped,

    /// <summary>
    /// Singleton
    /// </summary>
    Singleton,

    /// <summary>
    /// Transient
    /// </summary>
    Transient
}