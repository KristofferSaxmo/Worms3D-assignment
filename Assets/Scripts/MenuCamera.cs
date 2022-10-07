using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    [SerializeField] private Vector3 focusPointPosition;
    [SerializeField] private float rotationSpeed;
    private Vector3 _offset;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        _offset = transform.position - focusPointPosition;
    }

    private void LateUpdate()
    {
        _offset = Quaternion.AngleAxis(rotationSpeed, Vector3.up) * _offset;
        transform.position = focusPointPosition + _offset;
        transform.LookAt(focusPointPosition);
    }
}
