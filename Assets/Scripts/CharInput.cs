using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CharInput : MonoBehaviour
{
    private bool grounded=false;
    private Rigidbody2D rb;

    //[SerializeField]
    public int speed;
    public int jumpForce;
    public int playerNumber;
    string horizontal;
    string jump;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // use playerNumber to determin horizontal and jump buttons
        horizontal = "Horizontal" + playerNumber;
        jump = "Jump" + playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
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

        // if directional buttons are pressed
        if (Input.GetButtonDown(horizontal))
        {
            if (grounded) rb.drag = 1f;
            else rb.drag = 0.5f;
        }
        //left
        if (Input.GetAxis(horizontal) < 0)
        {
            rb.AddForce(new Vector2(-speed,0));
        }
        //right
        else if (Input.GetAxis(horizontal) > 0)
        {
            rb.AddForce(new Vector2(speed, 0));
        }
        else
        {
            rb.AddForce(Vector2.zero);
            rb.drag = 1f;
        }

        //jump
        if (Input.GetButtonDown(jump) && grounded)
        {
            rb.drag = 0.5f;
            rb.AddForce(new Vector2(0,jumpForce));
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
}
