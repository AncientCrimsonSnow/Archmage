using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int damageAmount = 10;
                    Enemy enemy = collision.GetComponent<Enemy>();

        if (collision.CompareTag("Boss"))
        {


            if(enemy != null){
                enemy.takeDamage(damageAmount);
                Destroy(gameObject);
            }
        }else if (collision.CompareTag("Enemy"))
        {


            if(enemy != null){
                enemy.takeDamage(damageAmount);
                Destroy(gameObject);
            }

        }else if(collision.CompareTag("Wall")){
            Destroy(gameObject);
        }
    }
}
