using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private bool isShooting;

    public float bulletForce = 10f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            isShooting = true;
            Shoot();
        }else{
            isShooting = false;
        }

    }

    void Shoot()
    {
        // Create Bullet from prefab and add force
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
