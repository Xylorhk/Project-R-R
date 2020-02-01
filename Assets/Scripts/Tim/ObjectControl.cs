using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    //Flag used to tell if the object can be interacted with or not.
    public bool isInteractable = false;


    void Update()
    {
        //Checks if the player is in the collider and also if the key is pressed.
        if (isInteractable && Input.GetKeyDown(KeyCode.F))
        {
            //personalized code can go in here when activated.
            //power on/timer pause
            //call function
            //play audio "Power Restored"(function)
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