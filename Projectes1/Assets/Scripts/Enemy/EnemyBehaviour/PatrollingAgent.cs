using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrollingAgent : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    private Vector2 destination;


    [HideInInspector]public float moveSpeed;
    public float stoppingDistance = 0.001f;

    BaseStateMachine stateMachine;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<BaseStateMachine>();
    }
    public bool hasPath { get;  set; }

    public float remainingDistance
    {
        get
        {
            return (destination - new Vector2(transform.position.x, 
                   transform.position.y)).magnitude;
        }
    }

    public Vector2 velocity
    {
        get
        {
            return rb.velocity;
        }
    }

    Vector2 lookAt;
    Vector2 moveDirection;

    public void SetDestination(Vector2 newDestination)
    {
        destination = newDestination;
        hasPath = true;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = stateMachine.speed;

        hasPath = false;
    }

    void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
        
        UpdateAnimation();

        if(hasPath) 
        {
            LookToTarget(destination); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        


        if (hasPath)
        {
            moveDirection = Vector2.zero;

            if (remainingDistance > stoppingDistance)
                moveDirection = (destination - new Vector2(transform.position.x, 
                                 transform.position.y)).normalized;
                
        }else if (!hasPath) { moveDirection = moveDirection = Vector2.zero; }

        
    }

    void UpdateAnimation()
    {
        if (animator != null)
        {
            animator.SetFloat("LookAtX", lookAt.x);
            animator.SetFloat("LookAtY", lookAt.y);
            animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        }
    }

    private void LookToTarget(Vector3 target)
    {

        Vector3 lookDirection = target - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    } 


}
