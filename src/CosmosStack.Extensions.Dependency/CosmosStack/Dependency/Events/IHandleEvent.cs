using System.Threading.Tasks;

namespace CosmosStack.Dependency.Events
{
    /// <summary>
    /// Handle an event
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public interface IHandleEvent<in TMessage>
    {
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="message"></param>
        void Handle(TMessage message);
    }

    /// <summary>
    /// Handle an event asynchronously
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public interface IHandleEventAsync<in TMessage>
    {
        Task HandleAsync(TMessage message);
    }
}