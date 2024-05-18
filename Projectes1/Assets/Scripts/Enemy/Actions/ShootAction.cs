using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "FSM/Actions/Shoot")]
public class ShootAction : FSMAction
{
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
}
