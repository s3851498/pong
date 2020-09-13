using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Access
    private Rigidbody2D rigidPaddle;

    // Game experience
    public float speed = 10.0f;
    public float boundary = 4.09f;

    // Controls
    //public KeyCode moveUp = KeyCode.W;
    //public KeyCode moveDown = KeyCode.S;
    PlayerControls controls;
    Vector2 move;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;

        controls.Player.Up.performed += ctx => moveUp();
        controls.Player.Down.performed += ctx => moveDown();
    }

    // Called at game start
    void Start()
    {
        rigidPaddle = GetComponent<Rigidbody2D>();
    }

    void moveUp()
    {
        var velocity = rigidPaddle.velocity;
        velocity.y = speed;
        rigidPaddle.velocity = velocity;
        Debug.Log("UP");
    }

    void moveDown()
    {
        var velocity = rigidPaddle.velocity;
        velocity.y = -speed;
        rigidPaddle.velocity = velocity;
        velocity.y = 0;
        Debug.Log("DOWN");
    }

    private void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
       // Debug.Log("Test move " + move.y);


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

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }


    /* // Old Code prior to new Input management system
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
     }*/
}
