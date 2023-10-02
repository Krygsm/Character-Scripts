using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGold : MonoBehaviour
{
    public int Gold;

    public int Income;

    private float Tick;

    void Update()
    {
        Tick += Time.deltaTime;

        if(Tick >= 1)
        {
            Gold+=Income;
            Tick=0f;
        }
    }
}
