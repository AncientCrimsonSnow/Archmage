using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //public int health;
    public int numOfHearts = 3;

    [SerializeField]
    public Image[] heartsImgs;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void HandleHearts(int playerLives)
    {
        // If the health is more than number of hearts display max number of hearts
        if (playerLives > numOfHearts)
        {
            playerLives = numOfHearts;
        }

        for (int i = 0; i < heartsImgs.Length; i++)
        {
            if (i < playerLives)
            {
                heartsImgs[i].sprite = fullHeart;
            }
            else
            {
                heartsImgs[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                heartsImgs[i].enabled = true;
            }
            else
            {
                heartsImgs[i].enabled = false;
            }
        }
    }
}
