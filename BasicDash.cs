using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDash : AbilityDash
{
    public override void AbilityStart()
    {
        SetUpDash();
    }

    public override void AbilityUpdate()
    {
        Dash();
    }

    public override void AbilityEnd()
    {
        Debug.Log("da");
        EndDash();
    }
}
