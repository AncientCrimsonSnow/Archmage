using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;

public class CharData_Controller
{
    public CharData _CharData;

    public CharData_Controller(string name)
    {
        loadData(name);
    }
    public void ResetData(String name)
    {
        _CharData.Name = name;
        _CharData.Lvl = 1;
        _CharData.Exp = 0;
        _CharData.Strength = 10;
        _CharData.MoveSpeed = 7;
        saveData();
    }
    public void saveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/CharData_" + _CharData.Name + ".dat");
        bf.Serialize(file, this._CharData);
        file.Close();
        
        
        Debug.Log("Char is saved with the values:");
        foreach (var thisVar in this._CharData.GetType().GetProperties())
        {
            Debug.Log(thisVar.Name + " = " + thisVar.GetValue(this._CharData, null));
        }
    }

    public void loadData(string name)
    {
        if (File.Exists(Application.persistentDataPath + "/CharData_" + name + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/CharData_" + name + ".dat", FileMode.Open);
            this._CharData = (CharData) bf.Deserialize(file);
            file.Close();
            ;
            
            
            Debug.Log("Char is loaded with the values:");
            foreach (var thisVar in this._CharData.GetType().GetProperties())
            {
                Debug.Log(thisVar.Name + " = " + thisVar.GetValue(this._CharData, null));
            }
        }
    }
}

[Serializable]
public class CharData
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int lvl;
    [SerializeField]
    private int exp;
    [SerializeField]
    private float strength;
    [SerializeField]
    private float moveSpeed;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Lvl
    {
        get => lvl;
        set => lvl = value;
    }

    public int Exp
    {
        get => exp;
        set => exp = value;
    }

    public float Strength
    {
        get => strength;
        set => strength = value;
    }

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }
    
}
