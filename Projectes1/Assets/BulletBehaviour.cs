using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;

    public float damage = 100f;
    private GameObject player;
    Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position- transform.position;

        rb.velocity = new Vector2 (direction.x, direction.y).normalized * speed;
    }
    public void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
}
