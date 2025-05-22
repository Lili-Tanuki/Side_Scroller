using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    public ParticleSystem dustFX;

    private Rigidbody2D rb;

    public Animator animator;

    private bool facingRight = true;
    
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int extraJumpValue;

    public bool jumpControl;
 

    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Controls()
    {
        jumpControl = (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0));

        
    }


    void FixedUpdate()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);

        if(moveInput > 0)
        {
            //Flip();
            Debug.Log("droite");
            animator.SetBool("isGoingRight", true);
            animator.SetBool("isMoving", true);
        }
        else if(moveInput < 0)
        {
            Debug.Log("gauche");
            //Flip();
            animator.SetBool("isGoingRight", false);
            animator.SetBool("isMoving", true);
        }
        else if (moveInput == 0)
        {
            Debug.Log("stop");
            animator.SetBool("isMoving", false);
        }
    }

    void Update()
    {
        Controls();
        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
        
        }

        if(jumpControl && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
            dustFX.Play();
        }
        else if(jumpControl && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            dustFX.Play();

        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
