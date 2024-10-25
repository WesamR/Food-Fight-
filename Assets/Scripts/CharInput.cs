using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharInput : MonoBehaviour
{
    private int moveInput = 0;
    private bool facingRight = true;
    private bool grounded = false;
    private Rigidbody2D rb;

    public int FacingDir { get => facingRight ? 1 : -1; }// returns char facing direction as 1/-1
    [Header("Grabbing/Throwing")]
    [SerializeField]
    private GameObject grabBox;

    [Header("Movements")]
    [SerializeField]
    private int groundedGrav = 1, nonGroundGrav = 3;
    [SerializeField]
    public float groundDrag = 5, airDrag = 0.5f;
    [SerializeField]
    public int speed = 6, airSpeed = 50, jumpForce = 800;

    // animation
    public Psound pam;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pam = GetComponent<Psound>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // change grav to make falling faster
        if (grounded)
        {
            rb.gravityScale = groundedGrav;
        }
        else
        {
            rb.gravityScale = nonGroundGrav;
        }

        /*
         * Movement
        */
        // moving
        MoveChar(moveInput);

        // jump
        //if (Input.GetButtonDown("Jump") && grounded)
        //{
        //    //rb.drag = airDrag;
        //    rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        //}
    }

    /*
     * Ground checking
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            animator.SetBool("isJumping", !grounded);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
            pam.jumpSound();
            animator.SetBool("isJumping", !grounded);
        }
    }

    /*
     * Movement methods
    */

    public void Move(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector2>());
        moveInput = (int)Mathf.Round(context.ReadValue<Vector2>().x);

        // changes facing dir
        if (moveInput > 0) facingRight = true;
        else if (moveInput < 0) facingRight = false;
    }

    /*
     * Jump method
     */
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
            JumpChar();
    }

    private void JumpChar()
    {
        if (grounded)
        {
            //rb.drag = airDrag;
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        }
    }

    /// <summary>
    /// Moves char left/right
    /// </summary>
    /// <param name="moveVal">1 right, -1 left</param>
    private void MoveChar(float moveVal = 0)
    {
        // linear drag changes so movement is slower mid air
        // also the speed

        // flip animation depending on direction
        if (moveVal < 0) GetComponent<SpriteRenderer>().flipX = true;
        if (moveVal > 0) GetComponent<SpriteRenderer>().flipX = false;

        // if directional buttons are pressed
        if (moveVal != 0)
        {
            if (grounded)
            {
                rb.drag = groundDrag;
                rb.velocity = new Vector2(moveVal * speed, rb.velocity.y);
                animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
                animator.SetFloat("yVelocity", rb.velocity.y);
            }
            else
            {
                rb.drag = airDrag;

                // put limit on how fast chat go midair
                if (Mathf.Abs(rb.velocity.x) <= speed) rb.AddForce(new Vector2(moveVal * airSpeed, 0));
            }
        }
        else
        {
            //rb.AddForce(rb.velocity);
            if (grounded) rb.drag = groundDrag;
            else rb.drag = airDrag;
        }

    }

    private void GrabItem()
    {
        // spawn grab trigger
        //Instantiate(grabBox);

        // if multiple items pick closest or first in order

        // have item follow char movement and disabled collision
    }
}
