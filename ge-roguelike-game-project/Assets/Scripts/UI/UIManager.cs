using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void UpdateLives(int health) {
	    FindObjectOfType<Healthbar>().SetHealth(health);
	}

    public void SetMaxHP(int health)
    {
	    FindObjectOfType<Healthbar>().SetMaxHealth(health);
    }
	public void UpdateGameLevel(int level)
    {
        FindObjectOfType<LevelCounter>().SetGameLevel(level);
    }
}
