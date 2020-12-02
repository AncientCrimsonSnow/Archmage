using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShoot : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    public GameObject spell;
    
    public bool temp;
    void Start()
    {
        temp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (temp)
        {
            spell.GetComponent<BaseSpell>().Shoot(firePoint);
            temp = false;
        }
    }
    

}
