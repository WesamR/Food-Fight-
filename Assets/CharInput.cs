using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CharInput : MonoBehaviour
{
    private bool grounded=false;
    private Rigidbody2D rb;

    [SerializeField]
    private int groundedMass = 1, nonGroundMass = 20;
    
    [SerializeField]
    public float groundDrag = 1, airDrag = 0.5f;
    [SerializeField]
    public int speed=30,jumpForce =500;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // change mass depending on grounded so char falls faster and doesn't float on the way down
        if (grounded)
        {
            rb.mass=1;
        }
        else
        {
            rb.mass = 20;
        }

        /*
         * Movement
        */
        // moving
        if (Input.GetButtonDown("Horizontal")) MoveChar(Input.GetAxis("Horizontal"));
        else MoveChar();

        // jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.drag = 0.5f;
            rb.AddForce(new Vector2(0, jumpForce));
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
     * Movement conditional methods
    */  
    /// <summary>
    /// Moves char left/right
    /// </summary>
    /// <param name="moveVal">1 right, -1 left</param>
    private void MoveChar(float moveVal=0)
    {
        // drag changes so movement is slower mid air

        // if directional buttons are pressed
        if (moveVal!=0)
        {
            if (grounded) rb.drag = groundDrag;
            else rb.drag =airDrag;
            rb.AddForce(new Vector2(moveVal * speed, 0));
        }
        else
        {
            rb.AddForce(Vector2.zero);
            rb.drag = groundDrag;
        }

    }
}
