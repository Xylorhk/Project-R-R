using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Flags")]
    [Tooltip("Whether or not the room is powered.")]
    public bool isPowered;
    [Tooltip("When true, provides oxygen while room is powered")]
    public bool providesOxygen = false;
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
            isPowered = !isPowered;
            ToggleDoors();
            if (timesToggled < 1) TriggerEvent();
            timesToggled++;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" & monster.activeSelf)
        {
            DamagePlayer();
        }
    }
    void ToggleDoors() //Toggles state of all doors connected to this room.
    {
        foreach (GameObject door in doors)
            {
            door.SetActive(!door.activeSelf);
        }
    }


    protected void DamagePlayer()
    {
        float damage = (timeSincePowered - timeUntilSpawn) * damageScale;
        player.Damage(damage);
    }
    void TriggerEvent()
    {
        
    }
}
