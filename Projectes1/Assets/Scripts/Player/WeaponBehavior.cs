using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public GameObject bullet;

    public float accuracy;
    public float numberBullets;

    public float secBeetweenShots;
    float secondsSinceLastShot;


    public AudioSource audioSource;
    public float kickAmount;

    public Transform shotPos;
    Rigidbody2D rb;

    void Start()
    {
        secondsSinceLastShot = secBeetweenShots;
        audioSource = GetComponent<AudioSource>();  
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        secondsSinceLastShot += Time.deltaTime;
        LookToTarget(References.player.transform.position);
    }


    public void Fire()
    {

        if (secondsSinceLastShot >= secBeetweenShots)
        {

            /*References.spawner.activated = true; //shooting alerts the spawner
            audioSource.Play();
            References.screenShake.joltVector = transform.forward * kickAmount;
            */

            for (int i = 0; i < numberBullets; i++)
            {
                //GameObject newBullet = 
                    
                Instantiate(bullet, shotPos.position, transform.rotation);

                //offset of the target pos by a random amount, according to inaccuracy

                /*float inaccuracy = Vector3.Distance(transform.position, targetPosition) / accuracy;

                Vector3 inaccuratePosition = targetPosition;

                inaccuratePosition.x += Random.Range(-inaccuracy, inaccuracy);
                inaccuratePosition.y += Random.Range(-inaccuracy, inaccuracy);
                */
                
                secondsSinceLastShot = 0;
            }
            
        }
    }

    private void LookToTarget(Vector3 target)
    {

        Vector3 lookDirection = target - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }
}

