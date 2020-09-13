using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{

    // Access
    private Rigidbody2D rigidBall;

    // Ball launch parameters
    public int ballx = 20;
    public int bally = -15;

    // Start is called before the first frame update
    void Start()
    {
        rigidBall = GetComponent<Rigidbody2D>();
        Invoke("LaunchSelect", 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 velocity;
            velocity.x = rigidBall.velocity.x;
            velocity.y = (rigidBall.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rigidBall.velocity = velocity;
        }
    }

    // Puts the ball in center (Refactor later for setting to player paddle etc)
    void ResetToCeter()
    {
        rigidBall.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetToCeter();
        Invoke("LaunchSelect", 2);
    }

/*    void Invoke()
    {
        LaunchSelect();
    }*/

    // Choose if a direction or a random launch
    void LaunchSelect()
    {
        RandomLaunch();
    }

    // Send launch direction
    void LaunchBall(int x, int y)
    {
        rigidBall.AddForce(new Vector2(x, y));
    }

    // This is the default for now
    void RandomLaunch()
    {
        float random = Random.Range(0, 2);
        if (random < 1)
        {
            LaunchBall(ballx, bally);
        } else
        {
            LaunchBall(-ballx, bally);
        }
    }
}
