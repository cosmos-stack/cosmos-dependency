using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Extensions.Dependency.Core {
    /// <summary>
    /// Register proxy bag
    /// </summary>
    public abstract class DependencyProxyRegister {
        private readonly List<DependencyRegisterDescriptor> _descriptors = new List<DependencyRegisterDescriptor>();

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="descriptor"></param>
        public void Register(DependencyRegisterDescriptor descriptor) {
            if (descriptor is null)
                throw new ArgumentNullException(nameof(descriptor));
            _descriptors.Add(descriptor);
        }

        /// <summary>
        /// Try register
        /// </summary>
        /// <param name="descriptor"></param>
        public void TryRegister(DependencyRegisterDescriptor descriptor) {
            if (descriptor is null)
                return;
            if (_descriptors.Any(d => (object) d.RegisterType == (object) descriptor.RegisterType))
                return;
            Register(descriptor);
        }

        /// <summary>
        /// Export Descriptors
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<DependencyRegisterDescriptor> ExportDescriptors() => _descriptors.AsReadOnly();
    }
}