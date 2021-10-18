using System.Threading.Tasks;
using Autofac;

namespace CosmosStack.Dependency.Events
{
    /// <summary>
    /// Autofac Event Publisher
    /// </summary>
    public class AutofacEventPublisher : EventPublisher
    {
        private readonly ILifetimeScope _scope;

        public AutofacEventPublisher(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public override void Publish<T>(T message)
        {
            _scope.Publish(message);
        }

        public override Task PublishAsync<T>(T message)
        {
            return _scope.PublishAsync(message);
        }
    }
}