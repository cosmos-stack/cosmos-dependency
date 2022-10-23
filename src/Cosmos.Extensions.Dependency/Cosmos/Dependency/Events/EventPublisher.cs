namespace Cosmos.Dependency.Events;

/// <summary>
/// To publish an event
/// </summary>
public interface IEventPublisher
{
    /// <summary>
    /// Publish
    /// </summary>
    /// <param name="message"></param>
    void Publish<T>(T message);
}

/// <summary>
/// To publish an event asynchronously
/// </summary>
public interface IAsyncEventPublisher
{
    /// <summary>
    /// Publish async
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    Task PublishAsync<T>(T message);
}

/// <summary>
/// An abstract event publisher
/// </summary>
public abstract class EventPublisher : IEventPublisher, IAsyncEventPublisher
{
    /// <summary>
    /// Publish
    /// </summary>
    /// <param name="message"></param>
    public abstract void Publish<T>(T message);

    /// <summary>
    /// Publish async
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public abstract Task PublishAsync<T>(T message);
}