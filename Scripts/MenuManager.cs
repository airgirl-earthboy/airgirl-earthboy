using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start the game or proceed to the next level
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Reset current level
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Return to level 1
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Quit to title screen
    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }

    // Start level at index i
    public void PlayLevel(int i)
    {
        SceneManager.LoadScene(i);
    }
}
