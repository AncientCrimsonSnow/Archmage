using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lookDir;
    private Vector2 mousePos;
    private float angle;
    public bool isWalking;

    public Movement_Controller(Rigidbody2D rb)
    {
        this.rb = rb;
    }

    public void move(float speed, Camera cam)
    {
        //position
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        
        isWalking = !(movement.x == 0 && movement.y == 0);
        
        
        //direction
        lookDir = getMouseVector(cam);
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    public Vector2 getMouseVector(Camera cam)
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        return mousePos - rb.position;
    }
}
