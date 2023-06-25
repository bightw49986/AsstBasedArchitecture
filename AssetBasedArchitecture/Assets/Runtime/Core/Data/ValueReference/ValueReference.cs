using System;
using UnityEngine;
using Sirenix.OdinInspector;

namespace JFramework.Data
{
    /// <summary>
    /// Unity event wrappers for UniRx's reactive properties.
    /// </summary>
    public abstract class ValueReference<T, U> : IDisposable, IEquatable<T> where U : ScriptableVariable<T>
    {
        [SerializeField]
        protected bool useScriptableValue;

        [ShowIf(nameof(useScriptableValue))]
        [Required]
        [SerializeField]
        private U scriptableValue;

        [HideIf(nameof(useScriptableValue))]
        [SerializeField]
        private T constValue;

        public T Value
        {
            get => useScriptableValue ? scriptableValue.Value : constValue;
            set
            {
                if (useScriptableValue)
                    scriptableValue.Value = value;
                else
                    constValue = value;
            }
        }

        private bool disposedValue;

        #region Object
        public override string ToString()
        {
            return Value.ToString();
        }

        public bool Equals(T other)
        {
            return Value.Equals(other);
        }
        #endregion

        #region IDisposable
        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    OnDisposed();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void OnDisposed() { }
        #endregion

        #region Operators
        public static implicit operator T(ValueReference<T, U> valueReference)
        {
            return valueReference.Value;
        }
        #endregion
    }
}
