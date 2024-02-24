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
        ScoreManager.Instance.IncreaseScore(score);
        Debug.Log("Object clicked: " + gameObject.name);
        Debug.Log("New Score: " + ScoreManager.Instance.Score);
        Destroy(gameObject); // Destroy the object when clicked
    }
}