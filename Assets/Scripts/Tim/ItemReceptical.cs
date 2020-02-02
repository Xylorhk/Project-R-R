using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemReceptical : MonoBehaviour
{
    //Flag used to tell if the object can be interacted with or not.
    public bool isInteractable = false;

    public Item item;
    public Renderer rend;
    public Player player;
    public bool isRepaired;
    public bool found;
    public GameObject objectName;
    public Text withPart;
    public Text withoutPart;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        rend = GetComponent<Renderer>();
        //rend.enabled = true;
        //item.itemObject = gameObject;
        //objectName = GameObject.GetComponent<ReactorPart>();
    }
    void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.F))
        {
            isRepaired = true;
            Debug.Log("Interact");
        }
        //for testing purposes
        //Debug.Log("Interact");
    }
    /// <summary>
    /// Is called when there is an object that enters the collider's borders.
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("scanning");
        for (int i = 0; i < player.inventory.Length; i++)
        {
            if (player.inventory[i] == objectName)
            {
                player.inventory[i] = gameObject;
                found = true;
                break;
            }
            Debug.Log("Scanned");
            //Compares the tag of the object entering this collider.
            if (other.tag == "Player" && found == true)
            {
                //turns on interactivity 
                isInteractable = true;
                withPart.text = "press F to repair";
            }
            else
            {
                withoutPart.text = "Requires Reactor part to Repair";
            }
        }
    }
        /// <summary>
        /// Is called when there is an object that leaves the collider's borders.
        /// </summary>
        /// <param name="other"></param>
         void OnTriggerExit(Collider other)
        {
            //compares the tag of the object exiting this collider.
            if (other.tag == "Player")
            {
                //turns off interactivity 
                isInteractable = false;
            }
        }
    }