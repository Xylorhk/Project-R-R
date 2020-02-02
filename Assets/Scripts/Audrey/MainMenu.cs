using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject optionsMenu, creditsMenu, mainMenu;
    void Start()
    {
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);

        Time.timeScale = 1f;
    }

   public void StartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(currentScene);
    }
   public void GoToOptions()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
   public void GoToCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
   public void GoToMain()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }
   public void ExitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
