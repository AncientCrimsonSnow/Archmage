using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //0 --> need top door
    //1 --> need bot door
    //2 --> need left door
    //3 --> need right door

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    public float waitTime;

    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.Find("Room Templates").GetComponent<RoomTemplates>();
        Invoke("Spawn", 1f);
    }
    void Spawn()
    {
        if (!spawned)
        {
            
            rand = UnityEngine.Random.Range(0, templates.botRooms.Length);
            switch (openingDirection)
            {
                case 0:
                    //need an TOP door
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    break;
                case 1:
                    //need an BOT door
                    Instantiate(templates.botRooms[rand], transform.position, templates.botRooms[rand].transform.rotation);
                    break;
                case 2:
                    //need an LEFT door
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                    break;
                case 3:
                    //need an RIGHT door
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                    break;
                default:
                    break;
            }
            spawned = true; 
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spawnpoint"))
        {
            if (!other.GetComponent<RoomSpawner>().spawned && !spawned)
            {
                Instantiate(templates.closedRooms, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            spawned = true;
        }
    }
}
