using System;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace JFramework.Event
{
    public abstract class StaticEventListener<T, U> : MonoBehaviour where U : StaticEvent<T>
    {
        
#if UNITY_EDITOR
        [TextArea]
        [SerializeField]
        [ShowIf(nameof(raiseUnityEvent))]
        private string description;
#endif

        [Required]
        [SerializeField]
        private U staticEvent;

        [SerializeField]
        private bool raiseUnityEvent = true;

        [ShowIf(nameof(raiseUnityEvent))]
        [SerializeField]
        private UnityEvent<T> onEventRaised = new UnityEvent<T>();

        private void OnEnable()
        {
            if (staticEvent == null)
            {
                Debug.LogError($"No static event serialized on:{this}!", gameObject);
                return;
            }

            staticEvent.AddListener(HandleEvent);
        }

        private void OnDisable()
        {
            if (staticEvent == null)
                return;

            staticEvent.RemoveListener(HandleEvent);
        }

        private void HandleEvent(object sender, T args)
        {
            if (raiseUnityEvent)
                onEventRaised?.Invoke(args);

            OnEventRaised(sender, args);
        }

        protected virtual void OnEventRaised(object sender, T arg) { }
    }
}