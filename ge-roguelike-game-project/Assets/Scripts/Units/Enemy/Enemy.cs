using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damageTimeout = .2f;
    private bool canTakeDamage = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canTakeDamage && other.CompareTag("Player"))
        {
            Debug.Log("Collisiooooon");
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
