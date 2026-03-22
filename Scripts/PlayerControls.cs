using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 5f;

    // Airgirl variable declarations
    private GameObject airgirl;
    private Animator animatorA;
    private Rigidbody2D rb2dA;
    private Vector2 inputA;

    // Earthboy variable declaration
    private GameObject earthboy;
    private Animator animatorE;
    private Rigidbody2D rb2dE;
    private Vector2 inputE;
    
    // Start is called before the first frame update
    void Start()
    {
        // Airgirl variable initializations
        airgirl = GameObject.Find("Airgirl");
        animatorA = airgirl.GetComponent<Animator>();
        rb2dA = airgirl.GetComponent<Rigidbody2D>();

        // Earthboy variable initializations
        earthboy = GameObject.Find("Earthboy");
        animatorE = airgirl.GetComponent<Animator>();
        rb2dE = earthboy.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Airgirl input (WAD)
        inputA = Vector2.zero;
        animatorA.SetFloat("SpeedX", 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputA += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            animatorA.SetFloat("SpeedX", -1);
            inputA += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            animatorA.SetFloat("SpeedX", 1);
            inputA += Vector2.right;
        }

        // Earthboy input (arrows)
        inputE = Vector2.zero;
        animatorE.SetFloat("SpeedX", 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputE += Vector2.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animatorE.SetFloat("SpeedX", -1);
            inputE += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animatorE.SetFloat("SpeedX", 1);
            inputE += Vector2.right;
        }
    }

    // Runs at fixed rate (for physics-based movement)
    void FixedUpdate()
    {
        // Airgirl movement
        rb2dA.linearVelocity = inputA * speed;

        // Earthboy movement
        rb2dE.linearVelocity = inputE * speed;
    }
}