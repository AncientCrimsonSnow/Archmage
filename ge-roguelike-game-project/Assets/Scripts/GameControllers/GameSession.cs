using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO: GameSession object must be created in the scene for this to work. There's a prefab for it.
public class GameSession : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public string gameOverScene;
    public int currentGameLevel = 1;

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
        currentHealth = maxHealth;
        FindObjectOfType<Healthbar>().SetMaxHealth(maxHealth);
        FindObjectOfType<UIManager>().UpdateLives(currentHealth);
        FindObjectOfType<UIManager>().UpdateGameLevel(currentGameLevel);
    }

    // TODO: adjust for damage from enemies by passing a parameter damage to the method below
    // -> ProcessPlayerDeath(int/float damage); & TakeDamage(damage);
    // Variable damage should be created in the Enemy script and passed there
    public void ProcessPlayerDeath(int damage)
    {
        if(currentHealth > 0)
        {
            TakeDamage(damage);
            FindObjectOfType<UIManager>().UpdateLives(currentHealth);
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
      
    }

    public void AddToGameLevel()
    {
        currentGameLevel++;
        FindObjectOfType<UIManager>().UpdateGameLevel(currentGameLevel);
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(gameOverScene);
        Destroy(gameObject);
    }

    public void PlayerDied()
    {
        ResetGameSession();
    }
}
