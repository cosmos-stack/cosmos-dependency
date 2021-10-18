using System;
using System.Collections.Generic;

namespace CosmosStack.Dependency
{
    /// <summary>
    /// Register proxy bag <br />
    /// 注册包
    /// </summary>
    /// <typeparam name="TServices"></typeparam>
    public abstract class DependencyProxyRegister<TServices> : DependencyProxyRegister
    {
        /// <inheritdoc />
        protected DependencyProxyRegister(TServices services)
        {
            RawServices = services ?? throw new ArgumentNullException(nameof(services));

            _preRegisterActionTable = new Dictionary<string, Action<TServices>>();
            _postRegisterActionTable = new Dictionary<string, Action<TServices>>();
        }

        /// <summary>
        /// Gets raw services <br />
        /// 获取原始服务
        /// </summary>
        public TServices RawServices { get; }

        #region Pre and Post register

        private readonly Dictionary<string, Action<TServices>> _preRegisterActionTable;

        private readonly Dictionary<string, Action<TServices>> _postRegisterActionTable;

        /// <summary>
        /// Add pre register action <br />
        /// 增加注册前事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="registerAct"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AddPreRegister(string key, Action<TServices> registerAct)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (registerAct is null)
                throw new ArgumentNullException(nameof(registerAct));
            if (_preRegisterActionTable.ContainsKey(key))
                throw new ArgumentException($"Same key '{key}' is exist in PreRegisterActionTable.");
            _preRegisterActionTable.Add(key, registerAct);
        }

        /// <summary>
        /// Add post register action <br />
        /// 增加注册后事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="registerAct"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AddPostRegister(string key, Action<TServices> registerAct)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (registerAct is null)
                throw new ArgumentNullException(nameof(registerAct));
            if (_postRegisterActionTable.ContainsKey(key))
                throw new ArgumentException($"Same key '{key}' is exist in PostRegisterActionTable.");
            _postRegisterActionTable.Add(key, registerAct);
        }

        /// <summary>
        /// Remove all register actions <br />
        /// 移除所有注册事件
        /// </summary>
        public void RemoveAllRegisters()
        {
            RemoveAllPreRegisters();
            RemoveAllPostRegisters();
        }

        /// <summary>
        /// Remove all pre register actions <br />
        /// 移除所有注册前事件
        /// </summary>
        public void RemoveAllPreRegisters() => _preRegisterActionTable.Clear();

        /// <summary>
        /// Remove all post register actions <br />
        /// 移除所有注册后事件
        /// </summary>
        public void RemoveAllPostRegisters() => _postRegisterActionTable.Clear();

        /// <summary>
        /// Remove pre register action <br />
        /// 移除指定名称的注册前事件
        /// </summary>
        /// <param name="key"></param>
        public void RemovePreRegister(string key) => _preRegisterActionTable.Remove(key);

        /// <summary>
        /// Remove post register action <br />
        /// 移除指定名称的注册后事件
        /// </summary>
        /// <param name="key"></param>
        public void RemovePostRegister(string key) => _postRegisterActionTable.Remove(key);

        private static Action<TServices> Combine(Dictionary<string, Action<TServices>> table)
        {
            Action<TServices> finallyAct = s => { };
            foreach (var item in table)
            {
                var action = item.Value;
                if (action is null)
                    continue;
                finallyAct += action;
            }

            return finallyAct;
        }

        #endregion

        /// <summary>
        /// Dispose <br />
        /// 释放
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) { }

        private bool _disposable;

        /// <inheritdoc />
        public override void Dispose()
        {
            if (!_disposable)
            {
                Combine(_preRegisterActionTable)?.Invoke(RawServices);

                Dispose(true);

                Combine(_postRegisterActionTable)?.Invoke(RawServices);
            }

            _disposable = true;
        }
    }
}