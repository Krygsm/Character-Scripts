using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public Character character;
    public CharacterGold gold;

    public List<Item> items = new List<Item>();

    public int InvCap = 8;

    public Item testItem1;
    public Item testItem2;

    public Item testItem3;
    public Item testItem4;

    void Start()
    {
        character = GetComponent<Character>();
        gold = GetComponent<CharacterGold>();
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.U))
        {
          Equip(testItem1);
        }
        if(Input.GetKeyUp(KeyCode.I))
        {
          Equip(testItem2);
        }
        if(Input.GetKeyUp(KeyCode.O))
        {
          Equip(testItem3);
        }
        if(Input.GetKeyUp(KeyCode.P))
        {
          Equip(testItem4);
        }
        if(Input.GetKeyUp(KeyCode.U))
        {
          for(int i = 0; i < items.Count; i++)
          {
            items[i] = null;
          }
        }
    }

    void Equip(Item item)
    {
        if (items.Count == InvCap) return;

        item.AddStats(character);
        items.Add(item);

        gold.Gold -= item.ItemCost;
    }

    void Remove(Item item)
    {
      item.RemoveStats(character);
      items.Remove(item);

      gold.Gold += Mathf.RoundToInt(item.ItemCost*0.75f);
    }
}
