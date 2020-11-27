using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string newGameScene;

    public GameObject continueButton;
    // Start is called before the first frame update
    void Start()
    {
        if (continueButton)
        {
            // If there's a save, it will be recognized,
            // and you will see the Continue button in the main menu
            if (PlayerPrefs.HasKey("Current_Scene"))
            {
                continueButton.SetActive(true);
            }
            else
            {
                continueButton.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Continue()
    {
        Debug.Log("Continue");
    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
