using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseSpell : MonoBehaviour
{
    public String name;
    public GameObject projectilePrefab;
    public float speed;
    public string shootBehavior_x;
    private shootBehavior _ShootBehavior;



    public void Init()
    {
        //shotSource = GetComponent<AudioSource>();
        _ShootBehavior = new shootBehavior(shootBehavior_x);
    }
    public void Shoot(Transform firePoint)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        _ShootBehavior.shoot(projectile, firePoint.up, speed);
                    
        
        //shotSource.Play();
    }
}
