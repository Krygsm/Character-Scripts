using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using moba.damage;

public class CharacterController : MonoBehaviour
{
    public NavMeshAgent agent;
    private RaycastHit hit;
    private Character character;

    [HideInInspector] public GameObject target;
    public CharacterController targetCC;
    [HideInInspector] public float distance;
    [HideInInspector] public bool isStatic;
    [HideInInspector] public float AttackProc;
    
    [HideInInspector] public CharacterHealth Health;
    [HideInInspector] public CharacterMana Mana;
    [HideInInspector] public CharacterArmor Armor;
    [HideInInspector] public CharacterDamage Damage;



    public bool isActive;
    public bool isControllable;
    public bool canAttack;
    public bool canCast;

    public bool CastReady;

    public bool hasAttacked;
    public bool gotAttacked;

    public bool hitAbility;
    public bool hitByAbility;

    void Start()
    {
        character = GetComponent<Character>();
        agent = GetComponent<NavMeshAgent>();

        Health = GetComponent<CharacterHealth>();
        Mana = GetComponent<CharacterMana>();
        Armor = GetComponent<CharacterArmor>();
        Damage = GetComponent<CharacterDamage>();

        agent.speed = character.MovementSpeed.Value/100;
    }

    void Update()
    {
        if(!isActive) return;

        if(isControllable)
        {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.tag == "Untagged")
                {
                    agent.SetDestination(hit.point);
                    target = null;
                    targetCC = null;

                } else if(hit.collider.tag == "enemy")
                {
                    target = hit.transform.gameObject;
                    targetCC = target.GetComponent<CharacterController>();

                    MoveToTarget();
                }
            }
        }
        }
        else
        {
            target = null;
        }

            if(target != null)
            {   
                MoveToTarget();
            }

        IsStatic();
        ReadyAttack();

        if(canCast)
        {
        Cast(KeyCode.Q, 0);
        Cast(KeyCode.W, 1);
        //Cast(KeyCode.E, 2);
        //Cast(KeyCode.R, 3);
        }
    }

    public void LateUpdate()
    {
        if(hasAttacked)
        {
        hasAttacked = false;
        }
        if(gotAttacked)
        {
        gotAttacked = false;
        }
        if(hitAbility)
        {
            hitAbility = false;
        }
        if(hitByAbility)
        {
            hitByAbility = false;
        }
    }

    public void IsStatic()
    {
        if(agent.velocity.magnitude == 0f)
        {
            isStatic = true;
        } else {
            isStatic = false;
        }
    }

    void MoveToTarget()
    {
        agent.SetDestination(target.transform.position);
        distance = Vector3.Distance(transform.position, target.transform.position);
        
        if(canAttack)
        {
        if(target.tag == "enemy")
        {
            if(distance <= (character.AttackRange.Value/100))
            {
                agent.SetDestination(transform.position);
                
                
                PerformAttack();
            } else {
                agent.SetDestination(target.transform.position);
            }
        }
        } else {
            agent.SetDestination(target.transform.position);
        }
    }

    void ReadyAttack()
    {
        if(AttackProc >= (1/character.AttackSpeed.Value)) return;

        AttackProc += Time.deltaTime;
    }

    void PerformAttack()
    {
        if(!isStatic) return;

        if(AttackProc >= 1/character.AttackSpeed.Value)
        {
            Damage.AutoAttack(target.GetComponent<CharacterController>());

            targetCC.gotAttacked = true;
            hasAttacked = true;

            AttackProc = 0;
        }

    }

    void Cast(KeyCode key, int num)
    {   
        if(character.Abilities[num].AbilityCost <= Mana.CurMana)
        {
        if(Input.GetKeyDown(key))
        {
            if(character.Abilities[num].castType == CastType.instant)
            {
                character.Abilities[num].AbilityCast();
            }
            else
            {
                character.Abilities[num].Indicator();
                CastReady = true;
            }
        }

        if(CastReady)
        {
            if(Input.GetKeyUp(key))
                {
                    character.Abilities[num].AbilityCast();
                    CastReady = false;
                }
        }
        }
    }
}
