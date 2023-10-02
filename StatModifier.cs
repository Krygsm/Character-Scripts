using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stats
{

public enum StatType {
    Flat = 100,
    PercentAdd = 200,
    PercentMulti = 300,
}

public class StatModifier
{
    public float Value;
    public StatType Type;

    public StatModifier(float value, StatType type)
    {
        Value = value;
        Type = type;
    }
}
}