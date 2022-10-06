using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected int damage;

    public int Damage => damage;

    public abstract void Shoot();
}
