using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int damageAmount = 10;

        if (collision.CompareTag("Boss"))
        {
            Destroy(gameObject);

        }else if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if(enemy != null){
                enemy.takeDamage(damageAmount);
                Destroy(gameObject);
            }

        }else if(collision.CompareTag("Wall")){
            Destroy(gameObject);
        }
    }
}
