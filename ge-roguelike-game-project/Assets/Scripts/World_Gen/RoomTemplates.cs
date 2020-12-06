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

    Vector3 enemyPos;
    //Random random = new UnityEngine.Random();
    
    private void Update()
    {
        //float roomspawner = gameObject.GetComponent<RoomSpawner>().hardCap;
        //float roomSpawnCap = roomspawner.hardCap;
        //Debug.Log(roomspawner);

        findSpawnpoint = GameObject.FindWithTag("Spawnpoint");
     
        if (findSpawnpoint is null)
        {
            spawning = false;
        }
        
        if (!spawning && !spawnedBoss)
        {
            /* This holds all graph data
            AstarData data = AstarPath.active.data;

            // This creates a Grid Graph
            GridGraph gridGraph = data.AddGraph(typeof(GridGraph)) as GridGraph;


            int width = 100;
            int height = 100;
            float nodeSize = 0.3f;

            gridGraph.SetDimensions(width, height, nodeSize);

            */
            
            spawnBoss();
            spawnMobs();

            AstarPath.active.Scan();
            //Debug.Log("Current Hardcap on Roomspawning is: " + roomSpawnCap);
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
        int rc = rooms.Count - 1;
        foreach (var room in rooms)
        {
            if(i == 0 || i == rc){
                Debug.Log("No ennemy in first and last room");
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

    }

    public Vector3 randomPosInRoom(GameObject room){
        Vector3 positionInRoom;
        float rand_x = UnityEngine.Random.Range(-4, 4);
        float rand_y = UnityEngine.Random.Range(-4, 4);

        rand_x += room.transform.position.x;
        rand_y += room.transform.position.y;

        positionInRoom = new Vector3(rand_x, rand_y,0);
        return positionInRoom;
    }
}

