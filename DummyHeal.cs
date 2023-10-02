using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHeal : MonoBehaviour
{
    private CharacterController characterController;

    public float timer;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    void Update()
    {
        if(characterController.gotAttacked)
        {
            timer = 0f;
            characterController.Health.CanHeal = false;
        }   
            timer += Time.deltaTime;

            characterController.Mana.CurMana = 100*Mathf.RoundToInt(timer);

            if(characterController.Health.CurHealth == characterController.Health.MaxHealth)
            {
                characterController.Health.CanHeal = false;
            }
            else
            {
                if(timer >= 7f)
                {
                    characterController.Health.CanHeal = true;
                }
            }

    }
}
