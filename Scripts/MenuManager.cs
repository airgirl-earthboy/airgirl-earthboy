using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start the game or proceed to the next level
    public void PlayGame()
    {
        Debug.Log("Start Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Start level at index i
    public void PlayLevel(int i)
    {
        SceneManager.LoadScene(i);
    }
}
