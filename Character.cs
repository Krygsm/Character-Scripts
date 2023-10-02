using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using stats;

public enum AttackType {
    melee,
    ranged,
    mage,
}
public class Character : MonoBehaviour
{
    public CharacterStat health;
    public CharacterStat HealthRegen;

    public CharacterStat mana;
    public CharacterStat ManaRegen;

    public CharacterStat MovementSpeed;

    public AttackType attackType;
    public CharacterStat AttackRange;
    public CharacterStat AttackSpeed;

    public CharacterStat AttackDamage;
    public CharacterStat MagicDamage;

    public CharacterStat AttackArmor;
    public CharacterStat MagicArmor;

    public CharacterStat Mitigate;

    public CharacterStat PhysicalPierce;
    public CharacterStat PhysicalTear;

    public CharacterStat MagicalPierce;
    public CharacterStat MagicalTear;

    public CharacterStat CriticalChance;
    public CharacterStat CooldownReduction;

    public int Team;

    public Ability[] Abilities;
    public List<StatusEffect> StatusEffects = new List<StatusEffect>();

    public StatusCache statusCache;

    public Sprite[] HitSprites;

    void Start()
    {
        Abilities = GetComponents<Ability>();
        statusCache = GameObject.Find("StatusCache").GetComponent<StatusCache>();
    }

    void Update()
    {
        
    }
}
