using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CastType {
    instant,
    indicator,
}

public class Ability : MonoBehaviour
{
    public Character character;
    public CharacterController characterController;

    /// Data

    public string AbilityName;
    public string AbilityDesc;
    public Sprite AbilitySprite;

    public int AbilityCost;
    public float AbilityCooldown;

    public float AbilityDuration;

    public int Stacks;
    public CastType castType;

    /// Current Data

    public float AbilityCurDuration;
    public float AbilityCurCD;
    public float StackCount;

    public bool Casting;
    public bool Castable;

    void Start()
    {
        character = GetComponent<Character>();
        characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        AbilityPassive();
        HandleCooldown();
        HandleAbility();
    }

    public void AbilityCast()
    {
        if(!Castable) return;

        if(Stacks == 0)
        {
        Casting = true;
        Castable = false;

        AbilityStart();

        AbilityCurCD = 0f;

        if(AbilityCurDuration < AbilityDuration)
        {
            AbilityUpdate();
        } else {
            AbilityEnd();

            Casting = false;
        }
        } else if(Stacks > 0 && StackCount > 0)
        {
        Casting = true;

        AbilityStart();
        }
    }

    void HandleAbility() 
    { 
        if(Casting)
        {
        AbilityCurDuration += Time.deltaTime;

        if(AbilityCurDuration >= AbilityDuration)
        {
            AbilityEnd();
            AbilityCurDuration = 0f;
            Casting = false;

            if(Stacks>0)
            {
                StackCount-=1;
            }
        }
        else
        {
            AbilityUpdate();
        }
        }

        if(Stacks > 0)
        {
            if(StackCount > 0)
            {
                if(Casting)
                {
                    Castable = false;
                } else {
                    Castable = true;
                }
            }
        }
    }

    public void HandleCooldown()
    {
        if(Casting && Stacks == 0) return;

        if(Stacks == 0)
        {
            if(AbilityCurCD < AbilityCooldown)
            {
                AbilityCurCD += Time.deltaTime;

            } else {
                AbilityCurCD = AbilityCooldown;
                Castable = true;
            }
        } else if(Stacks > 0)
        {
            if(StackCount == Stacks) return;

            if(AbilityCurCD < AbilityCooldown)
            {
                AbilityCurCD += Time.deltaTime;

            } else {
                if(StackCount < Stacks)
                {
                AbilityCurCD = 0;
                StackCount+=1;
                }
            }
        }

        if(Stacks > 0)
        {
            if(Casting) return;

            Castable = true;
        }
    }

    public void Indicator()
    {

    }

    public virtual void AbilityStart() { }
    public virtual void AbilityUpdate() { }
    public virtual void AbilityEnd() { }

    public virtual void AbilityPassive() { }

    public void CancelPath() { characterController.agent.SetDestination(transform.position); }
}
