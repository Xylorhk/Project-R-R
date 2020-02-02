using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemReceptical : MonoBehaviour
{
    public bool isInteractable = false;
    public bool hasPart = false;
    public bool needsPart = false;
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
        withPart.enabled = false;
        withoutPart.enabled = false;
        //rend.enabled = true;
        //item.itemObject = gameObject;
        //objectName = GameObject.GetComponent<ReactorPart>();
    }
    void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.F))
        {
            withPart.enabled = false;
            isRepaired = true;
            Debug.Log("Interact");
        }
    }
    
    // Is called when there is an object that enters the collider's borders.
    public void OnTriggerEnter(Collider other)
    {
        if(!isRepaired)
        {
            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i] == objectName)
                {
                    player.inventory[i] = gameObject;
                    found = true;
                    break;
                }
            }
        }
        Debug.Log("scanning");
        
            Debug.Log("Scanned");
            //Compares the tag of the object entering this collider.
            if (other.tag == "Player" && found == true)
            {
                //turns on interactivity 
                isInteractable = true;
                hasPart = true;
                withPart.enabled = true;

        }
            else
            {
                withoutPart.enabled = true;
            }
    }
        
        // Is called when there is an object that leaves the collider's borders.
         void OnTriggerExit(Collider other)
        {
            //compares the tag of the object exiting this collider.
                //turns off interactivity 
                isInteractable = false;
                withPart.enabled = false;
                withoutPart.enabled = false;


        }
    }