using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    private Character character;

    public float CurHealth;
    public float MinHealth;
    public float MaxHealth;

    public float HealthRegen;
    public bool CanHeal;

    private float Tick = 0;
    private float hpCD = 0;

    public bool HealthLost;

    private float HPCache;

    void Start()
    {
        character = GetComponent<Character>();
        MaxHealth = character.health.Value;
        HealthRegen = character.HealthRegen.Value;

        CurHealth = MaxHealth;
    }

    void Update()
    {
        RegenHealth();

        if(CurHealth > MaxHealth)
        {
            CurHealth = MaxHealth;
        }
    }

    void LateUpdate()
    {
        
        if(HealthLost)
        {
        HealthLost = false;
        }
    }

    public void DealDamage(float physical, float magical, float absolute)
    {
        float mitigated = character.Mitigate.Value;

        CurHealth -= ((physical-mitigated)+magical+absolute);

        HealthLost = true;
    }

    public void RegenHealth()
    {
        if(CurHealth < MaxHealth)
        {
        if(CanHeal)
        {
            Tick += Time.deltaTime;

            if(Tick >= 1f)
            {
                CurHealth += HealthRegen;
                
                Tick = 0;
            }
        } else {
            hpCD += Time.deltaTime;

            if(hpCD >= 5f)
            {
                CanHeal = true;
                hpCD = 0;
            }
        }
        }
    }
}
