using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class shootBehavior : MonoBehaviour
{
    public String _shootBehavior;
    
    public void shoot(GameObject projectile, Vector2 direction, float speed)
    {
        switch (_shootBehavior)
        {
            case "straight":
                shootBehavior_straight _shootBehaviorStraight = new shootBehavior_straight();
                _shootBehaviorStraight.shoot(projectile, direction, speed);
                break;
            default:
                Debug.Log(_shootBehavior + " is not an shootBehavior");
                break;
        }
    }
}
