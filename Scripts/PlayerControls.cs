using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Declarations for both Airgirl and Earthboy
    public float speed = 5f;
    public float jumpForce = 5f;
    public float jumpCooldown = 0.1f;
    public float groundCheckRadius = 0.2f;
    private LayerMask groundLayer;

    // Airgirl variable declarations
    private GameObject airgirl;
    private Animator animatorA;
    private Rigidbody2D rb2dA;
    private Transform groundCheckA;
    private float xInputA;
    private float lastJumpTimeA;
    private bool jumpA;
    private bool groundedA;

    // Earthboy variable declaration
    private GameObject earthboy;
    private Animator animatorE;
    private Rigidbody2D rb2dE;
    private float xInputE;
    private bool jumpE;

    // Start is called before the first frame update
    void Start()
    {
        // Initializations for Airgirl and Earthboy
        groundLayer = LayerMask.GetMask("Ground");

        // Airgirl variable initializations
        airgirl = GameObject.Find("Airgirl");
        animatorA = airgirl.GetComponent<Animator>();
        rb2dA = airgirl.GetComponent<Rigidbody2D>();
        groundCheckA = airgirl.transform.Find("GroundCheck");

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
        if (Time.time > lastJumpTimeA + jumpCooldown) // Prevent multiple consecutive jumps
        {
            Collider2D hit = Physics2D.OverlapCircle(groundCheckA.position, groundCheckRadius, groundLayer); // Check if groundCheckA point is touching anything on groundLayer (except Airgirl)
            if (hit.gameObject != airgirl)
            {
                groundedA = true;
            }
        }
        else
        {
            groundedA = false;
        }
        Debug.Log("Grounded: " + groundedA);
        if (Input.GetKeyDown(KeyCode.W) && groundedA)
        {
            jumpA = true;
            lastJumpTimeA = Time.time;
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
        xInputE = 0;
        animatorE.SetFloat("SpeedE", 0);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpE = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animatorE.SetFloat("SpeedE", -1);
            xInputE = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animatorE.SetFloat("SpeedE", 1);
            xInputE = 1;
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
        rb2dE.linearVelocity = new Vector2(xInputE * speed, rb2dE.linearVelocity.y);
        if (jumpE)
        {
            rb2dE.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpE = false;
        }
    }
}