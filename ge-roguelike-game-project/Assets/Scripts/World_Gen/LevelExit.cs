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

        if (Application.CanStreamedLevelBeLoaded(3))
        {

            Debug.Log("Trying to load next level ");
            transition.SetTrigger("Start");
            yield return new WaitForSecondsRealtime(levelLoadDelay);
            
            SceneManager.LoadScene(3);
            FindObjectOfType<GameSession>().AddToGameLevel();
        }
        else
        {
            Debug.Log("Load Scene failed.");
        }
    }
}
