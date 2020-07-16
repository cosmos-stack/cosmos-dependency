using System;
using System.Linq;
using AspectCore.DependencyInjection;
using Cosmos.Disposables;

namespace Cosmos.Dependency
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposableAction.Invoke();
            }
        }
    }
}