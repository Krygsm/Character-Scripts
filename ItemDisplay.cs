using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class ItemDisplay : MonoBehaviour
{
    public Item item;

    public Image itemImage;

    void Start()
    {
        itemImage = GetComponent<Image>();
        itemImage.enabled = false;
    }

    void Update()
    {
        if(item = null)
        {
            itemImage.sprite = null;
            itemImage.enabled = false;
        }
        else if(item != null)
        {
            itemImage.sprite = item.ItemSprite;
            itemImage.enabled = true;
        }
    }
}
