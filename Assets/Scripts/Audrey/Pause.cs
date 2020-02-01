using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;   
    void Awake()
    {
        if (!pauseMenu) pauseMenu = GameObject.Find("Menu_Pause");
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!pauseMenu.activeSelf)
            {
                PauseGame();
                
            }
            else
            {
                ResumeGame();
            }
        }
    }
    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void ReturnMenu()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Menu");
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
