using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kindle : StatusEffect
{
    public override void StatusStart() 
    {
        StatusDuration = 12;
        StatusTick = 0.5f;
        SpriteID = 1;
        Type = StatusType.enemy;

        characterController.Health.CanHeal = false;
    }

    public override void StatusUpdate()
    {
        characterController.Health.DealDamage(0, 0, 10);
    }

    public override void StatusEnd()
    {
        characterController.Health.CanHeal = true;
    }
}
