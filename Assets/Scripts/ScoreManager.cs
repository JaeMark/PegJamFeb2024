using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;

    // Public property to access the instance
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(ScoreManager).Name;
                    instance = obj.AddComponent<ScoreManager>();
                }
            }
            return instance;
        }
    }

    // Event triggered whenever the score changes
    public UnityAction<int> OnScoreChanged;

    private int score = 0;

    // Public property to access the score
    public int Score
    {
        get { return score; }
        private set
        {
            score = value;
            // Trigger the score change event
            OnScoreChanged?.Invoke(score);
        }
    }

    // Method to update the score
    public void IncreaseScore(int amount)
    {
        Score += amount;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}