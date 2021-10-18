using System;
using System.Linq;
using AspectCore.DependencyInjection;
using CosmosStack.Disposables;

namespace CosmosStack.Dependency
{
    /// <summary>
    /// AspectCore dependency proxy register
    /// </summary>
    public class AspectCoreProxyRegister : DependencyProxyRegister<IServiceContext>
    {
        private readonly IDisposableAction _disposableAction;

        /// <inheritdoc />
        public AspectCoreProxyRegister(IServiceContext services) : base(services)
        {
            _disposableAction = new DisposableAction<IServiceContext>(s => s.RegisterProxyFrom(this), services);
        }

        /// <inheritdoc />
        public override bool IsRegistered(Type type)
        {
            if (type is null)
                return false;
            return base.IsRegistered(type) ||
                   RawServices.Any(x => x.ServiceType == type);
        }

        /// <inheritdoc />
        public override bool IsRegistered<T>()
        {
            return base.IsRegistered<T>() ||
                   RawServices.Any(x => x.ServiceType == typeof(T));
        }

        /// <inheritdoc />
        public override bool IsRegistered(Type type, DependencyLifetimeType lifetimeType)
        {
            if (type is null)
                return false;
            return base.IsRegistered(type, lifetimeType) ||
                   RawServices.Any(x => x.ServiceType == type && x.Lifetime == lifetimeType.ToAspectCoreLifetime());
        }

        /// <inheritdoc />
        public override bool IsRegistered<T>(DependencyLifetimeType lifetimeType)
        {
            return base.IsRegistered<T>(lifetimeType) ||
                   RawServices.Any(x => x.ServiceType == typeof(T) && x.Lifetime == lifetimeType.ToAspectCoreLifetime());
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
}