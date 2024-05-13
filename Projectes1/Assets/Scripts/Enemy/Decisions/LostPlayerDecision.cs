using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="FSM/Decisions/Lost Player")]
public class LostPlayerDecision : Decision
{
    public override bool Decide(BaseStateMachine stateMachine)
    {
        var enemyInLineOfSight = stateMachine.GetComponent<EnemyVision>();

        return enemyInLineOfSight.FOV() == false;
    }
}
