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
    public GameObject enemy;

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
            
            spawnBoss();
            spawnMobs();
            AstarPath.active.Scan();
        }
    }

    void spawnBoss(){
        Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
        Debug.Log("Boss spawned at: " + rooms[rooms.Count - 1].transform.position);
        spawnedBoss = true;
    }

    void spawnMobs(){
        // Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
        //Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);

        int i = 0;
        foreach (var room in rooms)
        {
            if(i == 0 || i == rooms.Count){
                Debug.Log("No ennemy in first and last room");
            }else{
                Instantiate(enemy, room.transform.position, Quaternion.identity);
                Debug.Log("Enemies spawned");
            }

            i++;
        }
    }

    void spawnItems(){

    }
}

