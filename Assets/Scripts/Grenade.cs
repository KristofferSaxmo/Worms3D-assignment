using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
public class Grenade : MonoBehaviour
{
    [SerializeField] private float secondsUntilExplosion;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForce;
    [SerializeField] private ParticleSystem explosion;
    
    public int Damage { private get; set; }
    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(secondsUntilExplosion);

        explosion.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider obj in colliders)
        {
            if (!obj.CompareTag("Player")) continue;
            
            obj.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
            obj.GetComponent<Worm>().TakeDamage(Damage);
        }
        Destroy(transform.GetChild(0).gameObject);
        GetComponent<Rigidbody>().Sleep();
        yield return new WaitForSeconds(3);
        GameManager.Instance.SwitchWorm();
        Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(Explode());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Water")
        {
            GameManager.Instance.SwitchWorm();
            Destroy(gameObject);
        }
    }
}
