using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBehavior_straight
{
    public void shoot(GameObject projectile, Vector2 direction, float speed)
    {
        projectile.GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }

}
