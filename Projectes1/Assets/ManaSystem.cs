using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ManaBar;

    public float MaxMana;

    public float currentMana;

    ManaBarBehaviour manaBarBehaviour;

    void Start()
    {
        currentMana = MaxMana;
        manaBarBehaviour = ManaBar.GetComponent<ManaBarBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMana > MaxMana)
        {
            currentMana = MaxMana;
        }

        if (currentMana < 0)
        {
            currentMana = 0;
        }

        manaBarBehaviour.ShowManaFraction(currentMana/MaxMana);

    }

    public void CastAttack(float manaCost)
    {
        currentMana-=manaCost;
    }
}
