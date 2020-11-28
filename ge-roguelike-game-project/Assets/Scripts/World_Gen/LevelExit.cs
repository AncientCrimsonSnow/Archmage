using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField]
    private float levelLoadDelay = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (Application.CanStreamedLevelBeLoaded(currentSceneIndex + 1))
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("Load Scene failed.");
        }
    }
}
