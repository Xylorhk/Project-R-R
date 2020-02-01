using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageTest : MonoBehaviour
{
    //Flag used to tell if the object can be interacted with or not.
    public bool isInteractable = false;

    public Slider HealthBar;
    public float Health = 100;

    private float currentHealth;

    void Start()
    {
        currentHealth = Health;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthBar.value = currentHealth;
    }
    void Update()
    {
        //Checks if the player is in the collider and also if the key is pressed.
        if (isInteractable)
        {
            //personalized code can go in here when activated.
            //power on/timer pause
            //call function
            //play audio "Power Restored"(function)
            Debug.Log("Damage");
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
            //take player health
            TakeDamage(5);
            Debug.Log("5");
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