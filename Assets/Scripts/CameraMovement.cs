using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CameraMovement : MonoBehaviour
{
    [HideInInspector] public Transform target;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        if (target == null) return;
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = target.transform.position + offset;
        transform.LookAt(target.position);
    }
}
