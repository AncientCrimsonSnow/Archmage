using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    void Update()
    {
		UpdateLives(FindObjectOfType<GameSession>().playerLives);
	}

    public void UpdateLives(int playerLives) {
		FindObjectOfType<Health>().HandleHearts(playerLives);
	}
}
