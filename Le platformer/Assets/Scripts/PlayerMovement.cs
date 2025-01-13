using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpSpeed = 20f;
    [SerializeField] float jumpForce = 20f;
    [SerializeField] ContactFilter2D groundFilter;
    Vector2 moveInput;
    Rigidbody2D rb;
    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void Update()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }
    void OnJump()
    {
        Jump();
    }
    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
        
    }
    private void FixedUpdate()
    {
        isGrounded = rb.IsTouching(groundFilter);
    }

}
