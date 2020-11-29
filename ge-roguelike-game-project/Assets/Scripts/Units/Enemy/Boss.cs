using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //condition if health 0 then ..
        StartCoroutine(FindObjectOfType<LevelExit>().LoadNextLevel());
    }
}
