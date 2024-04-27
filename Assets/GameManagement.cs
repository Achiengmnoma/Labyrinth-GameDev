using UnityEngine;

public class GameManagement : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Check if the space button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Toggle between pausing and resuming the game
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        // Pause the game by setting Time.timeScale to 0
        Time.timeScale = 0;
        isPaused = true;
        Debug.Log("Game paused");
    }

    void ResumeGame()
    {
        // Resume the game by setting Time.timeScale back to 1
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("Game resumed");
    }
}
