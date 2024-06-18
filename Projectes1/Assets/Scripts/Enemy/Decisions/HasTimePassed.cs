using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "FSM/Decisions/HasTimePassed")]
public class HasTimePassed : Decision
{
    [SerializeField] private float timeToPass;
     private float currentTimePassed = 0;
    public override bool Decide(BaseStateMachine stateMachine)
    {
        while(currentTimePassed < timeToPass) 
        {
            currentTimePassed =  currentTimePassed + Time.deltaTime;

            return false;
        }

        return true;
    }

   

}
