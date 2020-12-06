using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsLoader : MonoBehaviour
{
    [SerializeField] private InputField inputfield;
    
    public void LoadPlayerData()
    {
        string inputfield_text = inputfield.text;
        GameObject.Find("Playername_save").GetComponent<PlayerName_save>().playerName = inputfield_text;
        CharData_Controller temp = new CharData_Controller(inputfield_text);

        GameObject.Find("Level_number").GetComponent<Text>().text = temp._CharData.Lvl.ToString();
        GameObject.Find("Exp_number").GetComponent<Text>().text = temp._CharData.Exp.ToString();
        GameObject.Find("MaxHealth_number").GetComponent<Text>().text = temp._CharData.MAXHp.ToString();
        GameObject.Find("CurHealth_number").GetComponent<Text>().text = temp._CharData.CurrentHp.ToString();
    }
}
