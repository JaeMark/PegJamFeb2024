using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAudioTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] scoreIncreaseClips; // Array of clips for score increase

    [SerializeField]
    private AudioClip[] scoreDecreaseClips; // Array of clips for score decrease

    private AudioSource audioSource;

    private int previousScore;

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Initialize the previous score with the current score
        previousScore = ScoreManager.Instance.Score;

        // Subscribe to the ScoreManager's OnScoreChanged event
        ScoreManager.Instance.OnScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged -= OnScoreChanged;
        }
    }

    private void OnScoreChanged(int newScore)
    {
        if (audioSource != null)
        {
            if (newScore > previousScore && scoreIncreaseClips.Length > 0)
            {
                // Play a random score increase audio clip
                PlayRandomClip(scoreIncreaseClips);
            }
            else if (newScore < previousScore && scoreDecreaseClips.Length > 0)
            {
                // Play a random score decrease audio clip
                PlayRandomClip(scoreDecreaseClips);
            }

            // Update the previous score
            previousScore = newScore;
        }
    }

    private void PlayRandomClip(AudioClip[] clips)
    {
        // Choose a random clip from the array
        int randomIndex = Random.Range(0, clips.Length);
        AudioClip randomClip = clips[randomIndex];

        if (randomClip != null)
        {
            // Play the selected audio clip
            audioSource.PlayOneShot(randomClip);
        }
    }
}
