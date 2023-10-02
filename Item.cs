using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using stats;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite ItemSprite;
    public int ItemCost;

    public float Health;
    public float HealthRegen;

    public float AttackDamage;
    public float MagicDamage;

    public float AttackArmor;
    public float MagicArmor;

    public float MoveSpeed;

    public float AttackSpeed;
    public float CriticalChance;

    public float CooldownReduction;
    public float Range;

    public void AddStats(Character c)
    {
        c.health.Value += Health;
        c.HealthRegen.Value += HealthRegen;
        c.AttackDamage.Value += AttackDamage;
        c.MagicDamage.Value += MagicDamage;
        c.AttackArmor.Value += AttackArmor;
        c.MagicArmor.Value += MagicArmor;
        c.MovementSpeed.Value += MoveSpeed;
        c.AttackSpeed.Value += AttackSpeed;
        c.CriticalChance.Value += CriticalChance;
        c.CooldownReduction.Value += CooldownReduction;
    }

    public void RemoveStats(Character c)
    {
        c.health.Value -= Health;
        c.HealthRegen.Value -= HealthRegen;
        c.AttackDamage.Value -= AttackDamage;
        c.MagicDamage.Value -= MagicDamage;
        c.AttackArmor.Value -= AttackArmor;
        c.MagicArmor.Value -= MagicArmor;
        c.MovementSpeed.Value -= MoveSpeed;
        c.AttackSpeed.Value -= AttackSpeed;
        c.CriticalChance.Value -= CriticalChance;
        c.CooldownReduction.Value -= CooldownReduction;
    }
}
