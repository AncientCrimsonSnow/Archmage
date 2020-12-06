using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;

public class CharData_Controller
{
    public CharData _CharData = new CharData();

    public CharData_Controller(string name)
    {
        if (!loadData(name))
        {
            ResetData(name);
        }
    }

    public void ResetData(String name)
    {
        _CharData.Name = name;
        _CharData.MAXHp = 100;
        _CharData.CurrentHp = 100;
        _CharData.Lvl = 1;
        _CharData.Exp = 0;
        _CharData.MAXExpToLvlUp = 100;
        _CharData.Strength = 10;
        _CharData.MoveSpeed = 3;
        saveData();
    }

    public void addExp(int exp)
    {
        _CharData.Exp += exp;
        Debug.Log("Char EXP: " + _CharData.Exp + "/" + _CharData.MAXExpToLvlUp);
        //Debug.Log(_CharData.MAXExpToLvlUp);
        //Lvl up by reaching max exp:
        if (_CharData.Exp >= _CharData.MAXExpToLvlUp)
        {
            lvlUp();
        }
    }
    public void lvlUp()
    {
        _CharData.Lvl++;
        _CharData.Strength += 5;
        _CharData.MAXHp += 10;
        _CharData.CurrentHp = _CharData.MAXHp;
        _CharData.Exp -= _CharData.MAXExpToLvlUp;
        _CharData.MAXExpToLvlUp += (int) Math.Round(_CharData.MAXExpToLvlUp * 1.1f);
        
        Debug.Log("LEVEL UP!");
        Debug.Log("EXP:" + _CharData.Exp + "/" + _CharData.MAXExpToLvlUp);
        //Debug.Log(_CharData.MAXExpToLvlUp);
        Debug.Log("HP:" + _CharData.CurrentHp + "/" + _CharData.MAXHp);
        //Debug.Log(_CharData.CurrentHp);

        GameObject.FindObjectOfType<UIManager>().UpdateLives(_CharData.CurrentHp);
        GameObject.FindObjectOfType<UIManager>().SetMaxHP(_CharData.CurrentHp);
    }

    public void doDmg(int dmg)
    {
        //Debug.Log("Calculate damage in chardatacontroller-- " + dmg);
        _CharData.CurrentHp -= dmg;
        //if player die
        
        if (_CharData.CurrentHp <= 0)
        {
            _CharData.CurrentHp = 0;
            GameObject.FindObjectOfType<GameSession>().PlayerDied();
        }
        else
        {
            GameObject.FindObjectOfType<UIManager>().UpdateLives(_CharData.CurrentHp);
        }
    }
    public void doHeal(int heal)
    {
        _CharData.CurrentHp += heal;
        if (_CharData.CurrentHp > _CharData.MAXHp)
        {
            _CharData.CurrentHp = _CharData.MAXHp;
        }
    }
    public void addSpeed(float moveSpeed)
    {
        _CharData.MoveSpeed += moveSpeed;
        Debug.Log("New Speed = " + _CharData.MoveSpeed);
    }
    public void addStrength(int strength)
    {
        _CharData.Strength += strength;
        Debug.Log("New Strength = " + _CharData.Strength);
    }
    public void saveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/CharData_" + _CharData.Name + ".dat");
        bf.Serialize(file, this._CharData);
        file.Close();
        
        
        //Debug.Log("Char is saved with the values:");
        foreach (var thisVar in this._CharData.GetType().GetProperties())
        {
            //Debug.Log(thisVar.Name + " = " + thisVar.GetValue(this._CharData, null));
        }
    }

    public bool loadData(string name)
    {
        if (File.Exists(Application.persistentDataPath + "/CharData_" + name + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/CharData_" + name + ".dat", FileMode.Open);
            this._CharData = (CharData) bf.Deserialize(file);
            file.Close();
            ;
            
            
            //Debug.Log("Char is loaded with the values:");
            foreach (var thisVar in this._CharData.GetType().GetProperties())
            {
                //Debug.Log(thisVar.Name + " = " + thisVar.GetValue(this._CharData, null));
            }

            return true;
        }
        return false;
    }
}

[Serializable]
public class CharData
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int currentHP;
    [SerializeField]
    private int lvl;
    [SerializeField]
    private int exp;
    [SerializeField]
    private int max_exp_to_lvl_up;

    public int MAXExpToLvlUp
    {
        get => max_exp_to_lvl_up;
        set => max_exp_to_lvl_up = value;
    }

    [SerializeField]
    private int strength;
    [SerializeField]
    private float moveSpeed;

    public string Name
    {
        get => name;
        set => name = value;
    }
    public int MAXHp
    {
        get => maxHP;
        set => maxHP = value;
    }

    public int CurrentHp
    {
        get => currentHP;
        set => currentHP = value;
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

    public int Strength
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
