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

    public GameObject healItem;
    public GameObject powerUp;
    public GameObject speedUp;
    public GameObject expUp;

    List<GameObject> itemList;

    

    private GameObject findSpawnpoint;

    Vector3 enemyPos, itemPos;
    //Random random = new UnityEngine.Random();

    void Start(){
        itemList = new List<GameObject>();

        itemList.Add(healItem);
        itemList.Add(powerUp);
        itemList.Add(speedUp);
        itemList.Add(expUp);
    }
    
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
            spawnItems();

            AstarPath.active.Scan();
            //Debug.Log("Current Hardcap on Roomspawning is: " + roomSpawnCap);
        }
    }

    void spawnBoss(){
        Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
        //Debug.Log("Boss spawned at: " + rooms[rooms.Count - 1].transform.position);
        spawnedBoss = true;
        
        
    }

    void spawnMobs(){
        // Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
        //Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);

        int i = 0;
        int rc = rooms.Count - 1;
        foreach (var room in rooms)
        {
            if(i == 0 || i == rc){
                //Debug.Log("No ennemy in first and last room");
            }else{

                // random.NextDouble() * (maximum - minimum) + minimum;

                enemyPos = randomPosInRoom(room);

                //Debug.Log("Room position: " + room.transform.position.y);

                // Instantiate(enemy, room.transform.position, Quaternion.identity);
                Instantiate(enemy, enemyPos, Quaternion.identity);
            }
            i++;
        }
    }

    void spawnItems(){

        foreach (var room in rooms)
        {
            //Debug.Log("Spawning Items ###");
            //Debug.Log(itemList.Count + " Items in current List");


            float perc = UnityEngine.Random.Range(0.0f, 1.0f);
            //Debug.Log(perc);
            // random.NextDouble() * (maximum - minimum) + minimum;
            if(perc <= 0.05){
                int itemNumb = UnityEngine.Random.Range(0, itemList.Count);
                itemPos = randomPosInRoom(room);
                //Debug.Log("Room position: " + room.transform.position.y);
                // Instantiate(enemy, room.transform.position, Quaternion.identity);
                Instantiate(itemList[itemNumb], itemPos, Quaternion.identity);
            }
        }
    }

    public Vector3 randomPosInRoom(GameObject room){
        Vector3 positionInRoom;
        float rand_x = UnityEngine.Random.Range(-3, 3);
        float rand_y = UnityEngine.Random.Range(-3, 3);

        rand_x += room.transform.position.x;
        rand_y += room.transform.position.y;

        positionInRoom = new Vector3(rand_x, rand_y,0);
        return positionInRoom;
    }
}

