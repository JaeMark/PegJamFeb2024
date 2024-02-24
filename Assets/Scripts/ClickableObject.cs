using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    [SerializeField]
    private float radius = 0.5f;

    [SerializeField]
    private int score = 100;

    public float Radius => radius;

    private void OnMouseDown()
    {
        OnClicked();
    }

    public virtual void OnClicked()
    {
        // Check if ScoreManager.Instance is not null before using it
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.IncreaseScore(score);
        }
        else
        {
            Debug.LogError("ScoreManager.Instance is null!");
        }

        Debug.Log("Object clicked: " + gameObject.name);

        // Check if gameObject is not null before destroying it
        if (gameObject != null)
        {
            Destroy(gameObject); // Destroy the object when clicked
        }
        else
        {
            Debug.LogError("gameObject is null!");
        }
    }
}