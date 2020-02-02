// ToggleLight.cs
// Turns the light component of this object on/off when the user presses and releases the `L` key.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSwitch : MonoBehaviour
{
	public LifeSupport power;
	Light light;
	public Player player;


	// Use this for initialization
	void Start()
	{
		light = gameObject.GetComponentInChildren<Light>();
		if (power.isPowered == true)
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
		if (power.isPowered)
		{
			player.replenishOxygen()
			power.TogglePower();
			light.color = Color.red;
			Debug.Log("Switch Occured off");
		}

		else
		{
			power.TogglePower();
			light.color = Color.blue;
			Debug.Log("Switch Occured on");
			Debug.Log(power.isPowered);
		}
	}
}