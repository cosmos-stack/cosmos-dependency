using System;
using System.Linq;
using Cosmos.Disposables;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Dependency
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposableAction.Invoke();
            }
        }
    }
}