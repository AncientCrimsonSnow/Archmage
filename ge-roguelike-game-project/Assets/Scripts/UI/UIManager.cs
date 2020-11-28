using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    void Update()
    {
		UpdateLives(FindObjectOfType<GameSession>().currentHealth);
	}

    public void UpdateLives(int health) {
		FindObjectOfType<Healthbar>().SetHealth(health);
	}
}
