using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveGameManager : MonoBehaviour
{
    public static SaveGameManager instance; // Singleton instance

private void Awake()
{
    // Singleton pattern to ensure only one instance of SaveGameManager exists
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

// Save the game state
public void SaveGameState(string levelName)
{
    // Save relevant game state data here, such as player position, scores, etc.
    PlayerPrefs.SetString("LastLevelName", levelName);
    PlayerPrefs.Save();
}

// Load the game state
public void LoadGameState()
{
    // Retrieve the last played level name from PlayerPrefs
    string lastLevelName = PlayerPrefs.GetString("LastLevelName", "Level1"); // Default to Level1 if not found

    // Load the last played level by name
    SceneManager.LoadScene(lastLevelName);
}

    public void ResumeGame()
    {
        // Load the game state
        SaveGameManager.instance.LoadGameState();
    }
}