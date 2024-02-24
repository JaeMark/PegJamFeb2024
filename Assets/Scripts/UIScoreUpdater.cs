using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScoreUpdater : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        // Subscribe to the score change event
        ScoreManager.Instance.OnScoreChanged += UpdateScoreText;

        // Update the initial score text
        UpdateScoreText(ScoreManager.Instance.Score);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the score change event to prevent memory leaks
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged -= UpdateScoreText;
        }
    }

    private void UpdateScoreText(int newScore)
    {
        // Update the TextMeshProUGUI with the new score
        scoreText.text = "Score: " + newScore.ToString();
    }
}
