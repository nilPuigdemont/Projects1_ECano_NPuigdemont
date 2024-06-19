using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "FSM/Actions/Shock")]
public class ShockAction : FSMAction
{
    public GameObject ShockFx;
    private GameObject shockRay;

    private float currentTime = 0;
    public float timeToPass;

    [SerializeField] private BaseState state;
    public override void OnEnter(BaseStateMachine stateMachine)
    {
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        patrollingAgent.hasPath = false;
        var weaponBehaviour = stateMachine.GetComponent<WeaponBehavior>();
        weaponBehaviour.playerSeen = false;

        var animator = stateMachine.GetComponentInChildren<Animator>();

        animator.Play("PlayerIdle");

        shockRay = Instantiate(ShockFx, stateMachine.gameObject.transform.position, ShockFx.transform.rotation);
        shockRay.transform.parent = stateMachine.gameObject.transform;
    }

    public override void Execute(BaseStateMachine stateMachine)
    {
        currentTime += Time.deltaTime;

        if (currentTime>= timeToPass)
        {
            stateMachine.CurrentState = state;
            
        }
    }

    public override void OnExit(BaseStateMachine stateMachine)
    {
        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        patrollingAgent.hasPath = true;
        var weaponBehaviour = stateMachine.GetComponent<WeaponBehavior>();
        weaponBehaviour.playerSeen = true;
        currentTime = 0;

        var animator = stateMachine.GetComponentInChildren<Animator>();
        animator.Play("playerWalkUp");
        Destroy(shockRay);
    }


}
