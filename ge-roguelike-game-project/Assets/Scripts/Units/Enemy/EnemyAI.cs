using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public Transform target2;
    
    public GameObject player;

    public bool loading;

    public int range;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.FindWithTag("Player");
        target2 = player.transform;

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

    }

    void UpdatePath(){
        if(seeker.IsDone()){
            //  Enemy Position, Target Position Calback Funtion
            seeker.StartPath(rb.position, target2.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p){
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        loading = GameObject.Find("Canvas").GetComponent<GameSession>().loading;
        float distanceToPlayer = Vector2.Distance (target2.transform.position, rb.transform.position);

        //Debug.Log("The distance to the player is " + distanceToPlayer);

        if(distanceToPlayer < range){

            if(path == null)
                return;
        
            if(currentWaypoint >= path.vectorPath.Count){
                reachedEndOfPath = true;
                return;
            } else{
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            if (!loading)
            {
                rb.AddForce(force);
            }
            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if(distance < nextWaypointDistance){
                currentWaypoint++;
            }
        }
    }
}
