using System;
using System.Collections.Generic;
using Autofac;

namespace CosmosStack.Dependency
{
    /// <summary>
    /// Autofac service resolver
    /// </summary>
    public struct AutofacServiceResolver : IDefinedResolver
    {
        private IComponentContext _container;

        /// <summary>
        /// Create a new instance of <see cref="AutofacServiceResolver"/>
        /// </summary>
        /// <param name="container"></param>
        public AutofacServiceResolver(IComponentContext container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        /// <inheritdoc />
        public object Resolve(Type serviceType) => _container.ResolveOptional(serviceType);

        /// <inheritdoc />
        public TService Resolve<TService>() where TService : class => _container.ResolveOptional<TService>();

        /// <inheritdoc />
        public object RequiredResolve(Type serviceType) => _container.Resolve(serviceType);

        /// <inheritdoc />
        public TService RequiredResolve<TService>() where TService : class => _container.Resolve<TService>();

        /// <inheritdoc />
        public bool TryResolve(Type serviceType, out object resolvedService)
        {
            try
            {
                resolvedService = RequiredResolve(serviceType);
                return true;
            }
            catch
            {
                resolvedService = default;
                return false;
            }
        }

        /// <inheritdoc />
        public bool TryResolve<TService>(out object resolvedService) where TService : class
        {
            try
            {
                resolvedService = RequiredResolve<TService>();
                return true;
            }
            catch
            {
                resolvedService = default;
                return false;
            }
        }

        /// <inheritdoc />
        public IEnumerable<object> ResolveMany(Type serviceType) => _container.ResolveMany(serviceType);

        /// <inheritdoc />
        public IEnumerable<TService> ResolveMany<TService>() where TService : class => _container.ResolveMany<TService>();
    }
}