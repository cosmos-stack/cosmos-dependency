namespace Cosmos.Dependency;

/// <summary>
/// Dependency proxy register interface <br />
/// 依赖注册器接口
/// </summary>
public interface IDependencyProxyRegister : IDisposable
{
    /// <summary>
    /// Register <br />
    /// 注册
    /// </summary>
    /// <param name="descriptor"></param>
    void Register(DependencyProxyDescriptor descriptor);

    /// <summary>
    /// Try register <br />
    /// 尝试注册
    /// </summary>
    /// <param name="descriptor"></param>
    void TryRegister(DependencyProxyDescriptor descriptor);

    /// <summary>
    /// Is registered <br />
    /// 标记是否已注册
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    bool IsRegistered(Type type);

    /// <summary>
    /// Is registered <br />
    /// 标记是否已注册
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    bool IsRegistered<T>();

    /// <summary>
    /// Is registered <br />
    /// 标记是否已注册
    /// </summary>
    /// <param name="type"></param>
    /// <param name="lifetimeType"></param>
    /// <returns></returns>
    bool IsRegistered(Type type, DependencyLifetimeType lifetimeType);

    /// <summary>
    /// Is registered <br />
    /// 标记是否已注册
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="lifetimeType"></param>
    /// <returns></returns>
    bool IsRegistered<T>(DependencyLifetimeType lifetimeType);
}