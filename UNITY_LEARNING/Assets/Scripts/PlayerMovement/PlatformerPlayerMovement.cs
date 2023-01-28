using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformerPlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    private float moveX = 0f;
    public float moveSpeed = 5f;

    public float jumpForce = 4f;

    private void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        // horizontal movement
        moveX = Input.GetAxisRaw("Horizontal");

        if(moveX > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if(moveX < 0f)
        {
            spriteRenderer.flipX = true;
        }

        // jump
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
      
    }

    void Move()
    {
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }
}
