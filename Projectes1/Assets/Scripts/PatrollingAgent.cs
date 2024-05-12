using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingAgent : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;

    private Vector2 destination;

    public float speed;
    [HideInInspector] public float stoppingDistance = 0.001f;
    public bool hasPath {  get; private set; }

    public float remainingDistance
    {
        get { return (destination - new Vector2(transform.position.x, transform.position.y)).magnitude; }
    }

    public Vector2 velocity { get { return rb.velocity; } }


    Vector2 lookAt;
    Vector2 moveDirection;
    public void SetDestination(Vector2 newDestination)
    {
        destination = newDestination;
        hasPath = true;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();

        hasPath = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;

        UpdateAnimation();
    }

     void Update()
    {
        if(hasPath) 
        {
            moveDirection = Vector2.zero;

            if(remainingDistance > stoppingDistance)
            {
                moveDirection = (destination - new Vector2(transform.position.x
                    , transform.position.y)).normalized; 
            }

        }

        if(moveDirection.sqrMagnitude > 0.0f)
        {
            lookAt = moveDirection;
        }
    }

    void UpdateAnimation()
    {
        animator.SetBool("moving", true);
    }
}
