using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{
    public Text currentLevelText;

    internal void SetGameLevel(int level)
    {
        currentLevelText.text = "Current level: " + level;
    }
}
