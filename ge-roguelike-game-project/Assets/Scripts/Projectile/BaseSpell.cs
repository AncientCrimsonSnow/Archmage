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
    private shootBehavior _ShootBehavior;
    private void Start()
    {
        _ShootBehavior = gameObject.GetComponent<shootBehavior>();
    }

    public void Shoot(Transform firePoint)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        _ShootBehavior.shoot(projectile, firePoint.up, speed);
    }
}
