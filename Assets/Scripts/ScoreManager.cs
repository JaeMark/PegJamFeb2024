using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Your score variable
    private int score = 0;

    // Public property to access the score
    public int Score
    {
        get { return score; }
        set { score = value; }
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

    // Example method to increase the score
    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}