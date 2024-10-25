using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class charinput1 : MonoBehaviour
{
    private bool grounded = false;
    private Rigidbody2D rb;

    [Header("Grabbing/Throwing")]
    [SerializeField]
    private GameObject grabBox;

    [Header("Movements")]
    [SerializeField]
    private int groundedMass = 1, nonGroundMass = 1;
    [SerializeField]
    public float groundDrag = 5, airDrag = 0.5f;
    [SerializeField]
    public int speed = 5, airSpeed = 2, jumpForce = 500;

    public Psound pam;
    public Animator animator;

    // Start is called before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;  // Freeze rotation to prevent toppling over
        pam = GetComponent<Psound>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (grounded)
        {
            rb.mass = groundedMass;
        }
        else
        {
            rb.mass = nonGroundMass;
        }

        // Movement
        MoveChar(Input.GetAxis("Horizontal"));

        // Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("run");
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            pam.jumpSound();
            grounded = false;
            animator.SetBool("isJumping",!grounded);
        }
    }

    // Ground checking
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("isJumping",!grounded);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            
        }
    }

    // Movement methods
    private void MoveChar(float moveVal = 0)
    {
        if (moveVal != 0)
        {
            // transform.localScale = new Vector2(moveVal, 1f);
            if(moveVal<0)GetComponent<SpriteRenderer>().flipX = true;
            if(moveVal>0)GetComponent<SpriteRenderer>().flipX = false;
            
            if (grounded)
            {
                rb.drag = groundDrag;
                rb.velocity = new Vector2(moveVal * speed, rb.velocity.y);
                animator.SetFloat("xVelocity",Mathf.Abs(rb.velocity.x));
                animator.SetFloat("yVelocity",rb.velocity.y);
            }
            else
            {
                rb.drag = airDrag;
                if (Mathf.Abs(rb.velocity.x) <= speed)
                {
                    rb.AddForce(new Vector2(moveVal * airSpeed, 0));
                }
            }
        }
        else
        {
            rb.drag = grounded ? groundDrag : airDrag;
        }
    }

    private void GrabItem()
    {
        Instantiate(grabBox);
    }
}
