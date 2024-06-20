using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BarrelExplosionBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius;
    public float damage;
    public GameObject ExplosionFX;
    public AudioClip ExplosionAudioClip;
    
   
    // Update is called once per frame

    private void Start()
    {
        
    }

    void Update()
    {
        Collider2D[] inRange = Physics2D.OverlapCircleAll(transform.position, radius);

        for(int i = 0; i < inRange.Length; i++)
        {
            Debug.Log("isInRange");
        }
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.white;
        Handles.DrawWireDisc(transform.position, Vector3.forward ,radius);
#endif
    }


    public void Explosion()
    {
        Collider2D[] inRange = Physics2D.OverlapCircleAll(transform.position, radius);

        SoundManager.Instance?.PlayAudio(ExplosionAudioClip);

        Destroy(gameObject);

        for (int i = 0; i < inRange.Length; i++)
        {
            if (inRange[i].GetComponent<HealthSystem>() != null) 
            {
                inRange[i].GetComponent<HealthSystem>().TakeDamage(damage);
            }

            if (inRange[i].gameObject.tag == "Explosive")
            {
                inRange[i].GetComponent<BarrelExplosionBehaviour>().Explosion();
            }
        }
        Instantiate(ExplosionFX, transform.position, ExplosionFX.transform.rotation);

        

    }
}
