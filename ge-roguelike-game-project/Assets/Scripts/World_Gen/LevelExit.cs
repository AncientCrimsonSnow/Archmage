using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField]
    private float levelLoadDelay = 2f;
    public Animator transition;

    public IEnumerator LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (Application.CanStreamedLevelBeLoaded(currentSceneIndex + 1))
        {
            transition.SetTrigger("Start");
            yield return new WaitForSecondsRealtime(levelLoadDelay);
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("Load Scene failed.");
        }
    }
}
