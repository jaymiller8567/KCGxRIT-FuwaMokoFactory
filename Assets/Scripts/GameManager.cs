using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas pauseMenu;
    public bool isPaused = false;
    public Canvas scoreText;
    public float timeLeft = 90;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.enabled = false;
        scoreText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            GameOver();
        }
    }

    void PauseGame()
    {
       // Time.timeScale = 0f;
        pauseMenu.enabled = true;
        scoreText.enabled = false;
        isPaused = true;
        Time.timeScale = 0f;
        Debug.Log("Game Paused!");
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.enabled = false;
        scoreText.enabled = true;
        isPaused = false;
        Debug.Log("Game Resumed!");
    } 

    public void GameOver()
    {
        // Game is over, proceed to next scene.
        Debug.Log("Time up!");
    }
}
