using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 200f;

    private Rigidbody2D rb;
    private float moveInput;
    private float rotationInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {

        moveInput = 0f;
        rotationInput = 0f;

        if (Input.GetKey(KeyCode.W))
            moveInput = 1f;
        if (Input.GetKey(KeyCode.S))
            moveInput = -1f;

        if (moveInput != 0f)
        {
            if (Input.GetKey(KeyCode.A))
                rotationInput = 1f;
            if (Input.GetKey(KeyCode.D))
                rotationInput = -1f;
        }

    }

    private void FixedUpdate()
    {

        float turnSign = (moveInput < 0f) ? -1f : 1f;
        float deltaRot = rotationInput * rotationSpeed * turnSign * Time.fixedDeltaTime;

        rb.MoveRotation(rb.rotation + deltaRot);

        
        Vector2 forward = transform.up; 
        rb.MovePosition(rb.position + forward * moveInput * moveSpeed * Time.fixedDeltaTime);

    }
}
