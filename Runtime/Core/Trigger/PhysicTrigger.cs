using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PhysicTrigger : MonoBehaviour
{
    public UnityEvent<Collider> TriggerEnter;
    public UnityEvent<Collider> TriggerStay;
    public UnityEvent<Collider> TriggerExit;
    public UnityEvent<Collision> CollisionEnter;
    public UnityEvent<Collision> CollisionStay;
    public UnityEvent<Collision> CollisionExit;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        TriggerStay?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerExit?.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionEnter?.Invoke(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        CollisionStay?.Invoke(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        CollisionExit?.Invoke(collision);
    }
}
