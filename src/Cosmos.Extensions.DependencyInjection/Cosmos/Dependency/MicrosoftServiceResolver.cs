using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Dependency
{
    /// <summary>
    /// Microsoft service resolver wrapper
    /// </summary>
    public struct MicrosoftServiceResolver : IDefinedResolver
    {
        private IServiceProvider _provider;

        /// <summary>
        /// Create a new instance of <see cref="MicrosoftServiceResolver"/>
        /// </summary>
        /// <param name="provider"></param>
        public MicrosoftServiceResolver(IServiceProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        /// <inheritdoc />
        public object Resolve(Type serviceType) => _provider.GetService(serviceType);

        /// <inheritdoc />
        public TService Resolve<TService>() where TService : class => _provider.GetService<TService>();

        /// <inheritdoc />
        public object RequiredResolve(Type serviceType) => _provider.GetRequiredService(serviceType);

        /// <inheritdoc />
        public TService RequiredResolve<TService>() where TService : class => _provider.GetRequiredService<TService>();

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
        public IEnumerable<object> ResolveMany(Type serviceType) => _provider.GetServices(serviceType);

        /// <inheritdoc />
        public IEnumerable<TService> ResolveMany<TService>() where TService : class => _provider.GetServices<TService>();
    }
}