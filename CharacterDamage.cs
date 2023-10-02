using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace moba.damage
{
public class CharacterDamage : MonoBehaviour
{
    private CharacterController characterController;
    private Character character;

    public List<Damage> OnHitDamage;
    public List<Damage> AbilityDamage;

    public float OnHitPhysical, OnHitMagic, OnHitAbsolute;
    public float AbilityPhysical, AbiltiyMagic, AbilityAbsolute;

    CharacterDamage()
    {
        OnHitDamage = new List<Damage>();
        AbilityDamage = new List<Damage>();
    }
    
    public void Start()
    {
        characterController = GetComponent<CharacterController>();
        character = GetComponent<Character>();

        float PhysicalDMG = character.AttackDamage.Value;
        float MagicDMG = character.MagicDamage.Value;

        OnHitAdd(new Damage(PhysicalDMG, DamageType.Physical));
    }

    public void Update()
    {
        if(Input.GetKeyUp("space"))
        {
            OnHitAdd(new Damage(20f, DamageType.Physical));
            OnHitAdd(new Damage(20f, DamageType.Magical));

            CalculateOnHitDamage();

            Debug.Log(OnHitPhysical);
            Debug.Log(OnHitMagic);
        }
    }

    public void OnHitAdd(Damage dmg)
    {
        OnHitDamage.Add(dmg);
    }

    public void OnHitRemove(Damage dmg)
    {
        OnHitDamage.Remove(dmg);
    }

    public void AbilityAdd(Damage dmg)
    {
        AbilityDamage.Add(dmg);
    }

    public void AbilityRemove(Damage dmg)
    {
        AbilityDamage.Add(dmg);
    }

    public void CalculateOnHitDamage()
    {
        OnHitAbsolute = 0;
        OnHitPhysical = 0;
        OnHitMagic = 0;

        for(int i = 0; i < OnHitDamage.Count; i++)
        {
            Damage dmg = OnHitDamage[i];

            if(dmg.Type == DamageType.Physical)
            {
                OnHitPhysical += dmg.Value;
            } else if(dmg.Type == DamageType.Magical)
            {
                OnHitMagic += dmg.Value;
            } else if(dmg.Type == DamageType.Absolute)
            {
                OnHitAbsolute += dmg.Value; 
            }
        }
    }

    public void CalculateAbilityDamage()
    {
        AbilityPhysical = 0;
        AbiltiyMagic = 0;

        for(int i = 0; i < AbilityDamage.Count; i++)
        {
            Damage dmg = AbilityDamage[i];

            if(dmg.Type == DamageType.Physical)
            {
                AbilityPhysical += dmg.Value;
            } else if(dmg.Type == DamageType.Magical)
            {
                AbiltiyMagic += dmg.Value;
            }
        }
    }

    public void AutoAttack(CharacterController target)
    {
        float TargetAR;
        float TargetMR;

        target.Armor.CalculateArmor();

        TargetAR = ((1-target.Armor.PhysicalReduction) / (1-character.PhysicalTear.Value*0.01f)) + (character.PhysicalPierce.Value*0.01f);
        TargetMR = ((1-target.Armor.MagicalReduction) / (1-character.MagicalTear.Value*0.01f)) + (character.MagicalPierce.Value*0.01f);

        CalculateOnHitDamage();

        if(TargetAR >= 1)
        {
            OnHitAbsolute += OnHitPhysical;
            OnHitPhysical = 0;
        }
        if(TargetMR >= 1)
        {
            OnHitAbsolute += OnHitMagic;
            OnHitMagic = 0;
        }

        target.Health.DealDamage(OnHitPhysical*TargetAR, OnHitMagic*TargetMR, OnHitAbsolute);

    }

    public void DealAbility(CharacterController target, Damage abilityDamage)
    {
        float TargetAR;
        float TargetMR;

        target.Armor.CalculateArmor();

        TargetAR = ((1-target.Armor.PhysicalReduction) / (1-character.PhysicalTear.Value*0.01f)) + (character.PhysicalPierce.Value*0.01f);
        TargetMR = ((1-target.Armor.MagicalReduction) / (1-character.MagicalTear.Value*0.01f)) + (character.MagicalPierce.Value*0.01f);

        CalculateAbilityDamage();

        if(TargetAR >= 1)
        {
            AbilityAbsolute += AbilityPhysical;
            AbilityPhysical = 0;
        }
        if(TargetMR >= 1)
        {
            AbilityAbsolute += AbiltiyMagic;
            AbiltiyMagic = 0;
        }

        characterController.hitAbility = true;
        target.hitByAbility = true;

        target.Health.DealDamage(AbilityPhysical*TargetAR, AbiltiyMagic*TargetMR, AbilityAbsolute);
    }
}
}