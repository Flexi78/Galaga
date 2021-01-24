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
            Time.timeScale = 0f; //pause of all Gameobjects
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

    /*void OnGUI()
    {
        if (isPaused)
        {
            // Si on clique sur le bouton alors isPaused devient faux donc le jeu reprend
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 80, 40), "Continuer"))
            {
                isPaused = false;
            }
            // Si on clique sur le bouton alors on ferme completment le jeu ou on charge la scene Menu Principal
            // Dans le cas du bouton Quitter, il faut augmenter sa position Y pour qu'il soit plus bas.
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Quitter"))
            {
                Application.Quit(); // Ferme le jeu
                Application.LoadLevel("Menu Principal"); // Charge le menu principal
            }
        }
    }*/

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
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(0);
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
}
