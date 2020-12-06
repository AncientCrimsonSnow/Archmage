using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompleteScreen;
    public bool isLevelComplete = false;

    public void DisplayLevelComplete()
    {
        levelCompleteScreen.SetActive(true);
        isLevelComplete = true;
    }

    public void HideLevelComplete()
    {
        levelCompleteScreen.SetActive(false);
        isLevelComplete = false;
    }
}
