using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    [Header("Players")]
    public GameObject playerOne;
    public GameObject playerTwo;

    //public int fps = 30;

    [Header("Movement")]
    public float moveSpeed = 12f;

    private float moveY;
    private float moveYTwo;

    private Rigidbody2D rb1;
    private Rigidbody2D rb2;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        rb1 = playerOne.GetComponent<Rigidbody2D>();
        rb2 = playerTwo.GetComponent<Rigidbody2D>();
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
        //Application.targetFrameRate = fps;

        moveY = playerControls.Player.Movement.ReadValue<float>();
        moveYTwo = playerControls.PlayerTwo.Movement.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        Move(moveY);
        MoveTwo(moveYTwo);
    }

    private void Move(float input)
    {
        // MUST ADD TIMEDELTA - MAKING IT SLOW NOW IDK
        rb1.velocity = new Vector2(rb1.velocity.x, input * moveSpeed);
    }

    private void MoveTwo(float input)
    {
        rb2.velocity = new Vector2(rb2.velocity.x, input * moveSpeed);
    }


}
