using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stats 
{
[Serializable]
public class CharacterStat
{
    public float BaseValue;

    [HideInInspector]public float FlatAddValue;
    [HideInInspector]public float PercentAddValue;
    [HideInInspector]public float PercentMultiValue;
    
    public float Value;
    

    public List<StatModifier> statModifiers;

    CharacterStat()
    {
        statModifiers = new List<StatModifier>();
    }
    
    CharacterStat(float baseValue)
    {
        BaseValue = baseValue;
    }

    public void AddModifier(StatModifier mod)
    {
        statModifiers.Add(mod);
        CalculateFinalValue();
        
    }

    public void RemoveModifier(StatModifier mod)
    {
        statModifiers.Remove(mod);
        CalculateFinalValue();
    }

    public void CalculateFinalValue()
    {
        FlatAddValue = 0;
        PercentAddValue = 1;
        PercentMultiValue = 1;

        for(int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];

            if(mod.Type == StatType.Flat)
            {
                FlatAddValue += mod.Value;
            }
            else if(mod.Type == StatType.PercentAdd)
            {
                PercentAddValue += mod.Value;
            } else if(mod.Type == StatType.PercentMulti)
            {
                PercentMultiValue *= 1 + mod.Value;
            }
        }

        Value = (int)Math.Round(((BaseValue + FlatAddValue) * PercentAddValue) * PercentMultiValue);
    }
}
}