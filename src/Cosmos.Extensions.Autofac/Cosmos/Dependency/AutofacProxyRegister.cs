using Autofac;
using Autofac.Core;
using Cosmos.Disposables;

namespace Cosmos.Dependency;

/// <summary>
/// Autofac dependency proxy register
/// </summary>
public class AutofacProxyRegister : DependencyProxyRegister<ContainerBuilder>
{
    private readonly IDisposableAction _disposableAction;

    /// <inheritdoc />
    public AutofacProxyRegister(ContainerBuilder services) : base(services)
    {
        _disposableAction = new DisposableAction<ContainerBuilder>(s => s.RegisterProxyFrom(this), services);
    }

    /// <inheritdoc />
    public override bool IsRegistered(Type type)
    {
        if (type is null)
            return false;
#if NET451 || NET452
            return base.IsRegistered(type);
#else
        return base.IsRegistered(type) ||
               RawServices.ComponentRegistryBuilder.IsRegistered(new TypedService(type));
#endif
    }

    /// <inheritdoc />
    public override bool IsRegistered<T>()
    {
#if NET451 || NET452
        return base.IsRegistered<T>();

#else
            return base.IsRegistered<T>() ||
                   RawServices.ComponentRegistryBuilder.IsRegistered(new TypedService(typeof(T)));
#endif
    }

    /// <inheritdoc />
    public override bool IsRegistered(Type type, DependencyLifetimeType lifetimeType)
    {
        return IsRegistered(type);
    }

    /// <inheritdoc />
    public override bool IsRegistered<T>(DependencyLifetimeType lifetimeType)
    {
        return IsRegistered<T>();
    }

    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _disposableAction.Invoke();
        }
    }
}