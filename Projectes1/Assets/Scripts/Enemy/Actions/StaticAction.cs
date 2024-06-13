using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "FSM/Actions/Static")]
public class StaticAction : FSMAction
{

    public override void OnEnter(BaseStateMachine stateMachine)
    {
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        patrollingAgent.hasPath = false;
        var weaponBehaviour = stateMachine.GetComponent<WeaponBehavior>();
        weaponBehaviour.playerSeen = false;

        var animator = stateMachine.GetComponentInChildren<Animator>();
        animator.Play("PlayerIdle");
    }

    public override void Execute(BaseStateMachine stateMachine)
    {
        
    }
}
