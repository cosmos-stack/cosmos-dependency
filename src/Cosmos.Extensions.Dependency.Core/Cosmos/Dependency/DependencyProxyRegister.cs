using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Dependency
{
    /// <summary>
    /// Register proxy bag
    /// </summary>
    public abstract class DependencyProxyRegister
    {
        private readonly List<DependencyRegisterDescriptor> _descriptors = new List<DependencyRegisterDescriptor>();

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="descriptor"></param>
        public void Register(DependencyRegisterDescriptor descriptor)
        {
            if (descriptor is null)
                throw new ArgumentNullException(nameof(descriptor));
            _descriptors.Add(descriptor);
        }

        /// <summary>
        /// Try register
        /// </summary>
        /// <param name="descriptor"></param>
        public void TryRegister(DependencyRegisterDescriptor descriptor)
        {
            if (descriptor is null)
                return;
            if (_descriptors.Any(d => (object) d.RegisterType == (object) descriptor.RegisterType))
                return;
            Register(descriptor);
        }

        /// <summary>
        /// Is registered
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual bool IsRegistered(Type type)
        {
            return type != null &&
                   _descriptors.Any(x => x.RegisterType == type);
        }

        /// <summary>
        /// Is registered
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual bool IsRegistered<T>()
        {
            var type = typeof(T);
            return _descriptors.Any(x => x.RegisterType == type);
        }

        /// <summary>
        /// Export Descriptors
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<DependencyRegisterDescriptor> ExportDescriptors() => _descriptors.AsReadOnly();
    }
}