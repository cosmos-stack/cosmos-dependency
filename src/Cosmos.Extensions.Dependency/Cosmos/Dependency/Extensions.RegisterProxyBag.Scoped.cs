using R = Cosmos.Dependency.DependencyProxyRegister;

namespace Cosmos.Dependency;

/// <summary>
/// Extensions for Register proxy bag <br />
/// 注册包扩展
/// </summary>
public static partial class RegisterProxyBagExtensions
{
    #region Add Scoped

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped<TService, TImplementation>(this R bag)
    {
        bag.CheckNull(nameof(bag));
        bag.Register(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementation"></param>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped<TService, TImplementation>(this R bag, TImplementation implementation)
    {
        bag.CheckNull(nameof(bag));
        bag.Register(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped<TService, TImplementation>(this R bag, Func<TImplementation> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.Register(DependencyProxyDescriptor.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped<TService, TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.Register(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped<TImplementation>(this R bag, Func<TImplementation> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.Register(DependencyProxyDescriptor.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped<TService>(this R bag, Func<object> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.Register(DependencyProxyDescriptor.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped<TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.Register(DependencyProxyDescriptor.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <param name="implementationType"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped(this R bag, Func<IDefinedResolver, object> implementationFunc, Type implementationType)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.Register(DependencyProxyDescriptor.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <typeparam name="TImplementationSelf"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped<TImplementationSelf>(this R bag)
    {
        bag.CheckNull(nameof(bag));
        bag.Register(DependencyProxyDescriptor.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="serviceType"></param>
    /// <param name="implementationType"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped(this R bag, Type serviceType, Type implementationType)
    {
        bag.CheckNull(nameof(bag));
        bag.Register(DependencyProxyDescriptor.CreateForType(serviceType, implementationType, DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementation"></param>
    /// <param name="implementationType"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped(this R bag, object implementation, Type implementationType)
    {
        bag.CheckNull(nameof(bag));
        bag.Register(DependencyProxyDescriptor.CreateForObject(implementation, implementationType, DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <param name="implementationType"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScoped(this R bag, Func<object> implementationFunc, Type implementationType)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.Register(DependencyProxyDescriptor.CreateForObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
        return bag;
    }

    #endregion

    #region Add Scoped Service

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementation"></param>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScopedService<TService>(this R bag, TService implementation)
    {
        bag.CheckNull(nameof(bag));
        bag.Register(DependencyProxyDescriptor.CreateForService<TService>(implementation, DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScopedService<TService>(this R bag, Func<IDefinedResolver, TService> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.Register(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R AddScopedService<TService>(this R bag, Func<IDefinedResolver, object> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.Register(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Scoped));
        return bag;
    }

    #endregion

    #region Try Add Scoped

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TImplementation"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScoped<TService, TImplementation>(this R bag)
    {
        bag.CheckNull(nameof(bag));
        bag.TryRegister(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementation"></param>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TImplementation"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScoped<TService, TImplementation>(this R bag, TImplementation implementation)
    {
        bag.CheckNull(nameof(bag));
        bag.TryRegister(DependencyProxyDescriptor.CreateForService<TService, TImplementation>(implementation, DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TImplementation"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScoped<TService, TImplementation>(this R bag, Func<TImplementation> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.TryRegister(DependencyProxyDescriptor.CreateForServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static R TryAddScoped<TService, TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService, TImplementation>(implementationFunc, DependencyLifetimeType.Scoped));
        return bag;
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TImplementation"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScoped<TImplementation>(this R bag, Func<TImplementation> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.TryRegister(DependencyProxyDescriptor.CreateForInstanceDelegate(implementationFunc, DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TService"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScoped<TService>(this R bag, Func<object> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.TryRegister(DependencyProxyDescriptor.CreateForServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <typeparam name="TImplementationSelf"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScoped<TImplementationSelf>(this R bag)
    {
        bag.CheckNull(nameof(bag));
        bag.TryRegister(DependencyProxyDescriptor.CreateForInstanceSelf<TImplementationSelf>(DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TImplementation"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScoped<TImplementation>(this R bag, Func<IDefinedResolver, TImplementation> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedInstanceDelegate(implementationFunc, DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <param name="implementationType"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScoped(this R bag, Func<IDefinedResolver, object> implementationFunc, Type implementationType)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="serviceType"></param>
    /// <param name="implementationType"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScoped(this R bag, Type serviceType, Type implementationType)
    {
        bag.CheckNull(nameof(bag));
        bag.TryRegister(DependencyProxyDescriptor.CreateForType(serviceType, implementationType, DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementation"></param>
    /// <param name="implementationType"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScoped(this R bag, object implementation, Type implementationType)
    {
        bag.CheckNull(nameof(bag));
        bag.TryRegister(DependencyProxyDescriptor.CreateForObject(implementation, implementationType, DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <param name="implementationType"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScoped(this R bag, Func<object> implementationFunc, Type implementationType)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.TryRegister(DependencyProxyDescriptor.CreateForObjectDelegate(implementationFunc, implementationType, DependencyLifetimeType.Scoped));
    }

    #endregion

    #region Try Add Scoped Service

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementation"></param>
    /// <typeparam name="TService"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScopedService<TService>(this R bag, TService implementation)
    {
        bag.CheckNull(nameof(bag));
        bag.TryRegister(DependencyProxyDescriptor.CreateForService<TService>(implementation, DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TService"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScopedService<TService>(this R bag, Func<IDefinedResolver, TService> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(resolver => implementationFunc(resolver), DependencyLifetimeType.Scoped));
    }

    /// <summary>
    /// Try add Scoped
    /// </summary>
    /// <param name="bag"></param>
    /// <param name="implementationFunc"></param>
    /// <typeparam name="TService"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void TryAddScopedService<TService>(this R bag, Func<IDefinedResolver, object> implementationFunc)
    {
        bag.CheckNull(nameof(bag));
        implementationFunc.CheckNull(nameof(implementationFunc));
        bag.TryRegister(DependencyProxyDescriptor.CreateForResolvedServiceDelegate<TService>(implementationFunc, DependencyLifetimeType.Scoped));
    }

    #endregion
}