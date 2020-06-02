namespace Cosmos.Dependency
{
    /// <summary>
    /// Lifetime type for register proxy
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
}