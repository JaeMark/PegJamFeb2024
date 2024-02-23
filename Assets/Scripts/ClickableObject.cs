using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    [SerializeField]
    private float radius = 0.5f;
    public float Radius => radius;

    // Optional: Handle click events
    public virtual void OnClicked()
    {
        // Override this method in derived classes to add specific behavior
        Debug.Log("Object clicked: " + gameObject.name);
    }
}

