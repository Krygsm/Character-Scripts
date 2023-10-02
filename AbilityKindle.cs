using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityKindle : Ability
{
    StatusEffect effect;

    public override void AbilityStart()
    {
        effect = character.statusCache.StatusEffectList[0];
    }

    public override void AbilityUpdate()
    {
        if(characterController.target != null)
        {

            character.statusCache.AddStatusEffect(characterController.target, 1);
            character.statusCache.AddStatusEffect(characterController.gameObject, 1);

            AbilityCurDuration = AbilityDuration;
        }
    }
}
