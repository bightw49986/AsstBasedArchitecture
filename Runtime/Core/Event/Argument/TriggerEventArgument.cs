using System;
using UnityEngine;

namespace JFramework.Event
{
    [Serializable]
    public readonly struct TriggerEventArgument
    {
        public readonly Collider Triggerer;
        public readonly Collider Reactor;
    }
}