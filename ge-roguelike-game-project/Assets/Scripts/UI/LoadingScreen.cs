using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public static bool isLoading = false;
    public GameObject loadingScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        loadingScreen.SetActive(true);
        isLoading = true;

        if (GameObject.FindWithTag("Boss") ||
            (GameObject.FindWithTag("Boss") == null &&
            !ReferenceEquals(GameObject.FindWithTag("Boss"), null)))
        {
            Debug.Log("Big Boss");
            loadingScreen.SetActive(false);
            isLoading = false;
        }
    }
}
