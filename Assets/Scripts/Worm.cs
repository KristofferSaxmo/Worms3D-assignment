using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;
public class Worm : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }
    public int Health { get; private set; }
    public int TeamNumber { get; set; }
    [SerializeField] private HealthBar healthBar;
    private void Start()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.UpdateBar(Health, MaxHealth);
        if (Health > 0) return;
        if (GameManager.Instance.CurrentWorm == gameObject)
            GameManager.Instance.SwitchWorm();
        GameManager.Instance.RemoveWorm(gameObject);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.GetContact(0).otherCollider.gameObject;
        
        if (collisionObject.name == "Water")
            TakeDamage(1000);
        
        if (!collisionObject.CompareTag("Weapon")) return;
        
        TakeDamage(collisionObject.GetComponent<BaseWeapon>().Damage);
    }
}