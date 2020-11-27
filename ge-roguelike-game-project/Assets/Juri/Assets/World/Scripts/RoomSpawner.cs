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
    
    
    private float softCap = 50;
    private float hardCap = 100;
    
    private float waitTime = 5;
    private float distanceToSpawn_Pow;
    
    void Start()
    {
        distanceToSpawn_Pow = transform.position.x * transform.position.x + transform.position.y * transform.position.y;
        Destroy(gameObject, waitTime);
        templates = GameObject.Find("Room Templates").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.5f);
    }
    void Spawn()
    {
        if (!spawned)
        {
            rand = UnityEngine.Random.Range(0, templates.botRooms.Length);
            
            if (distanceToSpawn_Pow > softCap * softCap)
            {
                if (distanceToSpawn_Pow > hardCap * hardCap)
                {
                    rand = 0;
                }
                else if (rand >= 4)
                {
                    rand = rand - 4;
                }
            }
            else
            {
                if(rand < 4)
                    rand = rand + 3;
            }
            Debug.Log(softCap);
            Debug.Log(hardCap);
            
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
