using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    Light[] lights;
    bool isLightOn = false;
    string lightName = "DeckLight";
    public float offIntensity = 0.0f, onIntensity = 3.0f;

    void Start()
    {
        lights = GetComponentInChildren<Light[]>();
        //Debug.Log(lights.length);
        foreach (Light light in lights)
        {
            if (light.name == lightName)
            {
                light.intensity = offIntensity;
            }
        }
    }
    private void OnMouseDown()
    {
        isLightOn = !isLightOn;

        if (isLightOn)
        {
            foreach (Light light in lights)
            {
                if (light.name == lightName)
                {
                    light.intensity = onIntensity;
                }
            }
        }
        else
        {
            foreach (Light light in lights)
            {
                if (light.name == lightName)
                {
                    light.intensity = offIntensity;
                }
            }
        }
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
