using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Chase")]
public class ChaseAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        var enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();

        patrollingAgent.SetDestination(References.player.transform.position);
    }

    public override void OnExit(BaseStateMachine stateMachine)
    {
        var patrolAgent = stateMachine.GetComponent<PatrollingAgent>();
        patrolAgent.hasPath = false;
    }
}
