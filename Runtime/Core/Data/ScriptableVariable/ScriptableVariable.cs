using UnityEngine;
using Sirenix.OdinInspector;

namespace JFramework.Data
{
    public abstract class ScriptableVariable<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [TextArea]
        [PropertyOrder(64)]
        private string description;
#endif
        public T Value;

        #region Operators
        public static implicit operator T(ScriptableVariable<T> variable)
        {
            return variable.Value;
        }
        #endregion
    }
}

