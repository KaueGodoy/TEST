using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerControls playerControls;
    private Rigidbody2D rb;

    [Header("Movement")]
    public float moveSpeed = 12f;
    private float moveY;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        moveY = playerControls.Player.Movement.ReadValue<float>();


    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveY * moveSpeed * Time.deltaTime);
        //rb.AddForce(new Vector2(0f, moveY * moveSpeed * Time.deltaTime), ForceMode2D.Impulse);
    }
}
