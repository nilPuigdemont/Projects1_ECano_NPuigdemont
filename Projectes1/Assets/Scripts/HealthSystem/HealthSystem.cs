using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [FormerlySerializedAs("health")]
    public float maxHealth;
    [HideInInspector] public float currentHealth;

    public GameObject healthBarPrefab;
    public GameObject deathEffectPrefb;

    HealthBarBehavior myHealthBar;
    public Transform canvas;

    public AudioClip HurtClip;
    public GameObject BloodFx;
    [SerializeField] private float offset;

    public void TakeDamage(float damageAmount)
    {

        SoundManager.Instance?.PlayAudio(HurtClip);

        if(BloodFx != null ) 
        {
            Instantiate(BloodFx, transform.position, BloodFx.transform.rotation);
        }
        

        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                if (deathEffectPrefb != null)
                {
                    Instantiate(deathEffectPrefb, transform.position, transform.rotation);
                }
                if(this.gameObject.tag == "Player")
                {
                    LevelManager.Instance.palyerDead = true;
                }
                Destroy(gameObject);

            }
        }
        

    }
    private void OnDestroy()
    {
        //don't create anything in the ondestroy Event - it's only for cleanning up after
        if(myHealthBar != null)
        {
            Destroy(myHealthBar.gameObject);
        }
        
    }
    void Start()
    {
        currentHealth = maxHealth;
        LevelManager.Instance.palyerDead = false;

        GameObject healthBarObj = Instantiate(healthBarPrefab, canvas.transform);
        myHealthBar = healthBarObj.GetComponent<HealthBarBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        myHealthBar.ShowHealthFraction(currentHealth/maxHealth);

        myHealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * offset); 
    }
}
