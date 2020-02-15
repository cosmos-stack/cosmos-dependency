using System;

namespace Cosmos.Extensions.Dependency.Core {
    /// <summary>
    /// Register proxy descriptor
    /// </summary>
    public class DependencyRegisterDescriptor<TResolver> : DependencyRegisterDescriptor {
        /// <summary>
        /// Instance func for implementation
        /// </summary>
        public Func<TResolver, object> ResolveFuncForImplementation { get; set; }
    }
}