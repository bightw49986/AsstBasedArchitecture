using System;
using UnityEngine;

namespace JFramework.Event
{
    [Serializable]
    public readonly struct TriggerEventArgument2D
    {
        public readonly Collider2D Triggerer;
        public readonly Collider2D Reactor;
    }
}