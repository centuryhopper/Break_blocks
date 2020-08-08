using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    // get the vector for the distance between the paddle and the ball
    Vector2 paddleToBall;

    // we need an object for the paddle itself
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVal = 2f, yVal = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactorUpperBound = 0.2f;

    // cached reference
    AudioSource aud;
    Rigidbody2D rigidbody2d;

    bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        // paddle1 = new Paddle();
        hasStarted = false;
        paddleToBall = transform.position - paddle1.transform.position;
        aud = GetComponent<AudioSource>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
            LockBallToPaddle();

        LaunchOnMouseClick();
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;

            // velocity is basically change in position,
            // so it makes sense to have a datatype of Vector2
            rigidbody2d.velocity = new Vector2(xVal, yVal);
        }
        else
        {
            return;
        }
    }

    private void LockBallToPaddle()
    {
        // capture the position of the paddle, which we'll put
        // in this method because it's constantly changing
        float xPaddle = paddle1.transform.position.x,
            yPaddle = paddle1.transform.position.y;
        Vector2 paddlePosition = new Vector2(xPaddle, yPaddle);

        // position of the ball is always changing
        transform.position = paddlePosition + paddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float randomRange = randomFactorUpperBound;
        Vector2 velocityTweak = new Vector2(randomRange, randomRange);

        if (hasStarted)
        {
            rigidbody2d.velocity += velocityTweak;
            aud.PlayOneShot(ballSounds[Random.Range(0, ballSounds.Length)]);
        }
    }
}
