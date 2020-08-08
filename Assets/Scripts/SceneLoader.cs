using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == SceneManager.sceneCountInBuildSettings - 2)
        {
            FindObjectOfType<GameStatus>().scoreDisplay.enabled = false;
        }
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadStartScene()
    {
        // first scene of any game is always at index 0
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
