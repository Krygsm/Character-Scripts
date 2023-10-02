using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ManaType {
    mana,
    stamina,
    none,
}

public class CharacterMana : MonoBehaviour
{
    private Character character;
    public ManaType type;

    public float CurMana;
    public float MaxMana;

    public float ManaRegen;

    private float Tick = 0f;

    void Start()
    {
        character = GetComponent<Character>();

        MaxMana = character.mana.Value;
        ManaRegen = character.ManaRegen.Value;

        CurMana = MaxMana;
        
    }

    void Update()
    {
        RegenerateMana();

        if(CurMana > MaxMana)
        {
            CurMana = MaxMana;
        }
    }

    void RegenerateMana()
    {
        if(CurMana >= MaxMana) return;

        Tick += Time.deltaTime;

        if(Tick >= 1)
        {
            CurMana += ManaRegen;

            Tick = 0f;
        }
    }
}
