using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CharInput : MonoBehaviour
{
    private bool grounded=false;
    private Rigidbody2D rb;

    [SerializeField]
    public int speed=30,jumpForce = 1000;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            rb.mass=2;
        }
        else
        {
            rb.mass = 10;
        }
        /*
         * Movement
        */

        // if directional buttons are pressed
        if (Input.GetButtonDown("Horizontal"))
        {
            rb.drag= 2f;
        }
        //left
        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(new Vector2(-speed,0));
        }
        //right
        else if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(new Vector2(speed, 0));
        }
        else
        {
            rb.AddForce(Vector2.zero);
            rb.drag = 0.05f;
        }

        //jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
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
