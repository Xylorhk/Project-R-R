using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
    //initial value of time = 5 min?
{
    private Text outPutText;
    public float doomCount = 300;
    const float fullOxygen = 120;
    public float timeLeft = fullOxygen;
    void Start()
    {
        outPutText = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        outPutText.text = timeLeft.ToString();
        timeLeft -= Time.deltaTime;
    }
    public void resetOxygen()
    {
        timeLeft = fullOxygen;
    }
}