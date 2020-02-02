using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSwitch : MonoBehaviour
{
	public LifeSupport power;
	Light light;
	public Player player;
	public bool switchPowered;

	void Start()
	{
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
	public void OnMouseDown()
	{
		if (switchPowered)
		{
			StartCoroutine("RefillOxygen");
			switchPowered = false;
			light.color = Color.red;
			Debug.Log("Switch Occured off");
		}
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
}