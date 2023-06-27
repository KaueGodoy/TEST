using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.XR.Haptics;

public class PlayerController : MonoBehaviour
{
    [Header("Players")]
    public GameObject playerOne;
    public GameObject playerTwo;

    //public int fps = 30;

    [Header("Movement")]
    public float moveSpeedPlayerOne;
    public float moveSpeedPlayerTwo;
    public float moveSpeedMultiplierIncrease = 2f;
    public float moveSpeedMultiplierDecrease;

    private const float DefaultSpeed = 12f;
    private float MaxSpeed;

    private float moveY;
    private float moveYTwo;

    private Vector2 direction;

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

        ResetMoveSpeed();

        MaxSpeed = DefaultSpeed + (moveSpeedMultiplierIncrease * 100);
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

        direction = new Vector2(rb1.velocity.x, moveY).normalized;

        if (playerControls.Player.SpeedUp.triggered)
        {
            // hold speed value before calculations 12
            float currentSpeed = moveSpeedPlayerOne;

            // mutiply moveSpeed by mutiplier = 12 * 2 = 24
            moveSpeedPlayerOne *= moveSpeedMultiplierIncrease;

            // if speed value after calculation > MaxSpeed set the speed to be the the one before calculation
            // if max speed 25, 24 * 2 = 48, set the moveSpeed to the current speed = the last multiplied speed before calculation going past limit
            if (moveSpeedPlayerOne > MaxSpeed)
            {
                moveSpeedPlayerOne = currentSpeed;
            }

        }


        if (playerControls.Player.SpeedDown.triggered)
        {
            if (moveSpeedPlayerOne > DefaultSpeed)
            {
                moveSpeedMultiplierDecrease = 1 / moveSpeedMultiplierIncrease;

                moveSpeedPlayerOne *= moveSpeedMultiplierDecrease;
            }

        }

    }

    private void FixedUpdate()
    {
        Move();
        MoveTwo(moveYTwo);
    }

    private void ResetMoveSpeed()
    {
        moveSpeedPlayerOne = DefaultSpeed;
        moveSpeedPlayerTwo = DefaultSpeed;
    }

    private void Move()
    {
        // MUST ADD TIMEDELTA - MAKING IT SLOW NOW IDK
        // normalize ???    

        rb1.velocity = direction * moveSpeedPlayerOne;
    }

    private void MoveTwo(float input)
    {
        rb2.velocity = new Vector2(rb2.velocity.x, input * moveSpeedPlayerTwo);
    }


}
