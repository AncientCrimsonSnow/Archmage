using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movespeed = 5f;

    public Rigidbody2D rb;
    //public Animator animator;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate()
    {
        //Learned almost everything from Brackeys Tutorials
        // Movement
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
        //Debug.Log("Player: " + rb.position);
        //Debug.Log("Mouse: " + mousePos);

        // Rotation
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        // Debug.Log("Angle: " + angle);
        // Debug.Log("RB Facing: " +  transform.rotation.eulerAngles.y);

        rb.rotation = angle;
    }
}
