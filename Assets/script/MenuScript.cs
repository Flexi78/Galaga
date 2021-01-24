using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuUI;
    
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Time.timeScale = 0f; //pause all Gameobjects
            AudioListener.pause = true;

            ActivateMenu();
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;

            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void QuiGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
}
