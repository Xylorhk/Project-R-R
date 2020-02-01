using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
    //initial value of time = 10 min?
{
    private Text outPutText;
    public double timeLeft = 120;
    void Start()
    {
        outPutText = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        outPutText.text = timeLeft.ToString();
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            //GameOver(); // ends game
        }
    }
}