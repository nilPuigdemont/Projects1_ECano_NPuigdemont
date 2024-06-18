using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Chase")]
public class ChaseAction : FSMAction
{
    public override void OnEnter(BaseStateMachine stateMachine)
    {
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        patrollingAgent.moveSpeed = patrollingAgent.moveSpeed + 1;
        patrollingAgent.agent.isStopped = false;
        stateMachine.animator.SetBool("Shoot", false);
    }
    public override void Execute(BaseStateMachine stateMachine)
    {
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        
        if(References.player != null)
        {
            patrollingAgent.SetDestination(References.player.transform.position);
        }
        
    }

    public override void OnExit(BaseStateMachine stateMachine)
    {
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        patrollingAgent.hasPath = false;
        patrollingAgent.agent.isStopped = true;
        patrollingAgent.moveSpeed = patrollingAgent.moveSpeed - 1;
    }
}
