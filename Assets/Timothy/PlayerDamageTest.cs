using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageTest : MonoBehaviour
{
    //Flag used to tell if the object can be interacted with or not.
    //public bool isInteractable = false;
    public float TestDamage;
    public Slider HealthBar;
    public float Health = 100;

    public float currentHealth;

    void Start()
    {
        currentHealth = Health;
    }
    
    public void TakeDamage(float damage)
    {
        damage = TestDamage;
        currentHealth -= damage;
        //HealthBar.value = currentHealth;
    }
    
    /// <summary>
    /// Is called when there is an object that enters the collider's borders.
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerStay(Collider other)
    {
        //Compares the tag of the object entering this collider.
        if (other.tag == "Player")
        {
            Debug.Log("trigger");
            //turns on interactivity 
            //isInteractable = true;
            //take player health
            TakeDamage(5);
            Debug.Log(currentHealth);

        }
   
    }
}