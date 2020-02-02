using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderAnims : MonoBehaviour
{

    public Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //compares the tag of the object exiting this collider.
        if (other.tag == "Player")
        {
            Animator.SetBool("EnterScene", true);
        }
    }
}
