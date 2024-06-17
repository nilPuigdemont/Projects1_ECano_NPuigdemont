using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "FSM/Actions/Shoot")]
public class ShootAction : FSMAction
{
    public override void OnEnter(BaseStateMachine stateMachine)
    {
        var enemyShootBehaviour = stateMachine.GetComponent<WeaponBehavior>();
        enemyShootBehaviour.playerSeen = true;
    }
    public override void Execute(BaseStateMachine stateMachine)
    {
        var enemyVision = stateMachine.GetComponent<EnemyVision>();

        var enemyShootBehaviour = stateMachine.GetComponent<WeaponBehavior>();

        if (enemyVision.FOV())
        {
            enemyShootBehaviour.Fire();
            stateMachine.animator.SetBool("Shoot", true);
        }
        

    }
    public override void OnExit(BaseStateMachine stateMachine)
    {
        var enemyShootBehaviour = stateMachine.GetComponent<WeaponBehavior>();
        enemyShootBehaviour.playerSeen = false;
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        
        patrollingAgent.agent.isStopped = false;
    }
}
