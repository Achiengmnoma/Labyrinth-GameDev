using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
   
    public void StartNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitApp(){
        Application.Quit();
    }

    public void SaveGameState(string levelName)
    {
        // Save relevant game state data here, such as player position, scores, etc.
        PlayerPrefs.SetString("previousLevelIndex", levelName);
        PlayerPrefs.Save();
    }

    // public void LevelLoad(){
    //     string previousLevel = SceneManager.GetActiveScene().name;
    //     PlayerPrefs.SetString("previousLevelIndex", previousLevel);
    //     PlayerPrefs.Save();
    // }
    public void OnLevelLoaded()
    {
        // Save the index of the current level as the last played level
        PlayerPrefs.SetInt("LastLevelIndex", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    // public void Resume(){
    //     string previousLevel = PlayerPrefs.GetString("previousLevelIndex","Level 1");

    //     SceneManager.LoadScene(previousLevel);
    //     //StartScreen.instance.LoadGameState();
    // }
    public void ResumeGame()
    {
        // Get the last played level index from PlayerPrefs or another data storage method
        int lastLevelIndex = PlayerPrefs.GetInt("LastLevelIndex");

        // Load the last played level
        SceneManager.LoadScene(lastLevelIndex);


        //   int targetSceneIndex = originalScreenIndex != 0 ? originalScreenIndex : SceneManager.GetActiveScene().buildIndex;
        // SceneManager.LoadScene(targetSceneIndex);
    }
}
