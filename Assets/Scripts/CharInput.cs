using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CharInput : MonoBehaviour
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

    // Start is called before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;  // Freeze rotation to prevent toppling over
        pam = GetComponent<Psound>();
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
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            pam.jumpSound();
        }
    }

    // Ground checking
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
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
            if (grounded)
            {
                rb.drag = groundDrag;
                rb.velocity = new Vector2(moveVal * speed, rb.velocity.y);
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
