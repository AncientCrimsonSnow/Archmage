using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public int heal = 10;
    public int strength= 5;
    public int exp= 2;
    public float speed = 1;


    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        //Debug.Log("Player healed by" + other.name);

        applyEffects();
        Destroy(gameObject);
    }

    void applyEffects(){

        GameObject.Find("Player").GetComponent<Player_Controller>()._charDataController.doHeal(heal);
        GameObject.Find("Player").GetComponent<Player_Controller>()._charDataController.addExp(exp);
        GameObject.Find("Player").GetComponent<Player_Controller>()._charDataController.addSpeed(speed);
        GameObject.Find("Player").GetComponent<Player_Controller>()._charDataController.addStrength(strength);
    }
}
