using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public State currentState;

    public EnemyStats enemyStats; // scriptableObject that contains all stats of enemy 

    private bool aiActive;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    //public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;

    public PatrollingAgent patrollingAgent;
    public PatrollPoints patrollPoints;

    private void Awake()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
        patrollingAgent= GetComponent<PatrollingAgent>();
    }
    void Start()
    {
        enemyStats.currentHealth = enemyStats.Maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    /*private void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmosColor;
            Gizmos.DrawWireSphere(transform.position,0.5f);
            
        }
    }*/
}
