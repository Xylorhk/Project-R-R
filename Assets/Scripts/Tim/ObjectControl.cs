using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectControl : MonoBehaviour
{
    //Flag used to tell if the object can be interacted with or not.
    public bool isInteractable = false;


    void Update()
    {
        //Checks if the player is in the collider and also if the key is pressed.
        if (isInteractable && Input.GetKeyDown(KeyCode.F))
        {
            
            Debug.Log("Interact");
        }
    }

    /// <summary>
    /// Is called when there is an object that enters the collider's borders.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //Compares the tag of the object entering this collider.
        if (other.tag == "Player")
        {
            //turns on interactivity 
            isInteractable = true;
            print("Press F to pick up");
        }
    }
    /// <summary>
    /// Is called when there is an object that leaves the collider's borders.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        //compares the tag of the object exiting this collider.
        if (other.tag == "Player")
        {
            //turns off interactivity 
            isInteractable = false;
        }
    }
}