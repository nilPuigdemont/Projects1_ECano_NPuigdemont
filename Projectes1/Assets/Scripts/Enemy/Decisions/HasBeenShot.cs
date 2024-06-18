using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "FSM/Decisions/HasBeenShot")]
public class HasBeenShot : Decision
{
    public override bool Decide(BaseStateMachine stateMachine)
    {
        var HealthSystem = stateMachine.GetComponent<HealthSystem>();   
        
        if(HealthSystem.currentHealth < HealthSystem.maxHealth)
        {
            return true;
        }

        return false;
    }

   
}
