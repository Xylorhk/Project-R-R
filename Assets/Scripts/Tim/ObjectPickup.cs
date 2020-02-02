using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPickup : MonoBehaviour
{
    //Flag used to tell if the object can be interacted with or not.
    public bool isInteractable = false;

    public Item item;
    public Renderer rend;
    public Player player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        //item.itemObject = gameObject;
    }
    public void OnMouseDown()
    {
        //Inventory.AddItem(item);
        for (int i = 0; i < player.inventory.Length; i++)
        {
            if (player.inventory[i] == null)
            {
                player.inventory[i] = gameObject;
                //for possible sprites later
                //itemImages[i].sprite = itemToAdd.sprite;
                //itemImages[i].enabled = true;
                break;
            }
        }
        rend.enabled = false;
        //for testing purposes
        //Debug.Log("Interact");
    }
    /// <summary>
    /// Is called when there is an object that enters the collider's borders.
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        //Compares the tag of the object entering this collider.
        if (other.tag == "Player" && rend.enabled == true)
        {
            //turns on interactivity 
            isInteractable = true;
            print("point at object and click left mouse");
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