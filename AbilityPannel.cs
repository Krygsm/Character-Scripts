using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPannel : MonoBehaviour
{
    public GameObject player;
    public AbilityDisplay[] AbilityDisplays;

    private Character character;
    
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AbilityDisplays = GetComponentsInChildren<AbilityDisplay>();

        character = player.GetComponent<Character>();

        UpdateDisplay();
    }

    void Update()
    {
        for(int i = 0; i < character.Abilities.Length; i++)
        {
            AbilityDisplays[i].AbilityImage.fillAmount = character.Abilities[i].AbilityCurCD/character.Abilities[i].AbilityCooldown;
        }
    }

    public void UpdateDisplay()
    {
        for(int i = 0; i < character.Abilities.Length; i++)
        {
            AbilityDisplays[i].AbilityImage.sprite = character.Abilities[i].AbilitySprite;
        }
    }
}
