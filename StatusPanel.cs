using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusGroup {
    team,
    enemy,
}

public class StatusPanel : MonoBehaviour
{
    public GameObject player;
    private Character character;

    public StatusDisplay[] StatusDisplays;

    public StatusGroup Group;

    private List<StatusEffect> Cache = new List <StatusEffect>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        character = player.GetComponent<Character>();

        StatusDisplays = GetComponentsInChildren<StatusDisplay>();
    }

    void Update()
    {
        if(Cache.Count != character.StatusEffects.Count)
        {
            UpdateStatusDisplays();

            Cache.Clear();
            Cache.AddRange(character.StatusEffects);
        }

    }

    public void ClearOutStatusEffects()
    {
        for(int i = 0; i<StatusDisplays.Length; i++)
        {
            StatusDisplays[i].image.sprite = null;
        }
    }
    
    public void UpdateStatusDisplays()
    {
        for(int i = 0; i < StatusDisplays.Length; i++)
        {
            if(i < character.StatusEffects.Count && character.StatusEffects[i] != null)
            {
                if(Group == StatusGroup.team && character.StatusEffects[i].Type == StatusType.team)
                {
                StatusDisplays[i].statusEffect = character.StatusEffects[i];
                }
                if(Group == StatusGroup.enemy && character.StatusEffects[i].Type == StatusType.enemy)
                {
                StatusDisplays[i].statusEffect = character.StatusEffects[i];
                }
            }
            else
            {
            StatusDisplays[i].statusEffect = null; 
            }

            StatusDisplays[i].UpdateDisplay();
        }
    }
}
