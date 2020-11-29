using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Movement : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;


    public float bulletForce = 10f;
    public float movespeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 noMovement = new Vector2(0, 0);
    Vector2 mousePos;

    Animator anim;

    void Start(){
        gameObject.tag = "Player";
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetButtonDown("Fire1")){
            anim.SetBool("isShooting", true);
            Shoot();
        }else{
            anim.SetBool("isShooting", false);
        }


        if(movement.Equals(noMovement)){
            //Debug.Log("Idling");
            anim.SetBool("isWalking", false);
        }else{
            anim.SetBool("isWalking", true);
        }
    }

    void FixedUpdate()
    {

        //Learned almost everything from Brackeys Tutorials
        // Movement
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
        // Rotation
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        rb.rotation = angle;

    }

    void Shoot()
    {
        // Create Bullet from prefab and add force
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
