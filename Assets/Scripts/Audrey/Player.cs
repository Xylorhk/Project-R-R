using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public Inventory inventory;

    #region Variable Initialization

    public GameObject player;
    public float moveSpeed, rotationSpeed = 2, gravity = 100, oxygenDepletionRate;
    const float TotalHealth = 100;
    public static float currentHealth;
    private float oxygen = 100, cameraY, cameraX;
    private Vector3 moveDirection;
    private CharacterController charController;
    private Transform playerTrans, cameraTrans;


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

    public void Damage(float deltaHealth)
    {
        currentHealth -= deltaHealth;
        if (currentHealth <= 0 | oxygen <= 0)
        {
            GameOver();
        }
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
