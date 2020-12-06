using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public static bool isLoading = false;
    public GameObject loadingScreen;

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
            loadingScreen.SetActive(false);
            isLoading = false;
        }
    }
}
