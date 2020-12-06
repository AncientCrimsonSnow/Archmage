using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    public string loadedScene;
    [SerializeField]
    private Text progressText;

    void Start()
    {
        if (loadedScene != null)
        {
            LoadLevel(loadedScene);
        }
        
    }

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            if(slider)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                progressText.text = progress * 100f + "%";

                yield return new WaitForEndOfFrame();
            }
            
        }
    }
}
