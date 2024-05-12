using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "FSM/Actions/Shoot")]
public class ShootAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        var enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();

        var enemyShootBehaviour = stateMachine.GetComponent<ShootBehaviour>();

        enemyShootBehaviour.Shoot();

    }
}
