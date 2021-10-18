using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosStack.Dependency
{
    /// <summary>
    /// Register proxy bag <br />
    /// 注册包
    /// </summary>
    public abstract class DependencyProxyRegister : IDependencyProxyRegister
    {
        private readonly List<DependencyProxyDescriptor> _descriptors = new();

        /// <summary>
        /// Register <br />
        /// 注册
        /// </summary>
        /// <param name="descriptor"></param>
        public void Register(DependencyProxyDescriptor descriptor)
        {
            if (descriptor is null)
                throw new ArgumentNullException(nameof(descriptor));
            _descriptors.Add(descriptor);
        }

        /// <summary>
        /// Try Register <br />
        /// 尝试注册
        /// </summary>
        /// <param name="descriptor"></param>
        public void TryRegister(DependencyProxyDescriptor descriptor)
        {
            if (descriptor is null)
                return;
            if (_descriptors.Any(d => (object) d.RegisterType == (object) descriptor.RegisterType))
                return;
            Register(descriptor);
        }

        /// <summary>
        /// Is Registered <br />
        /// 标记是否已注册
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual bool IsRegistered(Type type)
        {
            return type != null &&
                   _descriptors.Any(x => x.RegisterType == type);
        }

        /// <summary>
        /// Is Registered <br />
        /// 标记是否已注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual bool IsRegistered<T>()
        {
            var type = typeof(T);
            return _descriptors.Any(x => x.RegisterType == type);
        }

        /// <summary>
        /// Is Registered <br />
        /// 标记是否已注册
        /// </summary>
        /// <param name="type"></param>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public virtual bool IsRegistered(Type type, DependencyLifetimeType lifetimeType)
        {
            return type != null &&
                   _descriptors.Any(x => x.RegisterType == type && x.LifetimeType == lifetimeType);
        }

        /// <summary>
        /// Is Registered <br />
        /// 标记是否已注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lifetimeType"></param>
        /// <returns></returns>
        public virtual bool IsRegistered<T>(DependencyLifetimeType lifetimeType)
        {
            var type = typeof(T);
            return _descriptors.Any(x => x.RegisterType == type && x.LifetimeType == lifetimeType);
        }

        /// <summary>
        /// Export Descriptors <br />
        /// 导出描述符
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<DependencyProxyDescriptor> ExportDescriptors() => _descriptors.AsReadOnly();

        /// <summary>
        /// Dispose <br />
        /// 释放
        /// </summary>
        public abstract void Dispose();
    }
}