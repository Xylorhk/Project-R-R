using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenSwitch : MonoBehaviour
{
	public LifeSupport power;
	Light light;
	public Player player;
	public bool switchPowered;
	public bool isInteractable = true;
	public Text Interact;

	void Start()
	{
		Interact.enabled = false;
		light = gameObject.GetComponentInChildren<Light>();
		if (switchPowered == true)
		{
			light.color = Color.blue;
		}
		else
		{
			light.color = Color.red;
		}
	}
	void Update()
	{
		if (isInteractable && Input.GetKeyDown(KeyCode.F))
		{
			//withPart.enabled = false;
			if (switchPowered)
			{
				StartCoroutine("RefillOxygen");
				switchPowered = false;
				light.color = Color.red;
				Debug.Log("Switch Occured off");
				Debug.Log("Interact");
			}
		}
		//for testing purposes
		//Debug.Log("Interact");
	}
	private IEnumerable RefillOxygen()
	{
		player.replenishOxygen();
		if (player.globalOxygen)
		{
			yield return new WaitForSeconds(15f);
		}
		else
		{
			yield return new WaitForSeconds(45f);
		}
		light.color = Color.blue;
		switchPowered = true;
	}
	void OnTriggerExit(Collider other)
	{
		//compares the tag of the object exiting this collider.
			//turns off interactivity 
			isInteractable = false;
			Interact.enabled = false;
	}
}