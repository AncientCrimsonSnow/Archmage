using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    AudioSource hitSound;

    void Awake(){
        hitSound = GetComponent<AudioSource>();
    }

    void Start(){

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        hitSound.Play();

        int damageAmount = GameObject.Find("Player").GetComponent<Player_Controller>()._charDataController._CharData.Strength; 
        //Debug.Log(damageAmount);
        Enemy enemy = collision.GetComponent<Enemy>();

        //hitSource.Play();

        //Debug.Log("Hit enemy " + collision.tag);

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
