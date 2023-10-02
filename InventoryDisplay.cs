using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public GameObject player;
    public CharacterInventory characterInventory;

    public ItemDisplay[] itemDisplays;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        characterInventory = player.GetComponent<CharacterInventory>();

        itemDisplays = GetComponentsInChildren<ItemDisplay>();
    }

    void Update()
    {
        for(int i = 0; i < characterInventory.items.Count; i++)
        {
            itemDisplays[i].item = characterInventory.items[i];
        }
    }

}
