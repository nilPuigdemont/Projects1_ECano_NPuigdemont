using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/stats")]
public class EnemyStats : ScriptableObject
{
    public float maxHealth;
    public float currentHealth;

    public float speed;

}
