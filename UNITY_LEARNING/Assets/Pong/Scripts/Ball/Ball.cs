using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    public float initialSpeed = 5f;
    public float moveSpeed = 2f;

    private int playerOneScore = 0;
    private int playerTwoScore = 0;

    Vector2 initialPosition;

    [Header("UI")]
    public TextMeshProUGUI playerOneScoreText;
    public TextMeshProUGUI playerTwoScoreText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    private void Start()
    {
        ResetScore();
        StartGame();
    }

    public void StartGame()
    {
        rb.velocity = new Vector2(initialSpeed * moveSpeed, initialSpeed * moveSpeed);
    }

    private void ResetPosition()
    {
        transform.position = initialPosition;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // border collision

        if (collision.CompareTag("BorderHorizontal"))
        {
            // bounce
            Debug.Log("BorderHorizontal");
        }

        if (collision.CompareTag("BorderPlayerOne"))
        {
            // player two gets 1 point
            playerTwoScore++;
            UpdateUI();
            ResetPosition();

            Debug.Log("BorderPlayerOne");
            Debug.Log(playerTwoScore);
        }

        if (collision.CompareTag("BorderPlayerTwo"))
        {
            // player one gets 1 point
            playerOneScore++;
            UpdateUI();
            ResetPosition();

            Debug.Log("BorderPlayerTwo");
            Debug.Log(playerOneScore);

        }

        // player collision

        if (collision.CompareTag("PlayerOne"))
        {
            // bounce
            Debug.Log("PlayerOne");
        }

        if (collision.CompareTag("PlayerTwo"))
        {
            // bounce
            Debug.Log("PlayerTwo");
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Calculate the collision normal
        Vector2 collisionNormal = collision.contacts[0].normal;

        // Calculate the new direction using the collision normal
        Vector2 newDirection = Vector2.Reflect(rb.velocity.normalized, collisionNormal);

        // Apply the new direction
        rb.velocity = newDirection * initialSpeed;
    }



    public void ResetScore()
    {
        playerOneScore = 0;
        playerTwoScore = 0;

        playerOneScoreText.text = "" + playerOneScore;
        playerTwoScoreText.text = "" + playerTwoScore;
    }

    public void UpdateUI()
    {
        playerOneScoreText.text = "" + playerOneScore;
        playerTwoScoreText.text = "" + playerTwoScore;
    }

}
