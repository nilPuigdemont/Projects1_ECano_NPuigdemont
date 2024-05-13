using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Chase")]
public class ChaseAction : FSMAction
{
    public override void OnEnter(BaseStateMachine stateMachine)
    {
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        patrollingAgent.moveSpeed = patrollingAgent.moveSpeed + 2;
    }
    public override void Execute(BaseStateMachine stateMachine)
    {
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        

        patrollingAgent.SetDestination(References.player.transform.position);
    }

    public override void OnExit(BaseStateMachine stateMachine)
    {
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        patrollingAgent.hasPath = false;
        patrollingAgent.moveSpeed = patrollingAgent.moveSpeed - 2;
    }
}
