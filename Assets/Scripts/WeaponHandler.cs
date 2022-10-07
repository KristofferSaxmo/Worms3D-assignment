using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    private BaseWeapon _currentWeapon;
    [SerializeField] private WormMovement wormMovement;
    
    private void Awake()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        _currentWeapon = transform.GetChild(0).gameObject.GetComponent<BaseWeapon>();
        _currentWeapon.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchWeapon(2);

        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot();
            wormMovement.enabled = false;
            enabled = false;
        }
    }

    private void SwitchWeapon(int weaponIndex)
    {
        _currentWeapon.gameObject.SetActive(false);
        _currentWeapon = transform.GetChild(weaponIndex - 1).GetComponent<BaseWeapon>();
        _currentWeapon.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
    }
}
