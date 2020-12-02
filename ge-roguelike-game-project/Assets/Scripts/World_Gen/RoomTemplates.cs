using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RoomTemplates : MonoBehaviour
{
    /*
     * Index 0:
     *     closeup
     *     1-0
     * Index 1-3:
     *     1-1
     * Index 4-7
     *     1-2
     */
    public GameObject[] topRooms;
    public GameObject[] botRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRooms;
    public List<GameObject> rooms;

    public bool spawning = true;
    private bool spawnedBoss = false;
    public GameObject boss;

    private GameObject findSpawnpoint;
    
    private void Update()
    {
        findSpawnpoint = GameObject.FindWithTag("Spawnpoint");
        if (findSpawnpoint is null)
        {
            spawning = false;
        }
        
        if (!spawning && !spawnedBoss)
        {
            Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            spawnedBoss = true;
            AstarPath.active.Scan();
        }
    }
}

