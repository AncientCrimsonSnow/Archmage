using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO: GameSession object must be created in the scene for this to work
public class GameSession : MonoBehaviour
{
    [SerializeField]
    public int playerLives = 3;
    public string gameOverScene;
    //private AssetBundle myLoadedAssetBundle;
    //private string[] scenePaths;

    //private void Awake()
    //{
    //    int numGameSession = FindObjectsOfType<GameSession>().Length;
    //    if (numGameSession > 1)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}
    // Start is called before the first frame update
    void Start()
    {
        //myLoadedAssetBundle = AssetBundle.LoadFromFile("../scenes");
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();
        FindObjectOfType<UIManager>().UpdateLives(playerLives);
    }

    private void Update()
    {
        if (playerLives < 1)
        {
            ResetGameSession();
        }
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife(playerLives);
            FindObjectOfType<UIManager>().UpdateLives(playerLives);
        }
        else
        {
            ResetGameSession();
        }
    }
    private void TakeLife(int playerLives) => playerLives--;

    private void ResetGameSession()
    {
        SceneManager.LoadScene(gameOverScene);
        //Destroy(gameObject);
    }
}
