using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;

public class CharData : MonoBehaviour
{
    public string name;
    public int lvl;
    public int exp;
    public float strength;
    public float moveSpeed;
    public SpriteRenderer sprite;

    public void ResetData(String name)
    {
        lvl = 1;
        exp = 0;
        strength = 10;
        moveSpeed = 10;
    }

    public void saveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/CharData" + this.name + ".dat");
        Pure_CharData _pureCharData = new Pure_CharData(this);
        bf.Serialize(file, _pureCharData);
        file.Close();
        
        
        Debug.Log("Char is saved with the values:");
        foreach (var thisVar in _pureCharData.GetType().GetProperties())
        {
            Debug.Log(thisVar.Name + " = " + thisVar.GetValue(_pureCharData, null));
        }
    }

    public void loadData(string name)
    {
        if (File.Exists(Application.persistentDataPath + "/CharData" + name + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/CharData" + name + ".dat", FileMode.Open);
            Pure_CharData _pureCharData = (Pure_CharData) bf.Deserialize(file);
            file.Close();
            setAll(_pureCharData);
            
            
            Debug.Log("Char is loaded with the values:");
            foreach (var thisVar in _pureCharData.GetType().GetProperties())
            {
                Debug.Log(thisVar.Name + " = " + thisVar.GetValue(_pureCharData, null));
            }
        }
    }

    public void setAll(Pure_CharData _pureCharData)
    {
        this.name = _pureCharData.name;
        this.lvl = _pureCharData.lvl;
        this.exp = _pureCharData.exp;
        this.strength = _pureCharData.strength;
        this.moveSpeed = _pureCharData.moveSpeed;
    }
}

[Serializable]
public class Pure_CharData
{

    public string name;
    public int lvl;
    public int exp;
    public float strength;
    public float moveSpeed;

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

    public Pure_CharData(CharData _charData)
    {
        this.name = _charData.name;
        this.lvl = _charData.lvl;
        this.exp = _charData.exp;
        this.strength = _charData.strength;
        this.moveSpeed = _charData.moveSpeed;
    }
}
