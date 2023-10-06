using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Playing,
    Paused
}

public class GameManager : MonoBehaviour
{
    public static GameState state = GameState.Playing;
    public GameObject pauseMenuUI;

    private void Start()
    {
        Resume();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (state)
            {
                case GameState.Playing:
                    Pause();
                    break;
                case GameState.Paused:
                    Resume();
                    break;
                default:
                    break;
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        state = GameState.Paused;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        state = GameState.Playing;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}