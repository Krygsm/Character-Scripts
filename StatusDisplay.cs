using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class StatusDisplay : MonoBehaviour
{
    public Image image; 
    public StatusEffect statusEffect;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {   
        if(image.sprite == null)
        {
            image.enabled = false;
        }
        else
        {   
            image.enabled = true;
        }

        if(statusEffect != null)
        {
            if(statusEffect.StatusDuration > 0)
            {
            image.fillAmount = 1 - (statusEffect.StatusTime / statusEffect.StatusDuration);
            }
        }
    }

    public void UpdateDisplay()
    {
        if(statusEffect != null)
        {
            image.sprite = statusEffect.StatusSprite;
        }
        else
        {
            image.sprite = null;
        }
    }
}
