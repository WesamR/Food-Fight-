using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CharInput : MonoBehaviour
{
    private bool grounded=false;
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
    public int speed=5, airSpeed = 2, jumpForce =500;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // changing mass dont affect fall speed
        if (grounded)
        {
            rb.mass=groundedMass;
        }
        else
        {
            rb.mass = nonGroundMass;
        }

        /*
         * Movement
        */
        // moving
        MoveChar(Input.GetAxis("Horizontal"));

        // jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            //rb.drag = airDrag;
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        }
    }

    /*
     * Ground checking
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    /*
     * Movement methods
    */  
    /// <summary>
    /// Moves char left/right
    /// </summary>
    /// <param name="moveVal">1 right, -1 left</param>
    private void MoveChar(float moveVal=0)
    {
        // linear drag changes so movement is slower mid air
        // also the speed

        // if directional buttons are pressed
        if (moveVal!=0)
        {
            if (grounded)
            {
                rb.drag = groundDrag;
                rb.velocity = new Vector2(moveVal * speed, rb.velocity.y);
            }
            else
            {
                rb.drag = airDrag;
                // put limit on how fast chat go midair
                if(rb.velocity.x<=speed)rb.AddForce(new Vector2(moveVal * airSpeed, 0));
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
        Instantiate(grabBox);

        // if multiple items pick closest or first in order

        // have item follow char movement and disabled collision
    }
}
