using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereItem : MonoBehaviour 
{
    IInventoryItem itemI;
    public string Name
    {
        get
        {
            return "Sphere";
        }
    }

    public Sprite _Image;

    public Sprite Image
    {
        get { return _Image; }
    }

    public abstract void OnPickup()
    {
        gameObject.SetActive(false);
    }
}
