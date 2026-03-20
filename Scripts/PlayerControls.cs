using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 5f;

    // Airgirl
    private Rigidbody2D rb2dA;
    private Vector2 inputA;

    // Earthboy
    private Rigidbody2D rb2dE;
    private Vector2 inputE;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2dA = GameObject.Find("Airgirl").GetComponent<Rigidbody2D>();
        rb2dE = GameObject.Find("Earthboy").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Airgirl movement (WAD)
        inputA = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputA += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputA += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputA += Vector2.right;
        }

        // Earthboy movement (arrows)
        inputE = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputE += Vector2.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputE += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputE += Vector2.right;
        }
    }

    // Runs at fixed rate (for physics-based movement)
    void FixedUpdate()
    {
        rb2dA.linearVelocity = inputA * speed;
        rb2dE.linearVelocity = inputE * speed;
    }
}