using System;
using Autofac;
using Autofac.Core;
using Cosmos.Disposables;

namespace Cosmos.Dependency
{
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
            return base.IsRegistered(type) ||
                   RawServices.ComponentRegistryBuilder.IsRegistered(new TypedService(type));
        }

        /// <inheritdoc />
        public override bool IsRegistered<T>()
        {
            return base.IsRegistered<T>() ||
                   RawServices.ComponentRegistryBuilder.IsRegistered(new TypedService(typeof(T)));
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