using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinLose : MonoBehaviour
{
    //Variable Initialization goes here

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().enabled = false;
    }

    //Player's health is 0 || Player's oxygen is 0
    //void Update()
    //{
       // if ()
      //  {
       //     GetComponent<Text>().enabled = true;
       //     GetComponent<Text>().text = "You Lose";
         //   Time.timeScale = 0;
      //      Pause.pauseMenu.PauseGame();
      //  }

     //   else if(/*All rooms are repaired && Warp drive is activated*/)
      //  {
      //      GetComponent<Text>().enabled = true;
      //      GetComponent<Text>().text = "You Win!";
      //      Time.timeScale = 0;
      //      Pause.pauseMenu.PauseGame();
      //  }
  //  }
}

