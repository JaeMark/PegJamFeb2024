using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    [SerializeField]
    private int score = 100;

    [SerializeField]
    private float killY = -10;

    [SerializeField]
    private UnityEvent onClickedEvent;

    private void Update()
    {
        if (transform.position.y <= killY)
        {
            DestroyObject();
        }
    }

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

        if (onClickedEvent != null)
        {
            onClickedEvent.Invoke();
        }

        DestroyObject();
    }

    public virtual void DestroyObject()
    {
        // Check if gameObject is not null before destroying it
        if (gameObject != null)
        {
            // Find the highest parent in the hierarchy
            Transform highestParent = transform;
            while (highestParent.parent != null)
            {
                highestParent = highestParent.parent;
            }

            // Destroy the highest parent game object
            Destroy(highestParent.gameObject);
        }
        else
        {
            Debug.LogError("gameObject is null!");
        }
    }
}