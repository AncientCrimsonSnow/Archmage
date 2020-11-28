using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // TODO: add variable damage
    // Pass it ProcessPlayerDeath() after editing the method to ProcessPlayerDeath(int/float damage) in GameSession script
    public float damageTimeout = .2f;
    private bool canTakeDamage = true;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canTakeDamage && other.CompareTag("Player"))
        {
            FindObjectOfType<GameSession>().ProcessPlayerDeath();

            StartCoroutine(damageTimer());
        }
    }


    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }
}
