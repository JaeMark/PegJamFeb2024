using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    [SerializeField]
    private int score = 100;

    [SerializeField]
    private UnityEvent onClickedEvent;

    private void OnMouseDown()
    {
        OnClicked();
    }

    public virtual void OnClicked()
    {
        if (onClickedEvent != null)
        {
            onClickedEvent.Invoke();
        }

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