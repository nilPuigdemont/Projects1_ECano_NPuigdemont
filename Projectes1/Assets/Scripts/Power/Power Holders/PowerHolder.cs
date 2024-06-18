using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Power")]
public class PowerHolder : ScriptableObject
{
    public float manaCost;
    public float damage;

    public GameObject powerGameObject;
}
