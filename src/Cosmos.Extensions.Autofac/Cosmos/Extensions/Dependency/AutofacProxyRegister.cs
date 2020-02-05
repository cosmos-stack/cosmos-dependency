using System;
using Autofac;
using Cosmos.Disposables;
using Cosmos.Extensions.Dependency.Core;

namespace Cosmos.Extensions.Dependency {
    /// <summary>
    /// Autofac dependency proxy register
    /// </summary>
    public class AutofacProxyRegister : DependencyProxyRegister<ContainerBuilder> {
        private readonly IDisposableAction _disposableAction;

        /// <inheritdoc />
        public AutofacProxyRegister(ContainerBuilder services) : base(services) {
            _disposableAction = new DisposableAction<ContainerBuilder>(s => s.RegisterProxyFrom(this), services);
        }
        
        /// <inheritdoc />
        protected override void Dispose(bool disposing) {
            if (disposing) {
                _disposableAction.Invoke();
            }
        }
    }
}