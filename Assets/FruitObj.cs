using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitObj : MonoBehaviour
{
    public bool bulletState = false;
    public int calories = 10;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Food")
        {
            //Debug.Log("ancaclamm");
            bulletState = false;
        }
    }

    //private void FixedUpdate()
    //{
    //    if (rb.velocity.x < 0.15f && rb.velocity.y < 0.15f)
    //    {
    //        Debug.Log("ancaclamm");
    //    }
    //}
}
