namespace Cosmos.Extensions.Dependency.Core {
    /// <summary>
    /// Register proxy type
    /// </summary>
    public enum DependencyProxyType {
        /// <summary>
        /// Type to type
        /// </summary>
        TypeToType,

        /// <summary>
        /// Type to instance
        /// </summary>
        TypeToInstance,

        /// <summary>
        /// Type to instance func
        /// </summary>
        TypeToInstanceFunc,
        
        /// <summary>
        /// Type to resolved instance func
        /// </summary>
        TypeToResolvedInstanceFunc,

        /// <summary>
        /// Type self
        /// </summary>
        TypeSelf,

        /// <summary>
        /// Instance self
        /// </summary>
        InstanceSelf,

        /// <summary>
        /// Instance self func
        /// </summary>
        InstanceSelfFunc,
        
        /// <summary>
        /// Resolved instance selft func
        /// </summary>
        ResolvedInstanceSelfFunc
    }
}