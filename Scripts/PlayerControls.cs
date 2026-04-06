using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Declarations for both Airgirl and Earthboy
    public float speed = 5f;
    public float jumpForce = 6f;
    public float jumpCooldown = 0.1f;
    public float groundCheckRadius = 0.2f;
    private LayerMask groundLayer;
    private GameObject paused;

    // Airgirl variable declarations
    public AudioClip floatingSound; // wind woosh loop.ogg
    private GameObject airgirl;
    private AudioSource audioSourceA;
    private Animator animatorA;
    private Rigidbody2D rb2dA;
    private Transform groundCheckA;
    private GateManager gateA;
    private float xInputA;
    private float lastJumpTimeA;
    private bool jumpA;
    private bool groundedA;
    private bool duckingA;

    // Earthboy variable declaration
    public AudioClip walkingSound; // metal_steps_25.wav
    public AudioClip jumpingSound; // jump-sound.flac
    private GameObject earthboy;
    private AudioSource audioSourceE;
    private Animator animatorE;
    private Rigidbody2D rb2dE;
    private Transform groundCheckE;
    private GateManager gateE;
    private float xInputE;
    private float lastJumpTimeE;
    private bool jumpE;
    private bool groundedE;
    private bool duckingE;

    // Start is called before the first frame update
    void Start()
    {
        // Initializations for Airgirl and Earthboy
        groundLayer = LayerMask.GetMask("Ground", "Player"); // Allow players to jump on top of each other to reach collectibles
        paused = GameObject.Find("Canvas").transform.Find("PausedEmpty").gameObject;

        // Airgirl variable initializations
        airgirl = GameObject.Find("Airgirl");
        audioSourceA = airgirl.GetComponent<AudioSource>();
        animatorA = airgirl.GetComponent<Animator>();
        rb2dA = airgirl.GetComponent<Rigidbody2D>();
        groundCheckA = airgirl.transform.Find("GroundCheck");
        gateA = GameObject.Find("Gate-Airgirl").GetComponent<GateManager>();

        // Earthboy variable initializations
        earthboy = GameObject.Find("Earthboy");
        audioSourceE = earthboy.GetComponent<AudioSource>();
        animatorE = earthboy.GetComponent<Animator>();
        rb2dE = earthboy.GetComponent<Rigidbody2D>();
        groundCheckE = earthboy.transform.Find("GroundCheck");
        gateE = GameObject.Find("Gate-Earthboy").GetComponent<GateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gateA.doneA && !paused.activeSelf)
        {
            // Airgirl animation and input handling (WASD)
            rb2dA.simulated = true;
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
            if (Input.GetKey(KeyCode.S))
            {
                duckingA = true;
            }
            else
            {
                duckingA = false;
            }
            if (Input.GetKeyDown(KeyCode.W) && groundedA)
            {
                jumpA = true;
                lastJumpTimeA = Time.time;
            }
            if (Input.GetKey(KeyCode.A))
            {
                xInputA = -1;
                if (!duckingA)
                {
                    animatorA.SetFloat("SpeedA", -1);
                }
                if (!jumpA && audioSourceA != null && !audioSourceA.isPlaying)
                {
                    audioSourceA.clip = floatingSound;
                    audioSourceA.loop = true;
                    audioSourceA.Play();
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                xInputA = 1;
                if (!duckingA)
                {
                    animatorA.SetFloat("SpeedA", 1);
                }
                if (!jumpA && audioSourceA != null && !audioSourceA.isPlaying)
                {
                    audioSourceA.clip = floatingSound;
                    audioSourceA.loop = true;
                    audioSourceA.Play();
                }
            }
            if (xInputA == 0 && !jumpA)
            {
                audioSourceA.Stop();
            }
            animatorA.SetBool("DuckingA", duckingA);
        }
        else
        {
            rb2dA.simulated = false;
            xInputA = 0;
            animatorA.SetFloat("SpeedA", 0);
        }

        if (!gateE.doneE && !paused.activeSelf)
        {
            // Earthboy animation and input handling (arrows)
            rb2dE.simulated = true;
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
            if (Input.GetKey(KeyCode.DownArrow))
            {
                duckingE = true;
            }
            else
            {
                duckingE = false;
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
                if (!jumpE && audioSourceE != null && !audioSourceE.isPlaying)
                {
                    audioSourceE.clip = walkingSound;
                    audioSourceE.loop = true;
                    audioSourceE.Play();
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animatorE.SetFloat("SpeedE", 1);
                xInputE = 1;
                if (!jumpE && audioSourceE != null && !audioSourceE.isPlaying)
                {
                    audioSourceE.clip = walkingSound;
                    audioSourceE.loop = true;
                    audioSourceE.Play();
                }
            }
            if (xInputE == 0 && !jumpE)
            {
                audioSourceE.Stop();
            }
            animatorE.SetBool("DuckingE", duckingE);
        }
        else
        {
            rb2dE.simulated = false;
            xInputE = 0;
            animatorE.SetFloat("SpeedE", 0);
        }

        if (gateA.doneA && gateE.doneE)
        {
            GameObject.Find("Canvas").transform.Find("Success").gameObject.SetActive(true);
        }
    }

    // Runs at fixed rate (for physics-based movement)
    void FixedUpdate()
    {
        // Airgirl movement
        if (jumpA)
        {
            rb2dA.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (audioSourceA != null && !audioSourceA.isPlaying)
            {
                audioSourceA.PlayOneShot(jumpingSound);
            }
            jumpA = false;
        }
        rb2dA.linearVelocity = new Vector2(xInputA * speed, rb2dA.linearVelocity.y);

        // Earthboy movement
        if (jumpE)
        {
            rb2dE.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (audioSourceE != null && !audioSourceE.isPlaying)
            {
                audioSourceE.PlayOneShot(jumpingSound);
            }
            jumpE = false;
        }
        rb2dE.linearVelocity = new Vector2(xInputE * 2 * speed, rb2dE.linearVelocity.y);
    }
}