using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageTest : MonoBehaviour
{
    
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
    /// Is called when there is an object that enters the collider's borders. deals damage
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerStay(Collider other)
    {
        //Compares the tag of the object entering this collider.
        if (other.tag == "Player")
        {
            Debug.Log("trigger");
            //take player health
            TakeDamage(1);
            Debug.Log(currentHealth);

        }
   
    }
}