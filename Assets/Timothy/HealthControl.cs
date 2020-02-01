using UnityEngine;
using UnityEngine.UI;
public class HealthControl : MonoBehaviour
{
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
}
