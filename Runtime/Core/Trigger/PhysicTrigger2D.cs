using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class PhysicTrigger2D : MonoBehaviour
{
    public UnityEvent<Collider2D> TriggerEnter;
    public UnityEvent<Collider2D> TriggerStay;
    public UnityEvent<Collider2D> TriggerExit;
    public UnityEvent<Collision2D> CollisionEnter;
    public UnityEvent<Collision2D> CollisionStay;
    public UnityEvent<Collision2D> CollisionExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEnter?.Invoke(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TriggerStay?.Invoke(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TriggerExit?.Invoke(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionEnter?.Invoke(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionStay?.Invoke(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionExit?.Invoke(collision);
    }
}