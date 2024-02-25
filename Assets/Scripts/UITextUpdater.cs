using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum StatType
{
    Health,
    Score
}

public class UITextUpdater : MonoBehaviour
{
    [SerializeField]
    private StatType statType;

    [SerializeField]
    private string textPrefix;

    private TextMeshProUGUI UIText;

    private void Start()
    {
        UIText = GetComponent<TextMeshProUGUI>();

        // Subscribe to the appropriate event based on the stat type
        if (statType == StatType.Score)
        {
            ScoreManager.Instance.OnScoreChanged += UpdateUIText;
            UpdateUIText(ScoreManager.Instance.Score); // Update the initial score text
        }
        else if (statType == StatType.Health)
        {
            HealthManager.Instance.OnHealthChanged += UpdateUIText;
            UpdateUIText(HealthManager.Instance.Health); // Update the initial health text
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the appropriate event based on the stat type
        if (statType == StatType.Score && ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged -= UpdateUIText;
        }
        else if (statType == StatType.Health && HealthManager.Instance != null)
        {
            HealthManager.Instance.OnHealthChanged -= UpdateUIText;
        }
    }

    private void UpdateUIText(int newValue)
    {
        // Update the TextMeshProUGUI with the new value
        UIText.text = textPrefix + newValue.ToString();
    }
}
