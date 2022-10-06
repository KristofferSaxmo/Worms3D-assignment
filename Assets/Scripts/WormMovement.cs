using System;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    [SerializeField] private StaminaBar staminaBar;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpHeight;
    public float maxTravelDistance;
    private Rigidbody _rb;
    private Vector3 _moveDirection;
    private bool _inAir;
    private Vector3 _startingPos;
    public float TravelDistance { get; private set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _startingPos = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && _inAir == false)
            Jump();
        TravelDistance = Vector3.Distance(_startingPos, transform.position);
        if (TravelDistance > maxTravelDistance)
            GetComponent<WormMovement>().enabled = false;
    }

    private void Move()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        if (verticalInput != 0)
        {
            transform.position += movementSpeed * Time.deltaTime * verticalInput * transform.forward;
            staminaBar.UpdateBar(TravelDistance, maxTravelDistance);
        }
        if (horizontalInput != 0)
            transform.Rotate(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
    }

    private void Jump()
    {
        _rb.AddForce(0, jumpHeight, 0);
        _inAir = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
            _inAir = false;
    }
}
