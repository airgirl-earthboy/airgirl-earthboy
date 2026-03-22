using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    // Airgirl variable declarations
    private GameObject airgirl;
    private Animator animatorA;
    private Rigidbody2D rb2dA;
    private float xInputA;
    private bool jumpA;

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
        animatorE = earthboy.GetComponent<Animator>();
        rb2dE = earthboy.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Airgirl animation and input handling (WAD)
        xInputA = 0;
        animatorA.SetFloat("SpeedA", 0);
        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpA = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            animatorA.SetFloat("SpeedA", -1);
            xInputA = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            animatorA.SetFloat("SpeedA", 1);
            xInputA = 1;
        }

        // Earthboy animation and input handling (arrows)
        inputE = Vector2.zero;
        animatorE.SetFloat("SpeedE", 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputE += Vector2.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animatorE.SetFloat("SpeedE", -1);
            inputE += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animatorE.SetFloat("SpeedE", 1);
            inputE += Vector2.right;
        }
    }

    // Runs at fixed rate (for physics-based movement)
    void FixedUpdate()
    {
        // Airgirl movement
        rb2dA.linearVelocity = new Vector2(xInputA * speed, rb2dA.linearVelocity.y);
        if (jumpA)
        {
            rb2dA.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpA = false;
        }

        // Earthboy movement
        rb2dE.linearVelocity = inputE * speed;
    }
}