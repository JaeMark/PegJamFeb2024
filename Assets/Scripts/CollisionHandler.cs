using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [System.Serializable]
    public class CollisionEvent : UnityEvent<Collision2D> { }

    [SerializeField]
    private LayerMask zomBeeLayer;

    [SerializeField]
    private CollisionEvent onZomBeeCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsZomBeeCollision(collision))
        {
            onZomBeeCollision.Invoke(collision);
        }
    }

    private bool IsZomBeeCollision(Collision2D collision)
    {
        return (zomBeeLayer.value & 1 << collision.gameObject.layer) != 0;
    }
}

