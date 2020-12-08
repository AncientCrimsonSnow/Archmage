using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO: GameSession object must be created in the scene for this to work. There's a prefab for it.
public class GameSession : MonoBehaviour
{
    public string gameOverScene;
    public int currentGameLevel = 1;
    public float levelsize = 20;
    
    private void Awake()
    {
        GameObject.Find("Canvas").GetComponent<LevelComplete>().HideLevelComplete();
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
        string playerName = GameObject.Find("Playername_save").GetComponent<PlayerName_save>().playerName;
        GameObject.Find("Player").GetComponent<Player_Controller>().charName = playerName;
        GameObject.Find("Player").GetComponent<Player_Controller>().Init();
        GameObject.Find("Player").GetComponent<Player_Controller>()._charDataController.doDmg(0);
        //Destroy(GameObject.Find("Playername_save"));
    }
    // Start is called before the first frame update
    void Start()
    { 
        FindObjectOfType<UIManager>().UpdateGameLevel(currentGameLevel);
    }

    // TODO: adjust for damage from enemies by passing a parameter damage to the method below
    // -> ProcessPlayerDeath(int/float damage); & TakeDamage(damage);
    // Variable damage should be created in the Enemy script and passed there

    public void AddToGameLevel()
    {
        currentGameLevel++;
        levelsize += 5;
        //Debug.Log("Levelsize: " + levelsize);
        FindObjectOfType<UIManager>().UpdateGameLevel(currentGameLevel);
    }

    public void PlayerDied()
    {
        ResetGameSession();
    }

    private void ResetGameSession()
    {
        int maxHp = GameObject.Find("Player").GetComponent<Player_Controller>()._charDataController._CharData.MAXHp; 
        GameObject.Find("Player").GetComponent<Player_Controller>()._charDataController._CharData.CurrentHp = maxHp;
        GameObject.Find("Player").GetComponent<Player_Controller>()._charDataController.saveData();

        SceneManager.LoadScene(gameOverScene);
        Destroy(gameObject);
    }
}
