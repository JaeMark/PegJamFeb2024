using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    [SerializeField]
    private float radius = 0.5f;
    public float Radius => radius;

    private void OnMouseDown()
    {
        OnClicked();
    }

    public virtual void OnClicked()
    {
        Debug.Log("Object clicked: " + gameObject.name);
        Destroy(gameObject); // Destroy the object when clicked
    }
}