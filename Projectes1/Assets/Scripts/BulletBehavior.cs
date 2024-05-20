using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public float bulletSpeed;
    protected Rigidbody2D rb;
    public float secUntilDestroy;
    public float damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject player = References.player;
        Vector3 direction = player.transform.position - transform.position;

        rb.velocity =  transform. up * bulletSpeed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        secUntilDestroy -= Time.deltaTime;

        if(secUntilDestroy <1) 
        {
            transform.localScale *= secUntilDestroy;
        }
       
        if (secUntilDestroy < 0 )
        {
            Destroy(gameObject);
        }

    }



    private void OnTriggerEnter2D(Collider2D other)
    {

            HealthSystem otherHealth = other.gameObject.GetComponent<HealthSystem>();
            if(otherHealth != null ) 
            {
                otherHealth.TakeDamage(damage);
                Destroy(gameObject);
            }

            if(other.gameObject.tag == "Explosive")
            {
               
                other.GetComponent<BarrelExplosionBehaviour>().Explosion();

            }

            Destroy(gameObject);

    }
}
