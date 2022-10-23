namespace Cosmos.Dependency;

/// <summary>
/// Interface for service resolver <br />
/// 定义的服务解析器接口
/// </summary>
public interface IDefinedResolver
{
    /// <summary>
    /// Resolve <br />
    /// 解析
    /// </summary>
    /// <param name="serviceType"></param>
    /// <returns></returns>
    object Resolve(Type serviceType);

    /// <summary>
    /// Resolve <br />
    /// 解析
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    TService Resolve<TService>() where TService : class;

    /// <summary>
    /// Required resolve <br />
    /// 必须解析
    /// </summary>
    /// <param name="serviceType"></param>
    /// <returns></returns>
    object RequiredResolve(Type serviceType);

    /// <summary>
    /// Required resolve <br />
    /// 必须解析
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    TService RequiredResolve<TService>() where TService : class;

    /// <summary>
    /// Try resolve <br />
    /// 尝试解析
    /// </summary>
    /// <param name="serviceType"></param>
    /// <param name="resolvedService"></param>
    /// <returns></returns>
    bool TryResolve(Type serviceType, out object resolvedService);

    /// <summary>
    /// Try resolve <br />
    /// 尝试解析
    /// </summary>
    /// <param name="resolvedService"></param>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    bool TryResolve<TService>(out object resolvedService) where TService : class;

    /// <summary>
    /// Resolve many <br />
    /// 解析一组
    /// </summary>
    /// <param name="serviceType"></param>
    /// <returns></returns>
    IEnumerable<object> ResolveMany(Type serviceType);

    /// <summary>
    /// Resolve many <br />
    /// 解析一组
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    IEnumerable<TService> ResolveMany<TService>() where TService : class;
}