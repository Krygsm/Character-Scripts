using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusType {
    team,
    enemy,
}

public class StatusEffect : MonoBehaviour
{
    public StatusType Type;
    
    public int SpriteID;
    public Sprite StatusSprite;
    public string StatusName;
    public string StatusDesc;
    
    public float StatusDuration;
    [HideInInspector] public float StatusTime;

    public float StatusTick;
    [HideInInspector] public float Tick = 0;

    [HideInInspector] public CharacterController characterController;
    [HideInInspector] public Character character;

    public virtual void StatusStart() { }
    public virtual void StatusUpdate() { }
    public virtual void StatusEnd() { }

    public void Start()
    {
        characterController = GetComponent<CharacterController>();
        character = GetComponent<Character>();

        StatusStart();

        character.StatusEffects.Add(this);

        character.statusCache.ApplyStatusSprite(this, SpriteID);
    }

    public void Update()
    {
        if(StatusDuration == 0)
        {
        Tick += Time.deltaTime;

        if(Tick > StatusTick)
        {
            StatusUpdate();
            Tick=0;
        }
        }
        else
        {
            StatusTime+=Time.deltaTime;

            if(StatusTime <= StatusDuration+Tick)
            {
                Tick += Time.deltaTime;

                if(Tick > StatusTick)
                {
                    StatusUpdate();
                    Tick=0;
                }
            }
            else
            {
                character.StatusEffects.Remove(this);
                StatusEnd();

                Destroy(this, 0f);
            }
        }
    }

}
