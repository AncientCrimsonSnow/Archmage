using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharData : MonoBehaviour
{
    public bool temp;
    public bool save;
    public bool load;
    public string name;
    void Start()
    {
        save = false;
        load = false;
        temp = false;
        gameObject.GetComponent<CharData>().ResetData("Test");
    }

    // Update is called once per frame
    void Update()
    {
        if (temp)
        {
            temp = false;
        }
        if (save)
        {
            save = false;
            gameObject.GetComponent<CharData>().saveData();
            
        }
        if (load)
        {
            load = false;
            gameObject.GetComponent<CharData>().loadData(name);
        }
    }
}
