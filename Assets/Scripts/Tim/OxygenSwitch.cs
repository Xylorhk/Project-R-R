using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenSwitch : MonoBehaviour
{
	public LifeSupport power;
	Light[] lights;
	public Player player;
	public bool switchPowered;
	public bool isInteractable = true;
	public Text Interact;
	void Start()
	{
		switchPowered = true;
		lights = gameObject.GetComponentsInChildren<Light>();
		Interact.enabled = false;
		if (switchPowered == true)
		{
			foreach (Light light in lights)
			{
				light.color = Color.blue;
				light.intensity = 200000;
			}
		}
		else
		{
			foreach (Light light in lights)
			{
				light.color = Color.red;
				light.intensity = 100000;
			}
		}
	}
	void Update()
	{
		if (isInteractable && Input.GetKeyDown(KeyCode.F))
		{
			if (switchPowered)
			{
				Debug.Log("Working");
				switchPowered = false;
				foreach (Light light in lights)
				{
					light.color = Color.red;
					light.intensity = 100000;
				}
				Debug.Log("Switch Occured off");
				Debug.Log("Interact");
				StartCoroutine("RefillOxygen");
			}
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		isInteractable = true;
		Interact.enabled = true;
	}
	private IEnumerable RefillOxygen()
	{
		player.replenishOxygen();
		Debug.Log("Interact");
		if (player.globalOxygen)
		{
			yield return new WaitForSeconds(15f);
		}
		else
		{
			yield return new WaitForSeconds(45f);
		}
		foreach (Light light in lights)
		{
			light.color = Color.blue;
			light.intensity = 200000;
		}
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