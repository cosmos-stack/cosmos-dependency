using System;
using Cosmos.Disposables;
using Cosmos.Extensions.Dependency.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Extensions.Dependency {
    /// <summary>
    /// Microsoft dependency proxy register
    /// </summary>
    public sealed class MicrosoftProxyRegister : DependencyProxyRegister<IServiceCollection> {
        private readonly IDisposableAction _disposableAction;

        /// <inheritdoc />
        public MicrosoftProxyRegister(IServiceCollection services) : base(services) {
            _disposableAction = new DisposableAction<IServiceCollection>(s => s.AddRegisterProxyFrom(this), services);
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing) {
            if (disposing) {
                _disposableAction.Invoke();
            }
        }
    }
}