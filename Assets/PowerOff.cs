using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOff : StateMachineBehaviour
{
    public GameObject observationRoom;

    private void OnTriggerEnter(Collider other)
    {
        //compares the tag of the object exiting this collider.
        if (other.tag == "Player")
        {
            observationRoom.GetComponent<Room>().isPowered = false;
        }
    }
}
