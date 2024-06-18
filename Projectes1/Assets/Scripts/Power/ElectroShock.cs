using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ElectroShock : MonoBehaviour
{

    public float radius;
    public BaseState shock;
    public float speed;
    private Rigidbody2D rb;

    private float currentTime;
    public float destroyTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        rb.velocity = transform.up * speed;
        
        Collider2D[] shockRange = Physics2D.OverlapCircleAll(transform.position, radius);    

        for (int i = 0; i < shockRange.Length; i++)
        {
            if (shockRange[i].GetComponent<BaseStateMachine>()) 
            {
                ApplyShock(shockRange[i]);
            }
            
        }

        if (currentTime >= destroyTime)
        {
            Destroy(gameObject);
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
