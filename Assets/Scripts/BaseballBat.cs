using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseballBat : BaseWeapon
{
    private Animator _animator;
    [SerializeField] private int force;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    private IEnumerator WaitForWormSwitch()
    {
        yield return new WaitForSeconds(5);
        GameManager.Instance.SwitchWorm();
    }
    
    public override void Shoot()
    {
        _animator.SetTrigger("Swing");
        StartCoroutine(WaitForWormSwitch());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Vector3 direction = force * (transform.rotation * (Vector3.forward + Vector3.left));
        other.gameObject.GetComponent<Rigidbody>().AddForce(direction);
        other.gameObject.GetComponent<Worm>().TakeDamage(Damage);
        GameManager.Instance.playerCamera.GetComponent<CameraMovement>().target = other.gameObject.transform;
    }
}
