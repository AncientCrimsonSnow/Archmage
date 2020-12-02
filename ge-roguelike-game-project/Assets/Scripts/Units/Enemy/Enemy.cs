using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // TODO: add variable damage
    // Pass it ProcessPlayerDeath() after editing the method to ProcessPlayerDeath(int/float damage) in GameSession script
    public float damageTimeout = .2f;
    private bool canTakeDamage = true;

    public int enemyDamage = 10;

    public int enemyHealth = 100;

    // When the object holding the script enemy collides with another object this whill be triggered
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player coountdown for receiving damage is true and the hit object holds the tag player the 
        // damage will be parsed to the player and the countdown set to false
        if (canTakeDamage && other.CompareTag("Player"))
        {
            FindObjectOfType<GameSession>().ProcessPlayerDeath(enemyDamage);
            StartCoroutine(damageTimer());
        }
    }

    // the damage an enemy receives from a hero will be subtracted here
    // the calculation can be extended 
    public void takeDamage(int damage){
        enemyHealth -= damage;

        if(enemyHealth <= 0){
            Die();
        }
    }

    // when called, the die function destroys the object from the scene and if it was a Boss 
    // it will trigger the loading of the next level
    void Die(){
        Destroy(gameObject);

        if(gameObject.name == "BossMonster"){
            StartCoroutine(FindObjectOfType<LevelExit>().LoadNextLevel());
        }
    }


    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }
}