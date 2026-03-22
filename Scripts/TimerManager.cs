using TMPro; // Must be added to the top
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// NOT IMPLEMENTED YET
public class TimerManager : MonoBehaviour
{
    public TMPro.TMP_Text timerText;
    public TMPro.TMP_Text levelText;
    private Scene currentScene;

    private float elapsedTime;
    private bool timerRunning = true;

    // Update is called once per frame
    void Update()
    {
        // Set timer to keep track of time
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            string formattedTime = string.Format(" TIME {0:00}:{1:00}", minutes, seconds);
            timerText.text = formattedTime;
        }
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "TitleScreen") // Remove and clear timer if menu screen loaded
        {
            Destroy(gameObject);
        }

        // Set name of current level
        int sceneIndex = currentScene.buildIndex;
        string level = "LEVEL " + sceneIndex.ToString();
        levelText.text = level;
    }

    // Stop the timer
    public void StopTimer()
    {
        timerRunning = false;
        elapsedTime = 0.0f;
    }
}
