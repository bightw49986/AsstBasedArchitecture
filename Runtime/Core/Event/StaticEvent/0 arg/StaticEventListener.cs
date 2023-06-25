using System;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace JFramework.Event
{
    public class StaticEventListener : MonoBehaviour
    {
#if UNITY_EDITOR
        [TextArea]
        [SerializeField]
        [ShowIf(nameof(raiseUnityEvent))]
        private string description;
#endif

        [Required]
        [SerializeField]
        private StaticEvent staticEvent;

        [SerializeField]
        private bool raiseUnityEvent = true;

        [ShowIf(nameof(raiseUnityEvent))]
        [SerializeField]
        private UnityEvent onEventRaised = new UnityEvent();

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

        private void HandleEvent(object sender, EventArgs args)
        {
            if (raiseUnityEvent)
                onEventRaised?.Invoke();

            OnEventRaised(sender, args);
        }

        protected virtual void OnEventRaised(object sender, EventArgs e) { }
    }
}


