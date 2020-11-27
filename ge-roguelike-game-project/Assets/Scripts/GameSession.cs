using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO: GameSession object must be created in the scene for this to work
public class GameSession : MonoBehaviour
{
    public int playerLives;
    public string gameOverScene;
    public float damageTimeout = 1f;
    private bool canTakeDamage = true;

    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lives on Start: " + playerLives);
        FindObjectOfType<UIManager>().UpdateLives(playerLives);
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
            FindObjectOfType<UIManager>().UpdateLives(playerLives);
        }
        else
        {
            ResetGameSession();
        }
    }
    private void TakeLife()
    {
        playerLives--;
        //StartCoroutine(damageTimer());
        //var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex);
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(gameOverScene);
        Destroy(gameObject);
    }

    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }
}
