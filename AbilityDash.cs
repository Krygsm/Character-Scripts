using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDash : Ability
{
    [HideInInspector] public bool Dashing;

    public float DashDistance;

    [HideInInspector] public float DashLeft;

    [HideInInspector] public Vector3 DashDirection;
    
    public void SetUpDash()
    {
        characterController.isControllable = false;

        Dashing = true;

        SetUpDashEffect();

        DashLeft = DashDistance;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 targetPosition = hit.point;

            DashDirection = (targetPosition - transform.position).normalized;
        }
    }

    public void Dash()
    {
        float dashSpeed = DashDistance / AbilityDuration;

        if (DashLeft > 0)
        {
            DashEffect();

            float dashDistanceThisFrame = dashSpeed * Time.deltaTime;
            DashLeft -= dashDistanceThisFrame;

            transform.position += DashDirection * dashDistanceThisFrame;
        }
    }

    public void EndDash()
    {
        EndDashEffect();

        characterController.isControllable = true;
        Dashing = false;
    }

    public virtual void SetUpDashEffect() { }
    public virtual void DashEffect() { }
    public virtual void EndDashEffect() { }
}
