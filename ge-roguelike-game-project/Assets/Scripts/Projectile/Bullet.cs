using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int damageAmount = GameObject.Find("Player").GetComponent<Player_Controller>()._charDataController._CharData.Strength; 
        //Debug.Log(damageAmount);
        Enemy enemy = collision.GetComponent<Enemy>();

        Debug.Log("Hit enemy " + collision.tag);
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
