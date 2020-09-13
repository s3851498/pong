using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Access
    private Rigidbody2D rigidPaddle;

    // Game experience
    public float speed = 10.0f;
    public float boundary = 4.09f;

    // Controls
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;

    // Called at game start
    void Start()
    {
        rigidPaddle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = rigidPaddle.velocity;
        if (Input.GetKey(moveUp))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0;
        }
        rigidPaddle.velocity = velocity;

        var position = transform.position;
        if (position.y > boundary)
        {
            position.y = boundary;
        }
        else if (position.y < -boundary)
        {
            position.y = -boundary;
        }
        transform.position = position;
    }
}
