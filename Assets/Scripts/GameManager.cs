using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Canvas pauseMenu;
    public bool isPaused = false;
    public Canvas gameUI;
    public float timeLeft = 90;
    public GameObject timerText; 

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.enabled = false;
        gameUI.enabled = true;
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

        if (!isPaused) { 
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                GameOver();
            }
        }

        timerText.GetComponent<TextMeshProUGUI>().text = timeLeft.ToString("F0");
    }

    void PauseGame()
    {
       // Time.timeScale = 0f;
        pauseMenu.enabled = true;
        gameUI.enabled = false;
        isPaused = true;
        Time.timeScale = 0f;
        Debug.Log("Game Paused!");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.enabled = false;
        gameUI.enabled = true;
        isPaused = false;
        Debug.Log("Game Resumed!");
    } 

    public void GameOver()
    {
        // Game is over, proceed to next scene.
        Debug.Log("Time up!");
        SceneManager.LoadScene("EndScreen");
    }
}
