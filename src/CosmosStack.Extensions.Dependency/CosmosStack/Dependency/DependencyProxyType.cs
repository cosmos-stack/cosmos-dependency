namespace CosmosStack.Dependency
{
    /// <summary>
    /// Register proxy type <br />
    /// 注册类型
    /// </summary>
    public enum DependencyProxyType
    {
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
        /// Resolved instance self func
        /// </summary>
        ResolvedInstanceSelfFunc,
        
        /// <summary>
        /// Custom func
        /// </summary>
        CustomUnsafeDelegate,
    }
}