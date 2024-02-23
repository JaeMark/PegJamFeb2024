using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    [SerializeField]
    private float radius = 0.5f;
    public float Radius => radius;

    [SerializeField]
    private Vector3 velocity = Vector3.down;
    public Vector3 Velocity { get => velocity; set => velocity = value; }

    private void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    // Optional: Handle click events
    public virtual void OnClicked()
    {
        Debug.Log("Object clicked: " + gameObject.name);
    }
}
