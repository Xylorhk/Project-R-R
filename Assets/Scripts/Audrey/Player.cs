using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    #region Variable Initialization

    public GameObject player;
    public float moveSpeed,rotationSpeed = 2, gravity = 100, health = 100, oxygenDepletionRate;

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
        cameraTrans = playerTrans.Find("Player Camera").GetComponent<Transform>();
        cameraX = 0f;
        cameraY = 0f;
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
        health -= deltaHealth;
        if (health <= 0 | oxygen <= 0)
        {
            GameOver();
        }
    }

    public void Heal( float deltaHealth)
    {
        if (health < 100)
        {
            health += deltaHealth;
        }
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        

    }

    public void Victory()
    {

    }
}
