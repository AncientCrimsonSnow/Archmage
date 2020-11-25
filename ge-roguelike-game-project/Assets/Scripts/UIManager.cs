using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	void Update()
    {
		UpdateLives();
	}

    public void UpdateLives() {
		FindObjectOfType<Health>().HandleHearts();
	}
}
