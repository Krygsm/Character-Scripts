using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType {
    Physical,
    Magical,
    Absolute,
}


public class Damage
{
    public float Value;
    public DamageType Type;

    public Damage(float value, DamageType damageType)
    {
        Value = value;
        Type = damageType;
    }
}
