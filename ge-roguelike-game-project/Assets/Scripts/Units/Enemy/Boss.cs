using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(FindObjectOfType<LevelExit>().LoadNextLevel());
    }
}
