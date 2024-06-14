using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "FSM/Actions/Idle")]
public class IdleAction : FSMAction
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

    public override void OnExit(BaseStateMachine stateMachine)
    {
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        patrollingAgent.hasPath = true;
        var weaponBehaviour = stateMachine.GetComponent<WeaponBehavior>();
        weaponBehaviour.playerSeen = true;
        
        var animator = stateMachine.GetComponentInChildren<Animator>();
        animator.Play("PlayerShot");
    }


}
