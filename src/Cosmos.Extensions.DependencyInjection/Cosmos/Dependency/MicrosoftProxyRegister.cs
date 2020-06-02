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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposableAction.Invoke();
            }
        }
    }
}