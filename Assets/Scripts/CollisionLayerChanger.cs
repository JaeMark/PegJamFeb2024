using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLayerChanger : MonoBehaviour
{
    public void ChangeCollisionLayer(string newLayerName)
    {
        // Get the layer index by name
        int newLayerIndex = LayerMask.NameToLayer(newLayerName);

        // Check if the layer exists
        if (newLayerIndex == -1)
        {
            Debug.LogError("Layer " + newLayerName + " does not exist!");
            return;
        }

        // Change the collision layer of the GameObject
        gameObject.layer = newLayerIndex;
    }
}
