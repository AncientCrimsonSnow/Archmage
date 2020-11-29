using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movespeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    void Start(){
        gameObject.tag = "Player";
    }

    // Used for registring input
    // Update is called once per frame
    void Update()
    {
        // Input
        // If pressed send 1 else 0
        // Working with WASD and arrow keys, aswell as controller
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Dont do physics calculation in Update but rather in FixedUpdate
    // Called on a fixed time (50 times a second)
    void FixedUpdate()
    {
        //Learned almost everything from Brackeys Tutorials
        // Movement
        // moves the Rigidbody to the new position + movement times moveSpeed times Time
        // Amount of time since function was called
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);

        // Rotation
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        rb.rotation = angle;
    }
}
