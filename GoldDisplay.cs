using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{   
    public GameObject player;
    public CharacterGold characterGold;

    TextMeshProUGUI display;
    public int goldAmount;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterGold = player.GetComponent<CharacterGold>();

        display = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        goldAmount = characterGold.Gold;

        display.text = goldAmount.ToString();
    }
}   