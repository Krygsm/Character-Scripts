using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDMG : MonoBehaviour
{
    public GameObject player;
    public Character character;

    TextMeshProUGUI display;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        character = player.GetComponent<Character>();

        display = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        display.text = character.AttackDamage.Value.ToString();
    }
}
