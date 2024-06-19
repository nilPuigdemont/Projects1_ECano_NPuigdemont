using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public GameObject bullet;

    public float accuracy;
    public float numberBullets;
    public int maxBullets;
    [HideInInspector] public int currentBullets;
    

    public float secBeetweenShots;
    float secondsSinceLastShot;
    
   

  


    public AudioSource audioSource;
    public float kickAmount;


    public Transform shotPos;
    Rigidbody2D rb;

    [HideInInspector] public bool playerSeen = false;

    void Start()
    {
        secondsSinceLastShot = secBeetweenShots;
        currentBullets = maxBullets;
        audioSource = GetComponent<AudioSource>();  
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        secondsSinceLastShot += Time.deltaTime;
        
        if (References.player != null && playerSeen == true)
        {
            LookToTarget(References.player.transform.position);
        }
        
    }


    public void Fire()
    {

        if (secondsSinceLastShot >= secBeetweenShots)
        {
    
            audioSource.Play();
            currentBullets--;

            for (int i = 0; i < numberBullets; i++)
            {
                
                    
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

    public void Reload()
    {
        currentBullets = maxBullets;
                 
        
    }

}

