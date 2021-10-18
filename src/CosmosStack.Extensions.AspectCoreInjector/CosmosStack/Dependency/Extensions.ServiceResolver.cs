using AspectCore.DependencyInjection;

namespace CosmosStack.Dependency
{
    /// <summary>
    /// Extensions for NCC AspectCore
    /// </summary>
    public static class ServiceResolverExtensions
    {
        /// <summary>
        /// To abstract
        /// </summary>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static IDefinedResolver ToAbstract(this IServiceResolver resolver)
        {
            return new AspectCoreServiceResolver(resolver);
        }
    }
}