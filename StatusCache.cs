using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusCache : MonoBehaviour
{
    public List<StatusEffect> StatusEffectList = new List<StatusEffect>();
    public List<Sprite> StatusImageList = new List<Sprite>();

    public void AddStatusEffect(GameObject player, int id)
    {
        StatusEffect effect = StatusEffectList[id-1];
        Type type = effect.GetType();
        effect.StatusSprite =  StatusImageList[id-1];

        Component Status = effect.GetComponent(type);

        Status = player.AddComponent(type);
    }

    public void ApplyStatusSprite(StatusEffect eff, int id)
    {
        eff.StatusSprite = StatusImageList[id-1];
    }
}
