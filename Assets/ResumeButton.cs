using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButton : MonoBehaviour
{
    public void ResumeGame()
    {
        // Load the game state
        SaveGameManager.instance.LoadGameState();
    }
}
