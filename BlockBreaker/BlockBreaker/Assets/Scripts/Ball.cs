using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float randomFactor = 0.2f;

    private Vector2 paddleToBallVector;

    private bool hasStarted = false;


    private AudioSource myAudioSource;
    private Rigidbody2D myRigidbody2D;


    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        var paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (hasStarted)
        {
            var velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
            myRigidbody2D.velocity += velocityTweak;
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];           
            myAudioSource.PlayOneShot(clip);            
        }
    }
}
