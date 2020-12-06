using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioSource bgm;

    public string loadingScene;
    
    void Awake(){
        bgm = GetComponent<AudioSource>();

        bgm.Stop();
        bgm.Play();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(loadingScene);
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
