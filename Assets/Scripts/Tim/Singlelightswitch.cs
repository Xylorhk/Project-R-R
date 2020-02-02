// ToggleLight.cs
// Turns the light component of this object on/off when the user presses and releases the `L` key.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Singlelightswitch : MonoBehaviour
{
	public Room power;
	Light light;
	public GameObject[] requiredRepairs;

	private Toggle switchButton;
	// Use this for initialization
	void Start()
	{
		switchButton = gameObject.GetComponent<Toggle>();
		light = gameObject.GetComponentInChildren<Light>();
		if (power.isPowered == true)
		{
			light.color = Color.green;
			switchButton.isOn = true;
			
		}
		else
		{
			light.color = Color.red;
			switchButton.isOn = false;
		}
	}


	public void FlipPower()
	{
		if (!IsRestricted())
		{
			if (power.isPowered)
			{
				power.TogglePower();
				light.color = Color.red;
				switchButton.isOn = false;
				Debug.Log("Switch Occured off");
			}

			else
			{
				power.TogglePower();
				light.color = Color.green;
				switchButton.isOn = true;
				Debug.Log("Switch Occured on");
			}
		}

	}
	private bool IsRestricted()
	{
		foreach (GameObject repair in requiredRepairs)
		{
			if (!repair.GetComponent<ItemReceptical>().isRepaired) return true;
		}
		return false;
	}
}
