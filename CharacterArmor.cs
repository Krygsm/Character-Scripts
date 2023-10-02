using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterArmor : MonoBehaviour
{
    private Character character;

    public float PhysicalReduction;
    public float MagicalReduction;

    void Start()
    {
        character = GetComponent<Character>();
    }

    void Update()
    {
    }

    public void CalculateArmor()
    {
        float PA;
        float MA;

        PA = character.AttackArmor.Value;
        MA = character.MagicArmor.Value;

        PhysicalReduction = ((-45)/(PA+50)+0.9f);
        MagicalReduction = ((-45)/(MA+50)+0.9f);
    }
}
    