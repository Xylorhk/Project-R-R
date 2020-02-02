using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comms : MonoBehaviour
{
    [Header("Flags")]
    [Tooltip("Whether or not the room is powered.")]
    public bool isPowered;
    [Tooltip("When true, provides oxygen while room is powered")]
    public bool providesOxygen = false;
    [Tooltip("When true, always provides oxygen to the player regardless of providesOxygen setting")]
    public bool alwaysBreathable = false;
    [Header("GameObjects")]
    [Tooltip("All doors this room's power toggle will control")]
    public GameObject[] doors = new GameObject[3];
    [Tooltip("Whatever should be spawned after power is cut.")]
    public GameObject monster;
    [Header("Modifiers")]
    [Tooltip("How long to wait before activating the Monster")]
    public float timeUntilSpawn;
    [Tooltip("Amount to scale damage to the Player by.")]
    public float damageScale = 1;
    [Header("Additional Options")]
    [Tooltip("Script to execute when the Player first enters this room.")]
    public Component scriptedEvent;

    private float timeSincePowered;
    private bool powerState;
    private int timesToggled;
    private Player player;
    void Start()
    {
        if (!isPowered) monster.SetActive(false);
        powerState = isPowered;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPowered != powerState)
        {
            //TogglePower();
        }
        if (isPowered & timeSincePowered > 0f)
        {
            timeSincePowered = 0f;
            monster.SetActive(false);
        }
        if (!isPowered)
        {
            timeSincePowered += Time.deltaTime;

        }
        if (timeSincePowered >= timeUntilSpawn)
        {
            monster.SetActive(true);
        }
    }

    public void TogglePower()
    {
        isPowered = !isPowered;
        ToggleDoors();
        if (timesToggled < 1) TriggerEvent();
        timesToggled++;
        if (isPowered & providesOxygen)
        {
            player.globalOxygen = true;
        }
        else if (!isPowered & providesOxygen) player.globalOxygen = false;
    }
    void ToggleDoors() //Toggles state of all doors connected to this room.
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(!door.activeSelf);
        }
    }

    public void DamagePlayer(Transform playerPosition) //Calculates and applies damage from monster
    {
        float damage = (timeSincePowered - timeUntilSpawn) * damageScale;
        float damageMultiplier = Vector3.Distance(playerPosition.position, monster.transform.position) / 100;
        Mathf.Clamp(damageMultiplier, 0.1f, 1f);
        player.Damage((damage * damageMultiplier) * Time.deltaTime);
        Debug.Log(damage * damageMultiplier);
    }

    private void TriggerEvent()
    {

    }

    public void IsPowered(bool powered)
    {
        isPowered = powered;
    }
    public void switchPower()
    {
        isPowered = !isPowered;
    }
}
