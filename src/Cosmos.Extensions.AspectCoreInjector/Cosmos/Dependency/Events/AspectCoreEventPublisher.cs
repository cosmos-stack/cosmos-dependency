using AspectCore.DependencyInjection;

namespace Cosmos.Dependency.Events;

/// <summary>
/// AspectCore Event Publisher
/// </summary>
public class AspectCoreEventPublisher : EventPublisher
{
    private readonly IServiceResolver _scope;

    public AspectCoreEventPublisher(IServiceResolver scope)
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