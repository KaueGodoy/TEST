using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    public float initialSpeed = 5f;
    public float extraSpeed = 2f;
    public float maxExtraSpeed = 52f;
    public float ballSpeed;

    private int hitCounter = 0;

    // score
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
        StartCoroutine(Launch());

    }

    private IEnumerator Launch()
    {
        hitCounter = 0;

        float randomValue = 0f;
        do
        {
            randomValue = Random.Range(-1f, 1f);
        } while (Mathf.Approximately(randomValue, 0f));

        yield return new WaitForSeconds(1f);


        Move(new Vector2(randomValue, 0));
    }

    private void Move(Vector2 direction)
    {
        direction = direction.normalized;
        ballSpeed = initialSpeed + hitCounter * extraSpeed;
        rb.velocity = direction * ballSpeed;
        Debug.Log("Ball speed: " + ballSpeed);
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
            Debug.Log("Player two score: " + playerTwoScore);
        }

        if (collision.CompareTag("BorderPlayerTwo"))
        {
            // player one gets 1 point
            playerOneScore++;
            UpdateUI();
            ResetPosition();

            Debug.Log("BorderPlayerTwo");
            Debug.Log("Player one score: " + playerOneScore);

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
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // Calculate the collision normal
    //    Vector2 collisionNormal = collision.contacts[0].normal;

    //    // Calculate the new direction using the collision normal
    //    Vector2 newDirection = Vector2.Reflect(rb.velocity.normalized, collisionNormal);

    //    // Apply the new direction
    //    rb.velocity = newDirection * initialSpeed;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerOne" || collision.gameObject.name == "PlayerTwo")
        {
            Bounce(collision);
        }
    }

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 paddlePosition = collision.transform.position;
        float paddleHeight = collision.collider.bounds.size.y;

        float positionX;

        if (collision.gameObject.name == "PlayerOne")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - paddlePosition.y) / paddleHeight;

        IncreaseHitCounter();
        Debug.Log("Hit counter: " + hitCounter);
        Move(new Vector2(positionX, positionY));

    }

    private void IncreaseHitCounter()
    {
        if (hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }

    public void ResetScore()
    {
        playerOneScore = 0;
        playerTwoScore = 0;

        UpdateUI();
    }

    private void ResetPosition()
    {
        rb.velocity = Vector3.zero;
        transform.position = initialPosition;
        StartCoroutine(Launch());
    }

    public void UpdateUI()
    {
        playerOneScoreText.text = "" + playerOneScore;
        playerTwoScoreText.text = "" + playerTwoScore;
    }

}
