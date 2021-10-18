using System;
using System.Linq;
using CosmosStack.Disposables;
using Microsoft.Extensions.DependencyInjection;

namespace CosmosStack.Dependency
{
    /// <summary>
    /// Microsoft dependency proxy register
    /// </summary>
    public sealed class MicrosoftProxyRegister : DependencyProxyRegister<IServiceCollection>
    {
        private readonly IDisposableAction _disposableAction;

        /// <inheritdoc />
        public MicrosoftProxyRegister(IServiceCollection services) : base(services)
        {
            _disposableAction = new DisposableAction<IServiceCollection>(s => s.AddRegisterProxyFrom(this), services);
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
                   RawServices.Any(x => x.ServiceType == type && x.Lifetime == lifetimeType.ToMsLifetime());
        }

        /// <inheritdoc />
        public override bool IsRegistered<T>(DependencyLifetimeType lifetimeType)
        {
            return base.IsRegistered<T>(lifetimeType) ||
                   RawServices.Any(x => x.ServiceType == typeof(T) && x.Lifetime == lifetimeType.ToMsLifetime());
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