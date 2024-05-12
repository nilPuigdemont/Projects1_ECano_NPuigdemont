using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{

    public GameObject bullet;
    public Transform shootPos;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
       Instantiate(bullet, shootPos.position,Quaternion.identity);
    }
}
