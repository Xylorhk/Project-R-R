using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public Inventory inventory;

    #region Variable Initialization

    public GameObject player;
    public float moveSpeed, rotationSpeed = 2, gravity = 100, oxygenDepletionRate = 35, oxygenReplenishRate = 50;
    const float TotalHealth = 100;
    public static float currentHealth, currentOxygen;

    private float cameraY, cameraX;
    private Vector3 moveDirection;
    private CharacterController charController;
    private Transform playerTrans, cameraTrans;
    public bool globalOxygen;


    #endregion
    void Start()
    {
        charController = gameObject.GetComponent<CharacterController>();
        player = this.gameObject;
        playerTrans = player.GetComponent<Transform>();
        cameraTrans = playerTrans.Find("Player Camera");
        cameraX = 0f;
        cameraY = 0f;
        currentHealth = TotalHealth;
        currentOxygen = 100;
        
    }


    void FixedUpdate()
    {
        #region Character Movement
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection = playerTrans.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;
        moveDirection.y -= (gravity * 2) * Time.deltaTime; 
        
        charController.Move(moveDirection * Time.deltaTime);
        #endregion
        #region Character Look
        cameraX += Input.GetAxis("Mouse X")* rotationSpeed;
        cameraY += Input.GetAxis("Mouse Y") * rotationSpeed;
        cameraY = Mathf.Clamp(cameraY, -90, 90);
        cameraTrans.localRotation = Quaternion.Euler(-cameraY, 0.0f, 0.0f);
        playerTrans.rotation = Quaternion.Euler(0f, cameraX, 0f);
        #endregion
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RoomLocation")
        {
            if (!globalOxygen & !other.gameObject.GetComponentInParent<Room>().alwaysBreathable)
            {
                Damage(-oxygenDepletionRate * Time.deltaTime);
            }
            else if (globalOxygen | other.gameObject.GetComponentInParent<Room>().alwaysBreathable)
            {
                AdjustAir(oxygenReplenishRate * Time.deltaTime);
            }

        } 
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            
            other.SendMessageUpwards("DamagePlayer", playerTrans);
            
        }
    }

    public void Damage(float deltaHealth)
    {
        currentHealth -= deltaHealth;
        Debug.Log("Current Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }
    public void AdjustAir(float deltaOxygen)
    {
        currentOxygen += deltaOxygen;
    }

    public void Heal( float deltaHealth)
    {
        if (currentHealth < 100)
        {
            currentHealth += deltaHealth;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        

    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }

    public void Victory()
    {

    }
}
