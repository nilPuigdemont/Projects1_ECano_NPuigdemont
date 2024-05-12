using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableIA/Actions/Patrol")]

public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
       Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
      var patrolAgent = controller.GetComponent<PatrollingAgent>();
      var patrollPoints = controller.GetComponent<PatrollPoints>();
       
        if(patrollPoints.HasReached(patrolAgent))
        {
            patrolAgent.SetDestination(patrollPoints.GetNext().position); 
        }
    }

}
