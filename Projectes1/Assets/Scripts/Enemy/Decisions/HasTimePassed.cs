using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;


[CreateAssetMenu(menuName = "FSM/Decisions/HasTimePassed")]
public class HasTimePassed : Decision
{
    [SerializeField] private float timeToPass;
     private float currentTimePassed;


    public override bool Decide(BaseStateMachine stateMachine)
    {
        return true;

    }

   

}
