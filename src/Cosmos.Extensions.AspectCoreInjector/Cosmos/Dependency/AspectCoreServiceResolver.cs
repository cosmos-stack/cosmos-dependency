using System;
using System.Collections.Generic;
using AspectCore.DependencyInjection;

namespace Cosmos.Dependency
{
    /// <summary>
    /// NCC AspectCore service resolver
    /// </summary>
    public struct AspectCoreServiceResolver : IDefinedResolver
    {
        private IServiceResolver _resolver;

        /// <summary>
        /// Create a new instance of <see cref="AspectCoreServiceResolver"/>.
        /// </summary>
        /// <param name="resolver"></param>
        public AspectCoreServiceResolver(IServiceResolver resolver)
        {
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        /// <inheritdoc />
        public object Resolve(Type serviceType) => _resolver.Resolve(serviceType);

        /// <inheritdoc />
        public TService Resolve<TService>() where TService : class => _resolver.Resolve<TService>();

        /// <inheritdoc />
        public object RequiredResolve(Type serviceType) => _resolver.ResolveRequired(serviceType);

        /// <inheritdoc />
        public TService RequiredResolve<TService>() where TService : class => _resolver.ResolveRequired<TService>();

        /// <inheritdoc />
        public IEnumerable<object> ResolveMany(Type serviceType) => _resolver.ResolveMany(serviceType);

        /// <inheritdoc />
        public IEnumerable<TService> ResolveMany<TService>() where TService : class => _resolver.ResolveMany<TService>();
    }
}