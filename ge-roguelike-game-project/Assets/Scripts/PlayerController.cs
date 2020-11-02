using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;


    public Vector3 location;
    public PlayerActionscript controls;
    private GameObject player;
    public Rigidbody2D rb;


    void Awake(){
        
        speed = 1f;
        controls = new PlayerActionscript();
        rb = new Rigidbody2D();
        player = GameObject.Find("Player");

        controls.Player.Fire.performed += _ => Fire();
        controls.Player.Move.performed += context => Move(context.ReadValue<Vector2>());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Fire(){
        Debug.Log("Bzzz~~");
    }

    void Move(Vector2 direction){
        Debug.Log("Palyer wants to move");

        //position = rb.position;
        //Vector3 location = new Vector3(0,0,0);

        //location += new Vector3(1,0,0) * speed * Time.deltaTime;

        //Debug.Log("Player wants to move in direction " + direction);
        //Debug.Log("Position:" + location);
        // Read Move Value
        //var moveInput = controls.Player.Move.ReadValue<Vector2>();

        //rb.MovePosition(rb.position + moveInput * speed * Time.deltaTime);
       // player.AddForce(moveInput * speed * Time.deltaTime);
        //player.translate(new Vector2(0, 1) * speed * Time.deltaTime);
        // Move Player
        //position += moveInput * speed * Time.deltaTime;
    }

    public void OnEnable(){
        controls.Enable();
    }

    public void OnDisable(){
        controls.Disable();
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public PlayerActionscript controls;

    void Awake(){
        controls.Player.Fire.performed += _ => Fire();
        controls.Player.Move.performed += context => Move();
    }

    void Fire(){
        Debug.Log("Bzzz~~");
    }

    void Move(){
        Debug.Log("Player wants to move");
    }

    public void OnEnable(){
        controls.Enable();
    }

    public void OnDisable(){
        controls.Disable();
    }
}

*/