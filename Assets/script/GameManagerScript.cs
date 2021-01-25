using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState { gameMenu, gamePlay, gamePause, gameOver, gameVictory }

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField] public GameObject GameOverUI;
    [SerializeField] public GameObject VictoryUI;


    //GameState
    private GameState m_GameState;
    public bool IsPlaying { get { return m_GameState == GameState.gamePlay; } }
    public bool IsPaused { get { return m_GameState == GameState.gamePause; } }
    public bool IsGameover { get { return m_GameState == GameState.gameOver; } }
    public bool IsVictory { get { return m_GameState == GameState.gameVictory; } }

    private void Start()
    {
        m_GameState = GameState.gamePlay;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlaying)
        {
            DeactivateGameOver();
            DeactivateMenu();
            DeactivateVictory();
        }

        if (Input.GetKeyDown(KeyCode.Return) && IsPlaying) // press 'enter' to gameover
        {
            m_GameState = GameState.gameOver;

            if (IsGameover)
            {
                Time.timeScale = 0f; //pause all Gameobjects
                AudioListener.pause = true;

                GameOver();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && IsPlaying) // press 'echap' to pause menu
        {
            Time.timeScale = 0f; //pause all Gameobjects
            AudioListener.pause = true;

            ActivateMenu();
            m_GameState = GameState.gamePause;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused) 
        {
            DeactivateMenu();
        }

        if (Input.GetKeyDown(KeyCode.A) && IsPlaying) //press 'a' to victory
        {
            m_GameState = GameState.gameVictory;
            if (IsVictory)
            {
                Time.timeScale = 0f; //pause all Gameobjects
                AudioListener.pause = true;

                Victory();
            }
        }

    }

    void GameOver()
    {
        GameOverUI.SetActive(true);
    }

    public void DeactivateGameOver()
    {
        GameOverUI.SetActive(false);
        m_GameState = GameState.gamePlay;

    }

    void ActivateMenu()
    {
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        m_GameState = GameState.gamePlay;
    }

    void Victory()
    {
        VictoryUI.SetActive(true);
    }

    void DeactivateVictory()
    {
        VictoryUI.SetActive(false);
    }
    
    
    
    public void QuiGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        pauseMenuUI.SetActive(false);
        GameOverUI.SetActive(false);
        VictoryUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        m_GameState = GameState.gamePlay;
    }
}
