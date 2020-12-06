using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Animator transition;

    public void LoadNextLevel()
    {
        GameObject.Find("Player").GetComponent<Player_Controller>()._charDataController.saveData();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (Application.CanStreamedLevelBeLoaded(currentSceneIndex))
        {
            SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
            FindObjectOfType<GameSession>().AddToGameLevel();
        }
        else
        {
            Debug.Log("Load Scene failed.");
        }
    }
}
