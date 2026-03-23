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
    private GateManager gateA;
    private float xInputA;
    private float lastJumpTimeA;
    private bool jumpA;
    private bool groundedA;

    // Earthboy variable declaration
    private GameObject earthboy;
    private Animator animatorE;
    private Rigidbody2D rb2dE;
    private Transform groundCheckE;
    private GateManager gateE;
    private float xInputE;
    private float lastJumpTimeE;
    private bool jumpE;
    private bool groundedE;

    // Start is called before the first frame update
    void Start()
    {
        // Initializations for Airgirl and Earthboy
        groundLayer = LayerMask.GetMask("Ground", "Player"); // Allow players to jump on top of each other to reach collectibles

        // Airgirl variable initializations
        airgirl = GameObject.Find("Airgirl");
        animatorA = airgirl.GetComponent<Animator>();
        rb2dA = airgirl.GetComponent<Rigidbody2D>();
        groundCheckA = airgirl.transform.Find("GroundCheck");
        gateA = GameObject.Find("Gate-Airgirl").GetComponent<GateManager>();

        // Earthboy variable initializations
        earthboy = GameObject.Find("Earthboy");
        animatorE = earthboy.GetComponent<Animator>();
        rb2dE = earthboy.GetComponent<Rigidbody2D>();
        groundCheckE = earthboy.transform.Find("GroundCheck");
        gateE = GameObject.Find("Gate-Earthboy").GetComponent<GateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gateA.doneA)
        {
            // Airgirl animation and input handling (WAD)
            xInputA = 0;
            animatorA.SetFloat("SpeedA", 0);
            if (Time.time > lastJumpTimeA + jumpCooldown) // Prevent multiple consecutive jumps
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(groundCheckA.position, groundCheckRadius, groundLayer); // Check if groundCheckA point is touching anything on groundLayer (except Airgirl)
                bool foundGround = false;
                foreach (var h in hits)
                {
                    if (h.gameObject != airgirl)
                    {
                        foundGround = true;
                        break;
                    }
                }
                groundedA = foundGround;
            }
            else
            {
                groundedA = false;
            }
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
        }
        else
        {
            rb2dA.simulated = false;
            xInputA = 0;
            animatorA.SetFloat("SpeedA", 0);
        }

        if (!gateE.doneE)
        {
            // Earthboy animation and input handling (arrows)
            xInputE = 0;
            animatorE.SetFloat("SpeedE", 0);
            if (Time.time > lastJumpTimeE + jumpCooldown) // Prevent multiple consecutive jumps
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(groundCheckE.position, groundCheckRadius, groundLayer); // Check if groundCheckE point is touching anything on groundLayer (except Earthboy)
                bool foundGround = false;
                foreach (var h in hits)
                {
                    if (h.gameObject != earthboy)
                    {
                        foundGround = true;
                        break;
                    }
                }
                groundedE = foundGround;
            }
            else
            {
                groundedE = false;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && groundedE)
            {
                jumpE = true;
                lastJumpTimeE = Time.time;
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
        else
        {
            rb2dE.simulated = false;
            xInputE = 0;
            animatorE.SetFloat("SpeedE", 0);
        }

        if (gateA.doneA && gateE.doneE)
        {
            Debug.Log("Both Airgirl and Earthboy have reached gates");
            GameObject.Find("Canvas").transform.Find("Success").gameObject.SetActive(true);
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