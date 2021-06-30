using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Dependency.Events
{
    public class MicrosoftEventPublisher : EventPublisher
    {
        private readonly IServiceScope _scope;

        public MicrosoftEventPublisher(IServiceScope scope)
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