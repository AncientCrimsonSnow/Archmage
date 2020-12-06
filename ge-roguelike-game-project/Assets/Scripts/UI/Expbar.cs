using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Expbar : MonoBehaviour
{
    public Slider slider;
    public Text currentEXPText;
    public Text EXPtoNextLvlText;

    public void SetEXPToNextLvl(int exp)
    {
        slider.maxValue = exp;
        SetExpToNextLvlText(exp);
    }

    public void SetExp(int exp)
    {
        slider.value = exp;
        SetCurrentExpText(exp);
    }

    public void SetCurrentExpText(int currentExp)
    {
        currentEXPText.text = currentExp + " /";
    }

    public void SetExpToNextLvlText(int exp)
    {
        EXPtoNextLvlText.text = exp.ToString();
    }
}
