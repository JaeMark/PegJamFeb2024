using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            // Optionally, show pause menu UI or perform other pause-related actions
            Debug.Log("Game paused");
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            // Optionally, hide pause menu UI or perform other resume-related actions
            Debug.Log("Game resumed");
        }
    }
}
