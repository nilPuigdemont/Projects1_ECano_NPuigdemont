using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ElectroShock : Power
{

    public float radius;
    public BaseState shock;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] shockRange = Physics2D.OverlapCircleAll(transform.position, radius);    

        for (int i = 0; i < shockRange.Length; i++)
        {
            ApplyShock(shockRange[i]);
        }

    }

    private void ApplyShock(Collider2D shockedEnemy)
    {
        var stateMachine = shockedEnemy.GetComponent<BaseStateMachine>();
        stateMachine.CurrentState = shock;
    }

    private void OnDrawGizmos()
    {

#if UNITY_EDITOR
        Gizmos.color = Color.white;
        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
#endif
    }
}
