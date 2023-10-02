using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SliderType 
{
    health,
    resource,
}

public class SliderBar : MonoBehaviour
{
    public Canvas canvas; 
    public GameObject player;

    public SliderType type;
    private bool hp;
    private bool rs;

    private Slider slider;

    void Start()
    {
        canvas = transform.parent.GetComponent<Canvas>();
        player = canvas.transform.parent.gameObject;

        slider = GetComponent<Slider>();

        switch(type)
        {
            case SliderType.health:
                hp = true;
                break;
            case SliderType.resource:
                rs = true;
                break;
        }

        if(rs)
        {
            if(player.GetComponent<CharacterMana>().type == ManaType.mana)
            {
                slider.fillRect.GetComponent<Image>().color = new Color(0f, 201f, 255f);
            } else if(player.GetComponent<CharacterMana>().type == ManaType.stamina)
            {
                slider.fillRect.GetComponent<Image>().color = new Color(255f, 190f, 12f);
            }
        }
    }

    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;

        if(hp)
        {
            slider.value = player.GetComponent<CharacterHealth>().CurHealth/player.GetComponent<CharacterHealth>().MaxHealth;
        } else if(rs)
        {
            slider.value = player.GetComponent<CharacterMana>().CurMana/player.GetComponent<CharacterMana>().MaxMana;
        }
    }
}
