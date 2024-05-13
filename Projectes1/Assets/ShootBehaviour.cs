using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{

    public GameObject bullet;
    public Transform shootPos;

    public float timeBetweenShoot;
    private float currentTime;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        LookToTarget(References.player.transform.position);   
        
        currentTime += Time.deltaTime;

    }

    public void Shoot()
    {
        if (CanShoot())
        {
            
            Instantiate(bullet, shootPos.position, transform.rotation);
            currentTime = 0;
        }
       
    }

    private bool CanShoot()
    {
        if (currentTime >= timeBetweenShoot)
        {
            return true;
        }

        return false;
    }

    private void LookToTarget(Vector3 target)
    {

        Vector3 lookDirection = target - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }
}
