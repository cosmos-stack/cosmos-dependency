using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CosmosStack.Dependency.Events
{
    internal static class MicrosoftServiceScopeExtensions
    {
        public static void Publish<T>(this IServiceScope scope, T message)
        {
            if (message == null)
                return;

            var exceptions = new List<Exception>();
            var handleMethod = typeof(IHandleEvent<>).MakeGenericType(typeof(T)).GetMethod("Handle");
            var handleAsyncMethod = typeof(IHandleEventAsync<>).MakeGenericType(typeof(T)).GetMethod("HandleAsync");

            if (handleMethod is null || handleAsyncMethod is null)
                throw new InvalidOperationException("Handle and HandleAsync method should be defined.");

            foreach (var handler in scope.ResolveHandlers(message))
            {
                try
                {
                    //Invoke sync handler
                    handleMethod.Invoke(handler, new object[] { message });
                }
                catch (TargetInvocationException ti)
                {
                    //Unwrap TargetInvocationException
                    exceptions.Add(ti.InnerException ?? ti);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                }
            }

            foreach (var asyncHandler in scope.ResolveAsyncHandlers(message))
            {
                try
                {
                    //Invoke async handler
                    var task = (Task)handleAsyncMethod.Invoke(asyncHandler, new object[] { message });
                    task!.GetAwaiter().GetResult();
                }
                catch (TargetInvocationException ti)
                {
                    //Unwrap TargetInvocationException
                    exceptions.Add(ti.InnerException ?? ti);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public static async Task PublishAsync<T>(this IServiceScope scope, T message)
        {
            if (message == null)
                return;

            var exceptions = new List<Exception>();
            var handleMethod = typeof(IHandleEvent<>).MakeGenericType(typeof(T)).GetMethod("Handle");
            var handleAsyncMethod = typeof(IHandleEventAsync<>).MakeGenericType(typeof(T)).GetMethod("HandleAsync");

            if (handleMethod is null || handleAsyncMethod is null)
                throw new InvalidOperationException("Handle and HandleAsync method should be defined.");

            foreach (var handler in scope.ResolveHandlers(message))
            {
                try
                {
                    //Invoke sync handler
                    handleMethod.Invoke(handler, new object[] { message });
                }
                catch (TargetInvocationException ti)
                {
                    //Unwrap TargetInvocationException
                    exceptions.Add(ti.InnerException ?? ti);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                }
            }

            foreach (var asyncHandler in scope.ResolveAsyncHandlers(message))
            {
                try
                {
                    //Invoke async handler
                    await ((Task)handleAsyncMethod.Invoke(asyncHandler, new object[] { message }))!;
                }
                catch (TargetInvocationException ti)
                {
                    //Unwrap TargetInvocationException
                    exceptions.Add(ti.InnerException ?? ti);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public static IEnumerable<object> ResolveHandlers<T>(this IServiceScope scope, T message)
        {
            var eventType = message.GetType();
            return scope.ResolveConcreteHandlers(eventType, MakeHandlerType)
                        .Union(scope.ResolveInterfaceHandlers(eventType, MakeHandlerType));
        }

        public static IEnumerable<object> ResolveAsyncHandlers<T>(this IServiceScope scope, T message)
        {
            var eventType = message.GetType();
            return scope.ResolveConcreteHandlers(eventType, MakeAsyncHandlerType)
                        .Union(scope.ResolveInterfaceHandlers(eventType, MakeAsyncHandlerType));
        }

        private static IEnumerable<object> ResolveConcreteHandlers(this IServiceScope scope, Type eventType, Func<Type, Type> handlerFactory)
        {
            return scope.ServiceProvider.GetServices(handlerFactory(eventType));
        }

        private static IEnumerable<object> ResolveInterfaceHandlers(this IServiceScope scope, Type eventType, Func<Type, Type> handlerFactory)
        {
            return eventType.GetTypeInfo().ImplementedInterfaces.SelectMany(i => (IEnumerable<dynamic>)scope.ServiceProvider.GetServices(handlerFactory(i))).Distinct();
        }

        private static Type MakeHandlerType(Type type)
        {
            return typeof(IEnumerable<>).MakeGenericType(typeof(IHandleEvent<>).MakeGenericType(type));
        }

        private static Type MakeAsyncHandlerType(Type type)
        {
            return typeof(IEnumerable<>).MakeGenericType(typeof(IHandleEventAsync<>).MakeGenericType(type));
        }
    }
}