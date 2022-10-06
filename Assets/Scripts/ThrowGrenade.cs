using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : BaseWeapon
{
    [SerializeField] private float throwForceForward;
    [SerializeField] private float throwForceUp;

    private void OnEnable()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public override void Shoot()    
    {
        GameObject grenade = Instantiate(Resources.Load("Prefabs/Grenade") as GameObject, transform.position, transform.rotation);
        grenade.GetComponent<Grenade>().Damage = Damage;
        Vector3 trajectory = throwForceForward * transform.forward + Vector3.up * throwForceUp;
        grenade.GetComponent<Rigidbody>().AddForce(trajectory);
        GameManager.Instance.playerCamera.GetComponent<CameraMovement>().target = grenade.transform;

        transform.GetChild(0).gameObject.SetActive(false);
    }
}
