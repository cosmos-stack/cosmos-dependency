using System;
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposableAction.Invoke();
            }
        }
    }
}