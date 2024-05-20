using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float radius = 5f;
    [Range(1,360)]public float angle = 45f;
    public LayerMask targetLayer;

    private GameObject playerRef;
    public bool CanSeePlayer {  get; private set; } 
    public void Awake()
    {
        playerRef = References.player;
    }

    public void Update()
    {
        
    }


    public bool FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if(rangeCheck.Length > 0 )
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if(Vector2.Angle(transform.up, directionToTarget)< angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if(!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, References.wallLayer))
                {
                    return true;
                }else return false;
            }
            else return false;
        }
        return false;
        /*else if (CanSeePlayer)
        {
            CanSeePlayer = false;
        }*/
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.white;

        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle1 = DirectionFromAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle2 = DirectionFromAngle(-transform.eulerAngles.z, angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle1 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle2 * radius);

        if (CanSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, References.player.transform.position);
        }
#endif
    }

    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 
                           Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

    }



}
