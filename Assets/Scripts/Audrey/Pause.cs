using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public void PauseGame()
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
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Defeat(bool trust)
    {
        PauseGame();
        transform.Find("ResumeButton").gameObject.SetActive(false);
        Text titleText = transform.Find("PauseText").GetComponent<Text>();

        if(trust == true)
        {
            titleText.text = "You Win!";
        }
        else
        {
            titleText.text = "You Lose";
        }
    }
}
