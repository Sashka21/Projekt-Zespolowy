using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 9f;
    [SerializeField] private float rotationSpeed = 300f;
    [SerializeField] private float deceleration = 9f;
    [SerializeField] private float brakeDeceleration = 28f;
    [SerializeField] private float acceleration = 16f;

    private Rigidbody2D rb;

    private float moveInput;   // -1 .. 0 .. +1, W/S
    private float turnInput;   // -1 .. 0 .. +1, A/D

    private float currentSpeed = 0f;
    private const float speedEpsilon = 0.05f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Movement input
        moveInput = 0f;
        if (Input.GetKey(KeyCode.W)) moveInput = 1f;
        if (Input.GetKey(KeyCode.S)) moveInput = -1f;

        // Turning input
        turnInput = 0f;
        if (Input.GetKey(KeyCode.D)) turnInput = -1f;
        if (Input.GetKey(KeyCode.A)) turnInput = 1f;
    }

    private void FixedUpdate()
    {
        // Acceleration / Deceleration / Brake Deceleration
        if (moveInput != 0)
        {
            bool oppositeDirection = Mathf.Sign(currentSpeed) != Mathf.Sign(moveInput) && currentSpeed != 0f;

            if (oppositeDirection)
            {
                // Active braking
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, brakeDeceleration * Time.fixedDeltaTime);
            }
            else
            {
                // Normal acceleration
                currentSpeed = Mathf.MoveTowards(currentSpeed, moveInput * maxSpeed, acceleration * Time.fixedDeltaTime);
            }
        }
        else
        {
            // Passive deceleration
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.fixedDeltaTime);
        }

        // Clamp max speed
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Rotation
        bool canTurn = Mathf.Abs(currentSpeed) > speedEpsilon;

        if (canTurn)
        {
            float turnSign = (currentSpeed < 0f) ? -1f : 1f;
            float rotation = turnInput * rotationSpeed * turnSign * Time.fixedDeltaTime;
            rb.MoveRotation(rb.rotation + rotation);
        }

        // Forward movement
        Vector2 forward = (Vector2)transform.up;
        rb.MovePosition(rb.position + forward * currentSpeed * Time.fixedDeltaTime);
    }
}
