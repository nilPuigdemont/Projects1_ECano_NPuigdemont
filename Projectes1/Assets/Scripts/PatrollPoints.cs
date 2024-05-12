using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollPoints : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPoints;

    private int _currentPoint = 0;


    public Transform GetNext()
    {
        var point = _patrolPoints[_currentPoint];
        _currentPoint = (_currentPoint + 1)% _patrolPoints.Length;
        return point;
    }


    public bool HasReached(PatrollingAgent agent)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if(!agent.hasPath || agent.velocity.sqrMagnitude == 0)
            {
                return true;
            }
        }
        return false;
    }
   
}
