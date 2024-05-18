using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Patrol")]
public class PatrolAction : FSMAction
{
    public override void OnEnter(BaseStateMachine stateMachine)
    {
        var patrolAgent = stateMachine.GetComponent<PatrollingAgent>();
        var patrolPoints = stateMachine.GetComponent<PatrolPoints>();

        stateMachine.animator.SetBool("Shoot", false);
        patrolAgent.SetDestination(patrolPoints.GetNext().position);
    }

    public override void Execute(BaseStateMachine stateMachine)
    {
        var patrolAgent = stateMachine.GetComponent<PatrollingAgent>();
        var patrolPoints = stateMachine.GetComponent<PatrolPoints>();

        if (patrolPoints.HasReached(patrolAgent))
            patrolAgent.SetDestination(patrolPoints.GetNext().position);
    }

    public override void OnExit(BaseStateMachine stateMachine)
    {
        var patrolAgent = stateMachine.GetComponent<PatrollingAgent>();
            patrolAgent.hasPath = false;
    }
}

