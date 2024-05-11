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
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;

    private void Awake()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        enemyStats.currentHealth = enemyStats.Maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!aiActive)
        {
            return;
        }

        currentState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmosColor;
            Gizmos.DrawWireSphere(transform.position,0.5f);
            
        }
    }
}
